using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace EmpleoITSC.Services
{
    public class JobService
    {

        EmploymentAPI _api = new EmploymentAPI();
        CareersService carrersService = new CareersService();

        public async Task<List<JOB>> GetAll()
        {
            List<JOB> empleo = new List<JOB>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/JOB");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                empleo = JsonConvert.DeserializeObject<List<JOB>>(results);
            }

            return empleo;
        }

        public HttpResponseMessage Create(JOB empleo)
        {
            HttpClient client = _api.Initial();
            empleo.dateStart = DateTime.Now.ToString("dd-MMMM-yyyy", CultureInfo.CreateSpecificCulture("es-ES"));
            
            // HTTP POST
            var postTask = client.PostAsync("api/JOB", new StringContent(JsonConvert.SerializeObject(empleo), Encoding.UTF8, "application/json"));
            postTask.Wait();

            var result = postTask.Result;

            return result;
        }


        public async Task<JOB> GetInfo(int id)
        {
            JOB empleo = new JOB();
            var httpClient = new HttpClient();
            string apiResponse = "";

            var request = new HttpRequestMessage
              //(HttpMethod.Get, $"http://api-empleo.azurewebsites.net/api/JOB/{id}");
              (HttpMethod.Get, $"{_api.localUrl}/api/JOB/{id}");

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsStringAsync();
                empleo = JsonConvert.DeserializeObject<JOB>(apiResponse);
            }

            return empleo;
        }

        public HttpResponseMessage Update(JOB empleo)
        {

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
                //(HttpMethod.Put, $"http://api-empleo.azurewebsites.net/api/JOB/{empleo.jobId}")
                (HttpMethod.Put, $"{_api.localUrl}/api/JOB/{empleo.jobId}")
            {
                Content = new StringContent(new JavaScriptSerializer().Serialize(empleo), Encoding.UTF8, "application/json")
            };

            var response = httpClient.SendAsync(request);
            response.Wait();

            var result = response.Result;

            return result;
        }


        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = _api.Initial();
            var deleteTask = client.DeleteAsync($"api/JOB/{id}");
            deleteTask.Wait();

            var result = deleteTask.Result;

            return result;
        }
        public async Task<List<string>> carreras()
        {
            var carreras = new List<string>();
            var lista = await carrersService.GetAll();
            foreach (var career in lista)
            {
                carreras.Add(career.career);
            }

            return carreras;
        }

       

    }
}
