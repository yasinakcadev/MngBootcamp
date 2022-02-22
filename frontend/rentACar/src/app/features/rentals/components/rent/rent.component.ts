import { AdditionalServiceService } from './../../../../core/services/additional-service.service';
import { AuthService } from './../../../../core/services/auth.service';
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
    private additionalService: AdditionalServiceService,
    private authService: AuthService,
    private cityService: CityService,
    private carService: CarService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private router: Router
  ) {}

  rent: RentModel;
  rentCarForm!: FormGroup;
  selectedCar: CarListModel;
  selectedTakingCity: CityListModel;
  selectedGivingCity: CityListModel;
  userId: number;
  //totalRentDay: number;

  // users : ModelListModel[] = [];
  // additionalServices: ListResponseModel<AdditionalServiceListModel> = {
  //   items: [],
  // };
  cities: ListResponseModel<CityListModel> = { items: [] };
  cars: ListResponseModel<CarListModel> = { items: [] };
  additionalServices: ListResponseModel<AdditionalServiceListModel> = {
    items: [],
  };
  selectedList: ListResponseModel<number> = { items: [] };
  selectedItem: any;

  carsLoaded = false;
  citiesLoaded = false;
  additionalServicesLoaded = false;
  ngOnInit(): void {
    this.getUser();
    this.getCars();
    this.getCities();
    this.getAdditionalServices();
    this.createRentForm();
  }

  createRentForm() {
    this.rentCarForm = this.formBuilder.group({
      id: [this.rent?.id || 0, Validators.required],
      takingCityId: [this.rent?.takingCityId || 0, Validators.required],
      givingCityId: [this.rent?.givingCityId || 0, Validators.required],
      userId: [this.rent?.userId || this.getUser(), Validators.required],
      totalRentDay: [this.rent?.totalRentDay || 0, Validators.required],
      // additionalServices: [this.rent?.additionalServices || [], Validators.required],
    });
  }

  rentCar() {
    if (!this.rentCarForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let rentToAdd: RentModel = { ...this.rentCarForm.value };
    rentToAdd.additionalServices = this.selectedList.items;
    console.log(rentToAdd);
    this.carService.rentCar(rentToAdd).subscribe(() => {

      this.toastrService.success('Car has been rented.');
    });
  }

  getCities() {
    this.cityService.getCities(0, 100).subscribe((data) => {
      this.cities = data;
      this.citiesLoaded = true;
    });
  }
  getAdditionalServices() {
    this.additionalService.getAdditionalServices(0, 100).subscribe((data) => {
      this.additionalServices = data;
      this.additionalServicesLoaded = true;

    });
  }
  getCars() {
    this.carService.getCars(0, 100).subscribe((data) => {
      this.cars = data;
      this.carsLoaded = true;
    });
  }
  giveSelectedCityId() {
    console.log(this.selectedCar);
  }
  getUser(): number {
    let user = this.authService.giveUser();

    return user.id;
  }
  addSelectedList(item: AdditionalServiceListModel) {
    let additionalService = this.selectedList.items.find(
      (ad) => ad === item.id
    );
    if (additionalService) {
      this.selectedList.items.splice(
        this.selectedList.items.indexOf(additionalService),
        1
      );
    } else {
      this.selectedList.items.push(item.id);
    }

    this.getSelectedList();
  }
  getSelectedList() {
    console.log('selected item', this.selectedList);
    return this.selectedList;
  }
}
