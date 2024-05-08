using WebApi.Controllers;
using Logic.Models;
using Logic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;
using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace WebApiTests;


[TestClass]
public class ControllerTests
{
    private readonly Mock<IMedicineService> _mockService;
    private readonly MedicineController _controller;

    public MedicineControllerTests()
    {
        _mockService = new Mock<IMedicineService>();
        _controller = new MedicineController(_mockService.Object);
    }

    [TestMethod]

    public void GetAllMedicinesReturnsOk()
    {
        // Arrange
        var medicines = new List<Medicine>
        {
            new Medicine { Id = 1, Name = "Medicine1", Description = "Description1", Brand = "Brand1", Price = 10.0m },
            new Medicine { Id = 2, Name = "Medicine2", Description = "Description2", Brand = "Brand2", Price = 20.0m }
        };

        _mockService.Setup(service => service.GetAll()).Returns(medicines);
        var result = _controller.Get();
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void GetAllMedicinesReturnsBadRequest()
    {
        _mockService.Setup(service => service.GetAll()).Throws(new Exception());
        var result = _controller.Get();
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }
//no me dio el tiempo jeje
}