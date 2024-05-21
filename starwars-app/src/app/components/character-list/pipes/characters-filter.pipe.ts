import { Pipe, PipeTransform } from '@angular/core';  // 1) imports
import { Character } from '../../../models/character';

// 2) Nos creamos nuestra propia clase CharactersFilterPipe y la decoramos con el decorator @Pipe
@Pipe({
  name: 'charactersFilter'
})
export class CharactersFilterPipe implements PipeTransform { // 3) Implementamos la interfaz PipeTransform

  // 4) Implementamos el método transform de la interfaz PipeTransform
  transform(characters: Character[] | undefined, filterValue: string): Character[] {
    // 5) Escribimos el código para filtrar los personajes
    // El primer parámetro (characters) es la lista de personajes que vamos a transformar
    // El segundo parámetro (filterValue) es el criterio que vamos a utilizar para transformar
    // en este caso vamos a estar filtrando los personajes por ese filterValue
    // El retorno es la lista de personajes filtradas por filterValue
    if(!characters) {
      return [];
    }
    return characters.filter((character) => character.name.toLowerCase().includes(filterValue.toLowerCase()));
  }
}
