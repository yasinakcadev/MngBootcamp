import { BrandComponent } from './features/rentals/components/brand/brand.component';
import { RegisterComponent } from './core/components/register/register.component';
import { ModelComponent } from './features/rentals/components/model/model.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ColorAdminAddComponent } from './features/admins/components/color-admin/color-admin-add/color-admin-add.component';
import { ClaimGuard } from './core/guards/claim.guard';
import { LoginComponent } from './core/components/login/login.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: BrandComponent },
  { path: 'models', component: ModelComponent },
  { path: 'models/brand/:brandId', component: ModelComponent },
  {
    path: 'admins/color/add',
    component: ColorAdminAddComponent,
    canActivate: [ClaimGuard],
    data: {
      requiredClaims: ["admin"]
    }
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
