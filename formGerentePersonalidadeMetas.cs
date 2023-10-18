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
    public partial class formGerentePersonalidadeMetas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Objetivo> objetivos = new List<Objetivo>();
        int id_objetivo;

        DateTime data_atual;

        public formGerentePersonalidadeMetas()
        {
            InitializeComponent();
        }

        private void formAtividadesProcessos_Load(object sender, EventArgs e)
        {
            data_atual = DateTime.Now;

            DataGridViewProgressColumn column = new DataGridViewProgressColumn();

            dataGridViewLista.Columns.Add(column);
            dataGridViewLista.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.HeaderText = "Progresso";

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

            objetivos = comandos.TrazerObjetivos(data_atual);
            dataGridViewLista.Rows.Clear();

            if (objetivos.Count > 0)
                labelMensagem.Visible = false;
            else
                labelMensagem.Visible = true;            

            foreach (Objetivo objetivo in objetivos)
            {
                dataGridViewLista.Rows.Add(objetivo.ID_Objetivo, objetivo.Descricao, objetivo.Inicio.ToShortDateString(), objetivo.Termino.ToShortDateString(), Convert.ToInt32(objetivo.Progresso));
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
                id_objetivo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string objetivo = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();

                formGerentePersonalidadeMetasResultados resultados = new formGerentePersonalidadeMetasResultados(id_objetivo, objetivo);
                resultados.ShowDialog();
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadeMetasAdicionar adicionar = new formGerentePersonalidadeMetasAdicionar();
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

                        id_objetivo = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_objetivo = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_objetivo != 0)
            {
                comandos.ApagarObjetivo(id_objetivo);
                AtualizarDataGrid();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_objetivo != 0)
            {
                formGerentePersonalidadeMetasAdicionar alterar = new formGerentePersonalidadeMetasAdicionar(id_objetivo);
                alterar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DestacarBordasDasLinhas(e);
            }
        }

        private void DestacarBordasDasLinhas(DataGridViewCellPaintingEventArgs e)
        {
            if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                using (Pen p = new Pen(Color.DarkGoldenrod, 1))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    e.Graphics.DrawLine(p, rect.Left, rect.Top - 1, rect.Right, rect.Top - 1);
                    e.Graphics.DrawLine(p, rect.Left, rect.Bottom + 1, rect.Right, rect.Bottom + 1);
                }
                e.Handled = true;
            }

            if (dataGridViewLista.SelectedCells.Count > 0)
            {
                if (e.RowIndex == dataGridViewLista.SelectedCells[0].RowIndex)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.DarkGoldenrod, 1))
                    {
                        Rectangle rect = e.CellBounds;
                        rect.Height -= 2;
                        e.Graphics.DrawLine(p, rect.Left, rect.Top - 1, rect.Right, rect.Top - 1);
                        e.Graphics.DrawLine(p, rect.Left, rect.Bottom + 1, rect.Right, rect.Bottom + 1);
                    }
                    e.Handled = true;
                }
            }

        }

        private void dataGridViewLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewLista.SelectedCells.Count > 0)
            {
                dataGridViewLista.Invalidate();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data_atual = dateTimePicker1.Value;
            AtualizarDataGrid();
        }

        private void labelRecompensas_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadeMetasRecompensas recompensas = new formGerentePersonalidadeMetasRecompensas();
            recompensas.ShowDialog();
        }
    }
}
