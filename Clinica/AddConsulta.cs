using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaDentaria2
{
    class AddConsulta
    {
        public void ConsultaAdd(string query)
        {
            //criando metodo para adicionar consultas.
            ConnectionString Conexao = new ConnectionString();
            SqlConnection Con = Conexao.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            Con.Close();
            
        }
    }
}
