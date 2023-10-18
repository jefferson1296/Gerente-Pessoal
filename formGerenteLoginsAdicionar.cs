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
    public partial class formGerenteLoginsAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_login;
        Login login = new Login();

        bool cadastramento;

        public formGerenteLoginsAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formGerenteLoginsAdicionar(int ID_Login)
        {
            InitializeComponent();
            cadastramento = false;
            id_login = ID_Login;
        }

        private void formGestaoEstabelecimentosReparticoesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                login = comandos.InformacoesDoLogin(id_login);

                textBoxDescricao.Text = login.Descricao;
                textBoxLogin.Text = login.Log_in;
                textBoxSenha.Text = login.Senha;
            }
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string login = textBoxLogin.Text;
            string senha = textBoxSenha.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.login.Descricao = descricao;
                this.login.Log_in = login;
                this.login.Senha = senha;

                if (cadastramento)
                {
                    comandos.CadastrarLogin(this.login);
                }
                else
                {
                    comandos.EditarLogin(this.login);
                }

                Dispose();
            }
        }

        private void checkBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = checkBoxMostrar.Checked;

            textBoxSenha.UseSystemPasswordChar = !mostrar;
        }
    }
}
