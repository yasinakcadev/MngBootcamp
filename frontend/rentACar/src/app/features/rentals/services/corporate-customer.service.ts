import { CorporateCustomer } from './../../../core/models/corporateCustomer';
import { CorporateCustomerListModel } from './../../../core/models/listModels/corporateCustomerListModel';

import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CorporateCustomerService {

  apiUrl = 'http://localhost:5228/api/CorporateCustomers/'
  constructor(private httpClient:HttpClient) { }

  getCorporateCustomers(page: number, size: number):Observable<ListResponseModel<CorporateCustomerListModel>>{
    let newPath=this.apiUrl+ 'getAll?Page='+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<CorporateCustomerListModel>>(newPath);
  }

  addCorporateCustomer(corporateCustomer: CorporateCustomer): Observable<CorporateCustomer> {
    let newPath = this.apiUrl + 'add';
    return this.httpClient.post<CorporateCustomer>(newPath, corporateCustomer);
  }

  updateCorporateCustomer(corporateCustomer: CorporateCustomer): Observable<CorporateCustomer> {
    let newPath = this.apiUrl + 'update';
    return this.httpClient.put<CorporateCustomer>(newPath, corporateCustomer);
  }

  deleteCorporateCustomer(id: number) {
    const deleteOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id,
      },
    };

    let newPath = this.apiUrl + 'delete';
    return this.httpClient.delete<CorporateCustomer>(newPath, deleteOptions);
  }
}
