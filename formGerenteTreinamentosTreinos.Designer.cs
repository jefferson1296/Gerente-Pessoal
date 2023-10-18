
namespace GerenciamentoPessoal
{
    partial class formGerenteTreinamentosTreinos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteTreinamentosTreinos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTreinos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelMensagem = new System.Windows.Forms.Label();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renomearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonTreinos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 53);
            this.panel1.TabIndex = 0;
            // 
            // buttonTreinos
            // 
            this.buttonTreinos.BackColor = System.Drawing.Color.Black;
            this.buttonTreinos.ForeColor = System.Drawing.Color.White;
            this.buttonTreinos.Location = new System.Drawing.Point(284, 11);
            this.buttonTreinos.Name = "buttonTreinos";
            this.buttonTreinos.Size = new System.Drawing.Size(149, 32);
            this.buttonTreinos.TabIndex = 7;
            this.buttonTreinos.Text = "Adicionar treino";
            this.buttonTreinos.UseVisualStyleBackColor = false;
            this.buttonTreinos.Click += new System.EventHandler(this.buttonTreinos_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelMensagem);
            this.panel2.Controls.Add(this.dataGridViewLista);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 327);
            this.panel2.TabIndex = 1;
            // 
            // labelMensagem
            // 
            this.labelMensagem.AutoSize = true;
            this.labelMensagem.BackColor = System.Drawing.Color.White;
            this.labelMensagem.ForeColor = System.Drawing.Color.DimGray;
            this.labelMensagem.Location = new System.Drawing.Point(118, 157);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(208, 13);
            this.labelMensagem.TabIndex = 431;
            this.labelMensagem.Text = "Nenhum treino cadastrado até o momento.";
            this.labelMensagem.Visible = false;
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.ColumnHeadersHeight = 24;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2});
            this.dataGridViewLista.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(445, 327);
            this.dataGridViewLista.TabIndex = 430;
            this.dataGridViewLista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLista_CellDoubleClick);
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // Column5
            // 
            this.Column5.FillWeight = 50F;
            this.Column5.HeaderText = "N°";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Treino";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Grupos";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarToolStripMenuItem,
            this.renomearToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.importarPDFToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 114);
            // 
            // apagarToolStripMenuItem
            // 
            this.apagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("apagarToolStripMenuItem.Image")));
            this.apagarToolStripMenuItem.Name = "apagarToolStripMenuItem";
            this.apagarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.apagarToolStripMenuItem.Text = "Apagar";
            this.apagarToolStripMenuItem.Click += new System.EventHandler(this.apagarToolStripMenuItem_Click);
            // 
            // renomearToolStripMenuItem
            // 
            this.renomearToolStripMenuItem.Name = "renomearToolStripMenuItem";
            this.renomearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.renomearToolStripMenuItem.Text = "Renomear";
            this.renomearToolStripMenuItem.Click += new System.EventHandler(this.renomearToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // importarPDFToolStripMenuItem
            // 
            this.importarPDFToolStripMenuItem.Name = "importarPDFToolStripMenuItem";
            this.importarPDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importarPDFToolStripMenuItem.Text = "Importar PDF";
            this.importarPDFToolStripMenuItem.Click += new System.EventHandler(this.importarPDFToolStripMenuItem_Click);
            // 
            // formGerenteTreinamentosTreinos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 380);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formGerenteTreinamentosTreinos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formGerenteTreinamentosTreinos";
            this.Load += new System.EventHandler(this.formGerenteTreinamentosTreinos_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button buttonTreinos;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem apagarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renomearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarPDFToolStripMenuItem;
    }
}