import { ListResponseModel } from './../../../core/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BrandListModel } from '../models/brandListModel';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  apiUrl= 'http://localhost:5228/api/Brands/'
  constructor(private httpClient:HttpClient) { }

  getBrands(page: number, size: number):Observable<ListResponseModel<BrandListModel>>{
    let newPath=this.apiUrl+ 'getAll?Page'+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<BrandListModel>>(newPath);
  }
}
