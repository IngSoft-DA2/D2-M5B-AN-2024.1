using ImporterInterface;

namespace WebApi.Models.Out;

public class ImporterModel
{
    public string Name { get; set; }
    
    public ImporterModel(IImporter importer)
    {
        Name = importer.GetName();
    }
}