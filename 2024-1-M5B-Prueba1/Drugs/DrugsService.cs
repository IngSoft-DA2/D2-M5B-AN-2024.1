//Rodrigo Raimondi-242965
using Logic;
using Logic.Models;

namespace Drugs;

public class DrugsService : IDrugsService
{
    public string MainDrug(Drug[]? drugs)
    {
        if (drugs == null) throw new Exception("Drugs are null");
        else
        {
            Drug mainDrug = drugs[0];
            foreach (var item in drugs)
            {
                if (item.Milligrams > mainDrug.Milligrams) mainDrug = item;
            }
            return mainDrug.Name ?? "";
        }
    }
}