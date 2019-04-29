using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;

namespace ControleRotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPessoaRepository Repository;

        public HomeController(IPessoaRepository pessoaRepository)
        {
            Repository = pessoaRepository;
        }
        public IActionResult Index()
        {
            var ret = Repository.GetAll();
            ViewData["Title"] = "Index";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewBag.breadcrumbs = "Contact";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
