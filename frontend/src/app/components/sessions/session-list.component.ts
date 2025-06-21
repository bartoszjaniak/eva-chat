import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-session-list',
  standalone: true,
  imports: [RouterModule, MatButtonModule],
  templateUrl: './session-list.component.html',
  styleUrls: ['./session-list.component.scss']
})
export class SessionListComponent {
  sessions = [
    { id: '1', name: 'Nowy projekt' },
    { id: '2', name: 'Pomysły na startup' },
    { id: '3', name: 'Prywatny czat' }
  ];

  constructor(private router: Router) {}

  goToSession(sessionId: string) {
    this.router.navigate(['/chat', sessionId]);
  }

  goToNewChat() {
    this.router.navigate(['/chat']);
  }
}
