import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable, ReplaySubject} from "rxjs";
import {Cart} from "../models/cart";
import {AddCartItemRequest} from "../requests/add-cart-item-request";
import {CartItem} from "../models/cart-item";
import {UpdateCartItemRequest} from "../requests/update-cart-item-request";

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartSubject = new ReplaySubject<Cart>(1);
  private cart$ = this.cartSubject.asObservable();

  constructor(private httpClient: HttpClient) { }

  public setCartId(id: string): void {
    localStorage.setItem('cartId', id);
  }

  public getCartId(): string | null {
    return localStorage.getItem('cartId');
  }

  public loadCart(): Observable<Cart> {
    return this.httpClient.get<Cart>('api/Cart');
  }

  public getCart(): Observable<Cart> {
    return this.cart$;
  }

  public addItem(request: AddCartItemRequest): Observable<CartItem> {
    return this.httpClient.post<CartItem>('api/Cart', request);
  }

  public updateItem(request: UpdateCartItemRequest): Observable<CartItem> {
    return this.httpClient.put<CartItem>('api/Cart', request);
  }

  public removeItem(itemId: string): Observable<Object> {
    return this.httpClient.delete(`api/Cart/${itemId}`);
  }
}
