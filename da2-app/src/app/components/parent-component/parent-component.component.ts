import { Component, OnInit } from '@angular/core';
import { Da2ServicesService } from 'src/app/services/da2-services.service';

@Component({
  selector: 'app-parent-component',
  templateUrl: './parent-component.component.html',
  styleUrls: ['./parent-component.component.css']
})
export class ParentComponentComponent implements OnInit {

  items: Array<{ name: string }> = [];
  clickedname: string = "";
  clickedServices: string = "";
  constructor(private da2ServicesService: Da2ServicesService) { }

  ngOnInit(): void {
    this.items = [
      { name: 'Item 1' },
      { name: 'Item 2' },
      { name: 'Item 3' }
    ];
    this.da2ServicesService.servicesCommunication$.subscribe(name => {
      this.clickedServices = name;
    });
  }

  getFromChild(name: string) {
    this.clickedname = name;
  }
}
