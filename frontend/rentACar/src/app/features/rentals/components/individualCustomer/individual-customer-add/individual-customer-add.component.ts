import { AuthService } from './../../../../../core/services/auth.service';
import { IndividualCustomer } from './../../../../../core/models/individualCustomer';
import { IndividualCustomerService } from './../../../services/individual-customer.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-individual-customer-add',
  templateUrl: './individual-customer-add.component.html',
  styleUrls: ['./individual-customer-add.component.css']
})
export class IndividualCustomerAddComponent implements OnInit {

  individualCustomer: IndividualCustomer;
  individualCustomerForm!: FormGroup;
  constructor(
    private authService:AuthService,
    private individualCustomerService: IndividualCustomerService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.createIndividualCustomerForm()
  }
  createIndividualCustomerForm() {
    this.individualCustomerForm = this.formBuilder.group({
      userId: [this.individualCustomer?.userId || this.getUser(), Validators.required],
      firstName: [this.individualCustomer?.firstName || '', Validators.required],
      lastName: [this.individualCustomer?.lastName || '', Validators.required],
      nationalId: [this.individualCustomer?.nationalId || '', Validators.required],
    });
  }
  getUser(): number {
    let user = this.authService.giveUser();

    return user.id;
  }

  addIndividualCustomer() {
    if (!this.individualCustomerForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let individualCustomerToAdd: IndividualCustomer = { ...this.individualCustomerForm.value };
    this.individualCustomerService.addIndividualCustomer(individualCustomerToAdd).subscribe(() => {
      this.toastrService.success('Individual Customer has been added.');
    }
    ,

    (err)=>{
      this.toastrService.error(err.error.Detail);

      console.log(err)
    });
  }

}
