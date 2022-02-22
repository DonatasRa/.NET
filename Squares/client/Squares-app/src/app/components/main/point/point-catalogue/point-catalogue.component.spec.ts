import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PointCatalogueComponent } from './point-catalogue.component';

describe('PointCatalogueComponent', () => {
  let component: PointCatalogueComponent;
  let fixture: ComponentFixture<PointCatalogueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PointCatalogueComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PointCatalogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
