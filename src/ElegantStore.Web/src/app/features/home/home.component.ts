import { Component, OnInit } from '@angular/core';
import {CommonModule} from "@angular/common";
import {LandingBannerComponent} from "./components/landing-banner/landing-banner.component";
import {FeaturedProductListComponent} from "./components/featured-product-list/featured-product-list.component";

@Component({
  standalone: true,
  imports: [
    CommonModule,
    LandingBannerComponent,
    FeaturedProductListComponent
  ],
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export default class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
