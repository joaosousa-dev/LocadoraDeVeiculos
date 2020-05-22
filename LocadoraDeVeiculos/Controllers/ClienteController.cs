using LocadoraDeVeiculos.Dados;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Lista()
        {
            var metodo = new MetodosGerais();
            var clientes=metodo.ListarCLI();
            return View(clientes);
        }
        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            var metodo = new MetodosGerais();
            metodo.AtualizarCliente(cliente);
            return RedirectToAction("Lista");
        }

        public ActionResult Editar(string cpf)
        {
                var banco = new Conexao();
                var metodo = new MetodosGerais();
                var cliente = metodo.ListaIdCliente(cpf);
                if (cliente == null)
                {
                    return HttpNotFound();
                }
                return View(cliente);
        }
    }
}