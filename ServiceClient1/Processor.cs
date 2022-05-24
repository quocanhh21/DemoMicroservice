using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceClient1
{
    public class Processor
    {
        public static async Task<StudentModel> LoadStudent(int idStudent = 1)
        {
            // from appsetting.json microservice2
            string urlService1 = Common.Service();
            string url = "";

            if (idStudent > 0)
            {
                url = $"{urlService1}api/Student/{idStudent}";
            }
            else
            {
                url = $"{urlService1}api/Student";
            }

            HttpClient client = new HttpClient();

            //GET 
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                StudentModel student = null;
                if (response.IsSuccessStatusCode)
                {
                    student = await response.Content.ReadAsAsync<StudentModel>();

                    return student;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
