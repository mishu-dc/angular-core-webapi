import { Component, Inject, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Entity } from '../../data/Entity';
import { FilterArg } from '../../data/FilterArg';

@Component({
  selector: 'filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent {

  @Output('filter-changed') filterChanged = new EventEmitter();

  public fiscalYears: number[];
  public divisions: Entity[];
  public cans: Entity[];

  public selectedYear: number;
  public selectedDivision: number;
  public selectedCan: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

      http.get<number[]>(baseUrl + 'api/FiscalYear').subscribe(result => {
        this.fiscalYears = result;

        if (this.fiscalYears && this.fiscalYears.length > 0) {
          this.selectedYear = this.fiscalYears[0];
          this.loadingComplete();
        }
        
      }, error => console.error(error));

      http.get<Entity[]>(baseUrl + 'api/Division').subscribe(result => {
        this.divisions = result;

        if (this.divisions && this.divisions.length > 0) {
          this.selectedDivision = this.divisions[0].id;
          this.loadingComplete();
        }

      }, error => console.error(error));

      http.get<Entity[]>(baseUrl + 'api/Can').subscribe(result => {
        this.cans = result;

        if (this.cans && this.cans.length > 0) {
          this.selectedCan = this.cans[0].id;
          this.loadingComplete();
        }

      }, error => console.error(error));
  }

  loadingComplete() {
    if (this.selectedYear && this.selectedDivision && this.selectedCan)
        this.filterChanged.emit(this.getEventArg());
  }

  divisionChanged(division:number) {
    if (this.selectedDivision != division) {
      this.selectedDivision = division;
      this.filterChanged.emit(this.getEventArg());
    }
  }

  fiscalYearChanged(year: number) {
    if (this.selectedYear != year) {
      this.selectedYear = year;
      this.filterChanged.emit(this.getEventArg());
    }
  }

  canChanged(can: number) {
    if (this.selectedCan != can) {
      this.selectedCan = can;
      this.filterChanged.emit(this.getEventArg());
    }
  }

  private getEventArg() {
    return new FilterArg(this.selectedYear, this.selectedDivision, this.selectedCan);   
  }
}
