import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FuelListModel } from 'src/app/core/models/listModels/fuelListModel';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { ModelListModel } from '../../rentals/models/modelListModel';
import { Fuel } from '../models/fuel';

@Injectable({
  providedIn: 'root'
})
export class FuelCrudService {

  apiUrl="http://localhost:5228/api/Fuels/"
  constructor(private httpClient: HttpClient) { }

  getFuels(page: number, size: number):Observable<ListResponseModel<FuelListModel>>{
    let newPath=this.apiUrl+'getAll?Page='+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<FuelListModel>>(newPath);
  }

  addFuel(fuel: Fuel):Observable<Fuel> {
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<Fuel>(newPath,fuel);
  }

  updateFuel(fuel: Fuel):Observable<Fuel> {
    let newPath = this.apiUrl + "update";
    return this.httpClient.put<Fuel>(newPath,fuel);
  }

  deleteColor(id:number){
    const deleteOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id,
      },
    };

    let newPath= this.apiUrl+"delete";
    return this.httpClient.delete<Fuel>(newPath,deleteOptions);
  }
}
