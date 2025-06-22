import { Component, effect, inject } from '@angular/core';
import { ChatMessagesComponent } from '../components/chat/chat-messages.component';
import { ChatInputComponent } from '../components/chat/chat-input.component';
import { ChatStore } from '../stores/chat.store';
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

    onSend(message: string) {
        this.chatStore.sendMessage(message);
    }

    onAbort() {
        this.chatStore.stopGenerating();
    }
}
