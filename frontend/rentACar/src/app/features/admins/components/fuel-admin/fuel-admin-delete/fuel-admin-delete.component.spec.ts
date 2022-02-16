import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelAdminDeleteComponent } from './fuel-admin-delete.component';

describe('FuelAdminDeleteComponent', () => {
  let component: FuelAdminDeleteComponent;
  let fixture: ComponentFixture<FuelAdminDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FuelAdminDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelAdminDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
