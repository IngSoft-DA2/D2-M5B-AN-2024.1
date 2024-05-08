using Logic.Models;
using System.Collections.Generic;

namespace Logic;

public interface IMedicineService
{
    IEnumerable<Medicine> GetAll();
    string GetMainDrug(Medicine medicine);
}