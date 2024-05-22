import { Component, OnInit } from '@angular/core';
import { Da2ServicesService } from 'src/app/services/da2-services.service';

@Component({
  selector: 'app-list-component',
  templateUrl: './list-component.component.html',
  styleUrls: ['./list-component.component.css']
})
export class ListComponentComponent implements OnInit {

  items: Array<{ name: string }> = [];
  clicked: string = "";
  clickedService: string = "";
  constructor(private da2ServicesService: Da2ServicesService) { }


  ngOnInit(): void {
    this.items = [
      { name: 'Item 1' },
      { name: 'Item 2' },
      { name: 'Item 3' }
    ];
    this.da2ServicesService.servicesCommunication$.subscribe(name => {
      this.clickedService = name;
    });
  }

  getChildName(name: string) {
    this.clicked = name;
    }
}
