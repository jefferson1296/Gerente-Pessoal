using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formTarefasDoDia : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Tarefa> Lista = new List<Tarefa>();
        public formTarefasDoDia()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void buttonCarregar_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker1.Text;
            if (dateTimePicker1.Value < DateTime.Now.Date)
            {
                MessageBox.Show("Não é possível adicionar atividades em datas que já se passaram!");
            }
            else
            {
                AtualizarDataGrid(data);
            }
        }

        private void AtualizarDataGrid(string data)
        {
            dataGridTarefas.Rows.Clear();
            Lista = comandos.TrazerAtividadesDoDia(data);
            foreach (Tarefa Tarefa in Lista)
            {
                string hora = Tarefa.Inicio.ToShortTimeString() + " ~ " + Tarefa.Termino.ToShortTimeString();
                string descricao = Tarefa.Descricao;

                dataGridTarefas.Rows.Add(hora, descricao);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string atividade = textBoxAtividade.Text;
            string observacao = textBoxObservacao.Text;
            DateTime dia = dateTimePicker1.Value;
            DateTime inicio = Convert.ToDateTime(maskedTextBoxHora.Text);
            int tempo = Convert.ToInt32(textBoxTempo.Text);
            DateTime termino = inicio.AddMinutes(tempo);

            Tarefa Tarefa = new Tarefa()
            {
                Descricao = atividade,
                Observacao = observacao,
                Dia = dia,
                Inicio = inicio,
                Termino = termino
            };

            comandos.RegistrarAtividadeDiaria(Tarefa);
            textBoxAtividade.Clear();
            textBoxObservacao.Clear();
            textBoxTempo.Clear();
            maskedTextBoxHora.Text = comandos.HoraDaUltimaAtividade(dia.ToShortDateString());
            AtualizarDataGrid(dia.ToShortDateString());
        }

        private void textBoxTempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void dataGridTarefas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string data = dateTimePicker1.Text;
                string atividade = dataGridTarefas.Rows[e.RowIndex].Cells[1].Value.ToString();
                string detalhes = comandos.TrazerDetalhesDaAtividade(atividade, data);

                MessageBox.Show(detalhes, atividade, MessageBoxButtons.OK);
            }
            catch { }
        }
    }
}
