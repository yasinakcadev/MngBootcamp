import { CarService } from './../../../features/rentals/services/car.service';
import { CarListModel } from './../../models/listModels/carListModel';
import { ListResponseModel } from './../../models/listResponseModel';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  cars: ListResponseModel<CarListModel>={items:[]};
  selectedCar: CarListModel
  constructor(private carService:CarService) { }

  ngOnInit(): void {
    this.getCars();
  }
  getCars() {
    this.carService.getCars(0,100).subscribe((data) =>
      this.cars = data)

  }


}
