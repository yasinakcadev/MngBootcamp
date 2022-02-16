import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelAdminAddComponent } from './fuel-admin-add.component';

describe('FuelAdminAddComponent', () => {
  let component: FuelAdminAddComponent;
  let fixture: ComponentFixture<FuelAdminAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FuelAdminAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelAdminAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
