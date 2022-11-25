import {Pipe, PipeTransform} from "@angular/core";
import {Product} from "../models/product";

@Pipe({
  name: 'sortProducts',
  standalone: true
})
export class SortProductsPipe implements PipeTransform {
  transform(value: Product[] | null, sortOptions: string): Product[] {
    if(value !== null) {
      switch(sortOptions) {
        case 'priceAsc':
          return value.sort((a, b) => a.price - b.price);
        case 'priceDesc':
          return value.sort((a, b) => b.price - a.price);
        default:
          break;
      }
    }
    return value as Product[];
  }
}
