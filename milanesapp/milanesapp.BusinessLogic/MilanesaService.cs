using System.Collections.Generic;
using System.Linq.Expressions;
using milanesapp.Domain;
using milanesapp.IBusinessLogic;

namespace milanesaapp.BusinessLogic
{
    public class MilanesaService : IMilanesaService
    {
        //private readonly IGenericRepository<Milanesa> _repository;

        public MilanesaService(/*IGenericRepository<Milanesa> repository*/)
        {
            //  _repository = repository;
        }

        public void DeleteMilanesa(int id)
        {
            // Milanesa milanesa = GetMilanesaById(id);
            // _repository.Delete(milanesa);
            // _repository.Save();
        }

        public Milanesa GetMilanesaById(int id)
        {
            // Expression<Func<Milanesa, bool>> searchCondition = (x => x.Id == id);
            // Milanesa milanesa = _repository.Get(searchCondition);
            // return milanesa;
            return new Milanesa();
        }

        public IEnumerable<Milanesa> GetMilanesas()
        {
            // Crear una lista de milanesas de ejemplo
            var milanesas = new List<Milanesa>
    {
        new Milanesa
        {
            Id = 1,
            Name = "Milanesa Napolitana",
            Description = "Milanesa de ternera cubierta con salsa de tomate, jamón, queso mozzarella y orégano.",
            ImageUrl = "https://example.com/imagen-milanesa-napolitana.jpg"
        },
        new Milanesa
        {
            Id = 2,
            Name = "Milanesa a la Caballo",
            Description = "Milanesa de ternera acompañada de dos huevos fritos por encima.",
            ImageUrl = "https://example.com/imagen-milanesa-caballo.jpg"
        },
        new Milanesa
        {
            Id = 3,
            Name = "Milanesa de Pollo",
            Description = "Milanesa preparada con pechuga de pollo, empanada y frita.",
            ImageUrl = "https://example.com/imagen-milanesa-pollo.jpg"
        }
    };
            return milanesas;
            //return _repository.GetAll<Milanesa>();
        }

        public void InsertMilanesa(Milanesa? milanesa)
        {
            // if (IsMilanesaValid(milanesa))
            // {                
            //   _repository.Insert(milanesa!);
            //   _repository.Save();
            // }
        }

        public Milanesa? UpdateMilanesa(Milanesa? milanesa)
        {
            // if (IsMilanesaValid(milanesa))
            // {
            //     _repository.Update(milanesa!);
            //     return GetMilanesaById(milanesa!.Id);
            // }
            // return null;
            throw new NotImplementedException();
        }

        private bool IsMilanesaValid(Milanesa? milanesa)
        {
            if (milanesa == null)
            {
                // throw new NotNull("Milanesa no puede estar vacia");
            }
            if (milanesa.Name == string.Empty)
            {
                // throw new InvalidResourceException("El nombre de la milanesa es requerida");
            }
            return true;
        }
    }
}

