using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void GetAll_ServiceReturnsData_ReturnsOkWithData()
        {
            var medicines = new List<Medicine>
            {
                new Medicine { Name = "Medicine A" },
                new Medicine { Name = "Medicine B" }
            };

            var serviceMock = new Mock<IMedicineService>();
            serviceMock.Setup(s => s.GetAll()).Returns(medicines);

            var controller = new MedicineController(serviceMock.Object);

            var result = controller.GetAll();

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var model = okResult.Value as List<Medicine>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void GetAll_ServiceThrowsException_ReturnsBadRequestWithMessage()
        {
            var errorMessage = "Error fetching medicines";
            var serviceMock = new Mock<IMedicineService>();
            serviceMock.Setup(s => s.GetAll()).Throws(new Exception(errorMessage));

            var controller = new MedicineController(serviceMock.Object);

            var result = controller.GetAll();

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);

            var error = badRequestResult.Value as string;
            Assert.IsNotNull(error);
            Assert.AreEqual(errorMessage, error);
        }

        [TestMethod]
        public void MainDrug_ServiceReturnsMainDrug_ReturnsOkWithDrugName()
        {
            var medicine = new Medicine { Name = "Medicine A" };
            var expectedDrugName = "Paracetamol";

            var serviceMock = new Mock<IMedicineService>();
            serviceMock.Setup(s => s.GetMainDrug(medicine)).Returns(expectedDrugName);

            var controller = new MedicineController(serviceMock.Object);

            var result = controller.MainDrug(medicine);

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var drugName = okResult.Value as string;
            Assert.IsNotNull(drugName);
            Assert.AreEqual(expectedDrugName, drugName);
        }

        [TestMethod]
        public void MainDrug_ServiceThrowsException_ReturnsBadRequestWithMessage()
        {
            var medicine = new Medicine { Name = "Medicine B" };
            var errorMessage = "Error getting main drug";

            var serviceMock = new Mock<IMedicineService>();
            serviceMock.Setup(s => s.GetMainDrug(medicine)).Throws(new Exception(errorMessage));

            var controller = new MedicineController(serviceMock.Object);

            var result = controller.MainDrug(medicine);

            Assert.IsInstanceOf<BadRequestObjectResult>(result);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);

            var error = badRequestResult.Value as string;
            Assert.IsNotNull(error);
            Assert.AreEqual(errorMessage, error);
        }
    }
}
