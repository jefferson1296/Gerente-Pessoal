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
    public partial class formGerenteTreinamentosFrases : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<FraseMotivacional> frases = new List<FraseMotivacional>();
        int id;

        public formGerenteTreinamentosFrases()
        {
            InitializeComponent();
        }

        private void formGerenteTreinamentosGrupos_Load(object sender, EventArgs e)
        {
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

            frases = comandos.TrazerFrasesMotivacionais();
            dataGridViewLista.Rows.Clear();

            foreach (FraseMotivacional frase in frases)
            {
                dataGridViewLista.Rows.Add(frase.ID_Frase, frase.Descricao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
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

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a frase?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarFraseMotivacional(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosFrasesAdicionar adicionar = new formGerenteTreinamentosFrasesAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    formGerenteTreinamentosFrasesAdicionar editar = new formGerenteTreinamentosFrasesAdicionar(id);
                    editar.ShowDialog();
                    AtualizarDataGrid();
                }
                else
                {
                    id = 0;
                }
            }
            catch { }
        }
    }
}
