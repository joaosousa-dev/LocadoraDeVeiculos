using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dominio
{
    public class Cliente
    {
        [Required(ErrorMessage = "CPF é obrigatório")]
        [DisplayName("CPF")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", ErrorMessage = "CPF 11 Dígitos")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [RegularExpression(@"[a-z A-Z]{3,50}", ErrorMessage = "Apenas letras, mínimo 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O E-Mail é obrigatório")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "A Data de nascimento é obrigatória")]
        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNasc { get; set; }
        [RegularExpression(@"[1-9]{11}", ErrorMessage = "Preencha completo")]
        [DisplayName("CNH")]
        [Required(ErrorMessage = "A CNH é obrigatória")]
        public string Cnh { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }
        
        [Required(ErrorMessage = "O Nº é obrigatório")]
        [DisplayName("Nº")]

        public string Numero { get; set; }
        [Required(ErrorMessage = "O CEP é obrigatório")]
        [DisplayName("CEP")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "A Cidade é obrigatória")]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "A UF é obrigatória")]
        [DisplayName("UF")]
        public string UF { get; set; }
        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [DisplayName("Bairro")]
        public string Bairro { get; set; }
        [DisplayName("Usuário")]
        [RegularExpression(@"[a-zA-Z0-9]{3,50}", ErrorMessage = "Mínimo 3 caractéres, Não permitido caractéres especiais")]
        public string Login { get; set; }
        [DisplayName("Senha")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Compare("Senha", ErrorMessage = "As senhas são diferentes")]
        [DataType(DataType.Password)]
        [DisplayName("Confirmar senha")]
        public string ConfirmarSenha { get; set; }
        








    }
}