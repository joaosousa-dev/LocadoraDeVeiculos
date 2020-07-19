using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Manutencao
    {
        public int Id { get; set; }
        [DisplayName("Veiculo")]
        public int IdVeiculo { get; set; }
        [DisplayName("Modelo do veiculo")]
        public string ModeloVeiculo { get; set; }
        [DisplayName("Placa do veiculo")]
        public string PlacaVeiculo { get; set; }
        [DisplayName("Chassi do veiculo")]
        public string ChassiVeiculo { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Descrição da manutenção")]
        public string Descricao { get; set; }


    }
}