import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LinePairingComponent } from './line-pairing.component';

describe('LinePairingComponent', () => {
  let component: LinePairingComponent;
  let fixture: ComponentFixture<LinePairingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinePairingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinePairingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
