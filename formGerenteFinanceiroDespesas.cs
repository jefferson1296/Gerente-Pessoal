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
    public partial class formGerenteFinanceiroDespesas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Despesa> Despesas = new List<Despesa>();

        int id;
        string descricao;

        public bool alteracao = false;
        public formGerenteFinanceiroDespesas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFinanceiroDespesas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroDespesasAdicionar adicionar = new formGerenteFinanceiroDespesasAdicionar(this);
            adicionar.ShowDialog();
            if (alteracao)
            {
                AtualizarDataGrid();
                alteracao = false;
            }
        }

        private void AtualizarDataGrid()
        {
            Despesas = comandos.ListaDeDespesas();

            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (Despesa Despesa in Despesas)
            {
                string Dia;
                if (!Despesa.Ultimo_Dia && !Despesa.Dia_Util) { Dia = Despesa.Dia.ToString(); }
                else if (!Despesa.Ultimo_Dia && Despesa.Dia_Util)
                {
                    Dia = Despesa.Dia.ToString() + "º dia útil";
                }
                else { Dia = "Último dia"; }

                dataGridViewLista.Rows.Add(Despesa.ID_Despesa, Despesa.Descricao, Despesa.Tipo, Despesa.Valor.ToString("C"), Dia);
            }

            decimal total = Despesas.Sum(x => x.Valor);
            labelTotal.Text = total.ToString("C");

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

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

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    descricao = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                }                           
            }
            catch { }

        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id != 0)
                {
                    formGerenteFinanceiroDespesasAdicionar editar = new formGerenteFinanceiroDespesasAdicionar(this, id);
                    editar.ShowDialog();
                    if (alteracao)
                    {
                        AtualizarDataGrid();
                        alteracao = false;
                    }
                }
            }
            catch { }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("A despesa \"" + descricao + "\" será excluída permanentemente.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarDespesa(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void somatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow linha in dataGridViewLista.SelectedRows)
            {
                total = total + comandos.ConverterDinheiroEmDecimal(dataGridViewLista.Rows[linha.Index].Cells[3].Value.ToString());
            }

            MessageBox.Show("Total: " + total.ToString("C"), "Somatório");
        }

        private void labelOrcamento_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroDespesasOrcamento orcamento = new formGerenteFinanceiroDespesasOrcamento();
            orcamento.ShowDialog();
        }
    }
}
