using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formLogin : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGerente gerente = new formGerente();

        public formLogin()
        {
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            Cumprimentar();
        }

        private void Cumprimentar()
        {
            string pasta_local = Directory.GetCurrentDirectory();

            string[] partir = pasta_local.Split('\\');
            string diretorio = string.Empty;

            foreach (string texto in partir)
            {
                if (texto == "bin")
                {
                    diretorio = diretorio + "Imagens\\";
                    break;
                }
                else
                {
                    diretorio = diretorio + texto + "\\";
                }
            }

            int hora = DateTime.Now.Hour;

            if (hora >= 5 && hora < 12)
            {
                labelCumprimento.Text = "Bom dia !";
                labelCumprimento.ForeColor = Color.WhiteSmoke;

                labelEntrar.ForeColor = Color.Sienna;
                buttonAcessar.ForeColor = Color.Sienna;
                textBoxUsuario.ForeColor = Color.Peru;
                textBoxSenha.ForeColor = Color.Peru;
                panelLogin.BackColor = Color.Peru;
                panelSenha.BackColor = Color.Peru;

                this.BackColor = Color.White;
                textBoxUsuario.BackColor = Color.White;
                textBoxSenha.BackColor = Color.White;

                try
                {
                    panelImagem.BackgroundImage = Image.FromFile(diretorio + "bom dia.jpg");
                    buttonFechar.Image = Image.FromFile(diretorio + "fechar escuro.png");
                }
                catch { }

            }
            else if (hora >= 12 && hora < 18)
            {
                labelCumprimento.Text = "Boa tarde !";
                labelCumprimento.ForeColor = Color.WhiteSmoke;

                labelEntrar.ForeColor = Color.DarkOrange;
                buttonAcessar.ForeColor = Color.DarkOrange;
                textBoxUsuario.ForeColor = Color.FromArgb(255, 192, 60);
                textBoxSenha.ForeColor = Color.FromArgb(255, 192, 60);
                panelLogin.BackColor = Color.FromArgb(255, 192, 60);
                panelSenha.BackColor = Color.FromArgb(255, 192, 60);

                this.BackColor = Color.White;
                textBoxUsuario.BackColor = Color.White;
                textBoxSenha.BackColor = Color.White;

                try
                {
                    panelImagem.BackgroundImage = Image.FromFile(diretorio + "boa tarde.jpg");
                    buttonFechar.Image = Image.FromFile(diretorio + "fechar escuro.png");
                }
                catch { }
            }
            else if (hora >= 18 && hora <= 23 && hora != 0)
            {
                labelCumprimento.Text = "Boa noite !";
                labelCumprimento.ForeColor = Color.FromArgb(192, 192, 255);

                labelEntrar.ForeColor = Color.FromArgb(192, 192, 255);
                buttonAcessar.ForeColor = Color.FromArgb(192, 192, 255);
                textBoxUsuario.ForeColor = Color.FromArgb(192, 192, 255);
                textBoxSenha.ForeColor = Color.FromArgb(192, 192, 255);

                panelLogin.BackColor = Color.FromArgb(192, 192, 255);
                panelSenha.BackColor = Color.FromArgb(192, 192, 255);

                this.BackColor = Color.FromArgb(0, 0, 4);
                textBoxUsuario.BackColor = Color.FromArgb(0, 0, 4);
                textBoxSenha.BackColor = Color.FromArgb(0, 0, 4);

                try
                {
                    panelImagem.BackgroundImage = Image.FromFile(diretorio + "boa noite.jpeg");
                    buttonFechar.Image = Image.FromFile(diretorio + "fechar claro.png");
                }
                catch { }

            }
            else if (hora >= 0 && hora < 5)
            {
                labelCumprimento.Text = "Boa madrugada !";
                labelCumprimento.ForeColor = Color.DimGray;

                labelEntrar.ForeColor = Color.DimGray;
                buttonAcessar.ForeColor = Color.DimGray;
                textBoxUsuario.ForeColor = Color.DimGray;
                textBoxSenha.ForeColor = Color.DimGray;

                panelLogin.BackColor = Color.DarkGray;
                panelSenha.BackColor = Color.DarkGray;

                this.BackColor = Color.FromArgb(0, 0, 4);
                textBoxUsuario.BackColor = Color.FromArgb(0, 0, 4);
                textBoxSenha.BackColor = Color.FromArgb(0, 0, 4);

                try
                {
                    panelImagem.BackgroundImage = Image.FromFile(diretorio + "boa madrugada.jpg");
                    buttonFechar.Image = Image.FromFile(diretorio + "fechar claro.png");
                }
                catch { }
            }

            panelImagem.BackgroundImageLayout = ImageLayout.Stretch;
            labelCumprimento.BackColor = Color.Transparent;

            labelCumprimento.Left = (panelImagem.Width / 2) - (labelCumprimento.Width / 2);
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAcessar_Click(object sender, EventArgs e)
        {
            Acessar();
        }

        private void Acessar()
        {
            string login = textBoxUsuario.Text;
            string senha = textBoxSenha.Text;

            bool acesso = comandos.VerificarLogin(login, senha);

            if (acesso)
            {
                Program.usuario = comandos.TrazerUsuario(login, senha);
                timerTransparente.Enabled = true;
            }
            else
            {
                MessageBox.Show("Matrícula ou Senha incorretas!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerTransparente_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                timerTransparente.Stop();
                Hide();
                gerente.ShowDialog();
                Dispose();
            }
            else
            {
                Opacity = Opacity - 0.03;
            }
        }

        private void textBoxUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBoxUsuario.Text == "LOGIN")
            {
                textBoxUsuario.Clear();
            }
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "LOGIN")
            {
                textBoxUsuario.Clear();
            }
        }
        private void textBoxUsuario_Leave(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == string.Empty)
            {
                textBoxUsuario.Text = "LOGIN";
                textBoxUsuario.TabStop = true;
            }
            else
            {
                textBoxUsuario.TabStop = false;
            }
        }

        private void textBoxSenha_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxSenha.Clear();
            textBoxSenha.UseSystemPasswordChar = true;
        }
        private void textBoxSenha_Enter(object sender, EventArgs e)
        {
            textBoxSenha.Clear();
            textBoxSenha.UseSystemPasswordChar = true;
        }
        private void textBoxSenha_Leave(object sender, EventArgs e)
        {
            if (textBoxSenha.Text == string.Empty)
            {
                textBoxSenha.Text = "SENHA";
                textBoxSenha.UseSystemPasswordChar = false;
            }
            else { buttonAcessar.Focus(); }
        }

        private void formLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void formLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (buttonAcessar.Focused == true)
                {
                    buttonAcessar_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    ProcessTabKey(true);
                    e.Handled = true;
                }
            }
        }

        private void labelCadastrar_Click(object sender, EventArgs e)
        {
            formLoginCadastrarUsuario cadastrar = new formLoginCadastrarUsuario();
            cadastrar.ShowDialog();
        }
    }
}
