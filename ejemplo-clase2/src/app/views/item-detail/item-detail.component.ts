import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { ObjectDTO } from '../../../models';
import { ActivatedRoute, Router } from '@angular/router';
import { UpperCasePipe } from '@angular/common';
import { PrettyDataPipe } from '../../pipes/pretty-data.pipe';

@Component({
  selector: 'app-item-detail',
  standalone: true,
  imports: [UpperCasePipe, PrettyDataPipe],
  templateUrl: './item-detail.component.html',
  styleUrl: './item-detail.component.scss'
})
export class ItemDetailComponent {

  item?: ObjectDTO = undefined;

  constructor(private service: ApiService, private route: ActivatedRoute, private router: Router) {
    // dos formas de obtener el id
    console.log(this.route.snapshot.params['id']);
    console.log(this.route.snapshot.paramMap.get('id'));

    this.service.getObjectById(this.route.snapshot.params['id']).subscribe({
      next: (res) => {
        this.item = res;
      }
    });
  }

  getData() {
    return JSON.stringify(this.item?.data);
  }

  goBack() {
    this.router.navigate(['']);
  }

}
