using Drugs;
using Logic;
using Logic.Models;
using Medicines;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Medicine med;
        private Drug drug;
        private Mock<IDrugsService> _drugServiceMock;
        private MedicineService _medicineService;
        private Mock<IMedicineService> _medicineServiceMock;
        private MedicineController _medicineController;
        
        
        [TestInitialize]
        public void setup()
        {
            _drugServiceMock = new Mock<IDrugsService>();
            _medicineService = new MedicineService(_drugServiceMock.Object);
            _medicineServiceMock = new Mock<IMedicineService>();
            _medicineController = new MedicineController(_medicineServiceMock.Object);
            drug = new Drug()
            {
                Milligrams = 10,
                Name = "novemina"
            };
            med = new Medicine()
            {
                Drugs = new[] { drug },
                Name = "medicina1"
            };
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetMainDrugsEmptyListTest()
        {
            med.Drugs = null;
            _medicineService.GetMainDrug(med);
        }
        
        [TestMethod]
        public void GetMainDrugsReturnsNameTest()
        {
           var name = _medicineService.GetMainDrug(med);
           Assert.AreEqual(name, drug.Name);
        }
        
        [TestMethod]
        public void GetMainDrugsOkTest()
        {
            _drugServiceMock.Setup(m => m.MainDrug(It.IsAny<Drug[]>())).Returns(drug.Name);
            var name = _medicineService.GetMainDrug(med);
            Assert.AreEqual(name, drug.Name);
        }

        [TestMethod]
        public void MedicineControllerGetAllTest()
        {
            var result = _medicineController.GetAll(null);
            var createdResult = result as ObjectResult;
            Assert.AreEqual(createdResult.StatusCode,401);
        }
    }
}
