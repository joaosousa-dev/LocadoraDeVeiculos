using LocadoraDeVeiculos.Dados;
using LocadoraDeVeiculos.Dominio;
using LocadoraDeVeiculos.Metodos;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class VeiculoController : Controller
    {
        Conexao banco = new Conexao();
        // GET: Veiculo
        public ActionResult Cadastro()
        {
            List<SelectListItem> categoria = new List<SelectListItem>();

            var cmd = string.Format("select * from Categoria");
            var rdr = banco.ExecultarConsulta(cmd);

            while (rdr.Read())
            {
                categoria.Add(new SelectListItem
                {
                    Value = rdr[0].ToString(),
                    Text = rdr[1].ToString()

                });
            }

            ViewBag.categorias = new SelectList(categoria, "Value", "Text");
            rdr.Close();

            List<SelectListItem> marca = new List<SelectListItem>();

            cmd = string.Format("select * from marca");
            rdr = banco.ExecultarConsulta(cmd);

            while (rdr.Read())
            {
                marca.Add(new SelectListItem
                {
                    Value = rdr[0].ToString(),
                    Text = rdr[1].ToString()

                });
            }
            ViewBag.marcas = new SelectList(marca, "Value", "Text");
            rdr.Close();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(HttpPostedFileBase file, Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Imagens"), _FileName);
                    file.SaveAs(_path);
                    var imagepath = "~/Imagens/" + _FileName;
                    veiculo.imagem = imagepath;
                    var metodo = new MetodosGerais();
                    metodo.CadastroVeiculo(veiculo);
                }
                return RedirectToAction("Lista");
            }
            return View(veiculo);
        }
        
        public ActionResult Lista()
        {
            var metodo = new MetodosGerais();
            var veiculo = metodo.ListarVeiculo();
            return View(veiculo);
        }
        public ActionResult Editar()
        {
            List<SelectListItem> categoria = new List<SelectListItem>();

            var cmd = string.Format("select * from Categoria");
            var rdr = banco.ExecultarConsulta(cmd);

            while (rdr.Read())
            {
                categoria.Add(new SelectListItem
                {
                    Value = rdr[0].ToString(),
                    Text = rdr[1].ToString()

                });
            }

            ViewBag.categorias = new SelectList(categoria, "Value", "Text");
            rdr.Close();

            List<SelectListItem> marca = new List<SelectListItem>();

            cmd = string.Format("select * from marca");
            rdr = banco.ExecultarConsulta(cmd);

            while (rdr.Read())
            {
                marca.Add(new SelectListItem
                {
                    Value = rdr[0].ToString(),
                    Text = rdr[1].ToString()

                });
            }
            ViewBag.marcas = new SelectList(marca, "Value", "Text");
            rdr.Close();
            return View();
        }
    }
}

