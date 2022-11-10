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
