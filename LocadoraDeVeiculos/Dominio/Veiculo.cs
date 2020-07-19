using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Veiculo
    {
        public int id { get; set; }

        [DisplayName("Categoria")]
        public int idCategoria { get; set; }

        [DisplayName("Categoria do veiculo")]
        public string categoria { get; set; }

        [DisplayName("Marca do veiculo")]
        public string marca { get; set; }

        [DisplayName("Marca")]
        public int idMarca { get; set; }

        [DisplayName("Modelo")]
        public string modelo { get; set; }

        [DisplayName("Placa do veiculo")]
        public string placa { get; set; }
        [DisplayName("Chassi do veiculo")]
        [RegularExpression(@"[a-zA-Z0-9]{17}", ErrorMessage = "Chassi é composto por 17 caractéres")]
        public string chassi { get; set; }
        [DisplayName("Status do veiculo")]

        public string status { get; set; }

        [DisplayName("Foto do veiculo")]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Imagem é obrigatória")]
        public string imagem { get; set; }
    }
}