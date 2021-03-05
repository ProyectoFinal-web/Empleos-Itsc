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
            List<MAILBOX> mail = await mailboxServices.GetAll();
            return View(mail);
        }


        // Eliminar Objeto
        public async Task<ActionResult> ViewInfoDelete(int id)
        {
            MAILBOX mail = await mailboxServices.GetInfo(id);
            return View(mail);
        }

        public ActionResult Delete(int id)
        {
            var result = mailboxServices.Delete(id);
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }


    }
}
