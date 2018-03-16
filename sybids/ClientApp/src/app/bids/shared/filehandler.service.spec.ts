import { TestBed, inject } from '@angular/core/testing';

import { FilehandlerService } from './filehandler.service';

describe('FilehandlerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FilehandlerService]
    });
  });

  it('should be created', inject([FilehandlerService], (service: FilehandlerService) => {
    expect(service).toBeTruthy();
  }));
});
