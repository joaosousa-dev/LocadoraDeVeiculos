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
        public Login TestarUsuario(Login login)
        {
            var SelectLogin = string.Format("select * from login where usuario = '{0}' and senha = '{1}' ", login.Usuario, login.Senha);
            MySqlDataReader leitor;
            leitor = banco.ExecultarConsulta(SelectLogin);
            if (leitor.HasRows)
            {
                Login log = new Login();
                while (leitor.Read())
                {

                    {
                        log.Usuario = Convert.ToString(leitor["usuario"]);
                        log.Senha = Convert.ToString(leitor["senha"]);
                        log.Nivel = Convert.ToString(leitor["nivel"]);
                    }

                }
                login = log;
            }

            else
            {
               login.Usuario = null;
               login.Senha = null;
               login.Nivel = null;
            }

            return login;
        }
        public void CadastroCliente(Cliente cliente)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO Cliente(cpf_cliente,nome_cliente,email_cliente,data_nasc_cliente,cnh_cliente,sexo_cliente,logradouro,numero,CEP,cidade,uf,bairro,usuario,senha,nivel_login) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',1);", cliente.Cpf,cliente.Nome,cliente.Email,Convert.ToDateTime(cliente.DataNasc).ToString("yyyy/MM/dd hh:mm:ss"),cliente.Cnh,cliente.Sexo,cliente.Logradouro,cliente.Numero,cliente.CEP,cliente.Cidade,cliente.UF,cliente.Bairro,cliente.Login,cliente.Senha);
            banco.ExecutarComando(strQuery);

        }
    }
}