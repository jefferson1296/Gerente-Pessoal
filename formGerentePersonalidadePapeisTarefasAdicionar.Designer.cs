
namespace GerenciamentoPessoal
{
    partial class formGerentePersonalidadePapeisTarefasAdicionar
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxObservacoes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMulti = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 520;
            this.label2.Text = "Observações:";
            // 
            // textBoxObservacoes
            // 
            this.textBoxObservacoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxObservacoes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservacoes.Location = new System.Drawing.Point(15, 95);
            this.textBoxObservacoes.Multiline = true;
            this.textBoxObservacoes.Name = "textBoxObservacoes";
            this.textBoxObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxObservacoes.Size = new System.Drawing.Size(344, 42);
            this.textBoxObservacoes.TabIndex = 519;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 518;
            this.label1.Text = "Descrição:";
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescricao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(109, 15);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(250, 18);
            this.textBoxDescricao.TabIndex = 517;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.Location = new System.Drawing.Point(188, 158);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(148, 31);
            this.buttonCancelar.TabIndex = 522;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.Location = new System.Drawing.Point(34, 158);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(148, 31);
            this.buttonSalvar.TabIndex = 521;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 524;
            this.label3.Text = "Multiplicador:";
            // 
            // textBoxMulti
            // 
            this.textBoxMulti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMulti.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMulti.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxMulti.Location = new System.Drawing.Point(109, 45);
            this.textBoxMulti.Name = "textBoxMulti";
            this.textBoxMulti.Size = new System.Drawing.Size(64, 18);
            this.textBoxMulti.TabIndex = 523;
            this.textBoxMulti.Text = "1";
            this.textBoxMulti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMulti.Enter += new System.EventHandler(this.textBoxMulti_Enter);
            this.textBoxMulti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMulti_KeyPress);
            this.textBoxMulti.Leave += new System.EventHandler(this.textBoxMulti_Leave);
            // 
            // formGerentePersonalidadePapeisTarefasAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 208);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMulti);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxObservacoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDescricao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerentePersonalidadePapeisTarefasAdicionar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarefa fixa";
            this.Load += new System.EventHandler(this.formGerentePersonalidadePapeisTarefasAdicionar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxObservacoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMulti;
    }
}