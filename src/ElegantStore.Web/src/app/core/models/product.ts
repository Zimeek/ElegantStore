import {ProductVariant} from "./product-variant";

export interface Product {
  id: number,
  brand: string,
  model: string,
  color: string,
  gender: string,
  imageBase: string,
  price: number,
  variants?: ProductVariant[]
}
