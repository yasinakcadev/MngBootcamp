import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { FuelListModel } from '../../models/fuelListModel';
import { FuelService } from '../../services/fuel.service';

@Component({
  selector: 'app-fuel',
  templateUrl: './fuel.component.html',
  styleUrls: ['./fuel.component.css']
})
export class FuelComponent implements OnInit {

  fuels: ListResponseModel<FuelListModel>={items:[]};
  selectedFuel: FuelListModel

  constructor(private fuelService: FuelService) { }

  ngOnInit(): void {
    this.getFuels()
  }

  getFuels() {
    this.fuelService.getFuels(0,100).subscribe(data =>
      this.fuels = data)
  }

}
