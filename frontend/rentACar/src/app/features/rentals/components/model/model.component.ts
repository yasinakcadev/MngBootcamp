import { ModelService } from './../../services/model.service';
import { ModelListModel } from '../../models/modelListModel';


import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { ModelModel } from '../../models/modelModel';


@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css']
})
export class ModelComponent implements OnInit {

  constructor(private modelService:ModelService) { }
  models: ListResponseModel<ModelListModel> = {items :[]}
  modelsByBrand: ListResponseModel<ModelModel> = {items :[]}
  selectedModel : ModelListModel;

  ngOnInit(): void {
    //this.getModel();
    this.getModelByBrandId();
  }

  getModel(){
    this.modelService.getModel(0,100).subscribe(data=>{
      this.models=data;
    });
  }

  getModelByBrandId(){
    this.modelService.getModelByBrandId(0,100,1).subscribe(data=>{
      this.modelsByBrand = data;
      console.log("gelen data" + data.items);
    });
  }

}
