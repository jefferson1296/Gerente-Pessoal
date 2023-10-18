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
    public partial class formGerenteTreinamentosFrasesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        bool cadastramento;

        FraseMotivacional frase = new FraseMotivacional();

        public formGerenteTreinamentosFrasesAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGerenteTreinamentosFrasesAdicionar(int ID)
        {
            InitializeComponent();
            id = ID;
            cadastramento = false;
        }

        private void formGerenteTreinamentosFrasesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                frase = comandos.TrazerFraseMotivacional(id);
                textBoxDescricao.Text = frase.Descricao;
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
                MessageBox.Show("É necessário informar a frase para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frase.Descricao = descricao;

                if (cadastramento)
                {
                    comandos.AdicionarFraseMotivacional(frase);
                }
                else
                {
                    comandos.EditarFraseMotivacional(frase);
                }
            }

            Dispose();
        }
    }
}
