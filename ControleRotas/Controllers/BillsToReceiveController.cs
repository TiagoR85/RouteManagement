using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControleRotas.Controllers
{
    public class BillsToReceiveController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.breadcrumbs = "Contas à Receber";
            return View();
        }
    }
}