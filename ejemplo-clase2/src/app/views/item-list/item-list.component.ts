import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { ObjectDTO } from '../../../models';
import { NgFor, NgIf } from '@angular/common';
import { ItemComponent } from '../../components/item/item.component';

@Component({
  selector: 'app-item-list',
  standalone: true,
  imports: [ItemComponent, NgFor, NgIf],
  templateUrl: './item-list.component.html',
  styleUrl: './item-list.component.scss'
})
export class ItemListComponent {

  title = 'Lista de objetos';
  list: Partial<ObjectDTO[]> = [];
  error?: string = undefined;

  constructor(private service: ApiService) {
    this.service.getObjects().subscribe({
      next: (res) => {
        console.log('response ok', res);
        this.list = res;
      },
      error: (err) => {
        console.log('error', err.message);
        this.error = err.message;
      },
      complete: () => {
        console.log('soy como el finally del try&catch');
      },
    })
  }

}
