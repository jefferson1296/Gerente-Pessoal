
namespace GerenciamentoPessoal
{
    partial class formGerenteLoginsAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteLoginsAdicionar));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxMostrar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Descrição:";
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(117, 24);
            this.textBoxDescricao.MaxLength = 3000;
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(368, 26);
            this.textBoxDescricao.TabIndex = 11;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.Color.Black;
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(245, 164);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(159, 32);
            this.buttonCancelar.TabIndex = 57;
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
            this.buttonCadastrar.Location = new System.Drawing.Point(80, 164);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCadastrar.Size = new System.Drawing.Size(159, 32);
            this.buttonCadastrar.TabIndex = 56;
            this.buttonCadastrar.Text = "Cadastrar";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLogin.Location = new System.Drawing.Point(117, 68);
            this.textBoxLogin.MaxLength = 3000;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(368, 26);
            this.textBoxLogin.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 60;
            this.label2.Text = "Login:";
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenha.Location = new System.Drawing.Point(118, 117);
            this.textBoxSenha.MaxLength = 3000;
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(268, 26);
            this.textBoxSenha.TabIndex = 63;
            this.textBoxSenha.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 62;
            this.label3.Text = "Senha:";
            // 
            // checkBoxMostrar
            // 
            this.checkBoxMostrar.AutoSize = true;
            this.checkBoxMostrar.Location = new System.Drawing.Point(392, 123);
            this.checkBoxMostrar.Name = "checkBoxMostrar";
            this.checkBoxMostrar.Size = new System.Drawing.Size(93, 17);
            this.checkBoxMostrar.TabIndex = 64;
            this.checkBoxMostrar.Text = "Mostrar senha";
            this.checkBoxMostrar.UseVisualStyleBackColor = true;
            this.checkBoxMostrar.CheckedChanged += new System.EventHandler(this.checkBoxMostrar_CheckedChanged);
            // 
            // formGerenteLoginsAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 222);
            this.Controls.Add(this.checkBoxMostrar);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "formGerenteLoginsAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar login";
            this.Load += new System.EventHandler(this.formGestaoEstabelecimentosReparticoesAdicionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxMostrar;
    }
}