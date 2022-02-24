import { CarDetailComponent } from './core/components/car-detail/car-detail.component';
import { AdditinalServiceComponent } from './core/components/additinal-service/additinal-service.component';
import { FuelAdminDeleteComponent } from './features/admins/components/fuel-admin/fuel-admin-delete/fuel-admin-delete.component';
import { FuelAdminAddComponent } from './features/admins/components/fuel-admin/fuel-admin-add/fuel-admin-add.component';
import { FuelAdminUpdateComponent } from './features/admins/components/fuel-admin/fuel-admin-update/fuel-admin-update.component';
import { ColorAdminDeleteComponent } from './features/admins/components/color-admin/color-admin-delete/color-admin-delete.component';
import { AdminComponent } from './features/admins/adminsLayout/components/admin/admin.component';
import { CustomerAddComponent } from './core/components/customer-add/customer-add.component';
import { IndividualCustomerDeleteComponent } from './features/rentals/components/individualCustomer/individual-customer-delete/individual-customer-delete.component';
import { IndividualCustomerUpdateComponent } from './features/rentals/components/individualCustomer/individual-customer-update/individual-customer-update.component';
import { IndividualCustomerAddComponent } from './features/rentals/components/individualCustomer/individual-customer-add/individual-customer-add.component';
import { CorporateCustomerAddComponent } from './features/rentals/components/corporateCustomer/corporate-customer-add/corporate-customer-add.component';
import { CorporateCustomerDeleteComponent } from './features/rentals/components/corporateCustomer/corporate-customer-delete/corporate-customer-delete.component';
import { CorporateCustomerUpdateComponent } from './features/rentals/components/corporateCustomer/corporate-customer-update/corporate-customer-update.component';
import { CorporateCustomerComponent } from './core/components/corporate-customer/corporate-customer.component';
import { IndividualCustomerComponent } from './core/components/individual-customer/individual-customer.component';
import { ColorAdminUpdateComponent } from './features/admins/components/color-admin/color-admin-update/color-admin-update.component';
import { ColorComponent } from './core/components/color/color.component';
import { CarComponent } from './core/components/car/car.component';
import { BrandComponent } from './features/rentals/components/brand/brand.component';
import { RegisterComponent } from './core/components/register/register.component';

import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColorAdminAddComponent } from './features/admins/components/color-admin/color-admin-add/color-admin-add.component';
import { ClaimGuard } from './core/guards/claim.guard';
import { LoginComponent } from './core/components/login/login.component';

import { FuelComponent } from './core/components/fuel/fuel.component';
import { ModelComponent } from './core/components/model/model.component';
import { HomeComponent } from './features/rentals/components/home/home.component';
import { CityComponent } from './core/components/city/city.component';
import { RentComponent } from './features/rentals/components/rent/rent.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'models', component: ModelComponent },
  { path: 'models/brand/:brandId', component: ModelComponent },
  { path: 'colors', component: ColorComponent },
  { path: 'fuels', component: FuelComponent },
  { path: 'brands', component: BrandComponent },
  { path: 'cities', component: CityComponent },
  { path: 'rents', component: RentComponent },
  { path: 'cars', component: CarComponent },
  { path: 'cardetails', component: CarDetailComponent },
  { path: 'cardetails/brand/:brandId', component: CarDetailComponent },
  { path: 'admins/color/update', component: ColorAdminUpdateComponent },
  { path: 'individualcustomers', component: IndividualCustomerComponent },
  { path: 'admins/corporatecustomers', component: CorporateCustomerComponent },
  { path: 'admins/corporatecustomers/add', component: CorporateCustomerAddComponent },
  { path: 'admins/color/delete', component: ColorAdminDeleteComponent },
  { path: 'admins/fuel/add', component: FuelAdminAddComponent },
  { path: 'admins/fuel/update', component: FuelAdminUpdateComponent },
  { path: 'admins/fuel/delete', component: FuelAdminDeleteComponent },
  { path: 'admins/city/add', component: CityComponent },
  { path: 'admins/city/update', component: CityComponent },
  { path: 'admins/city/delete', component: CityComponent },
  { path: 'admins/additionalservices/add', component: AdditinalServiceComponent },
  { path: 'admins/additionalservices/update', component: AdditinalServiceComponent },
  { path: 'admins/additionalservices/delete', component: AdditinalServiceComponent },
  { path: 'admins', component: AdminComponent },
  {
    path: 'corporatecustomers/update',
    component: CorporateCustomerUpdateComponent,
  },
  {
    path: 'corporatecustomers/delete',
    component: CorporateCustomerDeleteComponent,
  },
  {
    path: 'individualcustomers/add',
    component: IndividualCustomerAddComponent,
  },
  {
    path: 'individualcustomers/update',
    component: IndividualCustomerUpdateComponent,
  },
  {
    path: 'individualcustomers/delete',
    component: IndividualCustomerDeleteComponent,
  },
  { path: 'customeradd', component: CustomerAddComponent },
  {
    path: 'admins/color/add',
    component: ColorAdminAddComponent,
    canActivate: [ClaimGuard],
    data: {
      requiredClaims: ['Admin'],
    },
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
