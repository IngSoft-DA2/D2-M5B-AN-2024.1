using System;
using milanesapp.Domain;
using System.Collections.Generic;

namespace milanesapp.IBusinessLogic
{
	public interface IMilanesaService
	{
        IEnumerable<Milanesa> GetMilanesas();
        Milanesa GetMilanesaById(int id);
        void InsertMilanesa(Milanesa? milanesa);
        Milanesa? UpdateMilanesa(Milanesa? milanesa);
        void DeleteMilanesa(int id);
    }
}

