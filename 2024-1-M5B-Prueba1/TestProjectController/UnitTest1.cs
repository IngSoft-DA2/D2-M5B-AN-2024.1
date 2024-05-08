using Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Moq;

namespace TestProjectController
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockService = new Mock<IMedicineService>();
            List<Medicine> medicines = new List<Medicine>() {
                new Medicine { Name = "Dolex 500", Drugs =  [ new Drug { Milligrams = 500, Name = "paracetamol" } ] },
                new Medicine { Name = "Perifar 200", Drugs = [ new Drug { Milligrams = 200, Name = "ibuprofeno" } ] },
                new Medicine { Name = "Biogrip", Drugs = [

                        new Drug { Milligrams = 100, Name = "paracetamol" },
                        new Drug { Milligrams = 200, Name = "loratadina" },
                        new Drug { Milligrams = 100, Name = "cafeina" }
                    ]}};

            mockService.Setup(service => service.GetAll())
                .Returns(medicines);

            var controller = new MedicineController(mockService.Object);

            // Act
            var result = controller.GetAll();
            var expectedresult = new OkObjectResult( new{ success = true, response = controller.GetAll() });

            // Assert
            Assert.AreEqual(expectedresult, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var mockMedicineService = new Mock<IMedicineService>();
            var mockDrugService = new Mock<IDrugsService>();
            Medicine NewMedicine = new Medicine()
            {
                Drugs = [

                        new Drug { Milligrams = 100, Name = "paracetamol" },
                        new Drug { Milligrams = 200, Name = "loratadina" },
                        new Drug { Milligrams = 100, Name = "cafeina" }
                    ]
            };
            Drug[] drugs = [
                        new Drug { Milligrams = 100, Name = "paracetamol" },
                        new Drug { Milligrams = 200, Name = "loratadina" },
                        new Drug { Milligrams = 100, Name = "cafeina" }];

            mockDrugService.Setup(service => service.MainDrug(drugs)).Returns("MainDrug");
            mockMedicineService.Setup(service => service.GetMainDrug(NewMedicine)).Returns("MainDrug");

            var controller = new MedicineController(mockMedicineService.Object);

            // Act
            var result = controller.MainDrug(NewMedicine);
            var expectedresult = new OkObjectResult(new { success = true, response = controller.MainDrug(NewMedicine) });

            // Assert
            Assert.AreEqual(expectedresult, result);
        }
    }
}