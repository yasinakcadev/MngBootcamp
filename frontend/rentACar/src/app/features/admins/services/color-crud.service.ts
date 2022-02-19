import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Color } from '../models/color';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { ColorListModel } from '../../rentals/models/colorListModel';

@Injectable({
  providedIn: 'root',
})
export class ColorCrudService {
  apiUrl = 'http://localhost:5228/api/Colors/';
  constructor(private httpClient: HttpClient) {}

  getColors(
    page: number,
    size: number
  ): Observable<ListResponseModel<ColorListModel>> {
    let newPath = this.apiUrl + 'getAll?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<ColorListModel>>(newPath);
  }

  addColor(color: Color): Observable<Color> {
    let newPath = this.apiUrl + 'add';
    return this.httpClient.post<Color>(newPath, color);
  }

  updateColor(color: Color): Observable<Color> {
    let newPath = this.apiUrl + 'update';
    return this.httpClient.put<Color>(newPath, color);
  }

  deleteColor(id: number) {
    const deleteOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id,
      },
    };

    let newPath = this.apiUrl + 'delete';
    return this.httpClient.delete<Color>(newPath, deleteOptions);
  }
}
