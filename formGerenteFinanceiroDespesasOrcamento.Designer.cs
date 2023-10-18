
namespace GerenciamentoPessoal
{
    partial class formGerenteFinanceiroDespesasOrcamento
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxPeriodo = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonConcluir = new System.Windows.Forms.Button();
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.orcamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxPeriodo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 48);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxPeriodo
            // 
            this.comboBoxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxPeriodo.FormattingEnabled = true;
            this.comboBoxPeriodo.Location = new System.Drawing.Point(316, 10);
            this.comboBoxPeriodo.Name = "comboBoxPeriodo";
            this.comboBoxPeriodo.Size = new System.Drawing.Size(189, 21);
            this.comboBoxPeriodo.TabIndex = 0;
            this.comboBoxPeriodo.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodo_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonConcluir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 385);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 68);
            this.panel2.TabIndex = 1;
            // 
            // buttonConcluir
            // 
            this.buttonConcluir.BackColor = System.Drawing.Color.White;
            this.buttonConcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonConcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConcluir.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConcluir.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConcluir.ForeColor = System.Drawing.SystemColors.GrayText;
            this.buttonConcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConcluir.Location = new System.Drawing.Point(346, 18);
            this.buttonConcluir.Name = "buttonConcluir";
            this.buttonConcluir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonConcluir.Size = new System.Drawing.Size(159, 30);
            this.buttonConcluir.TabIndex = 79;
            this.buttonConcluir.Text = "Concluir";
            this.buttonConcluir.UseVisualStyleBackColor = false;
            this.buttonConcluir.Click += new System.EventHandler(this.buttonConcluir_Click);
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AllowUserToAddRows = false;
            this.dataGridViewLista.AllowUserToResizeColumns = false;
            this.dataGridViewLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.dataGridViewLista.ColumnHeadersHeight = 48;
            this.dataGridViewLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column3,
            this.Column4});
            this.dataGridViewLista.ContextMenuStrip = this.menuStrip;
            this.dataGridViewLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLista.EnableHeadersVisualStyles = false;
            this.dataGridViewLista.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewLista.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.ReadOnly = true;
            this.dataGridViewLista.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLista.Size = new System.Drawing.Size(517, 337);
            this.dataGridViewLista.TabIndex = 92;
            this.dataGridViewLista.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewLista_CellMouseDown);
            // 
            // Column6
            // 
            this.Column6.FillWeight = 35F;
            this.Column6.HeaderText = "N°";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 180F;
            this.Column1.HeaderText = "Descrição";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 70F;
            this.Column3.HeaderText = "Valor";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 90F;
            this.Column4.HeaderText = "Data";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orcamentoToolStripMenuItem});
            this.menuStrip.Name = "menuStripFluxo";
            this.menuStrip.Size = new System.Drawing.Size(188, 26);
            // 
            // orcamentoToolStripMenuItem
            // 
            this.orcamentoToolStripMenuItem.Name = "orcamentoToolStripMenuItem";
            this.orcamentoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.orcamentoToolStripMenuItem.Text = "Lançar no orçamento";
            this.orcamentoToolStripMenuItem.Click += new System.EventHandler(this.orcamentoToolStripMenuItem_Click);
            // 
            // formGerenteFinanceiroDespesasOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 453);
            this.Controls.Add(this.dataGridViewLista);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerenteFinanceiroDespesasOrcamento";
            this.Text = "Lançar despesas no orçamento";
            this.Load += new System.EventHandler(this.formGerenteFinanceiroDespesasOrcamento_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPeriodo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button buttonConcluir;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem orcamentoToolStripMenuItem;
    }
}