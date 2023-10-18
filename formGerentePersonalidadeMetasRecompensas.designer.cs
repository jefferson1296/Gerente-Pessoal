
namespace GerenciamentoPessoal
{
    partial class formGerentePersonalidadeMetasRecompensas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerentePersonalidadeMetasRecompensas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarRecompensaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonAdicionar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 34);
            this.panel1.TabIndex = 0;
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdicionar.BackColor = System.Drawing.Color.White;
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdicionar.ForeColor = System.Drawing.Color.Black;
            this.buttonAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdicionar.Image")));
            this.buttonAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdicionar.Location = new System.Drawing.Point(407, 4);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAdicionar.Size = new System.Drawing.Size(106, 25);
            this.buttonAdicionar.TabIndex = 478;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelMensagem);
            this.panel3.Controls.Add(this.dataGridViewLista);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(517, 208);
            this.panel3.TabIndex = 2;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewLista.ColumnHeadersHeight = 28;
            this.dataGridViewLista.ColumnHeadersVisible = false;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewLista.RowTemplate.Height = 30;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(517, 208);
            this.dataGridViewLista.TabIndex = 67;
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            this.dataGridViewLista.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellMouseEnter);
            this.dataGridViewLista.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewLista_CellPainting);
            this.dataGridViewLista.SelectionChanged += new System.EventHandler(this.dataGridViewLista_SelectionChanged);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50F;
            this.Column4.HeaderText = "Nº";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column1.FillWeight = 250F;
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.editarRecompensaToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(173, 48);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // editarRecompensaToolStripMenuItem
            // 
            this.editarRecompensaToolStripMenuItem.Name = "editarRecompensaToolStripMenuItem";
            this.editarRecompensaToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.editarRecompensaToolStripMenuItem.Text = "Editar recompensa";
            this.editarRecompensaToolStripMenuItem.Click += new System.EventHandler(this.editarRecompensaToolStripMenuItem_Click);
            // 
            // labelMensagem
            // 
            this.labelMensagem.AutoSize = true;
            this.labelMensagem.BackColor = System.Drawing.Color.White;
            this.labelMensagem.Font = new System.Drawing.Font("Arial", 9.75F);
            this.labelMensagem.ForeColor = System.Drawing.Color.DimGray;
            this.labelMensagem.Location = new System.Drawing.Point(82, 96);
            this.labelMensagem.MaximumSize = new System.Drawing.Size(400, 0);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(353, 16);
            this.labelMensagem.TabIndex = 483;
            this.labelMensagem.Text = "Trabalhe com recompensas para impulsionar seus objetivos";
            this.labelMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMensagem.Visible = false;
            // 
            // formGerentePersonalidadeMetasRecompensas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 242);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerentePersonalidadeMetasRecompensas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recompensas";
            this.Load += new System.EventHandler(this.formAtividadesProcessos_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripMenuItem editarRecompensaToolStripMenuItem;
        private System.Windows.Forms.Label labelMensagem;
    }
}