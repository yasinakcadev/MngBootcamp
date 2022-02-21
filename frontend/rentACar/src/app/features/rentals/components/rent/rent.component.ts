import { CityListModel } from './../../../../core/models/listModels/cityListModel';
import { CityService } from './../../../../core/services/city.service';
import { CarService } from './../../services/car.service';
import { RentModel } from './../../models/rentModel';
import { AdditionalServiceListModel } from './../../../../core/models/listModels/additionalServiceListModel';
import { ListResponseModel } from './../../../../core/models/listResponseModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { CarListModel } from 'src/app/core/models/listModels/carListModel';


@Component({
  selector: 'app-rent',
  templateUrl: './rent.component.html',
  styleUrls: ['./rent.component.css'],
})
export class RentComponent implements OnInit {
  constructor(

    private cityService:CityService,
    private carService: CarService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private router: Router
  ) {}

  rent: RentModel;
  rentCarForm!:FormGroup;
  selectedCar:CarListModel;
  selectedTakingCity:CityListModel;
  selectedGivingCity:CityListModel;
  //totalRentDay: number;


  // users : ModelListModel[] = [];
  // additionalServices: ListResponseModel<AdditionalServiceListModel> = {
  //   items: [],
  // };
  cities: ListResponseModel<CityListModel> = { items: [] };
  cars:  ListResponseModel<CarListModel> = { items: [] };


  // additionalServicesLoaded = false;
  carsLoaded=false;
  citiesLoaded = false;
  ngOnInit(): void {
    this.getCars();
    this.getCities();
    this.createRentForm();
  }

  createRentForm() {
    this.rentCarForm = this.formBuilder.group({
      id: [this.rent?.id || '', Validators.required],
      takingCityId: [this.rent?.takingCityId || '', Validators.required],
      givingCityId: [this.rent?.givingCityId || '', Validators.required],
      userId: [this.rent?.userId || '', Validators.required],
      totalRentDay: [this.rent?.totalRentDay || '', Validators.required],
      additionalServices: [this.rent?.additionalServices || [0], Validators.required],

    });
  }

  rentCar() {
    if (!this.rentCarForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let rentToAdd: RentModel = { ...this.rentCarForm.value };
    this.carService.rentCar(rentToAdd).subscribe(() => {
      console.log("buradayız")
      this.toastrService.success('Car has been rented.');
    });
  }

  getCities() {
    this.cityService.getCities(0, 100).subscribe((data) => {
      this.cities = data;
      this.citiesLoaded=true;

      console.log(this.cities)

    });

  }
  getCars() {
    this.carService.getCars(0, 100).subscribe((data) => {
      this.cars = data;
      this.carsLoaded=true;

      console.log(this.cars)

    });

  }
  giveSelectedCityId(){

    console.log(this.selectedCar)


  }


}
