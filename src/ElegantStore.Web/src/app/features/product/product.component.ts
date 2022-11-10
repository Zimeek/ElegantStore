import { Component, OnInit } from '@angular/core';
import {ProductService} from "../../core/services/product.service";
import {Product} from "../../core/models/product";
import {ActivatedRoute, ParamMap} from "@angular/router";
import {Unsubscriber} from "../../shared/helpers/unsubscriber";
import {Observable, takeUntil} from "rxjs";
import {CommonModule} from "@angular/common";

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
    private route: ActivatedRoute) { super() }

  ngOnInit(): void {
    this.route.paramMap
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((params: ParamMap) => this.product$ = this.productService.getProductById(Number(params.get('id'))));
  }

  selectVariant(variant: string): void {
    this.selectedVariant = variant;
  }


}
