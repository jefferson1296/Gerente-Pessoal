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
    public partial class formGerentePersonalidadeMetasRecompensasObjetivos : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        int id_objetivo;

        bool cadastramento;

        Recompensa recompensa = new Recompensa();

        public formGerentePersonalidadeMetasRecompensasObjetivos(string Descricao)
        {
            InitializeComponent();
            recompensa.Descricao = Descricao;
            cadastramento = true;
        }

        public formGerentePersonalidadeMetasRecompensasObjetivos(int ID_Recompensa)
        {
            InitializeComponent();
            recompensa.ID_Recompensa = ID_Recompensa;
            cadastramento = false;
        }

        private void formAtividadesProcessosAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                recompensa = comandos.TrazerRecompensa(recompensa.ID_Recompensa);
            }
            else
            {
                recompensa = comandos.TrazerRecompensa();
            }

            labelRecompensa.Text = recompensa.Descricao;

            comboBoxObjetivos.DropDownHeight = 150;
            AtualizarComboObjetivos();

            AtualizarDataGrid();
        }

        private void AtualizarComboObjetivos()
        {
            List<Objetivo> objetivos = comandos.PreencherComboObjetivos();
            AutoCompleteStringCollection colecao = new AutoCompleteStringCollection();

            foreach (Objetivo objetivo in recompensa.Objetivos)
            {
                if (objetivos.Any(x => x.ID_Objetivo == objetivo.ID_Objetivo))
                {
                    objetivos.RemoveAll(x =>x.ID_Objetivo == objetivo.ID_Objetivo);
                }
            }

            comboBoxObjetivos.DataSource = objetivos;
            comboBoxObjetivos.DisplayMember = "Descricao";
            comboBoxObjetivos.ValueMember = "ID_Objetivo";

            foreach (Objetivo objetivo in objetivos)
            {
                colecao.Add(objetivo.Descricao);
            }

            comboBoxObjetivos.AutoCompleteCustomSource = colecao;
            comboBoxObjetivos.SelectedIndex = -1;
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            if (recompensa.Objetivos.Count == 0) { labelRegistros.Visible = true; }
            else { labelRegistros.Visible = false; }

            foreach (Objetivo objetivo in recompensa.Objetivos)
            {
                dataGridViewLista.Rows.Add(objetivo.ID_Objetivo, objetivo.Descricao);
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string objetivo = comboBoxObjetivos.Text;

            if (objetivo == string.Empty || !comandos.VerificarNomeDoObjetivo(objetivo))
            {
                MessageBox.Show("Informe um objetivo cadastrado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id_objetivo = (int)comboBoxObjetivos.SelectedValue;

                comandos.AdicionarObjetivoARecompensa(id_objetivo, recompensa.ID_Recompensa);
                recompensa.Objetivos = comandos.TrazerObjetivosDaRecompensa(recompensa.ID_Recompensa);

                AtualizarComboObjetivos();
                AtualizarDataGrid();

                comboBoxObjetivos.Text = string.Empty;
                comboBoxObjetivos.Focus();
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
                comandos.ApagarObjetivoDaRecompensa(id_objetivo, recompensa.ID_Recompensa);
                recompensa.Objetivos = comandos.TrazerObjetivosDaRecompensa(recompensa.ID_Recompensa);
                AtualizarComboObjetivos();
                AtualizarDataGrid();
            }
        }



        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
        }
    }
}
