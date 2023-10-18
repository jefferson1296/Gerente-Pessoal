
namespace GerenciamentoPessoal
{
    partial class formTarefasDoDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTarefasDoDia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxFechar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCarregar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridTarefas = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBoxHora = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAtividade = new System.Windows.Forms.TextBox();
            this.textBoxTempo = new System.Windows.Forms.TextBox();
            this.buttonAdicionar = new System.Windows.Forms.Button();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFechar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.Snow;
            this.panelSuperior.Controls.Add(this.pictureBox1);
            this.panelSuperior.Controls.Add(this.label6);
            this.panelSuperior.Controls.Add(this.pictureBoxFechar);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(453, 24);
            this.panelSuperior.TabIndex = 15;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            this.panelSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseMove);
            this.panelSuperior.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tarefas diárias";
            // 
            // pictureBoxFechar
            // 
            this.pictureBoxFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFechar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxFechar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFechar.Image")));
            this.pictureBoxFechar.Location = new System.Drawing.Point(431, 2);
            this.pictureBoxFechar.Name = "pictureBoxFechar";
            this.pictureBoxFechar.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFechar.TabIndex = 12;
            this.pictureBoxFechar.TabStop = false;
            this.pictureBoxFechar.Click += new System.EventHandler(this.pictureBoxFechar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCarregar);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 41);
            this.panel1.TabIndex = 17;
            // 
            // buttonCarregar
            // 
            this.buttonCarregar.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonCarregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonCarregar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarregar.ForeColor = System.Drawing.Color.Black;
            this.buttonCarregar.Location = new System.Drawing.Point(347, 7);
            this.buttonCarregar.Name = "buttonCarregar";
            this.buttonCarregar.Size = new System.Drawing.Size(103, 28);
            this.buttonCarregar.TabIndex = 16;
            this.buttonCarregar.Text = "Carregar";
            this.buttonCarregar.UseVisualStyleBackColor = false;
            this.buttonCarregar.Click += new System.EventHandler(this.buttonCarregar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(132, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Escolha o dia:";
            // 
            // dataGridTarefas
            // 
            this.dataGridTarefas.AllowUserToAddRows = false;
            this.dataGridTarefas.AllowUserToDeleteRows = false;
            this.dataGridTarefas.AllowUserToResizeColumns = false;
            this.dataGridTarefas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridTarefas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTarefas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTarefas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridTarefas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTarefas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTarefas.ColumnHeadersHeight = 30;
            this.dataGridTarefas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1});
            this.dataGridTarefas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridTarefas.EnableHeadersVisualStyles = false;
            this.dataGridTarefas.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridTarefas.Location = new System.Drawing.Point(0, 65);
            this.dataGridTarefas.Name = "dataGridTarefas";
            this.dataGridTarefas.ReadOnly = true;
            this.dataGridTarefas.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridTarefas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTarefas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTarefas.Size = new System.Drawing.Size(453, 249);
            this.dataGridTarefas.TabIndex = 18;
            this.dataGridTarefas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTarefas_CellDoubleClick);
            // 
            // Column8
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gray;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column8.FillWeight = 80F;
            this.Column8.HeaderText = "Hora";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Atividade";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // maskedTextBoxHora
            // 
            this.maskedTextBoxHora.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxHora.Location = new System.Drawing.Point(90, 420);
            this.maskedTextBoxHora.Mask = "90:00";
            this.maskedTextBoxHora.Name = "maskedTextBoxHora";
            this.maskedTextBoxHora.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBoxHora.TabIndex = 19;
            this.maskedTextBoxHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maskedTextBoxHora.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "Atividade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 21;
            this.label3.Text = "Hora:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(233, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tempo (min):";
            // 
            // textBoxAtividade
            // 
            this.textBoxAtividade.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAtividade.Location = new System.Drawing.Point(112, 322);
            this.textBoxAtividade.Multiline = true;
            this.textBoxAtividade.Name = "textBoxAtividade";
            this.textBoxAtividade.Size = new System.Drawing.Size(329, 22);
            this.textBoxAtividade.TabIndex = 23;
            // 
            // textBoxTempo
            // 
            this.textBoxTempo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTempo.Location = new System.Drawing.Point(350, 420);
            this.textBoxTempo.Name = "textBoxTempo";
            this.textBoxTempo.Size = new System.Drawing.Size(91, 26);
            this.textBoxTempo.TabIndex = 24;
            this.textBoxTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTempo_KeyPress);
            // 
            // buttonAdicionar
            // 
            this.buttonAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAdicionar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdicionar.ForeColor = System.Drawing.Color.Black;
            this.buttonAdicionar.Location = new System.Drawing.Point(90, 469);
            this.buttonAdicionar.Name = "buttonAdicionar";
            this.buttonAdicionar.Size = new System.Drawing.Size(270, 32);
            this.buttonAdicionar.TabIndex = 25;
            this.buttonAdicionar.Text = "Adicionar";
            this.buttonAdicionar.UseVisualStyleBackColor = false;
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxObservacao.Location = new System.Drawing.Point(112, 357);
            this.textBoxObservacao.Multiline = true;
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.Size = new System.Drawing.Size(329, 49);
            this.textBoxObservacao.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 19);
            this.label5.TabIndex = 26;
            this.label5.Text = "Observação:";
            // 
            // formTarefasDoDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 524);
            this.Controls.Add(this.textBoxObservacao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonAdicionar);
            this.Controls.Add(this.textBoxTempo);
            this.Controls.Add(this.textBoxAtividade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBoxHora);
            this.Controls.Add(this.dataGridTarefas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formTarefasDoDia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formTarefasDoDia";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFechar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTarefas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxFechar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCarregar;
        private System.Windows.Forms.DataGridView dataGridTarefas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAtividade;
        private System.Windows.Forms.TextBox textBoxTempo;
        private System.Windows.Forms.Button buttonAdicionar;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.Label label5;
    }
}