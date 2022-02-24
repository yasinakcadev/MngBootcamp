import { CarDetailListModel } from './../../../core/models/listModels/carDetailListModel';
import { RentModel } from './../models/rentModel';
import { CarListModel } from './../../../core/models/listModels/carListModel';
import { ListResponseModel } from './../../../core/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  apiUrl = 'http://localhost:5228/api/Cars/'
  constructor(private httpClient: HttpClient) { }

  getCars(page: number, size:number):Observable<ListResponseModel<CarListModel>> {
    let newPath = this.apiUrl + 'getAll?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<CarListModel>>(newPath);
  }

  rentCar(rent:RentModel):Observable<ListResponseModel<RentModel>> {
    let newPath = this.apiUrl + 'rent';
    return this.httpClient.put<ListResponseModel<RentModel>>(newPath,rent);
  }

  getCarDetails():Observable<ListResponseModel<CarDetailListModel>> {
    let newPath = this.apiUrl + 'get-all-car-detail';
    return this.httpClient.get<ListResponseModel<CarDetailListModel>>(newPath);
  }

  //http://localhost:5228/api/Cars/get-all-car-detailByBrandId?id=1
  getCarDetailsByBrandId(id:number):Observable<ListResponseModel<CarDetailListModel>> {
    let newPath = this.apiUrl + 'get-all-car-detailByBrandId?id='+id;
    return this.httpClient.get<ListResponseModel<CarDetailListModel>>(newPath);
  }

}
