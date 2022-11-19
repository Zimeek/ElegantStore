import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {CartService} from "../../core/services/cart.service";
import {Observable} from "rxjs";
import {CartItem} from "../../core/models/cart-item";
import {CheckoutItemComponent} from "./components/checkout-item/checkout-item.component";
import {
  ContactInformationFormComponent
} from "./components/contact-information-form/contact-information-form.component";
import {
  ShippingInformationFormComponent
} from "./components/shipping-information-form/shipping-information-form.component";
import {PaymentFormComponent} from "./components/payment-form/payment-form.component";

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, CheckoutItemComponent, ContactInformationFormComponent, ShippingInformationFormComponent, PaymentFormComponent],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  cartItems$!: Observable<CartItem[]>;
  cartTotal$!: Observable<number>;
  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cartItems$ = this.cartService.getItems();
    this.cartTotal$ = this.cartService.getTotal();
  }

}
