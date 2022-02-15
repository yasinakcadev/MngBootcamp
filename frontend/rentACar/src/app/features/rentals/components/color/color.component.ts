import { ColorListModel } from './../../models/colorListModel';
import { ListResponseModel } from './../../../../core/models/listResponseModel';
import { ColorService } from './../../services/color.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css']
})
export class ColorComponent implements OnInit {

    colors:ListResponseModel<ColorListModel>={items:[]}
    selectedColor:ColorListModel
  constructor(private colorService:ColorService) { }

  ngOnInit(): void {

    this.getColors();
  }
  getColors(){
    this.colorService.getColors(0,100).subscribe(data=>
      this.colors=data
      )
  }

}
