import { Component, OnInit } from '@angular/core';
import { Fuel } from '../../../models/fuel';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FuelCrudService } from '../../../services/fuel-crud.service';

@Component({
  selector: 'app-fuel-admin-update',
  templateUrl: './fuel-admin-update.component.html',
  styleUrls: ['./fuel-admin-update.component.css']
})
export class FuelAdminUpdateComponent implements OnInit {

  fuel: Fuel;
  fuelForm!: FormGroup;
  constructor(
    private fuelCrudService: FuelCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createModelForm()
  }

  createModelForm() {
    this.fuelForm = this.formBuilder.group({
      id: [this.fuel?.id || 0, Validators.required],
      name: [this.fuel?.fuelName || '', Validators.required],
    });
  }

  updateFuel() {
    if (!this.fuelForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let fuelToUpdate: Fuel = { ...this.fuelForm.value };
    this.fuelCrudService.updateFuel(fuelToUpdate).subscribe(() => {
      this.toastrService.success('Fuel has been updated.');
    });
  }

}
