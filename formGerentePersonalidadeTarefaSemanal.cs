using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formGerentePersonalidadeTarefaSemanal : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        bool agendar;

        Tarefa_Semanal tarefa = new Tarefa_Semanal();
        bool cadastramento;

        public formGerentePersonalidadeTarefaSemanal()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            cadastramento = true;
        }

        public formGerentePersonalidadeTarefaSemanal(int id)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            tarefa.ID_Tarefa = id;
            cadastramento = false;
        }

        private void formTarefaSemanal_Load(object sender, EventArgs e)
        {
            AplicarTema();

            List<Papel> papeis = comandos.PreencherComboPapeis();

            comboBoxPapel.ValueMember = "ID_Papel";
            comboBoxPapel.DisplayMember = "Descricao";
            comboBoxPapel.DataSource = papeis;

            comboBoxPapel.SelectedIndex = -1;

            List<string> tipos = comandos.PreencherComboTipos();
            foreach (string x in tipos) { comboBoxTipo.Items.Add(x); }
            comboBoxTipo.SelectedIndex = -1;

            comboBoxTipo.DropDownHeight = 120;
            comboBoxPapel.DropDownHeight = 120;

            if (!cadastramento) 
            {
                tarefa = comandos.TrazerTarefaSemanal(tarefa.ID_Tarefa);

                textBoxDescricao.Text = tarefa.Descricao;
                textBoxObservacoes.Text = tarefa.Observacao;
                comboBoxTipo.Text = tarefa.Tipo;
                
                if (tarefa.ID_Papel != 0) { comboBoxPapel.SelectedValue = tarefa.ID_Papel; }

                if (tarefa.Data != Convert.ToDateTime("01/01/0001")) 
                {
                    checkBoxAgendar.Checked = true;
                    dateTimePicker1.Value = tarefa.Data;
                    textBoxInicio.Text = tarefa.Data.ToShortTimeString();
                    textBoxTempo.Text = tarefa.Tempo.ToString();
                }
            }
        }

        private void AplicarTema()
        {
            panelSuperior.BackColor = Program.tema.Cor_Principal;
            labelTitulo.ForeColor = Program.tema.Cor_Secundaria;

            buttonSalvar.BackColor = Program.tema.Cor_Principal;
            buttonSalvar.ForeColor = Program.tema.Cor_Secundaria;
            buttonCancelar.BackColor = Program.tema.Cor_Principal;
            buttonCancelar.ForeColor = Program.tema.Cor_Secundaria;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            tarefa.Descricao = textBoxDescricao.Text;
            tarefa.Observacao = textBoxObservacoes.Text;

            if (textBoxDescricao.Text == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBoxInicio.Text == "  :" && agendar)
            {
                MessageBox.Show("Informe a hora de início para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (agendar)
                {
                    tarefa.Data = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString() + " " + textBoxInicio.Text);
                    tarefa.Tempo = Convert.ToInt32(textBoxTempo.Text);
                }


                try { tarefa.ID_Papel = (int)comboBoxPapel.SelectedValue; }
                catch { tarefa.ID_Papel = 0; }

                tarefa.Tipo = comboBoxTipo.Text;

                if (cadastramento)
                {
                    comandos.RegistrarTarefaSemanal(tarefa, agendar);
                }
                else
                {
                    comandos.EditarTarefaSemanal(tarefa, agendar);
                }

                Dispose();
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void textBoxInicio_Leave(object sender, EventArgs e)
        {
            string horario = textBoxInicio.Text;
            string[] partir = horario.Split(':');
            int horas;
            int minutos;
            try
            {
                if (horario == "  :") { horas = 0; minutos = 0; }
                else { horas = Convert.ToInt32(partir[0]); minutos = Convert.ToInt32(partir[1]); }
            }
            catch
            {
                horas = 100;
                minutos = 100;
            }

            if (horario.Length != 5 && horario != "  :" || horas > 23 || minutos > 59)
            {
                MessageBox.Show("Formato de hora incorreto.\r\nInforme a hora novamente.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxInicio.Text = "00:00";
                textBoxInicio.Focus();
            }
        }

        private void textBoxTempo_Enter(object sender, EventArgs e)
        {
            textBoxTempo.ForeColor = Color.Black;
            if (textBoxTempo.Text == "0") { textBoxTempo.Text = string.Empty; }
        }

        private void textBoxTempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxTempo_Leave(object sender, EventArgs e)
        {
            if (textBoxTempo.Text == string.Empty)
            {
                textBoxTempo.Text = "0";
            }
        }

        private void checkBoxAgendar_CheckedChanged(object sender, EventArgs e)
        {
            agendar = checkBoxAgendar.Checked;

            if (agendar)
            {
                textBoxInicio.Enabled = true;
                textBoxTempo.Enabled = true;
                dateTimePicker1.Enabled = true;

                textBoxTempo.Text = "60";

                labelData.ForeColor = Color.Black;
                labelInicio.ForeColor = Color.Black;
                labelTempo.ForeColor = Color.Black;

                dateTimePicker1.Format = DateTimePickerFormat.Short;
            }
            else
            {
                textBoxInicio.Enabled = false;
                textBoxTempo.Enabled = false;
                dateTimePicker1.Enabled = false;

                textBoxInicio.Clear();
                textBoxTempo.Clear();

                labelData.ForeColor = Color.DimGray;
                labelInicio.ForeColor = Color.DimGray;
                labelTempo.ForeColor = Color.DimGray;

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "''";
            }
        }
    }
}