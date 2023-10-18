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
    public partial class formLoginCadastrarUsuario : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public Tema tema = new Tema();

        public formLoginCadastrarUsuario()
        {
            InitializeComponent();
        }

        private void formCadastrarUsuario_Load(object sender, EventArgs e)
        {
            tema.Cor_Principal = Color.White;
            tema.Cor_Secundaria = Color.Black;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            string nome = textBoxNome.Text;
            string sobrenome = textBoxSobrenome.Text;
            DateTime nascimento = dateTimeNascimento.Value;
            string login = textBoxLogin.Text;
            string senha = textBoxSenha.Text;
            string confirmar_senha = textBoxConfirmar.Text;

            if (nome == string.Empty)
            {
                MessageBox.Show("Informe o nome para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (login == string.Empty)
            {
                MessageBox.Show("Informe o login para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (senha == string.Empty)
            {
                MessageBox.Show("Informe a senha para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if (senha.Length < 8)
            //{

            //}
            else if (senha != confirmar_senha)
            {
                MessageBox.Show("Verifique a senha informada.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Nascimento = nascimento;
                usuario.Login = login;
                usuario.Senha = senha;

                comandos.CadastrarUsuario(usuario, tema);

                MessageBox.Show("Usuário cadastrado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dispose();
            }
        }

        private void labelTema_Click(object sender, EventArgs e)
        {
            formTema tema = new formTema(this);
            tema.ShowDialog();
            panelPrincipal.BackColor = this.tema.Cor_Principal;
            panelSecundaria.BackColor = this.tema.Cor_Secundaria;
        }
    }
}
