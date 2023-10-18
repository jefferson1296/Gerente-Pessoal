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
    public partial class formGerentePersonalidadeMetasResultados : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Resultado> resultados = new List<Resultado>();

        string objetivo;
        int id_objetivo;
        int id_resultado;

        DateTime data_atual;

        public formGerentePersonalidadeMetasResultados()
        {
            InitializeComponent();
        }

        public formGerentePersonalidadeMetasResultados(int ID_Objetivo, string Objetivo)
        {
            InitializeComponent();
            id_objetivo = ID_Objetivo;
            objetivo = Objetivo;
        }

        private void formAtividadesProcessos_Load(object sender, EventArgs e)
        {
            data_atual = DateTime.Now;

            DataGridViewProgressColumn column = new DataGridViewProgressColumn();

            dataGridViewLista.Columns.Add(column);
            dataGridViewLista.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            column.HeaderText = "Progresso";

            AtualizarDataGrid();

            labelObjetivo.Text = "\"" + objetivo + "\"";
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            resultados = comandos.TrazerResultados(id_objetivo, data_atual);
            dataGridViewLista.Rows.Clear();

            if (resultados.Count == 0) { labelMensagem.Visible = true; }
            else { labelMensagem.Visible = false; }

            foreach (Resultado resultado in resultados)
            {
                dataGridViewLista.Rows.Add(resultado.ID_Resultado, resultado.Descricao, Convert.ToInt32(resultado.Progresso));
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
                id_resultado = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string resultado = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();

                formGerentePersonalidadeMetasResultadosAcompanhamento acompanhamento = new formGerentePersonalidadeMetasResultadosAcompanhamento(id_resultado, resultado);
                acompanhamento.ShowDialog();
            }
            catch { }

        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadeMetasResultadosAdicionar adicionar = new formGerentePersonalidadeMetasResultadosAdicionar(id_objetivo, true, objetivo);
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

                        id_resultado = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_resultado = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_resultado != 0)
            {
                comandos.ApagarResultado(id_resultado);
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

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_resultado != 0)
            {
                formGerentePersonalidadeMetasResultadosAdicionar alterar = new formGerentePersonalidadeMetasResultadosAdicionar(id_resultado, false, objetivo);
                alterar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data_atual = dateTimePicker1.Value;
            AtualizarDataGrid();
        }

        private void iniciativasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_resultado != 0)
            {
                formGerentePersonalidadeMetasResultadosIniciativas iniciativas = new formGerentePersonalidadeMetasResultadosIniciativas(id_resultado);
                iniciativas.ShowDialog();
                AtualizarDataGrid();
            }
        }
    }
}
