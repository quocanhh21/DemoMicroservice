using Microsoft.Extensions.Configuration;
using System.IO;

namespace ServiceClient2
{
    public static class Common
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
