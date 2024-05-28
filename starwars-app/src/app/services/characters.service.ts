import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { Character } from '../models/character';
import { ICreateCharacter } from '../interfaces/create-character.interface';
import { IDeleteResponse } from '../interfaces/delete-response.interface';

@Injectable({
  providedIn: 'root'
})
export class CharactersService {

  private _charactersBehaviorSubject$: BehaviorSubject<Character[] | undefined>;

  constructor(
    private _http: HttpClient,
  ) {
    this._charactersBehaviorSubject$ = new BehaviorSubject<Character[] | undefined>(undefined);
  }

  public get characters$(): Observable<Character[] | undefined> {
    return this._charactersBehaviorSubject$.asObservable();
  }

  public getCharacters(): Observable<Character[]> {
    const headers = new HttpHeaders();
    headers.append('token', 'ewrwetrwe');
    return this._http.get<Character[]>(`characters`, {headers}).pipe(
      tap((characters: Character[]) => this._charactersBehaviorSubject$.next(characters)),
    );
  }

  public getCharacterById(characterId: number): Observable<Character> {
    return this._http.get<Character>(`characters/${characterId}`);
  }

  public postCharacter(characterToAdd: ICreateCharacter): Observable<Character> {
    return this._http.post<Character>(`characters`, characterToAdd);
  }

  public putCharacter(characterToUpdate: Character): Observable<Character> {
    return this._http.put<Character>(`characters/${characterToUpdate.id}`, characterToUpdate);
  }

  public deleteCharacter(characterId: number): Observable<IDeleteResponse> {
    return this._http.delete<IDeleteResponse>(`characters/${characterId}`);
  }
}
