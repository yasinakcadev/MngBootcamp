import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FuelCrudService } from '../../../services/fuel-crud.service';

@Component({
  selector: 'app-fuel-admin-delete',
  templateUrl: './fuel-admin-delete.component.html',
  styleUrls: ['./fuel-admin-delete.component.css']
})
export class FuelAdminDeleteComponent implements OnInit {
  id:number;
  fuelForm!: FormGroup;

  constructor(
    private fuelCrudService: FuelCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
  }

  deleteFuel() {

  }

}
