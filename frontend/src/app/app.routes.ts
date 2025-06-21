import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout.component';
import { ChatSessionContainerComponent } from './features/chat-session-container.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
        { path: 'chat/:id', component: ChatSessionContainerComponent },
        { path: 'chat', component: ChatSessionContainerComponent },
        { path: '', redirectTo: 'chat', pathMatch: 'full' },
    ]
  },
  { path: '**', redirectTo: 'chat' }
];
