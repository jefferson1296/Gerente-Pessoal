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
    public partial class formGerenteFinanceiroDespesasOrcamento : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Despesa> Despesas = new List<Despesa>();

        int mes;
        int ano;

        int id;

        public formGerenteFinanceiroDespesasOrcamento()
        {
            InitializeComponent();
        }

        private void formGerenteFinanceiroDespesasOrcamento_Load(object sender, EventArgs e)
        {
            DateTime data = DateTime.Now;
            string proximo_mes = comandos.ConverterMesIntParaExtenso(data.AddMonths(1).Month).ToUpper() + "/" + data.AddMonths(1).Year.ToString();

            for (int i = 0; i < 13; i++)
            {
                string Mes = comandos.ConverterMesIntParaExtenso(data.Month).ToUpper() + "/" + data.Year.ToString();
                comboBoxPeriodo.Items.Add(Mes);

                data = data.AddMonths(1);
            }

            comboBoxPeriodo.Text = proximo_mes;
        }

        private void DefinirPeriodo()
        {
            string data = comboBoxPeriodo.Text;
            string[] partir = data.Split('/');
            string Mes = partir[0];
            mes = comandos.ConverterMesPorExtensoEmInt(Mes);
            ano = Convert.ToInt32(partir[1]);
        }

        private void comboBoxPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefinirPeriodo();
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            Despesas = comandos.ListaDeDespesasParaLancamento(mes, ano);

            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            foreach (Despesa Despesa in Despesas)
            {
                dataGridViewLista.Rows.Add(Despesa.ID_Despesa, Despesa.Descricao, Despesa.Valor.ToString("C"), Despesa.Data.ToShortDateString());
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

        }

        private void buttonConcluir_Click(object sender, EventArgs e)
        {
            comandos.LancarDespesas(Despesas);
            Dispose();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                }
            }
            catch { }
        }

        private void orcamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.LancarDespesa(id, mes, ano);
            }
        }
    }
}
