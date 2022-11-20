import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map, Observable, of} from "rxjs";
import {Product} from "../models/product";
import {productsPageSize} from "../../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private products$ = new BehaviorSubject<Product[]>([]);

  constructor(private httpClient: HttpClient) { }

  public getFeaturedProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>('api/Products/Featured');
  }

  public getProductsPaged(page: number, gender: string): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`api/Products?page=${page}&pageSize=${productsPageSize}&gender=${gender}`);
  }

  public getProductById(id: number): Observable<Product> {
    if(this.products$.value.some(product => product.id === id)) {
      return of(this.products$.value.find(product => product.id === id) as Product);
    }

    return this.httpClient.get<Product>(`api/Products/${id}`)
      .pipe(map(product => {
        this.products$.next([...this.products$.value, product]);
        return product;
      }))
  }

  public getProductsCountByGender(gender: string): Observable<number> {
    return this.httpClient.get<number>(`api/Products/Count/${gender}`);
  }
}
