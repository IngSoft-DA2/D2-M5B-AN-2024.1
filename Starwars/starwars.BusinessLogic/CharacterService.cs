using System.Collections.Generic;
using System.Linq.Expressions;
using starwars.Domain;
using starwars.Exceptions.BusinessLogicExceptions;
using starwars.IBusinessLogic;
using starwars.IDataAccess;

namespace starwars.BusinessLogic
{
    public class CharacterService : ICharacterService
    {
        private readonly IGenericRepository<Character> _repository;

        public CharacterService(IGenericRepository<Character> repository)
        {
            _repository = repository;
        }

        public void DeleteCharacter(int id)
        {
            Character character = GetCharacterById(id);
            _repository.Delete(character);
            _repository.Save();
        }

        public Character GetCharacterById(int id)
        {
            Expression<Func<Character, bool>> searchCondition = (x => x.Id == id);
            Character user = _repository.Get(searchCondition);
            return user;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return _repository.GetAll<Character>();
        }

        public void InsertCharacter(Character? character)
        {
            if (IsCharacterValid(character))
            {                
              _repository.Insert(character!);
              _repository.Save();
            }
        }

        public Character? UpdateCharacter(Character? character)
        {
            if (IsCharacterValid(character))
            {
                _repository.Update(character!);
                return GetCharacterById(character!.Id);
            }
            return null;

        }

        private bool IsCharacterValid(Character? character)
        {
            if (character == null)
            {
                throw new NotNull("Personaje no puede estar vacio");
            }
            if (character.Name == string.Empty)
            {
                throw new InvalidResourceException("El nombre del personaje es requerido");
            }
            return true;
        }
    }
}

