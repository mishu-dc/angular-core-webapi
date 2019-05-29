import { Component, ViewChild, OnInit } from '@angular/core';
import { FilterArg } from '../data/FilterArg';
import { PurchasePlanningComponent } from './purchase-planning/purchase-planning.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'app';

  @ViewChild(PurchasePlanningComponent) purchasePlanning: PurchasePlanningComponent;

  ngOnInit() {
    this.purchasePlanning.FilterArg = null;
  }

  filterChanged(eventArg: FilterArg) {
    this.purchasePlanning.filterChanged(eventArg);
  }
}
