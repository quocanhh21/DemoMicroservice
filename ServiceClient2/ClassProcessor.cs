using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceClient2
{
    public class ClassProcessor
    {
        public static async Task<ClassModel> LoadClass(int classId = 1)
        {
            // from appsetting.json microservice1 ( http://localhost:11271/api/)
            string urlService2 = Common.Service();
            string url = "";
            if (classId > 0)
            {
                url = $"{urlService2}api/Class/{classId}";
            }
            else
            {
                url = $"{urlService2}api/Class"; 
            }

            HttpClient client = new HttpClient();

            //GET 
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                ClassModel cl = null;
                if (response.IsSuccessStatusCode)
                {
                    cl = await response.Content.ReadAsAsync<ClassModel>();

                    return cl;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

            //var httpRequestMessage = new HttpRequestMessage();
            //httpRequestMessage.Method = HttpMethod.Post;
            //httpRequestMessage.RequestUri = new Uri($"{urlService2}api/Class");

            //var parameters = new List<KeyValuePair<string, string>>();
            //parameters.Add(new KeyValuePair<string, string>("Name", "class 10"));
            //parameters.Add(new KeyValuePair<string, string>("IdStudent", "15"));

            //var content = new FormUrlEncodedContent(parameters);
            //httpRequestMessage.Content = content;
            //var reponse = await client.SendAsync(httpRequestMessage);
            //var responseContent = await reponse.Content.ReadAsStringAsync();
            //return null;
        }
    }
}
