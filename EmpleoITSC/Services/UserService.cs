using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpleoITSC.Services
{
    public class UserService
    {
        EmploymentAPI _api = new EmploymentAPI();

        public async Task<List<USERS>> GetAll()
        {
            List<USERS> graduates = new List<USERS>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/USER");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                graduates = JsonConvert.DeserializeObject<List<USERS>>(results);
            }

            return graduates;
        }
        /*
        public HttpResponseMessage Create(GRADUATEPLUS student)
        {
            HttpClient client = _api.Initial();

            // HTTP POST
            var postTask = client.PostAsync("api/GRADUATEPLUS", new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json"));
            postTask.Wait();

            var result = postTask.Result;

            return result;
        }

        public async Task<GRADUATEPLUS> GetInfo(int id)
        {
            GRADUATEPLUS employee = new GRADUATEPLUS();
            var httpClient = new HttpClient();
            string apiResponse = "";

            var request = new HttpRequestMessage
              (HttpMethod.Get, $"http://api-empleo.azurewebsites.net/api/GRADUATEPLUS/{id}");

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<GRADUATEPLUS>(apiResponse);
            }

            return employee;
        }

        public HttpResponseMessage Update(GRADUATEPLUS employee)
        {

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"http://api-empleo.azurewebsites.net/api/GRADUATEPLUS/{employee.gradId}")
            {
                Content = new StringContent(new JavaScriptSerializer().Serialize(employee), Encoding.UTF8, "application/json")
            };

            var response = httpClient.SendAsync(request);
            response.Wait();

            var result = response.Result;

            return result;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = _api.Initial();
            var deleteTask = client.DeleteAsync($"api/GRADUATEPLUS/{id}");
            deleteTask.Wait();

            var result = deleteTask.Result;

            return result;
        }
        */
    }
}
