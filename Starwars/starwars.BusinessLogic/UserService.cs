using System.Collections.Generic;
using System.Linq.Expressions;
using starwars.Domain;
using starwars.Exceptions.BusinessLogicExceptions;
using starwars.IBusinessLogic;
using starwars.IDataAccess;

namespace starwars.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;

        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public void InsertUser(User user)
        {
            user.Role = "simple-user";
            _repository.Insert(user);
            _repository.Save();
        }
    }
}

