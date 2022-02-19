import { ModelListModel } from './../../models/listModels/modelListModel';
import { ListResponseModel } from './../../models/listResponseModel';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ModelService } from '../../services/model.service';
import { ModelModel } from 'src/app/features/rentals/models/modelModel';

@Component({
  selector: 'app-model',
  templateUrl: './model.component.html',
  styleUrls: ['./model.component.css'],
})
export class ModelComponent implements OnInit {
  models: ListResponseModel<ModelListModel> = { items: [] };
  modelsByBrand: ListResponseModel<ModelModel> = { items: [] };
  selectedModel: ModelListModel;
  constructor(
    private modelService: ModelService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => {
      if (params['brandId']) {
        this.getModelDetailsByBrandId(params['brandId']);
      } else {
        this.getModelDetails();
      }
    });
  }

  getModelDetails() {
    this.modelService.getModelDetails(0, 100).subscribe((data) => {
      this.models = data;
      console.log(this.models.items);
    });
  }

  getModel() {
    this.modelService.getModel(0, 100).subscribe((data) => {
      this.models = data;
    });
  }

  getModelDetailsByBrandId(brandId: number) {
    this.modelService
      .getModelDetailsByBrandId(0, 100, brandId)
      .subscribe((data) => {
        this.models = data;
      });
  }

  getModelByBrandId(brandId: number) {
    this.modelService.getModelByBrandId(0, 100, brandId).subscribe((data) => {
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
