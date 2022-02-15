import { ModelListModel } from './../models/modelListModel';
import { ListResponseModel } from './../../../core/models/listResponseModel';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BrandListModel } from '../models/brandListModel';
import { Observable } from 'rxjs';
import { ModelModel } from '../models/modelModel';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  apiUrl= 'http://localhost:5228/api/Models/'
  constructor(private httpClient:HttpClient) { }

  getModel(page: number, size: number):Observable<ListResponseModel<ModelListModel>>{
    let newPath=this.apiUrl+'getAll?Page'+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<ModelListModel>>(newPath);
  }

  getModelByBrandId(page: number, size: number,brandId: number):Observable<ListResponseModel<ModelModel>>{
    let newPath=this.apiUrl+'getallbybrandid?Page'+ page + "&PageSize="+ size + "&brandId" + brandId;
    return this.httpClient.get<ListResponseModel<ModelModel>>(newPath);
  }
}
