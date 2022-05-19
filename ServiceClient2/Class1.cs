using RestSharp;
using System;

namespace ServiceClient2
{
    public class Class1
    {
        static void Record()
        {
            string url = "http://localhost:50354/api/Student"; // from microservice1

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.GetAsync(request);
        }
    }
}
