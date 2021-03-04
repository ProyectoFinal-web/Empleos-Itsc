using EmpleoITSC.Models;
using EmpleoITSC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();
        // Listar Objectos
        public async Task<IActionResult> Index()
        {
            List<USERS> user = await userService.GetAll();
            return View(user);
        }

        // Crear Objecto
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(USERS user)
        {
            var result = userService.Create(user);
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
        public async Task<ActionResult> ViewInfoDelete(int id)
        {
            USERS user = await userService.GetInfo(id);
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var result = userService.Delete(id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

    }
}
