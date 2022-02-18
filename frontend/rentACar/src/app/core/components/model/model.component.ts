import { ModelModel } from './../../../features/rentals/models/modelModel';
import { ModelListModel } from './../../models/listModels/modelListModel';
import { ListResponseModel } from './../../models/listResponseModel';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../services/model.service';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css']
})
export class ModelComponent implements OnInit {

  models: ListResponseModel<ModelListModel> = {items :[]}
  modelsByBrand: ListResponseModel<ModelModel> = {items :[]}
  selectedModel : ModelListModel;
  constructor(private modelService:ModelService, private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.getModelDetails();
  }

  getModelDetails(){
    this.modelService.getModelDetails(0,100).subscribe(data=>{
      this.models=data;
    });
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

     // this.activatedRoute.params.subscribe(params=>{
    //   if(params["brandId"]){
    //     this.getModelByBrandId(params["brandId"]);

    //   }else{
    //     this.getModel();
    //   }
    // }
    //   )
}
