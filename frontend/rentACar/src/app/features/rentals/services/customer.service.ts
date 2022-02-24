import { Customer } from './../../../core/models/customer';
import { CustomerListModel } from './../../../core/models/listModels/customerListModel';
import { ListResponseModel } from './../../../core/models/listResponseModel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {


  apiUrl = 'http://localhost:5228/api/Customers/'
  constructor(private httpClient:HttpClient) { }

  getCustomers(page: number, size: number):Observable<ListResponseModel<CustomerListModel>>{
    let newPath=this.apiUrl+ 'getAll?Page='+ page + "&PageSize="+ size;
    return this.httpClient.get<ListResponseModel<CustomerListModel>>(newPath);
  }

  getCustomerByUserId(userId:number):Observable<Customer>{
    let newPath=this.apiUrl+ 'getcustomerbyuserid?UserId='+ userId;
    return this.httpClient.get<Customer>(newPath);
  }

}
