import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-chat-messages',
  imports: [RouterModule, CommonModule],
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent {
  @Input() messages: { from: 'user' | 'bot', text: string }[] = [];

  sessionId: string | null = null;
}
