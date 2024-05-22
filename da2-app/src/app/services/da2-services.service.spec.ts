import { TestBed } from '@angular/core/testing';

import { Da2ServicesService } from './da2-services.service';

describe('Da2ServicesService', () => {
  let service: Da2ServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Da2ServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
