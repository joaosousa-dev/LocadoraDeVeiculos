using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Funcionario
    {
        public int id { get; set; }
        [RegularExpression(@"[a-zA-Z0-9]{3,15}", ErrorMessage = "Apenas letras e números mínimo 3 caracteres")]
        [DisplayName("Login")]
        public string Login { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Data de nascimento")]
        public DateTime DataNasc{ get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Sexo { get; set; }
      
        
        [RegularExpression(@"[a-z A-Z]{3,50}", ErrorMessage = "Apenas letras para nomes,mínimo 3 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        
        [DisplayName("Senha")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        [Compare("Senha", ErrorMessage = "As senhas são diferentes")]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar senha")]
        public string ConfirmarSenha { get; set; }
        
        
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        
        [DisplayName("Nivel de acesso")]
        public string Nivel { get; set; }
    }
}