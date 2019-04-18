using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleRotas.Controllers
{
    public class DriversController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.breadcrumbs = "Motoristas";
            return View();
        }
    }
}