import { Injectable } from "@angular/core";
import { Message } from "../models/message";
import { ChatStore } from "../stores/chat-session.store";

@Injectable({ providedIn: 'root' })
export class SessionService {

    private chatStore = new ChatStore();
    private sessions: Record<string, Message[]> = {
        '1': [
            { id: '1', type: 'user', text: 'Cześć! Co robimy w nowym projekcie?' },
            { id: '2', type: 'bot', text: 'Możemy zacząć od analizy wymagań.' }
        ],
        '2': [
            { id: '3', type: 'user', text: 'Masz pomysł na startup?' },
            { id: '4', type: 'bot', text: 'Tak! Może aplikacja do zarządzania czasem?' }
        ],
        '3': [
            { id: '5', type: 'user', text: 'Hej, co słychać?' },
            { id: '6', type: 'bot', text: 'Wszystko dobrze, jak u Ciebie?' }
        ]
    };

    getSessionMessages(sessionId: string): Message[] {
        return this.sessions[sessionId] || [];
    }

    setSession(sessionId: string) {
        const messages = this.getSessionMessages(sessionId);
        this.chatStore.setMessages(messages);
    }
}
