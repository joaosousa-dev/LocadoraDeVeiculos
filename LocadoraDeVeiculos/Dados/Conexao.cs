using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Dados
{
    public class Conexao :IDisposable
    {
        private MySqlConnection con; 
        public Conexao()
        {
            con=new MySqlConnection("Server=localhost; DataBase=LocadoraSeven; User=root;pwd=1234567");
            con.Open();        
        }

        public void ExecutarComando(string strQuery)
        {
           MySqlCommand cmd = new MySqlCommand(strQuery, con);
            cmd.ExecuteNonQuery();
        }
        public MySqlDataReader ExecultarConsulta(string strQuery)
        {

            MySqlCommand cmd = new MySqlCommand(strQuery, con);
            return cmd.ExecuteReader();
            con.Close();
        }

        public void Dispose()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }

    }
}