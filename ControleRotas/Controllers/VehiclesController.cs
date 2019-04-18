using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleRotas.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.breadcrumbs = "Veículos";
            return View();
        }
    }
}