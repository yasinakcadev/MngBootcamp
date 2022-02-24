import { ActivatedRoute } from '@angular/router';
import { BrandService } from './../../services/brand.service';
import { ListResponseModel } from './../../../../core/models/listResponseModel';
import { Component, OnInit } from '@angular/core';
import { BrandListModel } from '../../models/brandListModel';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.css'],
})
export class BrandComponent implements OnInit {
  brands: ListResponseModel<BrandListModel> = { items: [] };
  selectedBrand: BrandListModel;
  constructor(private brandService: BrandService) {}
  isLoaded: boolean = false;

  ngOnInit(): void {
    this.getBrands();
  }
  getBrands() {
    this.brandService.getBrands(0, 100).subscribe((data) => {
      this.brands = data;
      this.isLoaded = true;
    });
  }

  setCurrentBrand(brand: BrandListModel) {
    this.selectedBrand = brand;
    console.log(this.selectedBrand.name);
  }

  // getRouterLink() {
  //   if (this.selectedBrand != null) {
  //     console.log(this.selectedBrand.id);
  //     return '/models/brand/' + this.selectedBrand.id;
  //   } else {
  //     return '/models/';
  //   }
  // }
  getRouterLink() {
    if (this.selectedBrand != null) {
      console.log(this.selectedBrand.id);
      return '/cardetails/brand/' + this.selectedBrand.id;
    } else {
      return '/cardetails/';
    }
  }
}
