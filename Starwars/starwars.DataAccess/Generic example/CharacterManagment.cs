using Microsoft.EntityFrameworkCore;
using starwars.Domain;

namespace starwars.DataAccess;
public class CharacterManagment : GenericRepository<Character>
{
    public CharacterManagment(DbContext context)
    {
        Context = context;
    }
}

