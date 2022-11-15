import { Component, OnInit } from '@angular/core';
import {ProductService} from "../../core/services/product.service";
import {Product} from "../../core/models/product";
import {ActivatedRoute, ParamMap} from "@angular/router";
import {Unsubscriber} from "../../shared/helpers/unsubscriber";
import {map, Observable, switchMap, takeUntil} from "rxjs";
import {CommonModule} from "@angular/common";
import {CartService} from "../../core/services/cart.service";
import {AddCartItemRequest} from "../../core/requests/add-cart-item-request";

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent extends Unsubscriber implements OnInit {
  product$!:Observable<Product>;
  selectedVariant: string | undefined;

  constructor(
    private productService: ProductService,
    private cartService: CartService,
    private route: ActivatedRoute) { super() }

  ngOnInit(): void {
    this.product$ = this.route.paramMap
      .pipe(
        map((params: ParamMap) => Number(params.get('id'))),
        switchMap((id: number) => this.productService.getProductById(id))
      );
  }

  selectVariant(variant: string): void {
    this.selectedVariant = variant;
  }

  addToCart(product: Product): void {
    const color = this.selectedVariant === undefined ? product.color : this.selectedVariant;
    const request: AddCartItemRequest = {
      productId: product.id,
      price: product.price,
      color: color
    };

    this.cartService.addItem(request)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe();
  }
}
