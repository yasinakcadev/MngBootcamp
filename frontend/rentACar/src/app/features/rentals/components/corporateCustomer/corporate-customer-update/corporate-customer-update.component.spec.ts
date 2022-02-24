import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporateCustomerUpdateComponent } from './corporate-customer-update.component';

describe('CorporateCustomerUpdateComponent', () => {
  let component: CorporateCustomerUpdateComponent;
  let fixture: ComponentFixture<CorporateCustomerUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorporateCustomerUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporateCustomerUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
