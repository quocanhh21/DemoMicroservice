using Microsoft.Extensions.Options;
using RestSharp;
using sclient2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sclient2
{
    public class NewService: INewService
    {
        private readonly IOptions<ServiceSettings> _serviceSettings;
        public NewService(IOptions<ServiceSettings> serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }
        public string ComposeUrl()
        {
            return _serviceSettings.Value.Url.ToString();
        }
        public string GettAllClass()
        {
            string url = _serviceSettings.Value.Url.ToString(); // from api microservice1

            var client = new RestClient(url);

            var request = new RestRequest();

            var response = client.Get(request);

            return response.Content.ToString();
        }
    }
}
