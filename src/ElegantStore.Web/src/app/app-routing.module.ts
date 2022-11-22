import {NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";

const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./features/home/home.component'),
    title: 'ElegantStore - Home'
  },
  {
    path: 'product/:id',
    loadComponent: () => import('./features/product/product.component')
  },
  {
    path: 'products/:gender',
    loadComponent: () => import('./features/products/products.component')
  },
  {
    path: 'checkout',
    loadComponent: () => import('./features/checkout/checkout.component')
  },
  {
    path: '**',
    redirectTo: ''
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
