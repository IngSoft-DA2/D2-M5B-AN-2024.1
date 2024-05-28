import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Da2ServicesService } from 'src/app/services/da2-services.service';

@Component({
  selector: 'app-item-component',
  templateUrl: './item-component.component.html',
  styleUrls: ['./item-component.component.css']
})
export class ItemComponentComponent implements OnInit {
  @Input() name!: string;
  @Output() childname = new EventEmitter<string>();
  constructor(private da2ServicesService: Da2ServicesService) {
   }

  ngOnInit(): void {
  }

  sendToParent(name: string)
  {
    this.childname.emit(name);
    this.da2ServicesService.setservicesCommunication(name);
  }

}
