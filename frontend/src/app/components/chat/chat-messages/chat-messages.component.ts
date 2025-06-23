import { Component, signal, input, output, computed } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Message } from '../../../models/message';
import { MatIconModule } from '@angular/material/icon';
import { RateMessageAction } from '../../../models/rate-message';
import { ChatMessageComponent } from '../chat-message/chat-message.component';
import { ChatRatingComponent } from '../chat-rating/chat-rating.component';

@Component({
  selector: 'app-chat-messages',
  imports: [RouterModule, CommonModule, MatIconModule, ChatMessageComponent, ChatRatingComponent],
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent {
  messages = input<Message[]>();

  public rateMessage = output<RateMessageAction>();

  onRate(event: { messageId: string; rating: number }) {
    this.rateMessage.emit(event);
  }

  sessionId: string | null = null;
}
