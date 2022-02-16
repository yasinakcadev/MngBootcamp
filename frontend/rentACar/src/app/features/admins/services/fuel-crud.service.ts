import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fuel } from '../models/fuel';

@Injectable({
  providedIn: 'root'
})
export class FuelCrudService {

  apiUrl="http://localhost:5228/api/Fuels/"
  constructor(private httpClient: HttpClient) { }

  addFuel(fuel: Fuel):Observable<Fuel> {
    let newPath = this.apiUrl + "add";
    return this.httpClient.post<Fuel>(newPath,fuel);
  }

  updateFuel(fuel: Fuel):Observable<Fuel> {
    let newPath = this.apiUrl + "update";
    return this.httpClient.put<Fuel>(newPath,fuel);
  }

  deleteColor(id:number){
    const deleteOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id,
      },
    };

    let newPath= this.apiUrl+"delete";
    return this.httpClient.delete<Fuel>(newPath,deleteOptions);
  }
}
