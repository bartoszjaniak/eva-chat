import { Component, inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ChatMessagesComponent } from '../components/chat/chat-messages.component';
import { ChatInputComponent } from '../components/chat/chat-input.component';
import { ChatStore } from '../stores/chat-session.store';

@Component({
    selector: 'app-chat-session-container',
    imports: [ChatMessagesComponent, ChatInputComponent],
    templateUrl: './chat-session-container.component.html',
    styleUrls: ['./chat-session-container.component.scss'],
    host: {
        class: 'flex flex-col h-full w-full max-w-3xl mx-auto'
    }
})
export class ChatSessionContainerComponent {
    protected chatStore = inject(ChatStore);

    constructor(private router: Router, private route: ActivatedRoute) {
        this.route.paramMap.subscribe(params => {
            const sessionId = params.get('id');

            // Jeśli jest id, załaduj przykładowe wiadomości
            if (sessionId) {
                this.chatStore.loadMessages(sessionId);
            } else {
                this.chatStore.setMessages([]);
            }
        });

    }

    onSend(message: string) {
        this.chatStore.sendMessage(message);
    }

    onAbort() {
        this.chatStore.stopGenerating();
    }
}
