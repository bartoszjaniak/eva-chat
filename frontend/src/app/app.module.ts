import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './layout/main-layout.component';
import { SidebarContainerComponent } from './features/sidebar-container.component';
import { ChatSessionContainerComponent } from './features/chat-session-container.component';
import { SessionListComponent } from './components/sessions/session-list.component';
import { ChatMessagesComponent } from './components/chat/chat-messages.component';
import { ChatInputComponent } from './components/chat/chat-input.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule, MAT_ICON_DEFAULT_OPTIONS } from '@angular/material/icon';
import { ChatStore } from './stores/chat-session.store';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule
  ],
  providers: [
    { provide: MAT_ICON_DEFAULT_OPTIONS, useValue: { fontSet: 'outlined' } }
  ]
})
export class AppModule {}
