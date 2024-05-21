import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, of, take } from 'rxjs';
import { Character } from '../../models/character';
import { ICreateCharacter } from '../../interfaces/create-character.interface';
import { CharactersService } from '../../services/characters.service';
import { ValidateString } from '../../validators/string.validator';
import { CHARACTER_LIST_URL } from '../../utils/routes';

@Component({
  selector: 'app-character-form',
  templateUrl: './character-form.component.html',
  styleUrls: ['./character-form.component.css']
})
export class CharacterFormComponent implements OnInit {

  public characterForm = new FormGroup({
    name: new FormControl('', [Validators.required, ValidateString])!,
    description: new FormControl('', [Validators.required, ValidateString]),
    imageurl: new FormControl('')
  });

  public isEditing = false;
  private characterId?: number;

  constructor(
    private _charactersService: CharactersService,
    private _router: Router,
    private _route: ActivatedRoute,
  ) { }

  public get name() { return this.characterForm.get('name'); }

  public get description() { return this.characterForm.get('description'); }

  public get imageurl() { return this.characterForm.get('imageurl'); }

  public ngOnInit(): void {
    const id = this._route.snapshot.params?.['id'];
    console.log({id});
    if(!!id && id !== 'new') {
      this.isEditing = true;
      this.characterId = id;
      this._charactersService.getCharacterById(id).pipe(
        take(1),
        catchError((err) => {
          console.log({err});
          return of(err);
        }),
      ).subscribe((character: Character) => {
        this.setCharacter(character);
      });
    }
    
  }

  public submitCharacter(): void {
    if(this.characterForm.valid) {
      if(this.isEditing) {
        this.updateCharacter();
      } else {
        this.createCharacter();
      }
    }
  }

  private createCharacter(): void {
    const character: ICreateCharacter = {
      name: this.characterForm.value.name!, // Si sabemos que nunca va a ser null o undefined usamos el simbolo '!'.
      description: this.characterForm.value.description!,
      imageurl: this.characterForm.value.imageurl ?? "", // utilizamos ?? "" para tener un valor por defecto en caso que sea null o undefined.
    };
    this._charactersService.postCharacter(character)
    .pipe(
      take(1),
      catchError((err) => {
        console.log({err});
        return of(err);
      }),
    )
    .subscribe((character: Character) => {
      if(!!character?.id) {
        alert('Personaje creado!!');
        this.cleanForm();
        this._router.navigateByUrl(`/${CHARACTER_LIST_URL}`);
      }
    });
  }

  private updateCharacter(): void {
    if(!!this.characterId) {
      const character = new Character(
        this.characterId as number,
        this.characterForm.value.name ?? "",
        this.characterForm.value.description ?? "",
        this.characterForm.value.imageurl ?? "",
      );
      this._charactersService.putCharacter(character)
      .pipe(
        take(1),
        catchError((err) => {
          console.log({err});
          return of(err);
        }),
      )
      .subscribe((character: Character) => {
        if(!!character?.id) {
          alert('Personaje modificada!!');
          this._router.navigateByUrl(`/${CHARACTER_LIST_URL}`);
        }
      });
    }
  }

  private setCharacter(character: Character): void {
    this.name?.setValue(character.name);
    this.description?.setValue(character.description);
    this.imageurl?.setValue(character.imageurl);
  }

  private cleanForm(): void {
    this.name?.setValue('');
    this.description?.setValue('');
    this.imageurl?.setValue('');
  }
}
