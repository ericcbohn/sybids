import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineMonthComponent } from './line-month.component';

describe('LineMonthComponent', () => {
  let component: LineMonthComponent;
  let fixture: ComponentFixture<LineMonthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineMonthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineMonthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
