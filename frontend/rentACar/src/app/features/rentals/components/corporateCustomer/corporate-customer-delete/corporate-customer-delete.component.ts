import { CorporateCustomerService } from './../../../services/corporate-customer.service';
import { ToastrService } from 'ngx-toastr';
import { CorporateCustomer } from './../../../../../core/models/corporateCustomer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-corporate-customer-delete',
  templateUrl: './corporate-customer-delete.component.html',
  styleUrls: ['./corporate-customer-delete.component.css']
})
export class CorporateCustomerDeleteComponent implements OnInit {

  corporateCustomer:CorporateCustomer;
  corporateCustomerForm!: FormGroup;
  constructor(
    private corporateCustomerService: CorporateCustomerService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.createCorporateCustomerForm();
  }
  createCorporateCustomerForm() {
    this.corporateCustomerForm = this.formBuilder.group({
      id: [this.corporateCustomer?.id || '', Validators.required],
    });
  }

  deleteCorporateCustomer() {
    let corporateCustomerToDelete: CorporateCustomer = { ...this.corporateCustomerForm.value };
    this.corporateCustomerService.deleteCorporateCustomer(corporateCustomerToDelete.id).subscribe(() => {
      this.toastrService.success('Corporate Customer has been deleted.');
    });
  }

}
