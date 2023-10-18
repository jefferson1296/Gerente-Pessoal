
namespace GerenciamentoPessoal
{
    partial class formGerenteFinanceiroFluxo
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
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle1 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle2 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle3 = new BrightIdeasSoftware.HeaderStateStyle();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.buttonCategorias = new System.Windows.Forms.Button();
            this.buttonRelatorios = new System.Windows.Forms.Button();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.headerFormatStyle1 = new BrightIdeasSoftware.HeaderFormatStyle();
            this.treeListView = new BrightIdeasSoftware.TreeListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.White;
            this.panelSuperior.Controls.Add(this.buttonCategorias);
            this.panelSuperior.Controls.Add(this.buttonRelatorios);
            this.panelSuperior.Controls.Add(this.comboBoxMes);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1009, 50);
            this.panelSuperior.TabIndex = 1;
            // 
            // buttonCategorias
            // 
            this.buttonCategorias.BackColor = System.Drawing.Color.White;
            this.buttonCategorias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCategorias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCategorias.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonCategorias.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonCategorias.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategorias.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCategorias.ForeColor = System.Drawing.Color.Black;
            this.buttonCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCategorias.Location = new System.Drawing.Point(7, 6);
            this.buttonCategorias.Name = "buttonCategorias";
            this.buttonCategorias.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonCategorias.Size = new System.Drawing.Size(177, 34);
            this.buttonCategorias.TabIndex = 162;
            this.buttonCategorias.Text = "Categorias";
            this.buttonCategorias.UseVisualStyleBackColor = false;
            this.buttonCategorias.Click += new System.EventHandler(this.buttonCategorias_Click);
            // 
            // buttonRelatorios
            // 
            this.buttonRelatorios.BackColor = System.Drawing.Color.White;
            this.buttonRelatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRelatorios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRelatorios.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonRelatorios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.buttonRelatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.buttonRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRelatorios.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRelatorios.ForeColor = System.Drawing.Color.Black;
            this.buttonRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRelatorios.Location = new System.Drawing.Point(192, 6);
            this.buttonRelatorios.Name = "buttonRelatorios";
            this.buttonRelatorios.Padding = new System.Windows.Forms.Padding(30, 0, 20, 0);
            this.buttonRelatorios.Size = new System.Drawing.Size(177, 34);
            this.buttonRelatorios.TabIndex = 161;
            this.buttonRelatorios.Text = "Relatórios";
            this.buttonRelatorios.UseVisualStyleBackColor = false;
            this.buttonRelatorios.Click += new System.EventHandler(this.buttonRelatorios_Click);
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxMes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(892, 10);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(105, 22);
            this.comboBoxMes.TabIndex = 160;
            this.comboBoxMes.SelectedIndexChanged += new System.EventHandler(this.comboBoxMes_SelectedIndexChanged);
            // 
            // headerFormatStyle1
            // 
            this.headerFormatStyle1.Hot = headerStateStyle1;
            this.headerFormatStyle1.Normal = headerStateStyle2;
            this.headerFormatStyle1.Pressed = headerStateStyle3;
            // 
            // treeListView
            // 
            this.treeListView.CellEditUseWholeCell = false;
            this.treeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView.FullRowSelect = true;
            this.treeListView.HideSelection = false;
            this.treeListView.Location = new System.Drawing.Point(0, 50);
            this.treeListView.Name = "treeListView";
            this.treeListView.ShowGroups = false;
            this.treeListView.Size = new System.Drawing.Size(1009, 559);
            this.treeListView.TabIndex = 2;
            this.treeListView.UseCellFormatEvents = true;
            this.treeListView.UseCompatibleStateImageBehavior = false;
            this.treeListView.View = System.Windows.Forms.View.Details;
            this.treeListView.VirtualMode = true;
            this.treeListView.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.treeListView_CellClick);
            this.treeListView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListView_FormatRow);
            // 
            // formGerenteFinanceiroFluxo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 609);
            this.Controls.Add(this.treeListView);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerenteFinanceiroFluxo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fluxo de caixa";
            this.Load += new System.EventHandler(this.formFinanceiroFluxo_Load);
            this.panelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private BrightIdeasSoftware.HeaderFormatStyle headerFormatStyle1;
        private BrightIdeasSoftware.TreeListView treeListView;
        private System.Windows.Forms.Button buttonCategorias;
        private System.Windows.Forms.Button buttonRelatorios;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}