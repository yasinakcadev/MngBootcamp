import { ListResponseModel } from './../../models/listResponseModel';
import { Component, OnInit } from '@angular/core';
import { ColorCrudService } from 'src/app/features/admins/services/color-crud.service';
import { ColorListModel } from 'src/app/features/rentals/models/colorListModel';

@Component({
  selector: 'app-color',
  templateUrl: './color.component.html',
  styleUrls: ['./color.component.css']
})
export class ColorComponent implements OnInit {

  colors: ListResponseModel<ColorListModel>={items:[]};
  selectedColor: ColorListModel
  constructor(private colorCrudService:ColorCrudService) { }

  ngOnInit(): void {
    this.getColors();
  }

  getColors() {
    this.colorCrudService.getColors(0,100).subscribe(data =>
      this.colors = data)

  }
}
