import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map, Observable} from "rxjs";
import {Cart} from "../models/cart";
import {AddCartItemRequest} from "../requests/add-cart-item-request";
import {CartItem} from "../models/cart-item";
import {UpdateCartItemRequest} from "../requests/update-cart-item-request";
//DONE
@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartItems$ = new BehaviorSubject<CartItem[]>([]);

  constructor(private httpClient: HttpClient) { }

  public setCartId(id: string): void {
    localStorage.setItem('cartId', id);
  }

  public getCartId(): string | null {
    return localStorage.getItem('cartId');
  }

  public loadItems(): Observable<void> {
    return this.httpClient.get<Cart>('api/Cart')
      .pipe(map((cart: Cart) => {
        if(this.getCartId() === null) {
          this.setCartId(cart.id);
        }
        this.cartItems$.next(cart.items);
      }));
  }

  public getItems(): Observable<CartItem[]> {
    return this.cartItems$.asObservable();
  }

  public getTotal(): Observable<number> {
    return this.getItems()
      .pipe(map(items => items.reduce((a, b) => {
        return a + (b.quantity * b.price)
      }, 0)))
  }

  public addItem(request: AddCartItemRequest): Observable<void> {
    const item = this.cartItems$.value.find(item => item.productId === request.productId && item.color === request.color);
    if(item !== undefined) {
      const updateRequest: UpdateCartItemRequest = { itemId: item.id, quantity: item.quantity + 1 };

      return this.updateItem(updateRequest);
    }

    return this.httpClient.post<CartItem>('api/Cart', request)
      .pipe(map(newItem => {
        this.cartItems$.next([...this.cartItems$.value, newItem])
      }))
  }

  public updateItem(request: UpdateCartItemRequest): Observable<void> {
    return this.httpClient.put<CartItem>('api/Cart', request)
      .pipe(map(updatedItem => {
        const updatedItems = this.cartItems$.value.map(item =>
          item.id === request.itemId ? { ...item, quantity: updatedItem.quantity } : item
        );

        this.cartItems$.next(updatedItems);
      }))
  }

  public removeItem(itemId: string): Observable<Object> {
    const updatedItems = this.cartItems$.value.filter(item => item.id !== itemId);

    this.cartItems$.next(updatedItems);

    return this.httpClient.delete(`api/Cart/${itemId}`)
  }

  public isEmpty(): boolean {
    return this.cartItems$.value.length === 0;
  }
}
