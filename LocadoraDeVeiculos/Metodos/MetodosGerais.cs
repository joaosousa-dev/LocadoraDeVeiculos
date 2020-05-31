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
       
        public void CadastroFuncionario(Funcionario funcionario)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO Funcionario(nome_funcionario,data_nascimento,email_funcionario,cpf_funcionario,sexo_funcionario,usuario,senha,nivel_login) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", funcionario.Nome, Convert.ToDateTime(funcionario.DataNasc).ToString("yyyy/MM/dd hh:mm:ss"), funcionario.Email, funcionario.Cpf, funcionario.Sexo, funcionario.Login, funcionario.Senha,funcionario.Nivel) ;
            banco.ExecutarComando(strQuery);
        }
        public void AtualizarFuncionario(Funcionario funcionario)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE FUNCIONARIO SET ");
            strQuery += string.Format("nome_funcionario='{0}',", funcionario.Nome);
           // strQuery += string.Format("data_nascimento='{0}',", funcionario.DataNasc);
            strQuery += string.Format("email_funcionario='{0}',", funcionario.Email);
            strQuery += string.Format("cpf_funcionario='{0}',", funcionario.Cpf);
            strQuery += string.Format("sexo_funcionario='{0}',", funcionario.Sexo);
            strQuery += string.Format("usuario='{0}',", funcionario.Login);
            strQuery += string.Format("senha='{0}' ", funcionario.Senha);
            strQuery += string.Format("WHERE cod_funcionario={0}", funcionario.id);
            banco.ExecutarComando(strQuery);

        }
        public void AtualizarSenhaFuncionario(Funcionario funcionario)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE FUNCIONARIO SET ");
            strQuery += string.Format("senha='{0}' ", funcionario.Senha);
            strQuery += string.Format("WHERE cod_funcionario={0}", funcionario.id);
            banco.ExecutarComando(strQuery);

        }

        public void CadastroCliente(Cliente cliente)
        {
            var strQuery = "";
            strQuery = string.Format("INSERT INTO Cliente(cpf_cliente,nome_cliente,email_cliente,data_nasc_cliente,cnh_cliente,sexo_cliente,logradouro,numero,CEP,cidade,uf,bairro,usuario,senha,nivel_login) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',1);", cliente.Cpf,cliente.Nome,cliente.Email,Convert.ToDateTime(cliente.DataNasc).ToString("yyyy/MM/dd hh:mm:ss"),cliente.Cnh,cliente.Sexo,cliente.Logradouro,cliente.Numero,cliente.CEP,cliente.Cidade,cliente.UF,cliente.Bairro,cliente.Login,cliente.Senha);
            banco.ExecutarComando(strQuery);

        }
        public void AtualizarCliente(Cliente cliente)
        {
            var strQuery = "";
            strQuery += string.Format("UPDATE CLIENTE SET ");
            strQuery += string.Format("NOME_CLIENTE=UPPER('{0}'),", cliente.Nome);
            strQuery += string.Format("EMAIL_CLIENTE='{0}',", cliente.Email);
            strQuery += string.Format("CNH_CLIENTE='{0}',", cliente.Cnh);
            strQuery += string.Format("logradouro = '{0}',", cliente.Logradouro);
            strQuery += string.Format("NUMERO = '{0}',", cliente.Numero);
            strQuery += string.Format("BAIRRO = '{0}',", cliente.Bairro);
            strQuery += string.Format("CIDADE = '{0}',", cliente.Cidade);
            strQuery += string.Format("UF = '{0}',", cliente.UF);
            strQuery += string.Format("CEP = '{0}' ", cliente.CEP);
            strQuery += string.Format("WHERE cpf_cliente='{0}'", cliente.Cpf);
            banco.ExecutarComando(strQuery);
        }

        public List<Cliente> ListarCLI()
        {
            using (banco = new Conexao())
            {
                var strQuery = "SELECT * FROM CLIENTE;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCLI(retorno);
            };
        }
        public List<Cliente> ListaDeCLI(MySqlDataReader retorno)
        {
            var cliente = new List<Cliente>();
            while (retorno.Read())
            {
                var TempCliente = new Cliente()
                {

                    Nome = retorno["nome_cliente"].ToString(),
                    Sexo = retorno["sexo_cliente"].ToString(),
                    Login = retorno["usuario"].ToString(),
                    Email = retorno["email_cliente"].ToString(),
                    DataNasc = DateTime.Parse(retorno["data_nasc_cliente"].ToString()),
                    Cnh = retorno["cnh_cliente"].ToString(),
                    Cpf = retorno["cpf_cliente"].ToString(),
                    Logradouro = retorno["logradouro"].ToString(),
                    Numero = retorno["numero"].ToString(),
                    Bairro = retorno["bairro"].ToString(),
                    Cidade = retorno["cidade"].ToString(),
                    UF = retorno["UF"].ToString(),
                    CEP = retorno["cep"].ToString()
                };
                cliente.Add(TempCliente);
            }
            retorno.Close();
            return cliente;
        }
        public Cliente ListaIdCliente(string cpf)
        {
            using (banco = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM CLIENTE where cpf_cliente='{0}'", cpf);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeCLI(retorno).FirstOrDefault();
            }
        }

        public List<Funcionario> ListaDeFunc(MySqlDataReader retorno)
        {
            var funcionario = new List<Funcionario>();
            while (retorno.Read())
            {
                var TempFunc = new Funcionario()
                {
                    id = int.Parse(retorno["cod_funcionario"].ToString()),
                    Nome = retorno["nome_funcionario"].ToString(),
                    Sexo = retorno["sexo_funcionario"].ToString(),
                    Login = retorno["usuario"].ToString(),
                    Email = retorno["email_funcionario"].ToString(),
                    DataNasc = DateTime.Parse(retorno["data_nascimento"].ToString()),
                    Cpf = retorno["cpf_funcionario"].ToString(),
                    Nivel = retorno["nivel_login"].ToString()
                };
                funcionario.Add(TempFunc);
            }
            retorno.Close();
            return funcionario;
        }

        public List<Funcionario> ListarFunc()
        {
            using (banco = new Conexao())
            {
                var strQuery = "SELECT * FROM funcionario;";
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeFunc(retorno);
            };
        }

        public Funcionario ListaIdFuncionario(int id)
        {
            using (banco = new Conexao())
            {
                var strQuery = string.Format("SELECT * FROM Funcionario where cod_funcionario={0}", id);
                var retorno = banco.ExecultarConsulta(strQuery);
                return ListaDeFunc(retorno).FirstOrDefault();
            }
        }
        public void ApagarFunc(int id)
        {
            var strQuery = "";
            strQuery += string.Format("DELETE FROM Funcionario WHERE cod_funcionario={0}", id);
            banco.ExecutarComando(strQuery);
        }
    }
}