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
    public partial class formGerentePersonalidadeMetasRecompensasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        bool cadastramento;

        Recompensa recompensa = new Recompensa();


        public formGerentePersonalidadeMetasRecompensasAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formGerentePersonalidadeMetasRecompensasAdicionar(int ID)
        {
            InitializeComponent();
            id = ID;
            cadastramento = false;
        }

        private void formGerentePersonalidadeMetasRecompensasAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                recompensa = comandos.TrazerRecompensa(id);
                textBoxDescricao.Text = recompensa.Descricao;
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
                MessageBox.Show("É necessário informar a recompensa para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cadastramento)
                {
                    comandos.CadastrarRecompensa(descricao);
                    formGerentePersonalidadeMetasRecompensasObjetivos exercicios = new formGerentePersonalidadeMetasRecompensasObjetivos(descricao);
                    exercicios.ShowDialog();
                }
                else
                {
                    recompensa.Descricao = descricao;

                    comandos.EditarRecompensa(recompensa);
                }
            }

            Dispose();
        }
    }
}
