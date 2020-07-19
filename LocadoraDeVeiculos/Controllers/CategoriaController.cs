using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Lista()
        {
            var metodo = new MetodosGerais();
            var categoria = metodo.ListarCategoria();
            return View(categoria);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosGerais();
                metodo.CadastroCategoria(categoria);
                return RedirectToAction("Lista");
            }
            return View(categoria);
        }
        [HttpPost]

        public ActionResult Editar(Categoria categoria)
        {
            var metodo = new MetodosGerais();
            metodo.AtualizarCategoria(categoria);
            return RedirectToAction("Lista");
        }
        public ActionResult Editar(int Id)
        {
            var metodo = new MetodosGerais();
            var categoria = metodo.ListaIdCategoria(Id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
    }
}