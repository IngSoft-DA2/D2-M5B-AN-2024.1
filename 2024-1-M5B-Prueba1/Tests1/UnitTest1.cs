using Medicines;
using Moq;
using Logic.Models;
using Logic;
using Drugs;

namespace Tests;

[TestClass]
public class UnitTest1
{
    private Mock<IDrugsService> _mockDrugService;
    private Drug _drug;
    private Medicine _medicine;
    private List<Drug> _drugs;
    private IMedicineService _medicineService;

    [TestInitialize]
    public void InitTest()
    {
        _mockDrugService = new Mock<IDrugsService>(MockBehavior.Strict);
        _drug = new Drug()
        {
            Milligrams = 3,
            Name = "Perifar"
        };
        _drugs = new List<Drug> { _drug };
        _medicine = new Medicine()
        {
            Name = "a",
            Drugs  = _drugs
        };
    }

    [TestCleanup]
    public void Cleanup()
    {
        _mockDrugService.VerifyAll();
    }

    [TestMethod]
    public void Valid()
    {
        string drug = "perifar";
        //Arrange
        _mockDrugService.Setup(m => m.MainDrug(It.IsAny <Drug[]>())).Returns(drug);
        //Act
        string returnedDrug = _medicineService!.GetMainDrug(_medicine!);

        //Assert
        Assert.AreEqual(drug, returnedDrug);
    }
    
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void NoDrugsExceptionName()
    {
        _medicine.Drugs[0].Name = null;
        string drug = "perifar";
        //Arrange
        _mockDrugService.Setup(m => m.MainDrug(It.IsAny<Drug[]>())).Returns(drug);
        //Act
        string returnedDrug = _medicineService!.GetMainDrug(_medicine!);

        //Assert
        Assert.AreEqual(drug, returnedDrug);
    }

}