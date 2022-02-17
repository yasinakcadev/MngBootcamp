import { TestBed } from '@angular/core/testing';

import { ClaimGuard } from './claim.guard';

describe('ClaimGuard', () => {
  let guard: ClaimGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ClaimGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
