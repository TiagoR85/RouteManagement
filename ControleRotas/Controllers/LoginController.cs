using ControleRotas.Models;
using ControleRotas.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ControleRotas.Controllers
{
    [Route("login")]
    public class LoginController : ControllerBase<Funcionario>
    {
        private Funcionario funcionario;
        private IFuncionarioRepository funcionarioRepo;

        public LoginController(IFuncionarioRepository funcionarioRepository)
        {
            funcionarioRepo = funcionarioRepository;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            TempData["Title"] = "Login";
            return View();
        }

        [Route("login")]
        [ValidateAntiForgeryToken]
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
                    HttpContext.Session.SetString("UserLogged", funcionario.UserName);
                    return Redirect("/Home");
                }
                else
                {
                    TempData["Erro"] = "Usuário ou senha incorretos";
                    return RedirectToAction("index");
                }
            }
            catch (Exception)
            {
                TempData["Erro"] = "Usuário ou senha incorretos";
                return RedirectToAction("index");
            }

        }
    }
}