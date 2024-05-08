using FluentAssertions;
using WebAPI;
using Drugs;
using Medicine;
using Logic;
using Moq;

namespace TestWebApi
{
    [TestClass]
    public class MedicineControllerTest
    {
        private Mock<IMedicineService>? _medicineServiceMock;
        private MedicineController? _controller;


        [TestInitialize]
        public void Initialize()
        {
            _medicineServiceMock = new Mock<IMedicineService>(MockBehavior.Strict);
            _drugsServiceMock = new Mock<IDrugsService>(MockBehavior.Strict);
            _controller = new MedicineController(MedicineController.Object);
        }

        [TestMethod]
        public void MainDrug_ShouldReturnCorrectDrug()
        {
            //string GetMainDrug(Medicine medicine);
            Drug mainDrug = drugs[0];
            
            _drugsServiceMock.Setup(x => x.GetMainDrug(It.IsAny<mainDrug>())).Returns(GetMainDrug);
            _controller.GetMainDrug(mainDrug);
        }


        [TestMethod]
        public void GetAllMedicine_ShouldReturnCorrectMedicineList()
        {
            //IEnumerable<Medicine> GetAll();
            var medicines = new List<Medicine>
            {
                new Medicine() { Name = "Dolex 500", Drugs = [new Drug() { Milligrams = 500, Name = "paracetamol"}]},
                new Medicine() { Name = "Perifar 200", Drugs = [new Drug() { Milligrams = 200, Name = "ibuprofeno"}]},
           };
            _drugsServiceMock.Setup(x => x.GetAll(It.IsAny<medicines>())).Returns(medicines);
            _controller.GetAll();
        }


    }
}
