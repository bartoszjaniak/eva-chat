import { Component, EventEmitter, input, Output } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FormControl, ReactiveFormsModule, Validators } from '@angular/forms';
import { ResponseStatus } from '../../models/response-status';

@Component({
  selector: 'app-chat-input',
  standalone: true,
  imports: [ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatIconModule],
  templateUrl: './chat-input.component.html',
  styleUrls: ['./chat-input.component.scss'],
  host: {
    class: 'flex items-center gap-2'
  }
})
export class ChatInputComponent {
  @Output() send = new EventEmitter<string>();
  @Output() pause = new EventEmitter<void>();

  public actionStatus = input<ResponseStatus>('idle');

  protected messageControl = new FormControl('', {
    nonNullable: true,
    validators: [Validators.required, Validators.minLength(1)]
  });

  sendMessage() {
    if (this.messageControl.valid) {
      this.send.emit(this.messageControl.getRawValue());
      this.messageControl.setValue(''); // Reset input after sending
      this.messageControl.markAsPristine(); // Mark as pristine to reset validation state
    }
  }

  pauseGeneration() {
    this.pause.emit();
  }
}
