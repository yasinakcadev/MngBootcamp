import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Fuel } from '../../../models/fuel';

import { FuelCrudService } from '../../../services/fuel-crud.service';

@Component({
  selector: 'app-fuel-admin-add',
  templateUrl: './fuel-admin-add.component.html',
  styleUrls: ['./fuel-admin-add.component.css']
})
export class FuelAdminAddComponent implements OnInit {
  fuel: Fuel;
  fuelForm!: FormGroup;

  constructor(
    private fuelCrudService: FuelCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createModelForm();
  }

  createModelForm() {
    this.fuelForm = this.formBuilder.group({
      name: [this.fuel?.fuelName || '', Validators.required],
    });
  }

  addFuel() {
    if (!this.fuelForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let fuelToAdd: Fuel = { ...this.fuelForm.value };
    this.fuelCrudService.addFuel(fuelToAdd).subscribe(() => {
      this.toastrService.success('Fuel has been added.');
    });
  }
}
