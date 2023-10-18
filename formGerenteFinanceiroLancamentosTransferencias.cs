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
    public partial class formGerenteFinanceiroLancamentosTransferencias : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Conta> contas = new List<Conta>();

        bool alterar_combo;

        public formGerenteFinanceiroLancamentosTransferencias()
        {
            InitializeComponent();
        }

        private void formFinanceiroFluxoTransferencias_Load(object sender, EventArgs e)
        {
            contas = comandos.ListaDeContas();

            comboBoxOrigem.DataSource = contas;
            comboBoxOrigem.ValueMember = "ID_Conta";
            comboBoxOrigem.DisplayMember = "Descricao";
            comboBoxOrigem.DropDownHeight = 120;
            comboBoxOrigem.SelectedIndex = -1;

            alterar_combo = true;

            comboBoxDestino.DropDownHeight = 120;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string origem = comboBoxOrigem.Text;
            string destino = comboBoxDestino.Text;
            decimal valor = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text);

            DateTime data = dateTimePicker.Value;

            if (origem == string.Empty)
            {
                MessageBox.Show("Informe a conta de origem para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (destino == string.Empty)
            {
                MessageBox.Show("Informe a conta de destino para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (valor == 0)
            {
                MessageBox.Show("Informe o valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {                
                Transferencia Transferencia = new Transferencia() 
                {
                    ID_Origem = (int)comboBoxOrigem.SelectedValue, 
                    ID_Destino = (int)comboBoxDestino.SelectedValue,
                    Valor = valor,
                    Data = data 
                };

                comandos.RegistrarTransferenciaEntreContas(Transferencia);

                Dispose();
            }
        }

        private void textBoxValor_Enter(object sender, EventArgs e)
        {
            if (textBoxValor.Text == "R$0,00")
            {
                textBoxValor.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxValor.Text.Split('$');
                textBoxValor.Text = partir[1];
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
            (e.KeyChar != ',' && e.KeyChar != '.' &&
            e.KeyChar != (char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxValor.Text.Contains(','))
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

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = "R$0,00";
            }
            else
            {
                decimal valor = Convert.ToDecimal(textBoxValor.Text);
                textBoxValor.Text = valor.ToString("C");
            }
        }

        private void comboBoxOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (alterar_combo)
            {
                if (comboBoxOrigem.Text != string.Empty)
                {
                    comboBoxDestino.DataSource = null;
                    List<Conta> contas = comandos.ListaDeContas();
                    contas.RemoveAll(x => x.Descricao == comboBoxOrigem.Text);

                    comboBoxDestino.DataSource = contas;
                    comboBoxDestino.ValueMember = "ID_Conta";
                    comboBoxDestino.DisplayMember = "Descricao";

                    comboBoxDestino.Enabled = true;

                    comboBoxDestino.SelectedIndex = -1;

                    comboBoxOrigem.Enabled = false;
                }
                else
                {
                    comboBoxOrigem.Enabled = true;
                    comboBoxDestino.Enabled = false;
                }
            }
        }
    }
}
