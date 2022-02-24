import { AuthService } from './../../../../../core/services/auth.service';
import { CorporateCustomer } from './../../../../../core/models/corporateCustomer';
import { CorporateCustomerService } from './../../../services/corporate-customer.service';
import { ToastrService } from 'ngx-toastr';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-corporate-customer-add',
  templateUrl: './corporate-customer-add.component.html',
  styleUrls: ['./corporate-customer-add.component.css']
})
export class CorporateCustomerAddComponent implements OnInit {

  corporateCustomer: CorporateCustomer;
  corporateCustomerForm!: FormGroup;
  constructor(
    private authService:AuthService,
    private corporateCustomerService: CorporateCustomerService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) { }

  ngOnInit(): void {
    this.createCorporateCustomerForm()
  }

  createCorporateCustomerForm() {
    this.corporateCustomerForm = this.formBuilder.group({
      userId: [this.corporateCustomer?.userId ||this.getUser(), Validators.required],
      companyName: [this.corporateCustomer?.companyName || '', Validators.required],
      taxNumber: [this.corporateCustomer?.taxNumber || '', Validators.required],
    });
  }
  getUser(): number {
    let user = this.authService.giveUser();

    return user.id;
  }

  addCorporateCustomer() {
    if (!this.corporateCustomerForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let corporateCustomerToAdd: CorporateCustomer = { ...this.corporateCustomerForm.value };
    this.corporateCustomerService.addCorporateCustomer(corporateCustomerToAdd).subscribe(() => {
      this.toastrService.error('hata');
      this.toastrService.success('Corporate Customer has been added.');

    }
    ,

    (err)=>{
      this.toastrService.error(err.error.Detail);

      console.log(err)
    }

    );
  }
}
