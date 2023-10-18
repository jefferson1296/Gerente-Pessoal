
namespace GerenciamentoPessoal
{
    partial class formGerenteFinanceiroLancamentosTransferencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteFinanceiroLancamentosTransferencias));
            this.comboBoxOrigem = new System.Windows.Forms.ComboBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDestino = new System.Windows.Forms.ComboBox();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // comboBoxOrigem
            // 
            this.comboBoxOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrigem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxOrigem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOrigem.FormattingEnabled = true;
            this.comboBoxOrigem.Location = new System.Drawing.Point(106, 12);
            this.comboBoxOrigem.Name = "comboBoxOrigem";
            this.comboBoxOrigem.Size = new System.Drawing.Size(210, 26);
            this.comboBoxOrigem.TabIndex = 103;
            this.comboBoxOrigem.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrigem_SelectedIndexChanged);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.BackgroundImage")));
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Location = new System.Drawing.Point(169, 130);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(147, 28);
            this.buttonSalvar.TabIndex = 102;
            this.buttonSalvar.Text = "Registrar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 101;
            this.label4.Text = "Destino:";
            // 
            // comboBoxDestino
            // 
            this.comboBoxDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDestino.Enabled = false;
            this.comboBoxDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDestino.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDestino.FormattingEnabled = true;
            this.comboBoxDestino.Location = new System.Drawing.Point(106, 85);
            this.comboBoxDestino.Name = "comboBoxDestino";
            this.comboBoxDestino.Size = new System.Drawing.Size(210, 26);
            this.comboBoxDestino.TabIndex = 100;
            // 
            // textBoxValor
            // 
            this.textBoxValor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.textBoxValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxValor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.ForeColor = System.Drawing.Color.Black;
            this.textBoxValor.Location = new System.Drawing.Point(106, 50);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(210, 19);
            this.textBoxValor.TabIndex = 99;
            this.textBoxValor.Text = "R$0,00";
            this.textBoxValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxValor.Enter += new System.EventHandler(this.textBoxValor_Enter);
            this.textBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValor_KeyPress);
            this.textBoxValor.Leave += new System.EventHandler(this.textBoxValor_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 98;
            this.label2.Text = "Valor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 97;
            this.label3.Text = "Origem:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(22, 133);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(110, 20);
            this.dateTimePicker.TabIndex = 104;
            // 
            // formFinanceiroFluxoTransferencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 176);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.comboBoxOrigem);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDestino);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formFinanceiroFluxoTransferencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transferências";
            this.Load += new System.EventHandler(this.formFinanceiroFluxoTransferencias_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOrigem;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDestino;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}