import { Component, Input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Message } from '../../models/message';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-chat-messages',
  imports: [RouterModule, CommonModule, MatIconModule],
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent {
  @Input() messages: Message[] = [];

  sessionId: string | null = null;
}
