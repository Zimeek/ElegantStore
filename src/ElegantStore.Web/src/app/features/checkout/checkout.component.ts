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
import {FormBuilder, ReactiveFormsModule, Validators} from "@angular/forms";

@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, CheckoutItemComponent, ContactInformationFormComponent, ShippingInformationFormComponent, PaymentFormComponent],
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export default class CheckoutComponent implements OnInit {
  cartItems$!: Observable<CartItem[]>;
  cartTotal$!: Observable<number>;

  checkoutForm = this.formBuilder.group({
    shippingForm: this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      lastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z]+$')]],
      address: ['', [Validators.required, Validators.pattern('\\w+(\\s\\w+){2,}')]],
      city: ['', [Validators.required, Validators.pattern('([a-zA-Z]+|[a-zA-Z]+\\\\s[a-zA-Z]+)')]],
      province: ['', Validators.required],
      postalCode: ['', [Validators.required, Validators.pattern('^(?!.*[DFIOQU])[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9]$')]]
    }),
    contactForm: this.formBuilder.group({
      emailAddress: ['', [Validators.email, Validators.required]],
      phoneNumber: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(12), Validators.pattern('^(1\\s?)?((\\([0-9]{3}\\))|[0-9]{3})[\\s\\-]?[\\0-9]{3}[\\s\\-]?[0-9]{4}$')]]
    }),
    paymentForm: this.formBuilder.group({
      cardNumber: ['', [Validators.required, Validators.pattern('^4[0-9]{12}(?:[0-9]{3})?$')]],
      expirationDate: ['', [Validators.required, Validators.pattern('^(0[1-9]|1[0-2])\\/?(2[2-8]{1})$')]],
      cvc: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(3), Validators.pattern('^\\d{3}$')]]
    })
  },
  {
    updateOn: 'blur'
  })

  constructor(
    private cartService: CartService,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.cartItems$ = this.cartService.getItems();
    this.cartTotal$ = this.cartService.getTotal();
  }

}
