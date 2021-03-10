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
        Pagination pagination = new Pagination();

        // Listar Objectos
        public async Task<IActionResult> Index(string word, int pagina = 1)
        {
            List<GRADUATEPLUS> graduates = await graduateService.GetAll();
            var search = filtro(word, graduates);
            var usuarios = search.OrderBy(x => x.name)
                    .Skip((pagina - 1) * pagination.cantidadRegistrosPorPagina)
                    .Take(pagination.cantidadRegistrosPorPagina).ToList();

            var totalDeRegistros = search.Count();
            var modelo = new IndexViewModel();
            modelo.GradutePlus = usuarios;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = pagination.cantidadRegistrosPorPagina;

            return View(modelo);
        }

        // Mostrar Info de Objeto por ID
        //public async Task<IActionResult> Details(int id)
        //{
        //    GRADUATEPLUS student = await graduateService.GetInfo(id);
        //    return View(student);
        //}

        // Crear Objecto
        public async Task<IActionResult> Create()
        {
            ViewBag.careers = await graduateService.carreras();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GRADUATEPLUS student, IFormFile upload)
        {
            
            ViewBag.careers = await graduateService.carreras();
            student.name = pagination.cadenaM(student.name);
            var result = graduateService.Create(student, upload);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            
            
            return View();
        }

        // Editar Objecto
        public async Task<IActionResult> ViewInfoEdit(int id)
        {
            ViewBag.careers = await graduateService.carreras();
            GRADUATEPLUS student = await graduateService.GetInfo(id);
            return View(student);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(GRADUATEPLUS estudiante, IFormFile upload)
        {

            GRADUATEPLUS estudiante2 = await graduateService.GetInfo(estudiante.gradId);
            GRADUATEPLUS student = new GRADUATEPLUS();
            student.gradId = estudiante.gradId;
            student.name = estudiante.name;
            student.descriptionGrad = estudiante.descriptionGrad;
            student.career = estudiante.career;
            student.photo = estudiante2.photo;
            var result = graduateService.Update(student, upload);
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

        // Filtro
        public IEnumerable<GRADUATEPLUS> filtro(string word, IEnumerable<GRADUATEPLUS> user)
        {
            ViewData["CurrentFilter"] = word;
            if (!String.IsNullOrEmpty(word))
            {
                word = word.ToLower();
                user = user.Where(x => x.name.ToLower().Contains(word));
                return user;
            }

            return user;
        }

    }

}
