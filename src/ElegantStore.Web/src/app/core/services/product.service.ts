import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BehaviorSubject, map, Observable, of} from "rxjs";
import {Product} from "../models/product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private products$ = new BehaviorSubject<Product[]>([]);

  constructor(private httpClient: HttpClient) { }

  public getFeaturedProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>('api/Products/Featured');
  }

  public getProductsPaged(page: number, pageSize: number, gender: string): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`api/Products?page=${page}&pageSize=${pageSize}&gender=${gender}`);
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
}
