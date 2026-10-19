import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OrderComponent } from './components/order/order.component'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet], 
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('client');
}