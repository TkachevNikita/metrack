import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatButton} from "@angular/material/button";
import {HttpClientModule} from "@angular/common/http";
import {ContactComponent} from "./components/contact/contact.component";
import {ContactService} from "./services/contact.service";

@NgModule({
  declarations: [
    AppComponent,
  ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        MatButton,
        HttpClientModule,
        ContactComponent
    ],
  providers: [
      provideAnimationsAsync(),
      ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
