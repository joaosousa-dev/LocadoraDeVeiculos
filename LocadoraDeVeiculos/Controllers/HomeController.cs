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
    public class HomeController : Controller
    {
        MetodosGerais metodo = new MetodosGerais();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Funcionario funcionario)
        {

            funcionario = metodo.TestarUsuario(funcionario);


            if (funcionario.Login != null && funcionario.Senha != null && funcionario.Nivel !=null)
            {
                FormsAuthentication.SetAuthCookie(funcionario.Login, false);
                Session["usuarioLogado"] = funcionario.Login.ToString();
                Session["senhaLogado"] = funcionario.Senha.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Session["usuarioNegado"] = "NEGADO";
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null; // destruindo a sessão.
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosGerais();
                metodo.CadastroCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

    }
}