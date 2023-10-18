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
    public partial class formGerenteFinanceiroFluxoCategoriasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;

        bool raiz;

        Categoria_Financeira categoria = new Categoria_Financeira();

        public formGerenteFinanceiroFluxoCategoriasAdicionar()
        {
            InitializeComponent();
            raiz = true;
            cadastramento = true;
        }

        public formGerenteFinanceiroFluxoCategoriasAdicionar(Categoria_Financeira Categoria, bool Cadastramento)
        {
            InitializeComponent();
            categoria = Categoria;
            cadastramento = Cadastramento;
            raiz = false;
        }


        private void formFinanceiroFluxoCategoriasAdicionar_Load(object sender, EventArgs e)
        {
            if (!raiz)
            {
                comboBoxRaiz.DataSource = comandos.PlanoDeContas();
                comboBoxRaiz.DisplayMember = "Categoria";
                comboBoxRaiz.ValueMember = "ID";
                comboBoxRaiz.SelectedValue = categoria.ID_Parente;
                comboBoxRaiz.Enabled = false;

                comboBoxTipo.Text = categoria.Tipo;
                comboBoxTipo.Enabled = false;
            }
            else
            {
                comboBoxRaiz.Enabled = false;
            }

            if (!cadastramento)
            {
                textBoxCategoria.Text = categoria.Categoria;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxCategoria.Text;
            string tipo = comboBoxTipo.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (descricao != categoria.Categoria && comandos.VerificarCategoria(descricao))
            {
                MessageBox.Show("Já existe uma categoria com essa descrição!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tipo == string.Empty)
            {
                MessageBox.Show("Informe o tipo para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                categoria.Categoria = descricao;
                categoria.Tipo = tipo;

                if (cadastramento)
                {
                    if (raiz)
                    {
                        comandos.CadastrarCategoriaRaiz(categoria);
                    }
                    else
                    {
                        categoria.ID_Parente = (int)comboBoxRaiz.SelectedValue;

                        comandos.CadastrarPlanoDeContas(categoria);
                    }


                }
                else
                {
                    comandos.EditarPlanoDeContas(categoria);
                }

                Dispose();
            }
        }
    }
}
