import { Component, input, output, EventEmitter } from '@angular/core';
import { Message } from '../../../models/message';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-chat-rating',
  imports: [MatIconModule],
  templateUrl: './chat-rating.component.html',
  styleUrls: ['./chat-rating.component.scss']
})
export class ChatRatingComponent {
  message = input<Message>();
  rateMessage = output<{ messageId: string; rating: number }>();

  onRate(rating: number) {
    const msg = this.message();
    if (!msg) return;
    const newRating = msg.rating === rating ? 0 : rating;
    this.rateMessage.emit({ messageId: msg.id, rating: newRating });
  }
}
