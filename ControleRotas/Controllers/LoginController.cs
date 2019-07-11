using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using ControleRotas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ControleRotas.Controllers
{
    [Route("login")]
    public class LoginController : ControllerBase<Funcionario>
    {
        private IViewModel viewModel;
        private IFuncionarioRepository funcionarioRepo;
        private Funcionario funcionario;

        public LoginController(IFuncionarioRepository funcionarioRepository)
        {
            viewModel = new ViewModel();
            viewModel.Model = new Funcionario();
            viewModel.ControllerName = "Login";
            viewModel.ActionName = "Login";
            viewModel.TitleBox = "Entrar - Routes Controller";
            funcionarioRepo = funcionarioRepository;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View(viewModel);
        }

        
        [ValidateAntiForgeryToken]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                funcionario = funcionarioRepo.Find(f => f.UserName == username).First();
                if (funcionario != null &&
                    username != null && password != null
                    && username == funcionario.UserName && password == funcionario.Senha)
                {
                    AddObjectInSession("UserLogged", funcionario);
                    return Redirect("/Home");
                }
                else
                {
                    TempData["Erro"] = "Usuário ou senha incorretos";
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = "Usuário ou senha incorretos";
                return RedirectToAction("index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            if (GetObjectFromSession("UserLogged") != null)
            {
                HttpContext.Session.Remove("UserLogged");
            }
            return Redirect("/Login");
        }
    }
}