import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {ActivatedRoute, ParamMap} from "@angular/router";
import {BehaviorSubject, combineLatestWith, map, filter, Observable, switchMap} from "rxjs";
import {Product} from "../../core/models/product";
import {ProductService} from "../../core/services/product.service";
import {ProductItemComponent} from "./components/product-item/product-item.component";

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule, ProductItemComponent],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  gender$!: Observable<string>;
  products$!: Observable<Product[]>;
  page$ = new BehaviorSubject<number>(1);
  disableNextPageButton$ = new BehaviorSubject<boolean>(false);

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.gender$ = this.route.paramMap
      .pipe(map((params: ParamMap) => String(params.get('gender'))));

    this.products$ = this.page$
      .pipe(
        combineLatestWith(this.gender$),
        switchMap(([page, gender]) => {
          return this.productService.getProductsPaged(page, 5, gender)
            .pipe(filter(products => {
              products.length === 0 ? this.disableNextPageButton$.next(true): this.disableNextPageButton$.next(false);
              return products.length > 0
            }))
        }));
  }

  public nextPage(): void {
    this.page$.next(this.page$.value + 1);
  }

  public previousPage(): void {
    if(this.page$.value > 1) {
      this.page$.next(this.page$.value - 1);
    }
  }

}
