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

import { CardModule } from 'primeng/card';

import { FuelAdminAddComponent } from './features/admins/components/fuel-admin/fuel-admin-add/fuel-admin-add.component';
import { FuelAdminUpdateComponent } from './features/admins/components/fuel-admin/fuel-admin-update/fuel-admin-update.component';
import { FuelAdminDeleteComponent } from './features/admins/components/fuel-admin/fuel-admin-delete/fuel-admin-delete.component';
import { ColorAdminAddComponent } from './features/admins/components/color-admin/color-admin-add/color-admin-add.component';
import { ColorAdminDeleteComponent } from './features/admins/components/color-admin/color-admin-delete/color-admin-delete.component';
import { ColorAdminUpdateComponent } from './features/admins/components/color-admin/color-admin-update/color-admin-update.component';
import { LoginComponent } from './core/components/login/login.component';
import { JwtModule } from '@auth0/angular-jwt';
import { RegisterComponent } from './core/components/register/register.component';
import { NaviComponent } from './features/admins/adminsLayout/components/navi/navi.component';
import { FooterComponent } from './features/admins/adminsLayout/components/footer/footer.component';
import { MenuComponent } from './features/admins/adminsLayout/components/menu/menu.component';
import { FuelComponent } from './core/components/fuel/fuel.component';
import { ColorComponent } from './core/components/color/color.component';
import { ModelComponent } from './core/components/model/model.component';
import { HomeComponent } from './features/rentals/components/home/home.component';
import { CityComponent } from './core/components/city/city.component';
import { AdditinalServiceComponent } from './core/components/additinal-service/additinal-service.component';
import { RentComponent } from './features/rentals/components/rent/rent.component';
import { CarComponent } from './core/components/car/car.component';
import { IndividualCustomerComponent } from './core/components/individual-customer/individual-customer.component';
import { CorporateCustomerComponent } from './core/components/corporate-customer/corporate-customer.component';
import { IndividualCustomerAddComponent } from './features/rentals/components/individualCustomer/individual-customer-add/individual-customer-add.component';
import { IndividualCustomerUpdateComponent } from './features/rentals/components/individualCustomer/individual-customer-update/individual-customer-update.component';
import { IndividualCustomerDeleteComponent } from './features/rentals/components/individualCustomer/individual-customer-delete/individual-customer-delete.component';
import { CorporateCustomerAddComponent } from './features/rentals/components/corporateCustomer/corporate-customer-add/corporate-customer-add.component';
import { CorporateCustomerUpdateComponent } from './features/rentals/components/corporateCustomer/corporate-customer-update/corporate-customer-update.component';
import { CorporateCustomerDeleteComponent } from './features/rentals/components/corporateCustomer/corporate-customer-delete/corporate-customer-delete.component';
import { CustomerAddComponent } from './core/components/customer-add/customer-add.component';
import { AdminComponent } from './features/admins/adminsLayout/components/admin/admin.component';
import { CarDetailComponent } from './core/components/car-detail/car-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    BrandComponent,
    ModelComponent,
    FuelComponent,
    ColorComponent,
    FuelAdminAddComponent,
    FuelAdminUpdateComponent,
    FuelAdminDeleteComponent,
    ColorAdminAddComponent,
    ColorAdminDeleteComponent,
    ColorAdminUpdateComponent,
    LoginComponent,
    RegisterComponent,
    NaviComponent,
    FooterComponent,
    MenuComponent,
    HomeComponent,
    CityComponent,
    AdditinalServiceComponent,
    RentComponent,
    CarComponent,
    IndividualCustomerComponent,
    CorporateCustomerComponent,
    IndividualCustomerAddComponent,
    IndividualCustomerUpdateComponent,
    IndividualCustomerDeleteComponent,
    CorporateCustomerAddComponent,
    CorporateCustomerUpdateComponent,
    CorporateCustomerDeleteComponent,
    CustomerAddComponent,
    AdminComponent,
    CarDetailComponent,

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
