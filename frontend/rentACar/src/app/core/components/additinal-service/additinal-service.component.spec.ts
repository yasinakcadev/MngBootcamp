import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditinalServiceComponent } from './additinal-service.component';

describe('AdditinalServiceComponent', () => {
  let component: AdditinalServiceComponent;
  let fixture: ComponentFixture<AdditinalServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditinalServiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditinalServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
