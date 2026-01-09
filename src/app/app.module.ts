import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { AppRoutingModule } from "./app-routing.module.routing";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BaseComponent } from './base/base.component';
 @NgModule({
  declarations: [
    AppComponent,
    BaseComponent

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AdminModule,
    UiModule,
    AppRoutingModule,
    NgxSpinnerModule
],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
