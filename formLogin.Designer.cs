
namespace GerenciamentoPessoal
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.buttonAcessar = new System.Windows.Forms.Button();
            this.panelSenha = new System.Windows.Forms.Panel();
            this.textBoxSenha = new System.Windows.Forms.TextBox();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.labelEntrar = new System.Windows.Forms.Label();
            this.buttonFechar = new System.Windows.Forms.PictureBox();
            this.labelCumprimento = new System.Windows.Forms.Label();
            this.panelImagem = new System.Windows.Forms.Panel();
            this.timerTransparente = new System.Windows.Forms.Timer(this.components);
            this.labelCadastrar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFechar)).BeginInit();
            this.panelImagem.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAcessar
            // 
            this.buttonAcessar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAcessar.FlatAppearance.BorderSize = 0;
            this.buttonAcessar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcessar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcessar.ForeColor = System.Drawing.Color.MediumPurple;
            this.buttonAcessar.Location = new System.Drawing.Point(395, 216);
            this.buttonAcessar.Name = "buttonAcessar";
            this.buttonAcessar.Size = new System.Drawing.Size(149, 33);
            this.buttonAcessar.TabIndex = 18;
            this.buttonAcessar.Text = "Acessar >>";
            this.buttonAcessar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAcessar.UseVisualStyleBackColor = true;
            this.buttonAcessar.Click += new System.EventHandler(this.buttonAcessar_Click);
            // 
            // panelSenha
            // 
            this.panelSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelSenha.Location = new System.Drawing.Point(258, 169);
            this.panelSenha.Name = "panelSenha";
            this.panelSenha.Size = new System.Drawing.Size(286, 1);
            this.panelSenha.TabIndex = 23;
            // 
            // textBoxSenha
            // 
            this.textBoxSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.textBoxSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSenha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBoxSenha.Location = new System.Drawing.Point(258, 148);
            this.textBoxSenha.Name = "textBoxSenha";
            this.textBoxSenha.Size = new System.Drawing.Size(286, 20);
            this.textBoxSenha.TabIndex = 17;
            this.textBoxSenha.Text = "SENHA";
            this.textBoxSenha.Enter += new System.EventHandler(this.textBoxSenha_Enter);
            this.textBoxSenha.Leave += new System.EventHandler(this.textBoxSenha_Leave);
            this.textBoxSenha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxSenha_MouseDown);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelLogin.Location = new System.Drawing.Point(258, 131);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(286, 1);
            this.panelLogin.TabIndex = 22;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.textBoxUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.textBoxUsuario.Location = new System.Drawing.Point(258, 110);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(286, 20);
            this.textBoxUsuario.TabIndex = 16;
            this.textBoxUsuario.Text = "LOGIN";
            this.textBoxUsuario.Enter += new System.EventHandler(this.textBoxUsuario_Enter);
            this.textBoxUsuario.Leave += new System.EventHandler(this.textBoxUsuario_Leave);
            this.textBoxUsuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxUsuario_MouseDown);
            // 
            // labelEntrar
            // 
            this.labelEntrar.AutoSize = true;
            this.labelEntrar.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntrar.ForeColor = System.Drawing.Color.MediumPurple;
            this.labelEntrar.Location = new System.Drawing.Point(252, 5);
            this.labelEntrar.Name = "labelEntrar";
            this.labelEntrar.Size = new System.Drawing.Size(89, 33);
            this.labelEntrar.TabIndex = 21;
            this.labelEntrar.Text = "Entrar";
            // 
            // buttonFechar
            // 
            this.buttonFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFechar.Image = ((System.Drawing.Image)(resources.GetObject("buttonFechar.Image")));
            this.buttonFechar.Location = new System.Drawing.Point(554, 5);
            this.buttonFechar.Name = "buttonFechar";
            this.buttonFechar.Size = new System.Drawing.Size(20, 20);
            this.buttonFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonFechar.TabIndex = 19;
            this.buttonFechar.TabStop = false;
            this.buttonFechar.Click += new System.EventHandler(this.buttonFechar_Click);
            // 
            // labelCumprimento
            // 
            this.labelCumprimento.AutoSize = true;
            this.labelCumprimento.BackColor = System.Drawing.Color.Transparent;
            this.labelCumprimento.Font = new System.Drawing.Font("Mistral", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCumprimento.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelCumprimento.Location = new System.Drawing.Point(67, 5);
            this.labelCumprimento.Name = "labelCumprimento";
            this.labelCumprimento.Size = new System.Drawing.Size(105, 33);
            this.labelCumprimento.TabIndex = 25;
            this.labelCumprimento.Text = "Bom dia !";
            // 
            // panelImagem
            // 
            this.panelImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelImagem.Controls.Add(this.labelCumprimento);
            this.panelImagem.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelImagem.Location = new System.Drawing.Point(0, 0);
            this.panelImagem.Name = "panelImagem";
            this.panelImagem.Size = new System.Drawing.Size(223, 261);
            this.panelImagem.TabIndex = 26;
            // 
            // timerTransparente
            // 
            this.timerTransparente.Interval = 50;
            this.timerTransparente.Tick += new System.EventHandler(this.timerTransparente_Tick);
            // 
            // labelCadastrar
            // 
            this.labelCadastrar.AutoSize = true;
            this.labelCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCadastrar.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCadastrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelCadastrar.Location = new System.Drawing.Point(255, 212);
            this.labelCadastrar.Name = "labelCadastrar";
            this.labelCadastrar.Size = new System.Drawing.Size(68, 12);
            this.labelCadastrar.TabIndex = 27;
            this.labelCadastrar.Text = "Cadastre-se";
            this.labelCadastrar.Click += new System.EventHandler(this.labelCadastrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(255, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "Esqueceu sua senha?";
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(578, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCadastrar);
            this.Controls.Add(this.panelImagem);
            this.Controls.Add(this.buttonAcessar);
            this.Controls.Add(this.panelSenha);
            this.Controls.Add(this.textBoxSenha);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.labelEntrar);
            this.Controls.Add(this.buttonFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formLogin";
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formLogin_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formLogin_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.buttonFechar)).EndInit();
            this.panelImagem.ResumeLayout(false);
            this.panelImagem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAcessar;
        private System.Windows.Forms.Panel panelSenha;
        private System.Windows.Forms.TextBox textBoxSenha;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label labelEntrar;
        private System.Windows.Forms.PictureBox buttonFechar;
        private System.Windows.Forms.Label labelCumprimento;
        private System.Windows.Forms.Panel panelImagem;
        private System.Windows.Forms.Timer timerTransparente;
        private System.Windows.Forms.Label labelCadastrar;
        private System.Windows.Forms.Label label2;
    }
}