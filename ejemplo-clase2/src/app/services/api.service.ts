import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ObjectDTO } from '../../models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  loading: boolean = false;

  constructor(private client: HttpClient) { }

  getObjects(): Observable<ObjectDTO[]> {
    return this.client.get<ObjectDTO[]>('https://api.restful-api.dev/objects');
  }

  getObjectById(id: number): Observable<ObjectDTO> {
    return this.client.get<ObjectDTO>(`https://api.restful-api.dev/objects/${id}`);
  }

  showLoading() {
    this.loading = true;
  }

  hideLoading() {
    this.loading = false;
  }

  isLoading() {
    return this.loading;
  }
}
