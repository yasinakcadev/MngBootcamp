import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  selected:""
  constructor() { }

  ngOnInit(): void {
  }

  change(){

    this.selected=

  }
  getClass(){
    if(this.selected){
      return "list-group-item active"
    }
    else{
      return "list-group-item"
    }
  }
}
