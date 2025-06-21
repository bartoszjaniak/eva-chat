import { Component, computed, effect, inject, signal, Signal, WritableSignal } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ChatMessagesComponent } from '../components/chat/chat-messages.component';
import { ChatInputComponent } from '../components/chat/chat-input.component';
import { ChatStreamService } from '../services/chat.service';
import { Location } from '@angular/common';
import { Message } from '../models/message';

@Component({
    selector: 'app-chat-session-container',
    imports: [ChatMessagesComponent, ChatInputComponent],
    templateUrl: './chat-session-container.component.html',
    styleUrls: ['./chat-session-container.component.scss'],
    host: {
        class: 'flex flex-col h-full w-full max-w-3xl mx-auto'
    },
    providers: [ChatStreamService]
})
export class ChatSessionContainerComponent {
    sessionId: string | null = null;
    private loadedMessages =  signal<Message[]>([]);

    protected chatService = inject(ChatStreamService);
    private location = inject(Location);

    private responsedSesionId = computed(() => this.chatService.responseSignal().sessionId);

    protected messages = computed(() => {
        const response = this.chatService.responseSignal();
        return response.message ? [
                ...this.loadedMessages(),
                { type: 'generated', text: response.message } as Message]
            : this.loadedMessages();
    });

    constructor(private router: Router, private route: ActivatedRoute) {
        this.route.paramMap.subscribe(params => {
            this.sessionId = params.get('id');

            // Jeśli jest id, załaduj przykładowe wiadomości
            if (this.sessionId) {
                this.loadedMessages.set(this.getDemoMessages(this.sessionId));
            } else {
                this.loadedMessages.set([]);
            }
        });

        // Ustawienie id sesji w URL bez przeładowania strony
        effect(() => { this.responsedSesionId() && this.location.go('/chat/' + this.responsedSesionId()) });

    }

    onSend(message: string) {
        this.loadedMessages.update(messages => [...messages, { type: 'user', text: message } as Message]);
        this.chatService.streamChatResponse({ sessionId: null, content: message });
    }

    getDemoMessages(id: string) {
        const demo: Record<string, Message[]> = {
            '1': [
                { type: 'user', text: 'Cześć! Co robimy w nowym projekcie?' },
                { type: 'bot', text: 'Możemy zacząć od analizy wymagań.' }
            ],
            '2': [
                { type: 'user', text: 'Masz pomysł na startup?' },
                { type: 'bot', text: 'Tak! Może aplikacja do zarządzania czasem?' }
            ],
            '3': [
                { type: 'user', text: 'Hej, co słychać?' },
                { type: 'bot', text: 'Wszystko dobrze, jak u Ciebie?' }
            ]
        };
        return demo[id] ?? [];
    }
}
