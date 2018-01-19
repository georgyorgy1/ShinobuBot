using System.IO;
using Microsoft.Extensions.Configuration;

namespace Shinobu.Services
{
    public class JsonStringService
    {
        public IConfiguration BuildConfig()
        {
            try
            {
                return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Files/config.json").Build();
            }
            
            catch (System.Exception ex)
            {
                ShinobuLoggerService.Log(ex.ToString());
                throw;
            }
        }
    }
}