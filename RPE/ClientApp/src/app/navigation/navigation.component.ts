import { Component } from '@angular/core';

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {

  selectedMenu: string;

  constructor() {
    this.selectedMenu = "purchase";
  }

  onCLick(selectedMenu: string) {
    this.selectedMenu = selectedMenu;
  }
}
