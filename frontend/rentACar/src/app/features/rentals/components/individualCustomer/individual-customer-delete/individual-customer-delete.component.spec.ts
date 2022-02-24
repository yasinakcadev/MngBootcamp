import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndividualCustomerDeleteComponent } from './individual-customer-delete.component';

describe('IndividualCustomerDeleteComponent', () => {
  let component: IndividualCustomerDeleteComponent;
  let fixture: ComponentFixture<IndividualCustomerDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndividualCustomerDeleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndividualCustomerDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
