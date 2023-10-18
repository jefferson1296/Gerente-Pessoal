using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GerenciamentoPessoal
{
    public partial class formGerenteFinanceiroAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        public bool cadastramento;
        public bool entrada;
        public int id_movimentacao;
        Movimentacao Movimentacao = new Movimentacao();
        private List<Categoria_Financeira> categorias = new List<Categoria_Financeira>();

        public bool alteracao = false;

        bool fechar;
        bool limpar;

        bool previsao;
        bool pagamento;

        public List<Item> Itens = new List<Item>();

        public formGerenteFinanceiroAdicionar()
        {
            InitializeComponent();
        }

        public formGerenteFinanceiroAdicionar(bool Entrada)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            cadastramento = true;
            entrada = Entrada;
        }

        public formGerenteFinanceiroAdicionar(int ID_Movimentacao)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_movimentacao = ID_Movimentacao;
            cadastramento = false;
        }

        private void formFinanceiroFluxoRegistrar_Load(object sender, EventArgs e)
        {
            comboBoxConta.DataSource = comandos.PreencherComboContas();
            comboBoxConta.DisplayMember = "Descricao";
            comboBoxConta.ValueMember = "ID_Conta";
            comboBoxConta.DropDownHeight = 120;
            comboBoxConta.SelectedIndex = -1;

            if (!cadastramento)
            {
                Movimentacao = comandos.TrazerInformacoesDaMovimentacao(id_movimentacao);

                if (Movimentacao.Valor_Previsto > 0) 
                { 
                    radioButtonEntrada.Checked = true;
                }
                else 
                { 
                    radioButtonEntrada.Checked = false;
                    Movimentacao.Valor_Previsto = -Movimentacao.Valor_Previsto;

                    if (Movimentacao.Valor < 0)
                    {
                        Movimentacao.Valor = -Movimentacao.Valor;
                    }
                }

                entrada = radioButtonEntrada.Checked;

                comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(entrada);
                comboBoxFin.DisplayMember = "Categoria";
                comboBoxFin.ValueMember = "ID";

                textBoxDescricao.Text = Movimentacao.Descricao;
                comboBoxConta.SelectedValue = Movimentacao.ID_Conta;
                comboBoxFin.SelectedValue = Movimentacao.ID_Categoria;                

                if (Movimentacao.Itens)
                {
                    Itens = comandos.TrazerListaDeItens(id_movimentacao);
                    checkBoxItens.Checked = true;
                }

                dateTimePickerData.Value = Movimentacao.Data_Movimentacao;

                textBoxValor.Text = Movimentacao.Valor.ToString("C");
                textBoxPrevisto.Text = Movimentacao.Valor_Previsto.ToString("C");
                checkBoxOrcamento.Checked = Movimentacao.Orcamento;
                dateTimePickerRealizada.Value = Movimentacao.Data.Date;
                dateTimePickerRealizada.Format = DateTimePickerFormat.Short;
                pagamento = true;

                dateTimePickerPrevista.Value = Movimentacao.Data_Prevista.Date;

                if (dateTimePickerRealizada.Value.Date == Convert.ToDateTime("01/01/1901"))
                {
                    textBoxValor.Text = string.Empty;
                    dateTimePickerRealizada.Value = DateTime.Now.Date;
                    pagamento = false;
                    dateTimePickerRealizada.Format = DateTimePickerFormat.Custom;
                }

                checkBoxPagamento.Checked = pagamento;

                checkBoxFechar.Visible = false;
                checkBoxLimpar.Visible = false;
            }
            else
            {
                radioButtonEntrada.Checked = entrada;
                comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(entrada);
                comboBoxFin.DisplayMember = "Categoria";
                comboBoxFin.ValueMember = "ID";
                comboBoxFin.SelectedIndex = -1;
            }

            VerificarMovimentacao();

            comboBoxFin.DropDownHeight = 120;
            comboBoxFin.PropertySelector = collection => collection.Cast<Categoria_Financeira>().Select(p => p.Categoria);

            textBoxDescricao.SelectionStart = textBoxDescricao.Text.Length;

            categorias = comandos.PlanoDeContasPorTipo(entrada);
            PreencherArvore();

            SetTreeViewTheme(treeViewCategoria.Handle);

            fechar = true;
        }

        private void AtualizarCategorias()
        {
            comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(entrada);
            comboBoxFin.PropertySelector = collection => collection.Cast<Categoria_Financeira>().Select(p => p.Categoria);
            categorias = comandos.PlanoDeContasPorTipo(entrada);
            PreencherArvore();
        }

        private void VerificarMovimentacao()
        {
            if (entrada)
            {
                labelTitulo.Text = "Registrar entrada";
                labelTitulo.ForeColor = Color.Green;
                pictureBox2.Visible = true;
                pictureBoxSaida.Visible = false;
                panel5.BackColor = Color.PaleGreen;
                radioButtonEntrada.ForeColor = Color.Black;
                radioButtonSaida.ForeColor = Color.Black;
                buttonSalvar.ForeColor = Color.Green;
                buttonCancelar.ForeColor = Color.Green;
                panelPrevisto.BackColor = Color.Green;
                panelPago.BackColor = Color.Green;
            }
            else
            {
                labelTitulo.Text = "Registrar saída";
                labelTitulo.ForeColor = Color.DarkRed;
                pictureBox2.Visible = false;
                pictureBoxSaida.Visible = true;
                panel5.BackColor = Color.FromArgb(192, 0, 0);
                radioButtonEntrada.ForeColor = Color.White;
                radioButtonSaida.ForeColor = Color.White;
                buttonSalvar.ForeColor = Color.Red;
                buttonCancelar.ForeColor = Color.Red;
                panelPrevisto.BackColor = Color.Red;
                panelPago.BackColor = Color.Red;
            }
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

                if (textBoxValor.Text == "R$0,00")
                {
                    textBoxValor.Text = string.Empty;
                }
                else
                {
                    if (!previsao || textBoxPrevisto.Text == string.Empty || textBoxPrevisto.Text == "R$0,00")
                    {
                        textBoxPrevisto.Text = valor.ToString("C");
                    }
                }
            }
        }

        private void textBoxPrevisto_Enter(object sender, EventArgs e)
        {
            if (textBoxPrevisto.Text == "R$0,00" || textBoxPrevisto.Text == string.Empty)
            {
                textBoxPrevisto.Text = string.Empty;
            }
            else
            {
                textBoxPrevisto.Text = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text).ToString("F");
            }
        }

        private void textBoxPrevisto_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxPrevisto.Text.Contains(','))
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

        private void textBoxPrevisto_Leave(object sender, EventArgs e)
        {
            if (textBoxPrevisto.Text != string.Empty)
            {
                decimal valor = Convert.ToDecimal(textBoxPrevisto.Text);
                textBoxPrevisto.Text = valor.ToString("C");

                if (textBoxPrevisto.Text == "R$0,00")
                    textBoxPrevisto.Text = string.Empty;
            }
        }

        #endregion



        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string categoria = comboBoxFin.Text;
            decimal valor = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text);
            decimal previsto = comandos.ConverterDinheiroEmDecimal(textBoxPrevisto.Text);
            string conta = comboBoxConta.Text;
            bool orcamento = checkBoxOrcamento.Checked;
            DateTime data = dateTimePickerRealizada.Value.Date;
            DateTime data_prevista = dateTimePickerPrevista.Value.Date;
            DateTime data_movimentacao = dateTimePickerData.Value.Date;

            bool permitir = true;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                permitir = false;
            }
            else if (!previsao)
            {
                MessageBox.Show("Informe a data e o valor previsto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                permitir = false;
            }
            else if (previsto == 0)
            {
                MessageBox.Show("Informe o valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                permitir = false;
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                permitir = false;
            }
            else if (conta == string.Empty)
            {
                MessageBox.Show("Informe a conta para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                permitir = false;
            }
            //else if (orcamento && data_prevista < DateTime.Now.AddDays(1))
            //{
            //    MessageBox.Show("Apenas previsões (datas do futuro) podem ser incluídas no orçamento.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    permitir = false;
            //}
            else
            {
                if (!orcamento && !pagamento && previsao)
                {
                    if (DialogResult.Yes == MessageBox.Show("Você está incluindo uma previsão de gastos.\r\nPara concluir esta ação, é necessário incluir\r\na transação no orçamento.\r\n\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        orcamento = true;
                        checkBoxOrcamento.Checked = true;
                    }
                    else
                    {
                        permitir = false;
                    }
                }

            }

            if (permitir)
            {
                Movimentacao.Descricao = descricao;
                Movimentacao.Data = data;
                Movimentacao.Data_Prevista = data_prevista;
                Movimentacao.Valor_Previsto = previsto;
                Movimentacao.Valor = valor;
                Movimentacao.ID_Categoria = (int)comboBoxFin.SelectedValue;
                Movimentacao.ID_Conta = (int)comboBoxConta.SelectedValue;
                Movimentacao.Orcamento = orcamento;
                Movimentacao.Itens = checkBoxItens.Checked;
                Movimentacao.Data_Movimentacao = data_movimentacao;

                if (cadastramento)
                {
                    comandos.RegistrarMovimentacao(Movimentacao, entrada, previsao, pagamento);
                    if (Movimentacao.Itens) { comandos.CadastrarItens(Itens); }

                    MessageBox.Show("Movimentação registrada com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (fechar)
                    {
                        Dispose();
                    }
                    else
                    {
                        if (limpar)
                        {
                            textBoxDescricao.Clear();
                            comboBoxConta.SelectedIndex = -1;
                            comboBoxFin.SelectedIndex = -1;
                            comboBoxFin.SelectedIndex = -1;

                            textBoxValor.Clear();
                            textBoxPrevisto.Clear();
                            dateTimePickerRealizada.Value = DateTime.Now.Date;
                            dateTimePickerPrevista.Value = DateTime.Now.Date;
                            pagamento = false;
                            previsao = false;
                            dateTimePickerRealizada.Format = DateTimePickerFormat.Custom;
                            dateTimePickerPrevista.Format = DateTimePickerFormat.Custom;
                        }
                    }
                }
                else
                {
                    comandos.EditarMovimentacao(Movimentacao, entrada, previsao, pagamento);
                    Dispose();
                }
            }
        }

        private void radioButtonEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEntrada.Checked) { entrada = true; }
            else { entrada = false; }

            comboBoxFin.DataSource = null;

            VerificarMovimentacao();

            comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(entrada);
            comboBoxFin.DisplayMember = "Categoria";
            comboBoxFin.ValueMember = "ID";
            comboBoxFin.DropDownHeight = 120;
            comboBoxFin.SelectedIndex = -1;

            categorias = comandos.PlanoDeContasPorTipo(entrada);
            PreencherArvore();
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void labelCalculadora_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void pictureBoxCalculadora_Click(object sender, EventArgs e)
        {
            Process.Start("calc");
        }

        private void dateTimePickerPrevista_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerPrevista.Format = DateTimePickerFormat.Short;
            previsao = true;
        }

        private void dateTimePickerRealizada_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxCategorias_Click(object sender, EventArgs e)
        {
            if (panelCategorias.Visible is true) { panelCategorias.Visible = false; }
            else { panelCategorias.Visible = true; }
        }

        private void treeViewCategoria_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                comboBoxFin.Text = e.Node.Text;
                panelCategorias.Visible = false;
            }
        }

        //private void treeViewCategoria_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (e.Node.Nodes.Count == 0)
        //    {
        //        comboBoxFin.Text = e.Node.Text;
        //        panelCategorias.Visible = false;
        //    }
        //}

        private void PreencherArvore()
        {
            treeViewCategoria.Nodes.Clear();

            foreach (Categoria_Financeira categoria in categorias)
            {
                TreeNode nó = new TreeNode(categoria.Categoria);

                if (categoria.ID_Parente == 0)
                {
                    treeViewCategoria.Nodes.Add(nó);
                }
                else
                {
                    string nome_pai = categorias.Where(x => x.ID == categoria.ID_Parente).Select(x => x.Categoria).FirstOrDefault();

                    foreach (TreeNode nó_pai in treeViewCategoria.Nodes)
                    {
                        if (nó_pai.Text == nome_pai)
                        {
                            nó_pai.Nodes.Add(nó);
                        }

                        foreach (TreeNode nó_filho in nó_pai.Nodes)
                        {
                            if (nó_filho.Text == nome_pai)
                            {
                                nó_filho.Nodes.Add(nó);
                            }
                        }
                    }
                }
            }
        }

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetTreeViewTheme(IntPtr treeHandle)
        {
            SetWindowTheme(treeHandle, "explorer", null);
        }



        private void formFinanceiroLancamentosAdicionar_MouseClick(object sender, MouseEventArgs e)
        {
            panelCategorias.Visible = false;
        }

        private void panelCategorias_VisibleChanged(object sender, EventArgs e)
        {
            treeViewCategoria.SelectedNode = null;
        }

        private void checkBoxFechar_CheckedChanged(object sender, EventArgs e)
        {
            fechar = checkBoxFechar.Checked;

            if (fechar)
            {
                checkBoxLimpar.Checked = false;
                checkBoxLimpar.Visible = false;
            }
            else
            {
                checkBoxLimpar.Visible = true;
            }
        }

        private void checkBoxLimpar_CheckedChanged(object sender, EventArgs e)
        {
            limpar = checkBoxLimpar.Checked;
        }

        private void comboBoxFin_MouseClick(object sender, MouseEventArgs e)
        {
            panelCategorias.Visible = false;
        }

        private void dateTimePickerRealizada_DropDown(object sender, EventArgs e)
        {
            dateTimePickerRealizada.Format = DateTimePickerFormat.Short;

            pagamento = true;
            checkBoxPagamento.Checked = pagamento;

            if (!previsao)
            {
                previsao = true;
                dateTimePickerPrevista.Format = DateTimePickerFormat.Short;
                dateTimePickerPrevista.Value = dateTimePickerRealizada.Value;
            }
        }

        private void labelCategoria_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroFluxoCategorias categorias = new formGerenteFinanceiroFluxoCategorias();
            categorias.ShowDialog();

            AtualizarCategorias();
        }

        private void checkBoxPagamento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPagamento.Checked)
            {
                checkBoxPagamento.Enabled = true;
            }
            else
            {
                textBoxValor.Text = string.Empty;
                dateTimePickerRealizada.Value = DateTime.Now.Date;
                pagamento = false;
                dateTimePickerRealizada.Format = DateTimePickerFormat.Custom;
                checkBoxPagamento.Enabled = false;
            }
        }

        private void checkBoxItens_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxItens.Checked)
            {
                textBoxValor.Enabled = false;
                textBoxPrevisto.Enabled = false;
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("A lista de itens será apagada.", "Apagar lista", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    textBoxValor.Enabled = true;
                    textBoxPrevisto.Enabled = true;
                }
                else
                {
                    checkBoxItens.Checked = true;
                }
            }
        }

        private void AtualizarValor()
        {
            Movimentacao.Valor = Itens.Sum(x => x.Valor * x.Quantidade);
            Movimentacao.Valor_Previsto = Itens.Where(x => x.Previsto).Sum(x => x.Valor * x.Quantidade);

            textBoxValor.Text = Movimentacao.Valor.ToString("C");
            textBoxPrevisto.Text = Movimentacao.Valor_Previsto.ToString("C");
        }

        private void labelItens_Click(object sender, EventArgs e)
        {
            if (!checkBoxItens.Checked)
            {
                checkBoxItens.Checked = true;

                formGerenteFinanceiroAdicionarItens itens = new formGerenteFinanceiroAdicionarItens(this);
                itens.ShowDialog();

                AtualizarValor();
            }
            else
            {
                formGerenteFinanceiroAdicionarItens itens = new formGerenteFinanceiroAdicionarItens(this);
                itens.ShowDialog();

                AtualizarValor();
            }
        }
    }
}
