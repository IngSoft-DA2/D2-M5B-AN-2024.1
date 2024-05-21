import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUserService, Session } from '../interfaces/user-service';
import { UsersEndpoints } from './endpoints';

@Injectable({
  providedIn: 'root',
})
export class UsersService implements IUserService {
  constructor(private _httpService: HttpClient) {}

  public login(): Observable<Session> {
    return this._httpService.post<Session>(`${UsersEndpoints.LOGIN}`, {
      email: 'marcofiorito1@gmail.com',
      password: '1234',
    });
  }
}