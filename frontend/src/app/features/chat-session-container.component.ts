import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ChatMessagesComponent } from '../components/chat/chat-messages.component';
import { ChatInputComponent } from '../components/chat/chat-input.component';

@Component({
  selector: 'app-chat-session-container',
  imports: [ChatMessagesComponent, ChatInputComponent],
  templateUrl: './chat-session-container.component.html',
  styleUrls: ['./chat-session-container.component.scss'],
  host: {
    class: 'flex flex-col h-full'
  }
})
export class ChatSessionContainerComponent {
  sessionId: string | null = null;
  messages: { from: 'user' | 'bot', text: string }[] = [];

  constructor(private router: Router, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(params => {
      this.sessionId = params.get('id');

      // Jeśli jest id, załaduj przykładowe wiadomości
      if (this.sessionId) {
        this.messages = this.getDemoMessages(this.sessionId);
      } else {
        this.messages = [];
      }
    });
  }

  onSend(message: string) {
    if (!this.sessionId) {
      // Tworzymy nowe id (np. timestamp)
      const newId = Date.now().toString();
      this.router.navigate(['/chat', newId]);
      this.messages = [{ from: 'user', text: message }];
    } else {
      this.messages = [...this.messages, { from: 'user', text: message }];
    }
  }

  getDemoMessages(id: string) {
    const demo: Record<string, { from: 'user' | 'bot', text: string }[]> = {
      '1': [
        { from: 'user', text: 'Cześć! Co robimy w nowym projekcie?' },
        { from: 'bot', text: 'Możemy zacząć od analizy wymagań.' }
      ],
      '2': [
        { from: 'user', text: 'Masz pomysł na startup?' },
        { from: 'bot', text: 'Tak! Może aplikacja do zarządzania czasem?' }
      ],
      '3': [
        { from: 'user', text: 'Hej, co słychać?' },
        { from: 'bot', text: 'Wszystko dobrze, jak u Ciebie?' }
      ]
    };
    return demo[id] ?? [];
  }
}
