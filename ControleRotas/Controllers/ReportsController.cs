using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleRotas.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.breadcrumbs = "Relatórios";
            return View();
        }

        public IActionResult Drivers()
        {
            ViewBag.breadcrumbs = "Relatórios";
            return View();
        }

        public IActionResult Vehicles()
        {
            ViewBag.breadcrumbs = "Relatórios";
            return View();
        }

        public IActionResult Services()
        {
            ViewBag.breadcrumbs = "Relatórios";
            return View();
        }

        public IActionResult Reports()
        {
            ViewBag.breadcrumbs = "Relatórios";
            return View();
        }
    }
}