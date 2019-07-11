using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using ControleRotas.ViewModels;

namespace ControleRotas.Controllers
{
    [Route("Home")]
    public class HomeController : ControllerBase<Funcionario>
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IFuncionarioRepository funcionarioRepository;
        private IViewModel homeViewModel;

        public HomeController(IPessoaRepository pessoaRepository, IFuncionarioRepository funcionarioRepository)
        {
            homeViewModel = new ViewModel();
            homeViewModel.ControllerName = "Home";
            homeViewModel.TitleBox = "DashBoard";
            this.pessoaRepository = pessoaRepository;
            this.funcionarioRepository = funcionarioRepository;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            var funcionarioContext = GetObjectFromSession("UserLogged") as Funcionario;
            if (funcionarioContext != null)
            {
                var funcionario = funcionarioRepository.GetById(funcionarioContext.FuncionarioId);
                homeViewModel.Model = funcionario;
                return View(homeViewModel);
            }
            else
            {
                return Redirect("/Login");
            }
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            ViewBag.breadcrumbs = "Contact";

            return View();
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
