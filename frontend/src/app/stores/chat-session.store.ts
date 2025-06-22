import { Injectable, signal, computed, effect, inject } from '@angular/core';
import { ChatStreamService } from '../services/chat.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { Message } from '../models/message';
import { signalStore, withState, withComputed, withMethods, patchState, withHooks } from '@ngrx/signals';
import { addEntity, setEntities, updateAllEntities, updateEntity, withEntities } from '@ngrx/signals/entities';
import { ResponseStatus } from '../models/response-status';

let currentAbortController: AbortController | null = null;

export const ChatStore = signalStore(
    { providedIn: 'root' },
    withEntities<Message>(),
    withState({
        sessionId: null as string | null,
        status: 'idle' as ResponseStatus
    }),
    withMethods((store, chatService = inject(ChatStreamService)) => ({
        loadMessages: (sessionId: string) => {

        },
        addMessage: (item: Message) => {
            patchState(store, addEntity(item));
        },
        setMessages: (messages: Message[]) => {
            patchState(store, setEntities(messages));
        },
        setStatus: (status: ResponseStatus) => {
            patchState(store, { status });
        },
        async sendMessage(message: string) {
            patchState(store, addEntity({ id: crypto.randomUUID(), type: 'user', text: message } as Message));
            const currentMessages = store.entities();
            let generatedMessage = currentMessages.find(msg => msg.type === 'generated');

            const sessionId = store.sessionId();
            patchState(store, { status: 'pending' });
            currentAbortController = new AbortController();
            try {
                for await (const { SessionId, Chunk } of chatService.streamChatResponse({ sessionId, content: message }, currentAbortController.signal)) {
                    if (SessionId) {
                        patchState(store, { status: 'generating' });
                    }

                    if(!sessionId) {
                        patchState(store, { sessionId: SessionId });
                    }

                    if (generatedMessage) {
                        generatedMessage.text += Chunk;
                        patchState(store, updateEntity({ id: generatedMessage.id, changes: { text: generatedMessage.text } }));
                    } else {
                        generatedMessage = {
                            id: crypto.randomUUID(),
                            type: 'generated',
                            text: Chunk
                        };

                        patchState(store, addEntity(generatedMessage));
                    }
                }

                patchState(store, updateEntity({ id: generatedMessage!.id, changes: { type: 'bot' } }));

                patchState(store, { status: 'idle' });
            } catch (error) {
                if ((error as any).name === 'AbortError') {
                    patchState(store, { status: 'idle' });
                } else {
                    patchState(store, { status: 'error' });
                }
            } finally {
                currentAbortController = null;
            }
        },
        stopGenerating() {
            if (currentAbortController) {
                currentAbortController.abort();
                currentAbortController = null;
                patchState(store, { status: 'idle' });
            }
        }
    }))
);
