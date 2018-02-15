import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LineRowComponent } from './line-row.component';

describe('LineRowComponent', () => {
  let component: LineRowComponent;
  let fixture: ComponentFixture<LineRowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LineRowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LineRowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
