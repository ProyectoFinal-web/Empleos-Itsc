using EmpleoITSC.Models;
using EmpleoITSC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();
        CareersService carrersService = new CareersService();
        // Listar Objectos
        public async Task<IActionResult> Index()
        {
            List<USERS> user = await userService.GetAll();
            return View(user);
        }

        // Crear Objecto
        public async Task<IActionResult> Create()
        {
            ViewBag.careers = await carreras();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(USERS user, IFormFile upload)
        {
            ViewBag.careers = await carreras();
            var result = userService.Create(user, upload);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        /*
        public async Task<IActionResult> Details(int id)
        {
            USERS user = await userService.GetInfo(id);
            return View(user);
        }*/


        //editar objeto
        public async Task<IActionResult> ViewInfoEdit(int id)
        {
            ViewBag.careers = await carreras();
            USERS user = await userService.GetInfo(id);
            return View(user);
        }

        public ActionResult Edit(USERS user)
        {
            var result = userService.Update(user);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");

            return View();
        }

        // Eliminar Objeto
        public IActionResult Delete(int id)
        {
            var result = userService.Delete(id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<FileResult> descargar(int codigo)
        {
            USERS student = await userService.GetInfo(codigo);

            return File(student.cv, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", student.cvName);

        }

        public async Task<List<string>> carreras()
        {
            var carreras = new List<string>();
            var lista = await carrersService.GetAll();
            foreach(var career in lista)
            {
                carreras.Add(career.career);
            }

            return carreras;
        }

    }
}
