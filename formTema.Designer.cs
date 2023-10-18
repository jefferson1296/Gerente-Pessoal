
namespace GerenciamentoPessoal
{
    partial class formTema
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSecundaria = new System.Windows.Forms.Panel();
            this.colorDialogCor1 = new System.Windows.Forms.ColorDialog();
            this.colorDialogCor2 = new System.Windows.Forms.ColorDialog();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPrincipal.Location = new System.Drawing.Point(165, 31);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(59, 63);
            this.panelPrincipal.TabIndex = 0;
            this.panelPrincipal.Click += new System.EventHandler(this.panelPrincipal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cor principal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cor secundária";
            // 
            // panelSecundaria
            // 
            this.panelSecundaria.BackColor = System.Drawing.Color.Black;
            this.panelSecundaria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSecundaria.Location = new System.Drawing.Point(165, 138);
            this.panelSecundaria.Name = "panelSecundaria";
            this.panelSecundaria.Size = new System.Drawing.Size(59, 63);
            this.panelSecundaria.TabIndex = 2;
            this.panelSecundaria.Click += new System.EventHandler(this.panelSecundaria_Click);
            // 
            // colorDialogCor1
            // 
            this.colorDialogCor1.Color = System.Drawing.Color.White;
            this.colorDialogCor1.FullOpen = true;
            // 
            // colorDialogCor2
            // 
            this.colorDialogCor2.FullOpen = true;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(54, 231);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(148, 31);
            this.buttonSalvar.TabIndex = 11;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // formTema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 289);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelSecundaria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "formTema";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tema";
            this.Load += new System.EventHandler(this.formTema_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSecundaria;
        private System.Windows.Forms.ColorDialog colorDialogCor1;
        private System.Windows.Forms.ColorDialog colorDialogCor2;
        private System.Windows.Forms.Button buttonSalvar;
    }
}