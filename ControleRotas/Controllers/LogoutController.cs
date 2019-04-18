using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleRotas.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Logout"] = "Você saiu";
            return View();
        }
    }
}