import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColorAdminUpdateComponent } from './color-admin-update.component';

describe('ColorAdminUpdateComponent', () => {
  let component: ColorAdminUpdateComponent;
  let fixture: ComponentFixture<ColorAdminUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ColorAdminUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ColorAdminUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
