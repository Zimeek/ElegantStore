import { Component, OnInit } from '@angular/core';
import {CartService} from "../../../core/services/cart.service";
import {Observable, takeUntil} from "rxjs";
import {Unsubscriber} from "../../helpers/unsubscriber";
import {UpdateCartItemRequest} from "../../../core/requests/update-cart-item-request";
import {CartItem} from "../../../core/models/cart-item";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent extends Unsubscriber implements OnInit {
  cartItems$!: Observable<CartItem[]>;
  cartTotal$!: Observable<number>;

  constructor(public cartService: CartService) { super() }

  ngOnInit(): void {
    this.cartService.loadItems()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe();

    this.cartItems$ = this.cartService.getItems();
    this.cartTotal$ = this.cartService.getTotal();
  }

  removeItem(itemId: string): void {
    this.cartService.removeItem(itemId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe();
  }

  updateItemQuantity(request: UpdateCartItemRequest): void {
    if(request.quantity <= 0) {
      this.removeItem(request.itemId);
    } else {
      this.cartService.updateItem(request)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe();
    }
  }
}
