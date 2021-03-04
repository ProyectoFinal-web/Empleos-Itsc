using EmpleoITSC.Helper;
using EmpleoITSC.Models;
using EmpleoITSC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoITSC.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
        
        //GraduateService graduateService = new GraduateService();
        //public async Task<IActionResult> /*Index*/ Lista()
        //{
        //    List<GRADUATEPLUS> graduates = await graduateService.GetAll();
        //    return View(graduates);
        //}

        //public async Task<IActionResult> Details(int id)
        //{
        //    GRADUATEPLUS student = await graduateService.GetInfo(id);

        //    return View(student);
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}
        
        //[HttpPost]
        //public ActionResult Create(GRADUATEPLUS student)
        //{
        //    var result = graduateService.Create(student);

        //    if(result.IsSuccessStatusCode)  return RedirectToAction("Index");

        //    //ModelState.AddModelError(string.Empty, "Pon un mensaje de error");
        //    return View();
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    GRADUATEPLUS student = await graduateService.GetInfo(id);

        //    return View(student);
        //    /*GRADUATEPLUS student = null;
        //    HttpClient client = _api.Initial();
        //    var  responseTask =  client.GetAsync($"api/GRADUATEPLUS/{id}");
        //    responseTask.Wait();

        //    var result = responseTask.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var readTask = result.Content.ReadAsAsync<GRADUATEPLUS>();
        //        readTask.Wait();

        //        student = readTask.Result;
        //    }

        //    return View(student);*/
        //}

        //[HttpPost]
        //public ActionResult Edit(GRADUATEPLUS student)
        //{
        //    var result = graduateService.Update(student);

        //    if (result.IsSuccessStatusCode)
        //    {
        //        // Recibir contenido y mandarlo por el View
        //        //string apiResponse = await result.Content.ReadAsStringAsync();
        //        //receivedEmployee = JsonConvert.DeserializeObject<GRADUATEPLUS>(apiResponse);

        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //    /* //HttpClient client = _api.Initial();
        //     var client = new HttpClient();
        //     //HTTP PUT
        //     client.BaseAddress = new Uri("https://localhost:44371/api/GRADUATEPLUS");
        //     var putTask = client.PutAsync("GRADUATEPLUS", new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json"));
        //     putTask.Wait();

        //     var result = putTask.Result;
        //     if (result.IsSuccessStatusCode)
        //         return RedirectToAction("Index");

        //     return View(student);*/
        //}

        //public async Task<ActionResult> ViewInfoDelete(int id)
        //{
        //    GRADUATEPLUS student = await graduateService.GetInfo(id);

        //    return View(student);
        //}

        //public ActionResult Delete(int id)
        //{
        //    var result = graduateService.Delete(id);

        //    if (result.IsSuccessStatusCode)
        //        return RedirectToAction("Index");

        //    return View();
        //}
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
