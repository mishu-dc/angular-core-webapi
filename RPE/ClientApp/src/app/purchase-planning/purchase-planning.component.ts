import { Component, ViewChild, Inject, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FilterArg } from '../../data/FilterArg';

import { DataGridPagination } from '../../data/DataGridPagination';
import { DataGridComponent } from '../data-grid/data-grid.component';
import { PurchasePlanningResponse } from '../../data/PurchasePlanningResponse';


@Component({
  selector: 'purchase-planning',
  templateUrl: './purchase-planning.component.html',
  styleUrls: ['./purchase-planning.component.css']
})
export class PurchasePlanningComponent {

  @ViewChild(DataGridComponent) dataGrid: DataGridComponent;
  @Input('FilterArg') FilterArg: FilterArg;

  pageChangeArg: DataGridPagination;
  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    
  }

  getPlanning() {
    console.log("currentPage:", this.dataGrid.currentPage);
    console.log("selectedPageSize:", this.dataGrid.selectedPageSize);
 
    console.log("filter args:", this.FilterArg);

    this.http.get<PurchasePlanningResponse>(this.baseUrl + 'api/PurchasePlanning' + this.getQueryString()).subscribe(result => {
      this.dataGrid.totalRecords = result.totalCount;
      this.dataGrid.records = result.plannings;
      console.log(result);
      this.dataGrid.reInitialize();
    }, error => console.error(error));
  }

  getQueryString() {
    let query = "?";

    this.FilterArg && this.FilterArg.fiscalYear ? query += "fiscalyear=" + this.FilterArg.fiscalYear : "";
    this.FilterArg && this.FilterArg.divisionId ? query += "&divisionId=" + this.FilterArg.divisionId : "";
    this.FilterArg && this.FilterArg.canId ? query += "&canId=" + this.FilterArg.canId : "";
    this.dataGrid.selectedPageSize ? query += "&pageSize=" + this.dataGrid.selectedPageSize : "";
    this.dataGrid.currentPage ? query += "&pageNo=" + this.dataGrid.currentPage : "";
    this.dataGrid.sortBy ? query += "&sortBy=" + this.dataGrid.sortBy : "";

    return query;
  }

  pageChanged(eventArgs: DataGridPagination) {
    console.log("pageChanged->");
    this.pageChangeArg = eventArgs;
    this.getPlanning();
  }

  filterChanged(eventArg: FilterArg) {
    console.log("filterChanged->");
    this.FilterArg = eventArg;
    this.getPlanning();
  }

}
