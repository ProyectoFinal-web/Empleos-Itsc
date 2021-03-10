using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpleoITSC.Helper
{
    public class EmploymentAPI
    {
        public string localUrl { get; set; } = "http://localhost:44371";
        public  HttpClient Initial()
        {
            var client = new HttpClient();
            // client.BaseAddress = new Uri("http://api-empleo.azurewebsites.net/");
            client.BaseAddress = new Uri("http://localhost:44371/");
            return client;
        }
    }
}
