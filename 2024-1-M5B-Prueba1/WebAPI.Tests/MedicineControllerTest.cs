using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace WebAPI.Tests
{
    [TestClass]
    public class MedicineControllerTest
    {
        private MedicineController _controller;
        private Mock<IMedicineService> _serviceMock;
        private List<Medicine> _medicineList = new List<Medicine>();
        private Medicine _medicine;
        private Drug _drug;

        [TestInitialize]
        public void Initialize()
        {
            _serviceMock = new Mock<IMedicineService>(MockBehavior.Strict);
            _controller = new MedicineController(_serviceMock.Object);
            Drug _drug = new Drug()
            {
                Milligrams = 1,
                Name = "ExperimentalDrug",
            };
            Medicine _medicine = new Medicine()
            {
                 Drugs = new List<Drug> { _drug }.ToArray(),
                 Name = "TestMedicine"

            };
            _medicineList.Add(_medicine);
        }

        [TestMethod]
        public void GetAllOk()
        {
            //Arrange
            _serviceMock.Setup(logic => logic.GetAll()).Returns(_medicineList);

            OkObjectResult expected = new OkObjectResult(_medicineList);

            List<Medicine> expectedObject = (expected.Value as List<Medicine>)!;

            //Act
            OkObjectResult result = (_controller.GetAll() as OkObjectResult)!;

            List<Medicine> objectResult = (result.Value as List<Medicine>)!;

            //Assert
            _serviceMock.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode) && expectedObject.First().Name.Equals(objectResult.First().Name));
        }

        [TestMethod]
        public void GetAllError()
        {
            //Arrange
            _serviceMock.Setup(logic => logic.GetAll()).Throws(new Exception("Error"));

            BadRequestObjectResult expected = new BadRequestObjectResult("Error");

            //Act
            BadRequestObjectResult result = (_controller.GetAll() as BadRequestObjectResult)!;


            //Assert
            _serviceMock.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode) && expected.Value == result.Value);
        }

        [TestMethod]
        public void MainDrugOk()
        {
            //Arrange
            _serviceMock.Setup(logic => logic.GetMainDrug(_medicine)).Returns("Maindrug");

            OkObjectResult expected = new OkObjectResult("Maindrug");

            String expectedObject = (expected.Value as String)!;

            //Act
            OkObjectResult result = (_controller.MainDrug(_medicine) as OkObjectResult)!;

            String objectResult = (result.Value as String)!;

            //Assert
            _serviceMock.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode) && expected.Value == result.Value);
        }


        [TestMethod]
        public void MainDrugError()
        {
            //Arrange
            _serviceMock.Setup(logic => logic.GetMainDrug(_medicine)).Throws(new Exception("Error"));

            BadRequestObjectResult expected = new BadRequestObjectResult("Error");

            //Act
            BadRequestObjectResult result = (_controller.MainDrug(_medicine) as BadRequestObjectResult)!;

            //Assert
            _serviceMock.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode) && expected.Value == result.Value);
        }
    }
}