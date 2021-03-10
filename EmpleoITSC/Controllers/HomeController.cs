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
        UserService userService = new UserService();
        private readonly string admin = "ADM";
        private readonly string student = "EST";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Index(string user, string pass)
        {
            var usuario = await userService.Logued(user, pass);
            if (usuario != null)
            {
                if (usuario.rol == admin)
                {
                    //TempData["usuario"] = usuario;
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (usuario.rol == student)
                {
                    //TempData["usuario"] = usuario;
                    return RedirectToAction("Index", "HomeStudent");
                }
                else
                {
                    ViewBag.FailedLogin = "Usuario o Contraseña Incorrecta";
                    return View();
                }
            }
            else
            {
                ViewBag.FailedLogin = "Usuario o Contraseña Incorrecta";
                return View();
            }
            return View();
        }
    }
}
