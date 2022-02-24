import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {

  constructor(

    private router: Router
  ) { }

  ngOnInit(): void {
  }

  goToAddIndividualCustomer(){
     this.router.navigateByUrl('individualcustomers/add');

  }
  goToAddCorporateCustomer(){
    this.router.navigateByUrl('corporatecustomers/add');

  }



}
