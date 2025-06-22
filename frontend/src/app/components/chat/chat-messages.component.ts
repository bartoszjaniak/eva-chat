import { Component, Input, output } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Message } from '../../models/message';
import { MatIconModule } from '@angular/material/icon';
import { RateMessageAction } from '../../models/rate-message';

@Component({
  selector: 'app-chat-messages',
  imports: [RouterModule, CommonModule, MatIconModule],
  templateUrl: './chat-messages.component.html',
  styleUrls: ['./chat-messages.component.scss']
})
export class ChatMessagesComponent {
  @Input() messages: Message[] = [];

  public rateMessage = output<RateMessageAction>();

  onRate(message: Message, rating: number) {
    const newRating = message.rating === rating ? 0 : rating;
    this.rateMessage.emit({ messageId: message.id, rating: newRating });
  }

  sessionId: string | null = null;
}
