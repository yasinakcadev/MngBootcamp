import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorAdminAddComponent } from './color-admin-add.component';

describe('ColorAdminAddComponent', () => {
  let component: ColorAdminAddComponent;
  let fixture: ComponentFixture<ColorAdminAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColorAdminAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColorAdminAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
