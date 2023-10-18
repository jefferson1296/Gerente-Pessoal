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
    public partial class formGerenteTreinamentosTreinos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Treino> treinos = new List<Treino>();
        int id;

        public formGerenteTreinamentosTreinos()
        {
            InitializeComponent();
        }

        private void formGerenteTreinamentosTreinos_Load(object sender, EventArgs e)
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

            treinos = comandos.TrazerTreinos();
            dataGridViewLista.Rows.Clear();

            if (treinos.Count == 0) { labelMensagem.Visible = true; }
            else { labelMensagem.Visible = false; }


            foreach (Treino treino in treinos)
            {
                dataGridViewLista.Rows.Add(treino.ID_Treino, treino.Descricao, treino.Grupos);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonTreinos_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosTreinosAdicionar adicionar = new formGerenteTreinamentosTreinosAdicionar();
            adicionar.ShowDialog();
            AtualizarDataGrid();
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
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o treino?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarTreino(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string descricao = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                formGerenteTreinamentosTreinosExercicios exercicios = new formGerenteTreinamentosTreinosExercicios(id, descricao);
                exercicios.ShowDialog();
            }
        }

        private void renomearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formGerenteTreinamentosTreinosAdicionar adicionar = new formGerenteTreinamentosTreinosAdicionar(id);
                adicionar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirTreino(id, true);
            }
        }

        private void importarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirTreino(id, false);
            }
        }
    }
}
