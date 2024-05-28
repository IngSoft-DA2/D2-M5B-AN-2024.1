import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Da2ServicesService {
  private servicesCommunication = new Subject<string>();
  constructor() { }
  servicesCommunication$ = this.servicesCommunication.asObservable();

  setservicesCommunication(name: string) {
    this.servicesCommunication.next(name+ "services");
  }
}
