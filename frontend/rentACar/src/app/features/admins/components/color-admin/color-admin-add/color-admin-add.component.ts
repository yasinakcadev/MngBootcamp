import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { Color } from "../../../models/color";
import { ColorCrudService } from "../../../services/color-crud.service";

@Component({
  selector: 'app-color-admin-add',
  templateUrl: './color-admin-add.component.html',
  styleUrls: ['./color-admin-add.component.css']
})
export class ColorAdminAddComponent implements OnInit {

  color: Color;
  colorForm!: FormGroup;

  constructor(
    private colorCrudService: ColorCrudService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.createColorForm()
  }

  createColorForm() {
    this.colorForm = this.formBuilder.group({
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
      this.toastrService.success('Color has been added.');
    });
  }

}
