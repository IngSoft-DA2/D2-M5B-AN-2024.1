using Moq;
using Medicines;
using Logic;
using Logic.Models;

namespace Testing;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestMethod1()
    {
        Mock<IDrugsService> mock = new(MockBehavior.Strict);
        IMedicineService service = new MedicineService(mock.Object);

        string result = service.GetMainDrug(new Medicine() { Name = "Solven", Drugs = [] });

        mock.VerifyAll();
    }

    [TestMethod]
    public void TestMethod2()
    {
        Mock<IDrugsService> mock = new(MockBehavior.Strict);
        IMedicineService service = new MedicineService(mock.Object);

        string result = service.GetMainDrug(new Medicine()
        {
            Name = "Solven",
            Drugs = [new Drug() { Milligrams = 100, Name = "test" }]
        });

        mock.VerifyAll();
        Assert.AreEqual(result, "test");
    }

    [TestMethod]
    public void TestMethod3()
    {
        Mock<IDrugsService> mock = new(MockBehavior.Strict);
        IMedicineService service = new MedicineService(mock.Object);

        Drug?[] drugs = [new Drug() { Milligrams = 100, Name = "test" }, new Drug() { Milligrams = 100, Name = "test" }];

        mock.Setup(x => x.MainDrug(drugs)).Returns("test");

        string result = service.GetMainDrug(new Medicine()
        {
            Name = "Solven",
            Drugs = drugs
        });

        mock.VerifyAll();
        Assert.AreEqual(result, "test");
    }
}