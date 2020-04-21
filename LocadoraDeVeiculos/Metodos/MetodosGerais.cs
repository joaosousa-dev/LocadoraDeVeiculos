using LocadoraDeVeiculos.Dados;
using LocadoraDeVeiculos.Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Metodos
{
    public class MetodosGerais
    {
        Conexao banco = new Conexao();
        public Funcionario TestarUsuario(Funcionario funcionario)
        {
            var SelectLogin = string.Format("select * from Funcionario where usuario = '{0}' and senha = '{1}' and nivel_login='{2}' ", funcionario.Login, funcionario.Senha,funcionario.Nivel);
            MySqlDataReader leitor;
            leitor = banco.ExecultarConsulta(SelectLogin);
            if (leitor.HasRows)
            {
                Funcionario func = new Funcionario();
                while (leitor.Read())
                {

                    {
                        func.Login = Convert.ToString(leitor["usuario"]);
                        func.Senha = Convert.ToString(leitor["senha"]);
                        func.Nivel = Convert.ToString(leitor["nivel_login"]);
                    }

                }
                funcionario = func;
            }

            else
            {
                funcionario.Login = null;
                funcionario.Senha = null;
                funcionario.Nivel = null;
            }

            return funcionario;
        }
        public void CadastroCliente(Cliente cliente)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO Cliente(cpf_cliente,nome_cliente,email_cliente,data_nasc_cliente,cnh_cliente,sexo_cliente,logradouro,numero,CEP,cidade,uf,bairro,usuario,senha,nivel_login) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');", cliente.Cpf,cliente.Nome,cliente.Email,Convert.ToDateTime(cliente.DataNasc).ToString("yyyy/MM/dd hh:mm:ss"),cliente.Cnh,cliente.Sexo,cliente.Logradouro,cliente.Numero,cliente.CEP,cliente.Cidade,cliente.UF,cliente.Bairro,cliente.Login,cliente.Senha);
            banco.ExecutarComando(strQuery);

        }
    }
}