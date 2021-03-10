using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoITSC.Services
{
    public class MailBoxService
    {

        EmploymentAPI _api = new EmploymentAPI();
        UserService userService = new UserService();
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

        //public async Task<MAILBOX> GetInfo(int id)
        //{
        //    MAILBOX mail = new MAILBOX();
        //    var httpClient = new HttpClient();
        //    string apiResponse = "";

        //    var request = new HttpRequestMessage
        //      //(HttpMethod.Get, $"http://api-empleo.azurewebsites.net/api/CAREERS/{id}");
        //      (HttpMethod.Get, $"{_api.localUrl}/api/CAREERS/{id}");

        //    var response = await httpClient.SendAsync(request);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        apiResponse = await response.Content.ReadAsStringAsync();
        //        mail = JsonConvert.DeserializeObject<MAILBOX>(apiResponse);
        //    }

        //    return mail;
        //}

        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = _api.Initial();
            var deleteTask = client.DeleteAsync($"api/MAILBOX/{id}");
            deleteTask.Wait();

            var result = deleteTask.Result;

            return result;
        }

        public async Task<HttpResponseMessage> Create(MAILBOX user)
        {
            HttpClient client = _api.Initial();
            var usuario = await userService.GetInfo((int)user.userId);
            user.name = $"{usuario.name} {usuario.lastName}";
            user.carrer = usuario.career;

            user.dateStart = DateTime.Now.ToString("dd-MMMM-yyyy", CultureInfo.CreateSpecificCulture("es-ES"));

            // HTTP POST
            var postTask = client.PostAsync("api/MAILBOX", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            postTask.Wait();

            var result = postTask.Result;

            return result;
        }

    }
}
