import { ModelService } from './../../services/model.service';
import { ModelListModel } from '../../models/modelListModel';


import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';


@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css']
})
export class ModelComponent implements OnInit {

  constructor(private modelService:ModelService) { }
  models: ListResponseModel<ModelListModel> = {items :[]}
  selectedModel : ModelListModel;
  ngOnInit(): void {
    this.getModel();
  }
  getModel(){
    this.modelService.getModel(0,100).subscribe(data=>{
      this.models=data;
    });
  }

}
