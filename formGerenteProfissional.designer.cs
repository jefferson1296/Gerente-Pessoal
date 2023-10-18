
namespace GerenciamentoPessoal
{
    partial class formGerenteProfissional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteProfissional));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelRegistros = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.agendarParaAmanhãToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelExportar = new System.Windows.Forms.Label();
            this.labelImprimir = new System.Windows.Forms.Label();
            this.pbProximo = new System.Windows.Forms.PictureBox();
            this.pbAnterior = new System.Windows.Forms.PictureBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelLista = new System.Windows.Forms.Label();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.buttonSubirRotina = new System.Windows.Forms.Button();
            this.buttonDescerRotina = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.buttonSubir = new System.Windows.Forms.Button();
            this.buttonDescer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.labelRotinas = new System.Windows.Forms.Label();
            this.dataGridViewRotinas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarRotinaTtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProximo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRotinas)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRegistros
            // 
            this.labelRegistros.AutoSize = true;
            this.labelRegistros.BackColor = System.Drawing.Color.White;
            this.labelRegistros.ForeColor = System.Drawing.Color.Gray;
            this.labelRegistros.Location = new System.Drawing.Point(215, 125);
            this.labelRegistros.Name = "labelRegistros";
            this.labelRegistros.Size = new System.Drawing.Size(199, 13);
            this.labelRegistros.TabIndex = 68;
            this.labelRegistros.Text = "Não há afazeres registrados para a data.";
            this.labelRegistros.Visible = false;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agendarParaAmanhãToolStripMenuItem,
            this.apagarToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(192, 48);
            // 
            // agendarParaAmanhãToolStripMenuItem
            // 
            this.agendarParaAmanhãToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("agendarParaAmanhãToolStripMenuItem.Image")));
            this.agendarParaAmanhãToolStripMenuItem.Name = "agendarParaAmanhãToolStripMenuItem";
            this.agendarParaAmanhãToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.agendarParaAmanhãToolStripMenuItem.Text = "Agendar para amanhã";
            this.agendarParaAmanhãToolStripMenuItem.Click += new System.EventHandler(this.agendarParaAmanhãToolStripMenuItem_Click);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelExportar);
            this.panel1.Controls.Add(this.labelImprimir);
            this.panel1.Controls.Add(this.pbProximo);
            this.panel1.Controls.Add(this.pbAnterior);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.labelLista);
            this.panel1.Controls.Add(this.buttonAdicionar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 54);
            this.panel1.TabIndex = 4;
            // 
            // labelExportar
            // 
            this.labelExportar.AutoSize = true;
            this.labelExportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExportar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelExportar.Location = new System.Drawing.Point(435, 6);
            this.labelExportar.Name = "labelExportar";
            this.labelExportar.Size = new System.Drawing.Size(46, 13);
            this.labelExportar.TabIndex = 483;
            this.labelExportar.Text = "Exportar";
            this.labelExportar.Click += new System.EventHandler(this.labelExportar_Click);
            // 
            // labelImprimir
            // 
            this.labelImprimir.AutoSize = true;
            this.labelImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImprimir.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelImprimir.Location = new System.Drawing.Point(365, 6);
            this.labelImprimir.Name = "labelImprimir";
            this.labelImprimir.Size = new System.Drawing.Size(42, 13);
            this.labelImprimir.TabIndex = 481;
            this.labelImprimir.Text = "Imprimir";
            this.labelImprimir.Click += new System.EventHandler(this.labelImprimir_Click);
            // 
            // pbProximo
            // 
            this.pbProximo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProximo.BackColor = System.Drawing.Color.Transparent;
            this.pbProximo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbProximo.Image = ((System.Drawing.Image)(resources.GetObject("pbProximo.Image")));
            this.pbProximo.Location = new System.Drawing.Point(479, 22);
            this.pbProximo.Name = "pbProximo";
            this.pbProximo.Size = new System.Drawing.Size(20, 20);
            this.pbProximo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProximo.TabIndex = 482;
            this.pbProximo.TabStop = false;
            this.pbProximo.Click += new System.EventHandler(this.pbProximo_Click);
            // 
            // pbAnterior
            // 
            this.pbAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAnterior.BackColor = System.Drawing.Color.Transparent;
            this.pbAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("pbAnterior.Image")));
            this.pbAnterior.Location = new System.Drawing.Point(342, 22);
            this.pbAnterior.Name = "pbAnterior";
            this.pbAnterior.Size = new System.Drawing.Size(20, 20);
            this.pbAnterior.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnterior.TabIndex = 481;
            this.pbAnterior.TabStop = false;
            this.pbAnterior.Click += new System.EventHandler(this.pbAnterior_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(368, 22);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker.TabIndex = 480;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // labelLista
            // 
            this.labelLista.AutoSize = true;
            this.labelLista.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLista.ForeColor = System.Drawing.Color.Red;
            this.labelLista.Location = new System.Drawing.Point(9, 13);
            this.labelLista.Name = "labelLista";
            this.labelLista.Size = new System.Drawing.Size(286, 30);
            this.labelLista.TabIndex = 479;
            this.labelLista.Text = "Minha lista de afazeres";
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdicionar.BackColor = System.Drawing.Color.White;
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdicionar.ForeColor = System.Drawing.Color.Black;
            this.buttonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.Image")));
            this.buttonAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdicionar.Location = new System.Drawing.Point(552, 15);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdicionar.Size = new System.Drawing.Size(161, 32);
            this.buttonAdicionar.TabIndex = 478;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(639, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(82, 446);
            this.panel2.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.buttonSubirRotina);
            this.panel8.Controls.Add(this.buttonDescerRotina);
            this.panel8.Location = new System.Drawing.Point(14, 336);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(54, 89);
            this.panel8.TabIndex = 493;
            // 
            // buttonSubirRotina
            // 
            this.buttonSubirRotina.BackColor = System.Drawing.Color.White;
            this.buttonSubirRotina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubirRotina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubirRotina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSubirRotina.ForeColor = System.Drawing.Color.Black;
            this.buttonSubirRotina.Image = ((System.Drawing.Image)(resources.GetObject("buttonSubirRotina.Image")));
            this.buttonSubirRotina.Location = new System.Drawing.Point(11, 11);
            this.buttonSubirRotina.Name = "buttonSubirRotina";
            this.buttonSubirRotina.Size = new System.Drawing.Size(30, 29);
            this.buttonSubirRotina.TabIndex = 485;
            this.buttonSubirRotina.UseVisualStyleBackColor = false;
            this.buttonSubirRotina.Click += new System.EventHandler(this.buttonSubirRotina_Click);
            // 
            // buttonDescerRotina
            // 
            this.buttonDescerRotina.BackColor = System.Drawing.Color.White;
            this.buttonDescerRotina.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDescerRotina.BackgroundImage")));
            this.buttonDescerRotina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDescerRotina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDescerRotina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDescerRotina.ForeColor = System.Drawing.Color.Black;
            this.buttonDescerRotina.Image = ((System.Drawing.Image)(resources.GetObject("buttonDescerRotina.Image")));
            this.buttonDescerRotina.Location = new System.Drawing.Point(11, 48);
            this.buttonDescerRotina.Name = "buttonDescerRotina";
            this.buttonDescerRotina.Size = new System.Drawing.Size(30, 26);
            this.buttonDescerRotina.TabIndex = 486;
            this.buttonDescerRotina.UseVisualStyleBackColor = false;
            this.buttonDescerRotina.Click += new System.EventHandler(this.buttonDescerRotina_Click);
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.buttonSubir);
            this.panel11.Controls.Add(this.buttonDescer);
            this.panel11.Location = new System.Drawing.Point(14, 49);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(54, 179);
            this.panel11.TabIndex = 492;
            // 
            // buttonSubir
            // 
            this.buttonSubir.BackColor = System.Drawing.Color.White;
            this.buttonSubir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSubir.BackgroundImage")));
            this.buttonSubir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSubir.ForeColor = System.Drawing.Color.Black;
            this.buttonSubir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSubir.Image")));
            this.buttonSubir.Location = new System.Drawing.Point(11, 11);
            this.buttonSubir.Name = "buttonSubir";
            this.buttonSubir.Size = new System.Drawing.Size(30, 66);
            this.buttonSubir.TabIndex = 485;
            this.buttonSubir.UseVisualStyleBackColor = false;
            this.buttonSubir.Click += new System.EventHandler(this.buttonSubir_Click);
            // 
            // buttonDescer
            // 
            this.buttonDescer.BackColor = System.Drawing.Color.White;
            this.buttonDescer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDescer.BackgroundImage")));
            this.buttonDescer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDescer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDescer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDescer.ForeColor = System.Drawing.Color.Black;
            this.buttonDescer.Image = ((System.Drawing.Image)(resources.GetObject("buttonDescer.Image")));
            this.buttonDescer.Location = new System.Drawing.Point(11, 96);
            this.buttonDescer.Name = "buttonDescer";
            this.buttonDescer.Size = new System.Drawing.Size(30, 63);
            this.buttonDescer.TabIndex = 486;
            this.buttonDescer.UseVisualStyleBackColor = false;
            this.buttonDescer.Click += new System.EventHandler(this.buttonDescer_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(639, 446);
            this.panel3.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.labelRotinas);
            this.panel7.Controls.Add(this.dataGridViewRotinas);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 299);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(639, 147);
            this.panel7.TabIndex = 72;
            // 
            // labelRotinas
            // 
            this.labelRotinas.AutoSize = true;
            this.labelRotinas.BackColor = System.Drawing.Color.White;
            this.labelRotinas.ForeColor = System.Drawing.Color.Gray;
            this.labelRotinas.Location = new System.Drawing.Point(253, 71);
            this.labelRotinas.Name = "labelRotinas";
            this.labelRotinas.Size = new System.Drawing.Size(133, 13);
            this.labelRotinas.TabIndex = 68;
            this.labelRotinas.Text = "Não há rotinas registradas.";
            this.labelRotinas.Visible = false;
            // 
            // dataGridViewRotinas
            // 
            this.dataGridViewRotinas.AllowUserToAddRows = false;
            this.dataGridViewRotinas.AllowUserToResizeColumns = false;
            this.dataGridViewRotinas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewRotinas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRotinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRotinas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRotinas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRotinas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewRotinas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRotinas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRotinas.ColumnHeadersHeight = 32;
            this.dataGridViewRotinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1});
            this.dataGridViewRotinas.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewRotinas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRotinas.EnableHeadersVisualStyles = false;
            this.dataGridViewRotinas.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewRotinas.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRotinas.Name = "dataGridViewRotinas";
            this.dataGridViewRotinas.ReadOnly = true;
            this.dataGridViewRotinas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewRotinas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewRotinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRotinas.Size = new System.Drawing.Size(639, 147);
            this.dataGridViewRotinas.TabIndex = 67;
            this.dataGridViewRotinas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRotinas_CellClick);
            this.dataGridViewRotinas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRotinas_CellDoubleClick);
            this.dataGridViewRotinas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRotinas_CellFormatting);
            this.dataGridViewRotinas.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRotinas_CellMouseDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 30F;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Atividade";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tempo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.FillWeight = 30F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarRotinaTtoolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 26);
            // 
            // apagarRotinaTtoolStripMenuItem
            // 
            this.apagarRotinaTtoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarRotinaTtoolStripMenuItem.Image")));
            this.apagarRotinaTtoolStripMenuItem.Name = "apagarRotinaTtoolStripMenuItem";
            this.apagarRotinaTtoolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.apagarRotinaTtoolStripMenuItem.Text = "Apagar rotina";
            this.apagarRotinaTtoolStripMenuItem.Click += new System.EventHandler(this.apagarRotinaTtoolStripMenuItem_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 267);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(639, 32);
            this.panel6.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(281, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 482;
            this.label3.Text = "Rotinas";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelRegistros);
            this.panel5.Controls.Add(this.dataGridViewLista);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(639, 235);
            this.panel5.TabIndex = 70;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewLista.ColumnHeadersHeight = 32;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column16,
            this.Column2});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(639, 235);
            this.dataGridViewLista.TabIndex = 67;
            this.dataGridViewLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellClick);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLista_CellFormatting);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // Column3
            // 
            this.Column3.FillWeight = 30F;
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.FillWeight = 200F;
            this.Column1.HeaderText = "Atividade";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Tempo";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 30F;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(639, 32);
            this.panel4.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(212, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 22);
            this.label2.TabIndex = 480;
            this.label2.Text = "Atividades pendentes";
            // 
            // formGerenteProfissional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 500);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "formGerenteProfissional";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista";
            this.Load += new System.EventHandler(this.formTelaInicialPrincipalGestaoAfazeres_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProximo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnterior)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRotinas)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelLista;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.Label labelRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button buttonSubir;
        private System.Windows.Forms.Button buttonDescer;
        private System.Windows.Forms.PictureBox pbProximo;
        private System.Windows.Forms.PictureBox pbAnterior;
        private System.Windows.Forms.ToolStripMenuItem agendarParaAmanhãToolStripMenuItem;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label labelRotinas;
        private System.Windows.Forms.DataGridView dataGridViewRotinas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem apagarRotinaTtoolStripMenuItem;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button buttonSubirRotina;
        private System.Windows.Forms.Button buttonDescerRotina;
        private System.Windows.Forms.Label labelImprimir;
        private System.Windows.Forms.Label labelExportar;
    }
}