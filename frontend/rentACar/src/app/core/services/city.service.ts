import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CityListModel } from '../models/listModels/cityListModel';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class CityService {
  apiUrl = 'http://localhost:5228/api/Cities/';

  constructor(private httpClient: HttpClient) {}

  getCities(
    page: number,
    size: number
  ): Observable<ListResponseModel<CityListModel>> {
    let newPath = this.apiUrl + 'getAll?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<CityListModel>>(newPath);
  }
}