using starwars.Domain;

namespace starwars.IDataAccess;
public interface ICharacterManagment
{
    IEnumerable<Character> GetCharacters();
    Character GetCharacterById(int id);
    void InsertCharacter(Character? character);
    Character? UpdateCharacter(Character? character);
    void DeleteCharacter(int id);
}

