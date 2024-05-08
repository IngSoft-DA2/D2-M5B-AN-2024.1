using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Logic.Models;
using Medicines;
using WebAPI.Controllers;

namespace Tests
{
    [TestFixture]
    public class MedicineTests
    {
        [Test]
        public void GetMainDrug_ReturnsCorrectDrugName()
        {
            // Arrange
            var mockDrugsService = new Mock<IDrugsService>();
            mockDrugsService.Setup(service => service.MainDrug(It.IsAny<Drug[]>())).Returns("paracetamol");
            var medicineService = new MedicineService(mockDrugsService.Object);

            var medicine = new Medicine
            {
                Drugs = new[] { new Drug { Milligrams = 500, Name = "paracetamol" } }
            };

            // Act
            var result = medicineService.GetMainDrug(medicine);

            // Assert
            Assert.AreEqual("paracetamol", result);
        }

        [Test]
        public void GetAll_ReturnsAllMedicines()
        {
            // Arrange
            var mockMedicineService = new Mock<IMedicineService>();
            mockMedicineService.Setup(service => service.GetAll()).Returns(new List<Medicine> { new Medicine { Name = "Dolex" } });
            var controller = new MedicineController(mockMedicineService.Object);

            // Act
            var result = controller.GetAll() as OkObjectResult;

            // Assert
            var medicines = result.Value as IEnumerable<Medicine>;
            Assert.IsNotNull(medicines);
            Assert.AreEqual(1, medicines.Count());
            Assert.AreEqual("Dolex", medicines.First().Name);
        }

        [Test]
        public void MainDrug_ReturnsCorrectMainDrug()
        {
            // Arrange
            var mockMedicineService = new Mock<IMedicineService>();
            mockMedicineService.Setup(service => service.GetMainDrug(It.IsAny<Medicine>())).Returns("paracetamol");
            var controller = new MedicineController(mockMedicineService.Object);
            var medicine = new Medicine();

            // Act
            var result = controller.MainDrug(medicine) as OkObjectResult;

            // Assert
            Assert.AreEqual("paracetamol", result.Value);
        }
    }
}
