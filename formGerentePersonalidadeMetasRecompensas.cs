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
    public partial class formGerentePersonalidadeMetasRecompensas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Recompensa> recompensas = new List<Recompensa>();
        int id_recompensa;

        public formGerentePersonalidadeMetasRecompensas()
        {
            InitializeComponent();
        }

        private void formAtividadesProcessos_Load(object sender, EventArgs e)
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

            recompensas = comandos.TrazerRecompensas();
            dataGridViewLista.Rows.Clear();

            if (recompensas.Count > 0)
                labelMensagem.Visible = false;
            else
                labelMensagem.Visible = true;

            foreach (Recompensa recompensa in recompensas)
            {
                dataGridViewLista.Rows.Add(recompensa.ID_Recompensa, recompensa.Descricao);
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
                id_recompensa = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id_recompensa != 0)
                {
                    formGerentePersonalidadeMetasRecompensasObjetivos alterar = new formGerentePersonalidadeMetasRecompensasObjetivos(id_recompensa);
                    alterar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadeMetasRecompensasAdicionar adicionar = new formGerentePersonalidadeMetasRecompensasAdicionar();
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

                        id_recompensa = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id_recompensa = 0;
                    }
                }
                catch { }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_recompensa != 0)
            {
                comandos.ApagarRecompensa(id_recompensa);
                AtualizarDataGrid();
            }
        }

        private void editarRecompensaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_recompensa != 0)
            {
                formGerentePersonalidadeMetasRecompensasAdicionar adicionar = new formGerentePersonalidadeMetasRecompensasAdicionar(id_recompensa);
                adicionar.ShowDialog();
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

        private void dataGridViewLista_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                List<Objetivo> objetivos = recompensas.Where(x => x.ID_Recompensa == id).Select(x => x.Objetivos).FirstOrDefault();

                string texto;

                if (objetivos.Count == 0)
                {
                    texto = "Não há objetivos para receber essa recompensa.";
                }
                else
                {
                    if (objetivos.Count() == 1)
                    {
                        texto = "Conclua o objetivo";
                    }
                    else
                    {
                        texto = "Conclua os objetivos";
                    }

                    foreach (Objetivo objetivo in objetivos)
                    {
                        texto += "\r\n\"" + objetivo.Descricao + "\"";
                    }

                    texto += "\r\npara receber a recompensa.";
                }

                DataGridViewCell celula = dataGridViewLista[e.ColumnIndex, e.RowIndex];

                celula.ToolTipText = texto;
            }
        }
    }
}
