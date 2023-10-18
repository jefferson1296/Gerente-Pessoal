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
    public partial class formGerentePersonalidadeMetasResultadosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        int id;
        bool cadastramento;
        string objetivo;

        Resultado resultado = new Resultado();

        public formGerentePersonalidadeMetasResultadosAdicionar(int ID, bool Cadastramento, string Objetivo)
        {
            InitializeComponent();
            id = ID;
            cadastramento = Cadastramento;
            objetivo = Objetivo;
        }


        private void formGerenteTreinamentosFrasesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                resultado = comandos.TrazerResultado(id);
                textBoxDescricao.Text = resultado.Descricao;

                if (resultado.Inicial % 1 == 0)
                {
                    textBoxInicial.Text = resultado.Inicial.ToString("N0");
                }
                else
                {
                    textBoxInicial.Text = resultado.Inicial.ToString("F");
                }

                if (resultado.Meta % 1 == 0)
                {
                    textBoxMeta.Text = resultado.Meta.ToString("N0");
                }
                else
                {
                    textBoxMeta.Text = resultado.Meta.ToString("F");
                }

                if (resultado.Un_Medida != string.Empty)
                {
                    textBoxUn.Text = resultado.Un_Medida;
                }

                textBoxPeriodicidade.Text = resultado.Periodicidade.ToString();
                comboBoxAgressividade.Text = resultado.Agressividade;

            }

            labelObjetivo.Text = "Objetivo: " + objetivo;
            textBoxDescricao.Focus();
            textBoxDescricao.SelectionStart = textBoxDescricao.Text.Length;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;

            decimal inicial = Convert.ToDecimal(textBoxInicial.Text);
            decimal meta = Convert.ToDecimal(textBoxMeta.Text);
            string un_medida;

            if (textBoxUn.Text == "Ex: dias, R$")
            { un_medida = string.Empty; }
            else { un_medida = textBoxUn.Text; } 

            int periodicidade = Convert.ToInt32(textBoxPeriodicidade.Text);
            string agressividade = comboBoxAgressividade.Text;



            if (descricao == string.Empty)
            {
                MessageBox.Show("É necessário informar a descrição do resultado para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                resultado.Descricao = descricao;
                resultado.Inicial = inicial;
                resultado.Meta = meta;
                resultado.Un_Medida = un_medida;
                resultado.Periodicidade = periodicidade;
                resultado.Agressividade = agressividade;

                if (cadastramento)
                {
                    resultado.ID_Objetivo = id;
                    comandos.CadastrarResultado(resultado);
                }
                else
                {
                    resultado.ID_Resultado = id;
                    comandos.EditarResultado(resultado);
                }
            }

            Dispose();
        }

        private void textBoxPeriodicidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxPeriodicidade_Leave(object sender, EventArgs e)
        {
            if (textBoxPeriodicidade.Text == string.Empty)
            {
                textBoxPeriodicidade.Text = "7";
            }
        }

        private void textBoxInicial_Enter(object sender, EventArgs e)
        {
            if (textBoxInicial.Text == "0")
            {
                textBoxInicial.Text = string.Empty;
            }
        }

        private void textBoxInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
(e.KeyChar != ',' && e.KeyChar != '.' &&
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxInicial.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void textBoxInicial_Leave(object sender, EventArgs e)
        {
            if (textBoxInicial.Text != string.Empty)
            {
                decimal valor = Convert.ToDecimal(textBoxInicial.Text);

                if (valor % 1 == 0) { textBoxInicial.Text = valor.ToString("N0"); }
                else { textBoxInicial.Text = valor.ToString("F"); }

                if (textBoxInicial.Text == "R$0,00")
                {
                    textBoxInicial.Text = string.Empty;
                }
            }
            else
            {
                textBoxInicial.Text = "0";
            }
        }

        private void textBoxMeta_Enter(object sender, EventArgs e)
        {
            if (textBoxMeta.Text == "0")
            {
                textBoxMeta.Text = string.Empty;
            }
        }

        private void textBoxMeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
(e.KeyChar != ',' && e.KeyChar != '.' &&
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxMeta.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void textBoxMeta_Leave(object sender, EventArgs e)
        {
            if (textBoxMeta.Text != string.Empty)
            {
                decimal valor = Convert.ToDecimal(textBoxMeta.Text);

                if (valor % 1 == 0) { textBoxMeta.Text = valor.ToString("N0"); }
                else { textBoxMeta.Text = valor.ToString("F"); }

                if (textBoxMeta.Text == "R$0,00")
                {
                    textBoxMeta.Text = string.Empty;
                }
            }
            else
            {
                textBoxMeta.Text = "0";
            }
        }

        private void textBoxUn_Enter(object sender, EventArgs e)
        {
            if (textBoxUn.Text == "Ex: dias, R$")
            {
                textBoxUn.Text = string.Empty;
                textBoxUn.ForeColor = Color.Black;
            }
        }

        private void textBoxUn_Leave(object sender, EventArgs e)
        {
            if (textBoxUn.Text == string.Empty)
            {
                textBoxUn.Text = "Ex: dias, R$";
                textBoxUn.ForeColor = Color.DarkGray;
            }
        }
    }
}
