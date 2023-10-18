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
    public partial class formGerenteFinanceiroAdicionarItens : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGerenteFinanceiroAdicionar pai = new formGerenteFinanceiroAdicionar();

        int ordem;

        bool reverso;

        public formGerenteFinanceiroAdicionarItens(formGerenteFinanceiroAdicionar Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formGerenteFinanceiroAdicionarItens_Load(object sender, EventArgs e)
        {
            if (pai.entrada) { checkBoxReverso.Text = "Custo"; }
            else { checkBoxReverso.Text = "Desconto"; }
            ValorForeColor();

            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                if (coluna.Index != 2)
                {
                    coluna.ReadOnly = true;
                }
            }

            AtualizarDataGrid();
        }

        private void ValorForeColor()
        {
            if (reverso)
            {
                if (pai.entrada) { textBoxValor.ForeColor = Color.DarkRed; }
                else { textBoxValor.ForeColor = Color.LimeGreen; }
            }
            else
            {
                if (!pai.entrada) { textBoxValor.ForeColor = Color.DarkRed; }
                else { textBoxValor.ForeColor = Color.LimeGreen; }
            }
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

            foreach (Item item in pai.Itens)
            {
                decimal total = item.Valor * item.Quantidade;
                dataGridViewLista.Rows.Add(item.ID_Item, item.Descricao, item.Valor, total, item.Previsto);
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

        #region Formatação de texto

        private void textBoxValor_Enter(object sender, EventArgs e)
        {
            if (textBoxValor.Text == "R$0,00" || textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = string.Empty;
            }
            else
            {
                textBoxValor.Text = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text).ToString("F");
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxValor.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text != string.Empty)
            {
                decimal valor = Convert.ToDecimal(textBoxValor.Text);
                textBoxValor.Text = valor.ToString("C");
            }
            else
            {
                textBoxValor.Text = "R$0,00";
            }
        }

        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "1")
                textBoxQuantidade.Text = string.Empty;
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxQuantidade_Leave(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == string.Empty || textBoxQuantidade.Text == "0")
                textBoxQuantidade.Text = "1";
        }

        #endregion

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            decimal valor = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text);

            if (reverso)
            {
                valor = -valor;
            }

            int quantidade = Convert.ToInt32(textBoxQuantidade.Text);
            bool previsto = checkBoxPrevisto.Checked;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe o item para continuar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (pai.cadastramento)
                {
                    int ordem = pai.Itens.Count + 1;
                    pai.Itens.Add(new Item { Descricao = descricao, Valor = valor, Quantidade = quantidade, Previsto = previsto, ID_Item = ordem });
                }
                else
                {
                    Item item = new Item { Descricao = descricao, Valor = valor, Quantidade = quantidade, Previsto = previsto, ID_Movimentacao = pai.id_movimentacao };
                    comandos.CadastrarItem(item);
                    pai.Itens = comandos.TrazerListaDeItens(pai.id_movimentacao);
                }

                textBoxDescricao.Clear();
                textBoxValor.Text = "R$0,00";
                textBoxQuantidade.Text = "1";
                checkBoxReverso.Checked = false;

                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                }
                catch
                {
                    ordem = 0;
                }
            }
            else
            {
                ordem = 0;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                if (pai.cadastramento)
                {
                    pai.Itens.RemoveAll(x => x.ID_Item == ordem);
                    ReordenarItens();
                }
                else
                {
                    comandos.ApagarItem(ordem);
                    pai.Itens = comandos.TrazerListaDeItens(pai.id_movimentacao); 
                }
            }

            AtualizarDataGrid();
        }

        public void ReordenarItens()
        {
            int ordem = 1;

            foreach(Item item in pai.Itens)
            {
                item.ID_Item = ordem;
                ordem++;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkBoxReverso_CheckedChanged(object sender, EventArgs e)
        {
            reverso = checkBoxReverso.Checked;
            ValorForeColor();
        }
    }
}
