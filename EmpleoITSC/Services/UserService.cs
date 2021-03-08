using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using Microsoft.AspNetCore.Http;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoITSC.Services
{
    public class UserService
    {
        EmploymentAPI _api = new EmploymentAPI();
        private readonly string estudiante = "EST";

        public async Task<List<USERS>> GetAll()
        {
            List<USERS> user = new List<USERS>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/USER");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<USERS>>(results);
            }


            return user;
        }
        
        public HttpResponseMessage Create(USERS user, IFormFile formFile)
        {
            HttpClient client = _api.Initial();

            if(user.rol == estudiante)
            {
                var bytes = GetBytes(formFile);
                string name = (string)formFile.FileName;
                user.cv = bytes;
                user.cvName = name;
            }
            

            // HTTP POST
            var postTask = client.PostAsync("api/USER", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            postTask.Wait();

            var result = postTask.Result;

            return result;
        }

        
        public async Task<USERS> GetInfo(int id)
        {
            USERS user = new USERS();
            var httpClient = new HttpClient();
            string apiResponse = "";

            var request = new HttpRequestMessage
              //(HttpMethod.Get, $"http://api-empleo.azurewebsites.net/api/USER/{id}");
              (HttpMethod.Get, $"{_api.localUrl}/api/USER/{id}");

            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<USERS>(apiResponse);
            }

            return user;
        }

        public HttpResponseMessage Update(USERS user)
        {

            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
                //(HttpMethod.Put, $"http://api-empleo.azurewebsites.net/api/USER/{user.userId}")
                (HttpMethod.Put, $"{_api.localUrl}/api/USER/{user.userId}")
            {
                Content = new StringContent(new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")
            };

            var response = httpClient.SendAsync(request);
            response.Wait();

            var result = response.Result;

            return result;
        }

        
        public HttpResponseMessage Delete(int id)
        {
            HttpClient client = _api.Initial();
            var deleteTask = client.DeleteAsync($"api/USER/{id}");
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

        public async Task<List<string>> fileName()
        {
            List<string> names = new List<string>();
            List<USERS> users = new List<USERS>();

            users = await GetAll();
            var stream = new MemoryStream();
            IFormFile file;

            foreach (var files in users)
            {
                stream = new MemoryStream(files.cv);
                file = new FormFile(stream, 0, stream.Length, "name", "fileName");
                names.Add(file.FileName);
            }

            return names;
        }

    }
}
