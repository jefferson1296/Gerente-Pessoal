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
    public partial class formGerentePersonalidadePapeisAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        bool cadastramento;
        int id_papel;

        Papel papel = new Papel();

        public formGerentePersonalidadePapeisAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGerentePersonalidadePapeisAdicionar(int ID_Papel)
        {
            InitializeComponent();

            cadastramento = false;
            id_papel = ID_Papel;
        }

        private void formGerentePersonalidadePapeisAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                papel = comandos.TrazerPapel(id_papel);

                textBoxDescricao.Text = papel.Descricao;
                panelCor.BackColor = papel.Cor;
            }
            else
            {
                papel.Cor = Color.White;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe o papel para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                papel.Descricao = descricao;

                if (cadastramento)
                {
                    comandos.CadastrarPapel(papel);

                    MessageBox.Show("Papel cadastrado.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    comandos.EditarPapel(papel);
                }

                Dispose();
            }
        }

        private void panelCor_Click(object sender, EventArgs e)
        {
            if (colorDialogCor.ShowDialog() == DialogResult.OK)
            {
                papel.Cor = colorDialogCor.Color;
                panelCor.BackColor = papel.Cor;
            }
        }
    }
}
