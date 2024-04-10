using System;
using starwars.Domain;
using System.Collections.Generic;

namespace starwars.IBusinessLogic
{
	public interface ICharacterService
	{
        IEnumerable<Character> GetCharacters();
        Character GetCharacterById(int id);
        void InsertCharacter(Character? character);
        Character? UpdateCharacter(Character? character);
        void DeleteCharacter(int id);
    }
}

