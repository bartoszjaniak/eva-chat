import { Component } from '@angular/core';
import { SessionListComponent } from '../components/sessions/session-list.component';

@Component({
  selector: 'app-sidebar-container',
  imports: [SessionListComponent],
  templateUrl: './sidebar-container.component.html',
  styleUrls: ['./sidebar-container.component.scss']
})
export class SidebarContainerComponent {}
