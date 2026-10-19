import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { OrderService } from '../../services/order.service';
import { Subscription, interval } from 'rxjs';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit, OnDestroy {
  orders: any[] = [];
  newOrder = {
    productName: '',
    price: 0
  };

  private pollSubscription?: Subscription;

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.loadOrders();

    // Poll every 3 seconds to get live status updates from the backend/database
    this.pollSubscription = interval(3000).subscribe(() => {
      this.loadOrders();
    });
  }

  ngOnDestroy(): void {
    // Unsubscribe when component is destroyed to prevent memory leaks
    if (this.pollSubscription) {
      this.pollSubscription.unsubscribe();
    }
  }

  loadOrders(): void {
    this.orderService.getOrders().subscribe({
      next: (data) => {
        this.orders = data;
      },
      error: (err) => {
        console.error('Error fetching orders:', err);
      }
    });
  }

  submitOrder(): void {
    if (!this.newOrder.productName || this.newOrder.price <= 0) {
      return;
    }

    this.orderService.createOrder(this.newOrder).subscribe({
      next: (response) => {
        console.log('Order created successfully:', response);
        // Reset form
        this.newOrder = { productName: '', price: 0 };
        // Immediately reload orders list
        this.loadOrders();
      },
      error: (err) => {
        console.error('Error creating order:', err);
      }
    });
  }
}