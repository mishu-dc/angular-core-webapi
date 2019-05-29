import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchasePlanningComponent } from './purchase-planning.component';

describe('PurchasePlanningComponent', () => {
  let component: PurchasePlanningComponent;
  let fixture: ComponentFixture<PurchasePlanningComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchasePlanningComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasePlanningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
