import { CorporateCustomerService } from './../../../features/rentals/services/corporate-customer.service';
import { CorporateCustomerListModel } from './../../models/listModels/corporateCustomerListModel';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-corporate-customer',
  templateUrl: './corporate-customer.component.html',
  styleUrls: ['./corporate-customer.component.css']
})
export class CorporateCustomerComponent implements OnInit {

  corporateCustomers: ListResponseModel<CorporateCustomerListModel>={items:[]};
  selectedCorporateCustomer: CorporateCustomerListModel
  constructor(private corporateCustomerService:CorporateCustomerService) { }

  ngOnInit(): void {
    this.getCorporateCustomers()
  }

  getCorporateCustomers() {
    this.corporateCustomerService.getCorporateCustomers(0,100).subscribe(data =>
      this.corporateCustomers = data)

      console.log(this.corporateCustomers)
  }
}
