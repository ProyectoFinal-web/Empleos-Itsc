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
            List<USERS> graduates = await userService.GetAll();
            return View(graduates);
        }
    }
}
