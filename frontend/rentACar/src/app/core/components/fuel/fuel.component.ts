import { FuelListModel } from './../../models/listModels/fuelListModel';

import { Component, OnInit } from '@angular/core';
import { FuelCrudService } from 'src/app/features/admins/services/fuel-crud.service';
import { ListResponseModel } from '../../models/listResponseModel';

@Component({
  selector: 'app-fuel',
  templateUrl: './fuel.component.html',
  styleUrls: ['./fuel.component.css']
})
export class FuelComponent implements OnInit {


  fuels: ListResponseModel<FuelListModel>={items:[]};
  selectedFuel: FuelListModel
  constructor(private fuelCrudService:FuelCrudService) { }

  ngOnInit(): void {
    this.getFuels()
  }

  getFuels() {
    this.fuelCrudService.getFuels(0,100).subscribe(data =>
      this.fuels = data)
  }
}
