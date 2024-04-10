using Microsoft.EntityFrameworkCore;
using starwars.Domain;

namespace starwars.DataAccess;
public class UserManagement : GenericRepository<User>
{
    public UserManagement(DbContext context)
    {
        Context = context;
    }
}

