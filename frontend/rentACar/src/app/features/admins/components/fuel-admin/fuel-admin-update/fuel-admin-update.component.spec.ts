import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FuelAdminUpdateComponent } from './fuel-admin-update.component';

describe('FuelAdminUpdateComponent', () => {
  let component: FuelAdminUpdateComponent;
  let fixture: ComponentFixture<FuelAdminUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FuelAdminUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FuelAdminUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
