using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using starwars.Exceptions;
using starwars.IDataAccess;
using static System.Net.Mime.MediaTypeNames;


namespace starwars.BusinessLogic.Tests;

[TestClass]
public class CharacterTest
{
    private Mock<IGenericRepository<Character>> mock;
    private CharacterService? service;
    private Character? character;
    private Character? nullCharacter;
    private IEnumerable<Character>? characters;
    private Character? invalidCharacter;

    [TestInitialize]
    public void InitTest()
    {
        mock = new Mock<IGenericRepository<Character>>(MockBehavior.Strict);
        service = new CharacterService(mock.Object);
        character = new Character()
        {
            Id = 1,
            Description = "Test",
            Name = "Darth Nico",
            ImageUrl = ""
        };
        nullCharacter = null;
        characters = new List<Character>() { character };
        invalidCharacter = new Character() { Description = "", Id = 0, ImageUrl ="", Name=""};
    }

    [TestMethod]
    public void InsertCharacterOk()
    {
        //Act
        mock.Setup(x => x.Insert(It.IsAny<Character>()));
        service!.InsertCharacter(character!);

        //Assert
        mock.VerifyAll();
    }


    [ExpectedException(typeof(Exception))]
    [TestMethod]
    public void InsertNullCharacter()
    {
        //Arrange
        //Mock<ICharacterService>? mock;
        //mock = new Mock<ICharacterService>(MockBehavior.Strict);
        //CharacterService? service;
        //service = new CharacterService();
        //Character? nullcharacter = null;
        //Act
        service!.InsertCharacter(nullCharacter);
        //Assert
        mock!.VerifyAll();
    }

    [TestMethod]
    public void GetAllCharacters()
    {
        mock.Setup(m => m.GetAll<Character>(It.IsAny<Func<Character, bool>>(),
        null));
        IEnumerable<Character> newcharacters = service!.GetCharacters();
        mock.VerifyAll();
    }

    [ExpectedException(typeof(Exception))]
    [TestMethod]
    public void InsertInvalidCaracter()
    {
        service!.InsertCharacter(invalidCharacter!);
        mock!.VerifyAll();
    }

    [ExpectedException(typeof(NotFoundException))]
    [TestMethod]
    public void UpdateCharacterNonExist()
    {
        mock.Setup(m => m.Get(It.IsAny<Expression<Func<Character, bool>>>(),
        It.IsAny<List<string>>())).Returns(nullCharacter);

        service!.UpdateCharacter(character!);
        mock.VerifyAll();
    }
}