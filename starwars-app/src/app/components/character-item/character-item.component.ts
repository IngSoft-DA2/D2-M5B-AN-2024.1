import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Character } from '../../models/character';

@Component({
  selector: 'app-character-item',
  templateUrl: './character-item.component.html',
  styleUrls: ['./character-item.component.css']
})
export class CharacterItemComponent implements OnInit {

  @Input() public character: Character | undefined;
  @Output() public delete: EventEmitter<Character> = new EventEmitter<Character>();
  @Output() public characterClicked: EventEmitter<Character> = new EventEmitter<Character>();

  constructor() { }

  public ngOnInit(): void {
  }

  public onDelete(): void {
    this.delete.emit(this.character);
  }

  public onCharacterClicked(): void {
    this.characterClicked.emit(this.character);
  }
}
