using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}