import { BrandService } from './../../services/brand.service';
import { BrandListModel } from '../../models/brandListModel';
import { ListResponseModel } from './../../../../core/models/listResponseModel';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css']
})
export class BrandComponent implements OnInit {

  brands:ListResponseModel<BrandListModel>={items:[]}
  selectedBrand: BrandListModel
  constructor(private brandService:BrandService) { }

  ngOnInit(): void {
    this.getBrands();
  }
  getBrands(){
    this.brandService.getBrands(0,100).subscribe(data=>{
      this.brands=data
    })
  }

}
