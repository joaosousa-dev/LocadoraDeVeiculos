using LocadoraDeVeiculos.Dados;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

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
        public ActionResult Index(Login login)
        {
            login = metodo.TestarUsuario(login);
            if (login.Usuario != null && login.Senha != null && login.Nivel != null)
            {
                FormsAuthentication.SetAuthCookie(login.Usuario, false);
                Session["usuarioLogado"] = login.Usuario.ToString();
                Session["senhaLogado"] = login.Senha.ToString();
                Session["nivel"] = login.Nivel.ToString();


                if (login.Nivel == "1")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Funcionario");
                }
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
        public ActionResult Lista()
        {
            var metodo = new MetodosGerais();
            var veiculo = metodo.ListarVeiculo();
            return View(veiculo);
        }

    }
}