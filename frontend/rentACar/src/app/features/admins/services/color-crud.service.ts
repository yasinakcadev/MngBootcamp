import { Observable } from 'rxjs';
import { Color } from './../models/Color';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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
  // deleteColor(id:number){
  //   let newPath= this.apiUrl+"delete"
  //   this.httpClient.delete<Observable<Color>>(newPath,id);
  // }
}
