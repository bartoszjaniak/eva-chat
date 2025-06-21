import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-session-list',
  standalone: true,
  imports: [RouterModule, MatButtonModule, MatIconModule],
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

  goToNewChat() {
    this.router.navigate(['/chat']);
  }
}
