using Logic.Models;
using System;


namespace Logic;

public interface IDrugsService
{
    string MainDrug(Drug[]? drugs);
}