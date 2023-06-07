import { TestBed } from '@angular/core/testing';

import { SenderService } from './sender.service';

describe('SenderService', () => {
  let service: SenderService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SenderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
