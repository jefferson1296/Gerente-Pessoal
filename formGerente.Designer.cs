
namespace GerenciamentoPessoal
{
    partial class formGerente
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerente));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuracoesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.temaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alterarSenhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFinanças = new System.Windows.Forms.Button();
            this.buttonPersonalidade = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLinha3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelLinha2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelLinha1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.timerAfazeres = new System.Windows.Forms.Timer(this.components);
            this.panelSuperior.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLinha3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelLinha2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelLinha1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.SystemColors.Control;
            this.panelSuperior.Controls.Add(this.menuStrip1);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1100, 24);
            this.panelSuperior.TabIndex = 0;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracoesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "Configurações";
            // 
            // configuracoesToolStripMenuItem
            // 
            this.configuracoesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.temaToolStripMenuItem,
            this.alterarSenhaToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.configuracoesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuracoesToolStripMenuItem.Image")));
            this.configuracoesToolStripMenuItem.Name = "configuracoesToolStripMenuItem";
            this.configuracoesToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.configuracoesToolStripMenuItem.Text = "Configurações";
            // 
            // temaToolStripMenuItem
            // 
            this.temaToolStripMenuItem.Name = "temaToolStripMenuItem";
            this.temaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.temaToolStripMenuItem.Text = "Tema";
            this.temaToolStripMenuItem.Click += new System.EventHandler(this.temaToolStripMenuItem_Click);
            // 
            // alterarSenhaToolStripMenuItem
            // 
            this.alterarSenhaToolStripMenuItem.Name = "alterarSenhaToolStripMenuItem";
            this.alterarSenhaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.alterarSenhaToolStripMenuItem.Text = "Alterar senha";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.buttonFinanças, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPersonalidade, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1100, 84);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonFinanças
            // 
            this.buttonFinanças.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFinanças.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFinanças.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFinanças.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinanças.Image = ((System.Drawing.Image)(resources.GetObject("buttonFinanças.Image")));
            this.buttonFinanças.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFinanças.Location = new System.Drawing.Point(553, 3);
            this.buttonFinanças.Name = "buttonFinanças";
            this.buttonFinanças.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonFinanças.Size = new System.Drawing.Size(544, 78);
            this.buttonFinanças.TabIndex = 2;
            this.buttonFinanças.Text = "Recursos";
            this.buttonFinanças.UseVisualStyleBackColor = false;
            this.buttonFinanças.Click += new System.EventHandler(this.buttonFinanças_Click);
            // 
            // buttonPersonalidade
            // 
            this.buttonPersonalidade.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPersonalidade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPersonalidade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPersonalidade.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPersonalidade.Image = ((System.Drawing.Image)(resources.GetObject("buttonPersonalidade.Image")));
            this.buttonPersonalidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPersonalidade.Location = new System.Drawing.Point(3, 3);
            this.buttonPersonalidade.Name = "buttonPersonalidade";
            this.buttonPersonalidade.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonPersonalidade.Size = new System.Drawing.Size(544, 78);
            this.buttonPersonalidade.TabIndex = 1;
            this.buttonPersonalidade.Text = "Personalidade";
            this.buttonPersonalidade.UseVisualStyleBackColor = false;
            this.buttonPersonalidade.Click += new System.EventHandler(this.buttonPersonalidade_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 84);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panelLinha3);
            this.panel2.Controls.Add(this.panelLinha2);
            this.panel2.Controls.Add(this.panelLinha1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 6);
            this.panel2.TabIndex = 10;
            // 
            // panelLinha3
            // 
            this.panelLinha3.BackColor = System.Drawing.Color.DarkRed;
            this.panelLinha3.Controls.Add(this.pictureBox4);
            this.panelLinha3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLinha3.Location = new System.Drawing.Point(0, 4);
            this.panelLinha3.Name = "panelLinha3";
            this.panelLinha3.Size = new System.Drawing.Size(1100, 2);
            this.panelLinha3.TabIndex = 13;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(7, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // panelLinha2
            // 
            this.panelLinha2.BackColor = System.Drawing.Color.White;
            this.panelLinha2.Controls.Add(this.pictureBox3);
            this.panelLinha2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLinha2.Location = new System.Drawing.Point(0, 2);
            this.panelLinha2.Name = "panelLinha2";
            this.panelLinha2.Size = new System.Drawing.Size(1100, 2);
            this.panelLinha2.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(7, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // panelLinha1
            // 
            this.panelLinha1.BackColor = System.Drawing.Color.DarkRed;
            this.panelLinha1.Controls.Add(this.pictureBox2);
            this.panelLinha1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLinha1.Location = new System.Drawing.Point(0, 0);
            this.panelLinha1.Name = "panelLinha1";
            this.panelLinha1.Size = new System.Drawing.Size(1100, 2);
            this.panelLinha1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(7, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panelCentral
            // 
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(0, 114);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(1100, 586);
            this.panelCentral.TabIndex = 11;
            // 
            // timerAfazeres
            // 
            this.timerAfazeres.Interval = 1000;
            this.timerAfazeres.Tick += new System.EventHandler(this.timerAfazeres_Tick);
            // 
            // formGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formGerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerente pessoal";
            this.Load += new System.EventHandler(this.formPlanejamentoSemanal_Load);
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelLinha3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelLinha2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelLinha1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonFinanças;
        private System.Windows.Forms.Button buttonPersonalidade;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelLinha3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelLinha2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panelLinha1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracoesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem temaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alterarSenhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Timer timerAfazeres;
    }
}

