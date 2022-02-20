import { TestBed } from '@angular/core/testing';

import { AdditionalServiceService } from './additional-service.service';

describe('AdditionalServiceService', () => {
  let service: AdditionalServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdditionalServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
