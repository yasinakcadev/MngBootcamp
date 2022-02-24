import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualCustomerAddComponent } from './individual-customer-add.component';

describe('IndividualCustomerAddComponent', () => {
  let component: IndividualCustomerAddComponent;
  let fixture: ComponentFixture<IndividualCustomerAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndividualCustomerAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualCustomerAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
