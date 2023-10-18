using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formGerenteFinanceiro : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        int id;

        int registros;
        bool mostrar_tudo;

        public formGerenteFinanceiro()
        {
            InitializeComponent();
        }


        private void formFinanceiroFluxo_Load(object sender, EventArgs e)
        {
            AplicarTema();

            registros = 100;
            textBoxRegistros.Text = registros.ToString();

            dataGridViewFluxo.AutoGenerateColumns = false;

            dataGridViewFluxo.Columns["ID_Movimentacao"].Visible = false;

            orcamentos = true;
            lancamentos = true;

            AtualizarDataGrid();
            timerFormatacao.Start();
        }

        private void AplicarTema()
        {
            panelSuperior.BackColor = Program.tema.Cor_Secundaria;
            //panelInferior.BackColor = Program.tema.Cor_Secundaria;

            //panelBotoes.BackColor = Program.tema.Cor_Secundaria;
            //buttonRelatorios.BackColor = Program.tema.Cor_Principal;
            //buttonSaldo.BackColor = Program.tema.Cor_Principal;
            //buttonFluxo.BackColor = Program.tema.Cor_Principal;
        }

        private void DataGridViewFluxo_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceFluxo.Sort = dataGridViewFluxo.SortString;

            FormatarDataGrid();
        }

        private void DataGridViewFluxo_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceFluxo.Filter = dataGridViewFluxo.FilterString;

            FormatarDataGrid();
        }

        private void buttonTranferencias_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaldo_Click(object sender, EventArgs e)
        {

        }

        private void buttonRelatorios_Click(object sender, EventArgs e)
        {
            //formFinanceiroRelatorios relatorios = new formFinanceiroRelatorios();
           // relatorios.ShowDialog();
        }

        private void DataGridViewFluxo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt32(dataGridViewFluxo.Rows[e.RowIndex].Cells[dataGridViewFluxo.Columns["ID_Movimentacao"].Index].Value);
                    string categoria = dataGridViewFluxo.Rows[e.RowIndex].Cells[dataGridViewFluxo.Columns["Categoria"].Index].Value.ToString();

                    if (categoria == "Transferência")
                    {
                        MessageBox.Show("Não é possível editar uma transferência.\r\nSe necessário, exclua as transações e registre novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        formGerenteFinanceiroAdicionar movimentacao = new formGerenteFinanceiroAdicionar(id);
                        movimentacao.ShowDialog();
                        AtualizarDataGrid();
                    }
                }
            }
            catch
            {
                id = 0;
            }
        }

        private void DataGridViewFluxo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewFluxo.CurrentCell = dataGridViewFluxo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewFluxo.Rows[e.RowIndex].Selected = true;
                        dataGridViewFluxo.Focus();

                        id = Convert.ToInt32(dataGridViewFluxo.Rows[e.RowIndex].Cells[0].Value);
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
            int registros = dataGridViewFluxo.SelectedRows.Count;

            if (registros > 0)
            {
                int i = 0;
                string texto = "Deseja apagar definitivamente ";

                foreach (DataGridViewRow linha in dataGridViewFluxo.SelectedRows)
                {
                    i++;
                    string movimentacao = dataGridViewFluxo.Rows[linha.Index].Cells[0].Value.ToString();

                    if (registros == 1)
                    {
                        texto = texto + "a movimentação " + movimentacao + "?";
                    }
                    else if (i == 1)
                    {
                        texto = texto + "as movimentações " + movimentacao + ", ";
                    }
                    else if (i > 1 && i != registros)
                    {
                        texto = texto + movimentacao + ", ";
                    }
                    else if (i > 1 && i == registros)
                    {
                        texto = texto + movimentacao + "?";
                    }
                }

                if (DialogResult.Yes == MessageBox.Show(texto, "Apagar", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (DataGridViewRow linha in dataGridViewFluxo.SelectedRows)
                    {
                        int id = Convert.ToInt32(dataGridViewFluxo.Rows[linha.Index].Cells[0].Value);
                        bool transferencia = Convert.ToBoolean(dataGridViewFluxo.Rows[linha.Index].Cells["Transferencia"].Value);

                        if (transferencia)
                        {
                            comandos.ApagarTransferencia(id);
                        }
                        else
                        {
                            comandos.ApagarMovimentacao(id);
                        }
                    }

                    string mensagem;
                    if (registros == 1) { mensagem = "Movimentação apagada com sucesso!"; }
                    else { mensagem = registros.ToString() + " movimentações apagadas com sucesso!"; }
                    MessageBox.Show(mensagem, "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AtualizarDataGrid();
                }
            }
        }



        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewFluxo.CurrentRow != null)
            {
                primeira_linha = dataGridViewFluxo.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewFluxo.CurrentRow.Index;
            }

            comandos.PreencherDataGridFluxo(dataGridViewFluxo, bindingSourceFluxo, registros, mostrar_tudo, orcamentos, lancamentos);

            try
            {
                dataGridViewFluxo.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewFluxo.CurrentCell = dataGridViewFluxo.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewFluxo.CurrentRow != null)
                dataGridViewFluxo.CurrentRow.Selected = false;

            FormatarDataGrid();
        }

        private void FormatarDataGrid()
        {
            Font minhafonte2 = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);


            foreach (DataGridViewRow e in dataGridViewFluxo.Rows)
            {
                //DataGridViewFluxo.Rows[e.Index].Cells[DataGridViewFluxo.Columns["Valor"].Index].Style.Font = minhafonte;
                //DataGridViewFluxo.Rows[e.Index].Cells[DataGridViewFluxo.Columns["Categoria"].Index].Style.Font = minhafonte;

                if (dataGridViewFluxo.Rows[e.Index].Cells["Categoria"].ColumnIndex == dataGridViewFluxo.Columns["Categoria"].Index)
                {
                    if (dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Categoria"].Index].Value.ToString() == "Transferências")
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.ForeColor = Color.Blue;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.SelectionForeColor = Color.Blue;
                    }
                    else if (comandos.ConverterDinheiroEmDecimal(dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Value.ToString()) < 0)
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.ForeColor = Color.DarkRed;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.SelectionForeColor = Color.DarkRed;
                    }
                    else if (comandos.ConverterDinheiroEmDecimal(dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Value.ToString()) > 0)
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.ForeColor = Color.Green;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.ForeColor = Color.Black;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Style.SelectionForeColor = Color.Black;
                    }

                    if (dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Categoria"].Index].Value.ToString() == "Transferências")
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.ForeColor = Color.CornflowerBlue;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.SelectionForeColor = Color.CornflowerBlue;
                    }
                    else if (comandos.ConverterDinheiroEmDecimal(dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Value.ToString()) < 0)
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.ForeColor = Color.IndianRed;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.SelectionForeColor = Color.IndianRed;
                    }
                    else if (comandos.ConverterDinheiroEmDecimal(dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Value.ToString()) > 0)
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.ForeColor = Color.DarkSeaGreen;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.SelectionForeColor = Color.DarkSeaGreen;
                    }
                    else
                    {
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.ForeColor = Color.Gray;
                        dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor_Previsto"].Index].Style.SelectionForeColor = Color.Gray;
                    }

                    dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Data_Prevista"].Index].Style.ForeColor = Color.Gray;
                    dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Data_Prevista"].Index].Style.SelectionForeColor = Color.Gray;
                }

                if (Convert.ToBoolean(dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Orcamento"].Index].Value) 
                    
                    && dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Valor"].Index].Value.ToString() == "")
                {
                    dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.Font = minhafonte2;

                    if (Convert.ToDateTime(dataGridViewFluxo.Rows[e.Index].Cells[dataGridViewFluxo.Columns["Data_Prevista"].Index].Value) >= DateTime.Now.Date)
                    {
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.BackColor = Color.AliceBlue;
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.SelectionBackColor = Color.AliceBlue;
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.SelectionForeColor = Color.RoyalBlue;
                    }
                    else
                    {
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.BackColor = Color.MistyRose;
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.SelectionBackColor = Color.MistyRose;
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.ForeColor = Color.DarkRed;
                        dataGridViewFluxo.Rows[e.Index].DefaultCellStyle.SelectionForeColor = Color.DarkRed;

                    }


                }
            }
        }


        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar" && textBoxPesquisa.Text != string.Empty)
            {
                bindingSourceFluxo.Filter = "Descricao like '%" + textBoxPesquisa.Text + "%'";
            }

            FormatarDataGrid();
        }

        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }

        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;

            if (dataGridViewFluxo.CurrentRow != null)
                dataGridViewFluxo.CurrentRow.Selected = false;
        }

        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bindingSourceFluxo.Filter = "Descricao like '%" + textBoxPesquisa.Text + "%'";
            }
        }

        private void somatorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow linha in dataGridViewFluxo.SelectedRows)
            {
                total += comandos.ConverterDinheiroEmDecimal(dataGridViewFluxo.Rows[linha.Index].Cells["Valor"].Value.ToString());
            }

            MessageBox.Show("Total: " + total.ToString("C"));
        }

        private void buttonExibir_Click(object sender, EventArgs e)
        {
            mostrar_tudo = false;
            registros = Convert.ToInt32(textBoxRegistros.Text);
            AtualizarDataGrid();
        }

        private void buttonTodos_Click(object sender, EventArgs e)
        {
            mostrar_tudo = true;
            AtualizarDataGrid();
        }

        private void textBoxRegistros_Enter(object sender, EventArgs e)
        {
            if (textBoxRegistros.Text == "0")
            {
                textBoxRegistros.Text = string.Empty;
            }
        }

        private void textBoxRegistros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxRegistros_Leave(object sender, EventArgs e)
        {
            if (textBoxRegistros.Text == string.Empty)
            {
                textBoxRegistros.Text = registros.ToString();
            }
        }

        private void timerFormatacao_Tick(object sender, EventArgs e)
        {
            orcamentos = comandos.ObterValorDoParametroBooleano("Visualizar Orçamentos");
            lancamentos = comandos.ObterValorDoParametroBooleano("Visualizar Lançamentos");

            if (orcamentos && lancamentos) { comboBoxVisualizar.Text = "Visualizar Lançamentos e Orçamentos"; }
            else if (!orcamentos && lancamentos) { comboBoxVisualizar.Text = "Visualizar apenas Lançamentos"; }
            else if (orcamentos && !lancamentos) { comboBoxVisualizar.Text = "Visualizar apenas Orçamentos"; }

            FormatarDataGrid();
            timerFormatacao.Stop();
        }

        bool orcamentos;
        bool lancamentos;


        private void comboBoxVisualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVisualizar.Text == "Visualizar apenas Lançamentos")
            {
                orcamentos = false;
                lancamentos = true;
            }
            else if (comboBoxVisualizar.Text == "Visualizar apenas Orçamentos")
            {
                orcamentos = true;
                lancamentos = false;
            }
            else if (comboBoxVisualizar.Text == "Visualizar Lançamentos e Orçamentos")
            {
                orcamentos = true;
                lancamentos = true;
            }

            
            Parametro parametro = new Parametro { Descricao = "Visualizar Orçamentos", Edicao = true, Tipo = "Booleano" };
            if (orcamentos) { parametro.Valor = "true"; } else { parametro.Valor = "false"; }

            Parametro parametro2 = new Parametro { Descricao = "Visualizar Lançamentos", Edicao = true, Tipo = "Booleano" };
            if (lancamentos) { parametro2.Valor = "true"; } else { parametro2.Valor = "false"; }

            List<Parametro> parametros = new List<Parametro>();
            parametros.Add(parametro);
            parametros.Add(parametro2);

            comandos.EditarParametros(parametros);

            AtualizarDataGrid();
        }

        private void dataGridViewFluxo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DestacarBordasDasLinhas(e);
                //DestacarBordasDasCelulasJuntas(e);
                //DestacarBordasDasCelulasSeparadas(e);
            }
        }

        private void DestacarBordasDasLinhas(DataGridViewCellPaintingEventArgs e)
        {
            if (dataGridViewFluxo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                using (Pen p = new Pen(Color.DarkGoldenrod, 1))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    e.Graphics.DrawLine(p, rect.Left, rect.Top - 1, rect.Right, rect.Top -1);
                    e.Graphics.DrawLine(p, rect.Left, rect.Bottom + 1, rect.Right, rect.Bottom + 1);
                }
                e.Handled = true;
            }

            if (dataGridViewFluxo.SelectedCells.Count > 0)
            {
                if (e.RowIndex == dataGridViewFluxo.SelectedCells[0].RowIndex)
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

        private void DestacarBordasDasCelulasSeparadas(DataGridViewCellPaintingEventArgs e)
        {

            if (dataGridViewFluxo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                using (Pen p = new Pen(Color.Red, 1))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    e.Graphics.DrawRectangle(p, rect);
                }
                e.Handled = true;
            }

        }

        private void DestacarBordasDasCelulasJuntas(DataGridViewCellPaintingEventArgs e)
        {

            if (dataGridViewFluxo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                using (Pen p = new Pen(Color.Blue, 1))
                {
                    System.Drawing.Rectangle rect = e.CellBounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    e.Graphics.DrawRectangle(p, rect);
                }
                e.Handled = true;
            }

            if (dataGridViewFluxo.SelectedCells.Count > 0)
            {
                if (e.RowIndex == dataGridViewFluxo.SelectedCells[0].RowIndex)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Blue, 1))
                    {
                        System.Drawing.Rectangle rect = e.CellBounds;
                        rect.Height -= 2;
                        e.Graphics.DrawRectangle(p, rect);
                    }
                    e.Handled = true;
                }
            }

        }


        private void dataGridViewFluxo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFluxo.SelectedCells.Count > 0)
            {
                dataGridViewFluxo.Invalidate();
            }
        }

        private void entradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroAdicionar movimentacao = new formGerenteFinanceiroAdicionar(true);
            movimentacao.ShowDialog();
            AtualizarDataGrid();
        }

        private void saidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroAdicionar movimentacao = new formGerenteFinanceiroAdicionar(false);
            movimentacao.ShowDialog();
            AtualizarDataGrid();
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroLancamentosTransferencias transferencias = new formGerenteFinanceiroLancamentosTransferencias();
            transferencias.ShowDialog();
            AtualizarDataGrid();
        }

        private void despesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroDespesas despesas = new formGerenteFinanceiroDespesas();
            despesas.ShowDialog();
            AtualizarDataGrid();
        }

        private void contasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroLancamentosContas contas = new formGerenteFinanceiroLancamentosContas();
            contas.ShowDialog();
        }

        private void fluxoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroFluxo fluxo = new formGerenteFinanceiroFluxo();
            fluxo.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroFluxoCategorias categorias = new formGerenteFinanceiroFluxoCategorias();
            categorias.ShowDialog();
        }

        private void saldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroSaldo saldo = new formGerenteFinanceiroSaldo();
            saldo.ShowDialog();
        }

        private void somatórioPrevistoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            foreach (DataGridViewRow linha in dataGridViewFluxo.SelectedRows)
            {
                total += comandos.ConverterDinheiroEmDecimal(dataGridViewFluxo.Rows[linha.Index].Cells["Valor_Previsto"].Value.ToString());
            }

            MessageBox.Show("Total: " + total.ToString("C"));
        }

        private void hojeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in dataGridViewFluxo.SelectedRows)
            {
                id = Convert.ToInt32(dataGridViewFluxo.Rows[linha.Index].Cells[0].Value);
                comandos.MarcarComoPago(id, true);
            }

            AtualizarDataGrid();
        }

        private void naDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in dataGridViewFluxo.SelectedRows)
            {
                id = Convert.ToInt32(dataGridViewFluxo.Rows[linha.Index].Cells[0].Value);
                comandos.MarcarComoPago(id, false);
            }

            AtualizarDataGrid();
        }

        //GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        //{
        //    float m = 2.75F;
        //    float r2 = radius / 2f;
        //    GraphicsPath GraphPath = new GraphicsPath();

        //    GraphPath.AddArc(Rect.X + m, Rect.Y + m, radius, radius, 180, 90);
        //    GraphPath.AddLine(Rect.X + r2 + m, Rect.Y + m, Rect.Width - r2 - m, Rect.Y + m);
        //    GraphPath.AddArc(Rect.X + Rect.Width - radius - m, Rect.Y + m, radius, radius, 270, 90);
        //    GraphPath.AddLine(Rect.Width - m, Rect.Y + r2, Rect.Width - m, Rect.Height - r2 - m);
        //    GraphPath.AddArc(Rect.X + Rect.Width - radius - m,
        //                   Rect.Y + Rect.Height - radius - m, radius, radius, 0, 90);
        //    GraphPath.AddLine(Rect.Width - r2 - m, Rect.Height - m, Rect.X + r2 - m, Rect.Height - m);
        //    GraphPath.AddArc(Rect.X + m, Rect.Y + Rect.Height - radius - m, radius, radius, 90, 90);
        //    GraphPath.AddLine(Rect.X + m, Rect.Height - r2 - m, Rect.X + m, Rect.Y + r2 + m);

        //    GraphPath.CloseFigure();
        //    return GraphPath;
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    int borderRadius = 25;
        //    float borderThickness = 1.75f;
        //    base.OnPaint(e);
        //    RectangleF Rect = new RectangleF(0, 0, buttonEntrada.Width, buttonEntrada.Height);
        //    RectangleF Rect1 = new RectangleF(0, 0, buttonSaida.Width, buttonSaida.Height);
        //    RectangleF Rect2 = new RectangleF(0, 0, buttonTranferencias.Width, buttonTranferencias.Height);
        //    GraphicsPath GraphPath = GetRoundPath(Rect, borderRadius);
        //    GraphicsPath GraphPath1 = GetRoundPath(Rect1, borderRadius);
        //    GraphicsPath GraphPath2 = GetRoundPath(Rect2, borderRadius);

        //    buttonEntrada.Region = new Region(GraphPath);
        //    buttonSaida.Region = new Region(GraphPath1);
        //    buttonTranferencias.Region = new Region(GraphPath2);

        //    using (Pen pen = new Pen(Color.Silver, borderThickness))
        //    {
        //        pen.Alignment = PenAlignment.Inset;
        //        e.Graphics.DrawPath(pen, GraphPath);
        //        e.Graphics.DrawPath(pen, GraphPath1);
        //        e.Graphics.DrawPath(pen, GraphPath2);
        //    }
        //}
    }
}
