import { Component, OnInit,Input ,Output} from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


   alisSehriId:any;
   verisSehriId:any;
  constructor() { }

  ngOnInit(): void {
  }

  SetAlisSehri(cityId: any) {
    console.log("rent için alış şehri: ",cityId)
    this.alisSehriId=cityId;
  }
  SetVerisSehri(cityId: any) {
    console.log("rent için veriş şehri: ",cityId)
    this.verisSehriId=cityId;
  }
  sehirleriYaz(){
    console.log("rent için alış şehri: ",this.alisSehriId)
    console.log("rent için veriş şehri: ",this.verisSehriId)
  }


}
