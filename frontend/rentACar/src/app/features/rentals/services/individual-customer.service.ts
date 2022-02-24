import { IndividualCustomer } from './../../../core/models/individualCustomer';
import { IndividualCustomerListModel } from './../../../core/models/listModels/individualCustomerListModel';

import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IndividualCustomerService {

  apiUrl = 'http://localhost:5228/api/IndividualCustomers/'
  constructor(private httpClient:HttpClient) { }

  getIndividualCustomers(page: number, size: number):Observable<ListResponseModel<IndividualCustomerListModel>>{
    let newPath=this.apiUrl+ 'getAll?Page='+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<IndividualCustomerListModel>>(newPath);
  }

  addIndividualCustomer(individualCustomer: IndividualCustomer): Observable<IndividualCustomer> {
    let newPath = this.apiUrl + 'add';
    return this.httpClient.post<IndividualCustomer>(newPath, individualCustomer);
  }

  updateIndividualCustomer(individualCustomer: IndividualCustomer): Observable<IndividualCustomer> {
    let newPath = this.apiUrl + 'update';
    return this.httpClient.put<IndividualCustomer>(newPath, individualCustomer);
  }

  deleteIndividualCustomer(id: number) {
    const deleteOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id,
      },
    };

    let newPath = this.apiUrl + 'delete';
    return this.httpClient.delete<IndividualCustomer>(newPath, deleteOptions);
  }
}
