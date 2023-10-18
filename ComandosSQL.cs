using Microsoft.Reporting.WinForms;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    class ComandosSQL
    {
        Conexao conexao = new Conexao();

        #region Métodos genéricos
        public string PrimeiraLetraMaiuscula(string inserir)
        {
            if (string.IsNullOrEmpty(inserir))
                throw new ArgumentException("Insira uma palavra");
            return inserir.Length > 1 ? char.ToUpper(inserir[0]) + inserir.Substring(1) : inserir.ToUpper();
        }

        public string TurnoDoDia()
        {
            string cumprimento = string.Empty;
            DateTime agora = DateTime.Now;
            DateTime manha = Convert.ToDateTime("00:00");
            DateTime tarde = Convert.ToDateTime("12:00");
            DateTime noite = Convert.ToDateTime("18:00");
            DateTime fim_da_noite = Convert.ToDateTime("23:59");

            if (agora >= manha && agora < tarde)
            {
                cumprimento = "Bom dia";
            }
            else if (agora >= tarde && agora < noite)
            {
                cumprimento = "Boa tarde";
            }
            else if (agora >= noite && agora <= fim_da_noite)
            {
                cumprimento = "Boa noite";
            }
            return cumprimento;
        }

        public int ConverterMesPorExtensoEmInt(string Mes)
        {
            int mes = DateTime.ParseExact(Mes, "MMMM", CultureInfo.CurrentCulture).Month;
            return mes;
        }

        public string ConverterMesIntParaExtenso(int mes)
        {
            DateTime data = new DateTime(DateTime.Now.Year, mes, 1);
            string mes_ = data.ToString(@"MMMM");
            return mes_;
        }

        public decimal ConverterDinheiroEmDecimal(string dinheiro)
        {
            decimal valor;

            try
            {
                string[] partir = dinheiro.Split('$');
                valor = Convert.ToDecimal(partir[1]);

                if (partir[0] != "R")
                {
                    valor = -valor;
                }
            }
            catch { valor = 0; }

            return valor;
        }

        public string ConverterDecimalEmDinheiro(decimal valor)
        {
            string dinheiro;
            try { dinheiro = valor.ToString("C"); }
            catch { dinheiro = "R$0,00"; }

            return dinheiro;
        }

        public string ConverterDataParaDiaDaSemana(DateTime data)
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            string dia_da_semana = formato.GetDayName(data.DayOfWeek).PrimeiraLetraMaiuscula();
            return dia_da_semana;
        }
        #endregion

        #region Exemplos CRUD

        public class Exemplo { public int ID { get; set; } public string Descricao { get; set; } }

        public void Cadastrar(Exemplo e)
        {
            string comando = "";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id", e.ID);
                insert.Parameters.AddWithValue("@descricao", e.Descricao);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void Editar(Exemplo e)
        {
            string comando = "";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", e.ID);
                update.Parameters.AddWithValue("@descricao", e.Descricao);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void Apagar(int id)
        {
            string comando = "";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Excluído.", "Excluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Exemplo TrazerExemplo(int id)
        {
            Exemplo exemplo = new Exemplo();

            string comando = "";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {

                    }
                }
            }

            conexao.Desconectar();

            return exemplo;
        }

        public List<Exemplo> TrazerExemplos()
        {
            List<Exemplo> exemplos = new List<Exemplo>();

            string comando = "";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        exemplos.Add(new Exemplo
                        {

                        });
                    }
                }
            }

            return exemplos;
        }


        #endregion

        #region Tela inicial

        public void CadastrarParametro(Parametro Parametro)
        {
            string comando;

            if (Parametro.Tipo == "Decimal")
            {
                comando = "INSERT INTO tbl_Parametros (Nome_Parametro, Valor_Parametro) VALUES (@parametro, @valor)";
                decimal valor = Convert.ToDecimal(Parametro.Valor);

                using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@valor", valor);
                    insert.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    insert.ExecuteNonQuery();
                }
            }
            else if (Parametro.Tipo == "Texto")
            {
                comando = "INSERT INTO tbl_ParametrosTexto (Nome_Parametro, Valor_Parametro) VALUES (@parametro, @valor)";

                using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@valor", Parametro.Valor);
                    insert.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    insert.ExecuteNonQuery();
                }
            }
            else if (Parametro.Tipo == "Booleano")
            {
                comando = "INSERT INTO tbl_ParametrosBooleanos (Nome_Parametro, Valor_Parametro) VALUES (@parametro, @valor)";
                bool valor = Convert.ToBoolean(Convert.ToInt32(Parametro.Valor));

                using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@valor", valor);
                    insert.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    insert.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();

            MessageBox.Show("Parâmetro cadastrado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ApagarParametro(Parametro Parametro)
        {
            string comando;

            if (Parametro.Tipo == "Decimal")
            {
                comando = "DELETE FROM tbl_Parametros WHERE Nome_Parametro = @parametro";

                using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
                {
                    delete.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    delete.ExecuteNonQuery();
                }
            }
            else if (Parametro.Tipo == "Texto")
            {
                comando = "DELETE FROM tbl_ParametrosTexto WHERE Nome_Parametro = @parametro";

                using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
                {
                    delete.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    delete.ExecuteNonQuery();
                }
            }
            else if (Parametro.Tipo == "Booleano")
            {
                comando = "DELETE FROM tbl_ParametrosBooleanos WHERE Nome_Parametro = @parametro";

                using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
                {
                    delete.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    delete.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();

            MessageBox.Show("Parâmetro apagado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EditarParametro(Parametro Parametro)
        {
            string comando;

            if (Parametro.Tipo == "Decimal")
            {
                comando = "UPDATE tbl_Parametros SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro";
                decimal valor = Convert.ToDecimal(Parametro.Valor);

                using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@valor", valor);
                    update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    update.ExecuteNonQuery();
                }
            }
            else if (Parametro.Tipo == "Texto")
            {
                comando = "UPDATE tbl_ParametrosTexto SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro";

                using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@valor", Parametro.Valor);
                    update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    update.ExecuteNonQuery();
                }
            }
            else if (Parametro.Tipo == "Booleano")
            {
                comando = "UPDATE tbl_ParametrosBooleanos SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro";
                bool valor = Convert.ToBoolean(Parametro.Valor);

                using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@valor", valor);
                    update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                    update.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();
        }

        public void EditarParametros(List<Parametro> Parametros)
        {
            foreach (Parametro Parametro in Parametros)
            {
                if (Parametro.Edicao)
                {
                    string comando = string.Empty;

                    if (Parametro.Tipo == "Decimal")
                    {
                        comando = "UPDATE tbl_Parametros SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro";
                        decimal valor = Convert.ToDecimal(Parametro.Valor);

                        using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                        {
                            update.Parameters.AddWithValue("@valor", valor);
                            update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                            update.ExecuteNonQuery();
                        }
                    }
                    else if (Parametro.Tipo == "Texto")
                    {
                        comando = "UPDATE tbl_ParametrosTexto SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro";

                        using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                        {
                            update.Parameters.AddWithValue("@valor", Parametro.Valor);
                            update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                            update.ExecuteNonQuery();
                        }
                    }
                    else if (Parametro.Tipo == "Booleano")
                    {
                        comando = "UPDATE tbl_ParametrosBooleanos SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro";
                        bool valor = Convert.ToBoolean(Parametro.Valor);

                        using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                        {
                            update.Parameters.AddWithValue("@valor", valor);
                            update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                            update.ExecuteNonQuery();
                        }
                    }
                }
            }

            conexao.Desconectar();
        }

        public void EditarParametrosDoUsuario(List<Parametro> Parametros)
        {
            foreach (Parametro Parametro in Parametros)
            {
                if (Parametro.Edicao)
                {
                    string comando = string.Empty;

                    if (Parametro.Tipo == "Decimal")
                    {
                        comando = "UPDATE tbl_Parametros SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro AND ID_Usuario = @id_usuario";
                        decimal valor = Convert.ToDecimal(Parametro.Valor);

                        using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                        {
                            update.Parameters.AddWithValue("@valor", valor);
                            update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                            update.ExecuteNonQuery();
                        }
                    }
                    else if (Parametro.Tipo == "Texto")
                    {
                        comando = "UPDATE tbl_ParametrosTexto SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro AND ID_Usuario = @id_usuario";

                        using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                        {
                            update.Parameters.AddWithValue("@valor", Parametro.Valor);
                            update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                            update.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                            update.ExecuteNonQuery();
                        }
                    }
                    else if (Parametro.Tipo == "Booleano")
                    {
                        comando = "UPDATE tbl_ParametrosBooleanos SET Valor_Parametro = @valor WHERE Nome_Parametro = @parametro AND ID_Usuario = @id_usuario";
                        bool valor = Convert.ToBoolean(Parametro.Valor);

                        using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                        {
                            update.Parameters.AddWithValue("@valor", valor);
                            update.Parameters.AddWithValue("@parametro", Parametro.Descricao);
                            update.ExecuteNonQuery();
                        }
                    }
                }
            }

            conexao.Desconectar();
        }

        public decimal ObterValorDoParametro(string parametro)
        {
            decimal valor;

            string comando = "SELECT Valor_Parametro FROM tbl_Parametros WHERE Nome_Parametro = @parametro";
            
            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@parametro", parametro);
                valor = Convert.ToDecimal(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return valor;
        }

        public bool ObterValorDoParametroBooleano(string parametro)
        {
            bool valor;
            string comando = "SELECT Valor_Parametro FROM tbl_ParametrosBooleanos WHERE Nome_Parametro = @parametro";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@parametro", parametro);
                valor = Convert.ToBoolean(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return valor;

        }

        public string ObterValorDoParametroDeTexto(string parametro)
        {
            string valor;
            string comando = "SELECT ISNULL(Valor_Parametro, '') FROM tbl_ParametrosTexto WHERE Nome_Parametro = @parametro";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@parametro", parametro);
                valor = select.ExecuteScalar().ToString();
            }

            conexao.Desconectar();

            return valor;
        }

        public string ObterValorDoParametroDeTextoPeloUsuario(string parametro)
        {
            string valor;
            string comando = "SELECT Valor_Parametro FROM tbl_ParametrosTexto WHERE Nome_Parametro = @parametro AND ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@parametro", parametro);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                valor = select.ExecuteScalar().ToString();
            }

            conexao.Desconectar();

            return valor;
        }

        public decimal ObterValorDoParametroPeloUsuario(string parametro)
        {
            decimal valor;
            string comando = "SELECT Valor_Parametro FROM tbl_Parametros WHERE Nome_Parametro = @parametro AND ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@parametro", parametro);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                valor = Convert.ToDecimal(select.ExecuteScalar());
            }

            conexao.Desconectar();
            return valor;
        }

        public void ObterTemaPeloUsuario()
        {
            string comando = "SELECT Descricao, R, G, B FROM tbl_Temas WHERE ID_Usuario = @id_usuario AND Descricao = 'Cor principal' UNION SELECT Descricao, R, G, B FROM tbl_Temas WHERE ID_Usuario = @id_usuario AND Descricao = 'Cor secundária' ";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        if (leitor["Descricao"].ToString() == "Cor principal")
                        {
                            Program.tema.Cor_Principal = Color.FromArgb((int)leitor["R"], (int)leitor["G"], (int)leitor["B"]);
                        }
                        else
                        {
                            Program.tema.Cor_Secundaria = Color.FromArgb((int)leitor["R"], (int)leitor["G"], (int)leitor["B"]);
                        }
                    }
                }
            }

            conexao.Desconectar();
        }

        #endregion

        #region Login

        public void CadastrarUsuario(Usuario usuario, Tema tema)
        {
            string comando = "INSERT INTO tbl_Usuarios (Nome, Sobrenome, Nascimento, Registro, Login, Senha) VALUES (@nome, @sobrenome, @nascimento, GETDATE(), @login, @senha)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@nome", usuario.Nome);
                insert.Parameters.AddWithValue("@sobrenome", usuario.Sobrenome);
                insert.Parameters.AddWithValue("@nascimento", usuario.Nascimento);
                insert.Parameters.AddWithValue("@login", usuario.Login);
                insert.Parameters.AddWithValue("@senha", usuario.Senha);

                insert.ExecuteNonQuery();
            }

            CadastrarTema(tema);
            CadastrarCategoriasFinanceiras();
            CadastrarParametrosDoUsuario();

            conexao.Conectar();
        }

        public void CadastrarTema(Tema tema)
        {
            string comando = "INSERT INTO tbl_Temas (Descricao, ID_Usuario, R, G, B) VALUES ('Cor principal', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), @r, @g, @b)";
            string comando2 = "INSERT INTO tbl_Temas (Descricao, ID_Usuario, R, G, B) VALUES ('Cor secundária', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), @r, @g, @b)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@r", tema.Cor_Principal.R);
                insert.Parameters.AddWithValue("@g", tema.Cor_Principal.G);
                insert.Parameters.AddWithValue("@b", tema.Cor_Principal.B);
                insert.ExecuteNonQuery();
            }

            using (SqlCommand insert = new SqlCommand(comando2, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@r", tema.Cor_Secundaria.R);
                insert.Parameters.AddWithValue("@g", tema.Cor_Secundaria.G);
                insert.Parameters.AddWithValue("@b", tema.Cor_Secundaria.B);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void CadastrarCategoriasFinanceiras()
        {
            string comando = "INSERT INTO tbl_CategoriasFinanceiras (Categoria, ID_Usuario, Tipo, ID_Parente) VALUES ('Receitas', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Receita', NULL), ('Despesas', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Despesa', NULL), ('Investimentos', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Despesa', NULL), ('Outras movimentações', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), NULL, NULL), ('Transferências', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), NULL, NULL), ('Acerto do caixa', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), NULL, NULL) INSERT INTO tbl_CategoriasFinanceiras (Categoria, ID_Usuario, Tipo, ID_Parente) VALUES ('Despesas fixas', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Despesa', (SELECT ID_Categoria FROM tbl_CategoriasFinanceiras WHERE Categoria = 'Despesas' AND ID_Usuario = (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC))), ('Despesas variáveis', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Despesa', (SELECT ID_Categoria FROM tbl_CategoriasFinanceiras WHERE Categoria = 'Despesas' AND ID_Usuario = (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC))), ('Outras receitas', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Receita', (SELECT ID_Categoria FROM tbl_CategoriasFinanceiras WHERE Categoria = 'Outras movimentações' AND ID_Usuario = (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC))), ('Outras despesas', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC), 'Despesa', (SELECT ID_Categoria FROM tbl_CategoriasFinanceiras WHERE Categoria = 'Outras movimentações' AND ID_Usuario = (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC)))";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void CadastrarParametrosDoUsuario()
        {
            string comando = "INSERT INTO tbl_ParametrosTexto (Nome_Parametro, Valor_Parametro, ID_Usuario) VALUES ('Exibição do dia no planejamento semanal', 'Dia útil', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC)), ('Período do fluxo de caixa', '', (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC))";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.ExecuteNonQuery();
            }

            string comando2 = "INSERT INTO tbl_ParametrosBooleanos(Nome_Parametro, Valor_Parametro, ID_Usuario) VALUES ('Visualizar Orçamentos', 1, (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC)), ('Visualizar Lançamentos', 1, (SELECT TOP(1) ID_Usuario FROM tbl_Usuarios ORDER BY ID_Usuario DESC))";

            using (SqlCommand insert = new SqlCommand(comando2, conexao.Conectar()))
            {
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public bool VerificarLogin(string login, string senha)
        {
            bool confirmacao = false;

            string comando = "SELECT * FROM tbl_Usuarios WHERE Login = @login AND Senha = @senha";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@login", login);
                select.Parameters.AddWithValue("@senha", senha);


                    using (SqlDataReader leitor = select.ExecuteReader())
                    {
                        if (leitor.HasRows)
                        {
                            confirmacao = true;
                        }
                    }

            }


            return confirmacao;
        }

        public Usuario TrazerUsuario(string login, string senha)
        {
            Usuario usuario = new Usuario();

            string comando = "SELECT ID_Usuario, Nome, Sobrenome, Nascimento, Registro, Login, Senha FROM tbl_Usuarios WHERE Login = @login AND Senha = @senha";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@login", login);
                select.Parameters.AddWithValue("@senha", senha);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        usuario.ID_Usuario = Convert.ToInt32(leitor[0]);
                        usuario.Nome = leitor[1].ToString();
                        usuario.Sobrenome = leitor[2].ToString();
                        usuario.Nascimento = Convert.ToDateTime(leitor[3]);
                        usuario.Registro = Convert.ToDateTime(leitor[4]);
                        usuario.Login = leitor[5].ToString();
                        usuario.Senha = leitor[6].ToString();
                    }
                }
            }


            return usuario;
        }

        #endregion

        #region Gerenciamento pessoal


        #region Tela Inicial

        public void PreencherPlanejamentoSemanal(DateTime Dia1, List<Tarefa_Semanal> Tarefas, string tipo)
        {
            string comando;

            if (tipo == "Todos")
            {
                comando = "SELECT ID_Tarefa, Descricao, Observacao, Dia, Inicio, ISNULL(ID_Papel, 0), ISNULL((SELECT R FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS R, ISNULL((SELECT G FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS G, ISNULL((SELECT B FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS B, Fixa FROM tbl_Planejamento WHERE ID_Usuario = @id_usuario AND Dia BETWEEN @dia1 AND DATEADD(DD, 7, @dia1) ORDER BY Dia, Inicio";
            }
            else
            {
                comando = "SELECT ID_Tarefa, Descricao, Observacao, Dia, Inicio, ISNULL(ID_Papel, 0), ISNULL((SELECT R FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS R, ISNULL((SELECT G FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS G, ISNULL((SELECT B FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS B, Fixa FROM tbl_Planejamento WHERE ID_Usuario = @id_usuario AND Dia BETWEEN @dia1 AND DATEADD(DD, 7, @dia1) AND Tipo = @tipo ORDER BY Dia, Inicio";
            }

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@dia1", Dia1.Date);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@tipo", tipo);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        DateTime data = Convert.ToDateTime(Convert.ToDateTime(leitor[3].ToString()).ToShortDateString() + " " + Convert.ToDateTime(leitor[4].ToString()).ToShortTimeString());

                        foreach (Tarefa_Semanal tarefa in Tarefas)
                        {
                            if (tarefa.Data == data)
                            {
                                tarefa.ID_Tarefa = (int)leitor[0];
                                tarefa.Descricao = leitor[1].ToString();
                                tarefa.Observacao = leitor[2].ToString();
                                tarefa.ID_Papel = (int)leitor[5];
                                tarefa.Cor = Color.FromArgb((int)leitor[6], (int)leitor[7], (int)leitor[8]);
                                tarefa.Fixa = Convert.ToBoolean(leitor[9]);
                            }
                        }
                    }
                }

                conexao.Desconectar();
            }
        }

        public void CopiarPlanejamentoDaSemanaPassada(DateTime dia1)
        {
            List<Tarefa_Semanal> tarefas = new List<Tarefa_Semanal>();

            ApagarPlanejamentoAtual(dia1);

            string comando = "INSERT INTO tbl_Planejamento (Descricao, Observacao, Dia, Inicio, Status, ID_Usuario, ID_Papel, Fixa, Tempo, Tipo) SELECT Descricao, Observacao, DATEADD(DD, 7, Dia), Inicio, Status, @id_usuario, ID_Papel, Fixa, Tempo, Tipo FROM tbl_Planejamento WHERE ID_Usuario = @id_usuario AND Dia BETWEEN DATEADD(DD, -7, @dia1) AND DATEADD(DD, -1, @dia1)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@dia1", dia1.Date);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarPlanejamentoAtual(DateTime dia1)
        {
            string cmd = "DELETE FROM tbl_Planejamento WHERE Dia >= @dia1 AND ID_Usuario = @id_usuario";

            using (SqlCommand delete = new SqlCommand(cmd, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@dia1", dia1.Date);
                delete.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public List<Tarefa_Semanal>  PreencherPainelDeTarefas(DateTime Dia1)
        {
            List<Tarefa_Semanal> Tarefas = new List<Tarefa_Semanal>();

            string comando = "SELECT ID_Tarefa, Descricao, Observacao, ISNULL(ID_Papel, 0) AS ID_Papel, 1 AS Multiplicador, ISNULL((SELECT R FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS R, ISNULL((SELECT G FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS G, ISNULL((SELECT B FROM tbl_Papeis WHERE ID_Papel = tbl_Planejamento.ID_Papel AND ID_Usuario = tbl_Planejamento.ID_Usuario), 255) AS B, 0 AS Fixa FROM tbl_Planejamento WHERE ID_Usuario = @id_usuario AND Dia IS NULL UNION SELECT ID_Fixa, IIF(Multiplicador = 1, Descricao, IIF(Multiplicador - (SELECT COUNT(*) FROM tbl_Planejamento WHERE Descricao = tbl_TarefasFixas.Descricao AND ID_Papel = tbl_TarefasFixas.ID_Papel AND ID_Usuario = tbl_TarefasFixas.ID_Usuario) <= 0, Descricao + ' ' + CONVERT(VARCHAR(3), Multiplicador) + ' x na semana' + ' (Agendado)', IIF(Multiplicador - (SELECT COUNT(*) FROM tbl_Planejamento WHERE Descricao = tbl_TarefasFixas.Descricao AND ID_Papel = tbl_TarefasFixas.ID_Papel AND ID_Usuario = tbl_TarefasFixas.ID_Usuario) = 1, Descricao + ' ' + CONVERT(VARCHAR(3), Multiplicador) + ' x na semana' + ' (resta 1)', Descricao + ' ' + CONVERT(VARCHAR(3), Multiplicador) + ' x na semana' + ' (restam ' + CONVERT(VARCHAR(3), Multiplicador - (SELECT COUNT(*) FROM tbl_Planejamento WHERE Descricao = tbl_TarefasFixas.Descricao AND ID_Papel = tbl_TarefasFixas.ID_Papel AND ID_Usuario = tbl_TarefasFixas.ID_Usuario)) + ')'))), Observacao, ISNULL(ID_Papel, 0), Multiplicador, ISNULL((SELECT R FROM tbl_Papeis WHERE ID_Papel = tbl_TarefasFixas.ID_Papel AND ID_Usuario = tbl_TarefasFixas.ID_Usuario), 255) AS R, ISNULL((SELECT G FROM tbl_Papeis WHERE ID_Papel = tbl_TarefasFixas.ID_Papel AND ID_Usuario = tbl_TarefasFixas.ID_Usuario), 255) AS G, ISNULL((SELECT B FROM tbl_Papeis WHERE ID_Papel = tbl_TarefasFixas.ID_Papel AND ID_Usuario = tbl_TarefasFixas.ID_Usuario), 255) AS B, 1 FROM tbl_TarefasFixas WHERE ID_Usuario = @id_usuario ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@dia1", Dia1);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Tarefas.Add(new Tarefa_Semanal
                        {
                            ID_Tarefa = (int)leitor[0],
                            Descricao = leitor[1].ToString(),
                            Observacao = leitor[2].ToString(),
                            ID_Papel = (int)leitor[3],
                            Multiplicador = (int)leitor[4],
                            Cor = Color.FromArgb((int)leitor[5], (int)leitor[6], (int)leitor[7]),
                            Fixa = Convert.ToBoolean(leitor[8])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return Tarefas;
        }

        public List<Tarefa> TrazerAtividadesDoDia(string data)
        {
            string comando = "SELECT Inicio, Termino, Descricao FROM tbl_TarefasDiarias WHERE Dia = @data ORDER BY Inicio";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@data", data);
            SqlDataReader leitor = select.ExecuteReader();
            List<Tarefa> Lista = new List<Tarefa>();
            while (leitor.Read())
            {
                Lista.Add(new Tarefa
                {
                    Inicio = Convert.ToDateTime(leitor[0].ToString()),
                    Termino = Convert.ToDateTime(leitor[1].ToString()),
                    Descricao = leitor[2].ToString()
                });
            }
            leitor.Close();
            conexao.Desconectar();
            return Lista;
        }

        public void RegistrarAtividadeDiaria(Tarefa Tarefa)
        {
            string comando = "INSERT INTO tbl_TarefasDiarias (Descricao, Observacao, Dia, Inicio, Termino, Status) VALUES (@descricao, @obs, @dia, @inicio, @termino, 'Pendente')";
            SqlCommand insert = new SqlCommand(comando, conexao.Conectar());
            insert.Parameters.AddWithValue("@descricao", Tarefa.Descricao);
            insert.Parameters.AddWithValue("@obs", Tarefa.Observacao);
            insert.Parameters.AddWithValue("@dia", Tarefa.Dia.ToShortDateString());
            insert.Parameters.AddWithValue("@inicio", Tarefa.Inicio.ToShortTimeString());
            insert.Parameters.AddWithValue("@termino", Tarefa.Termino.ToShortTimeString());
            insert.ExecuteNonQuery();

            MessageBox.Show("Tarefa registrada.");
        }

        public string HoraDaUltimaAtividade(string data)
        {
            string comando = "SELECT TOP (1) Termino FROM tbl_TarefasDiarias WHERE Dia = @data ORDER BY Termino DESC";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@data", data);
            string termino = Convert.ToDateTime(select.ExecuteScalar().ToString()).ToShortTimeString();
            conexao.Desconectar();
            return termino;
        }

        public string TrazerDetalhesDaAtividade(string atividade, string data)
        {
            string comando = "SELECT TOP (1) Observacao FROM tbl_TarefasDiarias WHERE Descricao = @atividade AND Dia = @data";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@atividade", atividade);
            select.Parameters.AddWithValue("@data", data);
            string detalhe = select.ExecuteScalar().ToString();
            return detalhe;
        }

        public void EditarTema(Tema tema)
        {
            string comando = "UPDATE tbl_Temas SET R = @r, G = @g, B = @b WHERE ID_Usuario = @id_usuario AND Descricao = 'Cor principal'";
            string comando2 = "UPDATE tbl_Temas SET R = @r, G = @g, B = @b WHERE ID_Usuario = @id_usuario AND Descricao = 'Cor secundária'";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@r", tema.Cor_Principal.R);
                update.Parameters.AddWithValue("@g", tema.Cor_Principal.G);
                update.Parameters.AddWithValue("@b", tema.Cor_Principal.B);
                update.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                update.ExecuteNonQuery();
            }

            using (SqlCommand update = new SqlCommand(comando2, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@r", tema.Cor_Secundaria.R);
                update.Parameters.AddWithValue("@g", tema.Cor_Secundaria.G);
                update.Parameters.AddWithValue("@b", tema.Cor_Secundaria.B);
                update.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                update.ExecuteNonQuery();
            }

            Program.tema = tema;

            conexao.Desconectar();
        }

        public bool VerificarLancamentoDeMetodoAutomaticoDiario(string descricao)
        {
            bool verificar = false;

            string comando = "SELECT IIF(COUNT(*) = 0, 0, 1) FROM tbl_MetodosAutomaticos WHERE Descricao = @descricao AND CONVERT(DATE, Data) = CONVERT(DATE, GETDATE()) AND ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@descricao", descricao);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                verificar = Convert.ToBoolean(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return verificar;
        }

        public void AtualizarLancamentoDeMetodoAutomatico(string descricao)
        {
            string comando = "INSERT INTO tbl_MetodosAutomaticos (Descricao, Data, ID_Usuario) VALUES (@descricao, GETDATE(), @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", descricao);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #region Tarefas Semanais

        public void RegistrarTarefaSemanal(Tarefa_Semanal Tarefa, bool agendar)
        {
            string comando;

            if (agendar)
            {
                comando = "INSERT INTO tbl_Planejamento (Descricao, Observacao, Dia, Inicio, Tempo, Status, ID_Usuario, ID_Papel, Fixa, Tipo) VALUES (@descricao, @observacao, @dia, @inicio, @tempo, 'Pendente', @id_usuario, @id_papel, 0, @tipo)";

            }
            else
            {
                comando = "INSERT INTO tbl_Planejamento (Descricao, Observacao, Status, ID_Usuario, ID_Papel, Tipo) VALUES (@descricao, @observacao, 'Pendente', @id_usuario, @id_papel, @tipo)";
            }

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", Tarefa.Descricao);
                insert.Parameters.AddWithValue("@observacao", Tarefa.Observacao);
                insert.Parameters.AddWithValue("@dia", Tarefa.Data.ToShortDateString());
                insert.Parameters.AddWithValue("@inicio", Tarefa.Data.ToShortTimeString());
                insert.Parameters.AddWithValue("@tempo", Tarefa.Tempo);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@id_Papel", Tarefa.ID_Papel);
                insert.Parameters.AddWithValue("@tipo", Tarefa.Tipo);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Tarefa_Semanal TrazerTarefaSemanal(int id_tarefa)
        {
            Tarefa_Semanal tarefa = new Tarefa_Semanal();

            string comando = "SELECT Descricao, Observacao, Dia, Inicio, ISNULL(Tempo, 0), ID_Papel, Tipo FROM tbl_Planejamento WHERE ID_Tarefa = @id_tarefa";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_tarefa", id_tarefa);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        tarefa.ID_Tarefa = id_tarefa;
                        tarefa.Descricao = leitor[0].ToString();
                        tarefa.Observacao = leitor[1].ToString();

                        string dia = leitor[2].ToString().Substring(0, 10);
                        string inicio = leitor[3].ToString().Substring(0, 5); 

                        if (dia != string.Empty && inicio != string.Empty)
                        {
                            tarefa.Data = Convert.ToDateTime(dia + " " + inicio);
                        }

                        tarefa.Tempo = Convert.ToInt32(leitor[4]);
                        tarefa.ID_Papel = Convert.ToInt32(leitor[5]);
                        tarefa.Tipo = leitor[6].ToString();
                    }
                }
            }

            conexao.Desconectar();

            return tarefa;
        }

        public void EditarTarefaSemanal(Tarefa_Semanal Tarefa, bool agendar)
        {
            string comando;

            if (agendar)
            {
                comando = "UPDATE tbl_Planejamento SET Descricao = @descricao, Observacao = @observacao, Dia = @dia, Inicio = @inicio, ID_Papel = @id_papel, Tempo = @tempo, Tipo = @tipo WHERE ID_Tarefa = @id_tarefa";

            }
            else
            {
                comando = "UPDATE tbl_Planejamento SET Descricao = @descricao, Observacao = @observacao, Dia = NULL, Inicio = NULL, ID_Papel = @id_papel, Tempo = NULL, Tipo = @tipo WHERE ID_Tarefa = @id_tarefa";
            }

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", Tarefa.Descricao);
                update.Parameters.AddWithValue("@observacao", Tarefa.Observacao);
                update.Parameters.AddWithValue("@dia", Tarefa.Data.ToShortDateString());
                update.Parameters.AddWithValue("@inicio", Tarefa.Data.ToShortTimeString());
                update.Parameters.AddWithValue("@tempo", Tarefa.Tempo);
                update.Parameters.AddWithValue("@id_tarefa", Tarefa.ID_Tarefa);
                update.Parameters.AddWithValue("@id_Papel", Tarefa.ID_Papel);
                update.Parameters.AddWithValue("@tipo", Tarefa.Tipo);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AdicionarTarefaAoPlanejamento(Tarefa_Semanal tarefa)
        {
            string comando;

            if (tarefa.Fixa) 
            { 
                comando = "INSERT INTO tbl_Planejamento (Descricao, Observacao, Dia, Inicio, Status, ID_Usuario, ID_Papel, Fixa, Tempo) SELECT Descricao, Observacao, @dia, @inicio, 'Pendente', @id_usuario, ID_Papel, @fixa, 60 FROM tbl_TarefasFixas WHERE ID_Fixa = @id_tarefa"; 

                using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@id_tarefa", tarefa.ID_Tarefa);
                    insert.Parameters.AddWithValue("@fixa", tarefa.Fixa);
                    insert.Parameters.AddWithValue("@dia", tarefa.Data.ToShortDateString());
                    insert.Parameters.AddWithValue("@inicio", tarefa.Data.ToShortTimeString());
                    insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                    insert.ExecuteNonQuery();
                }
            }
            else 
            {
                comando = "UPDATE tbl_Planejamento SET Dia = @dia, Inicio = @inicio, Tempo = 60 WHERE ID_Tarefa = @id_tarefa";

                using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@dia", tarefa.Data.ToShortDateString());
                    update.Parameters.AddWithValue("@inicio", tarefa.Data.ToShortTimeString());
                    update.Parameters.AddWithValue("@id_tarefa", tarefa.ID_Tarefa);

                    update.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();
        }

        public void RemoverTarefaDoPlanejamento(Tarefa_Semanal tarefa)
        {
            string comando;

            if (tarefa.Fixa)
            {
                comando = "DELETE FROM tbl_Planejamento WHERE ID_Tarefa = @id_tarefa";
            }
            else
            {
                comando = "UPDATE tbl_Planejamento SET Dia = NULL, Inicio = NULL, Tempo = NULL WHERE ID_Tarefa = @id_tarefa";
            }


            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_tarefa", tarefa.ID_Tarefa);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarTarefa(Tarefa_Semanal tarefa)
        {
            string comando = "DELETE FROM tbl_Planejamento WHERE ID_Tarefa = @id_tarefa"; 

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_tarefa", tarefa.ID_Tarefa);

                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #region Papéis

        public void CadastrarPapel(Papel papel)
        {
            string comando = "INSERT INTO tbl_Papeis (Descricao, ID_Usuario, R, G, B) VALUES (@descricao, @id_usuario, @r, @g, @b)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", papel.Descricao);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@r", papel.Cor.R);
                insert.Parameters.AddWithValue("@g", papel.Cor.G);
                insert.Parameters.AddWithValue("@b", papel.Cor.B);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarPapel(Papel papel)
        {
            string comando = "UPDATE tbl_Papeis SET Descricao = @descricao, R = @r, G = @g, B = @b WHERE ID_Papel = @id_papel AND ID_Usuario = @id_usuario";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", papel.Descricao);
                update.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                update.Parameters.AddWithValue("@id_papel", papel.ID_Papel);
                update.Parameters.AddWithValue("@r", papel.Cor.R);
                update.Parameters.AddWithValue("@g", papel.Cor.G);
                update.Parameters.AddWithValue("@b", papel.Cor.B);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public List<Papel> TrazerPapeis(DateTime dia1)
        {
            List<Papel> Papeis = new List<Papel>();

            string comando = "SELECT ID_Papel, Descricao, (SELECT COUNT(*) FROM tbl_Planejamento WHERE ID_Papel = tbl_Papeis.ID_Papel AND Dia BETWEEN @dia1 AND DATEADD(DAY, 7, @dia1)), R, G, B FROM tbl_Papeis WHERE ID_Usuario = @id_usuario  ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@dia1", dia1);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Papeis.Add(new Papel
                        {
                            ID_Papel = (int)leitor[0],
                            Descricao = leitor[1].ToString(),
                            Compromissos = (int)leitor[2],
                            Cor = Color.FromArgb((int)leitor[3], (int)leitor[4], (int)leitor[5])
                        });
                    }
                }
            }

            return Papeis;
        }

        public void ApagarPapel(int id)
        {
            string comando = "DELETE FROM tbl_Papeis WHERE ID_Papel = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Papel excluído.", "Excluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Papel> PreencherComboPapeis()
        {
            List<Papel> lista = new List<Papel>();

            string comando = "SELECT ID_Papel, Descricao FROM tbl_Papeis WHERE ID_Usuario = @id_usuario ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Papel
                        {
                            ID_Papel = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return lista;
        }

        public List<string> PreencherComboTipos()
        {
            List<string> lista = new List<string>();

            string comando = "SELECT DISTINCT Tipo FROM tbl_Planejamento ORDER BY Tipo";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(leitor[0].ToString());
                    }
                }
            }

            if (!lista.Contains("Mais importante")) { lista.Add("Mais importante"); }

            conexao.Desconectar();

            return lista;
        }

        public List<string> TrazerTipos()
        {
            List<string> lista = new List<string>();

            lista.Add("Todos"); 

            string comando = "SELECT DISTINCT Tipo FROM tbl_Planejamento ORDER BY Tipo";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(leitor[0].ToString());
                    }
                }
            }



            conexao.Desconectar();

            return lista;
        }

        public Papel TrazerPapel(int id_papel)
        {
            Papel papel = new Papel();

            string comando = "SELECT Descricao, R, G, B FROM tbl_Papeis WHERE ID_Papel = @id_papel AND ID_Usuario = @id_usuario";

            using (SqlCommand select =new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_papel", id_papel);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        papel.ID_Papel = id_papel;
                        papel.Descricao = leitor[0].ToString();
                        papel.Cor = Color.FromArgb(Convert.ToInt32(leitor[1]), Convert.ToInt32(leitor[2]), Convert.ToInt32(leitor[3]));
                    }
                }
            }

            conexao.Desconectar();

            return papel;
        }

        #endregion

        #region Tarefas fixas

        public void CadastrarTarefaFixa(Tarefa_Semanal tarefa)
        {
            string comando = "INSERT INTO tbl_TarefasFixas (Descricao, Observacao, ID_Usuario, ID_Papel, Multiplicador) VALUES (@descricao, @observacao, @id_usuario, @id_papel, @multiplicador)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", tarefa.Descricao);
                insert.Parameters.AddWithValue("@observacao", tarefa.Observacao);
                insert.Parameters.AddWithValue("@id_papel", tarefa.ID_Papel);
                insert.Parameters.AddWithValue("@multiplicador", tarefa.Multiplicador);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarTarefaFixa(Tarefa_Semanal tarefa)
        {
            string comando = "UPDATE tbL_TarefasFixas SET Descricao = @descricao, Observacao = @observacao, Multiplicador = @multiplicador WHERE ID_Fixa = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", tarefa.ID_Tarefa);
                update.Parameters.AddWithValue("@descricao", tarefa.Descricao);
                update.Parameters.AddWithValue("@observacao", tarefa.Observacao);
                update.Parameters.AddWithValue("@multiplicador", tarefa.Multiplicador);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarTarefaFixa(int id_tarefa)
        {
            string comando = "DELETE FROM tbl_TarefasFixas WHERE ID_Fixa = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id_tarefa);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Excluído.", "Excluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Tarefa_Semanal TrazerTarefaFixa(int id)
        {
            Tarefa_Semanal tarefa = new Tarefa_Semanal();

            string comando = "SELECT Descricao, Observacao, Multiplicador FROM tbl_TarefasFixas WHERE ID_Fixa = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        tarefa.ID_Tarefa = id;
                        tarefa.Descricao = leitor[0].ToString();
                        tarefa.Observacao = leitor[1].ToString();
                        tarefa.Multiplicador = Convert.ToInt32(leitor[2]);
                    }
                }
            }

            conexao.Desconectar();

            return tarefa;
        }

        public List<Tarefa_Semanal> TrazerTarefasFixas(int id_papel)
        {
            List<Tarefa_Semanal> tarefas = new List<Tarefa_Semanal>();

            string comando = "SELECT ID_Fixa, Descricao, Multiplicador FROM tbl_TarefasFixas WHERE ID_Usuario = @id_usuario AND ID_Papel = @id_papel";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@id_papel", id_papel);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        tarefas.Add(new Tarefa_Semanal
                        {
                            ID_Tarefa = (int)leitor[0],
                            Descricao = leitor[1].ToString(),
                            Multiplicador = (int)leitor[2]
                         });
                    }
                }
            }

            return tarefas;
        }

        #endregion

        #region Lista de Afazeres

        public void ImprimirAfazeresDoDia(DateTime data, bool imprimir)
        {
            List<Afazer> atividades = new List<Afazer>();

            List<Afazer> afazeres = new List<Afazer>();
            List<Afazer> rotinas = new List<Afazer>();

            string comando = "SELECT Ordem, Descricao, Minutos, Conclusao, IIF(ID_Rotina IS NULL, 0, 1) AS Rotina FROM tbl_Afazeres WHERE Data = @data AND ID_Usuario = @id_usuario ORDER BY IIF(ID_Rotina IS NULL, 0, 1), Ordem";
        
            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@data", data);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        atividades.Add(new Afazer
                        {
                            Ordem = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Minutos = Convert.ToInt32(leitor[2]),
                            Conclusao = Convert.ToBoolean(leitor[3]),
                            Rotina = Convert.ToBoolean(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();

            foreach (Afazer atividade in atividades)
            {
                DateTime tempo = Convert.ToDateTime("00:00");
                tempo = tempo.AddMinutes(atividade.Minutos);

                atividade.Detalhes = tempo.ToShortTimeString();

                if (atividade.Detalhes == "00:00") { atividade.Detalhes = string.Empty; }
                else 
                {
                    string horas = atividade.Detalhes.Substring(0, 2);
                    string minutos = atividade.Detalhes.Substring(3, 2);

                    if (horas == "00")
                    {
                        atividade.Detalhes = minutos + "min";
                    }
                    else
                    {
                        atividade.Detalhes = horas + "h" + minutos + "min";
                    }
                }
            }

            afazeres = atividades.Where(x => !x.Rotina).OrderBy(x => x.Ordem).ToList();
            rotinas = atividades.Where(x => x.Rotina).OrderBy(x => x.Ordem).ToList();



            formRepAfazeres relatorio = new formRepAfazeres();
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("data", data.ToShortDateString()));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("usuario", Program.usuario.Nome));


            relatorio.reportViewer1.LocalReport.DataSources.Clear();
            relatorio.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetAfazer", afazeres));
            relatorio.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetRotina", rotinas));

            relatorio.reportViewer1.RefreshReport();

            if (imprimir)
            {
                AutoPrintCls autoprintme = new AutoPrintCls(relatorio.reportViewer1.LocalReport);
                //autoprintme.PrinterSettings.PrinterName = Program.Computador.Impressora_Termica;
                autoprintme.Print();
            }
            else
            {
                AutoPrintCls autoprintme = new AutoPrintCls(relatorio.reportViewer1.LocalReport);
                autoprintme.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                autoprintme.Print();
            }
        }

        public List<Afazer> ListaDeAfazeres(DateTime data)
        {
            List<Afazer> afazeres = new List<Afazer>();

            string comando = "SELECT ID_Afazer, Ordem, Descricao, Minutos, Conclusao FROM tbl_Afazeres WHERE ID_Usuario = @id_usuario AND Data = CONVERT(DATE, @data) AND ID_Rotina IS NULL ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@data", data);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        afazeres.Add(new Afazer
                        {
                            ID_Afazer = Convert.ToInt32(leitor[0]),
                            Ordem = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Minutos = Convert.ToInt32(leitor[3]),
                            Conclusao = Convert.ToBoolean(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return afazeres;
        }

        public List<Rotina> ListaDeRotinasDoDia(DateTime data)
        {
            List<Rotina> rotinas = new List<Rotina>();

            string comando = "SELECT ID_Afazer, Ordem, Descricao, Minutos, Conclusao, ID_Rotina FROM tbl_Afazeres WHERE ID_Usuario = @id_usuario AND Data = CONVERT(DATE, @data) AND ID_Rotina IS NOT NULL ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@data", data);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        rotinas.Add(new Rotina
                        {
                            ID_Afazer = Convert.ToInt32(leitor[0]),
                            Ordem = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Minutos = Convert.ToInt32(leitor[3]),
                            Conclusao = Convert.ToBoolean(leitor[4]),
                            ID_Rotina = Convert.ToInt32(leitor[5])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return rotinas;
        }

        public List<Rotina> ListaDeRotinas(DateTime data)
        {
            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;

            int dias_do_mes = DateTime.DaysInMonth(ano, mes);

            bool ultimo_dia = false;
            if (dia == dias_do_mes) { ultimo_dia = true; }

            List<Rotina> rotinas = new List<Rotina>();

            string comando = "SELECT ID_Rotina, Ordem, Descricao, Minutos FROM tbl_Rotinas WHERE ID_Usuario = @id_usuario AND ((Mensal = 0 AND DATEDIFF(DD, (SELECT TOP(1) Data FROM tbl_Afazeres WHERE ID_Rotina = tbl_Rotinas.ID_Rotina ORDER BY Data DESC), @data) % Intervalo = 0) OR (Mensal = 1 AND @ultimo_dia = 1 AND Ultimo_Dia = 1) OR (Mensal = 1 AND DATEPART(DD, @data) = Dia_do_Mes)) ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@data", data);
                select.Parameters.AddWithValue("@ultimo_dia", ultimo_dia);


                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        rotinas.Add(new Rotina
                        {
                            ID_Rotina = Convert.ToInt32(leitor[0]),
                            Ordem = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Minutos = Convert.ToInt32(leitor[3]),
                        });
                    }
                }
            }

            conexao.Desconectar();

            return rotinas;
        }

        public void AdicionarAfazer(Rotina afazer)
        {
            string comando;

            if (afazer.Rotina)
            {
                AdicionarRotina(afazer);
                comando = "INSERT INTO tbl_Afazeres (Ordem, Descricao, Detalhes, Minutos, ID_Usuario, Conclusao, Registro, Data, ID_Rotina) VALUES ((SELECT COUNT(*) FROM tbl_Afazeres WHERE Data = @data AND ID_Usuario = @id_usuario AND ID_Rotina IS NOT NULL) + 1, @descricao, @detalhes, @minutos, @id_usuario, 0, GETDATE(), @data, (SELECT TOP(1) ID_Rotina FROM tbl_Rotinas ORDER BY ID_Rotina DESC))";
            }
            else
            {
                comando = "INSERT INTO tbl_Afazeres (Ordem, Descricao, Detalhes, Minutos, ID_Usuario, Conclusao, Registro, Data) VALUES ((SELECT COUNT(*) FROM tbl_Afazeres WHERE Data = @data AND ID_Usuario = @id_usuario AND ID_Rotina IS NULL) + 1, @descricao, @detalhes, @minutos, @id_usuario, 0, GETDATE(), @data)";
            }


            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", afazer.Descricao);
                insert.Parameters.AddWithValue("@detalhes", afazer.Detalhes);
                insert.Parameters.AddWithValue("@minutos", afazer.Minutos);
                insert.Parameters.AddWithValue("@data", afazer.Data);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AdicionarRotina(Rotina afazer)
        {
            string comando;

            if (afazer.Mensal)
            {
                comando = "INSERT INTO tbl_Rotinas (Ordem, Descricao, Detalhes, Minutos, ID_Usuario, Mensal, Dia_do_Mes, Ultimo_Dia) VALUES ((SELECT COUNT(*) FROM tbl_Rotinas WHERE ID_Usuario = @id_usuario) + 1, @descricao, @detalhes, @minutos, @id_usuario, @mensal, @dia, @ultimo_dia)";
            }
            else
            {
                comando = "INSERT INTO tbl_Rotinas (Ordem, Descricao, Detalhes, Minutos, ID_Usuario, Mensal, Intervalo) VALUES ((SELECT COUNT(*) FROM tbl_Rotinas WHERE ID_Usuario = @id_usuario) + 1, @descricao, @detalhes, @minutos, @id_usuario, @mensal, @intervalo)";
            }

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", afazer.Descricao);
                insert.Parameters.AddWithValue("@detalhes", afazer.Detalhes);
                insert.Parameters.AddWithValue("@minutos", afazer.Minutos);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@id_etapa", afazer.ID_Etapa);
                insert.Parameters.AddWithValue("@rotina", afazer.Rotina);
                insert.Parameters.AddWithValue("@mensal", afazer.Mensal);

                insert.Parameters.AddWithValue("@intervalo", afazer.Intervalo);
                insert.Parameters.AddWithValue("@dia", afazer.Dia);
                insert.Parameters.AddWithValue("@ultimo_dia", afazer.Ultimo_Dia);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void TrazerInformacoesDoAfazer(Rotina afazer)
        {
            string comando = "SELECT ID_Afazer, Descricao, Detalhes, Minutos, Data, Ordem, ISNULL(ID_Rotina, 0) FROM tbl_Afazeres WHERE ID_Afazer = @id_afazer";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_afazer", afazer.ID_Afazer);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        afazer.ID_Afazer = Convert.ToInt32(leitor[0]);
                        afazer.Descricao = Convert.ToString(leitor[1]);
                        afazer.Detalhes = Convert.ToString(leitor[2]);
                        afazer.Minutos = Convert.ToInt32(leitor[3]);
                        afazer.Data = Convert.ToDateTime(leitor[4]);
                        afazer.Ordem = Convert.ToInt32(leitor[5]);
                        afazer.ID_Rotina = Convert.ToInt32(leitor[6]);
                    }
                }
            }

            conexao.Desconectar();
        }

        public void TrazerInformacoesDaRotina(Rotina rotina)
        {
            string comando = "SELECT ID_Rotina, Descricao, Detalhes, Minutos, Intervalo, Mensal, ISNULL(Dia_do_Mes, 0), ISNULL(Ultimo_Dia, 0) FROM tbl_Rotinas WHERE ID_Rotina = @id_rotina";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_rotina", rotina.ID_Rotina);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        rotina.ID_Rotina = Convert.ToInt32(leitor[0]);
                        rotina.Descricao = Convert.ToString(leitor[1]);
                        rotina.Detalhes = Convert.ToString(leitor[2]);
                        rotina.Minutos = Convert.ToInt32(leitor[3]);
                        rotina.Intervalo = Convert.ToInt32(leitor[4]);
                        rotina.Mensal = Convert.ToBoolean(leitor[5]);
                        rotina.Dia = Convert.ToInt32(leitor[6]);
                        rotina.Ultimo_Dia = Convert.ToBoolean(leitor[7]);
                    }
                }
            }

            conexao.Desconectar();
        }

        public void EditarAfazer(Afazer afazer)
        {
            string comando = "UPDATE tbl_Afazeres SET Descricao = @descricao, Detalhes = @detalhes, Minutos = @minutos, Data = CONVERT(DATE, @data), Ordem = IIF(CONVERT(DATE, @data) = Data, Ordem, (SELECT COUNT(*) FROM tbl_Afazeres WHERE Data = @data AND ID_Rotina IS NULL AND ID_Usuario = @id_usuario) + 1) WHERE ID_Afazer = @id_afazer";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", afazer.Descricao);
                update.Parameters.AddWithValue("@detalhes", afazer.Detalhes);
                update.Parameters.AddWithValue("@minutos", afazer.Minutos);
                update.Parameters.AddWithValue("@data", afazer.Data);
                update.Parameters.AddWithValue("@id_afazer", afazer.ID_Afazer);
                update.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarRotina(Rotina afazer)
        {
            string comando = "UPDATE tbl_Rotinas SET Descricao = @descricao, Detalhes = @detalhes, Minutos = @minutos, Intervalo = @intervalo, Mensal = @mensal, Dia_do_Mes = @dia, Ultimo_Dia = @ultimo_dia WHERE ID_Rotina = @id_rotina";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", afazer.Descricao);
                update.Parameters.AddWithValue("@detalhes", afazer.Detalhes);
                update.Parameters.AddWithValue("@minutos", afazer.Minutos);
                update.Parameters.AddWithValue("@id_rotina", afazer.ID_Rotina);
                update.Parameters.AddWithValue("@mensal", afazer.Mensal);

                update.Parameters.AddWithValue("@intervalo", afazer.Intervalo);
                update.Parameters.AddWithValue("@dia", afazer.Dia);
                update.Parameters.AddWithValue("@ultimo_dia", afazer.Ultimo_Dia);
                update.ExecuteNonQuery();
            }

            string comando2 = "UPDATE tbl_Afazeres SET Descricao = @descricao, Detalhes = @detalhes, Minutos = @minutos WHERE ID_Rotina = @id_rotina";

            using (SqlCommand update = new SqlCommand(comando2, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", afazer.Descricao);
                update.Parameters.AddWithValue("@detalhes", afazer.Detalhes);
                update.Parameters.AddWithValue("@minutos", afazer.Minutos);
                update.Parameters.AddWithValue("@id_rotina", afazer.ID_Rotina);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarConclusaoDoAfazer(int id_afazer, bool conclusao)
        {
            string comando = "UPDATE tbl_Afazeres SET Conclusao = @conclusao WHERE ID_Afazer = @id_afazer";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_afazer", id_afazer);
                update.Parameters.AddWithValue("@conclusao", conclusao);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarConclusaoDaRotina(int id_rotina, bool conclusao)
        {
            string comando = "UPDATE tbl_Afazeres SET Conclusao = @conclusao WHERE ID_Rotina = @id_rotina";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_rotina", id_rotina);
                update.Parameters.AddWithValue("@conclusao", conclusao);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarAfazer(int id_afazer)
        {
            string comando = "DELETE FROM tbl_Afazeres WHERE ID_Afazer = @id_afazer";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_afazer", id_afazer);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarAfazerAPartirDaRotina(int id_rotina, DateTime data)
        {
            string comando = "DELETE FROM tbl_Afazeres WHERE ID_Rotina = @id_rotina AND Data = @data";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_rotina", id_rotina);
                delete.Parameters.AddWithValue("@data", data.Date);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarRotina(int id_rotina)
        {
            string comando = "DELETE FROM tbl_Rotinas WHERE ID_Rotina = @id_rotina";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_rotina", id_rotina);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarOrdemDoAfazer(int id_afazer, int nova_ordem)
        {
            string comando = "UPDATE tbl_Afazeres SET Ordem = @nova_ordem WHERE ID_Afazer = @id_afazer";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_afazer", id_afazer);
                update.Parameters.AddWithValue("@nova_ordem", nova_ordem);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarOrdemDoAfazerAPartirDaRotina(int id_rotina, DateTime data, int nova_ordem)
        {
            string comando = "UPDATE tbl_Afazeres SET Ordem = @nova_ordem WHERE ID_Rotina = @id_rotina AND Data = @data";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_rotina", id_rotina);
                update.Parameters.AddWithValue("@nova_ordem", nova_ordem);
                update.Parameters.AddWithValue("@data", data.Date);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarOrdemDaRotina(int id_rotina, int nova_ordem)
        {
            string comando = "UPDATE tbl_Rotinas SET Ordem = @nova_ordem WHERE ID_Rotina = @id_rotina";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_rotina", id_rotina);
                update.Parameters.AddWithValue("@nova_ordem", nova_ordem);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public bool VerificarAfazeresPendentes()
        {
            bool pendentes;

            string comando = "SELECT IIF(COUNT(*) > 0, 1, 0) FROM tbl_Afazeres WHERE Data < CONVERT(DATE, GETDATE()) AND ID_Usuario = @id_usuario AND Conclusao = 0 AND ID_Rotina IS NULL";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                pendentes = Convert.ToBoolean(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return pendentes;
        }

        public bool VerificarRotinasALancar()
        {
            bool pendentes;

            string comando = "SELECT IIF(COUNT(*) > 0, 1, 0) FROM tbl_Afazeres WHERE Data < CONVERT(DATE, GETDATE()) AND ID_Usuario = @id_usuario AND Conclusao = 0";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                pendentes = Convert.ToBoolean(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return pendentes;
        }

        public void AtualizarDataDosAfazeresPendentes()
        {
            string comando = "[AtualizarDataDosAfazeresPendentes] @id_usuario";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AgendarAfazerParaAmanha(int id_afazer)
        {
            string comando = "INSERT INTO tbl_Afazeres (Descricao, Detalhes, Minutos, ID_Usuario, Conclusao, Registro, Data, Ordem, ID_Etapa) SELECT Descricao, Detalhes, Minutos, ID_Usuario, 0, GETDATE(), DATEADD(DAY, 1, CONVERT(DATE, GETDATE())), (SELECT COUNT(*) FROM tbl_Afazeres WHERE Data = DATEADD(DAY, 1, CONVERT(DATE, GETDATE())) AND ID_Usuario = @id_usuario) + 1, ID_Etapa FROM tbl_Afazeres WHERE ID_Afazer = @id_afazer";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_afazer", id_afazer);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void DefinirRotinasDoDia()
        {
            List<Rotina> rotinas = new List<Rotina>();

            int dia = DateTime.Now.Day;
            int mes = DateTime.Now.Month;
            int ano = DateTime.Now.Year;

            string comando = "SELECT ID_Rotina, Descricao, Detalhes, Minutos, Ordem, ISNULL(Mensal, 0), Intervalo, ISNULL(Dia_do_Mes, 0), ISNULL(Ultimo_Dia, 0), (SELECT COUNT(*) FROM tbl_Afazeres WHERE ID_Rotina = tbl_Rotinas.ID_Rotina AND Data = CONVERT(DATE, GETDATE())) AS Lancado, (SELECT TOP(1) Data FROM tbl_Afazeres WHERE ID_Rotina = tbl_Rotinas.ID_Rotina ORDER BY Data DESC) AS Ultimo FROM tbl_Rotinas WHERE ID_Usuario = @id_usuario ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Rotina rotina = new Rotina();

                        rotina.ID_Rotina = Convert.ToInt32(leitor[0]);
                        rotina.Descricao = leitor[1].ToString();
                        rotina.Detalhes = leitor[2].ToString();
                        rotina.Minutos = Convert.ToInt32(leitor[3]);
                        rotina.Ordem = Convert.ToInt32(leitor[4]);
                        rotina.Mensal = Convert.ToBoolean(leitor[5]);
                        rotina.Intervalo = Convert.ToInt32(leitor[6]);
                        rotina.Dia = Convert.ToInt32(leitor[7]);
                        rotina.Ultimo_Dia = Convert.ToBoolean(leitor[8]);

                        bool lançado = Convert.ToBoolean(leitor[9]);
                        DateTime ultimo_lançamento = Convert.ToDateTime(leitor[10]);

                        int dias_do_mes = DateTime.DaysInMonth(ano, mes);

                        //Se a rotina não foi lançada ainda...

                        if (!lançado)
                        {
                            if (rotina.Mensal)
                            {
                                if (dia == dias_do_mes && rotina.Ultimo_Dia)
                                {
                                    rotinas.Add(rotina);
                                }
                                else if (rotina.Dia == dia)
                                {
                                    rotinas.Add(rotina);
                                }
                            }
                            else
                            {
                                if (ultimo_lançamento.AddDays(rotina.Intervalo).Date <= DateTime.Now.Date)
                                {
                                    rotinas.Add(rotina);
                                }
                            }
                        }
                    }
                }

                foreach (Rotina rotina in rotinas)
                {
                    rotina.Rotina = true;
                    rotina.Data = DateTime.Now.Date;

                    AdicionarRotinaAosAfazeresAutomaticamente(rotina);
                }
            }

            conexao.Desconectar();
        }

        public void AdicionarRotinaAosAfazeresAutomaticamente(Rotina afazer)
        {
            string comando = "INSERT INTO tbl_Afazeres (Ordem, Descricao, Detalhes, Minutos, ID_Usuario, Conclusao, Registro, Data, ID_Rotina) VALUES ((SELECT COUNT(*) FROM tbl_Afazeres WHERE Data = @data AND ID_Usuario = @id_usuario AND ID_Rotina IS NOT NULL) + 1, @descricao, @detalhes, @minutos, @id_usuario, 0, GETDATE(), @data, @id_rotina)";
            
            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", afazer.Descricao);
                insert.Parameters.AddWithValue("@id_rotina", afazer.ID_Rotina);
                insert.Parameters.AddWithValue("@detalhes", afazer.Detalhes);
                insert.Parameters.AddWithValue("@minutos", afazer.Minutos);
                insert.Parameters.AddWithValue("@data", afazer.Data);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }
        #endregion

        #region Logins
        public List<Login> ListaDeLogins()
        {
            List<Login> logins = new List<Login>();
            string comando = "SELECT ID_Login, Descricao FROM tbl_Logins WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        logins.Add(new Login
                        {
                            ID_Login = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return logins;
        }

        public Login InformacoesDoLogin(int id_login)
        {
            Login login = new Login();
            string comando = "SELECT Descricao, Login, Senha FROM tbl_Logins WHERE ID_Login = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_login);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        login.ID_Login = id_login;
                        login.Descricao = leitor[0].ToString();
                        login.Log_in = leitor[1].ToString();
                        login.Senha = leitor[2].ToString();
                    }
                }
            }

            conexao.Desconectar();

            return login;
        }

        public void CadastrarLogin(Login login)
        {
            string comando = "INSERT INTO tbl_Logins (Descricao, Login, Senha, ID_Usuario) VALUES (@descricao, @login, @senha, @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", login.Descricao);
                insert.Parameters.AddWithValue("@login", login.Log_in);
                insert.Parameters.AddWithValue("@senha", login.Senha);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Login registrado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EditarLogin(Login login)
        {
            string comando = "UPDATE tbl_Logins SET Descricao = @descricao, Login = @login, Senha = @senha WHERE ID_Login = @id_login";
            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_login", login.ID_Login);
                update.Parameters.AddWithValue("@descricao", login.Descricao);
                update.Parameters.AddWithValue("@login", login.Log_in);
                update.Parameters.AddWithValue("@senha", login.Senha);

                update.ExecuteNonQuery();
            }
            conexao.Desconectar();

            MessageBox.Show("Login editado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ApagarLogin(int id)
        {
            string comando = "DELETE FROM tbl_Logins WHERE ID_Login = @id";
            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }
            conexao.Desconectar();

            MessageBox.Show("Login apagado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Treinamentos

        #region Grupos Musculares

        public void AdicionarGrupoMuscular(GrupoMuscular grupo)
        {
            string comando = "INSERT INTO tbl_GrupoMuscular (Descricao, ID_Usuario) VALUES (@descricao, @id_usuario) ";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@descricao", grupo.Descricao);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarGrupoMuscular(GrupoMuscular grupo)
        {
            string comando = "UPDATE tbl_GrupoMuscular SET Descricao = @descricao WHERE ID_Grupo = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", grupo.ID_Grupo);
                update.Parameters.AddWithValue("@descricao", grupo.Descricao);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarGrupoMuscular(int id)
        {
            string comando = "DELETE FROM tbl_GrupoMuscular WHERE ID_Grupo = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarExerciciosDoGrupoMuscular(int id)
        {
            string comando = "DELETE FROM tbl_Exercicios WHERE ID_Grupo = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public GrupoMuscular TrazerGrupoMuscular(int id)
        {
            GrupoMuscular grupo = new GrupoMuscular();

            string comando = "SELECT Descricao FROM tbl_GrupoMuscular WHERE ID_Grupo = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        grupo.ID_Grupo = id;
                        grupo.Descricao = leitor[0].ToString();
                    }
                }
            }

            conexao.Desconectar();

            return grupo;
        }

        public List<GrupoMuscular> TrazerGruposMusculares()
        {
            List<GrupoMuscular> grupos = new List<GrupoMuscular>();

            string comando = "SELECT ID_Grupo, Descricao FROM tbl_GrupoMuscular WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        grupos.Add(new GrupoMuscular
                        {
                            ID_Grupo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            return grupos;
        }

        #endregion

        #region Frases motivacionais

        public void AdicionarFraseMotivacional(FraseMotivacional frase)
        {
            string comando = "INSERT INTO tbl_FrasesMotivacionais (Descricao, ID_Usuario) VALUES (@descricao, @id_usuario) ";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@descricao", frase.Descricao);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarFraseMotivacional(FraseMotivacional frase)
        {
            string comando = "UPDATE tbl_FrasesMotivacionais SET Descricao = @descricao WHERE ID_Frase = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", frase.ID_Frase);
                update.Parameters.AddWithValue("@descricao", frase.Descricao);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarFraseMotivacional(int id)
        {
            string comando = "DELETE FROM tbl_FrasesMotivacionais WHERE ID_Frase = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public FraseMotivacional TrazerFraseMotivacional(int id)
        {
            FraseMotivacional frase = new FraseMotivacional();

            string comando = "SELECT Descricao FROM tbl_FrasesMotivacionais WHERE ID_Frase = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        frase.ID_Frase = id;
                        frase.Descricao = leitor[0].ToString();
                    }
                }
            }

            conexao.Desconectar();

            return frase;
        }

        public List<FraseMotivacional> TrazerFrasesMotivacionais()
        {
            List<FraseMotivacional> frases = new List<FraseMotivacional>();

            string comando = "SELECT ID_Frase, Descricao FROM tbl_FrasesMotivacionais WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        frases.Add(new FraseMotivacional
                        {
                            ID_Frase = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            return frases;
        }

        #endregion

        #region Exercícios

        public List<Exercicio> GruposMuscularesEExercicios()
        {
            List<Exercicio> exercicios = new List<Exercicio>();

            string comando = "SELECT 0 AS ID_Grupo, Descricao, ID_Grupo AS ID_Exercicio FROM tbl_GrupoMuscular WHERE ID_Usuario = @id_usuario UNION SELECT ID_Grupo, Descricao, ID_Exercicio FROM tbl_Exercicios WHERE ID_Usuario = @id_usuario ORDER BY ID_Grupo, Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        exercicios.Add(new Exercicio
                        {
                            ID_Grupo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            ID_Exercicio = Convert.ToInt32(leitor[2])
                        });
                    }
                }
            }

            return exercicios;
        }

        public void AdicionarExercicio(Exercicio exercicio)
        {
            string comando = "INSERT INTO tbl_Exercicios (Descricao, Aerobico, ID_Grupo, ID_Usuario) VALUES (@descricao, @aerobico, @id_grupo, @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@descricao", exercicio.Descricao);
                insert.Parameters.AddWithValue("@aerobico", exercicio.Aerobico);
                insert.Parameters.AddWithValue("@id_grupo", exercicio.ID_Grupo);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarExercicio(Exercicio exercicio)
        {
            string comando = "UPDATE tbl_Exercicios SET Descricao = @descricao, Aerobico = @aerobico, ID_Grupo = @id_grupo WHERE ID_Exercicio = @id_exercicio";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_exercicio", exercicio.ID_Exercicio);
                update.Parameters.AddWithValue("@descricao", exercicio.Descricao);
                update.Parameters.AddWithValue("@aerobico", exercicio.Aerobico);
                update.Parameters.AddWithValue("@id_grupo", exercicio.ID_Grupo);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarExercicio(int id)
        {
            string comando = "DELETE FROM tbl_Exercicios WHERE ID_Exercicio = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Exercicio TrazerExercicio(int id)
        {
            Exercicio exercicio = new Exercicio();

            string comando = "SELECT Descricao, Aerobico, ID_Grupo FROM tbl_Exercicios WHERE ID_Exercicio = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        exercicio.ID_Exercicio = id;
                        exercicio.Descricao = leitor[0].ToString();
                        exercicio.Aerobico = Convert.ToBoolean(leitor[1]);
                        exercicio.ID_Grupo = Convert.ToInt32(leitor[2]);
                    }
                }
            }

            conexao.Desconectar();

            return exercicio;
        }

        public List<GrupoMuscular> PreencherComboGruposMusculares()
        {
            List<GrupoMuscular> grupos = new List<GrupoMuscular>();

            string comando = "SELECT ID_Grupo, Descricao FROM tbl_GrupoMuscular WHERE ID_Usuario = @id_usuario ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        grupos.Add(new GrupoMuscular
                        {
                            ID_Grupo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return grupos;
        }

        #endregion

        #region Treinos

        public List<Treino> TrazerTreinos()
        {
            List<Treino> treinos = new List<Treino>();

            string comando = "SELECT ID_Treino, Descricao, STUFF((SELECT DISTINCT '/' + (SELECT Descricao FROM tbl_GrupoMuscular WHERE ID_Grupo = tbl_TreinoGrupos.ID_Grupo) FROM tbl_TreinoGrupos WHERE tbl_TreinoGrupos.ID_Treino = tbl_Treinos.ID_Treino FOR XML PATH('')), 1,1,'') AS Grupos FROM tbl_Treinos WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        treinos.Add(new Treino
                        {
                            ID_Treino = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Grupos = leitor[2].ToString(),
                        });
                    }
                }
            }

            return treinos;
        }

        public void AdicionarTreino(Treino treino)
        {
            string comando = "INSERT INTO tbl_Treinos (Descricao, ID_Usuario) VALUES (@descricao, @id_usuario) ";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@descricao", treino.Descricao);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarTreino(Treino treino)
        {
            string comando = "UPDATE tbl_Treinos SET Descricao = @descricao WHERE ID_Treino = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", treino.ID_Treino);
                update.Parameters.AddWithValue("@descricao", treino.Descricao);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarTreino(int id)
        {
            string comando = "DELETE FROM tbl_Treinos WHERE ID_Treino = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            string comando2 = "DELETE FROM tbl_TreinoGrupos WHERE ID_Treino = @id";

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            string comando3 = "DELETE FROM tbl_TreinosExercicios WHERE ID_Treino = @id";

            using (SqlCommand delete = new SqlCommand(comando3, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Treino TrazerTreino(int id)
        {
            Treino treino = new Treino();

            string comando = "SELECT Descricao FROM tbl_Treinos WHERE ID_Frase = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        treino.ID_Treino = id;
                        treino.Descricao = leitor[0].ToString();
                    }
                }
            }

            conexao.Desconectar();

            return treino;
        }

        public List<GrupoMuscular> TrazerGruposDoTreino(int ID_Treino)
        {
            List<GrupoMuscular> grupos = new List<GrupoMuscular>();

            string comando = "SELECT ID_Grupo, Descricao, IIF((SELECT COUNT(*) FROM tbl_TreinoGrupos WHERE ID_Treino = @id_treino AND ID_Grupo = tbl_GrupoMuscular.ID_Grupo) > 0, 1, 0) FROM tbl_GrupoMuscular WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@id_treino", ID_Treino);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        grupos.Add(new GrupoMuscular
                        {
                            ID_Grupo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Check = Convert.ToBoolean(leitor[2])
                        });
                    }
                }
            }

            return grupos;
        }

        public void AdicionarGrupoAoTreino(int id_treino, int id_grupo)
        {
            string comando = "INSERT INTO tbl_TreinoGrupos (ID_Treino, ID_Grupo) VALUES (@id_treino, @id_grupo)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_treino", id_treino);
                insert.Parameters.AddWithValue("@id_grupo", id_grupo);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void RemoverGrupoDoTreino(int id_treino, int id_grupo)
        {
            string comando = "DELETE FROM tbl_TreinoGrupos WHERE ID_Treino = @id_treino AND ID_Grupo = @id_grupo";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_treino", id_treino);
                delete.Parameters.AddWithValue("@id_grupo", id_grupo);
                delete.ExecuteNonQuery();
            }

            string comando2 = "DELETE FROM tbl_TreinosExercicios WHERE ID_Treino = @id_treino AND ID_Grupo = @id_grupo";

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_treino", id_treino);
                delete.Parameters.AddWithValue("@id_grupo", id_grupo);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public List<Exercicio> TrazerExerciciosDoTreino(int ID_Treino)
        {
            List<Exercicio> exercicios = new List<Exercicio>();

            string comando = "SELECT Ordem, (SELECT Descricao FROM tbl_Exercicios WHERE ID_Exercicio = tbl_TreinosExercicios.ID_Exercicio) AS Descricao, 1, ID_Grupo, Tipo, Ajuste, Series, ID_Exercicio, Peso FROM tbl_TreinosExercicios WHERE ID_Treino = @id_treino UNION SELECT 0 AS ordem, Descricao, 0 AS Contem, ID_Grupo, 'Regular' AS Tipo, '' AS Ajuste, '3X10' as Series, ID_Exercicio, '' AS Peso FROM tbl_Exercicios WHERE (SELECT COUNT(*) FROM tbl_TreinosExercicios WHERE ID_Treino = @id_treino AND ID_Exercicio = tbl_Exercicios.ID_Exercicio) = 0";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_treino", ID_Treino);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        exercicios.Add(new Exercicio
                        {
                            Ordem = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Check = Convert.ToBoolean(leitor[2]),
                            ID_Grupo = Convert.ToInt32(leitor[3]),
                            Tipo = leitor[4].ToString(),
                            Ajuste = leitor[5].ToString(),
                            Series = leitor[6].ToString(),
                            ID_Exercicio = Convert.ToInt32(leitor[7]),
                            Peso = leitor[8].ToString()
                        });
                    }
                }
            }

            return exercicios;
        }

        public int TrazerUltimoTreinoCadastrado()
        {
            int id = 0;

            string comando = "SELECT TOP(1) ID_Treino FROM tbl_Treinos ORDER BY ID_Treino DESC";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                id = Convert.ToInt32(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return id;
        }

        public void AdicionarExercicioAoTreino(int id_treino, Exercicio exercicio)
        {
            string comando = "INSERT INTO tbl_TreinosExercicios (ID_Treino, ID_Exercicio, Tipo, Ajuste, ID_Grupo, Series, Ordem, Peso) VALUES (@id_treino, @id_exercicio, @tipo, @ajuste, @id_grupo, @series, (SELECT COUNT(*) FROM tbl_TreinosExercicios WHERE ID_Treino = @id_treino AND ID_Grupo = @id_grupo) + 1, @peso)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_treino", id_treino);
                insert.Parameters.AddWithValue("@id_grupo", exercicio.ID_Grupo);
                insert.Parameters.AddWithValue("@id_exercicio", exercicio.ID_Exercicio);
                insert.Parameters.AddWithValue("@tipo", exercicio.Tipo);
                insert.Parameters.AddWithValue("@ajuste", exercicio.Ajuste);
                insert.Parameters.AddWithValue("@series", exercicio.Series);
                insert.Parameters.AddWithValue("@peso", exercicio.Peso);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void RemoverExercicioDoTreino(int id_treino, int id_exercicio)
        {
            string comando = "DELETE FROM tbl_TreinosExercicios WHERE ID_Treino = @id_treino AND ID_Exercicio = @id_exercicio";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_treino", id_treino);
                delete.Parameters.AddWithValue("@id_exercicio", id_exercicio);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarConfiguracoesDoExercicio(Exercicio exercicio, int id_treino)
        {
            string comando = "UPDATE tbl_TreinosExercicios SET Tipo = @tipo, Ajuste = @ajuste, Series = @series, Peso = @peso WHERE ID_Treino = @id_treino AND ID_Exercicio = @id_exercicio";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_treino", id_treino);
                update.Parameters.AddWithValue("@id_exercicio", exercicio.ID_Exercicio);
                update.Parameters.AddWithValue("@tipo", exercicio.Tipo);
                update.Parameters.AddWithValue("@ajuste", exercicio.Ajuste);
                update.Parameters.AddWithValue("@series", exercicio.Series);
                update.Parameters.AddWithValue("@peso", exercicio.Peso);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarOrdemDoExercicio(int id_exercicio, int id_treino, int id_grupo, int nova_ordem)
        {
            string comando = "UPDATE tbl_TreinosExercicios SET Ordem = @nova_ordem WHERE ID_Exercicio = @id_exercicio AND ID_Grupo = @id_grupo AND ID_Treino = @id_treino";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_exercicio", id_exercicio);
                update.Parameters.AddWithValue("@id_treino", id_treino);
                update.Parameters.AddWithValue("@id_grupo", id_grupo);
                update.Parameters.AddWithValue("@nova_ordem", nova_ordem);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ImprimirTreino(int id_treino, bool imprimir)
        {
            string treino = string.Empty;
            string usuario = string.Empty;
            List<Exercicio> exercicios = new List<Exercicio>();

            string cmd1 = "SELECT Descricao, (SELECT Nome FROM tbl_Usuarios WHERE ID_Usuario = tbl_Treinos.ID_Usuario) AS Usuario FROM tbl_Treinos WHERE ID_Treino = @id_treino";

            using (SqlCommand select = new SqlCommand(cmd1, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_treino", id_treino);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        treino = leitor[0].ToString();
                        usuario = leitor[1].ToString();
                    }
                }
            }

            string cmd2 = "SELECT Ordem, (SELECT Descricao FROM tbl_Exercicios WHERE ID_Exercicio = tbl_TreinosExercicios.ID_Exercicio) AS Exercicio, (SELECT Descricao FROM tbl_GrupoMuscular WHERE ID_Grupo = tbl_TreinosExercicios.ID_Grupo) AS Grupo, Series, Ajuste, Peso, Tipo FROM tbl_TreinosExercicios WHERE ID_Treino = @id_treino ORDER BY ID_Grupo, Ordem";

            using (SqlCommand select = new SqlCommand(cmd2, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_treino", id_treino);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        exercicios.Add(new Exercicio
                        {
                            Ordem = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Grupo = leitor[2].ToString(),
                            Series = leitor[3].ToString(),
                            Ajuste = leitor[4].ToString(),
                            Peso = leitor[5].ToString(), 
                            Tipo = leitor[6].ToString()
                        });
                    }

                }
            }

            formRepTreino relatorio = new formRepTreino();
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("treino", treino));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("usuario", usuario));


            relatorio.reportViewer1.LocalReport.DataSources.Clear();
            relatorio.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetExercicios", exercicios));

            relatorio.reportViewer1.RefreshReport();

            if (imprimir)
            {
                AutoPrintCls autoprintme = new AutoPrintCls(relatorio.reportViewer1.LocalReport);
                //autoprintme.PrinterSettings.PrinterName = Program.Computador.Impressora_Termica;
                autoprintme.Print();
            }
            else
            {
                AutoPrintCls autoprintme = new AutoPrintCls(relatorio.reportViewer1.LocalReport);
                autoprintme.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                autoprintme.Print();
            }

        }

        #endregion

        #endregion

        #region Metas

        #region Objetivos

        public void CadastrarObjetivo(Objetivo objetivo)
        {
            string comando = "INSERT INTO tbl_Objetivos (Descricao, Inicio, Termino, Status, ID_Usuario) VALUES (@descricao, @inicio, @termino, 'Pendente', @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", objetivo.Descricao);
                insert.Parameters.AddWithValue("@inicio", objetivo.Inicio);
                insert.Parameters.AddWithValue("@termino", objetivo.Termino);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarObjetivo(Objetivo objetivo)
        {
            string comando = "UPDATE tbl_Objetivos SET Descricao = @descricao, Inicio = @inicio, Termino = @termino WHERE ID_Objetivo = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", objetivo.ID_Objetivo);
                update.Parameters.AddWithValue("@descricao", objetivo.Descricao);
                update.Parameters.AddWithValue("@inicio", objetivo.Inicio);
                update.Parameters.AddWithValue("@termino", objetivo.Termino);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarObjetivo(int id)
        {

            string comando1 = "DELETE FROM tbl_Iniciativas WHERE (SELECT ID_Objetivo FROM tbl_Resultados WHERE ID_Resultado = tbl_Iniciativas.ID_Resultado) = @id";
            string comando4 = "DELETE FROM tbl_ResultadosAcompanhamento WHERE (SELECT ID_Objetivo FROM tbl_Resultados WHERE ID_Resultado = tbl_ResultadosAcompanhamento.ID_Resultado) = @id";
            string comando2 = "DELETE FROM tbl_Resultados WHERE ID_Objetivo = @id";
            string comando3 = "DELETE FROM tbl_RecompensasObjetivos WHERE ID_Objetivo = @id";
            string comando = "DELETE FROM tbl_Objetivos WHERE ID_Objetivo = @id";

            using (SqlCommand delete = new SqlCommand(comando1, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(comando4, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(comando3, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Objetivo TrazerObjetivo(int id)
        {
            Objetivo objetivo = new Objetivo();

            string comando = "SELECT Descricao, Inicio, Termino FROM tbl_Objetivos WHERE ID_Objetivo = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        objetivo.Descricao = leitor[0].ToString();
                        objetivo.Inicio = Convert.ToDateTime(leitor[1]);
                        objetivo.Termino = Convert.ToDateTime(leitor[2]);
                    }
                }
            }

            conexao.Desconectar();

            return objetivo;
        }

        public List<Objetivo> TrazerObjetivos(DateTime data)
        {
            List<Objetivo> objetivos = new List<Objetivo>();

            string comando = "SELECT ID_Objetivo, Descricao, Inicio, Termino, Status FROM tbl_Objetivos WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        objetivos.Add(new Objetivo
                        {
                            ID_Objetivo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Inicio = Convert.ToDateTime(leitor[2]),
                            Termino = Convert.ToDateTime(leitor[3]),
                            Status = leitor[4].ToString()
                        });
                    }
                }
            }

            List<Acompanhamento> resultados = new List<Acompanhamento>();

            string cmd = "SELECT ID_Objetivo, ISNULL((SELECT TOP(1) Valor FROM tbl_ResultadosAcompanhamento WHERE ID_Resultado = tbl_Resultados.ID_Resultado AND Data <= @data ORDER BY Data DESC) / ((Meta - Valor_inicial) / 100), 0) FROM tbl_Resultados WHERE (SELECT ID_Usuario FROM tbl_Objetivos WHERE ID_Objetivo = tbl_Resultados.ID_Objetivo) = @id_usuario";

            using (SqlCommand select = new SqlCommand(cmd, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                select.Parameters.AddWithValue("@data", data);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        resultados.Add(new Acompanhamento
                        {
                            ID_Objetivo = Convert.ToInt32(leitor[0]),
                            Atual = Convert.ToDecimal(leitor[1])
                        });
                    }
                }

            }
            foreach (Objetivo objetivo in objetivos)
            {
                int qtd_resultados = resultados.Where(x => x.ID_Objetivo == objetivo.ID_Objetivo).Count();
                decimal valores = resultados.Where(x => x.ID_Objetivo == objetivo.ID_Objetivo).Sum(x => x.Atual);

                try { objetivo.Progresso = valores / qtd_resultados; }
                catch { objetivo.Progresso = 0; }

            }

            return objetivos;
        }

        public void AlterarStatusDoObjetivo(Objetivo objetivo)
        {
            string comando = "UPDATE tbl_Objetivos SET Status = @status WHERE ID_Objetivo = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", objetivo.ID_Objetivo);
                update.Parameters.AddWithValue("@status", objetivo.Status);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #region Resultados-chave

        public void CadastrarResultado(Resultado resultado)
        {
            string comando = "INSERT INTO tbl_Resultados (ID_Objetivo, Descricao, Valor_Inicial, Meta, Un_Medida, Agressividade, Periodicidade) VALUES (@id_objetivo, @descricao, @inicial, @meta, @un, @agressividade, @periodicidade)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_objetivo", resultado.ID_Objetivo);
                insert.Parameters.AddWithValue("@descricao", resultado.Descricao);
                insert.Parameters.AddWithValue("@inicial", resultado.Inicial);
                insert.Parameters.AddWithValue("@meta", resultado.Meta);
                insert.Parameters.AddWithValue("@un", resultado.Un_Medida);
                insert.Parameters.AddWithValue("@agressividade", resultado.Agressividade);
                insert.Parameters.AddWithValue("@periodicidade", resultado.Periodicidade);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();

            DefinirAcompanhamentos(resultado);
        }

        public void DefinirAcompanhamentos(Resultado resultado)
        {
            Objetivo objetivo = new Objetivo();
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();

            string comando = "SELECT Inicio, Termino FROM tbl_Objetivos WHERE ID_Objetivo = @id_objetivo";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_objetivo", resultado.ID_Objetivo);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        objetivo.Inicio = Convert.ToDateTime(leitor[0]);
                        objetivo.Termino = Convert.ToDateTime(leitor[1]);
                    }
                }
            }

            conexao.Desconectar();

            for (DateTime data = objetivo.Inicio; data < objetivo.Termino; data = data.AddDays(resultado.Periodicidade))
            {
                if (data != objetivo.Inicio)
                {
                    acompanhamentos.Add(new Acompanhamento
                    {
                        Atual = 0,
                        Data = data
                    });
                }
            }

            acompanhamentos.Add(new Acompanhamento { Atual = 0, Data = objetivo.Termino });

            string cmd = "INSERT INTO tbl_ResultadosAcompanhamento (ID_Resultado, Data, Valor) VALUES ((SELECT TOP(1) ID_Resultado FROM tbl_Resultados ORDER BY ID_Resultado DESC), @data, @valor)";

            foreach (Acompanhamento acompanhamento in acompanhamentos)
            {
                using (SqlCommand insert = new SqlCommand(cmd, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@id_resultado", resultado.ID_Resultado);
                    insert.Parameters.AddWithValue("@data", acompanhamento.Data);
                    insert.Parameters.AddWithValue("@valor", acompanhamento.Atual);

                    insert.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();
        }

        public void EditarResultado(Resultado resultado)
        {
            string comando = "UPDATE tbl_Resultados SET Descricao = @descricao, Valor_Inicial = @inicial, Meta = @meta, Un_Medida = @un, Agressividade = @agressividade, Periodicidade = @periodicidade WHERE ID_Resultado = @id_resultado";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", resultado.Descricao);
                update.Parameters.AddWithValue("@inicial", resultado.Inicial);
                update.Parameters.AddWithValue("@meta", resultado.Meta);
                update.Parameters.AddWithValue("@un", resultado.Un_Medida);
                update.Parameters.AddWithValue("@agressividade", resultado.Agressividade);
                update.Parameters.AddWithValue("@periodicidade", resultado.Periodicidade);
                update.Parameters.AddWithValue("@id_resultado", resultado.ID_Resultado);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarResultado(int id)
        {
            string comando = "DELETE FROM tbl_Resultados WHERE ID_Resultado = @id";
            string cmd = "DELETE FROM Iniciativas WHERE ID_Resultado = @id";
            string cmd1 = "DELETE FROM tbl_ResultadosAcompanhamento WHERE ID_Resultado = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(cmd, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(cmd1, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Resultado TrazerResultado(int id)
        {
            Resultado resultado = new Resultado();

            string comando = "SELECT Descricao, Valor_Inicial, Meta, Un_Medida, Agressividade, Periodicidade FROM tbl_Resultados WHERE ID_Resultado = @id_resultado";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_resultado", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        resultado.Descricao = leitor[0].ToString();
                        resultado.Inicial = Convert.ToDecimal(leitor[1]);
                        resultado.Meta = Convert.ToDecimal(leitor[2]);
                        resultado.Un_Medida = leitor[3].ToString();
                        resultado.Agressividade = leitor[4].ToString();
                        resultado.Periodicidade = Convert.ToInt32(leitor[5]);
                    }
                }
            }

            conexao.Desconectar();

            return resultado;
        }

        public List<Resultado> TrazerResultados(int id_objetivo, DateTime data)
        {
            List<Resultado> resultados = new List<Resultado>();

            string comando = "SELECT ID_Resultado, Descricao, ISNULL((SELECT TOP(1) Valor FROM tbl_ResultadosAcompanhamento WHERE ID_Resultado = tbl_Resultados.ID_Resultado AND Data <= @data ORDER BY Data DESC) / ((Meta - Valor_inicial) / 100), 0) FROM tbl_Resultados WHERE ID_Objetivo = @id_objetivo";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_objetivo", id_objetivo);
                select.Parameters.AddWithValue("@data", data.Date);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        resultados.Add(new Resultado
                        {
                            ID_Resultado = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Progresso = Convert.ToDecimal(leitor[2])
                        });
                    }
                }
            }

            return resultados;
        }

        public List<Acompanhamento> TrazerAcompanhamento(int id_resultado)
        {
            List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();

            string comando = "SELECT ID_ResultadoAcompanhamento, Data, Valor FROM tbl_ResultadosAcompanhamento WHERE ID_Resultado = @id_resultado";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_resultado", id_resultado);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        acompanhamentos.Add(new Acompanhamento
                        {
                            ID_Acompanhamento = Convert.ToInt32(leitor[0]),
                            Data = Convert.ToDateTime(leitor[1]),
                            Atual = Convert.ToDecimal(leitor[2])
                        });
                    }
                }
            }

            return acompanhamentos;
        }

        public void EditarAcompanhamento(Acompanhamento acompanhamento)
        {
            string comando = "UPDATE tbl_ResultadosAcompanhamento SET Data = @data, Valor = @atual WHERE ID_ResultadoAcompanhamento = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@data", acompanhamento.Data);
                update.Parameters.AddWithValue("@atual", acompanhamento.Atual);
                update.Parameters.AddWithValue("@id", acompanhamento.ID_Acompanhamento);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarAcompanhamento(int id)
        {
            string comando = "DELETE FROM tbl_ResultadosAcompanhamento WHERE ID_ResultadoAcompanhamento = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Excluído.", "Excluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Resultado NivelDoAcompanhamento(int id_resultado)
        {
            Resultado resultado = new Resultado();

            string comando = "SELECT Valor_Inicial, Meta, (SELECT Inicio FROM tbl_Objetivos WHERE ID_Objetivo = tbl_Resultados.ID_Objetivo) AS Inicio, (SELECT Termino FROM tbl_Objetivos WHERE ID_Objetivo = tbl_Resultados.ID_Objetivo) AS Termino FROM tbl_Resultados WHERE ID_Resultado = @id_resultado";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_resultado", id_resultado);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        resultado.Inicial = Convert.ToDecimal(leitor[0]);
                        resultado.Meta = Convert.ToDecimal(leitor[1]);
                        resultado.Inicio = Convert.ToDateTime(leitor[2]);
                        resultado.Termino = Convert.ToDateTime(leitor[3]);
                    }
                }
            }

            conexao.Desconectar();

            return resultado;
        }

        #endregion

        #region Iniciativas

        public void CadastrarIniciativa(Iniciativa iniciativa)
        {
            string comando = "INSERT INTO tbl_Iniciativas (ID_Resultado, Descricao, Detalhes, Status, Referencia) VALUES (@id_resultado, @descricao, @detalhes, 'Pendente', @referencia)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_resultado", iniciativa.ID_Resultado);
                insert.Parameters.AddWithValue("@descricao", iniciativa.Descricao);
                insert.Parameters.AddWithValue("@detalhes", iniciativa.Detalhes);
                insert.Parameters.AddWithValue("@referencia", iniciativa.Referencia);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarIniciativa(Iniciativa iniciativa)
        {
            string comando = "UPDATE tbl_Iniciativas SET Descricao = @descricao, Detalhes = @detalhes, Referencia = @referencia WHERE ID_Iniciativa = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", iniciativa.ID_Iniciativa);
                update.Parameters.AddWithValue("@descricao", iniciativa.Descricao);
                update.Parameters.AddWithValue("@detalhes", iniciativa.Detalhes);
                update.Parameters.AddWithValue("@referencia", iniciativa.Referencia);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarIniciativa(int id)
        {
            string comando = "DELETE FROM tbl_Iniciativas WHERE ID_Iniciativa = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Iniciativa TrazerIniciativa(int id)
        {
            Iniciativa iniciativa = new Iniciativa();

            string comando = "SELECT Descricao, Detalhes, Referencia FROM tbl_Iniciativas WHERE ID_Iniciativa = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        iniciativa.Descricao = leitor[0].ToString();
                        iniciativa.Detalhes = leitor[1].ToString();
                        iniciativa.Referencia = leitor[2].ToString();
                    }
                }
            }

            conexao.Desconectar();

            return iniciativa;
        }

        public List<Iniciativa> TrazerIniciativas(int id_resultado)
        {
            List<Iniciativa> iniciativas = new List<Iniciativa>();

            string comando = "SELECT ID_Iniciativa, Descricao, Detalhes, Referencia, Status FROM tbl_Iniciativas WHERE ID_Resultado = @id_resultado";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_resultado", id_resultado);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        iniciativas.Add(new Iniciativa
                        {
                            ID_Iniciativa = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Detalhes = leitor[2].ToString(),
                            Referencia = leitor[3].ToString(),
                            Status = leitor[4].ToString(),
                            ID_Resultado = id_resultado
                        });
                    }
                }
            }

            return iniciativas;
        }

        public void AlterarStatusDaIniciativa(Iniciativa iniciativa)
        {
            string comando = "UPDATE tbl_iniciativas SET Status = @status WHERE ID_Iniciativa = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", iniciativa.ID_Iniciativa);
                update.Parameters.AddWithValue("@status", iniciativa.Status);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #region Recompensas

        public void CadastrarRecompensa(string descricao)
        {
            string comando = "INSERT INTO tbl_Recompensas (Descricao, Status, ID_Usuario) VALUES (@descricao, 'Pendente', @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", descricao);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarRecompensa(Recompensa recompensa)
        {
            string comando = "UPDATE tbl_Recompensas SET Descricao = @descricao WHERE ID_Recompensa = @id_recompensa";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_recompensa", recompensa.ID_Recompensa);
                update.Parameters.AddWithValue("@descricao", recompensa.Descricao);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarRecompensa(int id_recompensa)
        {
            string comando = "DELETE FROM tbl_Recompensas WHERE ID_Recompensa = @id_recompensa";
            string comando2 = "DELETE FROM tbl_RecompensasObjetivos WHERE ID_Recompensa = @id_recompensa";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_recompensa", id_recompensa);
                delete.ExecuteNonQuery();
            }

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_recompensa", id_recompensa);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Excluído.", "Excluído!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Recompensa TrazerRecompensa(int id)
        {
            Recompensa recompensa = new Recompensa();

            string comando = "SELECT Descricao FROM tbl_Recompensas WHERE ID_Recompensa = @id_recompensa";
            string comando2 = "SELECT ID_Objetivo, (SELECT Descricao FROM tbl_Objetivos WHERE ID_Objetivo = tbl_RecompensasObjetivos.ID_Objetivo) FROM tbl_RecompensasObjetivos WHERE ID_Recompensa = @id_recompensa";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_recompensa", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        recompensa.ID_Recompensa = id;
                        recompensa.Descricao = leitor[0].ToString();
                        recompensa.Objetivos = new List<Objetivo>();
                    }
                }
            }

            using (SqlCommand select = new SqlCommand(comando2, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_recompensa", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        recompensa.Objetivos.Add(new Objetivo
                        {
                            ID_Objetivo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return recompensa;
        }

        public Recompensa TrazerRecompensa()
        {
            Recompensa recompensa = new Recompensa();

            string comando = "SELECT ID_Recompensa, Descricao FROM tbl_Recompensas WHERE ID_Recompensa = (SELECT TOP(1) ID_Recompensa FROM tbl_Recompensas WHERE ID_Usuario = @id_usuario ORDER BY ID_Recompensa DESC)";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        recompensa.ID_Recompensa = Convert.ToInt32(leitor[0]);
                        recompensa.Descricao = leitor[1].ToString();
                        recompensa.Objetivos = new List<Objetivo>();
                    }
                }
            }

            conexao.Desconectar();

            return recompensa;
        }

        public List<Objetivo> TrazerObjetivosDaRecompensa(int id_recompensa)
        {
            List<Objetivo> objetivos = new List<Objetivo>();

            string comando = "SELECT ID_Objetivo, (SELECT Descricao FROM tbl_Objetivos WHERE ID_Objetivo = tbl_RecompensasObjetivos.ID_Objetivo) AS Descricao, (SELECT Status FROM tbl_Objetivos WHERE ID_Objetivo = tbl_RecompensasObjetivos.ID_Objetivo) AS Status FROM tbl_RecompensasObjetivos WHERE ID_Recompensa = @id_recompensa";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_recompensa", id_recompensa);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        objetivos.Add(new Objetivo
                        {
                            ID_Objetivo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Status = leitor[2].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return objetivos;
        }

        public List<Recompensa> TrazerRecompensas()
        {
            List<Recompensa> recompensas = new List<Recompensa>();

            string comando = "SELECT ID_Recompensa, Descricao, Status FROM tbl_Recompensas WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        recompensas.Add(new Recompensa
                        {
                            ID_Recompensa = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Status = leitor[2].ToString()
                        });
                    }
                }
            }

            foreach (Recompensa recompensa in recompensas)
            {
                recompensa.Objetivos = TrazerObjetivosDaRecompensa(recompensa.ID_Recompensa);
            }

            return recompensas;
        }

        public List<Objetivo> PreencherComboObjetivos()
        {
            List<Objetivo> lista = new List<Objetivo>();

            string comando = "SELECT ID_Objetivo, Descricao FROM tbl_Objetivos WHERE ID_Usuario = @id_usuario AND Status = 'Pendente'";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(new Objetivo 
                        {
                            ID_Objetivo = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return lista;
        }

        public bool VerificarNomeDoObjetivo(string objetivo)
        {
            string comando = "SELECT IIF(COUNT(*) > 0, 1, 0) FROM tbl_Objetivos WHERE Descricao = @objetivo AND ID_Usuario = @id_usuario";
            bool verificar;

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@objetivo", objetivo);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                verificar = Convert.ToBoolean(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return verificar;
        }

        public void AdicionarObjetivoARecompensa(int id_objetivo, int id_recompensa)
        {
            string comando = "INSERT INTO tbl_RecompensasObjetivos (ID_Recompensa, ID_Objetivo) VALUES (@id_recompensa, @id_objetivo)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_objetivo", id_objetivo);
                insert.Parameters.AddWithValue("@id_recompensa", id_recompensa);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarObjetivoDaRecompensa(int id_objetivo, int id_recompensa)
        {
            string comando = "DELETE FROM tbl_RecompensasObjetivos WHERE ID_Objetivo = @id_objetivo AND ID_Recompensa = @id_recompensa";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_objetivo", id_objetivo);
                delete.Parameters.AddWithValue("@id_recompensa", id_recompensa);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarStatusDaRecompensa(Recompensa recompensa)
        {
            string comando = "UPDATE tbl_Recompensas SET Status = @status WHERE ID_Recompensa = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", recompensa.ID_Recompensa);
                update.Parameters.AddWithValue("@status", recompensa.Status);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #endregion

        #region Plano de Ação

        public List<Plano> ListaDePlanosDeAcao()
        {
            List<Plano> planos = new List<Plano>();

            string comando = "SELECT ID, Descricao, Onde, Conclusao, Arquivado FROM tbl_Planos";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        planos.Add(new Plano
                        {
                            ID_Projeto = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Onde = leitor[2].ToString(),
                            Conclusao = Convert.ToBoolean(leitor[3]),
                            Arquivado = Convert.ToBoolean(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return planos;
        }

        public Plano TrazerInformacoesDoPlanoDeAcao(int id_projeto)
        {
            Plano projeto = new Plano();
            List<Etapa> etapas = new List<Etapa>();
            List<Custo> custos = new List<Custo>();
            List<Checklist> check_list = new List<Checklist>();

            string comando = "SELECT Descricao, O_Que, Por_Que, Onde FROM tbl_Planos WHERE ID = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        projeto.ID_Projeto = id_projeto;
                        projeto.Descricao = leitor[0].ToString();
                        projeto.O_Que = leitor[1].ToString();
                        projeto.Por_Que = leitor[2].ToString();
                        projeto.Onde = leitor[3].ToString();
                    }
                }
            }

            conexao.Desconectar();

            string comando2 = "SELECT ID, Descricao, Como, Prazo, Previsao_Inicio, Ordem FROM tbl_PlanoEtapas WHERE ID_PlanoDeAcao = @id";

            using (SqlCommand select = new SqlCommand(comando2, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        etapas.Add(new Etapa
                        {
                            ID_Etapa = Convert.ToInt32(leitor[0]),
                            O_Que = leitor[1].ToString(),
                            Como = leitor[2].ToString(),
                            Prazo = Convert.ToInt32(leitor[3]),
                            Previsao_Inicio = Convert.ToDateTime(leitor[4]),
                            Ordem = Convert.ToInt32(leitor[5])
                        });
                    }
                }
            }

            conexao.Desconectar();

            string comando3 = "SELECT ID, Ordem, Descricao, Detalhes, Valor, Categoria FROM tbl_PlanoCustos WHERE ID_PlanoDeAcao = @id";

            using (SqlCommand select = new SqlCommand(comando3, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        custos.Add(new Custo
                        {
                            ID = Convert.ToInt32(leitor[0]),
                            Ordem = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Detalhes = leitor[3].ToString(),
                            Valor = Convert.ToInt32(leitor[4]),
                            Categoria = leitor[5].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            string comando4 = "SELECT ID, ID_Etapa, Descricao, Ordem, Confirmacao FROM tbl_EtapasCheckList WHERE (SELECT ID_PlanoDeAcao FROM tbl_PlanoEtapas WHERE ID = ID_Etapa) = @id ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando4, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        check_list.Add(new Checklist
                        {
                            ID = Convert.ToInt32(leitor[0]),
                            Referencia = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Ordem = Convert.ToInt32(leitor[3]),
                            Confirmacao = Convert.ToBoolean(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();


            projeto.Custos = custos;
            projeto.Etapas = etapas;
            projeto.Checklist = check_list;

            return projeto;
        }

        public List<Etapa> AtualizarEtapasDoPlano(int id_projeto)
        {
            List<Etapa> etapas = new List<Etapa>();

            string comando = "SELECT ID, Descricao, Como, Prazo, Previsao_Inicio, Ordem FROM tbl_PlanoEtapas WHERE ID_PlanoDeAcao = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        etapas.Add(new Etapa
                        {
                            ID_Etapa = Convert.ToInt32(leitor[0]),
                            O_Que = leitor[1].ToString(),
                            Como = leitor[2].ToString(),
                            Prazo = Convert.ToInt32(leitor[3]),
                            Previsao_Inicio = Convert.ToDateTime(leitor[4]),
                            Ordem = Convert.ToInt32(leitor[5])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return etapas;
        }

        public List<Checklist> AtualizarCheckListDoPlano(int id_projeto)
        {
            List<Checklist> checklist = new List<Checklist>();

            string comando = "SELECT ID, ID_Etapa, Descricao, Ordem, Confirmacao FROM tbl_EtapasCheckList WHERE (SELECT ID_PlanoDeAcao FROM tbl_PlanoEtapas WHERE ID = ID_Etapa) = @id ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        checklist.Add(new Checklist
                        {
                            ID = Convert.ToInt32(leitor[0]),
                            Referencia = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Ordem = Convert.ToInt32(leitor[3]),
                            Confirmacao = Convert.ToBoolean(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return checklist;
        }

        public List<Custo> AtualizarCustosDoPlano(int id_projeto)
        {
            List<Custo> custos = new List<Custo>();

            string comando = "SELECT ID, Ordem, Descricao, Detalhes, Valor, Categoria FROM tbl_PlanoCustos WHERE ID_PlanoDeAcao = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        custos.Add(new Custo
                        {
                            ID = Convert.ToInt32(leitor[0]),
                            Ordem = Convert.ToInt32(leitor[1]),
                            Descricao = leitor[2].ToString(),
                            Detalhes = leitor[3].ToString(),
                            Valor = Convert.ToInt32(leitor[4]),
                            Categoria = leitor[5].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return custos;
        }

        public void RegistrarPlanoDeAcao(Plano projeto)
        {
            string comando = "INSERT INTO tbl_Planos (Descricao, O_Que, Por_Que, Onde, Registro, Conclusao, Arquivado) VALUES (@descricao, @o_que, @por_que, @onde, GETDATE(), 0, 0)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", projeto.Descricao);
                insert.Parameters.AddWithValue("@o_que", projeto.O_Que);
                insert.Parameters.AddWithValue("@por_que", projeto.Por_Que);
                insert.Parameters.AddWithValue("@onde", projeto.Onde);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();

            string comando2 = "INSERT INTO tbl_PlanoEtapas (Descricao, Como, Prazo, Previsao_Inicio, Conclusao, Ordem, ID_PlanoDeAcao) VALUES (@descricao, @como, @prazo, @previsao, 0, @ordem, (SELECT TOP(1) ID FROM tbl_Planos ORDER BY ID DESC))";

            foreach (Etapa etapa in projeto.Etapas)
            {
                using (SqlCommand insert = new SqlCommand(comando2, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@descricao", etapa.O_Que);
                    insert.Parameters.AddWithValue("@como", etapa.Como);
                    insert.Parameters.AddWithValue("@prazo", etapa.Prazo);
                    insert.Parameters.AddWithValue("@previsao", etapa.Previsao_Inicio);
                    insert.Parameters.AddWithValue("@ordem", etapa.Ordem);

                    insert.ExecuteNonQuery();
                }

                foreach (Checklist check in projeto.Checklist)
                {
                    if (check.Referencia == etapa.Ordem)
                    {
                        string cmd = "INSERT INTO tbl_EtapasCheckList (ID_Etapa, Descricao, Ordem, Confirmacao) VALUES ((SELECT TOP(1) ID FROM tbl_PlanoEtapas ORDER BY ID DESC), @descricao, @ordem, @confirmacao)";

                        using (SqlCommand insrt = new SqlCommand(cmd, conexao.Conectar()))
                        {
                            insrt.Parameters.AddWithValue("@descricao", check.Descricao);
                            insrt.Parameters.AddWithValue("@ordem", check.Ordem);
                            insrt.Parameters.AddWithValue("@confirmacao", check.Confirmacao);

                            insrt.ExecuteNonQuery();
                        }
                    }
                }

            }


            conexao.Desconectar();

            string comando3 = "INSERT INTO tbl_PlanoCustos (ID_PlanoDeAcao, Ordem, Descricao, Detalhes, Valor, Categoria) VALUES ((SELECT TOP(1) ID FROM tbl_PlanoDeAcao ORDER BY ID DESC), @ordem, @descricao, @detalhes, @valor, @categoria)";


            foreach (Custo custo in projeto.Custos)
            {
                using (SqlCommand insert = new SqlCommand(comando3, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("@ordem", custo.Ordem);
                    insert.Parameters.AddWithValue("@descricao", custo.Descricao);
                    insert.Parameters.AddWithValue("@detalhes", custo.Detalhes);
                    insert.Parameters.AddWithValue("@valor", custo.Valor);
                    insert.Parameters.AddWithValue("@categoria", custo.Categoria);

                    insert.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();

            MessageBox.Show("Plano de ação registrado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EditarPlanoDeAcao(Plano projeto)
        {
            string comando = "UPDATE tbl_Planos SET Descricao = @descricao, O_Que = @o_que, Por_Que = @por_que, Onde = @onde WHERE ID = @id_projeto";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_projeto", projeto.ID_Projeto);
                update.Parameters.AddWithValue("@descricao", projeto.Descricao);
                update.Parameters.AddWithValue("@o_que", projeto.O_Que);
                update.Parameters.AddWithValue("@por_que", projeto.Por_Que);
                update.Parameters.AddWithValue("@onde", projeto.Onde);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Plano de ação editado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AdicionarEtapaDoPlanoDeAcao(Etapa etapa, List<Checklist> checklist, int id_projeto)
        {
            string comando = "INSERT INTO tbl_PlanoEtapas (Descricao, Como, Prazo, Previsao_Inicio, Conclusao, Ordem, ID_PlanoDeAcao) VALUES (@descricao, @como, @prazo, @previsao, 0, @ordem, @id_plano)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_plano", id_projeto);
                insert.Parameters.AddWithValue("@descricao", etapa.O_Que);
                insert.Parameters.AddWithValue("@como", etapa.Como);
                insert.Parameters.AddWithValue("@prazo", etapa.Prazo);
                insert.Parameters.AddWithValue("@previsao", etapa.Previsao_Inicio);
                insert.Parameters.AddWithValue("@ordem", etapa.Ordem);

                insert.ExecuteNonQuery();

                foreach (Checklist check in checklist)
                {
                    if (check.Referencia == etapa.Ordem)
                    {
                        string cmd = "INSERT INTO tbl_EtapasCheckList (ID_Etapa, Descricao, Ordem, Confirmacao) VALUES ((SELECT TOP(1) ID FROM tbl_PlanoEtapas ORDER BY ID DESC), @descricao, @ordem, @confirmacao)";

                        using (SqlCommand insrt = new SqlCommand(cmd, conexao.Conectar()))
                        {
                            insrt.Parameters.AddWithValue("@descricao", check.Descricao);
                            insrt.Parameters.AddWithValue("@ordem", check.Ordem);
                            insrt.Parameters.AddWithValue("@confirmacao", check.Confirmacao);

                            insrt.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void EditarEtapaDoPlanoDeAcao(Etapa etapa)
        {
            string comando = "UPDATE tbl_PlanoEtapas SET Descricao = @descricao, Como = @como, Prazo = @prazo, Previsao_Inicio = @previsao WHERE ID = @id_etapa";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_etapa", etapa.ID_Etapa);
                insert.Parameters.AddWithValue("@descricao", etapa.O_Que);
                insert.Parameters.AddWithValue("@como", etapa.Como);
                insert.Parameters.AddWithValue("@prazo", etapa.Prazo);
                insert.Parameters.AddWithValue("@previsao", etapa.Previsao_Inicio);

                insert.ExecuteNonQuery();
            }
        }

        public void AdicionarItemAoCheckList(Checklist checklist)
        {
            string comando = "INSERT INTO tbl_EtapasCheckList (ID_Etapa, Descricao, Ordem, Confirmacao) VALUES (@referencia, @descricao, @ordem, 0)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@referencia", checklist.Referencia);
                insert.Parameters.AddWithValue("@descricao", checklist.Descricao);
                insert.Parameters.AddWithValue("@ordem", checklist.Ordem);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarItemDoCheckList(Checklist checklist)
        {
            string comando = "UPDATE tbl_EtapasCheckList SET Descricao = @descricao WHERE ID_Etapa = @referencia AND Ordem = @ordem";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@referencia", checklist.Referencia);
                update.Parameters.AddWithValue("@descricao", checklist.Descricao);
                update.Parameters.AddWithValue("@ordem", checklist.Ordem);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarItemDoCheckList(Checklist checklist)
        {
            string comando = "DELETE FROM tbl_EtapasCheckList WHERE ID_Etapa = @referencia AND Ordem = @ordem";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@referencia", checklist.Referencia);
                delete.Parameters.AddWithValue("@ordem", checklist.Ordem);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarPlanoDeAcao(int id)
        {
            string comando = "DELETE FROM tbl_EtapasCheckList WHERE (SELECT ID_PlanoDeAcao FROM tbl_PlanoEtapas WHERE ID = tbl_EtapasCheckList.ID_Etapa) = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            string comando2 = "DELETE FROM tbl_PlanoEtapas WHERE ID_PlanoDeAcao = @id";

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();

            string comando3 = "DELETE FROM tbl_Planos WHERE ID = @id";

            using (SqlCommand delete = new SqlCommand(comando3, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarEtapaDoPlanoDeAcao(int id_etapa)
        {
            string comando2 = "DELETE FROM tbl_PlanoEtapas WHERE ID = @id";

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id_etapa);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ReordenarEtapasDoPlano(int id_projeto)
        {
            List<int> Etapas = new List<int>();

            string comando = "SELECT ID FROM tbl_PlanoEtapas WHERE ID_PlanoDeAcao = @id_projeto ORDER BY Ordem";
            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_projeto", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Etapas.Add(Convert.ToInt32(leitor["ID"]));
                    }
                }
            }
            conexao.Desconectar();

            int ordem = 1;
            string cmd = "UPDATE tbl_PlanoEtapas SET Ordem = @ordem WHERE ID = @id_etapa";

            foreach (int id_etapa in Etapas)
            {
                using (SqlCommand update = new SqlCommand(cmd, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@id_etapa", id_etapa);
                    update.Parameters.AddWithValue("@ordem", ordem);
                    update.ExecuteNonQuery();
                }

                ordem++;
            }
        }

        public void ReordenarChecklist(int id_etapa)
        {
            List<int> lista = new List<int>();

            string comando = "SELECT ID FROM tbl_EtapasCheckList WHERE ID_Etapa = @id_etapa ORDER BY Ordem";
            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_etapa", id_etapa);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(Convert.ToInt32(leitor["ID"]));
                    }
                }
            }
            conexao.Desconectar();

            int ordem = 1;
            string cmd = "UPDATE tbl_EtapasCheckList SET Ordem = @ordem WHERE ID = @id";

            foreach (int id in lista)
            {
                using (SqlCommand update = new SqlCommand(cmd, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@id", id);
                    update.Parameters.AddWithValue("@ordem", ordem);
                    update.ExecuteNonQuery();
                }

                ordem++;
            }
        }

        public void AlterarOrdemDoChecklist(int id, int nova_ordem)
        {
            string comando = "UPDATE tbl_EtapasCheckList SET Ordem = @nova_ordem WHERE ID = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", id);
                update.Parameters.AddWithValue("@nova_ordem", nova_ordem);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AlterarOrdemDaEtapa(int id, int nova_ordem)
        {
            string comando = "UPDATE tbl_PlanoEtapas SET Ordem = @nova_ordem WHERE ID = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", id);
                update.Parameters.AddWithValue("@nova_ordem", nova_ordem);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void AdicionarCustoDoPlanoDeAcao(Custo custo, int id_projeto)
        {
            string comando = "INSERT INTO tbl_PlanoCustos (ID_PlanoDeAcao, Descricao, Detalhes, Valor, Categoria, Ordem) VALUES (@id_plano, @descricao, @detalhes, @valor, @categoria, @ordem)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id_plano", id_projeto);
                insert.Parameters.AddWithValue("@descricao", custo.Descricao);
                insert.Parameters.AddWithValue("@detalhes", custo.Detalhes);
                insert.Parameters.AddWithValue("@valor", custo.Valor);
                insert.Parameters.AddWithValue("@categoria", custo.Categoria);
                insert.Parameters.AddWithValue("@ordem", custo.Ordem);

                insert.ExecuteNonQuery();
            }
        }

        public void EditarCustoDoPlanoDeAcao(Custo custo)
        {
            string comando = "UPDATE tbl_PlanoCustos SET Descricao = @descricao, Detalhes = @detalhes, Valor = @valor, Categoria = @categoria WHERE ID = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", custo.ID);
                update.Parameters.AddWithValue("@descricao", custo.Descricao);
                update.Parameters.AddWithValue("@detalhes", custo.Detalhes);
                update.Parameters.AddWithValue("@valor", custo.Valor);
                update.Parameters.AddWithValue("@categoria", custo.Categoria);

                update.ExecuteNonQuery();
            }
        }

        public void ApagarCustoDoPlanoDeAcao(int id_custo)
        {
            string comando2 = "DELETE FROM tbl_PlanoCustos WHERE ID = @id";

            using (SqlCommand delete = new SqlCommand(comando2, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id_custo);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ReordenarCustosDoPlano(int id_projeto)
        {
            List<int> Custos = new List<int>();

            string comando = "SELECT ID FROM tbl_PlanoCustos WHERE ID_PlanoDeAcao = @id_projeto ORDER BY Ordem";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_projeto", id_projeto);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Custos.Add(Convert.ToInt32(leitor["ID"]));
                    }
                }
            }

            conexao.Desconectar();

            int ordem = 1;
            string cmd = "UPDATE tbl_PlanoCustos SET Ordem = @ordem WHERE ID = @id_custo";

            foreach (int id_custo in Custos)
            {
                using (SqlCommand update = new SqlCommand(cmd, conexao.Conectar()))
                {
                    update.Parameters.AddWithValue("@id_custo", id_custo);
                    update.Parameters.AddWithValue("@ordem", ordem);
                    update.ExecuteNonQuery();
                }

                ordem++;
            }
        }

        public void ImprimirPlanoDeAcao(int id, bool impressao)
        {
            List<Checklist> checklists = new List<Checklist>();
            List<Custo> custos = new List<Custo>();

            string data = DateTime.Now.ToShortDateString();
            string descricao = string.Empty;
            string inicio = string.Empty;
            string o_que = string.Empty;
            string por_que = string.Empty;
            string onde = string.Empty;

            string comando = "SELECT Descricao, O_Que, Por_Que, Onde, CONVERT(DATE, (SELECT MIN(Previsao_Inicio) FROM tbl_PlanoEtapas WHERE ID_PlanoDeAcao = tbl_Planos.ID)) AS Inicio FROM tbl_Planos WHERE ID = @id";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        descricao = leitor[0].ToString();
                        o_que = leitor[1].ToString();
                        por_que = leitor[2].ToString();
                        onde = leitor[3].ToString();
                        inicio = Convert.ToDateTime(leitor[4]).ToShortDateString();
                    }
                }
            }

            string cmd2 = "[EtapasDoPlanoDeAcao] @id";

            using (SqlCommand select = new SqlCommand(cmd2, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        checklists.Add(new Checklist
                        {
                            Referencia = Convert.ToInt32(leitor[0]),
                            Etapa = leitor[1].ToString(),
                            Como = leitor[2].ToString(),
                            Previsao_Inicio = Convert.ToDateTime(leitor[3]),
                            Inicio = Convert.ToDateTime(leitor[4]),
                            Conclusao = Convert.ToBoolean(leitor[5]),
                            Ordem = Convert.ToInt32(leitor[6]),
                            Descricao = leitor[7].ToString()
                        });
                    }
                }
            }

            string cmd3 = "[CustosDoPlanoDeAcao] @id";

            using (SqlCommand select = new SqlCommand(cmd3, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id", id);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        custos.Add(new Custo
                        {
                            Descricao = leitor[0].ToString(),
                            Detalhes = leitor[1].ToString(),
                            Valor = Convert.ToDecimal(leitor[2])
                        });
                    }
                }
            }


            conexao.Desconectar();

            formRepPlano relatorio = new formRepPlano();
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("data", data));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("descricao", descricao));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("inicio", inicio));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("o_que", o_que));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("por_que", por_que));
            relatorio.reportViewer1.LocalReport.SetParameters(new ReportParameter("onde", onde));

            relatorio.reportViewer1.LocalReport.DataSources.Clear();
            relatorio.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetEtapas", checklists));
            relatorio.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSetCustos", custos));

            relatorio.reportViewer1.RefreshReport();

            if (impressao)
            {
                AutoPrintCls autoprintme = new AutoPrintCls(relatorio.reportViewer1.LocalReport);
                //autoprintme.PrinterSettings.PrinterName = Program.Computador.Impressora_A4;
                autoprintme.Print();
            }
            else
            {
                relatorio.ShowDialog();
            }
        }

        public void ArquivarOuDesarquivarPlano(int id)
        {
            string comando = "UPDATE tbl_Planos SET Arquivado = IIF(Arquivado = 1, 0, 1) WHERE ID = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", id);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public int QuantidadeDePlanosArquivados()
        {
            int planos = 0;

            string comando = "SELECT COUNT(*) FROM tbl_Planos WHERE Arquivado = 1";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                planos = Convert.ToInt32(update.ExecuteScalar());
            }

            conexao.Desconectar();

            return planos;
        }

        public void AlterarConclusaoDoPlano(int id)
        {
            string comando = "UPDATE tbl_Planos SET Conclusao = IIF(Conclusao = 1, 0, 1) WHERE ID = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", id);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #endregion

        #region Finanças

        public void RegistrarMovimentacao(Movimentacao movimentacao, bool entrada, bool previsao, bool pagamento)
        {
            if (!entrada) { movimentacao.Valor = -movimentacao.Valor; }
            if (!entrada) { movimentacao.Valor_Previsto = -movimentacao.Valor_Previsto; }

            string comando = "INSERT INTO tbl_Movimentacoes (Descricao, Valor, Data, ID_Categoria, ID_Conta, Registro, Valor_Previsto, Data_Prevista, Orcamento, ID_Usuario, Transferencia, Itens, Data_Movimentacao) VALUES (@descricao, IIF(@pagamento = 1, @valor, NULL), IIF(@pagamento = 1, @data, NULL), @id_categoria,  @id_conta, GETDATE(), IIF(@previsao = 1, @valor_previsto, NULL), IIF(@previsao = 1, @data_prevista, NULL), @orcamento, @id_usuario, 0, @itens, @data_movimentacao)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", movimentacao.Descricao);
                insert.Parameters.AddWithValue("@valor", movimentacao.Valor);
                insert.Parameters.AddWithValue("@data", movimentacao.Data);
                insert.Parameters.AddWithValue("@id_categoria", movimentacao.ID_Categoria);
                insert.Parameters.AddWithValue("@id_conta", movimentacao.ID_Conta);
                insert.Parameters.AddWithValue("@orcamento", movimentacao.Orcamento);
                insert.Parameters.AddWithValue("@valor_previsto", movimentacao.Valor_Previsto);
                insert.Parameters.AddWithValue("@data_prevista", movimentacao.Data_Prevista);
                insert.Parameters.AddWithValue("@previsao", previsao);
                insert.Parameters.AddWithValue("@pagamento", pagamento);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@itens", movimentacao.Itens);
                insert.Parameters.AddWithValue("@data_movimentacao", movimentacao.Data_Movimentacao);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }


        public void EditarMovimentacao(Movimentacao movimentacao, bool entrada, bool previsao, bool pagamento)
        {
            if (!entrada) { movimentacao.Valor = -movimentacao.Valor; }
            if (!entrada) { movimentacao.Valor_Previsto = -movimentacao.Valor_Previsto; }

            string comando = "UPDATE tbl_Movimentacoes SET Descricao = @descricao, Valor = IIF(@pagamento = 1, @valor, NULL), Data = IIF(@pagamento = 1, @data, NULL), Valor_Previsto = IIF(@previsao = 1, @valor_previsto, NULL), Data_Prevista = IIF(@previsao = 1, @data_prevista, NULL), Orcamento = @orcamento, ID_Categoria = @id_categoria, ID_Conta = @id_conta, Registro = GETDATE(), Itens = @itens, Data_Movimentacao = @data_movimentacao WHERE ID_Movimentacao = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@descricao", movimentacao.Descricao);
                update.Parameters.AddWithValue("@valor", movimentacao.Valor);
                update.Parameters.AddWithValue("@data", movimentacao.Data);
                update.Parameters.AddWithValue("@id_categoria", movimentacao.ID_Categoria);
                update.Parameters.AddWithValue("@id_conta", movimentacao.ID_Conta);
                update.Parameters.AddWithValue("@id", movimentacao.ID_Movimentacao);
                update.Parameters.AddWithValue("@orcamento", movimentacao.Orcamento);
                update.Parameters.AddWithValue("@valor_previsto", movimentacao.Valor_Previsto);
                update.Parameters.AddWithValue("@data_prevista", movimentacao.Data_Prevista);
                update.Parameters.AddWithValue("@previsao", previsao);
                update.Parameters.AddWithValue("@pagamento", pagamento);
                update.Parameters.AddWithValue("@itens", movimentacao.Itens);
                update.Parameters.AddWithValue("@data_movimentacao", movimentacao.Data_Movimentacao);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();

            MessageBox.Show("Movimentação editada!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ApagarMovimentacao(int id)
        {
            string comando = "DELETE FROM tbl_Movimentacoes WHERE ID_Movimentacao = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }
            
            conexao.Desconectar();
        }

        public void ApagarTransferencia(int id)
        {
            string comando = "DELETE FROM tbl_Movimentacoes WHERE ID_Movimentacao = @id OR ID_Movimentacao = @id -1";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void PreencherDataGridFluxo(DataGridView dataGrid, BindingSource bindingSource, int registros, bool todos, bool orcamentos, bool lancamentos)
        {
            string comando;

            if (todos)
            {
                comando = "SELECT ID_Movimentacao, Descricao, ISNULL(FORMAT(Valor, 'c', 'pt-br'), '') AS Valor, ISNULL((SELECT Categoria FROM tbl_CategoriasFinanceiras WHERE tbl_CategoriasFinanceiras.ID_Categoria = tbl_Movimentacoes.ID_Categoria), ' - ') AS Categoria, (SELECT Descricao FROM tbl_Contas WHERE ID_Conta = tbl_Movimentacoes.ID_Conta) AS Conta, ISNULL(FORMAT(Data, 'dd/MM/yyyy'), '') AS Data, Registro, ISNULL(FORMAT(Data_Prevista, 'dd/MM/yyyy'), '') AS Data_Prevista, ISNULL(FORMAT(Valor_Previsto, 'c', 'pt-br'), '') AS Valor_Previsto, ID_Parente, Orcamento, ISNULL(Data, Data_Prevista) AS Data_Original, Transferencia FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario AND Transferencia = 0 AND ((Orcamento = @orcamentos AND IIF(Valor IS NULL, 0, 1) = IIF(@orcamentos = 0, 1, 0)) OR (IIF(Valor IS NULL, 0, 1) = IIF(@lancamentos = 1, 1, 0))) UNION SELECT ID_Movimentacao, Descricao, ISNULL(FORMAT(Valor, 'c', 'pt-br'), '') AS Valor, (SELECT Categoria FROM tbl_CategoriasFinanceiras WHERE tbl_CategoriasFinanceiras.ID_Categoria = tbl_Movimentacoes.ID_Categoria) AS Categoria, 'Transferência' AS Conta, ISNULL(FORMAT(Data, 'dd/MM/yyyy'), '') AS Data, Registro, ISNULL(FORMAT(Data_Prevista, 'dd/MM/yyyy'), '') AS Data_Prevista, ISNULL(FORMAT(Valor_Previsto, 'c', 'pt-br'), '') AS Valor_Previsto, ID_Parente, Orcamento, ISNULL(Data, Data_Prevista) AS Data_Original, Transferencia FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario AND Transferencia = 1 AND Valor > 0 AND ((Orcamento = @orcamentos AND IIF(Valor IS NULL, 0, 1) = IIF(@orcamentos = 0, 1, 0)) OR (IIF(Valor IS NULL, 0, 1) = IIF(@lancamentos = 1, 1, 0))) ORDER BY Data_Original DESC, Registro DESC";
            }
            else
            {
                comando = "SELECT TOP(@registros) * FROM (SELECT TOP(@registros) ID_Movimentacao, Descricao, ISNULL(FORMAT(Valor, 'c', 'pt-br'), '') AS Valor, ISNULL((SELECT Categoria FROM tbl_CategoriasFinanceiras WHERE tbl_CategoriasFinanceiras.ID_Categoria = tbl_Movimentacoes.ID_Categoria), ' - ') AS Categoria, (SELECT Descricao FROM tbl_Contas WHERE ID_Conta = tbl_Movimentacoes.ID_Conta) AS Conta, ISNULL(FORMAT(Data, 'dd/MM/yyyy'), '') AS Data, Registro, ISNULL(FORMAT(Data_Prevista, 'dd/MM/yyyy'), '') AS Data_Prevista, ISNULL(FORMAT(Valor_Previsto, 'c', 'pt-br'), '') AS Valor_Previsto, ID_Parente, Orcamento, ISNULL(Data, Data_Prevista) AS Data_Original, Transferencia FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario AND Transferencia = 0 AND ((Orcamento = @orcamentos AND IIF(Valor IS NULL, 0, 1) = IIF(@orcamentos = 0, 1, 0)) OR (IIF(Valor IS NULL, 0, 1) = IIF(@lancamentos = 1, 1, 0))) ORDER BY Data_Original DESC, Registro DESC UNION ALL SELECT top(@registros) ID_Movimentacao, Descricao, ISNULL(FORMAT(Valor, 'c', 'pt-br'), '') AS Valor, (SELECT Categoria FROM tbl_CategoriasFinanceiras WHERE tbl_CategoriasFinanceiras.ID_Categoria = tbl_Movimentacoes.ID_Categoria) AS Categoria, 'Transferências', ISNULL(FORMAT(Data, 'dd/MM/yyyy'), '') AS Data, Registro, ISNULL(FORMAT(Data_Prevista, 'dd/MM/yyyy'), '') AS Data_Prevista, ISNULL(FORMAT(Valor_Previsto, 'c', 'pt-br'), '') AS Valor_Previsto, ID_Parente, Orcamento, ISNULL(Data, Data_Prevista) AS Data_Original, Transferencia FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario AND Transferencia = 1 AND Valor > 0 AND ((Orcamento = @orcamentos AND IIF(Valor IS NULL, 0, 1) = IIF(@orcamentos = 0, 1, 0)) OR (IIF(Valor IS NULL, 0, 1) = IIF(@lancamentos = 1, 1, 0))) ORDER BY Data_Original DESC, Registro DESC) T3 ORDER BY Data_Original DESC, Registro DESC";
            }


            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@registros", registros);
                select.Parameters.AddWithValue("@orcamentos", orcamentos);
                select.Parameters.AddWithValue("@lancamentos", lancamentos);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                SqlDataAdapter adaptador = new SqlDataAdapter(select);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adaptador);
                DataSet dataSet = new DataSet();
                adaptador.Fill(dataSet);
                bindingSource.DataSource = dataSet;
                bindingSource.DataMember = dataSet.Tables[0].TableName;
                dataGrid.DataSource = bindingSource;
            }

            conexao.Desconectar();
        }

        public void RegistrarTransferenciaEntreContas(Transferencia transferencia)
        {
            string comando = "INSERT INTO tbl_Movimentacoes (Descricao, Valor, Data, ID_Conta, Registro, ID_Categoria, Valor_Previsto, Data_Prevista, Orcamento, ID_Usuario, Transferencia) VALUES ((SELECT Descricao FROM tbl_Contas WHERE ID_Conta = @id_origem) + ' > ' + (SELECT Descricao FROM tbl_Contas WHERE ID_Conta = @id_destino), @valor, @data, @id_origem, GETDATE(), (SELECT ID_Categoria FROM tbl_CategoriasFinanceiras WHERE Categoria = 'Transferências' AND ID_Usuario = @id_usuario), @valor, @data, 0, @id_usuario, 1)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@valor", -transferencia.Valor);
                insert.Parameters.AddWithValue("@id_origem", transferencia.ID_Origem);
                insert.Parameters.AddWithValue("@id_destino", transferencia.ID_Destino);
                insert.Parameters.AddWithValue("@data", transferencia.Data);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            string comando1 = "INSERT INTO tbl_Movimentacoes (Descricao, Valor, Data, ID_Conta, Registro, ID_Categoria, Valor_Previsto, Data_Prevista, Orcamento, ID_Usuario, Transferencia) VALUES ((SELECT Descricao FROM tbl_Contas WHERE ID_Conta = @id_origem) + ' > ' + (SELECT Descricao FROM tbl_Contas WHERE ID_Conta = @id_destino), @valor, @data, @id_destino, GETDATE(), (SELECT ID_Categoria FROM tbl_CategoriasFinanceiras WHERE Categoria = 'Transferências' AND ID_Usuario = @id_usuario), @valor, @data, 0, @id_usuario, 1)";

            using (SqlCommand insert = new SqlCommand(comando1, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@valor", transferencia.Valor);
                insert.Parameters.AddWithValue("@id_origem", transferencia.ID_Origem);
                insert.Parameters.AddWithValue("@id_destino", transferencia.ID_Destino);
                insert.Parameters.AddWithValue("@data", transferencia.Data);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.ExecuteNonQuery();
            }

            MessageBox.Show("Transferência realizada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<string> TrazerListaDeCategoriasFinanceiras(string tipo)
        {
            List<string> lista = new List<string>();
            string comando = "SELECT Categoria FROM tbl_Categorias WHERE ID_Usuario = @id_usuario AND (Tipo = @tipo OR Tipo = 'OUTROS') ORDER BY Categoria ASC";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@tipo", tipo);
            select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

            SqlDataReader leitor = select.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(Convert.ToString(leitor[0]));
            }
            leitor.Close();
            conexao.Desconectar();
            return lista;
        }

        public Movimentacao TrazerInformacoesDaMovimentacao(int id_movimentacao)
        {
            Movimentacao movimentacao = new Movimentacao();

            string comando = "SELECT Descricao, ISNULL(Valor, 0) AS Valor, ID_Categoria, ID_Conta, ISNULL(Data, '01/01/1901') AS Data, ISNULL(Valor_Previsto, 0) AS Valor_Previsto, ISNULL(Data_Prevista, '01/01/1901') AS Data_Prevista, Orcamento, Itens, Data_Movimentacao FROM tbl_Movimentacoes WHERE ID_Movimentacao = @id_movimentacao AND ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_movimentacao", id_movimentacao);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        movimentacao.ID_Movimentacao = id_movimentacao;
                        movimentacao.Descricao = leitor[0].ToString();
                        movimentacao.Valor = Convert.ToDecimal(leitor[1]);
                        movimentacao.ID_Categoria = Convert.ToInt32(leitor[2]);
                        movimentacao.ID_Conta = Convert.ToInt32(leitor[3]);
                        movimentacao.Data = Convert.ToDateTime(leitor[4]);
                        movimentacao.Valor_Previsto = Convert.ToDecimal(leitor[5]);
                        movimentacao.Data_Prevista = Convert.ToDateTime(leitor[6]);
                        movimentacao.Orcamento = Convert.ToBoolean(leitor[7]);
                        movimentacao.Itens = Convert.ToBoolean(leitor[8]);
                        movimentacao.Data_Movimentacao = Convert.ToDateTime(leitor[9]);
                    }
                }
            }

            conexao.Desconectar();

            return movimentacao;
        }

        public void CadastrarItens(List<Item> itens)
        {
            string comando = "INSERT INTO tbl_MovimentacoesItens (Descricao, Valor, Previsto, ID_Movimentacao, Quantidade) VALUES (@descricao, @valor, @previsto, (SELECT TOP(1) ID_Movimentacao FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario ORDER BY ID_Movimentacao DESC), @quantidade)";

            foreach (Item item in itens)
            {
                using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
                {
                    insert.Parameters.AddWithValue("id_usuario", Program.usuario.ID_Usuario);
                    insert.Parameters.AddWithValue("@descricao", item.Descricao);
                    insert.Parameters.AddWithValue("@valor", item.Valor);
                    insert.Parameters.AddWithValue("@quantidade", item.Quantidade);
                    insert.Parameters.AddWithValue("@previsto", item.Previsto);
                    insert.ExecuteNonQuery();
                }
            }

            conexao.Desconectar();
        }

        public List<Item> TrazerListaDeItens(int id_movimentacao)
        {
            List<Item> itens = new List<Item>();

            string comando = "SELECT ID_Item, Descricao, Valor, Previsto, Quantidade FROM tbl_MovimentacoesItens WHERE ID_Movimentacao = @id_movimentacao ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_movimentacao", id_movimentacao);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        itens.Add(new Item
                        {
                            ID_Item = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Valor = Convert.ToDecimal(leitor[2]),
                            Previsto = Convert.ToBoolean(leitor[3]),
                            Quantidade = Convert.ToInt32(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return itens;
        }

        public void CadastrarItem(Item item)
        {
            string comando = "INSERT INTO tbl_MovimentacoesItens (Descricao, Valor, Previsto, ID_Movimentacao, Quantidade) VALUES (@descricao, @valor, @previsto, @id_movimentacao, @quantidade)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", item.Descricao);
                insert.Parameters.AddWithValue("@valor", item.Valor);
                insert.Parameters.AddWithValue("@id_movimentacao", item.ID_Movimentacao);
                insert.Parameters.AddWithValue("@quantidade", item.Quantidade);
                insert.Parameters.AddWithValue("@previsto", item.Previsto);
                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarItem(int id)
        {
            string comando = "DELETE FROM tbl_MovimentacoesItens WHERE ID_Item = @id";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id", id);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public List<Categoria_Financeira> PreencherComboPlanoDeContas(bool entrada)
        {
            string tipo;
            if (entrada) { tipo = "Receita"; }
            else { tipo = "Despesa"; }

            List<Categoria_Financeira> categorias = new List<Categoria_Financeira>();

            string comando = "SELECT ID_Categoria, Categoria FROM tbl_CategoriasFinanceiras AS P1 WHERE (SELECT COUNT(*) FROM tbl_CategoriasFinanceiras WHERE ID_Parente = P1.ID_Categoria AND ID_Usuario = @id_usuario) = 0 AND (Tipo = @tipo OR Tipo IS NULL) AND ID_Usuario = @id_usuario ORDER BY Categoria";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@tipo", tipo);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        categorias.Add(new Categoria_Financeira
                        {
                            ID = (int)leitor[0],
                            Categoria = (string)leitor[1]
                        });
                    }
                }
            }

            conexao.Desconectar();

            return categorias;
        }

        public List<Categoria_Financeira> PlanoDeContasPorTipo(bool entrada)
        {
            string tipo;
            if (entrada) { tipo = "Receita"; }
            else { tipo = "Despesa"; }

            List<Categoria_Financeira> categorias = new List<Categoria_Financeira>();

            string comando = "SELECT ID_Categoria, Categoria, ISNULL(ID_Parente, 0), ISNULL(Tipo, '') FROM tbl_CategoriasFinanceiras WHERE ID_Usuario = @id_usuario AND (Tipo = @tipo OR Tipo IS NULL)";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@tipo", tipo);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        categorias.Add(new Categoria_Financeira
                        {
                            ID = (int)leitor[0],
                            Categoria = (string)leitor[1],
                            ID_Parente = (int)leitor[2],
                            Tipo = (string)leitor[3]
                        });
                    }
                }
            }

            conexao.Desconectar();

            return categorias;
        }

        public List<Conta> TrazerSaldoDasContas(DateTime data)
        {
            List<Conta> contas = new List<Conta>();
            string comando = "SELECT Descricao, ISNULL((SELECT SUM(Valor) FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario AND ID_Conta = tbl_Contas.ID_Conta AND CONVERT(DATE, Data) <= CONVERT(DATE, @data)), 0) AS Valor FROM tbl_Contas WHERE ID_Usuario = @id_usuario AND Visivel = 1 ORDER BY Descricao";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@data", data);
            select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

            SqlDataReader leitor = select.ExecuteReader();
            while (leitor.Read())
            {
                contas.Add(new Conta
                {
                    Descricao = leitor[0].ToString(),
                    Saldo = Convert.ToDecimal(leitor[1])
                });
            }
            leitor.Close();
            conexao.Desconectar();
            return contas;
        }

        public void MarcarComoPago(int id, bool hoje)
        {
            string comando;
            
            if (hoje)
            {
                comando = "UPDATE tbl_Movimentacoes SET Valor = Valor_Previsto, Data = @data WHERE ID_Movimentacao = @id";
            }
            else
            {
                comando = "UPDATE tbl_Movimentacoes SET Valor = Valor_Previsto, Data = Data_Prevista WHERE ID_Movimentacao = @id";
            }

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@id", id);
                insert.Parameters.AddWithValue("@data", DateTime.Now.Date);
                insert.ExecuteNonQuery();
            }
        }

        #region Contas

        public List<string> PreencherComboCategoriasDasContas()
        {
            List<string> lista = new List<string>();
            string comando = "SELECT DISTINCT Categoria FROM tbl_Contas WHERE ID_Usuario = @id_usuario ORDER BY Categoria";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        lista.Add(Convert.ToString(leitor[0]));
                    }
                }
            }

            conexao.Desconectar();

            return lista;
        }

        public List<Banco> ListaDeBancos()
        {
            List<Banco> bancos = new List<Banco>();

            string comando = "SELECT ID_Banco, Descricao, Cod_Banco FROM tbl_Bancos ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        bancos.Add(new Banco
                        {
                            ID_Banco = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Cod_Banco = leitor[2].ToString(),
                        });
                    }
                }
            }

            conexao.Desconectar();

            return bancos;
        }

        public List<Conta> ListaDeContas()
        {
            List<Conta> contas = new List<Conta>();

            string comando = "SELECT ID_Conta, Descricao, Categoria, ISNULL((SELECT SUM(Valor) FROM tbl_Movimentacoes WHERE ID_Conta = tbl_Contas.ID_Conta), 0) AS Valor, Visivel FROM tbl_Contas WHERE ID_Usuario = @id_usuario ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        contas.Add(new Conta
                        {
                            ID_Conta = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString(),
                            Categoria = leitor[2].ToString(),
                            Saldo = Convert.ToDecimal(leitor[3]),
                            Visivel = Convert.ToBoolean(leitor[4])
                        });
                    }
                }
            }

            conexao.Desconectar();

            return contas;
        }

        public void AdicionarConta(Conta conta)
        {
            string comando = "INSERT INTO tbl_Contas (Descricao, Categoria, Agencia, Conta, ID_Banco, ID_Usuario, Visivel) VALUES (@descricao, @categoria, @agencia, @conta, IIF(@id_banco = 0, NULL, @id_banco), @id_usuario, @visivel)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@descricao", conta.Descricao);
                insert.Parameters.AddWithValue("@categoria", conta.Categoria);
                insert.Parameters.AddWithValue("@agencia", conta.Agencia);
                insert.Parameters.AddWithValue("@conta", conta.N_Conta);
                insert.Parameters.AddWithValue("@id_banco", conta.ID_Banco);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);
                insert.Parameters.AddWithValue("@visivel", conta.Visivel);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public Conta TrazerInformacoesDaConta(int id_conta)
        {
            Conta conta = new Conta();

            string comando = "SELECT ID_Conta, Descricao, Categoria, Agencia, Conta, ID_Banco FROM tbl_Contas WHERE ID_Conta = @id_conta";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_conta", id_conta);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        conta.ID_Conta = Convert.ToInt32(leitor[0]);
                        conta.Descricao = leitor[1].ToString();
                        conta.Categoria = leitor[2].ToString();
                        conta.Agencia = leitor[3].ToString();
                        conta.N_Conta = leitor[4].ToString();

                        try { conta.ID_Banco = Convert.ToInt32(leitor[5]); }
                        catch { conta.ID_Banco = 0; }
                    }
                }
            }

            conexao.Desconectar();

            return conta;
        }

        public void EditarConta(Conta conta)
        {
            string comando = "UPDATE tbl_Contas SET Descricao = @descricao, Categoria = @categoria, Agencia = @agencia, Conta = @conta, ID_Banco = IIF(@id_banco = 0, NULL, @id_banco) WHERE ID_Conta = @id_conta";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_conta", conta.ID_Conta);
                update.Parameters.AddWithValue("@descricao", conta.Descricao);
                update.Parameters.AddWithValue("@categoria", conta.Categoria);
                update.Parameters.AddWithValue("@agencia", conta.Agencia);
                update.Parameters.AddWithValue("@conta", conta.N_Conta);
                update.Parameters.AddWithValue("@id_banco", conta.ID_Banco);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarVisibilidadeDaConta(int id_conta, bool visivel)
        {
            string comando = "UPDATE tbl_Contas SET Visivel = @visivel WHERE ID_Conta = @id_conta";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id_conta", id_conta);
                update.Parameters.AddWithValue("@visivel", visivel);

                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarConta(int id_conta)
        {
            string comando = "DELETE FROM tbl_Contas WHERE ID_Conta = @id_conta";

            using (SqlCommand delete = new SqlCommand(comando, conexao.Conectar()))
            {
                delete.Parameters.AddWithValue("@id_conta", id_conta);
                delete.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public List<Conta> PreencherComboContas()
        {
            List<Conta> contas = new List<Conta>();

            string comando = "SELECT ID_Conta, Descricao FROM tbl_Contas WHERE ID_Usuario = @id_usuario ORDER BY Descricao";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        contas.Add(new Conta
                        {
                            ID_Conta = Convert.ToInt32(leitor[0]),
                            Descricao = leitor[1].ToString()
                        });
                    }
                }
            }

            conexao.Desconectar();

            return contas;
        }

        #endregion

        #region Fluxo de caixa

        public List<string> MesesDoFluxoDeCaixa()
        {
            List<string> Meses = new List<string>();
            string comando = "SELECT DISTINCT MONTH(Data_Prevista), YEAR(Data_Prevista), CONVERT(VARCHAR, UPPER(FORMAT(Data_Prevista, 'MMMM', 'pt-BR'))) + '/' + CONVERT(VARCHAR, YEAR(Data_Prevista)) FROM tbl_Movimentacoes WHERE ID_Usuario = @id_usuario ORDER BY YEAR(Data_Prevista) DESC, MONTH(Data_Prevista) DESC";
            
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

            SqlDataReader leitor = select.ExecuteReader();
            while (leitor.Read())
            {
                Meses.Add(leitor[2].ToString());
            }
            leitor.Close();
            conexao.Desconectar();

            return Meses;
        }

        public List<FluxoDeCaixa> InformacoesDoFluxoDeCaixa(int mes, int ano)
        {
            List<FluxoDeCaixa> fluxo = new List<FluxoDeCaixa>();

            string comando = "[FluxoDeCaixaEsperado] @mes, @ano, @id_usuario";

            using (SqlCommand procedure = new SqlCommand(comando, conexao.Conectar()))
            {
                procedure.Parameters.AddWithValue("@mes", mes);
                procedure.Parameters.AddWithValue("@ano", ano);
                procedure.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = procedure.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        fluxo.Add(new FluxoDeCaixa
                        {
                            ID = Convert.ToInt32(leitor[0]),
                            ID_Parente = Convert.ToInt32(leitor[1]),
                            Categoria = leitor[2].ToString(),
                            Valor4 = Convert.ToDecimal(leitor[3]),
                            Esperado4 = Convert.ToDecimal(leitor[4]),
                            Valor3 = Convert.ToDecimal(leitor[5]),
                            Esperado3 = Convert.ToDecimal(leitor[6]),
                            Valor2 = Convert.ToDecimal(leitor[7]),
                            Esperado2 = Convert.ToDecimal(leitor[8]),
                            Valor1 = Convert.ToDecimal(leitor[9]),
                            Esperado1 = Convert.ToDecimal(leitor[10]),
                        });
                    }
                }
            }

            conexao.Desconectar();

            return fluxo;
        }

        public List<Categoria_Financeira> PlanoDeContas()
        {
            List<Categoria_Financeira> categorias = new List<Categoria_Financeira>();

            string comando = "SELECT ID_Categoria, Categoria, ISNULL(ID_Parente, 0), ISNULL(Tipo, '') FROM tbl_CategoriasFinanceiras WHERE ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                using (SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        categorias.Add(new Categoria_Financeira
                        {
                            ID = (int)leitor[0],
                            Categoria = (string)leitor[1],
                            ID_Parente = (int)leitor[2],
                            Tipo = (string)leitor[3]
                        });
                    }
                }
            }

            conexao.Desconectar();

            return categorias;
        }

        public bool VerificarCategoria(string categoria)
        {
            bool verificar = false;
            string comando = "SELECT IIF(COUNT(*) = 0, 0, 1) FROM tbl_CategoriasFinanceiras WHERE Categoria = @categoria AND ID_Usuario = @id_usuario";

            using (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@categoria", categoria);
                select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                verificar = Convert.ToBoolean(select.ExecuteScalar());
            }

            conexao.Desconectar();

            return verificar;
        }

        public void CadastrarPlanoDeContas(Categoria_Financeira categoria)
        {
            string comando = "INSERT INTO tbl_CategoriasFinanceiras (Categoria, ID_Parente, Tipo, ID_Usuario) VALUES (@categoria, IIF(@id_parente = 0, NULL, @id_parente), @tipo, @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@categoria", categoria.Categoria);
                insert.Parameters.AddWithValue("@id_parente", categoria.ID_Parente);
                insert.Parameters.AddWithValue("@tipo", categoria.Tipo);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void CadastrarCategoriaRaiz(Categoria_Financeira categoria)
        {
            string comando = "INSERT INTO tbl_CategoriasFinanceiras (Categoria, Tipo, ID_Usuario) VALUES (@categoria, @tipo, @id_usuario)";

            using (SqlCommand insert = new SqlCommand(comando, conexao.Conectar()))
            {
                insert.Parameters.AddWithValue("@categoria", categoria.Categoria);
                insert.Parameters.AddWithValue("@tipo", categoria.Tipo);
                insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

                insert.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void EditarPlanoDeContas(Categoria_Financeira categoria)
        {
            string comando = "UPDATE tbl_CategoriasFinanceiras SET Categoria = @categoria WHERE ID_Categoria = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", categoria.ID);
                update.Parameters.AddWithValue("@categoria", categoria.Categoria);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        public void ApagarCategoriaDoPlanoDeContas(int id)
        {
            string comando = "DELETE FROM tbl_CategoriasFinanceiras WHERE ID_Categoria = @id";

            using (SqlCommand update = new SqlCommand(comando, conexao.Conectar()))
            {
                update.Parameters.AddWithValue("@id", id);
                update.ExecuteNonQuery();
            }

            conexao.Desconectar();
        }

        #endregion

        #region Despesas

        public List<Despesa> ListaDeDespesas()
        {
            List<Despesa> Despesas = new List<Despesa>();

            string comando = "SELECT 1, ID_Despesa, Descricao, Tipo_Despesa, Valor, Dia_do_Mes, Ultimo_Dia, Dia_Util FROM tbl_Despesas WHERE Ultimo_Dia = 0 AND ID_Usuario = @id_usuario UNION SELECT 2, ID_Despesa, Descricao, Tipo_Despesa, Valor, Dia_do_Mes, Ultimo_Dia, Dia_Util FROM tbl_Despesas WHERE Ultimo_Dia = 1 AND ID_Usuario = @id_usuario";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());

            select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

            SqlDataReader leitor = select.ExecuteReader();
            while (leitor.Read())
            {
                Despesas.Add(new Despesa
                {
                    ID_Despesa = Convert.ToInt32(leitor[1]),
                    Descricao = leitor[2].ToString(),
                    Tipo = leitor[3].ToString(),
                    Valor = Convert.ToDecimal(leitor[4]),
                    Dia = Convert.ToInt32(leitor[5]),
                    Ultimo_Dia = Convert.ToBoolean(leitor[6]),
                    Dia_Util = Convert.ToBoolean(leitor[7])
                });
            }
            leitor.Close();
            conexao.Desconectar();

            return Despesas;
        }

        public void ApagarDespesa(int id)
        {
            string comando = "DELETE FROM tbl_Despesas WHERE ID_Despesa = @id";
            SqlCommand delete = new SqlCommand(comando, conexao.Conectar());
            delete.Parameters.AddWithValue("@id", id);
            delete.ExecuteNonQuery();

            conexao.Desconectar();

            MessageBox.Show("Despesa excluída!", "Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RegistrarNovaDespesa(Despesa despesa)
        {
            string comando = "INSERT INTO tbl_Despesas (Descricao, Tipo_Despesa, Valor, Dia_do_Mes, Data_Registro, ID_CatFin, Dia_Util, Ultimo_Dia, Mesmo_Dia, Antes_do_Dia, Depois_do_Dia, ID_Usuario, ID_Conta) VALUES (@descricao, @tipo, @valor, @dia, @data, @id_catfin, @dia_util, @ultimo_dia, @mesmo_dia, @antes_do_dia, @depois_do_dia, @id_usuario, @id_conta)";
            SqlCommand insert = new SqlCommand(comando, conexao.Conectar());
            insert.Parameters.AddWithValue("@descricao", despesa.Descricao);
            insert.Parameters.AddWithValue("@tipo", despesa.Tipo);
            insert.Parameters.AddWithValue("@valor", despesa.Valor);
            insert.Parameters.AddWithValue("@data", despesa.Data);
            insert.Parameters.AddWithValue("@dia", despesa.Dia);
            insert.Parameters.AddWithValue("@id_catfin", despesa.ID_CatFin);
            insert.Parameters.AddWithValue("@dia_util", despesa.Dia_Util);
            insert.Parameters.AddWithValue("@ultimo_dia", despesa.Ultimo_Dia);
            insert.Parameters.AddWithValue("@mesmo_dia", despesa.Mesmo_Dia);
            insert.Parameters.AddWithValue("@antes_do_dia", despesa.Antes_do_Dia);
            insert.Parameters.AddWithValue("@depois_do_dia", despesa.Depois_do_Dia);
            insert.Parameters.AddWithValue("@id_conta", despesa.ID_Conta);
            insert.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

            insert.ExecuteNonQuery();
            MessageBox.Show("Despesa registrada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Despesa TrazerInformacoesDaDespesa(int id)
        {
            string comando = "SELECT Descricao, Tipo_Despesa, Valor, Dia_do_Mes, ID_CatFin, Dia_Util, Ultimo_Dia, Mesmo_Dia, Antes_do_Dia, Depois_do_Dia, ID_Conta FROM tbl_Despesas WHERE ID_Despesa = @id";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());
            select.Parameters.AddWithValue("@id", id);
            SqlDataReader leitor = select.ExecuteReader();
            Despesa Despesa = new Despesa();

            while (leitor.Read())
            {
                Despesa = new Despesa
                {
                    Descricao = leitor[0].ToString(),
                    Tipo = leitor[1].ToString(),
                    Valor = Convert.ToDecimal(leitor[2]),
                    Dia = Convert.ToInt32(leitor[3]),
                    ID_CatFin = (int)leitor[4],
                    Dia_Util = Convert.ToBoolean(leitor[5]),
                    Ultimo_Dia = Convert.ToBoolean(leitor[6]),
                    Mesmo_Dia = Convert.ToBoolean(leitor[7]),
                    Antes_do_Dia = Convert.ToBoolean(leitor[8]),
                    Depois_do_Dia = Convert.ToBoolean(leitor[9]),
                    ID_Conta = Convert.ToInt32(leitor[10])
                };
            }
            leitor.Close();

            conexao.Desconectar();

            return Despesa;
        }

        public void EditarDespesa(Despesa despesa)
        {
            string comando = "UPDATE tbl_Despesas SET Descricao = @descricao, Tipo_Despesa = @tipo, Valor = @valor, Dia_do_Mes = @dia, ID_CatFin = @id_catfin, Dia_Util = @dia_util, Ultimo_Dia = @ultimo_dia, Mesmo_Dia = @mesmo_dia, Antes_do_Dia = @antes_do_dia, Depois_do_Dia = @depois_do_dia, ID_Conta = @id_conta WHERE ID_Despesa = @id";
            SqlCommand update = new SqlCommand(comando, conexao.Conectar());
            update.Parameters.AddWithValue("@id", despesa.ID_Despesa);
            update.Parameters.AddWithValue("@descricao", despesa.Descricao);
            update.Parameters.AddWithValue("@tipo", despesa.Tipo);
            update.Parameters.AddWithValue("@valor", despesa.Valor);
            update.Parameters.AddWithValue("@dia", despesa.Dia);
            update.Parameters.AddWithValue("@id_catfin", despesa.ID_CatFin);
            update.Parameters.AddWithValue("@dia_util", despesa.Dia_Util);
            update.Parameters.AddWithValue("@ultimo_dia", despesa.Ultimo_Dia);
            update.Parameters.AddWithValue("@mesmo_dia", despesa.Mesmo_Dia);
            update.Parameters.AddWithValue("@antes_do_dia", despesa.Antes_do_Dia);
            update.Parameters.AddWithValue("@depois_do_dia", despesa.Depois_do_Dia);
            update.Parameters.AddWithValue("@id_conta", despesa.ID_Conta);
            update.ExecuteNonQuery();

            MessageBox.Show("Despesa editada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Despesa> ListaDeDespesasParaLancamento(int mes, int ano)
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            List<Despesa> Despesas = new List<Despesa>();

            string comando = "SELECT 1, ID_Despesa, Descricao, Tipo_Despesa, Valor, Dia_do_Mes, Ultimo_Dia, Dia_Util, ID_CatFin, ID_Conta FROM tbl_Despesas WHERE Ultimo_Dia = 0 AND ID_Usuario = @id_usuario UNION SELECT 2, ID_Despesa, Descricao, Tipo_Despesa, Valor, Dia_do_Mes, Ultimo_Dia, Dia_Util, ID_CatFin, ID_Conta FROM tbl_Despesas WHERE Ultimo_Dia = 1 AND ID_Usuario = @id_usuario";
            SqlCommand select = new SqlCommand(comando, conexao.Conectar());

            select.Parameters.AddWithValue("@id_usuario", Program.usuario.ID_Usuario);

            SqlDataReader leitor = select.ExecuteReader();
            while (leitor.Read())
            {
                Despesas.Add(new Despesa
                {
                    ID_Despesa = Convert.ToInt32(leitor[1]),
                    Descricao = leitor[2].ToString(),
                    Tipo = leitor[3].ToString(),
                    Valor = Convert.ToDecimal(leitor[4]),
                    Dia = Convert.ToInt32(leitor[5]),
                    Ultimo_Dia = Convert.ToBoolean(leitor[6]),
                    Dia_Util = Convert.ToBoolean(leitor[7]),
                    ID_CatFin = Convert.ToInt32(leitor[8]),
                    ID_Conta = Convert.ToInt32(leitor[9])
                });
            }
            leitor.Close();
            conexao.Desconectar();


            foreach (Despesa despesa in Despesas)
            {
                if (despesa.Ultimo_Dia)
                {
                    despesa.Data = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
                }
                else if (despesa.Dia_Util)
                {
                    int dia = 1;

                    for (int i = 1; i <= DateTime.DaysInMonth(ano, mes); i++)
                    {
                        DateTime data = new DateTime(ano, mes, i);

                        string dia_da_semana = PrimeiraLetraMaiuscula(formato.GetDayName(data.DayOfWeek));

                        if (dia_da_semana == "Domingo" || dia_da_semana == "Sábado")
                        {
                            dia--;
                        }

                        if (despesa.Dia == dia)
                        {

                            despesa.Data = new DateTime(ano, mes, i); ;
                            break;
                        }

                        dia++;
                    }
                }
                else
                {
                    despesa.Data = new DateTime(ano, mes, despesa.Dia);
                }
            }


            return Despesas;
        }

        public void LancarDespesas(List<Despesa> despesas)
        {
            foreach (Despesa despesa in despesas)
            {
                Movimentacao movimentacao = new Movimentacao();

                movimentacao.Descricao = despesa.Descricao;
                movimentacao.Valor = despesa.Valor;
                movimentacao.Valor_Previsto = despesa.Valor;
                movimentacao.Data = despesa.Data;
                movimentacao.Data_Prevista = despesa.Data;
                movimentacao.ID_Conta = despesa.ID_Conta;
                movimentacao.ID_Categoria = despesa.ID_CatFin;
                movimentacao.Orcamento = true;
                movimentacao.Data_Movimentacao = DateTime.Now;

                RegistrarMovimentacao(movimentacao, false, true, false);
            }
        }

        public void LancarDespesa(int id_despesa, int mes, int ano)
        {
            CultureInfo cultura = new CultureInfo("pt-BR");
            DateTimeFormatInfo formato = cultura.DateTimeFormat;

            Despesa despesa = new Despesa();

            string comando = "SELECT Descricao, Valor, Dia_Util, Ultimo_Dia, Dia_do_Mes, ID_CatFin, ID_Conta FROM tbl_Despesas WHERE ID_Despesa = @id_despesa";

            using   (SqlCommand select = new SqlCommand(comando, conexao.Conectar()))
            {
                select.Parameters.AddWithValue("@id_despesa", id_despesa);

                using(SqlDataReader leitor = select.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        despesa.Descricao = leitor[0].ToString();
                        despesa.Valor = Convert.ToDecimal(leitor[1]);
                        despesa.Dia_Util = Convert.ToBoolean(leitor[2]);
                        despesa.Ultimo_Dia = Convert.ToBoolean(leitor[3]);
                        despesa.Dia = Convert.ToInt32(leitor[4]);
                        despesa.ID_CatFin = Convert.ToInt32(leitor[5]);
                        despesa.ID_Conta = Convert.ToInt32(leitor[6]);
                    }
                }
            }

            conexao.Desconectar();

            if (despesa.Ultimo_Dia)
            {
                despesa.Data = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
            }
            else if (despesa.Dia_Util)
            {
                int dia = 1;

                for (int i = 1; i <= DateTime.DaysInMonth(ano, mes); i++)
                {
                    DateTime data = new DateTime(ano, mes, i);

                    string dia_da_semana = PrimeiraLetraMaiuscula(formato.GetDayName(data.DayOfWeek));

                    if (dia_da_semana == "Domingo" || dia_da_semana == "Sábado")
                    {
                        dia--;
                    }

                    if (despesa.Dia == dia)
                    {

                        despesa.Data = new DateTime(ano, mes, i); ;
                        break;
                    }

                    dia++;
                }
            }
            else
            {
                despesa.Data = new DateTime(ano, mes, despesa.Dia);
            }

            Movimentacao movimentacao = new Movimentacao();

            movimentacao.Descricao = despesa.Descricao;
            movimentacao.Valor = despesa.Valor;
            movimentacao.Valor_Previsto = despesa.Valor;
            movimentacao.Data = despesa.Data;
            movimentacao.Data_Prevista = despesa.Data;
            movimentacao.ID_Conta = despesa.ID_Conta;
            movimentacao.ID_Categoria = despesa.ID_CatFin;
            movimentacao.Orcamento = true;

            RegistrarMovimentacao(movimentacao, false, true, false);
        }
        #endregion

        #endregion
    }

    #region Classes

    #region Geral

    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime Registro { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class Tema
    {
        public Color Cor_Principal { get; set; }
        public Color Cor_Secundaria { get; set; }
        public Font Fonte_Principal { get; set; }
        public Font Fonte_Secundaria { get; set; }
        public int ID_Usuario { get; set; }
        public string Descricao { get; set; }
    }

    public class SuggestComboBox : ComboBox
    {
        #region fields and properties

        private readonly ListBox _suggLb = new ListBox { Visible = false, TabStop = false };
        private readonly BindingList<string> _suggBindingList = new BindingList<string>();
        private Expression<Func<ObjectCollection, IEnumerable<string>>> _propertySelector;
        private Func<ObjectCollection, IEnumerable<string>> _propertySelectorCompiled;
        private Expression<Func<string, string, bool>> _filterRule;
        private Func<string, bool> _filterRuleCompiled;
        private Expression<Func<string, string>> _suggestListOrderRule;
        private Func<string, string> _suggestListOrderRuleCompiled;

        public int SuggestBoxHeight
        {
            get { return _suggLb.Height; }
            set { if (value > 0) _suggLb.Height = value; }
        }
        /// <summary>
        /// If the item-type of the ComboBox is not string,
        /// you can set here which property should be used
        /// </summary>
        public Expression<Func<ObjectCollection, IEnumerable<string>>> PropertySelector
        {
            get { return _propertySelector; }
            set
            {
                if (value == null) return;
                _propertySelector = value;
                _propertySelectorCompiled = value.Compile();
            }
        }

        ///<summary>
        /// Lambda-Expression to determine the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: case-insensitive contains search</para>
        /// <para>1st string: list item</para>
        /// <para>2nd string: typed text</para>
        ///</summary>
        public Expression<Func<string, string, bool>> FilterRule
        {
            get { return _filterRule; }
            set
            {
                if (value == null) return;
                _filterRule = value;
                _filterRuleCompiled = item => value.Compile()(item, Text);
            }
        }

        ///<summary>
        /// Lambda-Expression to order the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: alphabetic ordering</para>
        ///</summary>
        public Expression<Func<string, string>> SuggestListOrderRule
        {
            get { return _suggestListOrderRule; }
            set
            {
                if (value == null) return;
                _suggestListOrderRule = value;
                _suggestListOrderRuleCompiled = value.Compile();
            }
        }

        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public SuggestComboBox()
        {
            // set the standard rules:
            _filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());
            _suggestListOrderRuleCompiled = s => s;
            _propertySelectorCompiled = collection => collection.Cast<string>();

            _suggLb.DataSource = _suggBindingList;
            _suggLb.Click += SuggLbOnClick;

            ParentChanged += OnParentChanged;
        }

        /// <summary>
        /// the magic happens here ;-)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!Focused) return;

            _suggBindingList.Clear();
            _suggBindingList.RaiseListChangedEvents = false;
            _propertySelectorCompiled(Items)
                 .Where(_filterRuleCompiled)
                 .OrderBy(_suggestListOrderRuleCompiled)
                 .ToList()
                 .ForEach(_suggBindingList.Add);
            _suggBindingList.RaiseListChangedEvents = true;
            _suggBindingList.ResetBindings();

            _suggLb.Visible = _suggBindingList.Any();

            if (_suggBindingList.Count == 1 &&
                        _suggBindingList.Single().Length == Text.Trim().Length)
            {
                Text = _suggBindingList.Single();
                Select(0, Text.Length);
                _suggLb.Visible = false;
            }
        }

        /// <summary>
        /// suggest-ListBox is added to parent control
        /// (in ctor parent isn't already assigned)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParentChanged(object sender, EventArgs e)
        {
            Parent.Controls.Add(_suggLb);
            Parent.Controls.SetChildIndex(_suggLb, 0);
            _suggLb.Top = Top + Height;
            _suggLb.Left = Left;
            _suggLb.Width = Width;
            _suggLb.Font = new Font("Segoe UI", 9);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            // _suggLb can only getting focused by clicking (because TabStop is off)
            // --> click-eventhandler 'SuggLbOnClick' is called
            if (!_suggLb.Focused)
                HideSuggBox();
            base.OnLostFocus(e);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            _suggLb.Top = Top + Height;
            _suggLb.Left = Left;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _suggLb.Width = Width;
        }

        private void SuggLbOnClick(object sender, EventArgs eventArgs)
        {
            Text = _suggLb.Text;
            Focus();
        }

        private void HideSuggBox()
        {
            _suggLb.Visible = false;
        }

        protected override void OnDropDown(EventArgs e)
        {
            HideSuggBox();
            base.OnDropDown(e);
        }

        #region keystroke events

        /// <summary>
        /// if the suggest-ListBox is visible some keystrokes
        /// should behave in a custom way
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (!_suggLb.Visible)
            {
                base.OnPreviewKeyDown(e);
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (_suggLb.SelectedIndex < _suggBindingList.Count - 1)
                        _suggLb.SelectedIndex++;
                    return;
                case Keys.Up:
                    if (_suggLb.SelectedIndex > 0)
                        _suggLb.SelectedIndex--;
                    return;
                case Keys.Enter:
                    Text = _suggLb.Text;
                    Select(0, Text.Length);
                    _suggLb.Visible = false;
                    return;
                case Keys.Escape:
                    HideSuggBox();
                    return;
            }

            base.OnPreviewKeyDown(e);
        }

        private static readonly Keys[] KeysToHandle = new[]
                    { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // the keysstrokes of our interest should not be processed be base class:
            if (_suggLb.Visible && KeysToHandle.Contains(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }

    public class Parametro
    {
        public int ID_Parametro { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public bool Edicao { get; set; } //Utilizado apenas para editar configurações
    }

    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }

    class DataGridViewProgressCell : DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;
        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);
        }
        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }
        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                int progressVal = (int)value;
                float percentage = ((float)progressVal / 100.0f); // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.
                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                // Draws the cell grid
                base.Paint(g, clipBounds, cellBounds,
                 rowIndex, cellState, value, formattedValue, errorText,
                 cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

                //if (percentage > 0.0)
                //{
                    // Draw the progress bar and the text
                    g.FillRectangle(new SolidBrush(Color.FromArgb(203, 235, 108)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                    g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + (cellBounds.Width / 2) - 5, cellBounds.Y + 2);

                //}
                //else
                //{
                //    // draw the text
                //    if (this.DataGridView.CurrentRow.Index == rowIndex)
                //        g.DrawString(progressVal.ToString() + "%", cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2);
                //    else
                //        g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + 6, cellBounds.Y + 2);
                //}
            }
            catch (Exception e) { }

        }
    }

    #endregion

    #region Gerenciamento

    public class Papel
    {
        public int ID_Papel { get; set; }
        public string Descricao { get; set; }
        public int Compromissos { get; set; }
        public Color Cor { get; set; }
    }

    public class Tarefa_Semanal
    {
        public int ID_Tarefa { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }
        public string Dia { get; set; }
        public int Tempo { get; set; }
        public DateTime Data { get; set; }
        public int ID_Papel { get; set; }
        public string Status { get; set; }

        public Color Cor { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int Multiplicador { get; set; }
        public bool Fixa { get; set; }
    }

    public class Tarefa
    {
        public string Descricao { get; set; }
        public string Papel { get; set; }
        public int ID_Papel { get; set; }
        public string Observacao { get; set; }
        public DateTime Dia { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Status { get; set; }
    }

    public static class Atalho
    {
        public static string PrimeiraLetraMaiuscula(this string inserir)
        {
            if (String.IsNullOrEmpty(inserir))
                throw new ArgumentException("Insira uma palavra");
            return inserir.Length > 1 ? char.ToUpper(inserir[0]) + inserir.Substring(1) : inserir.ToUpper();
        }
    }

    #endregion

    #region Plano de ação

    public class Plano
    {
        public int ID_Projeto { get; set; }
        public string Detalhes { get; set; }
        public string Status { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Resultado_Esperado { get; set; }


        public string Descricao { get; set; }

        //Novos
        public string O_Que { get; set; }
        public string Por_Que { get; set; }
        public string Onde { get; set; }
        public List<Etapa> Etapas { get; set; }
        public List<Custo> Custos { get; set; }
        public List<Checklist> Checklist { get; set; }
        public bool Conclusao { get; set; }
        public bool Arquivado { get; set; }
    }

    public class Etapa : Plano
    {
        public string Projeto { get; set; }
        public int ID_Etapa { get; set; }
        public int Ordem { get; set; }


        //Novos
        public new string Descricao { get; set; }
        public string Como { get; set; }
       // public string Quem { get; set; }
        public int Prazo { get; set; }
        public DateTime Previsao_Inicio { get; set; }
        public new DateTime Inicio { get; set; }
        public DateTime Previsao_Termino { get; set; }
        public new DateTime Termino { get; set; }
        public bool Conclusao { get; set; }
        public string Resultado { get; set; }
    }

    public class Checklist : Etapa
    {
        public int ID { get; set; }
        public int Referencia { get; set; }
        public string Etapa { get; set; }
        public bool Confirmacao { get; set; }
    }

    public class Custo
    {
        public int ID { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
    }

    #endregion

    #region Finanças

    public class Movimentacao
    {
        public int ID_Movimentacao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Data_Prevista { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Valor_Previsto { get; set; }
        public string Status { get; set; }
        public int ID_Categoria { get; set; }
        public string Conta { get; set; }
        public int ID_Conta { get; set; }
        public bool Orcamento { get; set; }
        public bool Itens { get; set; }
        public DateTime Data_Movimentacao { get; set; }
    }

    public class Item
    {
        public int ID_Item { get; set; }
        public int ID_Movimentacao { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Previsto { get; set; }
        public int Quantidade { get; set; }
    }

    public class Categoria_Financeira
    {
        public int ID { get; set; }
        public string Categoria { get; set; }
        public int ID_Parente { get; set; }
        public int ID_CatCon { get; set; }
        public string Tipo { get; set; }
    }

    public class Conta
    {
        public int ID_Conta { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Saldo { get; set; }
        public string Agencia { get; set; }
        public string N_Conta { get; set; }
        public int ID_Banco { get; set; }
        public bool Visivel { get; set; }
    }

    public class Banco
    {
        public int ID_Banco { get; set; }
        public string Descricao { get; set; }
        public string Cod_Banco { get; set; }
    }

    public class Transferencia
    {
        public int ID_Origem { get; set; }
        public int ID_Destino { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }

    public class FluxoDeCaixa
    {
        public int ID { get; set; }
        public int ID_Parente { get; set; }
        public string Categoria { get; set; }
        public decimal Valor1 { get; set; }
        public decimal Esperado1 { get; set; }
        public decimal AV1 { get; set; }
        public decimal AH2 { get; set; }
        public decimal Valor2 { get; set; }
        public decimal Esperado2 { get; set; }
        public decimal AV2 { get; set; }
        public decimal AH3 { get; set; }
        public decimal Valor3 { get; set; }
        public decimal Esperado3 { get; set; }
        public decimal AV3 { get; set; }
        public decimal AH4 { get; set; }
        public decimal Valor4 { get; set; }
        public decimal Esperado4 { get; set; }
        public decimal AV4 { get; set; }
    }

    public class Afazer
    {
        public int ID_Afazer { get; set; }
        public int Ordem { get; set; }
        public int ID_Etapa { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public int Minutos { get; set; }
        public int ID_Colaborador { get; set; }
        public bool Conclusao { get; set; }
        public DateTime Registro { get; set; }
        public DateTime Data { get; set; }
        public bool Rotina { get; set; }


    }

    public class Rotina : Afazer
    {
        public int ID_Rotina { get; set; }
        public bool Mensal { get; set; }

        //Intervalo diário
        public int Intervalo { get; set; }

        //Intervalos mensais
        public int Dia { get; set; }
        public bool Ultimo_Dia { get; set; }
    }

    public class Despesa
    {
        public int ID_Despesa { get; set; }
        public int ID_Usuario { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Categoria_Financeira { get; set; }
        public int ID_CatFin { get; set; }
        public int Dia { get; set; }
        public DateTime Data { get; set; }
        public bool Dia_Util { get; set; }
        public bool Ultimo_Dia { get; set; }
        public bool Mesmo_Dia { get; set; }
        public bool Antes_do_Dia { get; set; }
        public bool Depois_do_Dia { get; set; }
        public int ID_Conta { get; set; }
    }

    public class Login
    {
        public int ID_Login { get; set; }
        public int ID_Usuario { get; set; }
        public string Descricao { get; set; }
        public string Log_in { get; set; }
        public string Senha { get; set; }
    }

    #endregion

    #region Exercícios

    public class FraseMotivacional
    {
        public int ID_Frase { get; set; }
        public int ID_Usuario { get; set; }
        public string Descricao { get; set; }
    }

    public class GrupoMuscular
    {
        public int ID_Grupo { get; set; }
        public int ID_Usuario { get; set; }
        public string Descricao { get; set; }
        public bool Check { get; set; }
    }


    public class Exercicio : GrupoMuscular
    {
        public int ID_Exercicio { get; set; }
        public int Ordem { get; set; }
        public string Grupo { get; set; }
        public string Tipo { get; set; }
        public string Peso { get; set; }
        public string Series { get; set; }
        public string Ajuste { get; set; }
        public string Detalhes { get; set; }
        public bool Aerobico { get; set; }

    }

    public class Treino
    {
        public int ID_Treino { get; set; }
        public string Descricao { get; set; }

        public int ID_Usuario { get; set; }
        public DateTime Data { get; set; }
        public bool Conclusao { get; set; }
        public string Grupos { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public string Dia { get; set; }
        public int ID_Tarefa { get; set; }
    }

    #endregion

    #region Metas

    public class Objetivo
    {
        public int ID_Objetivo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public int ID_Usuario { get; set; }
        public decimal Progresso { get; set; }
    }

    public class Resultado : Objetivo
    {
        public int ID_Resultado { get; set; }
        public decimal Inicial { get; set; }
        public decimal Meta { get; set; }
        public string Objetivo { get; set; }
        public string Un_Medida { get; set; }
        public string Agressividade { get; set; }
        public int Periodicidade { get; set; }
    }

    public class Acompanhamento : Resultado
    {
        public int ID_Acompanhamento { get; set; }
        public decimal Atual { get; set; }
        public DateTime Data { get; set; }
        public Color Cor { get; set; }
    }

    public class Iniciativa
    {
        public int ID_Iniciativa { get; set; }
        public int ID_Resultado { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public string Status { get; set; }
        public string Referencia { get; set; }
    }

    public class Recompensa
    {
        public int ID_Recompensa { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public List<Objetivo> Objetivos { get; set; }
    }

    #endregion

    #endregion
}


