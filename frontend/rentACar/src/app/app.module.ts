import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrandComponent } from './features/rentals/components/brand/brand.component';
import {ListboxModule} from 'primeng/listbox';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { ModelComponent } from './features/rentals/components/model/model.component';
import {CardModule} from 'primeng/card';
import { ColorComponent } from './features/rentals/components/color/color.component';
import { FuelComponent } from './features/rentals/components/fuel/fuel.component';
@NgModule({
  declarations: [
    AppComponent,
    BrandComponent,
    ModelComponent,
    ColorComponent,
    FuelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ListboxModule,
    FormsModule,
    ReactiveFormsModule,
    CardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
