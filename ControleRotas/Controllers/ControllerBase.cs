using ControleRotas.Exceptions;
using ControleRotas.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleRotas.Controllers
{
    public class ControllerBase<T> : Controller where T : class
    {
        protected void AddObjectInSession(string key, object value)
        {
            if (HttpContext.Session == null)
                return;

            Utils.SetObjectAsJson(HttpContext.Session, key, value);
        }

        protected object GetObjectFromSession(string key)
        {
            var ret = Utils.GetObjectFromJson<T>(HttpContext.Session, key);

            if (ret == null)
                throw new ExceptionApp("É possível que sua sessão tenha expirado, efetue login e repita esta operação.");

            return ret;
        }
    }
}