using Microsoft.Extensions.Configuration;
using System.IO;

namespace ServiceClient1
{
    public class Common
    {
        public static string Service()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            string url = config.GetValue<string>("ServiceSettings:Url");
            return url.ToString();
        }
    }
}
