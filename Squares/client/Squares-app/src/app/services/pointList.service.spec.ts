/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PointListService } from './pointList.service';

describe('Service: PointList', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PointListService]
    });
  });

  it('should ...', inject([PointListService], (service: PointListService) => {
    expect(service).toBeTruthy();
  }));
});
