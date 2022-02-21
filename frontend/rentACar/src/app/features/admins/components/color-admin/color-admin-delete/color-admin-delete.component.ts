

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

import { ColorCrudService } from '../../../services/color-crud.service';
import { FuelCrudService } from '../../../services/fuel-crud.service';
import { Color } from './../../../models/color';

@Component({
  selector: 'app-color-admin-delete',
  templateUrl: './color-admin-delete.component.html',
  styleUrls: ['./color-admin-delete.component.css']
})
export class ColorAdminDeleteComponent implements OnInit {

  color:Color;
  colorForm!: FormGroup;

  constructor(
    private colorCrudService: ColorCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createColorForm();
  }

  createColorForm() {
    this.colorForm = this.formBuilder.group({
      id: [this.color?.id || '', Validators.required],
    });
  }

  deleteColor() {
    let colorToDelete: Color = { ...this.colorForm.value };
    this.colorCrudService.deleteColor(colorToDelete.id).subscribe(() => {
      this.toastrService.success('Color has been deleted.');
    });
  }
}
