import {Component, Input, OnInit} from '@angular/core';
import {Product} from "../../../../core/models/product";
import {RouterModule} from "@angular/router";

@Component({
  selector: 'app-product-item',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {
  @Input() product!: Product;

  constructor() { }

  ngOnInit(): void {
  }

}
