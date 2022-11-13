import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { CartComponent } from './shared/components/cart/cart.component';
import {Interceptor} from "./core/interceptors/interceptor";
import {CartItemComponent} from "./shared/components/cart/components/cart-item/cart-item.component";

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    CartComponent,
    CartItemComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AppRoutingModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: Interceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
