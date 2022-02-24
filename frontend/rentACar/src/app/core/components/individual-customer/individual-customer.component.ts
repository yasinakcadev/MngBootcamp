import { IndividualCustomerListModel } from './../../models/listModels/individualCustomerListModel';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { Component, OnInit } from '@angular/core';
import { IndividualCustomerService } from 'src/app/features/rentals/services/individual-customer.service';

@Component({
  selector: 'app-individual-customer',
  templateUrl: './individual-customer.component.html',
  styleUrls: ['./individual-customer.component.css']
})
export class IndividualCustomerComponent implements OnInit {

  individualCustomers: ListResponseModel<IndividualCustomerListModel>={items:[]};
  selectedIndividualCustomer: IndividualCustomerListModel
  constructor(private individualCustomerService:IndividualCustomerService) { }

  ngOnInit(): void {
    this.getIndividualCustomers()
  }

  getIndividualCustomers() {
    this.individualCustomerService.getIndividualCustomers(0,100).subscribe(data =>
      this.individualCustomers = data)

      console.log(this.individualCustomers)
  }

}
