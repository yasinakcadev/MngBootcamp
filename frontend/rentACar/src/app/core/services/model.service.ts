import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ModelListModel } from 'src/app/core/models/listModels/modelListModel';
import { ModelModel } from 'src/app/features/rentals/models/modelModel';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class ModelService {
  apiUrl = 'http://localhost:5228/api/Models/';
  constructor(private httpClient: HttpClient) {}

  getModel(
    page: number,
    size: number
  ): Observable<ListResponseModel<ModelListModel>> {
    let newPath = this.apiUrl + 'getAll?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<ModelListModel>>(newPath);
  }

  getModelDetails(
    page: number,
    size: number
  ): Observable<ListResponseModel<ModelListModel>> {
    let newPath =
      this.apiUrl + 'getallmodeldetails?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<ModelListModel>>(newPath);
  }

  getModelDetailsByBrandId(
    page: number,
    size: number,
    brandId: number
  ): Observable<ListResponseModel<ModelListModel>> {
    let newPath =
      this.apiUrl +
      'getModelDetailListByBrandId?Page=' +
      page +
      '&PageSize=' +
      size +
      '&brandId=' +
      brandId;
    let result =
      this.httpClient.get<ListResponseModel<ModelListModel>>(newPath);
    //result.subscribe(x => console.log(x.items));
    return result;
  }

  getModelByBrandId(
    page: number,
    size: number,
    brandId: number
  ): Observable<ListResponseModel<ModelModel>> {
    let newPath =
      this.apiUrl +
      'getallbybrandid?Page=' +
      page +
      '&PageSize=' +
      size +
      '&brandId=' +
      brandId;
    let result = this.httpClient.get<ListResponseModel<ModelModel>>(newPath);
    //result.subscribe(x => console.log(x.items));
    return result;
  }
}
