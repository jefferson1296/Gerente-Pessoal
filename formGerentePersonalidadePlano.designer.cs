
namespace GerenciamentoPessoal
{
    partial class formGerentePersonalidadePlano
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerentePersonalidadePlano));
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.checkBoxArquivados = new System.Windows.Forms.CheckBox();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.arquivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.ColumnHeadersHeight = 28;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewLista.ContextMenuStrip = this.menuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(678, 294);
            this.dataGridViewLista.TabIndex = 65;
            this.dataGridViewLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellClick);
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewLista_CellFormatting);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            this.dataGridViewLista.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridViewLista_CellPainting);
            this.dataGridViewLista.SelectionChanged += new System.EventHandler(this.dataGridViewLista_SelectionChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.visualizarToolStripMenuItem,
            this.arquivarToolStripMenuItem});
            this.menuStrip.Name = "menuStripFluxo";
            this.menuStrip.Size = new System.Drawing.Size(124, 92);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            this.visualizarToolStripMenuItem.Click += new System.EventHandler(this.visualizarToolStripMenuItem_Click);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.BackColor = System.Drawing.Color.White;
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionar.ForeColor = System.Drawing.Color.Black;
            this.buttonAdicionar.Location = new System.Drawing.Point(541, 8);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(126, 28);
            this.buttonAdicionar.TabIndex = 92;
            this.buttonAdicionar.TabStop = false;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // checkBoxArquivados
            // 
            this.checkBoxArquivados.AutoSize = true;
            this.checkBoxArquivados.Location = new System.Drawing.Point(12, 19);
            this.checkBoxArquivados.Name = "checkBoxArquivados";
            this.checkBoxArquivados.Size = new System.Drawing.Size(106, 17);
            this.checkBoxArquivados.TabIndex = 93;
            this.checkBoxArquivados.Text = "Exibir arquivados";
            this.checkBoxArquivados.UseVisualStyleBackColor = true;
            this.checkBoxArquivados.CheckedChanged += new System.EventHandler(this.checkBoxArquivados_CheckedChanged);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 20F;
            this.Column4.HeaderText = "Nº";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 180F;
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 80F;
            this.Column2.HeaderText = "Local";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 20F;
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // arquivarToolStripMenuItem
            // 
            this.arquivarToolStripMenuItem.Name = "arquivarToolStripMenuItem";
            this.arquivarToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.arquivarToolStripMenuItem.Text = "Arquivar";
            this.arquivarToolStripMenuItem.Click += new System.EventHandler(this.arquivarToolStripMenuItem_Click);
            // 
            // formGerentePersonalidadePlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 342);
            this.Controls.Add(this.checkBoxArquivados);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.dataGridViewLista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerentePersonalidadePlano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plano de ação";
            this.Load += new System.EventHandler(this.formGestaoPlanosDeAcao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxArquivados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem arquivarToolStripMenuItem;
    }
}