import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  selectedMenuItem
  constructor() { }

  ngOnInit(): void {
  }

  setCurrentMenuItem(){



  }

  getRouterLink(){

    if(this.selectedMenuItem!=null){
      console.log(this.selectedMenuItem)
      return this.selectedMenuItem


    }else{
      return ""
    }
    }


  getClass(){
    if(this.selectedMenuItem){
      return "list-group-item active"
    }
    else{
      return "list-group-item"
    }
  }
}
