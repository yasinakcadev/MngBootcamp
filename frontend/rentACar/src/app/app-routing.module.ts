import { BrandComponent } from './features/rentals/components/brand/brand.component';
import { RegisterComponent } from './core/components/register/register.component';

import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColorAdminAddComponent } from './features/admins/components/color-admin/color-admin-add/color-admin-add.component';
import { ClaimGuard } from './core/guards/claim.guard';
import { LoginComponent } from './core/components/login/login.component';
import { ColorComponent } from './core/components/color/color.component';
import { FuelComponent } from './core/components/fuel/fuel.component';
import { ModelComponent } from './core/components/model/model.component';
import { HomeComponent } from './features/rentals/components/home/home.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: HomeComponent },
  { path: 'models', component: ModelComponent },
  { path: 'models/brand/:brandId', component: ModelComponent },
  { path: 'colors', component: ColorComponent },
  { path: 'fuels', component: FuelComponent },
  { path: 'brands', component: BrandComponent },
  {
    path: 'admins/color/add',
    component: ColorAdminAddComponent,
    canActivate: [ClaimGuard],
    data: {
      requiredClaims: ['admin'],
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
