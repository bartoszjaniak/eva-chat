import { Component, HostListener, inject } from '@angular/core';
import { SidebarContainerComponent } from '../features/sidebar-container.component';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-main-layout',
  imports: [SidebarContainerComponent, RouterModule, MatSidenavModule, MatIconModule, MatButtonModule],
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent {
  opened = false;

  private router = inject(Router);

  constructor() {
  this.router.events.pipe(takeUntilDestroyed()).subscribe(() => {
      // Close the sidebar when navigating to a new route
      this.opened = false;
    });
  }

  // close when ESC key is pressed
  @HostListener('document:keydown', ['$event'])
  onKeydown(event: KeyboardEvent) {
    if (event.key === 'Escape') {
      this.opened = false;
    }
  }
}
