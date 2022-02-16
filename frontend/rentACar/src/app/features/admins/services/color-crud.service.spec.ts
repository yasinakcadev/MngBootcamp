import { TestBed } from '@angular/core/testing';

import { ColorCrudService } from './color-crud.service';

describe('ColorCrudService', () => {
  let service: ColorCrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ColorCrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
