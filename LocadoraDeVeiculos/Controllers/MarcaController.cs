using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Lista()
        {
            var metodo = new MetodosGerais();
            var marca = metodo.ListarMarca();
            return View(marca);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Marca marca)
        {
            if (ModelState.IsValid)
            {
                var metodo = new MetodosGerais();
                metodo.CadastroMarca(marca);
                return RedirectToAction("Lista");
            }
            return View(marca);
        }
        [HttpPost]

        public ActionResult Editar(Marca marca)
        {
            var metodo = new MetodosGerais();
            metodo.AtualizarMarca(marca);
            return RedirectToAction("Lista");
        }
        public ActionResult Editar(int Id)
        {
            var metodo = new MetodosGerais();
            var marca = metodo.ListaIdMarca(Id);
            if (marca == null)
            {
                return HttpNotFound();
            }
            return View(marca);
        }
    }
}