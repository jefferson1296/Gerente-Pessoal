
namespace GerenciamentoPessoal
{
    partial class formGerenteTreinamentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteTreinamentos));
            this.panelLateral = new System.Windows.Forms.Panel();
            this.buttonFrases = new System.Windows.Forms.Button();
            this.buttonTreinos = new System.Windows.Forms.Button();
            this.buttonExercicios = new System.Windows.Forms.Button();
            this.buttonInicial = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLateral.SuspendLayout();
            this.panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.Black;
            this.panelLateral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelLateral.Controls.Add(this.buttonFrases);
            this.panelLateral.Controls.Add(this.buttonTreinos);
            this.panelLateral.Controls.Add(this.buttonExercicios);
            this.panelLateral.Controls.Add(this.buttonInicial);
            this.panelLateral.Controls.Add(this.panel4);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 0);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(167, 380);
            this.panelLateral.TabIndex = 1;
            // 
            // buttonFrases
            // 
            this.buttonFrases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFrases.ForeColor = System.Drawing.Color.White;
            this.buttonFrases.Location = new System.Drawing.Point(12, 146);
            this.buttonFrases.Name = "buttonFrases";
            this.buttonFrases.Size = new System.Drawing.Size(149, 23);
            this.buttonFrases.TabIndex = 6;
            this.buttonFrases.Text = "Frases de efeito";
            this.buttonFrases.UseVisualStyleBackColor = true;
            this.buttonFrases.Click += new System.EventHandler(this.buttonFrases_Click);
            // 
            // buttonTreinos
            // 
            this.buttonTreinos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTreinos.ForeColor = System.Drawing.Color.White;
            this.buttonTreinos.Location = new System.Drawing.Point(12, 76);
            this.buttonTreinos.Name = "buttonTreinos";
            this.buttonTreinos.Size = new System.Drawing.Size(149, 23);
            this.buttonTreinos.TabIndex = 4;
            this.buttonTreinos.Text = "Treinos";
            this.buttonTreinos.UseVisualStyleBackColor = true;
            this.buttonTreinos.Click += new System.EventHandler(this.buttonTreinos_Click);
            // 
            // buttonExercicios
            // 
            this.buttonExercicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExercicios.ForeColor = System.Drawing.Color.White;
            this.buttonExercicios.Location = new System.Drawing.Point(12, 41);
            this.buttonExercicios.Name = "buttonExercicios";
            this.buttonExercicios.Size = new System.Drawing.Size(149, 23);
            this.buttonExercicios.TabIndex = 3;
            this.buttonExercicios.Text = "Exercícios";
            this.buttonExercicios.UseVisualStyleBackColor = true;
            this.buttonExercicios.Click += new System.EventHandler(this.buttonExercicios_Click);
            // 
            // buttonInicial
            // 
            this.buttonInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInicial.ForeColor = System.Drawing.Color.White;
            this.buttonInicial.Location = new System.Drawing.Point(12, 6);
            this.buttonInicial.Name = "buttonInicial";
            this.buttonInicial.Size = new System.Drawing.Size(149, 23);
            this.buttonInicial.TabIndex = 0;
            this.buttonInicial.Text = "Tela inicial";
            this.buttonInicial.UseVisualStyleBackColor = true;
            this.buttonInicial.Click += new System.EventHandler(this.buttonInicial_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 193);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(167, 187);
            this.panel4.TabIndex = 2;
            // 
            // panelCentral
            // 
            this.panelCentral.BackColor = System.Drawing.Color.Black;
            this.panelCentral.Controls.Add(this.pictureBox1);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(167, 0);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(445, 380);
            this.panelCentral.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(247, -21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // formGerenteTreinamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 380);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelLateral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerenteTreinamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Treinamentos";
            this.Load += new System.EventHandler(this.formGerenteTreinamentos_Load);
            this.panelLateral.ResumeLayout(false);
            this.panelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Button buttonFrases;
        private System.Windows.Forms.Button buttonTreinos;
        private System.Windows.Forms.Button buttonExercicios;
        private System.Windows.Forms.Button buttonInicial;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}