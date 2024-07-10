﻿using Logic.Models;

namespace Logic;

public interface IMedicineService
{
    IEnumerable<Medicine> GetAll();
    string GetMainDrug(Medicine medicine);
}