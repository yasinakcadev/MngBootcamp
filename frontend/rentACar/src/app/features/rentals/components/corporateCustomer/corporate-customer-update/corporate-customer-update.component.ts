import { CorporateCustomerService } from './../../../services/corporate-customer.service';
import { ToastrService } from 'ngx-toastr';
import { CorporateCustomer } from './../../../../../core/models/corporateCustomer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-corporate-customer-update',
  templateUrl: './corporate-customer-update.component.html',
  styleUrls: ['./corporate-customer-update.component.css']
})
export class CorporateCustomerUpdateComponent implements OnInit {

  corporateCustomer: CorporateCustomer;
  corporateCustomerForm!: FormGroup;
  constructor(
    private corporateCustomerService: CorporateCustomerService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.updateCorporateCustomerForm()
  }
  updateCorporateCustomerForm() {
    this.corporateCustomerForm = this.formBuilder.group({
      id: [this.corporateCustomer?.id || 0, Validators.required],
      userId: [this.corporateCustomer?.userId || '', Validators.required],
      companyName: [this.corporateCustomer?.companyName || 0, Validators.required],
      taxNumber: [this.corporateCustomer?.taxNumber || '', Validators.required],
    });
  }

  updateCorporateCustomer() {
    if (!this.corporateCustomerForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let corporateCustomerToUpdate: CorporateCustomer= { ...this.corporateCustomerForm.value };
    this.corporateCustomerService.updateCorporateCustomer(corporateCustomerToUpdate).subscribe(() => {
      this.toastrService.success('Corporate Customer has been updated.');
    });
  }

}
