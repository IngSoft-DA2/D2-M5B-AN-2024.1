namespace UnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Logic;
using Logic.Models;
using Drugs;
using Medicines;


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
    [ExpectedException(typeof(Exception))]
    public void GetMainDrugWithMultipleDrugsTest()
    {
    
    }

}