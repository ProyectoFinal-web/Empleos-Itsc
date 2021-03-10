using EmpleoITSC.Models;
using EmpleoITSC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();
        Pagination pagination = new Pagination();

        // Listar Objectos
        public async Task<IActionResult> Index(string word, int pagina = 1)
        {
            IEnumerable<USERS> user = await userService.GetAll();
            var search = filtro(word, user);
            var usuarios = search.OrderBy(x => x.name)
                    .Skip((pagina - 1) * pagination.cantidadRegistrosPorPagina)
                    .Take(pagination.cantidadRegistrosPorPagina).ToList();

            var totalDeRegistros = search.Count();
            var modelo = new IndexViewModel();
            modelo.Users = usuarios;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = pagination.cantidadRegistrosPorPagina;

            return View(modelo);
        }

        // Crear Objecto
        public async Task<IActionResult> Create()
        {
            ViewBag.careers = await userService.carreras();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(USERS user, IFormFile upload)
        {
            if (ModelState.IsValid)
            {
                ViewBag.careers = await userService.carreras();
                user.name = pagination.cadenaM(user.name);
                user.lastName = pagination.cadenaM(user.lastName);
                var result = userService.Create(user, upload);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            }
            
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
            ViewBag.careers = await userService.carreras();
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

        public IEnumerable<USERS> filtro(string word, IEnumerable<USERS> user)
        {
            ViewData["CurrentFilter"] = word;
            if (!String.IsNullOrEmpty(word))
            {
                word = word.ToLower();
                user = user.Where(x => x.name.ToLower().Contains(word) || x.lastName.ToLower().Contains(word));
                return user;
            }

            return user;
        }

        

        

    }
}
