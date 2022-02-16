import { ModelService } from './../../services/model.service';
import { ModelListModel } from '../../models/modelListModel';


import { Component, OnInit } from '@angular/core';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { ModelModel } from '../../models/modelModel';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css']
})
export class ModelComponent implements OnInit {

  constructor(private modelService:ModelService, private activatedRoute:ActivatedRoute) { }
  models: ListResponseModel<ModelListModel> = {items :[]}
  modelsByBrand: ListResponseModel<ModelModel> = {items :[]}
  selectedModel : ModelListModel;

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["brandId"]){
        this.getModelByBrandId(params["brandId"]);

      }else{
        this.getModel();
      }
    }
      )


  }

  getModel(){
    this.modelService.getModel(0,100).subscribe(data=>{
      this.models=data;
    });
  }

  getModelByBrandId(brandId:number){
    this.modelService.getModelByBrandId(0,100,brandId).subscribe(data=>{
      this.modelsByBrand = data;

    });
  }

}
