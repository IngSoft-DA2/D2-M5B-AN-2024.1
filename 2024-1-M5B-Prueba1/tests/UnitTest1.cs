using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;
using Drugs;
using Medicines;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using WebAPI.Controllers;

namespace tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void GetMainDrug_NoDrugs_ThrowsException()
    {
        // Arrange
        var medicine = new Medicine { Drugs = new Drug[0] };
        var mockMedicineService = new Mock<IMedicineService>();
        var controller = new MedicineController(mockMedicineService.Object);

        // Act + Assert
        Assert.ThrowsException<Exception>(() => controller.MainDrug(medicine));
    }

   
    
    [TestMethod]
    public void GetAll_ReturnsOkResult()
    {
        // Arrange
        var mockService = new Mock<IMedicineService>();
        mockService.Setup(service => service.GetAll()).Returns(new[] { new Medicine() }); // Mocking the service method

        var controller = new MedicineController(mockService.Object);

        // Act
        var result = controller.GetAll();

        // Assert
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetAll_ExceptionThrown_ReturnsBadRequest()
    {
        // Arrange
        var mockService = new Mock<IMedicineService>();
        mockService.Setup(service => service.GetAll()).Throws(new Exception("Test exception"));

        var controller = new MedicineController(mockService.Object);

        // Act
        var result = controller.GetAll() as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test exception", result.Value);
    }

    [TestMethod]
    public void MainDrug_ReturnsOkResult()
    {
        // Arrange
        var mockService = new Mock<IMedicineService>();
        mockService.Setup(service => service.GetMainDrug(It.IsAny<Medicine>())).Returns("Main Drug");

        var controller = new MedicineController(mockService.Object);

        // Act
        var result = controller.MainDrug(new Medicine()) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Main Drug", result.Value);
    }

    [TestMethod]
    public void MainDrug_ExceptionThrown_ReturnsBadRequest()
    {
        // Arrange
        var mockService = new Mock<IMedicineService>();
        mockService.Setup(service => service.GetMainDrug(It.IsAny<Medicine>())).Throws(new Exception("Test exception"));

        var controller = new MedicineController(mockService.Object);

        // Act
        var result = controller.MainDrug(new Medicine()) as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Test exception", result.Value);
    }


}