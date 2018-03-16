import { TestBed, inject } from '@angular/core/testing';

import { LineHandlerService } from './line-handler.service';

describe('LineHandlerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LineHandlerService]
    });
  });

  it('should be created', inject([LineHandlerService], (service: LineHandlerService) => {
    expect(service).toBeTruthy();
  }));
});
