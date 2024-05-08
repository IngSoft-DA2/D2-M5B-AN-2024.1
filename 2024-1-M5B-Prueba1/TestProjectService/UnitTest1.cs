using Logic;
using Logic.Models;
using Moq;

namespace TestProjectService
{
    [TestClass]
    public class UnitTest1
    {
        private IMedicineService _service;




        [TestMethod]
        public void TestMethod1()
        {
            var mockMedicineService = new Mock<IMedicineService>();

            List<Medicine> medicines = new List<Medicine>() {
                new Medicine { Name = "Dolex 500", Drugs =  [ new Drug { Milligrams = 500, Name = "paracetamol" } ] },
                new Medicine { Name = "Perifar 200", Drugs = [ new Drug { Milligrams = 200, Name = "ibuprofeno" } ] },
                new Medicine { Name = "Biogrip", Drugs = [
                    
                        new Drug { Milligrams = 100, Name = "paracetamol" },
                        new Drug { Milligrams = 200, Name = "loratadina" },
                        new Drug { Milligrams = 100, Name = "cafeina" }
                    ]}};
                

        mockMedicineService.Setup(service => service.GetAll())
                .Returns(medicines);

            var medicineService = mockMedicineService.Object;

            var result = medicineService.GetAll();

            Assert.IsNotNull(medicines);
            Assert.AreEqual(3, medicines.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod2()
        {
            var mockMedicineService = new Mock<IMedicineService>();
           

            Medicine NewMedicine = new Medicine();


            mockMedicineService.Setup(service => service.GetMainDrug(NewMedicine)).Throws(new Exception());

            var medicineService = mockMedicineService.Object;

            var result = medicineService.GetMainDrug(NewMedicine);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var mockMedicineService = new Mock<IMedicineService>();
            var mockDrugService = new Mock<IDrugsService>();

            Medicine NewMedicine = new Medicine() { Drugs = [

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

            var medicineService = mockMedicineService.Object;

            var result = medicineService.GetMainDrug(NewMedicine);
            Assert.AreEqual("MainDrug", result);
        }


    }
    }