import { TestBed } from '@angular/core/testing';

import { OpenbugsService } from './openbugs.service';

describe('OpenbugsService', () => {
  let service: OpenbugsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OpenbugsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
