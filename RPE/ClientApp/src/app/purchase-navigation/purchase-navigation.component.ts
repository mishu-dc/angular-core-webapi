import { Component } from '@angular/core';

@Component({
  selector: 'purchase-navigation',
  templateUrl: './purchase-navigation.component.html',
  styleUrls: ['./purchase-navigation.component.css']
})
export class PurchaseNavigationComponent {

  selectedMenu: string;

  constructor() {
    this.selectedMenu = "planning";
  }

  onCLick(selectedMenu: string) {
    this.selectedMenu = selectedMenu;
  }
}
