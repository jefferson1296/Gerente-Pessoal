
namespace GerenciamentoPessoal
{
    partial class formGerenteTreinamentosGruposAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteTreinamentosGruposAdicionar));
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(116, 20);
            this.textBoxDescricao.MaxLength = 30;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(251, 26);
            this.textBoxDescricao.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Descrição:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Black;
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(191, 69);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(159, 32);
            this.buttonCancelar.TabIndex = 59;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.BackColor = System.Drawing.Color.Black;
            this.buttonCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCadastrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCadastrar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCadastrar.ForeColor = System.Drawing.Color.White;
            this.buttonCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.Image")));
            this.buttonCadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCadastrar.Location = new System.Drawing.Point(26, 69);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCadastrar.Size = new System.Drawing.Size(159, 32);
            this.buttonCadastrar.TabIndex = 58;
            this.buttonCadastrar.Text = "Concluir";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // formGerenteTreinamentosGruposAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 122);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerenteTreinamentosGruposAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos musculares";
            this.Load += new System.EventHandler(this.formGerenteTreinamentosGrupo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
    }
}