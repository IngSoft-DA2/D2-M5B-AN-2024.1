using Medicines;
using Moq;
using NUnit.Framework;
using Logic.Models;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Test;

[TestClass]
public class UnitTest1
{
    private Mock<IDrugsService> _mockDrugService;
    private Drug _drug;
    private Medicine _medicine;

    [TestInitialize]
    public void InitTest()
    {
        _mockDrugService = new Mock<IDrugsService>(MockBehavior.Strict);
        _drug = new Drug()
        {
            Milligrams = 3,
            Name = "Perifar"
        };
    }

    [TestCleanup]
    public void Cleanup()
    {
        _mockDrugService.VerifyAll();
    }

    [TestMethod]
    public void InsertValidBuilding()
    {
        //Arrange
        _mockBuildingRepo.Setup(m => m.Get(It.IsAny<Expression<Func<Building, bool>>>(),
    null)).Returns(_nullBuilding);
        _mockUserService.Setup(u => u.GetUser(It.IsAny<string>())).Returns(_managerUser);
        _mockDepartmentService.Setup(u => u.ValidateDepartmentToCreate(It.IsAny<Department>())).Returns(_department);
        _mockOwnerService.Setup(u => u.ValidateOwnerToCreate(It.IsAny<Owner>())).Returns(_department.Owner);


        _mockBuildingRepo.Setup(x => x.Insert(It.IsAny<Building>()));
        _mockBuildingRepo.Setup(x => x.Save());
        //Act
        Building createdBuilding = _buildingService!.CreateBuilding(_building!);

        //Assert
        Assert.AreEqual(createdBuilding.Name, _building.Name);
    }
}