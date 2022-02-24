import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorporateCustomerDeleteComponent } from './corporate-customer-delete.component';

describe('CorporateCustomerDeleteComponent', () => {
  let component: CorporateCustomerDeleteComponent;
  let fixture: ComponentFixture<CorporateCustomerDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorporateCustomerDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CorporateCustomerDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
