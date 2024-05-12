import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  host: {
    class:'router-component-container'
  },
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
}
