using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Login
    {
        public string Usuario { get; set; }
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string Nivel { get; set; }
    }
}