import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorAdminDeleteComponent } from './color-admin-delete.component';

describe('ColorAdminDeleteComponent', () => {
  let component: ColorAdminDeleteComponent;
  let fixture: ComponentFixture<ColorAdminDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColorAdminDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColorAdminDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
