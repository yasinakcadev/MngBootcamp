import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { ModelListModel } from '../models/modelListModel';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  apiUrl='http://localhost:5228/api/Models/'
  constructor(private httpClient: HttpClient) { }

  getModel(page: number, size: number):Observable<ListResponseModel<ModelListModel>>{
    let newPath=this.apiUrl+'getAll?Page'+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<ModelListModel>>(newPath);
  }
}
