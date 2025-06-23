import { Component, inject, input } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Session } from '../../models/session';

@Component({
  selector: 'app-session-list',
  standalone: true,
  imports: [RouterModule, MatButtonModule, MatIconModule],
  templateUrl: './session-list.component.html',
  styleUrls: ['./session-list.component.scss']
})
export class SessionListComponent {
  public sessions = input<Session[]>([]);
  public status = input('loading'); // 'loading' | 'error' | 'success'

  private router = inject(Router);

  goToNewChat() {
    // force refresh of the chat store
    this.router.navigate(['/chat'], { onSameUrlNavigation: 'reload' });
  }
}
