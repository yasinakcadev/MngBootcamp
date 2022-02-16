import { ModelComponent } from './features/rentals/components/model/model.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'' ,pathMatch:'full', component: ModelComponent},
  {path:'models' , component: ModelComponent},
  { path: 'models/brand/:brandId', component: ModelComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
