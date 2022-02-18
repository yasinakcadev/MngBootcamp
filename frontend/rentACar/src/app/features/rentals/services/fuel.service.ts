import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FuelListModel } from 'src/app/core/models/listModels/fuelListModel';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';


@Injectable({
  providedIn: 'root'
})
export class FuelService {

  apiUrl = 'http://localhost:5228/api/Fuels/'
  constructor(private httpClient: HttpClient) {

   }

   getFuels(page: number, size:number):Observable<ListResponseModel<FuelListModel>> {
     let newPath = this.apiUrl + 'getAll?Page' + page + '&PageSize' + size;
     return this.httpClient.get<ListResponseModel<FuelListModel>>(newPath);
   }
}
