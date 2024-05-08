using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class MedicineTest
    {
        public void GetMainDrug_WhenNoDrugs_ThrowsException()
        {
            var drugServiceMock = new Mock<IDrugsService>();
            var medicineService = new MedicineService(drugServiceMock.Object);
            var medicine = new Medicine() { Name = "No Drugs Medicine", Drugs = new Drug[0] };

            Assert.ThrowsException<Exception>(() => medicineService.GetMainDrug(medicine));
        }

        [TestMethod]
        public void GetMainDrug_WhenSingleDrug_ReturnsDrugName()
        {
            var drugServiceMock = new Mock<IDrugsService>();
            var medicineService = new MedicineService(drugServiceMock.Object);
            var drugName = "Single Drug";
            var medicine = new Medicine() { Name = "Medicine with Single Drug", Drugs = new[] { new Drug() { Name = drugName, Milligrams = 100 } } };

            var result = medicineService.GetMainDrug(medicine);

            Assert.AreEqual(drugName, result);
        }

        [TestMethod]
        public void GetMainDrug_WhenMultipleDrugs_CallsDrugService()
        {
            var drugServiceMock = new Mock<IDrugsService>();
            var medicineService = new MedicineService(drugServiceMock.Object);
            var medicine = new Medicine()
            {
                Name = "Medicine with Multiple Drugs",
                Drugs = new[]
                {
                    new Drug() { Name = "Drug A", Milligrams = 100 },
                    new Drug() { Name = "Drug B", Milligrams = 200 },
                    new Drug() { Name = "Drug C", Milligrams = 300 }
                }
            };

            drugServiceMock.Setup(x => x.MainDrug(It.IsAny<Drug[]>())).Returns("Main Drug");

            var result = medicineService.GetMainDrug(medicine);

            Assert.AreEqual("Main Drug", result);
            drugServiceMock.Verify(x => x.MainDrug(medicine.Drugs), Times.Once);
        }
    }
}
