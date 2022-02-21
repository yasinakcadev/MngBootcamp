import { Observable } from 'rxjs';
import { ListResponseModel } from './../../../core/models/listResponseModel';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ColorListModel } from '../models/colorListModel';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  apiUrl = 'http://localhost:5228/api/Colors/';
  constructor(private httpClient: HttpClient) {}

  getColors(
    page: number,
    size: number
  ): Observable<ListResponseModel<ColorListModel>> {
    let newPath = this.apiUrl + 'getAll?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<ColorListModel>>(newPath);
  }
}
