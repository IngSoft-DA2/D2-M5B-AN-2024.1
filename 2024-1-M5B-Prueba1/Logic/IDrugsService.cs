//Rodrigo Raimondi-242965
using Logic.Models;

namespace Logic;

public interface IDrugsService
{
    string MainDrug(Drug[]? drugs);
}