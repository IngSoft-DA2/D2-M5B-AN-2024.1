using System;
using milanesapp.Domain;

namespace milanesapp.WebApi.Dtos;
public class MilanesappCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }

    public Milanesa ToEntity()
	{
        return new Milanesa()
        {
            Name = this.Name,
            Description = this.Description,
            ImageUrl = this.ImageUrl
        };
	}
}

