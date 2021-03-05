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
    public class CareersService
    {

        EmploymentAPI _api = new EmploymentAPI();
        public async Task<List<CAREERS>> GetAll()
        {
            List<CAREERS> user = new List<CAREERS>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/CAREERS");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<CAREERS>>(results);
            }

            return user;
        }
    }
}
