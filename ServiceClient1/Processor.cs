using RestSharp;
using System;
using System.Configuration;

namespace ServiceClient1
{
    public class Processor
    {
       public void LoadStudent()
        {
            string url = ConfigurationManager.AppSettings["host"]; // from api microservice1

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            Console.WriteLine(response.Content.ToString());

        }
    }
}
