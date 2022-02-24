import { IndividualCustomerService } from './../../../services/individual-customer.service';
import { IndividualCustomer } from './../../../../../core/models/individualCustomer';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-individual-customer-update',
  templateUrl: './individual-customer-update.component.html',
  styleUrls: ['./individual-customer-update.component.css']
})
export class IndividualCustomerUpdateComponent implements OnInit {

  individualCustomer: IndividualCustomer;
  individualCustomerForm!: FormGroup;
  constructor(
    private individualCustomerService: IndividualCustomerService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.updateIndividualCustomerForm()
  }
  updateIndividualCustomerForm() {
    this.individualCustomerForm = this.formBuilder.group({
      id: [this.individualCustomer?.id || 0, Validators.required],
      userId: [this.individualCustomer?.userId || '', Validators.required],
      firstName: [this.individualCustomer?.firstName || 0, Validators.required],
      lastName: [this.individualCustomer?.lastName || '', Validators.required],
      nationalId: [this.individualCustomer?.nationalId || '', Validators.required],
    });
  }

  updateIndividualCustomer() {
    if (!this.individualCustomerForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let individualCustomerToUpdate: IndividualCustomer= { ...this.individualCustomerForm.value };
    this.individualCustomerService.updateIndividualCustomer(individualCustomerToUpdate).subscribe(() => {
      this.toastrService.success('Individual Customer has been updated.');
    });
  }

}
