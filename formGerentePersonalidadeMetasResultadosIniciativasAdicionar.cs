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
    public partial class formGerentePersonalidadeMetasResultadosIniciativasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        bool cadastramento;

        Iniciativa iniciativa = new Iniciativa();

        public formGerentePersonalidadeMetasResultadosIniciativasAdicionar()
        {
            InitializeComponent();

        }

        public formGerentePersonalidadeMetasResultadosIniciativasAdicionar(int ID, bool Cadastramento)
        {
            InitializeComponent();
            id = ID;
            cadastramento = Cadastramento;
        }

        private void formGerenteTreinamentosFrasesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                iniciativa = comandos.TrazerIniciativa(id);
                textBoxDescricao.Text = iniciativa.Descricao;
                textBoxDetalhes.Text = iniciativa.Detalhes;
                textBoxReferencia.Text = iniciativa.Referencia;
            }
            else
            {
                iniciativa.ID_Resultado = id;
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
            string detalhes = textBoxDetalhes.Text;
            string referencia = textBoxReferencia.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("É necessário informar a descrição para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                iniciativa.Descricao = descricao;
                iniciativa.Detalhes = detalhes;
                iniciativa.Referencia = referencia;

                if (cadastramento)
                {
                    comandos.CadastrarIniciativa(iniciativa);
                }
                else
                {
                    comandos.EditarIniciativa(iniciativa);
                }
            }

            Dispose();
        }
    }
}
