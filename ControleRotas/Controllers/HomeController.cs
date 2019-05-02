using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ControleRotas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Pessoa> pessoaRepository;
        private readonly IRepository<Email> emailRepository;
        private readonly IRepository<Endereco> enderecoRepository;

        public HomeController(IRepository<Pessoa> pessoaRepository,
                              IRepository<Email> emailRepository,
                              IRepository<Endereco> enderecoRepository)
        {
            this.pessoaRepository = pessoaRepository;
            this.emailRepository = emailRepository;
            this.enderecoRepository = enderecoRepository;
        }
        public IActionResult Index()
        {
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
