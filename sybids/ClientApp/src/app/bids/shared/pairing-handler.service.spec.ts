import { TestBed, inject } from '@angular/core/testing';

import { PairingHandlerService } from './pairing-handler.service';

describe('PairingHandlerService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PairingHandlerService]
    });
  });

  it('should be created', inject([PairingHandlerService], (service: PairingHandlerService) => {
    expect(service).toBeTruthy();
  }));
});
