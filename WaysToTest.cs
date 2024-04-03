using Domain.Interfaces;
using Moq;
using SimpleServer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Castle.Core.Resource;

namespace SimpleServer.test
{
    [TestClass]
    public class WaysToTest
    {
        //TODO Comentado
        ///*
        // * Un test fake es un tipo de objeto utilizado en pruebas de software para reemplazar un objeto real que tiene dependencias externas (como una base de datos o un servicio web). El objeto falso tiene una implementación simplificada de ciertos métodos que se utilizan en lugar del objeto real en las pruebas. El objetivo de usar un objeto falso es aislar el código que se está probando de las dependencias externas, de manera que las pruebas puedan ejecutarse de manera más rápida y confiable.
        // */
        [TestMethod]
        public void GetCustomers_ReturnsTestCustomers()
        {
           // Arrange
           var fakeDatabase = new FakeDatabase();
           var service = new MyService(fakeDatabase);

           // Act
           var result = service.GetCustomers();

           // Assert
           Assert.NotNull(result);
           Assert.IsType<List<Customer>>(result);
           Assert.Equal(2, result.Count);
           Assert.Equal("John Doe", result[0].Name);
           Assert.Equal("Jane Smith", result[1].Name);
        }


        ///*
        // * Un test dummy es un tipo de objeto utilizado en pruebas de software para cumplir con los requisitos de la firma de un método o constructor, pero que nunca se utiliza en realidad durante la prueba. Los objetos ficticios se utilizan para satisfacer al compilador o cumplir con la firma del método, sin afectar la prueba en sí.
        // */
        [TestMethod]
        public void DoSomething_SucceedsWithDummyCustomer()
        {
           // Arrange
           var dummyCustomer = new Customer();
           var service = new MyService();

           // Act
           service.DoSomething(dummyCustomer);
        }

        ///*
        // * Un test stub es un tipo de objeto utilizado en pruebas de software para proporcionar respuestas predeterminadas a las llamadas de método. Los objetos ficticios se utilizan para simular un comportamiento particular de un objeto en una prueba. Por ejemplo, se puede crear un objeto ficticio que simule una conexión a una base de datos, para evitar el tiempo de espera necesario para conectarse a una base de datos real durante la prueba.
        // */
        [TestMethod]
        public void SendEmail_LogsEmailMessage()
        {
           // Arrange
           var stubEmailService = new StubEmailService();
           var service = new MyService(stubEmailService);

           // Act
           const result = service.SendEmail("jane@example.com", "Test Email", "This is a test email.");

           // Assert
           var expectedOutput = "To: jane@example.com, Subject: Test Email, Body: This is a test email.";
           Assert.Contains(expectedOutput, result);
        }

        //// MOCKS === SIMULAR COMPORTAMIENTO :D 
        [TestMethod]
        public void PostTest()
        {
           //Arrange
           SomeDto expectedDTO = new SomeDto()
           {
               Data = "PA"
           };
           var aGreetingObject = new Mock<IGreetingObject>(MockBehavior.Strict);
           var controller = new SimpleController(aGreetingObject.Object);
           aGreetingObject.Setup(m => m.GetOnPostAction(It.IsAny<string>())).Returns(expectedDTO.Data);

           //Act
           var resultCall = controller.Post(expectedDTO);

           //Assert
           aGreetingObject.VerifyAll();
           Assert.AreEqual(resultCall.Value, expectedDTO.Data);
        }

        ///*
        // * Pero cual es la diferencia?
        // * Supongamos que estamos probando una clase de registro que utiliza una clase de correo electrónico para enviar correos electrónicos de confirmación a los usuarios. Queremos asegurarnos de que la clase de correo electrónico se llama correctamente y que se envía el correo electrónico de confirmación al usuario. En este caso, en lugar de crear un stub que simplemente devuelva un valor predefinido, podemos crear un mock que implemente la interfaz de la clase de correo electrónico y que verifique que el método de enviar correo electrónico se llama correctamente con los argumentos adecuados. De esta manera, podemos verificar que se ha enviado el correo electrónico correctamente y que la clase de correo electrónico se ha llamado correctamente durante la prueba.
        // * 
        // */
        
    }
}