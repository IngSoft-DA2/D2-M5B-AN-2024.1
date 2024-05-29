import { Component, Input } from '@angular/core';
import { ObjectDTO } from '../../../models';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [NgIf],
  templateUrl: './item.component.html',
  styleUrl: './item.component.scss'
})
export class ItemComponent {
  @Input() item?: ObjectDTO = undefined;

  constructor(private router: Router) { }

  goToDetail() {
    this.router.navigate(['item', this.item?.id])
  }
}
