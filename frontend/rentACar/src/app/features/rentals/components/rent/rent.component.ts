import { CustomerListModel } from './../../../../core/models/listModels/customerListModel';
import { Customer } from './../../../../core/models/customer';
import { CustomerService } from './../../services/customer.service';
import { AdditionalServiceService } from './../../../../core/services/additional-service.service';
import { AuthService } from './../../../../core/services/auth.service';
import { CityListModel } from './../../../../core/models/listModels/cityListModel';
import { CityService } from './../../../../core/services/city.service';
import { CarService } from './../../services/car.service';
import { RentModel } from './../../models/rentModel';
import { AdditionalServiceListModel } from './../../../../core/models/listModels/additionalServiceListModel';
import { ListResponseModel } from './../../../../core/models/listResponseModel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
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
    private customerService:CustomerService,
    private additionalService: AdditionalServiceService,
    private authService: AuthService,
    private cityService: CityService,
    private carService: CarService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private router: Router,
    private activatedRoute:ActivatedRoute
  ) {}

  rent: RentModel;
  rentCarForm!: FormGroup;
  selectedCar: CarListModel;
  selectedTakingCity: CityListModel;
  selectedGivingCity: CityListModel;
  userId: number;
  customer:Customer;
  customerId:number;
  carId:number;
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
  customers: ListResponseModel<CustomerListModel> = { items: [] };
 customerIdLoaded=false;

  selectedList: ListResponseModel<number> = { items: [] };
  selectedItem: any;

  carsLoaded = false;
  citiesLoaded = false;
  additionalServicesLoaded = false;
   ngOnInit(): void {
     this.customer=new Customer();
     this.get();

    this.getUserId();
    this.getCustomerByUserId();
    this.getCustomers();
    this.getCars();
    this.getCities();
    this.getAdditionalServices();
    this.createRentForm();
  }

  createRentForm() {
    this.rentCarForm = this.formBuilder.group({
     // id: [this.rent?.id || 0, Validators.required],
      takingCityId: [this.rent?.takingCityId || 0, Validators.required],
      givingCityId: [this.rent?.givingCityId || 0, Validators.required],
    //  customerId: [this.rent?.customerId || '', Validators.required],
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
    rentToAdd.customerId=this.customer.id;
    rentToAdd.id=this.carId;
    console.log(rentToAdd);
    this.carService.rentCar(rentToAdd).subscribe(() => {
      this.toastrService.success('Car has been rented.');
    },

    (err)=>{
      this.toastrService.error(err.error.Detail);

      console.log(err)
    }
    );



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
    console.log(this.customer.id)
  }

  giveSelectedCityId2(event: any) {
    console.log(event.target.value);
  }

  getUser(): number {
    let user = this.authService.giveUser();

    return user.id;
  }

 getUserId(){
  this.userId= this.getUser();
 }

  getCustomerByUserId() {

  this.customerService.getCustomerByUserId(3).subscribe((data)=>{
  this.customer=data
  this.customerIdLoaded=true;
  })

  }
  getCustomers() {
    this.customerService.getCustomers(0, 100).subscribe((data) => {
      this.customers = data;

    });
    console.log(this.customers.items)
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

  get(){
    this.activatedRoute.params.subscribe((params)=>{
      if(params['carId']){
        this.carId=params['carId'];
      }
    })
  }

  // ngOnInit(): void {
  //   this.activatedRoute.params.subscribe((params) => {
  //     if (params['brandId']) {
  //       this.getModelDetailsByBrandId(params['brandId']);
  //     } else {
  //       this.getModelDetails();
  //     }
  //   });
  // }
}
