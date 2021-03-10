using EmpleoITSC.Models;
using EmpleoITSC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Controllers
{
    public class JobController : Controller
    {
        JobService jobService = new JobService();
        Pagination pagination = new Pagination();
        public async Task<IActionResult> Index(string word, int pagina =1)
        {
            List<JOB> empleo = await jobService.GetAll();
            var search = filtro(word, empleo);
            var usuarios = search.OrderBy(x => x.title)
                    .Skip((pagina - 1) * pagination.cantidadRegistrosPorPagina)
                    .Take(pagination.cantidadRegistrosPorPagina).ToList();

            var totalDeRegistros = search.Count();
            var modelo = new IndexViewModel();
            modelo.Jobs = usuarios;
            modelo.PaginaActual = pagina;
            modelo.TotalDeRegistros = totalDeRegistros;
            modelo.RegistrosPorPagina = pagination.cantidadRegistrosPorPagina;

            return View(modelo);
        }

        // Detalle
        public async Task<IActionResult> Detail(int id)
        {
           var empleo = await jobService.GetInfo(id);

            return View(empleo);
        }

        // Crear Objecto
        public async Task<IActionResult> Create()
        {
            ViewBag.careers = await jobService.carreras();
            return View();
        }

        [HttpPost]
        public IActionResult Create(JOB empleo)
        {
            if (ModelState.IsValid)
            {
                empleo.title = pagination.cadenaM(empleo.title);
                var result = jobService.Create(empleo);
                if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            }
            
            return View();
        }

        public async Task<IActionResult> ViewInfoEdit(int id)
        {
            ViewBag.careers = await jobService.carreras();
            JOB empleo = await jobService.GetInfo(id);
            return View(empleo);
        }

        public ActionResult Edit(JOB empleo)
        {
            var result = jobService.Update(empleo);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");

            return View();
        }

        // Eliminar Objeto
        public async Task<ActionResult> ViewInfoDelete(int id)
        {
            JOB empleo = await jobService.GetInfo(id);
            return View(empleo);
        }

        public ActionResult Delete(int id)
        {
            var result = jobService.Delete(id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        // Filtro
        public IEnumerable<JOB> filtro(string word, IEnumerable<JOB> user)
        {
            ViewData["CurrentFilter"] = word;
            if (!String.IsNullOrEmpty(word))
            {
                word = word.ToLower();
                user = user.Where(x => x.title.ToLower().Contains(word));
                return user;
            }

            return user;
        }
    }
}
