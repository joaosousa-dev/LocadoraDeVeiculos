using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [RegularExpression(@"[+-]?\d+(\,\d+)?", ErrorMessage = "Preencha conforme Ex:10,50")]
        public string Valor { get; set; }
    }
}