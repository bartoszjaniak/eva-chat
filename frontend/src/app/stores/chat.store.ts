import { EnvironmentInjector, inject, Injector } from '@angular/core';
import { ChatStreamService } from '../services/chat.service';
import { Message, Rating } from '../models/message';
import { signalStore, withState, withMethods, patchState, withHooks, withProps } from '@ngrx/signals';
import { addEntity, removeAllEntities, setEntities, updateEntity, withEntities } from '@ngrx/signals/entities';
import { ResponseStatus } from '../models/response-status';
import { SessionService } from '../services/session.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { RateMessageAction } from '../models/rate-message';
import { SessionStore } from './session.store';


let currentAbortController: AbortController | null = null;

export const ChatStore = signalStore(
    { providedIn: 'root' },
    withEntities<Message>(),
    withState({
        sessionId: null as string | null,
        status: 'idle' as ResponseStatus
    }),
    withProps((store) => ({
        chatService: inject(ChatStreamService),
        sessionService: inject(SessionService),
        location: inject(Location),
        sessionStore: inject(SessionStore)
    })),
    withMethods((store) => ({
        initNewSession() {
            patchState(store, { sessionId: null, status: 'idle' });
            patchState(store, removeAllEntities());
        },
        async loadMessages(sessionId: string) {
            patchState(store, { sessionId, status: 'loading' });
            try {
                patchState(store, removeAllEntities());
                const messages = await store.sessionService.getSessionMessages(sessionId).toPromise();

                patchState(store, setEntities(messages || []));
                patchState(store, { status: 'idle' });
            } catch (error) {
                console.error('Error loading messages:', error);
                patchState(store, { status: 'error' });
            }
        },
        async sendMessage(message: string) {
            patchState(store, addEntity({ id: crypto.randomUUID(), type: 'user', text: message } as Message));
            const currentMessages = store.entities();
            let generatedMessage = currentMessages.find(msg => msg.type === 'generated');

            const sessionId = store.sessionId();

            patchState(store, { status: 'pending' });
            currentAbortController = new AbortController();
            try {
                for await (const { SessionId, MessageId, Chunk } of store.chatService.streamChatResponse({ sessionId, content: message }, currentAbortController.signal)) {
                    if (SessionId) {
                        patchState(store, { status: 'generating' });
                    }

                    if (!store.sessionId()) {
                        patchState(store, { sessionId: SessionId });
                        store.sessionStore.reloadList();
                        store.location.go(`/chat/${SessionId}`);
                    }

                    if (generatedMessage) {
                        generatedMessage.text += Chunk;
                        patchState(store, updateEntity({ id: generatedMessage.id, changes: { text: generatedMessage.text } }));
                    } else {
                        generatedMessage = {
                            id: MessageId,
                            type: 'generated',
                            text: Chunk,
                            rating: Rating.None,
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
        },
        rateMessage(action: RateMessageAction){
            return store.chatService.rateMessage(action).toPromise().then(() => {
                const message = store.entities().find(msg => msg.id === action.messageId);
                if (message) {
                    patchState(store, updateEntity({ id: message.id, changes: { rating: action.rating } }));
                }
            }).catch(error => {
                console.error('Error rating message:', error);
            });
        }
    }))
);
