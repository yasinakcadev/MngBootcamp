import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrandComponent } from './features/rentals/components/brand/brand.component';
import {ListboxModule} from 'primeng/listbox'
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { ModelComponent } from './features/rentals/components/model/model.component';

@NgModule({
  declarations: [
    AppComponent,
    BrandComponent,
    ModelComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ListboxModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
