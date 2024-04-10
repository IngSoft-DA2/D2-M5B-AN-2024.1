using System;
using starwars.Domain;

namespace starwars.WebApi.Dtos;
public class CharacterCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public Character ToEntity()
	{
        return new Character()
        {
            Name = this.Name,
            Description = this.Description,
            ImageUrl = this.ImageUrl
        };
	}
}

