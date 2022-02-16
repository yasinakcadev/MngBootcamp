import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Color } from '../../../models/color';
import { ColorCrudService } from '../../../services/color-crud.service';

@Component({
  selector: 'app-color-admin-update',
  templateUrl: './color-admin-update.component.html',
  styleUrls: ['./color-admin-update.component.css']
})
export class ColorAdminUpdateComponent implements OnInit {

  color: Color;
  colorForm!: FormGroup;

  constructor(
    private colorCrudService: ColorCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.updateColorForm()
  }

  updateColorForm() {
    this.colorForm = this.formBuilder.group({
      id: [this.color?.id || 0, Validators.required],
      name: [this.color?.colorName || '', Validators.required],
    });
  }

  updateColor() {
    if (!this.colorForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let colorToUpdate: Color = { ...this.colorForm.value };
    this.colorCrudService.updateColor(colorToUpdate).subscribe(() => {
      this.toastrService.success('Color has been updated.');
    });
  }
}
