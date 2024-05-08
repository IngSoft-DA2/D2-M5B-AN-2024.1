namespace MedicineTest;

[TestClass]
public class MedicineTests
{
    [TestMethod]
    
    public void GetMainDrugReturnsOk()
    {
        var medicine = new Medicine { Name = "Medicine1", Drugs = new Drug[] { new Drug { Milligrams = 500, Name = "paracetamol" } } };
        _mockService.Setup(service => service.GetMainDrug(medicine)).Returns("paracetamol");
        var result = _controller.GetMainDrug(medicine);
        Assert.AreEqual("paracetamol", result);
    }

    public void GetMainDrugReturnsBadRequest()
    {
        var medicine = new Medicine { Name = "Medicine1", Drugs = new Drug[] { } };
        _mockService.Setup(service => service.GetMainDrug(medicine)).Throws(new Exception());
        var result = _controller.GetMainDrug(medicine);
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }
}