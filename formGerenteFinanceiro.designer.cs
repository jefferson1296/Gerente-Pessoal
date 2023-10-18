
namespace GerenciamentoPessoal
{
    partial class formGerenteFinanceiro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteFinanceiro));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelBotoes = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despesasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.fluxoCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fluxoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.relatoriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saldoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mensalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patrimônioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.investimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxVisualizar = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelMovimentacoes = new System.Windows.Forms.Label();
            this.textBoxPesquisa = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.buttonExibir = new System.Windows.Forms.Button();
            this.textBoxRegistros = new System.Windows.Forms.TextBox();
            this.panelLinha = new System.Windows.Forms.Panel();
            this.dataGridViewFluxo = new ADGV.AdvancedDataGridView();
            this.ID_Movimentacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data_Prevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor_Previsto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orcamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStripFluxo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somatórioPrevistoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceFluxo = new System.Windows.Forms.BindingSource(this.components);
            this.timerFormatacao = new System.Windows.Forms.Timer(this.components);
            this.marcarComoPagoHojeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hojeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelBotoes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFluxo)).BeginInit();
            this.menuStripFluxo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFluxo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBotoes
            // 
            this.panelBotoes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBotoes.Controls.Add(this.panel1);
            this.panelBotoes.Controls.Add(this.comboBoxVisualizar);
            this.panelBotoes.Controls.Add(this.tableLayoutPanel2);
            this.panelBotoes.Controls.Add(this.panel2);
            this.panelBotoes.Controls.Add(this.panelSuperior);
            this.panelBotoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotoes.Location = new System.Drawing.Point(0, 0);
            this.panelBotoes.Name = "panelBotoes";
            this.panelBotoes.Size = new System.Drawing.Size(1301, 79);
            this.panelBotoes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.menuStrip4);
            this.panel1.Controls.Add(this.menuStrip3);
            this.panel1.Controls.Add(this.menuStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 30);
            this.panel1.TabIndex = 88;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(112, 24);
            this.menuStrip1.TabIndex = 92;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradaToolStripMenuItem,
            this.saidaToolStripMenuItem,
            this.transferenciaToolStripMenuItem,
            this.despesasToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.arquivoToolStripMenuItem.Text = "Movimentações";
            // 
            // entradaToolStripMenuItem
            // 
            this.entradaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("entradaToolStripMenuItem.Image")));
            this.entradaToolStripMenuItem.Name = "entradaToolStripMenuItem";
            this.entradaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.entradaToolStripMenuItem.Text = "Entrada";
            this.entradaToolStripMenuItem.Click += new System.EventHandler(this.entradaToolStripMenuItem_Click);
            // 
            // saidaToolStripMenuItem
            // 
            this.saidaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saidaToolStripMenuItem.Image")));
            this.saidaToolStripMenuItem.Name = "saidaToolStripMenuItem";
            this.saidaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saidaToolStripMenuItem.Text = "Saída";
            this.saidaToolStripMenuItem.Click += new System.EventHandler(this.saidaToolStripMenuItem_Click);
            // 
            // transferenciaToolStripMenuItem
            // 
            this.transferenciaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("transferenciaToolStripMenuItem.Image")));
            this.transferenciaToolStripMenuItem.Name = "transferenciaToolStripMenuItem";
            this.transferenciaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.transferenciaToolStripMenuItem.Text = "Transferência";
            this.transferenciaToolStripMenuItem.Click += new System.EventHandler(this.transferenciaToolStripMenuItem_Click);
            // 
            // despesasToolStripMenuItem
            // 
            this.despesasToolStripMenuItem.Name = "despesasToolStripMenuItem";
            this.despesasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.despesasToolStripMenuItem.Text = "Despesas";
            this.despesasToolStripMenuItem.Click += new System.EventHandler(this.despesasToolStripMenuItem_Click);
            // 
            // menuStrip4
            // 
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip4.Location = new System.Drawing.Point(112, 3);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(64, 24);
            this.menuStrip4.TabIndex = 91;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contasToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem1.Text = "Contas";
            // 
            // contasToolStripMenuItem
            // 
            this.contasToolStripMenuItem.Name = "contasToolStripMenuItem";
            this.contasToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.contasToolStripMenuItem.Text = "Ver contas";
            this.contasToolStripMenuItem.Click += new System.EventHandler(this.contasToolStripMenuItem_Click);
            // 
            // menuStrip3
            // 
            this.menuStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fluxoCaixaToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(176, 3);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(102, 24);
            this.menuStrip3.TabIndex = 90;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // fluxoCaixaToolStripMenuItem
            // 
            this.fluxoCaixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fluxoToolStripMenuItem,
            this.categoriasToolStripMenuItem});
            this.fluxoCaixaToolStripMenuItem.Name = "fluxoCaixaToolStripMenuItem";
            this.fluxoCaixaToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.fluxoCaixaToolStripMenuItem.Text = "Fluxo de caixa";
            // 
            // fluxoToolStripMenuItem
            // 
            this.fluxoToolStripMenuItem.Name = "fluxoToolStripMenuItem";
            this.fluxoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.fluxoToolStripMenuItem.Text = "Exibir fluxo";
            this.fluxoToolStripMenuItem.Click += new System.EventHandler(this.fluxoToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.categoriasToolStripMenuItem.Text = "Categorias";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatoriosToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(278, 3);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(79, 24);
            this.menuStrip2.TabIndex = 89;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // relatoriosToolStripMenuItem
            // 
            this.relatoriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saldoToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.mensalToolStripMenuItem,
            this.patrimônioToolStripMenuItem,
            this.investimentosToolStripMenuItem});
            this.relatoriosToolStripMenuItem.Name = "relatoriosToolStripMenuItem";
            this.relatoriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatoriosToolStripMenuItem.Text = "Relatórios";
            // 
            // saldoToolStripMenuItem
            // 
            this.saldoToolStripMenuItem.Name = "saldoToolStripMenuItem";
            this.saldoToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saldoToolStripMenuItem.Text = "Saldo";
            this.saldoToolStripMenuItem.Click += new System.EventHandler(this.saldoToolStripMenuItem_Click);
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            // 
            // mensalToolStripMenuItem
            // 
            this.mensalToolStripMenuItem.Name = "mensalToolStripMenuItem";
            this.mensalToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.mensalToolStripMenuItem.Text = "Relatório mensal";
            // 
            // patrimônioToolStripMenuItem
            // 
            this.patrimônioToolStripMenuItem.Name = "patrimônioToolStripMenuItem";
            this.patrimônioToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.patrimônioToolStripMenuItem.Text = "Patrimônio";
            // 
            // investimentosToolStripMenuItem
            // 
            this.investimentosToolStripMenuItem.Name = "investimentosToolStripMenuItem";
            this.investimentosToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.investimentosToolStripMenuItem.Text = "Investimentos";
            // 
            // comboBoxVisualizar
            // 
            this.comboBoxVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVisualizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxVisualizar.FormattingEnabled = true;
            this.comboBoxVisualizar.Items.AddRange(new object[] {
            "Visualizar apenas Lançamentos",
            "Visualizar apenas Orçamentos",
            "Visualizar Lançamentos e Orçamentos"});
            this.comboBoxVisualizar.Location = new System.Drawing.Point(1081, 44);
            this.comboBoxVisualizar.Name = "comboBoxVisualizar";
            this.comboBoxVisualizar.Size = new System.Drawing.Size(207, 21);
            this.comboBoxVisualizar.TabIndex = 86;
            this.comboBoxVisualizar.SelectedIndexChanged += new System.EventHandler(this.comboBoxVisualizar_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.22395F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.13064F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.56765F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelMovimentacoes, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPesquisa, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1286, 32);
            this.tableLayoutPanel2.TabIndex = 82;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(702, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(581, 2);
            this.panel5.TabIndex = 72;
            // 
            // labelMovimentacoes
            // 
            this.labelMovimentacoes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMovimentacoes.AutoSize = true;
            this.labelMovimentacoes.Font = new System.Drawing.Font("Arial", 13.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.labelMovimentacoes.Location = new System.Drawing.Point(546, 5);
            this.labelMovimentacoes.Name = "labelMovimentacoes";
            this.labelMovimentacoes.Size = new System.Drawing.Size(149, 21);
            this.labelMovimentacoes.TabIndex = 24;
            this.labelMovimentacoes.Text = "Movimentações";
            // 
            // textBoxPesquisa
            // 
            this.textBoxPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPesquisa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPesquisa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisa.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPesquisa.Location = new System.Drawing.Point(3, 3);
            this.textBoxPesquisa.MaxLength = 150;
            this.textBoxPesquisa.Name = "textBoxPesquisa";
            this.textBoxPesquisa.Size = new System.Drawing.Size(537, 26);
            this.textBoxPesquisa.TabIndex = 67;
            this.textBoxPesquisa.Text = "Digite aqui para pesquisar";
            this.textBoxPesquisa.TextChanged += new System.EventHandler(this.textBoxPesquisa_TextChanged);
            this.textBoxPesquisa.Enter += new System.EventHandler(this.textBoxPesquisa_Enter);
            this.textBoxPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPesquisa_KeyDown);
            this.textBoxPesquisa.Leave += new System.EventHandler(this.textBoxPesquisa_Leave);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1301, 3);
            this.panel2.TabIndex = 29;
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1301, 5);
            this.panelSuperior.TabIndex = 26;
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInferior.Controls.Add(this.buttonTodos);
            this.panelInferior.Controls.Add(this.buttonExibir);
            this.panelInferior.Controls.Add(this.textBoxRegistros);
            this.panelInferior.Controls.Add(this.panelLinha);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 608);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(1301, 46);
            this.panelInferior.TabIndex = 1;
            // 
            // buttonTodos
            // 
            this.buttonTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTodos.BackColor = System.Drawing.Color.White;
            this.buttonTodos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTodos.Location = new System.Drawing.Point(1208, 11);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(87, 23);
            this.buttonTodos.TabIndex = 50;
            this.buttonTodos.Text = "Mostrar todos";
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // buttonExibir
            // 
            this.buttonExibir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExibir.BackColor = System.Drawing.Color.White;
            this.buttonExibir.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExibir.Location = new System.Drawing.Point(1127, 11);
            this.buttonExibir.Name = "buttonExibir";
            this.buttonExibir.Size = new System.Drawing.Size(75, 23);
            this.buttonExibir.TabIndex = 49;
            this.buttonExibir.Text = "Exibir";
            this.buttonExibir.UseVisualStyleBackColor = false;
            this.buttonExibir.Click += new System.EventHandler(this.buttonExibir_Click);
            // 
            // textBoxRegistros
            // 
            this.textBoxRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRegistros.Location = new System.Drawing.Point(1078, 13);
            this.textBoxRegistros.Name = "textBoxRegistros";
            this.textBoxRegistros.Size = new System.Drawing.Size(43, 20);
            this.textBoxRegistros.TabIndex = 48;
            this.textBoxRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxRegistros.Enter += new System.EventHandler(this.textBoxRegistros_Enter);
            this.textBoxRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRegistros_KeyPress);
            this.textBoxRegistros.Leave += new System.EventHandler(this.textBoxRegistros_Leave);
            // 
            // panelLinha
            // 
            this.panelLinha.BackColor = System.Drawing.Color.White;
            this.panelLinha.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLinha.Location = new System.Drawing.Point(0, 0);
            this.panelLinha.Name = "panelLinha";
            this.panelLinha.Size = new System.Drawing.Size(1301, 2);
            this.panelLinha.TabIndex = 3;
            // 
            // dataGridViewFluxo
            // 
            this.dataGridViewFluxo.AllowUserToAddRows = false;
            this.dataGridViewFluxo.AllowUserToDeleteRows = false;
            this.dataGridViewFluxo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewFluxo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFluxo.AutoGenerateContextFilters = true;
            this.dataGridViewFluxo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFluxo.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFluxo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFluxo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewFluxo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFluxo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFluxo.ColumnHeadersHeight = 70;
            this.dataGridViewFluxo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewFluxo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Movimentacao,
            this.Column9,
            this.Categoria,
            this.Data_Prevista,
            this.Valor_Previsto,
            this.Column14,
            this.Valor,
            this.Column12,
            this.Orcamento,
            this.Transferencia});
            this.dataGridViewFluxo.ContextMenuStrip = this.menuStripFluxo;
            this.dataGridViewFluxo.DateWithTime = false;
            this.dataGridViewFluxo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFluxo.EnableHeadersVisualStyles = false;
            this.dataGridViewFluxo.GridColor = System.Drawing.Color.LightGray;
            this.dataGridViewFluxo.Location = new System.Drawing.Point(0, 79);
            this.dataGridViewFluxo.Name = "dataGridViewFluxo";
            this.dataGridViewFluxo.ReadOnly = true;
            this.dataGridViewFluxo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewFluxo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFluxo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFluxo.Size = new System.Drawing.Size(1301, 529);
            this.dataGridViewFluxo.TabIndex = 66;
            this.dataGridViewFluxo.TimeFilter = false;
            this.dataGridViewFluxo.SortStringChanged += new System.EventHandler(this.DataGridViewFluxo_SortStringChanged);
            this.dataGridViewFluxo.FilterStringChanged += new System.EventHandler(this.DataGridViewFluxo_FilterStringChanged);
            this.dataGridViewFluxo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFluxo_CellDoubleClick);
            this.dataGridViewFluxo.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewFluxo_CellMouseDown);
            this.dataGridViewFluxo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewFluxo_CellPainting);
            this.dataGridViewFluxo.SelectionChanged += new System.EventHandler(this.dataGridViewFluxo_SelectionChanged);
            // 
            // ID_Movimentacao
            // 
            this.ID_Movimentacao.DataPropertyName = "ID_Movimentacao";
            this.ID_Movimentacao.FillWeight = 35F;
            this.ID_Movimentacao.HeaderText = "ID";
            this.ID_Movimentacao.MinimumWidth = 22;
            this.ID_Movimentacao.Name = "ID_Movimentacao";
            this.ID_Movimentacao.ReadOnly = true;
            this.ID_Movimentacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ID_Movimentacao.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Descricao";
            this.Column9.FillWeight = 300F;
            this.Column9.HeaderText = "Descrição";
            this.Column9.MinimumWidth = 22;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.FillWeight = 150F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.MinimumWidth = 22;
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            this.Categoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Data_Prevista
            // 
            this.Data_Prevista.DataPropertyName = "Data_Prevista";
            this.Data_Prevista.FillWeight = 80F;
            this.Data_Prevista.HeaderText = "Data agendada";
            this.Data_Prevista.MinimumWidth = 22;
            this.Data_Prevista.Name = "Data_Prevista";
            this.Data_Prevista.ReadOnly = true;
            this.Data_Prevista.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Valor_Previsto
            // 
            this.Valor_Previsto.DataPropertyName = "Valor_Previsto";
            this.Valor_Previsto.FillWeight = 80F;
            this.Valor_Previsto.HeaderText = "Valor a pagar";
            this.Valor_Previsto.MinimumWidth = 22;
            this.Valor_Previsto.Name = "Valor_Previsto";
            this.Valor_Previsto.ReadOnly = true;
            this.Valor_Previsto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "Data";
            this.Column14.FillWeight = 80F;
            this.Column14.HeaderText = "Data realizada";
            this.Column14.MinimumWidth = 22;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            this.Valor.FillWeight = 80F;
            this.Valor.HeaderText = "Valor pago";
            this.Valor.MinimumWidth = 22;
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "Conta";
            this.Column12.FillWeight = 130F;
            this.Column12.HeaderText = "Conta";
            this.Column12.MinimumWidth = 22;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Orcamento
            // 
            this.Orcamento.DataPropertyName = "Orcamento";
            this.Orcamento.HeaderText = "Orcamento";
            this.Orcamento.MinimumWidth = 22;
            this.Orcamento.Name = "Orcamento";
            this.Orcamento.ReadOnly = true;
            this.Orcamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Orcamento.Visible = false;
            // 
            // Transferencia
            // 
            this.Transferencia.DataPropertyName = "Transferencia";
            this.Transferencia.HeaderText = "Transferencia";
            this.Transferencia.MinimumWidth = 22;
            this.Transferencia.Name = "Transferencia";
            this.Transferencia.ReadOnly = true;
            this.Transferencia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Transferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Transferencia.Visible = false;
            // 
            // menuStripFluxo
            // 
            this.menuStripFluxo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.somatorioToolStripMenuItem,
            this.somatórioPrevistoToolStripMenuItem,
            this.marcarComoPagoHojeToolStripMenuItem});
            this.menuStripFluxo.Name = "menuStripFluxo";
            this.menuStripFluxo.Size = new System.Drawing.Size(181, 114);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // somatorioToolStripMenuItem
            // 
            this.somatorioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("somatorioToolStripMenuItem.Image")));
            this.somatorioToolStripMenuItem.Name = "somatorioToolStripMenuItem";
            this.somatorioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.somatorioToolStripMenuItem.Text = "Somatório";
            this.somatorioToolStripMenuItem.Click += new System.EventHandler(this.somatorioToolStripMenuItem_Click);
            // 
            // somatórioPrevistoToolStripMenuItem
            // 
            this.somatórioPrevistoToolStripMenuItem.Name = "somatórioPrevistoToolStripMenuItem";
            this.somatórioPrevistoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.somatórioPrevistoToolStripMenuItem.Text = "Somatório previsto";
            this.somatórioPrevistoToolStripMenuItem.Click += new System.EventHandler(this.somatórioPrevistoToolStripMenuItem_Click);
            // 
            // timerFormatacao
            // 
            this.timerFormatacao.Tick += new System.EventHandler(this.timerFormatacao_Tick);
            // 
            // marcarComoPagoHojeToolStripMenuItem
            // 
            this.marcarComoPagoHojeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hojeToolStripMenuItem,
            this.naDataToolStripMenuItem});
            this.marcarComoPagoHojeToolStripMenuItem.Name = "marcarComoPagoHojeToolStripMenuItem";
            this.marcarComoPagoHojeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.marcarComoPagoHojeToolStripMenuItem.Text = "Marcar como pago";
            // 
            // hojeToolStripMenuItem
            // 
            this.hojeToolStripMenuItem.Name = "hojeToolStripMenuItem";
            this.hojeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hojeToolStripMenuItem.Text = "Hoje";
            this.hojeToolStripMenuItem.Click += new System.EventHandler(this.hojeToolStripMenuItem_Click);
            // 
            // naDataToolStripMenuItem
            // 
            this.naDataToolStripMenuItem.Name = "naDataToolStripMenuItem";
            this.naDataToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.naDataToolStripMenuItem.Text = "Na data";
            this.naDataToolStripMenuItem.Click += new System.EventHandler(this.naDataToolStripMenuItem_Click);
            // 
            // formGerenteFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 654);
            this.Controls.Add(this.dataGridViewFluxo);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelBotoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formGerenteFinanceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formFinanceiroFluxo";
            this.Load += new System.EventHandler(this.formFinanceiroFluxo_Load);
            this.panelBotoes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFluxo)).EndInit();
            this.menuStripFluxo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFluxo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBotoes;
        private System.Windows.Forms.Label labelMovimentacoes;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.BindingSource bindingSourceFluxo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelInferior;
        private ADGV.AdvancedDataGridView dataGridViewFluxo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelLinha;
        private System.Windows.Forms.ContextMenuStrip menuStripFluxo;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxPesquisa;
        private System.Windows.Forms.ToolStripMenuItem somatorioToolStripMenuItem;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Button buttonExibir;
        private System.Windows.Forms.TextBox textBoxRegistros;
        private System.Windows.Forms.Timer timerFormatacao;
        private System.Windows.Forms.ComboBox comboBoxVisualizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contasToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem fluxoCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fluxoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem relatoriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saldoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mensalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patrimônioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem investimentosToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem somatórioPrevistoToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Movimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Prevista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor_Previsto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orcamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transferencia;
        private System.Windows.Forms.ToolStripMenuItem marcarComoPagoHojeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hojeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naDataToolStripMenuItem;
    }
}