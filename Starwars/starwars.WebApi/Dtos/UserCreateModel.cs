using System;
using starwars.Domain;

namespace starwars.WebApi.Dtos;
public class UserCreateModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User ToEntity()
	{
        return new User()
        {
            Name = this.Name,
            Email = this.Email,
            Password = this.Password
        };
	}

}

