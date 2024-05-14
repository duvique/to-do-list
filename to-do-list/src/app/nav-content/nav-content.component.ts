import { Component } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { navRoutes } from '../app.routes';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-nav-content',
  standalone: true,
  imports: [MatSidenav, RouterModule, MatIconModule],
  templateUrl: './nav-content.component.html',
  styleUrl: './nav-content.component.css',
})
export class NavContentComponent {
  navRoutes = navRoutes;
}
