import { Component, ViewChild, Inject, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FilterArg } from '../../data/FilterArg';

import { DataGridPagination } from '../../data/DataGridPagination';
import { DataGridComponent } from '../data-grid/data-grid.component';
import { PurchasePlanningResponse } from '../../data/PurchasePlanningResponse';
import { PurchasePlanning } from '../../data/purchasePlanning';
import { saveAs } from 'file-saver';



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
  imageBaseUrl: string = "../../assets/images/";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;    
  }

  download(url: string) {
    return this.http.post<Response>(url, { responseType: 'blob' });
  }

  downloadExcel() {
    let url: string = this.baseUrl + 'api/PurchasePlanning/export' + this.getQueryString();
    window.location.href = url;
  }

  getPlanning() {

    this.http.get<PurchasePlanningResponse>(this.baseUrl + 'api/PurchasePlanning' + this.getQueryString()).subscribe(result => {

      result.plannings.forEach(planning => {
        planning.canDescription = planning.can.name;
        planning.tagImgUrl = planning.isTag ? this.imageBaseUrl + "tag.png" : this.imageBaseUrl + "no-tag.png";

        switch (planning.priority) {
          case 4:
            planning.priorityImgUrl = this.imageBaseUrl + "priority_flag-high.png";
            break;
          case 3:
            planning.priorityImgUrl = this.imageBaseUrl + "priority_flag-med.png";
            break;
          case 2:
            planning.priorityImgUrl = this.imageBaseUrl + "priority_flag-low.png";
            break;
          case 1:
            planning.priorityImgUrl = this.imageBaseUrl + "priority_flag-none.png";
            break;
        }
      });

      let summary = new PurchasePlanning();
      summary.description = "Total (all pages)";
      summary.planedAmount = result.totalAmount;
      result.plannings.push(summary);

      this.dataGrid.totalRecords = result.totalCount;
      this.dataGrid.records = result.plannings;

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
    this.dataGrid.sortDir ? query += "&sortDir=" + this.dataGrid.sortDir : "";

    return query;
  }

  pageChanged(eventArgs: DataGridPagination) {
    this.pageChangeArg = eventArgs;
    this.getPlanning();
  }

  filterChanged(eventArg: FilterArg) {
    this.FilterArg = eventArg;
    this.dataGrid.currentPage = 1;
    this.getPlanning();
  }

  exportClicked(eventArg: DataGridPagination) {
    this.pageChangeArg = eventArg;
    this.downloadExcel();
  }

}
