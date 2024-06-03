using Domain;
using Domain.Importer;

namespace ImporterInterface;

public interface IImporter
{
  string GetName();
  List<Pet> ImportPets();
}
