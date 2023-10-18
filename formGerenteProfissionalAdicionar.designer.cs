
namespace GerenciamentoPessoal
{
    partial class formGerenteProfissionalAdicionar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGerenteProfissionalAdicionar));
            this.buttonCadastrar = new System.Windows.Forms.Button();
            this.textBoxDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDetalhes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTempo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.checkBoxRotina = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxIntervalo = new System.Windows.Forms.TextBox();
            this.labelIntervalo = new System.Windows.Forms.Label();
            this.comboBoxRotina = new System.Windows.Forms.ComboBox();
            this.labelRotina = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonUltimo = new System.Windows.Forms.RadioButton();
            this.comboBoxDia = new System.Windows.Forms.ComboBox();
            this.radioButtonDia = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCadastrar
            // 
            this.buttonCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCadastrar.BackColor = System.Drawing.Color.Black;
            this.buttonCadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCadastrar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCadastrar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCadastrar.ForeColor = System.Drawing.Color.White;
            this.buttonCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCadastrar.Image")));
            this.buttonCadastrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCadastrar.Location = new System.Drawing.Point(46, 230);
            this.buttonCadastrar.Name = "buttonCadastrar";
            this.buttonCadastrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCadastrar.Size = new System.Drawing.Size(195, 32);
            this.buttonCadastrar.TabIndex = 5;
            this.buttonCadastrar.Text = "Salvar";
            this.buttonCadastrar.UseVisualStyleBackColor = false;
            this.buttonCadastrar.Click += new System.EventHandler(this.buttonCadastrar_Click);
            // 
            // textBoxDescricao
            // 
            this.textBoxDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescricao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricao.Location = new System.Drawing.Point(88, 38);
            this.textBoxDescricao.Name = "textBoxDescricao";
            this.textBoxDescricao.Size = new System.Drawing.Size(389, 19);
            this.textBoxDescricao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "Descrição:";
            // 
            // textBoxDetalhes
            // 
            this.textBoxDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDetalhes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDetalhes.Location = new System.Drawing.Point(12, 85);
            this.textBoxDetalhes.Multiline = true;
            this.textBoxDetalhes.Name = "textBoxDetalhes";
            this.textBoxDetalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDetalhes.Size = new System.Drawing.Size(465, 101);
            this.textBoxDetalhes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Detalhes";
            // 
            // textBoxTempo
            // 
            this.textBoxTempo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTempo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTempo.Location = new System.Drawing.Point(105, 201);
            this.textBoxTempo.Name = "textBoxTempo";
            this.textBoxTempo.Size = new System.Drawing.Size(65, 19);
            this.textBoxTempo.TabIndex = 3;
            this.textBoxTempo.Text = "0";
            this.textBoxTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTempo.Enter += new System.EventHandler(this.textBoxTempo_Enter);
            this.textBoxTempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTempo_KeyPress);
            this.textBoxTempo.Leave += new System.EventHandler(this.textBoxTempo_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Tempo (min):";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(190, 203);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(41, 16);
            this.labelData.TabIndex = 63;
            this.labelData.Text = "Data:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Location = new System.Drawing.Point(237, 201);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(240, 20);
            this.dateTimePicker.TabIndex = 4;
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelar.BackColor = System.Drawing.Color.Black;
            this.buttonCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancelar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(247, 230);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(195, 32);
            this.buttonCancelar.TabIndex = 65;
            this.buttonCancelar.TabStop = false;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // checkBoxRotina
            // 
            this.checkBoxRotina.AutoSize = true;
            this.checkBoxRotina.Location = new System.Drawing.Point(9, 4);
            this.checkBoxRotina.Name = "checkBoxRotina";
            this.checkBoxRotina.Size = new System.Drawing.Size(57, 17);
            this.checkBoxRotina.TabIndex = 66;
            this.checkBoxRotina.Text = "Rotina";
            this.checkBoxRotina.UseVisualStyleBackColor = true;
            this.checkBoxRotina.CheckedChanged += new System.EventHandler(this.checkBoxRotina_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.checkBoxRotina);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 25);
            this.panel1.TabIndex = 67;
            // 
            // textBoxIntervalo
            // 
            this.textBoxIntervalo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxIntervalo.Enabled = false;
            this.textBoxIntervalo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIntervalo.Location = new System.Drawing.Point(404, 237);
            this.textBoxIntervalo.Name = "textBoxIntervalo";
            this.textBoxIntervalo.Size = new System.Drawing.Size(73, 19);
            this.textBoxIntervalo.TabIndex = 68;
            this.textBoxIntervalo.Text = "0";
            this.textBoxIntervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIntervalo.Visible = false;
            this.textBoxIntervalo.Enter += new System.EventHandler(this.textBoxIntervalo_Enter);
            this.textBoxIntervalo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntervalo_KeyPress);
            this.textBoxIntervalo.Leave += new System.EventHandler(this.textBoxIntervalo_Leave);
            // 
            // labelIntervalo
            // 
            this.labelIntervalo.AutoSize = true;
            this.labelIntervalo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntervalo.Location = new System.Drawing.Point(292, 239);
            this.labelIntervalo.Name = "labelIntervalo";
            this.labelIntervalo.Size = new System.Drawing.Size(106, 16);
            this.labelIntervalo.TabIndex = 69;
            this.labelIntervalo.Text = "Intervalo (dias):";
            this.labelIntervalo.Visible = false;
            // 
            // comboBoxRotina
            // 
            this.comboBoxRotina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRotina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRotina.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRotina.FormattingEnabled = true;
            this.comboBoxRotina.Items.AddRange(new object[] {
            "Diariamente",
            "Semanalmente",
            "Mensal",
            "Definir período"});
            this.comboBoxRotina.Location = new System.Drawing.Point(79, 236);
            this.comboBoxRotina.Name = "comboBoxRotina";
            this.comboBoxRotina.Size = new System.Drawing.Size(191, 24);
            this.comboBoxRotina.TabIndex = 70;
            this.comboBoxRotina.Visible = false;
            this.comboBoxRotina.SelectedIndexChanged += new System.EventHandler(this.comboBoxRotina_SelectedIndexChanged);
            // 
            // labelRotina
            // 
            this.labelRotina.AutoSize = true;
            this.labelRotina.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRotina.Location = new System.Drawing.Point(9, 239);
            this.labelRotina.Name = "labelRotina";
            this.labelRotina.Size = new System.Drawing.Size(53, 16);
            this.labelRotina.TabIndex = 71;
            this.labelRotina.Text = "Rotina:";
            this.labelRotina.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUltimo);
            this.groupBox1.Controls.Add(this.comboBoxDia);
            this.groupBox1.Controls.Add(this.radioButtonDia);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 72);
            this.groupBox1.TabIndex = 109;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            this.groupBox1.Visible = false;
            // 
            // radioButtonUltimo
            // 
            this.radioButtonUltimo.AutoSize = true;
            this.radioButtonUltimo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUltimo.Location = new System.Drawing.Point(241, 33);
            this.radioButtonUltimo.Name = "radioButtonUltimo";
            this.radioButtonUltimo.Size = new System.Drawing.Size(152, 22);
            this.radioButtonUltimo.TabIndex = 106;
            this.radioButtonUltimo.Text = "Último dia do mês";
            this.radioButtonUltimo.UseVisualStyleBackColor = true;
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
            // formGerenteProfissionalAdicionar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 283);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.textBoxTempo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDetalhes);
            this.Controls.Add(this.textBoxDescricao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCadastrar);
            this.Controls.Add(this.labelRotina);
            this.Controls.Add(this.comboBoxRotina);
            this.Controls.Add(this.textBoxIntervalo);
            this.Controls.Add(this.labelIntervalo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formGerenteProfissionalAdicionar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar";
            this.Load += new System.EventHandler(this.formGestaoAfazeresAdicionar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCadastrar;
        private System.Windows.Forms.TextBox textBoxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDetalhes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTempo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.CheckBox checkBoxRotina;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxIntervalo;
        private System.Windows.Forms.Label labelIntervalo;
        private System.Windows.Forms.ComboBox comboBoxRotina;
        private System.Windows.Forms.Label labelRotina;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUltimo;
        private System.Windows.Forms.ComboBox comboBoxDia;
        private System.Windows.Forms.RadioButton radioButtonDia;
    }
}