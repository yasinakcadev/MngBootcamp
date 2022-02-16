import { TestBed } from '@angular/core/testing';

import { FuelCrudService } from './fuel-crud.service';

describe('FuelCrudService', () => {
  let service: FuelCrudService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FuelCrudService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
