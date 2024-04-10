using System;
using starwars.Domain;
using System.Collections.Generic;

namespace starwars.IBusinessLogic
{
	public interface IUserService
	{
        void InsertUser(User user);
    }
}

