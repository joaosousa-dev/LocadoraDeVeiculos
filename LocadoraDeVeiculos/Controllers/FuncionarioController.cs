using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LocadoraDeVeiculos.Controllers
{
    public class FuncionarioController : Controller
    {
        MetodosGerais metodo = new MetodosGerais();
        public ActionResult Entrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Entrar(Funcionario funcionario)
        {

            funcionario = metodo.TestarUsuario(funcionario);


            if (funcionario.Login != null && funcionario.Senha != null)
            {
                FormsAuthentication.SetAuthCookie(funcionario.Login, false);
                Session["usuarioLogado"] = funcionario.Login.ToString();
                Session["senhaLogado"] = funcionario.Senha.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["usuarioNegado"] = "NEGADO";
                return RedirectToAction("Entrar", "Funcionario");
            }
        }
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null; // destruindo a sessão.
            return RedirectToAction("Entrar", "Funcionario");
        }
    }
}