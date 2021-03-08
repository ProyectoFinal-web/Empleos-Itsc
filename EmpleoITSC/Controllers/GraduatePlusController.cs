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
    public class GraduatePlusController : Controller
    {
        GraduateService graduateService = new GraduateService();

        // Listar Objectos
        public async Task<IActionResult> Index()
        {
            List<GRADUATEPLUS> graduates = await graduateService.GetAll();
            return View(graduates);
        }

        // Mostrar Info de Objeto por ID
        public async Task<IActionResult> Details(int id)
        {
            GRADUATEPLUS student = await graduateService.GetInfo(id);
            return View(student);
        }

        // Crear Objecto
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GRADUATEPLUS student, IFormFile upload)
        {
            var result = graduateService.Create(student, upload);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        // Editar Objecto
        public async Task<IActionResult> ViewInfoEdit(int id)
        {
            GRADUATEPLUS student = await graduateService.GetInfo(id);
            return View(student);
        }
        
        public ActionResult Edit(GRADUATEPLUS student)
        {
            var result = graduateService.Update(student);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            
            return View();
        }

        // Eliminar Objeto
        public async Task<ActionResult> ViewInfoDelete(int id)
        {
            GRADUATEPLUS student = await graduateService.GetInfo(id);
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            var result = graduateService.Delete(id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<ActionResult> convertirImagen(int codigo)
        {
            GRADUATEPLUS student = await graduateService.GetInfo(codigo);

            return File(student.photo, "Imagenes/jpg");

        }

    }

}
