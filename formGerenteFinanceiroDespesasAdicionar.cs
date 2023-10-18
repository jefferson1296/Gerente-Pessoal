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
    public partial class formGerenteFinanceiroDespesasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGerenteFinanceiroDespesas pai = new formGerenteFinanceiroDespesas();
        int id;
        Despesa Despesa = new Despesa();
        bool cadastramento;
        public formGerenteFinanceiroDespesasAdicionar()
        {
            InitializeComponent();
        }
        public formGerenteFinanceiroDespesasAdicionar(formGerenteFinanceiroDespesas Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            cadastramento = true;
        }
        public formGerenteFinanceiroDespesasAdicionar(formGerenteFinanceiroDespesas Pai, int ID)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            id = ID;
            cadastramento = false;
        }
        private void formFinanceiroDespesasAdicionar_Load(object sender, EventArgs e)
        {
            comboBoxDia.DropDownHeight = 120;

            comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(false);
            comboBoxFin.DisplayMember = "Categoria";
            comboBoxFin.ValueMember = "ID";
            comboBoxFin.DropDownHeight = 120;
            comboBoxFin.SelectedIndex = -1;

            comboBoxConta.DataSource = comandos.PreencherComboContas();
            comboBoxConta.DisplayMember = "Descricao";
            comboBoxConta.ValueMember = "ID_Conta";
            comboBoxConta.DropDownHeight = 120;
            comboBoxConta.SelectedIndex = -1;

            if (!cadastramento)
            {
                Despesa = comandos.TrazerInformacoesDaDespesa(id);

                textBoxDescricao.Text = Despesa.Descricao;
                textBoxValor.Text = Despesa.Valor.ToString("C");
                comboBoxDespesa.SelectedItem = Despesa.Tipo;
                comboBoxFin.SelectedValue = Despesa.ID_CatFin;
                comboBoxConta.SelectedValue = Despesa.ID_Conta;

                if (Despesa.Ultimo_Dia)
                {
                    comboBoxDia.SelectedIndex = -1;
                    comboBoxDia.Enabled = false;
                    radioButtonDia.Checked = false;
                    radioButtonUltimo.Checked = true;

                    if (Despesa.Depois_do_Dia) { radioButtonDepois.Checked = true; }
                    else if (Despesa.Antes_do_Dia) { radioButtonAntes.Checked = true; }
                    else if (Despesa.Mesmo_Dia) { radioButtonMesmo.Checked = true; }
                }
                else
                {
                    comboBoxDia.SelectedItem = Despesa.Dia.ToString();
                    radioButtonDia.Checked = true;
                    radioButtonUltimo.Checked = false;

                    if (Despesa.Dia_Util)
                    {
                        checkBoxUtil.Checked = true;
                    }
                    else
                    {
                        checkBoxUtil.Checked = false;
                        if (Despesa.Depois_do_Dia) { radioButtonDepois.Checked = true; }
                        else if (Despesa.Antes_do_Dia) { radioButtonAntes.Checked = true; }
                        else if (Despesa.Mesmo_Dia) { radioButtonMesmo.Checked = true; }
                    }
                }
            }
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
            string descricao = textBoxDescricao.Text;
            string tipo = comboBoxDespesa.Text;
            string catfin = comboBoxFin.Text;            
            string conta = comboBoxConta.Text;            
            bool dia_util = false;
            bool ultimo_dia = false;

            bool mesmo_dia = radioButtonMesmo.Checked;
            bool antes_do_dia = radioButtonAntes.Checked;
            bool depois_do_dia = radioButtonDepois.Checked;

            decimal valor = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text);
            int dia = 0;            

            if (radioButtonDia.Checked)
            {
                try { dia = Convert.ToInt32(comboBoxDia.Text); } catch { dia = 0; }
                dia_util = checkBoxUtil.Checked;
            }
            else
            {
                ultimo_dia = true;
            }
          
            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tipo == string.Empty)
            {
                MessageBox.Show("Informe o tipo de despesa para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (conta == string.Empty)
            {
                MessageBox.Show("Informe a conta para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (catfin == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (valor == 0)
            {
                MessageBox.Show("Informe o valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dia == 0 && radioButtonDia.Checked)
            {
                MessageBox.Show("Informe o dia para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Despesa despesa = new Despesa()
                {
                    ID_Despesa = id,
                    Descricao = descricao,
                    Tipo = tipo,
                    ID_CatFin = (int)comboBoxFin.SelectedValue,
                    ID_Conta = (int)comboBoxConta.SelectedValue,
                    Valor = valor,
                    Dia = dia,
                    Data = DateTime.Now,
                    Dia_Util = dia_util,
                    Ultimo_Dia = ultimo_dia,
                    Mesmo_Dia = mesmo_dia,
                    Antes_do_Dia = antes_do_dia,
                    Depois_do_Dia = depois_do_dia
                };

                if (cadastramento)
                {
                    comandos.RegistrarNovaDespesa(despesa);
                }
                else
                {
                    comandos.EditarDespesa(despesa);
                }

                pai.alteracao = true;
                Dispose();
            }

        }


        private void radioButtonDia_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDia.Checked)
            {
                checkBoxUtil.Enabled = true;
                comboBoxDia.Enabled = true;
                try { comboBoxDia.SelectedItem = Despesa.Dia.ToString(); } 
                catch { comboBoxDia.SelectedIndex = 0; }
            }
            else
            {
                comboBoxDia.SelectedIndex = -1;
                comboBoxDia.Enabled = false;
                checkBoxUtil.Checked = false;
                checkBoxUtil.Enabled = false;
            }
        }

        private void checkBoxUtil_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUtil.Checked)
            {
                radioButtonAntes.Checked = false;
                radioButtonDepois.Checked = false;
                radioButtonMesmo.Checked = false;
                radioButtonAntes.Enabled = false;
                radioButtonDepois.Enabled = false;
                radioButtonMesmo.Enabled = false;
            }
            else
            {
                radioButtonAntes.Checked = false;
                radioButtonDepois.Checked = true;
                radioButtonMesmo.Checked = false;
                radioButtonAntes.Enabled = true;
                radioButtonDepois.Enabled = true;
                radioButtonMesmo.Enabled = true;
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
        #region Formatação
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
e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
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
        #endregion
    }
}
