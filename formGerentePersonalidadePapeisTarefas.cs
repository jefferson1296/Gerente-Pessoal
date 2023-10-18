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
    public partial class formGerentePersonalidadePapeisTarefas : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        List<Tarefa_Semanal> tarefas = new List<Tarefa_Semanal>();

        int id_papel;
        int id;

        public formGerentePersonalidadePapeisTarefas()
        {
            InitializeComponent();
        }

        public formGerentePersonalidadePapeisTarefas(int ID_Papel)
        {
            InitializeComponent();
            id_papel = ID_Papel;
        }

        private void formGerentePersonalidadePapeisTarefas_Load(object sender, EventArgs e)
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

            tarefas = comandos.TrazerTarefasFixas(id_papel);

            dataGridViewLista.Rows.Clear();

            if (tarefas.Count == 0) { labelMensagem.Visible = true; }
            else { labelMensagem.Visible = false; }

            foreach (Tarefa_Semanal tarefa in tarefas)
            {
                dataGridViewLista.Rows.Add(tarefa.ID_Tarefa, tarefa.Descricao, tarefa.Multiplicador);
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadePapeisTarefasAdicionar adicionar = new formGerentePersonalidadePapeisTarefasAdicionar(id_papel);
            adicionar.ShowDialog();

            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                if (id != 0)
                {
                    formGerentePersonalidadePapeisTarefasAdicionar editar = new formGerentePersonalidadePapeisTarefasAdicionar(id, id_papel);
                    editar.ShowDialog();

                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ApagarTarefaFixa(id);
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
    }
}
