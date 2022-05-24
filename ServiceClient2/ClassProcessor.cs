using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceClient2
{
    public class ClassProcessor
    {
        public static async Task<ClassModel> LoadClass(int classId = 1)
        {
            // from appsetting.json microservice1
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
        }
    }
}
