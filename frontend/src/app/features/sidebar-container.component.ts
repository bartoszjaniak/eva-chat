import { Component } from '@angular/core';
import { SessionListComponent } from '../components/sessions/session-list.component';
import { SessionStore } from '../stores/session.store';
import { inject } from '@angular/core';

@Component({
  selector: 'app-sidebar-container',
  imports: [SessionListComponent],
  templateUrl: './sidebar-container.component.html',
  styleUrls: ['./sidebar-container.component.scss'],
    host: {
        class: 'max-h-full overflow-y-auto'
    }
})
export class SidebarContainerComponent {
    protected sessionsStore = inject(SessionStore);
}
