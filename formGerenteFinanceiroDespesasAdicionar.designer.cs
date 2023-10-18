
namespace GerenciamentoPessoal
{
    partial class formGerenteFinanceiroDespesasAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteFinanceiroDespesasAdicionar));
            this.comboBoxDespesa = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxValor = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDia = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonUltimo = new System.Windows.Forms.RadioButton();
            this.checkBoxUtil = new System.Windows.Forms.CheckBox();
            this.radioButtonDia = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonDepois = new System.Windows.Forms.RadioButton();
            this.radioButtonAntes = new System.Windows.Forms.RadioButton();
            this.radioButtonMesmo = new System.Windows.Forms.RadioButton();
            this.comboBoxConta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFin = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDespesa
            // 
            this.comboBoxDespesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxDespesa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDespesa.FormattingEnabled = true;
            this.comboBoxDespesa.Items.AddRange(new object[] {
            "Despesa Fixa",
            "Despesa Variável"});
            this.comboBoxDespesa.Location = new System.Drawing.Point(91, 54);
            this.comboBoxDespesa.Name = "comboBoxDespesa";
            this.comboBoxDespesa.Size = new System.Drawing.Size(236, 26);
            this.comboBoxDespesa.TabIndex = 102;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 19);
            this.label7.TabIndex = 101;
            this.label7.Text = "Despesa:";
            // 
            // textBoxValor
            // 
            this.textBoxValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValor.ForeColor = System.Drawing.Color.Black;
            this.textBoxValor.Location = new System.Drawing.Point(406, 53);
            this.textBoxValor.Name = "textBoxValor";
            this.textBoxValor.Size = new System.Drawing.Size(116, 26);
            this.textBoxValor.TabIndex = 95;
            this.textBoxValor.Text = "R$0,00";
            this.textBoxValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxValor.Enter += new System.EventHandler(this.textBoxValor_Enter);
            this.textBoxValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValor_KeyPress);
            this.textBoxValor.Leave += new System.EventHandler(this.textBoxValor_Leave);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.BackColor = System.Drawing.Color.Red;
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(280, 298);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(159, 32);
            this.buttonCancelar.TabIndex = 94;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalvar.BackColor = System.Drawing.Color.Red;
            this.buttonSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalvar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSalvar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSalvar.ForeColor = System.Drawing.Color.White;
            this.buttonSalvar.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalvar.Image")));
            this.buttonSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSalvar.Location = new System.Drawing.Point(94, 298);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSalvar.Size = new System.Drawing.Size(159, 32);
            this.buttonSalvar.TabIndex = 93;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = false;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(109, 17);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(413, 26);
            this.textBoxDescricao.TabIndex = 92;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(346, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 96;
            this.label2.Text = "Valor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 98;
            this.label4.Text = "Categoria:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 103;
            this.label1.Text = "Descrição:";
            // 
            // comboBoxDia
            // 
            this.comboBoxDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxDia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDia.FormattingEnabled = true;
            this.comboBoxDia.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBoxDia.Location = new System.Drawing.Point(79, 31);
            this.comboBoxDia.Name = "comboBoxDia";
            this.comboBoxDia.Size = new System.Drawing.Size(68, 26);
            this.comboBoxDia.TabIndex = 105;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.radioButtonUltimo);
            this.groupBox1.Controls.Add(this.comboBoxDia);
            this.groupBox1.Controls.Add(this.checkBoxUtil);
            this.groupBox1.Controls.Add(this.radioButtonDia);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 72);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // radioButtonUltimo
            // 
            this.radioButtonUltimo.AutoSize = true;
            this.radioButtonUltimo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUltimo.Location = new System.Drawing.Point(306, 33);
            this.radioButtonUltimo.Name = "radioButtonUltimo";
            this.radioButtonUltimo.Size = new System.Drawing.Size(152, 22);
            this.radioButtonUltimo.TabIndex = 106;
            this.radioButtonUltimo.Text = "Último dia do mês";
            this.radioButtonUltimo.UseVisualStyleBackColor = true;
            // 
            // checkBoxUtil
            // 
            this.checkBoxUtil.AutoSize = true;
            this.checkBoxUtil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUtil.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUtil.Location = new System.Drawing.Point(153, 35);
            this.checkBoxUtil.Name = "checkBoxUtil";
            this.checkBoxUtil.Size = new System.Drawing.Size(61, 20);
            this.checkBoxUtil.TabIndex = 0;
            this.checkBoxUtil.Text = "Dia útil";
            this.checkBoxUtil.UseVisualStyleBackColor = true;
            this.checkBoxUtil.CheckedChanged += new System.EventHandler(this.checkBoxUtil_CheckedChanged);
            // 
            // radioButtonDia
            // 
            this.radioButtonDia.AutoSize = true;
            this.radioButtonDia.Checked = true;
            this.radioButtonDia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDia.Location = new System.Drawing.Point(28, 33);
            this.radioButtonDia.Name = "radioButtonDia";
            this.radioButtonDia.Size = new System.Drawing.Size(55, 22);
            this.radioButtonDia.TabIndex = 1;
            this.radioButtonDia.TabStop = true;
            this.radioButtonDia.Text = "Dia:";
            this.radioButtonDia.UseVisualStyleBackColor = true;
            this.radioButtonDia.CheckedChanged += new System.EventHandler(this.radioButtonDia_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.radioButtonDepois);
            this.groupBox2.Controls.Add(this.radioButtonAntes);
            this.groupBox2.Controls.Add(this.radioButtonMesmo);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 72);
            this.groupBox2.TabIndex = 108;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Se a data da despesa for um final de semana ou feriado, o pagamento deve ser real" +
    "izado no mesmo dia?";
            // 
            // radioButtonDepois
            // 
            this.radioButtonDepois.AutoSize = true;
            this.radioButtonDepois.Checked = true;
            this.radioButtonDepois.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDepois.Location = new System.Drawing.Point(407, 35);
            this.radioButtonDepois.Name = "radioButtonDepois";
            this.radioButtonDepois.Size = new System.Drawing.Size(77, 22);
            this.radioButtonDepois.TabIndex = 109;
            this.radioButtonDepois.TabStop = true;
            this.radioButtonDepois.Text = "Depois";
            this.radioButtonDepois.UseVisualStyleBackColor = true;
            // 
            // radioButtonAntes
            // 
            this.radioButtonAntes.AutoSize = true;
            this.radioButtonAntes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonAntes.Location = new System.Drawing.Point(233, 35);
            this.radioButtonAntes.Name = "radioButtonAntes";
            this.radioButtonAntes.Size = new System.Drawing.Size(66, 22);
            this.radioButtonAntes.TabIndex = 108;
            this.radioButtonAntes.Text = "Antes";
            this.radioButtonAntes.UseVisualStyleBackColor = true;
            // 
            // radioButtonMesmo
            // 
            this.radioButtonMesmo.AutoSize = true;
            this.radioButtonMesmo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMesmo.Location = new System.Drawing.Point(18, 35);
            this.radioButtonMesmo.Name = "radioButtonMesmo";
            this.radioButtonMesmo.Size = new System.Drawing.Size(128, 22);
            this.radioButtonMesmo.TabIndex = 107;
            this.radioButtonMesmo.Text = "No mesmo dia";
            this.radioButtonMesmo.UseVisualStyleBackColor = true;
            // 
            // comboBoxConta
            // 
            this.comboBoxConta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxConta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxConta.FormattingEnabled = true;
            this.comboBoxConta.Location = new System.Drawing.Point(371, 98);
            this.comboBoxConta.Name = "comboBoxConta";
            this.comboBoxConta.Size = new System.Drawing.Size(151, 23);
            this.comboBoxConta.TabIndex = 109;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 110;
            this.label3.Text = "Conta:";
            // 
            // comboBoxFin
            // 
            this.comboBoxFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxFin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFin.FormattingEnabled = true;
            this.comboBoxFin.Location = new System.Drawing.Point(102, 96);
            this.comboBoxFin.Name = "comboBoxFin";
            this.comboBoxFin.Size = new System.Drawing.Size(196, 23);
            this.comboBoxFin.TabIndex = 111;
            // 
            // formGerenteFinanceiroDespesasAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 350);
            this.Controls.Add(this.comboBoxFin);
            this.Controls.Add(this.comboBoxConta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDespesa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxValor);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerenteFinanceiroDespesasAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar despesa";
            this.Load += new System.EventHandler(this.formFinanceiroDespesasAdicionar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxDespesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxValor;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUltimo;
        private System.Windows.Forms.CheckBox checkBoxUtil;
        private System.Windows.Forms.RadioButton radioButtonDia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonDepois;
        private System.Windows.Forms.RadioButton radioButtonAntes;
        private System.Windows.Forms.RadioButton radioButtonMesmo;
        private System.Windows.Forms.ComboBox comboBoxConta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxFin;
    }
}