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
    public class ManutencaoController : Controller
    {
        Conexao banco = new Conexao();

        // GET: Manutencao
        public ActionResult Index()
        {
            var metodo = new MetodosGerais();
            var manutencao = metodo.ListarManutencao();
            return View(manutencao);
        }
        public ActionResult Cadastro()
        {
            List<SelectListItem> veiculo = new List<SelectListItem>();

            var cmd = string.Format("select * from veiculo where status_veiculo='Disponivel'");
            var rdr = banco.ExecultarConsulta(cmd);

            while (rdr.Read())
            {
                veiculo.Add(new SelectListItem
                {
                    Value = rdr[0].ToString(),
                    Text = rdr[5].ToString() + " (" + rdr[3].ToString() + ")"

                });
            }

            ViewBag.veiculos = new SelectList(veiculo, "Value", "Text");
            rdr.Close();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Manutencao manutencao)
        {
          
           
            if (ModelState.IsValid)
            {
                var metodo = new MetodosGerais();
                metodo.CadastroManutencao(manutencao);
                return RedirectToAction("Index");
            }
            return View(manutencao);
        }
        public ActionResult Baixar(int id)
        {
            var metodo = new MetodosGerais();
            metodo.BaixarManutencao(id);
            return RedirectToAction("Index");
        }
    }

}