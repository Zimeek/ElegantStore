import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {CartService} from "../services/cart.service";

@Injectable()
export class Interceptor implements HttpInterceptor {

  constructor(private cartService: CartService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const cartId = this.cartService.getCartId();
    if(cartId !== null) {
      req = req.clone({
        headers: req.headers.set('cartId', cartId)
      });
    }

    return next.handle(req);
  }
}
