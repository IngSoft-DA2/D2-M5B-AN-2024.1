using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Moq;
using starwars.Domain;
using starwars.IBusinessLogic;
using starwars.WebApi.Controllers;
using starwars.WebApi.Dtos;

namespace starwars.WebApi.Tests;

[TestClass]
public class CharactersControllerTests
{
    [TestMethod]
    public void GetAllCharacters()
    {
        //Arrange
        Character character = new Character()
        {
            Name = "Yoda",
            Description = "Jedi Master"
        };
        IEnumerable<Character> characters = new List<Character>()
            {
                character
            };

        Mock<ICharacterService> charactersLogicMock = new Mock<ICharacterService>(MockBehavior.Strict);
        charactersLogicMock.Setup(logic => logic.GetCharacters())
            .Returns(characters);

        CharactersController _characterController = new CharactersController(charactersLogicMock.Object);
        OkObjectResult expected = new OkObjectResult(new List<CharacterDTO>() {
                new CharacterDTO(characters.First())});

        List<CharacterDTO> expectedObject = (expected.Value as List<CharacterDTO>)!;
        //Act
        OkObjectResult result = (_characterController.GetCharacters() as OkObjectResult)!;
        Console.WriteLine(result.Value);
        List<CharacterDTO> objectResult = (result.Value as List<CharacterDTO>)!;
        //Assert
        charactersLogicMock.VerifyAll();
        Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
            && expectedObject.First().Name.Equals(objectResult.First().Name));
    }
}