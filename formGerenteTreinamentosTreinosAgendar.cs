using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formGerenteTreinamentosTreinosAgendar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        DateTime Atual = new DateTime();
        DateTime Dia1 = new DateTime();

        CultureInfo cultura = new CultureInfo("pt-BR");
        DateTimeFormatInfo formato = new DateTimeFormatInfo();

        List<Treino> treinos = new List<Treino>();
        List<Treino> treinos_disponiveis = new List<Treino>();

        Treino treino = new Treino();

        int id_treino;

        bool arrastar;
        bool atualizar_listas;

        public formGerenteTreinamentosTreinosAgendar()
        {
            InitializeComponent();
        }

        private void formGerenteTreinamentosTreinosAgendar_Load(object sender, EventArgs e)
        {
            formato = cultura.DateTimeFormat;

            Atual = DateTime.Now;

            AtualizarDatas();
            AtualizarListas();

            atualizar_listas = true;
        }

        private void AtualizarDatas()
        {
            int dia = Atual.Day;
            int semana = dia / 7;
            if (dia % 7 > 0) { semana++; }

            string mes_ = Atual.ToString(@"MMMM");
            string Mes = mes_.PrimeiraLetraMaiuscula().Substring(0, 3);
            string data = "Semana " + semana + " - " + Mes + "/" + Convert.ToString(Atual.Year);
            labelData.Text = data;

            string dia_da_semana = comandos.PrimeiraLetraMaiuscula(formato.GetDayName(Atual.DayOfWeek));

            if (dia_da_semana == "Domingo") { Dia1 = Atual; }
            else if (dia_da_semana == "Segunda-feira") { Dia1 = Atual.AddDays(-1); }
            else if (dia_da_semana == "Terça-feira") { Dia1 = Atual.AddDays(-2); }
            else if (dia_da_semana == "Quarta-feira") { Dia1 = Atual.AddDays(-3); }
            else if (dia_da_semana == "Quinta-feira") { Dia1 = Atual.AddDays(-4); }
            else if (dia_da_semana == "Sexta-feira") { Dia1 = Atual.AddDays(-5); }
            else if (dia_da_semana == "Sábado") { Dia1 = Atual.AddDays(-6); }

            ColunaDomingo.HeaderText = "Domingo " + Dia1.ToShortDateString().Substring(0, 5);
            ColunaSegunda.HeaderText = "Segunda-feira " + Dia1.AddDays(1).ToShortDateString().Substring(0, 5);
            ColunaTerca.HeaderText = "Terça-feira " + Dia1.AddDays(2).ToShortDateString().Substring(0, 5);
            ColunaQuarta.HeaderText = "Quarta-feira " + Dia1.AddDays(3).ToShortDateString().Substring(0, 5);
            ColunaQuinta.HeaderText = "Quinta-feira " + Dia1.AddDays(4).ToShortDateString().Substring(0, 5);
            ColunaSexta.HeaderText = "Sexta-feira " + Dia1.AddDays(5).ToShortDateString().Substring(0, 5);
            ColunaSabado.HeaderText = "Sábado " + Dia1.AddDays(6).ToShortDateString().Substring(0, 5);

            foreach (DataGridViewColumn coluna in dataGridPlanejamento.Columns)
            {
                string[] partir = coluna.HeaderText.Split(' ');

                if (partir[0] == dia_da_semana)
                {
                    coluna.HeaderCell.Style.BackColor = Color.White;
                    coluna.HeaderCell.Style.Font = new Font("Century", 9, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        private void CriarMatriz()
        {
            int x;
            int y;
            string hora;

            treinos.Clear();

            for (x = 1; x <= 7; x++)
            {
                for (y = 0; y <= 23; y++)
                {
                    Treino treino = new Treino();

                    treino.X = x;
                    treino.Y = y;

                    if (x == 1) { treino.Dia = "Domingo"; }
                    if (x == 2) { treino.Dia = "Segunda-feira"; }
                    if (x == 3) { treino.Dia = "Terça-feira"; }
                    if (x == 4) { treino.Dia = "Quarta-feira"; }
                    if (x == 5) { treino.Dia = "Quinta-feira"; }
                    if (x == 6) { treino.Dia = "Sexta-feira"; }
                    if (x == 7) { treino.Dia = "Sábado"; }

                    if (y <= 9) { hora = "0" + y + ":00"; } else { hora = y.ToString() + ":00"; }

                    treino.Data = Convert.ToDateTime(Dia1.AddDays(x - 1).ToShortDateString() + " " + hora);

                    treinos.Add(treino);
                }
            }
        }

        private void AtualizarListas()
        {
            AtualizarPlanejamentoSemanal();
            AtualizarListaDeAtividadesDisponiveis();
        }

        private void AtualizarPlanejamentoSemanal()
        {
            //CriarMatriz();

            //string hora;
            //comandos.PreencherTreinosDoPlanejamentoSemanal(Dia1, tarefas, tipo);

            //dataGridPlanejamento.Rows.Clear();

            //for (int y = 0; y <= 23; y++)
            //{
            //    if (y <= 9) { hora = "0" + y + ":00"; } else { hora = y.ToString() + ":00"; }

            //    dataGridPlanejamento.Rows.Add(
            //        hora,
            //        tarefas.Where(t => t.Y == y && t.X == 1).Select(x => x.Descricao).FirstOrDefault(),
            //        tarefas.Where(t => t.Y == y && t.X == 2).Select(x => x.Descricao).FirstOrDefault(),
            //        tarefas.Where(t => t.Y == y && t.X == 3).Select(x => x.Descricao).FirstOrDefault(),
            //        tarefas.Where(t => t.Y == y && t.X == 4).Select(x => x.Descricao).FirstOrDefault(),
            //        tarefas.Where(t => t.Y == y && t.X == 5).Select(x => x.Descricao).FirstOrDefault(),
            //        tarefas.Where(t => t.Y == y && t.X == 6).Select(x => x.Descricao).FirstOrDefault(),
            //        tarefas.Where(t => t.Y == y && t.X == 7).Select(x => x.Descricao).FirstOrDefault()
            //        );
            //}

            //if (dataGridPlanejamento.CurrentRow != null)
            //    dataGridPlanejamento.CurrentRow.Selected = false;
        }

        private void AtualizarListaDeAtividadesDisponiveis()
        {
            //tarefas_disponiveis = comandos.PreencherPainelDeTarefas(Dia1);

            //int linha_selecionada = 0, primeira_linha = 0;

            //if (dataGridViewTarefas.CurrentRow != null)
            //{
            //    primeira_linha = dataGridViewTarefas.FirstDisplayedScrollingRowIndex;
            //    linha_selecionada = dataGridViewTarefas.CurrentRow.Index;
            //}

            //dataGridViewTarefas.Rows.Clear();

            //foreach (Tarefa_Semanal tarefa in tarefas_disponiveis)
            //{
            //    dataGridViewTarefas.Rows.Add(tarefa.ID_Tarefa, tarefa.Descricao, tarefa.ID_Papel);
            //}

            //try
            //{
            //    dataGridViewTarefas.FirstDisplayedScrollingRowIndex = primeira_linha;
            //    dataGridViewTarefas.CurrentCell = dataGridViewTarefas.Rows[linha_selecionada].Cells[0];
            //}
            //catch { }

            //if (dataGridViewTarefas.CurrentRow != null)
            //    dataGridViewTarefas.CurrentRow.Selected = false;
        }
    }
}
