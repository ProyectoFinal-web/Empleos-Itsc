using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmpleoITSC.Helper
{
    public class EmploymentAPI
    {
        public  HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api-empleo.azurewebsites.net/");
            return client;
        }
    }
}
