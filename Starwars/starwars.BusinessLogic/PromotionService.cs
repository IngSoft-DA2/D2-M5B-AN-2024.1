using System;
using System.IO;
using System.Reflection;
using starwars.IBusinessLogic;

namespace starwars.BusinessLogic
{
    public class PromotionService : IPromotionService
    {
        public PromotionService()
        {
        }

        public List<string> GetAllPromotions()
        {
            try
            {
                List<string> promotionsNames = new List<string>();
                //string baseDirectory = Directory.GetCurrentDirectory(); no, no no
                string baseDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string promotionsPath = Path.Combine(baseDirectory, "Promotions");

                if (!Directory.Exists(promotionsPath))
                {
                    //Manejar la excepcion.
                    throw new Exception("No encuentro la carpeta de promociones");
                }

                foreach (var file in Directory.GetFiles(promotionsPath, "*.dll"))
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    promotionsNames.Add(fileName);
                }
                return promotionsNames;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
                    
                  
