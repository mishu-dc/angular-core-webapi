import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { DataGridPagination } from '../../data/DataGridPagination';

@Component({
  selector: 'data-grid',
  templateUrl: './data-grid.component.html',
  styleUrls: ['./data-grid.component.css']
})
export class DataGridComponent implements OnInit {

  @Input('height') height: number;
  @Input('headers') headers: string[];
  @Input('columns') columns: string[];
  @Input('column-widths') columnWidths: string[];
  @Input('column-alignments') columnAlignments: string[];
  @Input('column-types') columnTypes: string[];
  @Input('sortable') sortable: boolean[];
  @Input('total-records') totalRecords: number;
  @Input('pages') pages: number[];
  @Input('current-page') currentPage: number;
  @Input('sort-by') sortBy: string;
  @Input('sort-direction') sortDir: string;
  @Input('selected-page-size') selectedPageSize: number;
  @Input('records') records: any[] = [];
  @Input('can-export') canExport: boolean;
  @Output('page-changed') pageChanged = new EventEmitter();
  @Output('export-clicked') export = new EventEmitter();

  footerColSpan: number;

  pageCount: number;
  from: number;
  to: number;

  constructor() { }

  ngOnInit() {
    this.height = this.height ? this.height : 800;
    this.totalRecords = this.totalRecords ? this.totalRecords : 0;
    this.columns = this.columns ? this.columns : [];
    this.pages = this.pages ? this.pages : [10, 20, 30, 40, 50];
    this.selectedPageSize = this.selectedPageSize ? this.selectedPageSize : this.pages[0];
    this.currentPage = this.currentPage ? this.currentPage : 1;
    this.sortBy = this.sortBy ? this.sortBy : "";
    this.footerColSpan = this.headers.length;
    this.pageCount = Math.ceil(this.totalRecords / this.selectedPageSize);
  }

  reInitialize() {
    this.pageCount = Math.ceil(this.totalRecords / this.selectedPageSize);
    this.from = (this.currentPage - 1) * this.selectedPageSize + 1;
    this.to = (this.from * 1) + (this.selectedPageSize * 1) - 1;
    this.to = this.to > this.totalRecords ? this.totalRecords : this.to;
  }

  private getEventArg() {
    return new DataGridPagination(this.currentPage, this.selectedPageSize, this.sortBy, this.sortDir);
  }

  moveFirst() {
    if (this.currentPage != 1) {
      this.currentPage = 1;
      this.pageChanged.emit(this.getEventArg());
    }
  }

  previous() {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.pageChanged.emit(this.getEventArg());
    }
  }

  next() {
    if (this.currentPage < this.pageCount) {
      this.currentPage++;
      this.pageChanged.emit(this.getEventArg());
    }
  }

  moveTo(event: number) {
    if (event >= 1 && event <= this.pageCount) {
      this.currentPage = event;
      this.pageChanged.emit(this.getEventArg());
    }
  }

  moveLast() {
    if (this.currentPage != this.pageCount && this.pageCount > 0) {
      this.currentPage = this.pageCount;
      this.pageChanged.emit(this.getEventArg());
    }
  }

  pageSizeChanged(selectedPageSize: number) {
    if (selectedPageSize != this.selectedPageSize) {
      this.selectedPageSize = selectedPageSize;
      this.currentPage = 1;
      this.pageChanged.emit(this.getEventArg());
    }
  }

  onHeaderClick(header) {
    if (this.sortBy === header) {
      this.sortDir = this.sortDir == "desc"? "asc":"desc";
    } else {
      this.sortBy = header
      this.sortDir = "asc";
    }
    this.pageChanged.emit(this.getEventArg());
  }

  refreshList() {
    this.pageChanged.emit(this.getEventArg());
  }

  exportList() {
    if (this.canExport) {
       this.export.emit(this.getEventArg());
    }    
  }

}
