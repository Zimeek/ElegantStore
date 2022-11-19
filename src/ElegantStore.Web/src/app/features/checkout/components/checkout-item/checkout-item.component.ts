import {Component, Input, OnInit} from '@angular/core';
import {CartItem} from "../../../../core/models/cart-item";
import {Observable} from "rxjs";
import {Product} from "../../../../core/models/product";
import {ProductService} from "../../../../core/services/product.service";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-checkout-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './checkout-item.component.html',
  styleUrls: ['./checkout-item.component.css']
})
export class CheckoutItemComponent implements OnInit {
  @Input() item!: CartItem;
  product$!: Observable<Product>;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.product$ = this.productService.getProductById(this.item.productId);
  }

}
