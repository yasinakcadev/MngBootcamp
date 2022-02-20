import { Component, OnInit,Input } from '@angular/core';
import { CityListModel } from '../../models/listModels/cityListModel';
import { ListResponseModel } from '../../models/listResponseModel';
import { CityService } from '../../services/city.service';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css'],
})
export class CityComponent implements OnInit {
  cities: ListResponseModel<CityListModel> = { items: [] };
  selectedCity: any;
  @Output() giveSelectedCityIdEvent = new EventEmitter<any>();

  constructor(private cityService: CityService) {}

  ngOnInit(): void {

    this.getCities();
  }

  getCities() {
    this.cityService.getCities(0, 100).subscribe((data) => {
      this.cities = data;
      console.log('selectedcity', this.selectedCity);


    });
  }

  getSelectedCity(selectedCity: any) {
    console.log('burdan geldim', this.selectedCity);
  }

  giveSelectedCityId() {
    this.giveSelectedCityIdEvent.emit(this.selectedCity);
    console.log(this.selectedCity)

  }
}
