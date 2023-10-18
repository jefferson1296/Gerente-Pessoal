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
    public partial class formGerentePersonalidadePlanoCustos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Custo custo = new Custo();

        formGerentePersonalidadePlanoAdicionar pai = new formGerentePersonalidadePlanoAdicionar();
        bool cadastramento;
        int ordem;

        public formGerentePersonalidadePlanoCustos(formGerentePersonalidadePlanoAdicionar Pai)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = true;
        }

        public formGerentePersonalidadePlanoCustos(formGerentePersonalidadePlanoAdicionar Pai, Custo Custo)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = false;
            custo = Custo;
        }

        private void formGestaoProjetoCustos_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                textBoxDescricao.Text = custo.Descricao;
                textBoxDetalhes.Text = custo.Detalhes;
                comboBoxCategoria.Text = custo.Categoria;
                textBoxValor.Text = custo.Valor.ToString("C");
            }
            else
            {
                custo.Ordem = pai.Projeto.Custos.Count + 1;
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

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string detalhes = textBoxDetalhes.Text;
            decimal valor = comandos.ConverterDinheiroEmDecimal(textBoxValor.Text);
            string categoria = comboBoxCategoria.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (valor == 0)
            {
                MessageBox.Show("Informe a valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                custo.Descricao = descricao;
                custo.Categoria = categoria;
                custo.Detalhes = detalhes;
                custo.Valor = valor;

                if (pai.cadastramento)
                {
                    if (cadastramento)
                    {
                        pai.Projeto.Custos.Add(custo);
                    }
                    else
                    {
                        foreach (Custo Custo in pai.Projeto.Custos)
                        {
                            if (Custo.Ordem == custo.Ordem)
                            {
                                Custo.Descricao = descricao;
                                Custo.Detalhes = detalhes;
                                Custo.Categoria = categoria;
                                Custo.Valor = valor;
                            }
                        }
                    }
                }
                else
                {
                    if (cadastramento)
                    {
                        comandos.AdicionarCustoDoPlanoDeAcao(custo, pai.Projeto.ID_Projeto);
                    }
                    else
                    {
                        comandos.EditarCustoDoPlanoDeAcao(custo);
                    }

                    pai.AtualizarCustos();
                }

                Dispose();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
