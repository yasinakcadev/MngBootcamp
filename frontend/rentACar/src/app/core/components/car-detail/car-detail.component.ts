import { ActivatedRoute } from '@angular/router';
import { CarDetailListModel } from './../../models/listModels/carDetailListModel';
import { ListResponseModel } from './../../models/listResponseModel';
import { CarService } from './../../../features/rentals/services/car.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {

  isLoaded=false;
  carDetails: ListResponseModel<CarDetailListModel>={items:[]};
  selectedCar: CarDetailListModel
  constructor( private carService:CarService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['brandId']) {
        this.getCarDetailsByBrandId(params['brandId']);
      } else {
        this.getCarDetails();
      }
    });
  }
  getCarDetails() {
    this.carService.getCarDetails().subscribe((data) =>{
      this.carDetails = data
      this.isLoaded=true;



    })
  }
  getCarDetailsByBrandId(brandId:number) {
    this.carService.getCarDetailsByBrandId(brandId).subscribe((data) => {
      this.carDetails = data;
      this.isLoaded=true;
      console.log(this.carDetails)
    });
  }
  goToRent(item){

  }

}
