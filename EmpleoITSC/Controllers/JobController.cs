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
        public async Task<IActionResult> Index()
        {
            List<JOB> empleo = await jobService.GetAll();
            return View(empleo);
        }

        // Crear Objecto
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JOB empleo)
        {
            var result = jobService.Create(empleo);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> ViewInfoEdit(int id)
        {
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
    }
}
