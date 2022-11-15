import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {delay, Observable} from "rxjs";
import {Product} from "../models/product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  public getFeaturedProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>('api/Products/Featured');
  }

  public getProductsPaged(page: number, pageSize: number, gender: string): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`api/Products?page=${page}&pageSize=${pageSize}&gender=${gender}`);
  }

  public getProductById(id: number): Observable<Product> {
    return this.httpClient.get<Product>(`api/Products/${id}`);
  }
}
