using Logic;
using Medicines;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;

namespace Tests
{
    [TestClass]
    public class Test
    {
        private Mock<IDrugsService> mock;
        private MedicineService? service;

        [TestInitialize]
        public void Initialize()
        {
            this.mock = new Mock<IDrugsService>(MockBehavior.Strict);
            service = new MedicineService(mock.Object);

        }


        [TestMethod]
        public void GetMainDrugNoDrugs()
        {
            Medicine medicine = new Medicine() { Drugs = new Drug[0] };
            Assert.ThrowsException<Exception>(() => service.GetMainDrug(medicine));
        }

        [TestMethod]
        public void GetMainDrugOneDrug()
        {
            Medicine medicine = new Medicine() { Drugs = new Drug[] { new Drug() { Name = "paracetamol", Milligrams = 500 } } };
            string result = service.GetMainDrug(medicine);
            Assert.AreEqual("paracetamol", result);
        }

        [TestMethod]
        public void GetMainDrugMultipleDrugs()
        {
            Drug[] drugs = new Drug[]
            {
                new Drug() { Name = "paracetamol", Milligrams = 500 },
                new Drug() { Name = "ibuprofeno", Milligrams = 200 },
                new Drug() { Name = "loratadina", Milligrams = 200 }
            };
            Medicine medicine = new Medicine() { Drugs = drugs };
            mock.Setup(x => x.MainDrug(drugs)).Returns("paracetamol");
            string result = service.GetMainDrug(medicine);
            Assert.AreEqual("paracetamol", result);
        }
    }
}
