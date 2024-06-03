using Domain;
using Domain.Importer;
using ImporterInterface;

namespace JsonImporter;
public class JsonImporter : IImporter
{
  public string GetName()
  {
    return "Soy un Json Importer";
  }

  public List<Pet> ImportPets()
  {
    // Deberia leer de un archivo JSON....
    // esto es harcodeado
    return new List<Pet>() { new Pet() { Id = 1, Name = "Name", Age = 1 } };
  }
}
