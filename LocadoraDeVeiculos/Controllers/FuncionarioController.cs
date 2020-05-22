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
        public ActionResult Index()
        {
                return View();
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosGerais();
                metodo.CadastroFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }
        
    }
}