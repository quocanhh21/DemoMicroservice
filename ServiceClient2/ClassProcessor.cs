using System.Threading.Tasks;

namespace ServiceClient2
{
    public class ClassProcessor
    {
        public async Task LoadClass(int classId = 0)
        {
            // from appsetting.json microservice1 ( http://localhost:11271/api/)
            string urlService2 = Common.Service();
            string url = "";
            if (classId > 0)
            {
                url = $"{urlService2}Class/{classId}";
            }
        }
    }
}
