import { Color } from './../../models/Color';
import { ColorCrudService } from './../../services/color-crud.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-color-admin',
  templateUrl: './color-admin.component.html',
  styleUrls: ['./color-admin.component.css'],
})
export class ColorAdminComponent implements OnInit {
  color: Color;
  colorForm!: FormGroup;
  constructor(
    private colorCrudService: ColorCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    // this.toastrService.info("    burdan geldi");
    this.createModelForm()}

  createModelForm() {
    this.colorForm = this.formBuilder.group({
      id: [this.color?.id || 0, Validators.required],
      name: [this.color?.colorName || '', Validators.required],
    });
  }

  addColor() {
    if (!this.colorForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let colorToAdd: Color = { ...this.colorForm.value };
    this.colorCrudService.addColor(colorToAdd).subscribe(() => {
      this.toastrService.success('Model has been added.');
    });
  }
  updateColor() {
    if (!this.colorForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let colorToUpdate: Color = { ...this.colorForm.value };
    this.colorCrudService.updateColor(colorToUpdate).subscribe(() => {
      this.toastrService.success('Model has been updated.');
    });
  }
}
