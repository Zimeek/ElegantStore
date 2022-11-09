import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs";
import { Product } from "../../../../core/models/product";
import { ProductService } from "../../../../core/services/product.service";
import { CommonModule } from "@angular/common";

@Component({
  selector: 'app-featured-product-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './featured-product-list.component.html',
  styleUrls: ['./featured-product-list.component.css']
})
export class FeaturedProductListComponent implements OnInit {
  featuredProducts$!: Observable<Product[]>;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.featuredProducts$ = this.productService.getFeaturedProducts();
  }

}
