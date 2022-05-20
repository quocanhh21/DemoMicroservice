using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient2
{
    public class ClassProcessor
    {
        public void LoadClass()
        {
            string url = ConfigurationManager.AppSettings["host2"]; // from api microservice1

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine(response.Content.ToString());

        }
    }
}
