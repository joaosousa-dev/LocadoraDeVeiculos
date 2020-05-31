using LocadoraDeVeiculos.Dados;
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
        public ActionResult Lista()
        {
            var metodo = new MetodosGerais();
            var func = metodo.ListarFunc();
            return View(func);
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

        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            var metodo = new MetodosGerais();
            metodo.AtualizarFuncionario(funcionario);
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(int Id)
        {
            var metodo = new MetodosGerais();
            var funcionario = metodo.ListaIdFuncionario(Id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        [HttpPost]
        public ActionResult NovaSenha(Funcionario funcionario)
        {
            var metodo = new MetodosGerais();
            metodo.AtualizarSenhaFuncionario(funcionario);
            return RedirectToAction("Lista");
        }

       public ActionResult NovaSenha(int Id)
        {
            var metodo = new MetodosGerais();
            var funcionario = metodo.ListaIdFuncionario(Id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
        public ActionResult Apagar(int id)
        {
            var metodo = new MetodosGerais();
            var funcionario=metodo.ListaIdFuncionario(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
         }
        [HttpPost]
        public ActionResult Apagar(Funcionario funcionario,int id)
        {
            var metodo = new MetodosGerais();
            metodo.ApagarFunc(id);
            return RedirectToAction("Lista");
        }
    }
}