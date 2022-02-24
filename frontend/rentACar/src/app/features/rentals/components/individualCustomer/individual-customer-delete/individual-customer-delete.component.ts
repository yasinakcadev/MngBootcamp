import { ToastrService } from 'ngx-toastr';
import { IndividualCustomerService } from './../../../services/individual-customer.service';
import { IndividualCustomer } from './../../../../../core/models/individualCustomer';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-individual-customer-delete',
  templateUrl: './individual-customer-delete.component.html',
  styleUrls: ['./individual-customer-delete.component.css']
})
export class IndividualCustomerDeleteComponent implements OnInit {

  individualCustomer:IndividualCustomer;
  individualCustomerForm!: FormGroup;
  constructor(
    private individualCustomerService: IndividualCustomerService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.createIndividualCustomerForm();
  }
  createIndividualCustomerForm() {
    this.individualCustomerForm = this.formBuilder.group({
      id: [this.individualCustomer?.id || '', Validators.required],
    });
  }

  deleteIndividualCustomer() {
    let individualCustomerToDelete: IndividualCustomer = { ...this.individualCustomerForm.value };
    this.individualCustomerService.deleteIndividualCustomer(individualCustomerToDelete.id).subscribe(() => {
      this.toastrService.success('Individual Customer has been deleted.');
    });
  }

}
