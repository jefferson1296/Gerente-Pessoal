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
    public partial class formGerenteFinanceiroLancamentosContas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Conta> contas = new List<Conta>();

        int id_conta;
        public formGerenteFinanceiroLancamentosContas()
        {
            InitializeComponent();
        }

        private void formFinanceiroFluxoContas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroLancamentosContasAdicionar adicionar = new formGerenteFinanceiroLancamentosContasAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            contas = comandos.ListaDeContas();
            dataGridViewLista.Rows.Clear();

            foreach (Conta Conta in contas)
            {
                dataGridViewLista.Rows.Add(Conta.ID_Conta, Conta.Descricao, Conta.Categoria, Conta.Saldo.ToString("C"), Conta.Visivel);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_conta = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id_conta != 0)
                {
                    formGerenteFinanceiroLancamentosContasAdicionar alterar = new formGerenteFinanceiroLancamentosContasAdicionar(id_conta);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewLista.Rows[e.RowIndex].Selected = true;
                        dataGridViewLista.Focus();

                        id_conta = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_conta = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_conta != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a conta?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarConta(id_conta);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    id_conta = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    bool visivel = !Convert.ToBoolean(dataGridViewLista.Rows[e.RowIndex].Cells[4].Value);

                    dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = visivel;
                    comandos.EditarVisibilidadeDaConta(id_conta, visivel);
                }
                else
                {
                    id_conta = 0;
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            DataGridViewRow linha = dataGridViewLista.Rows[e.RowIndex];

            if (e.ColumnIndex == 4)
            {
                bool check = Convert.ToBoolean(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);

                if (!check)
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    linha.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.Black;
                    linha.DefaultCellStyle.ForeColor = Color.Black;
                }
            }

        }
    }
}
