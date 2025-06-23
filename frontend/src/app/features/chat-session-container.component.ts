import { Component, effect, inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ChatMessagesComponent } from '../components/chat/chat-messages/chat-messages.component';
import { ChatStore } from '../stores/chat.store';
import { Location } from '@angular/common';
import { ChatInputComponent } from '../components/chat/chat-input/chat-input.component';

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
    protected location = inject(Location);
    protected route = inject(ActivatedRoute);

    constructor() {
        this.route.paramMap.subscribe(params => {
            const sessionId = params.get('id');

            if (sessionId) {
                this.chatStore.loadMessages(sessionId);
            } else {
                this.chatStore.initNewSession();
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
