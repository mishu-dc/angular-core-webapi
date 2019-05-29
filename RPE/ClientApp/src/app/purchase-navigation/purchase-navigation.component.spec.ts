import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseNavigationComponent } from './purchase-navigation.component';

describe('PurchaseNavigationComponent', () => {
  let component: PurchaseNavigationComponent;
  let fixture: ComponentFixture<PurchaseNavigationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PurchaseNavigationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
