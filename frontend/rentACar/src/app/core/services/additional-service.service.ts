import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AdditionalServiceListModel } from '../models/listModels/additionalServiceListModel';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root',
})
export class AdditionalServiceService {
  apiUrl = 'http://localhost:5228/api/AdditionalServices/';

  constructor(private httpClient: HttpClient) {}

  getAdditionalServices(
    page: number,
    size: number
  ): Observable<ListResponseModel<AdditionalServiceListModel>> {
    let newPath = this.apiUrl + 'getAll?Page=' + page + '&PageSize=' + size;
    return this.httpClient.get<ListResponseModel<AdditionalServiceListModel>>(
      newPath
    );
  }
}
