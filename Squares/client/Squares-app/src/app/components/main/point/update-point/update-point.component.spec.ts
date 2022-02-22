import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePointComponent } from './update-point.component';

describe('UpdatePointComponent', () => {
  let component: UpdatePointComponent;
  let fixture: ComponentFixture<UpdatePointComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdatePointComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatePointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
