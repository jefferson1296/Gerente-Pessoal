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
    public partial class formGerenteTreinamentosTreinosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        bool cadastramento;

        Treino treino = new Treino();

        public formGerenteTreinamentosTreinosAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGerenteTreinamentosTreinosAdicionar(int ID)
        {
            InitializeComponent();
            id = ID;
            cadastramento = false;
        }

        private void formGerenteTreinamentosFrasesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                treino = comandos.TrazerTreino(id);
                textBoxDescricao.Text = treino.Descricao;
                buttonCadastrar.Text = "Concluir";
            }
            else
            {
                buttonCadastrar.Text = "Avançar";
            }

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

            if (descricao == string.Empty)
            {
                MessageBox.Show("É necessário informar o nome do treino para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                treino.Descricao = descricao;

                if (cadastramento)
                {
                    comandos.AdicionarTreino(treino);
                    formGerenteTreinamentosTreinosExercicios exercicios = new formGerenteTreinamentosTreinosExercicios(descricao);
                    exercicios.ShowDialog();
                }
                else
                {
                    comandos.EditarTreino(treino);
                }
            }

            Dispose();
        }
    }
}
