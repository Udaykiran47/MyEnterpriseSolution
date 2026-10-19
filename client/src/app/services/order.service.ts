import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'https://appproducts-fzcdckdqdxf8fgb3.southindia-01.azurewebsites.net/api/Orders';

  constructor(private http: HttpClient) {}

  getOrders(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  createOrder(order: { productName: string; price: number }): Observable<any> {
    return this.http.post<any>(this.apiUrl, order);
  }
}