using EmpleoITSC.Models;
using EmpleoITSC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Controllers
{
    public class MailBoxController : Controller
    {
        MailBoxService mailboxServices = new MailBoxService();

        // Listar Objectos
        public async Task<IActionResult> Index()
        {
            var all = await mailboxServices.GetAll();
            return View(all.ToList());
        }

        // Crear Objecto
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MAILBOX user)
        {
            var result = await mailboxServices.Create(user);
            if (result.IsSuccessStatusCode) return RedirectToAction("Index");

            return View();
        }

        // Eliminar Objeto
        //public async Task<ActionResult> ViewInfoDelete(int id)
        //{
        //    MAILBOX mail = await mailboxServices.GetInfo(id);
        //    return View(mail);
        //}

        public ActionResult Delete(int id)
        {
            var result = mailboxServices.Delete(id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
