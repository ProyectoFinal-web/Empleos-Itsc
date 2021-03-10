using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoITSC.Services
{
    public class GraduateService
    {
        EmploymentAPI _api = new EmploymentAPI();
        CareersService carrersService = new CareersService();

        public async Task<List<GRADUATEPLUS>> GetAll()
        {
            List<GRADUATEPLUS> graduates = new List<GRADUATEPLUS>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/GRADUATEPLUS");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                graduates = JsonConvert.DeserializeObject<List<GRADUATEPLUS>>(results);
            }

            return graduates;
        }

        //public async Task<GRADUATEPLUS> Details(int id)
        //{
        //    GRADUATEPLUS graduates = new GRADUATEPLUS();
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = await client.GetAsync($"api/GRADUATEPLUS/{id}");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var results = res.Content.ReadAsStringAsync().Result;
        //        graduates = JsonConvert.DeserializeObject<GRADUATEPLUS>(results);
        //    }

        //    return graduates;
        //}

        public HttpResponseMessage Create(GRADUATEPLUS student, IFormFile formFile)
        {
            HttpClient client = _api.Initial();
            if(formFile != null)
            {
                var bytes = GetBytes(formFile);
                student.photo = bytes;
            }
            
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
              //(HttpMethod.Get, $"http://api-empleo.azurewebsites.net/api/GRADUATEPLUS/{id}");
              (HttpMethod.Get, $"{_api.localUrl}/api/GRADUATEPLUS/{id}");

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<GRADUATEPLUS>(apiResponse);
            }

            return employee;
        }

        public HttpResponseMessage Update(GRADUATEPLUS employee, IFormFile file)
        {
            if (file != null)
            {
                var bytes = GetBytes(file);
                employee.photo = bytes;
            }
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
                //(HttpMethod.Put, $"http://api-empleo.azurewebsites.net/api/GRADUATEPLUS/{employee.gradId}")
                (HttpMethod.Put, $"{_api.localUrl}/api/GRADUATEPLUS/{employee.gradId}")
            {
                Content = new StringContent(new JavaScriptSerializer().Serialize(employee), Encoding.UTF8, "application/json")
            };

            var response =  httpClient.SendAsync(request);
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

        public byte[] GetBytes(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                 formFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
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
