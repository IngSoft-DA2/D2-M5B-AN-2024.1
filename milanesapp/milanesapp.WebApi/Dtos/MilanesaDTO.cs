using System;
using milanesapp.Domain;

namespace milanesapp.WebApi.Dtos
{
	public class MilanesaDTO
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public MilanesaDTO(Milanesa milanesa)
		{
			Name = milanesa.Name;
            Description = milanesa.Description;
            ImageUrl = milanesa.ImageUrl;
        }
	}
}

