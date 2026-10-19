import { Routes } from '@angular/router';
import { OrderComponent } from './components/order/order.component';

export const routes: Routes = [
  { path: '', component: OrderComponent }, // Loads OrderComponent at the root URL
  { path: '**', redirectTo: '' }         // Fallback redirect for unknown URLs
];