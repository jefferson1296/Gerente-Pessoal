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
    public partial class formGerentePersonalidadePlano : Form
    {
        List<Plano> planos = new List<Plano>();
        ComandosSQL comandos = new ComandosSQL();
        int id;

        bool arquivados;

        public formGerentePersonalidadePlano()
        {
            InitializeComponent();
        }

        private void formGestaoPlanosDeAcao_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            checkBoxArquivados.Text = "Exibir arquivados (" + comandos.QuantidadeDePlanosArquivados().ToString() + ")";
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            planos = comandos.ListaDePlanosDeAcao();

            dataGridViewLista.Rows.Clear();


            foreach (Plano plano in planos)
            {
                if (arquivados)
                {
                    dataGridViewLista.Rows.Add(plano.ID_Projeto, plano.Descricao, plano.Onde, plano.Conclusao);
                }
                else
                {
                    if (!plano.Arquivado)
                    {
                        dataGridViewLista.Rows.Add(plano.ID_Projeto, plano.Descricao, plano.Onde, plano.Conclusao);
                    }
                }
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
            formGerentePersonalidadePlanoAdicionar projeto = new formGerentePersonalidadePlanoAdicionar();
            projeto.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    formGerentePersonalidadePlanoAdicionar projeto = new formGerentePersonalidadePlanoAdicionar(id);
                    projeto.ShowDialog();
                    AtualizarDataGrid();
                }
            }
            catch
            {
                id = 0;
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                    if (planos.Where(x => x.ID_Projeto == id).Select(x => x.Arquivado).FirstOrDefault())
                    {
                        arquivarToolStripMenuItem.Text = "Desarquivar";
                    }
                    else
                    {
                        arquivarToolStripMenuItem.Text = "Arquivar";
                    }
                }
                catch
                {
                    id = 0;
                }
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O plano de ação será apagado permanentemente.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarPlanoDeAcao(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirPlanoDeAcao(id, true);
            }
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ImprimirPlanoDeAcao(id, false);
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

        private void checkBoxArquivados_CheckedChanged(object sender, EventArgs e)
        {
            arquivados = checkBoxArquivados.Checked;
            AtualizarDataGrid();
        }

        private void arquivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comandos.ArquivarOuDesarquivarPlano(id);
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                if (id != 0)
                {
                    comandos.AlterarConclusaoDoPlano(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewLista.Rows[e.RowIndex];
            Font fonte = new Font("Arial", 9, FontStyle.Strikeout, GraphicsUnit.Point);

            if (e.ColumnIndex == 1)
            {
                int id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                bool arquivado = planos.Where(x => x.ID_Projeto == id).Select(x => x.Arquivado).FirstOrDefault();
                bool conclusao = planos.Where(x => x.ID_Projeto == id).Select(x => x.Conclusao).FirstOrDefault();

                if (arquivado)
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    linha.DefaultCellStyle.ForeColor = Color.DarkGray;
                }

                if (conclusao)
                {
                    linha.DefaultCellStyle.Font = fonte;
                }
            }

        }
    }
}
