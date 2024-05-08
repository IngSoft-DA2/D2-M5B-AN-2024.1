//Rodrigo Raimondi-242965
using Logic;
using Logic.Models;

namespace Medicines;

public class MedicineService : IMedicineService
{
    private readonly IDrugsService drugService;
    public MedicineService(IDrugsService drugService)
    {
        this.drugService = drugService;
    }
    public IEnumerable<Medicine> GetAll()
    {
        return
        [
            new Medicine() { Name = "Dolex 500", Drugs = [new Drug() { Milligrams = 500, Name = "paracetamol"}]},
            new Medicine() { Name = "Perifar 200", Drugs = [new Drug() { Milligrams = 200, Name = "ibuprofeno"}]},
            new Medicine() { Name = "Biogrip", Drugs = [
                new Drug() { Milligrams = 100, Name = "paracetamol"},
                new Drug() { Milligrams = 200, Name = "loratadina"},
                new Drug() { Milligrams = 100, Name = "cafeina"}
            ]},
        ];
    }

    public string GetMainDrug(Medicine medicine)
    {
        if (medicine.Drugs?.Length == 0)
            throw new Exception("There are no drugs");
        if (medicine.Drugs?.Length == 1)
            return medicine.Drugs?[0].Name ?? throw new Exception("There are no drugs");

        string mainDrug = this.drugService.MainDrug(medicine.Drugs);
        return mainDrug;
    }
}