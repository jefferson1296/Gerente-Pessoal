using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formGerenteFinanceiroSaldo : Form
    {
        bool clique;
        Point clickedAt;
        List<Conta> contas = new List<Conta>();
        ComandosSQL comandos = new ComandosSQL();

        DateTime data = new DateTime();

        public formGerenteFinanceiroSaldo()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFinanceiroSaldo_Load(object sender, EventArgs e)
        {
            string data_atual = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString();
            labelData.Text = data_atual;
            labelData.Left = panelSuperior.Left + ((panelSuperior.Width - labelData.Width) / 2);

            data = dateTimePicker.Value.Date;

            AtualizarDataGrid();

            pbAnterior.Focus();
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            contas = comandos.TrazerSaldoDasContas(data);

            foreach (Conta conta in contas)
            {
                dataGridViewLista.Rows.Add(conta.Descricao.ToUpper(), conta.Saldo.ToString("C"));
            }

            decimal saldo_total = contas.Sum(x => x.Saldo);
            decimal reservas = contas.Where(x => x.Descricao == "Capital de giro" || x.Descricao == "Reserva de emergência" || x.Descricao == "Dinheiro trocado").Sum(x => x.Saldo);

            decimal liquido = saldo_total - reservas;

            textBoxSaldo.Text = saldo_total.ToString("C");
            textBoxLiquido.Text = liquido.ToString("C");

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Movimentacao do Formulario
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

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Font minha_fonte = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.Font = minha_fonte;

            if (e.ColumnIndex == 1)
            {
                string valor = dataGridViewLista[1, e.RowIndex].Value.ToString();
                decimal saldo = comandos.ConverterDinheiroEmDecimal(valor);

                if (saldo > 0)
                {
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.ForestGreen;
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.ForestGreen;
                }
                else if (saldo < 0)
                {
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkRed;
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.DarkRed;
                }
                else
                {
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGray;
                    dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.SelectionForeColor = Color.DarkGray;
                }

                dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else if (e.ColumnIndex == 0)
            {
                dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

        }

        private void pictureBoxVer_Click(object sender, EventArgs e)
        {
            if (textBoxSaldo.UseSystemPasswordChar == true)
                textBoxSaldo.UseSystemPasswordChar = false;
            else
                textBoxSaldo.UseSystemPasswordChar = true;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker.Value.Date;
            AtualizarDataGrid();
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void labelCalculadora_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }
    }
}
