using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpleoITSC.Services
{
    public class MailBoxService
    {

        EmploymentAPI _api = new EmploymentAPI();

        public async Task<List<MAILBOX>> GetAll()
        {
            List<MAILBOX> mail = new List<MAILBOX>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/MAILBOX");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                mail = JsonConvert.DeserializeObject<List<MAILBOX>>(results);
            }

            return mail;
        }

        public async Task<MAILBOX> GetInfo(int id)
        {
            MAILBOX mail = new MAILBOX();
            var httpClient = new HttpClient();
            string apiResponse = "";

            var request = new HttpRequestMessage
              (HttpMethod.Get, $"http://api-empleo.azurewebsites.net/api/CAREERS/{id}");

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsStringAsync();
                mail = JsonConvert.DeserializeObject<MAILBOX>(apiResponse);
            }

            return mail;
        }

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = _api.Initial();
            var deleteTask = client.DeleteAsync($"api/CAREERS/{id}");
            deleteTask.Wait();

            var result = deleteTask.Result;

            return result;
        }

    }
}
