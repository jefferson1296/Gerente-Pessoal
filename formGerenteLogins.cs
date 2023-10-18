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
    public partial class formGerenteLogins : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Login> Logins = new List<Login>();

        int id;

        public formGerenteLogins()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentosReparticoes_Load(object sender, EventArgs e)
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

            Logins = comandos.ListaDeLogins();            

            dataGridViewLista.Rows.Clear();

            foreach (Login login in Logins)
            {
                dataGridViewLista.Rows.Add(login.ID_Login, login.Descricao);
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
            formGerenteLoginsAdicionar adicionar = new formGerenteLoginsAdicionar();

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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                if (id != 0)
                {
                    formGerenteLoginsAdicionar editar = new formGerenteLoginsAdicionar(id);
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
                if (DialogResult.Yes == MessageBox.Show("Essa ação não poderá ser desfeita.\r\nTem certeza que deseja apagar o login?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarLogin(id);
                    AtualizarDataGrid();
                }
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
    }
}
