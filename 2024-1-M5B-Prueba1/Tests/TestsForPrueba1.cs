using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAPI.Controllers;
using Medicines;
using Drugs;

namespace Tests;

[TestClass]
public class TestsForPrueba1
{
    private MedicineController _controller;
    private MedicineService _medicineService;
    private Mock<IDrugsService> _mockDrugsService;
    private Medicine medicineOK;
    private Medicine medicineNoDrugs;
    private Medicine medicineOneDrug;

    [TestInitialize]
    public void TestInitialize()
    {
        _controller = new MedicineController(_medicineService);
        _mockDrugsService = new Mock<IDrugsService>();
        _medicineService = new MedicineService(_mockDrugsService.Object);
        medicineOK = new Medicine()
        {
            Name = "Dolex 500",
            Drugs = new Drug[] { new Drug() { Milligrams = 500, Name = "paracetamol" } }
        };
        medicineNoDrugs = new Medicine() { Name = "Dolex 500", Drugs = new Drug[] { } };
        medicineOneDrug = new Medicine() { Name = "Dolex 500", Drugs = new Drug[] { new Drug() { Milligrams = 500, Name = "paracetamol" } } };
    }
    
    [TestMethod]
    public void GetMainDrug_NoDrugsTest()
    {
        // Arrange
        var medicine = medicineNoDrugs;

        // Act
        var result = _medicineService.GetMainDrug(medicine);

        // Assert
        Assert.AreEqual("No drugs", result);
    }

    [TestMethod]
    public void GetMainDrug_OneDrugTest()
    {
        // Arrange
        var medicine = medicineOneDrug;

        // Act
        var result = _medicineService.GetMainDrug(medicine);

        // Assert
        Assert.AreEqual("paracetamol", result);
    }

    [TestMethod]
    public void GetMainDrug_MoreThanOneDrugTest()
    {
        // Arrange
        var medicine = medicineOK;
        _mockDrugsService.Setup(x => x.MainDrug(It.IsAny<Medicine[]>())).Returns("paracetamol");

        // Act
        var result = _medicineService.GetMainDrug(medicine);

        // Assert
        Assert.AreEqual("paracetamol", result);
    }

    [TestMethod]
    public void GetAll_ReturnsOkTest()
    {
        // Arrange
        var medicines = new Medicine[] { medicineOK, medicineOneDrug, medicineNoDrugs };
        _medicineService.Setup(x => x.GetAll()).Returns(medicines);

        // Act
        var result = _controller.GetAll();

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetAll_ReturnsBadRequestTest()
    {
        // Arrange
        _medicineService.Setup(x => x.GetAll()).Throws(new Exception("Error"));

        // Act
        var result = _controller.GetAll();

        // Assert
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

    [TestMethod]
    public void MainDrug_ReturnsOkTest()
    {
        // Arrange
        _medicineService.Setup(x => x.GetMainDrug(It.IsAny<Medicine[]>())).Returns("paracetamol");

        // Act
        var result = _controller.MainDrug(medicineOK);

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void MainDrug_ReturnsBadRequestTest()
    {
        // Arrange
        _medicineService.Setup(x => x.GetMainDrug(It.IsAny<Medicine[]>())).Throws(new Exception("Error"));

        // Act
        var result = _controller.MainDrug(medicineOK);

        // Assert
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

}