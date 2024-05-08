namespace UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Logic;
using Logic.Models;
using Drugs;
using Medicines;
using WebAPI.Controllers;


[TestClass]
public class UnitTest1
{
    [TestMethod]

    public void GetMainDrugSucceedTest()
    {
        var Medicine = new Medicine() { Name = "Dolex 500", Drugs = [new Drug() { Milligrams = 500, Name = "paracetamol"}]};
        var medicineService = new MedicineService(new Mock<IDrugsService>().Object);
        string drug = medicineService.GetMainDrug(Medicine);
        Assert.AreEqual("paracetamol", drug);

    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void GetMainDrugWithNoDrugsTest()
    {
        var Medicine = new Medicine() { Name = "Dolex 500", Drugs = []};
        var medicineService = new MedicineService(new Mock<IDrugsService>().Object);
        string drug = medicineService.GetMainDrug(Medicine);
    }

    [TestMethod]
    public void GetAllTest()
    {
        var medicineService = new MedicineService(new Mock<IDrugsService>().Object);
        var medicineController = new MedicineController(medicineService);
        var result = medicineController.GetAll();
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void MainDrugTest()
    {
        var medicineService = new MedicineService(new Mock<IDrugsService>().Object);
        var medicineController = new MedicineController(medicineService);
        var result = medicineController.MainDrug(new Medicine() { Name = "Dolex 500", Drugs = [new Drug() { Milligrams = 500, Name = "paracetamol"}]});
        Assert.IsNotNull(result);
    }

}