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
    public partial class formGerentePersonalidadePapeis : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        List<Papel> Papeis = new List<Papel>();

        int id;

        DateTime dia1 = new DateTime();

        public formGerentePersonalidadePapeis()
        {
            InitializeComponent();
        }

        public formGerentePersonalidadePapeis(DateTime Dia1)
        {
            InitializeComponent();
            dia1 = Dia1;
        }

        private void formGerentePersonalidadePapeis_Load(object sender, EventArgs e)
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

            Papeis = comandos.TrazerPapeis(dia1);

            dataGridViewLista.Rows.Clear();

            if (Papeis.Count == 0) { labelMensagem.Visible = true; }
            else { labelMensagem.Visible = false; }

            foreach (Papel Papel in Papeis)
            {
                dataGridViewLista.Rows.Add(Papel.ID_Papel, "", Papel.Descricao, Papel.Compromissos);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;

            DestacarMarcadores();
        }

        private void DestacarMarcadores()
        {
            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {
                int id = Convert.ToInt32(dataGridViewLista[0, linha.Index].Value);
                Color cor = Papeis.Where(x => x.ID_Papel == id).Select(x => x.Cor).FirstOrDefault();
                dataGridViewLista[1, linha.Index].Style.BackColor = cor;
                dataGridViewLista[1, linha.Index].Style.SelectionBackColor = cor;
            }

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadePapeisAdicionar adicionar = new formGerentePersonalidadePapeisAdicionar();
            adicionar.ShowDialog();

            AtualizarDataGrid();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarPapel(id);
                AtualizarDataGrid();
            }
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

                        id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                dataGridViewLista[e.ColumnIndex, e.RowIndex].Style.Font = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Point);
            }
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                if (id != 0)
                {
                    formGerentePersonalidadePapeisAdicionar editar = new formGerentePersonalidadePapeisAdicionar(id);
                    editar.ShowDialog();

                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void tarefasFixasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formGerentePersonalidadePapeisTarefas tarefas = new formGerentePersonalidadePapeisTarefas(id);
                tarefas.ShowDialog();
            }
        }
    }
}
