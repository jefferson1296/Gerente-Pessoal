using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrightIdeasSoftware.TreeListView;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace GerenciamentoPessoal
{
    class Conexao
    {
        SqlConnection conexao = new SqlConnection();

        public Conexao()
        {
            string servidor_online = "Server=tcp:jefferson-franca.database.windows.net,1433;Initial Catalog=bd_Gerente;Persist Security Info=False;User ID=jeffersonfranca;Password=121296#Je;Connection Timeout=15;";
            string servidor_local = @"Data Source=DESKTOP-C4A0FDU\SQLEXPRESS;Initial Catalog=bd_Gerente;Integrated Security=True";

            conexao.ConnectionString = servidor_local;
        }

        public SqlConnection Conectar()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }
            return conexao;
        }
        public void Desconectar()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}
