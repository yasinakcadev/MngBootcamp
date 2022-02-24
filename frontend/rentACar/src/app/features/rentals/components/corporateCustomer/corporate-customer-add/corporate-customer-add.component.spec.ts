import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporateCustomerAddComponent } from './corporate-customer-add.component';

describe('CorporateCustomerAddComponent', () => {
  let component: CorporateCustomerAddComponent;
  let fixture: ComponentFixture<CorporateCustomerAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorporateCustomerAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporateCustomerAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
