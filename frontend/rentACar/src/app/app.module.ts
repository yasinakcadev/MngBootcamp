import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrandComponent } from './features/rentals/components/brand/brand.component';
import { ListboxModule } from 'primeng/listbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModelComponent } from './features/rentals/components/model/model.component';
import { CardModule } from 'primeng/card';
import { ColorComponent } from './features/rentals/components/color/color.component';
import { FuelComponent } from './features/rentals/components/fuel/fuel.component';
import { FuelAdminAddComponent } from './features/admins/components/fuel-admin/fuel-admin-add/fuel-admin-add.component';
import { FuelAdminUpdateComponent } from './features/admins/components/fuel-admin/fuel-admin-update/fuel-admin-update.component';
import { FuelAdminDeleteComponent } from './features/admins/components/fuel-admin/fuel-admin-delete/fuel-admin-delete.component';
import { ColorAdminAddComponent } from './features/admins/components/color-admin/color-admin-add/color-admin-add.component';
import { ColorAdminDeleteComponent } from './features/admins/components/color-admin/color-admin-delete/color-admin-delete.component';
import { ColorAdminUpdateComponent } from './features/admins/components/color-admin/color-admin-update/color-admin-update.component';
import { LoginComponent } from './core/components/login/login.component';
import { JwtModule } from '@auth0/angular-jwt';

@NgModule({
  declarations: [
    AppComponent,
    BrandComponent,
    ModelComponent,
    ColorComponent,
    FuelComponent,
    FuelAdminAddComponent,
    FuelAdminUpdateComponent,
    FuelAdminDeleteComponent,
    ColorAdminAddComponent,
    ColorAdminDeleteComponent,
    ColorAdminUpdateComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ListboxModule,
    FormsModule,
    ReactiveFormsModule,
    CardModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    BrowserAnimationsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('token'),
        allowedDomains: [],
        disallowedRoutes: [],
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
