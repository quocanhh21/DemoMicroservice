using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient2
{
    public class CallingWebApi
    {
        public static HttpClient client = new HttpClient();

        public static string ShowClass(ClassModel cl)
        {
            return $" Class Name: {cl.Name} -- Student ID: {cl.IdStudent} ";
        }

        public static async Task<Uri> CreateClassAsync(ClassModel cl)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Class", cl);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<ClassModel> GetClassAsync(string path)
        {
            ClassModel cl = null;
            HttpResponseMessage respon = await client.GetAsync(path);
            if (respon.IsSuccessStatusCode)
            {
                cl = await respon.Content.ReadAsAsync<ClassModel>();
            }

            return cl;
        }

        public static async Task<ClassModel> UpdateClasstAsync(ClassModel cl)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Class/{cl.Id}",cl);

            cl = await response.Content.ReadAsAsync<ClassModel>();

            return cl;
        }

        public static async Task<HttpStatusCode> DeleteAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Class/{id}");
            return response.StatusCode;
        }

        //Run
        public static async Task RunAsync()
        {
            string urlService = Common.Service();
            client.BaseAddress = new Uri($"{urlService}");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //Create Class
                ClassModel cl = new ClassModel {
                    
                    Name="Class 10",
                    IdStudent= 10
                };

                var url = await CreateClassAsync(cl);

                //Get class
                cl = await GetClassAsync(url.PathAndQuery);
                ShowClass(cl);

                //Update class
                cl.Name = "Class 15";
                await UpdateClasstAsync(cl);

                //Get update class
                cl = await GetClassAsync(url.PathAndQuery);

                //delete
                var statusCode = await DeleteAsync(url.PathAndQuery);
            }
            catch (Exception e )
            {
                throw new ArgumentException("Error" +e.Message);
            }
        }
    }
}
