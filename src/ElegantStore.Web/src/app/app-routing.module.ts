import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";

const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/home/home.component').then(c => c.HomeComponent),
    title: 'ElegantStore - Home'
  },
  {
    path: 'product/:id',
    loadComponent: () => import('./features/product/product.component').then(c => c.ProductComponent)
  },
  {
    path: 'products/:gender',
    loadComponent: () => import('./features/products/products.component').then(c => c.ProductsComponent)
  },
  {
    path: 'checkout',
    loadComponent: () => import('./features/checkout/checkout.component').then(c => c.CheckoutComponent)
  }
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
