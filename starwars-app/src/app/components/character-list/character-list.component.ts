import { Component, OnInit } from '@angular/core';
import { CharactersService } from '../../services/characters.service';
import { Character } from '../../models/character';
import { Router } from '@angular/router';
import { catchError, filter, of, take } from 'rxjs';
import { IDeleteResponse } from 'src/app/interfaces/delete-response.interface';
import { ADD_CHARACTER_URL, getCharacterFormUrl } from '../../utils/routes';

@Component({
  selector: 'app-character-list',
  templateUrl: './character-list.component.html',
  styleUrls: ['./character-list.component.css']
})
export class CharacterListComponent implements OnInit {

  public filterValue: string = '';
  public characters: Character[] = [];

  constructor(
    private _charactersService: CharactersService,
    private _router: Router,
  ) { }

  public ngOnInit(): void {
    // cuando inicia el componente llamo al servicio para obtener los personajes
    this._charactersService.getCharacters().pipe(
      take(1),
      catchError((err) => {
        console.log({err});
        return of(err);
      }),
    )
    .subscribe((characters: Character[]) => {
      this.setCharacters(characters);
    });
  }

  public navigateToAddCharacter(): void {
    this._router.navigateByUrl(`/${ADD_CHARACTER_URL}`);
  }

  public navigateToEditCharacter(character: Character): void {
    this._router.navigateByUrl(`/${getCharacterFormUrl(character.id)}`);
  }

  public deleteCharacter(characterToDelete: Character): void {
    // voy a borrar la personaje
    this._charactersService.deleteCharacter(characterToDelete?.id).pipe(
      take(1),
      catchError((err) => {
        console.log({err});
        return of(err);
      }),
      //filter((response: IDeleteResponse) => response.success === true),
    ).subscribe((response: IDeleteResponse) => {
      this._charactersService.getCharacters()
      .pipe(
        take(1),
        catchError((err) => {
          console.log({err});
          return of(err);
        }),
      ).subscribe((characters: Character[] | undefined) => {
        this.setCharacters(characters);
      });
    });
  }

  private setCharacters = (characters: Character[] | undefined) => {
    if(!characters) this.characters = [];
    else this.characters = characters;
  };
}
