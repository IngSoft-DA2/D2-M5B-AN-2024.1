using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using starwars.Domain;

namespace starwars.DataAccess;

public class SessionManagment : GenericRepository<Session>
{
    public SessionManagment(DbContext context) 
    {
        Context = context;
    }
    
    public override void Insert(Session session)
    {
        Context.Entry(session.User).State = EntityState.Unchanged;
        Context.Set<Session>().Add(session);
    }
}