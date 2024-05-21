import { Component, OnInit } from '@angular/core';
import { ADD_CHARACTER_URL, CHARACTER_LIST_URL } from '../../utils/routes';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  public characterListUrl = `/${CHARACTER_LIST_URL}`;
  public addCharacterUrl = `/${ADD_CHARACTER_URL}`;

  constructor() { }

  ngOnInit(): void {
  }

}
