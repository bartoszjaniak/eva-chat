import { Component } from '@angular/core';
import { SidebarContainerComponent } from '../features/sidebar-container.component';
import { ChatSessionContainerComponent } from '../features/chat-session-container.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [SidebarContainerComponent, RouterModule],
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent {}
