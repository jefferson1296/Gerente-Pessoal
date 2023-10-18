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
    public partial class formGerenteTreinamentosGruposAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        bool cadastramento;

        GrupoMuscular grupo = new GrupoMuscular();

        formGerenteTreinamentosExercicios pai = new formGerenteTreinamentosExercicios();

        public formGerenteTreinamentosGruposAdicionar(formGerenteTreinamentosExercicios Pai)
        {
            InitializeComponent();
            cadastramento = true;
            pai = Pai;
        }

        public formGerenteTreinamentosGruposAdicionar(int ID, formGerenteTreinamentosExercicios Pai)
        {
            InitializeComponent();
            id = ID;
            cadastramento = false;
            pai = Pai;
        }

        private void formGerenteTreinamentosGrupo_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                grupo = comandos.TrazerGrupoMuscular(id);
                textBoxDescricao.Text = grupo.Descricao;
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
                MessageBox.Show("É necessário informar a descrição do grupo para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                grupo.Descricao = descricao;

                if (cadastramento)
                {
                    comandos.AdicionarGrupoMuscular(grupo);
                }
                else
                {
                    comandos.EditarGrupoMuscular(grupo);
                }

                pai.alteracao = true;
            }

            Dispose();
        }
    }
}
