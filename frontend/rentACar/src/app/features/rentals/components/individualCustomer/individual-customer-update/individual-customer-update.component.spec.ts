import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualCustomerUpdateComponent } from './individual-customer-update.component';

describe('IndividualCustomerUpdateComponent', () => {
  let component: IndividualCustomerUpdateComponent;
  let fixture: ComponentFixture<IndividualCustomerUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndividualCustomerUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualCustomerUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
