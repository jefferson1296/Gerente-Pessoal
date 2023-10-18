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
    public partial class formGerenteProfissionalAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGerenteProfissional pai = new formGerenteProfissional();

        Rotina afazer = new Rotina();
        bool cadastramento;
        DateTime data = new DateTime();

        bool rotina;

        public formGerenteProfissionalAdicionar()
        {
            InitializeComponent();
        }

        public formGerenteProfissionalAdicionar(DateTime Data)
        {
            InitializeComponent();
            cadastramento = true;
            afazer.Data = Data;
        }


        public formGerenteProfissionalAdicionar(int ID_Afazer, formGerenteProfissional Pai, bool Rotina)
        {
            InitializeComponent();
            
            rotina = Rotina;

            if (rotina) { afazer.ID_Rotina = ID_Afazer; }
            else { afazer.ID_Afazer = ID_Afazer; }
            cadastramento = false;
            pai = Pai;
        }

        private void formGestaoAfazeresAdicionar_Load(object sender, EventArgs e)
        {
            comboBoxDia.DropDownHeight = 200;

            AplicarTema();

            if (!cadastramento)
            {
                if (rotina)
                {
                    labelData.Visible = false;
                    dateTimePicker.Visible = false;
                    checkBoxRotina.Checked = true;
                    checkBoxRotina.Enabled = false;

                    comandos.TrazerInformacoesDaRotina(afazer);

                    if (afazer.Mensal) 
                    { 
                        comboBoxRotina.Text = "Mensal";

                        if (afazer.Ultimo_Dia)
                        {
                            radioButtonUltimo.Checked = true;
                        }
                        else
                        {
                            radioButtonDia.Checked = true;
                            comboBoxDia.Text = afazer.Dia.ToString();
                        }

                    }
                    else if (afazer.Intervalo == 7) { comboBoxRotina.Text = "Semanalmente"; }
                    else if (afazer.Intervalo == 1) { comboBoxRotina.Text = "Diariamente"; }
                    else { comboBoxRotina.Text = "Definir período"; }

                }
                else
                {
                    comandos.TrazerInformacoesDoAfazer(afazer);
                }               

                textBoxDescricao.Text = afazer.Descricao;
                textBoxDetalhes.Text = afazer.Detalhes;
                textBoxTempo.Text = afazer.Minutos.ToString();
                data = afazer.Data;
                dateTimePicker.Value = data;

                textBoxDescricao.SelectionStart = textBoxDescricao.Text.Length;
            }
            else
            {
                if (afazer.ID_Etapa != 0)
                {
                    textBoxDescricao.Text = afazer.Descricao;
                    textBoxDetalhes.Text = afazer.Detalhes;
                }
                else
                {
                    dateTimePicker.Value = afazer.Data;
                }
            }
        }

        private void AplicarTema()
        {
            buttonCadastrar.BackColor = Program.tema.Cor_Principal;
            buttonCadastrar.ForeColor = Program.tema.Cor_Secundaria;

            buttonCancelar.BackColor = Program.tema.Cor_Principal;
            buttonCancelar.ForeColor = Program.tema.Cor_Secundaria;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string detalhes = textBoxDetalhes.Text;
            int tempo = Convert.ToInt32(textBoxTempo.Text);
            DateTime data = dateTimePicker.Value.Date;
            bool rotina = checkBoxRotina.Checked;

            int intervalo = Convert.ToInt32(textBoxIntervalo.Text);

            bool ultimo_dia = false;

            int dia = 0;

            //Rotina

            if (rotina)
            {
                if (comboBoxRotina.Text == "Mensal")
                    afazer.Mensal = true;
                else
                    afazer.Mensal = false;

                if (afazer.Mensal)
                {
                    if (radioButtonDia.Checked)
                    {
                        try { dia = Convert.ToInt32(comboBoxDia.Text); } catch { dia = 0; }
                    }
                    else
                    {
                        ultimo_dia = true;
                    }
                }
                else
                {
                    afazer.Intervalo = Convert.ToInt32(textBoxIntervalo.Text);
                }
            }





            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (afazer.Mensal && dia == 0 && radioButtonDia.Checked)
            {
                MessageBox.Show("Informe o dia para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                afazer.Descricao = descricao;
                afazer.Detalhes = detalhes;
                afazer.Minutos = tempo;
                afazer.Data = data;
                afazer.Rotina = rotina;

                if (afazer.Rotina)
                {
                    if (afazer.Mensal)
                    {
                        afazer.Dia = dia;
                        afazer.Ultimo_Dia = ultimo_dia;
                        afazer.Intervalo = 0;
                    }
                    else
                    {
                        afazer.Intervalo = intervalo;
                        afazer.Dia = 0;
                        afazer.Ultimo_Dia = false;
                    }
                }


                if (cadastramento)
                {
                    comandos.AdicionarAfazer(afazer);

                    MessageBox.Show("Lista de afazeres atualizada.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (rotina)
                    {
                        comandos.EditarRotina(afazer);
                    }
                    else
                    {
                        comandos.EditarAfazer(afazer);

                        if (data.Date != this.data.Date)
                        {
                            int ordem = afazer.Ordem;

                            foreach (Afazer afazer in pai.afazeres)
                            {
                                if (afazer.Ordem > this.afazer.Ordem)
                                {
                                    comandos.AlterarOrdemDoAfazer(afazer.ID_Afazer, ordem);
                                    ordem++;
                                }
                            }
                        }
                    }
                }

                Dispose();
            }
        }

        private void textBoxTempo_Enter(object sender, EventArgs e)
        {
            if (textBoxTempo.Text == "0")
                textBoxTempo.Clear();
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
                textBoxTempo.Text = "0";
        }

        private void checkBoxRotina_CheckedChanged(object sender, EventArgs e)
        {
            bool rotina = checkBoxRotina.Checked;
            comboBoxRotina.Text = "Diariamente";

            if (rotina) 
            {
                Height = 362;
                labelRotina.Visible = true;
                labelIntervalo.Visible = true;
                textBoxIntervalo.Visible = true;
                comboBoxRotina.Visible = true;
            }
            if (!rotina) 
            {

                Height = 322;
                labelRotina.Visible = false;
                labelIntervalo.Visible = false;
                textBoxIntervalo.Visible = false;
                comboBoxRotina.Visible = false;
            }
        }

        private void textBoxIntervalo_Enter(object sender, EventArgs e)
        {
            if (textBoxIntervalo.Text == "1")
                textBoxIntervalo.Clear();
        }

        private void textBoxIntervalo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxIntervalo_Leave(object sender, EventArgs e)
        {
            if (textBoxIntervalo.Text == string.Empty || textBoxIntervalo.Text == "0")
                textBoxIntervalo.Text = "1";
        }

        private void comboBoxRotina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRotina.Text == "Diariamente")
            {
                Height = 362;
                textBoxIntervalo.Enabled = false;
                textBoxIntervalo.Visible = true;
                labelIntervalo.Visible = true;
                textBoxIntervalo.Text = "1";
                groupBox1.Visible = false;

            }
            else if (comboBoxRotina.Text == "Semanalmente")
            {
                Height = 362;
                textBoxIntervalo.Enabled = false;
                textBoxIntervalo.Visible = true;
                labelIntervalo.Visible = true;
                textBoxIntervalo.Text = "7";
                groupBox1.Visible = false;
            }
            else if (comboBoxRotina.Text == "Mensal")
            {
                Height = 455;
                textBoxIntervalo.Visible = false;
                labelIntervalo.Visible = false;
                groupBox1.Visible = true;
            }
            else if (comboBoxRotina.Text == "Definir período")
            {
                Height = 362;
                textBoxIntervalo.Enabled = true;
                textBoxIntervalo.Visible = true;
                labelIntervalo.Visible = true;
                textBoxIntervalo.Text = "1";
                groupBox1.Visible = false;
            }
        }

        private void radioButtonDia_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDia.Checked)
            {
                comboBoxDia.Enabled = true;
                try { comboBoxDia.SelectedItem = afazer.Dia.ToString(); }
                catch { comboBoxDia.SelectedIndex = 0; }
            }
            else
            {
                comboBoxDia.SelectedIndex = -1;
                comboBoxDia.Enabled = false;
            }
        }
    }
}
