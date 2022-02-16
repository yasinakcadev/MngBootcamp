import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Color } from '../models/color';


@Injectable({
  providedIn: 'root'
})
export class ColorCrudService {


  apiUrl="http://localhost:5228/api/Colors/"
  constructor(private httpClient:HttpClient) { }

  addColor(color:Color):Observable<Color>{
    let newPath= this.apiUrl+"add"
    return this.httpClient.post<Color>(newPath,color);
  }

  updateColor(color:Color):Observable<Color>{
    let newPath= this.apiUrl+"update"
   return this.httpClient.put<Color>(newPath,color);
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
    return this.httpClient.delete<Color>(newPath,deleteOptions);
  }
}
