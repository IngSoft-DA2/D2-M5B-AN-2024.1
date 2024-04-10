using starwars.Domain;

namespace starwars.IBusinessLogic;

public interface ISessionService
{
    User? GetCurrentUser(Guid? authToken = null);
    Guid Authenticate(string email, string password);
}