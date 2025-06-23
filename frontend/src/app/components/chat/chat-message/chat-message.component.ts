import { Component, input, computed } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Message } from '../../../models/message';

@Component({
  selector: 'app-chat-message',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './chat-message.component.html',
  styleUrls: ['./chat-message.component.scss']
})
export class ChatMessageComponent {
  message = input<Message>();

  formattedText = computed(() => {
    const msg = this.message();
    if (!msg) return '';
    return msg.text.replace(/\n/g, '<br>');
  });
}
