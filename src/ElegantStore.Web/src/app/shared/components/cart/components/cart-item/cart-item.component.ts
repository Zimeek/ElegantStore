import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {CartItem} from "../../../../../core/models/cart-item";
import {ProductService} from "../../../../../core/services/product.service";
import {delay, Observable} from "rxjs";
import {Product} from "../../../../../core/models/product";
import {UpdateCartItemRequest} from "../../../../../core/requests/update-cart-item-request";

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent implements OnInit {
  @Input() item!: CartItem;

  @Output() removeItemEvent = new EventEmitter<string>();
  @Output() removeItemQuantityEvent = new EventEmitter<UpdateCartItemRequest>();
  @Output() addItemQuantityEvent = new EventEmitter<UpdateCartItemRequest>();

  product$!: Observable<Product>;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.product$ = this.productService.getProductById(this.item.productId)
  }

  onRemoveItem(): void {
    this.removeItemEvent.emit(this.item.id);
  }

  onRemoveItemQuantity(): void {
    const request: UpdateCartItemRequest = {
      itemId: this.item.id,
      quantity: this.item.quantity - 1
    };

    this.removeItemQuantityEvent.emit(request);
  }

  onAddItemQuantity(): void {
    const request: UpdateCartItemRequest = {
      itemId: this.item.id,
      quantity: this.item.quantity + 1
    };

    this.addItemQuantityEvent.emit(request);
  }

}
