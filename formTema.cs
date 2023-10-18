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
    public partial class formTema : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;

        formLoginCadastrarUsuario cadastrar = new formLoginCadastrarUsuario();
        Tema tema = new Tema();


        public formTema()
        {
            InitializeComponent();
            cadastramento = false;
        }

        public formTema(formLoginCadastrarUsuario Cadastrar)
        {
            InitializeComponent();
            cadastramento = true;
            cadastrar = Cadastrar;
        }

        private void formTema_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                panelPrincipal.BackColor = Program.tema.Cor_Principal;
                colorDialogCor1.Color = Program.tema.Cor_Principal;
                tema.Cor_Principal = Program.tema.Cor_Principal;

                panelSecundaria.BackColor = Program.tema.Cor_Secundaria;
                colorDialogCor2.Color = Program.tema.Cor_Secundaria;
                tema.Cor_Secundaria = Program.tema.Cor_Secundaria;
            }
            else
            {
                panelPrincipal.BackColor = cadastrar.tema.Cor_Principal;
                colorDialogCor1.Color = cadastrar.tema.Cor_Principal;
                tema.Cor_Principal = cadastrar.tema.Cor_Principal;

                panelSecundaria.BackColor = cadastrar.tema.Cor_Secundaria;
                colorDialogCor2.Color = cadastrar.tema.Cor_Secundaria;
                tema.Cor_Secundaria = cadastrar.tema.Cor_Secundaria;
            }
        }

        private void panelPrincipal_Click(object sender, EventArgs e)
        {
            if (colorDialogCor1.ShowDialog() == DialogResult.OK)
            {
                tema.Cor_Principal = colorDialogCor1.Color;
                panelPrincipal.BackColor = tema.Cor_Principal;
            }
        }

        private void panelSecundaria_Click(object sender, EventArgs e)
        {
            if (colorDialogCor2.ShowDialog() == DialogResult.OK)
            {
                tema.Cor_Secundaria = colorDialogCor2.Color;
                panelSecundaria.BackColor = tema.Cor_Secundaria;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                cadastrar.tema = tema;
                Dispose();
            }
            else
            {
                comandos.EditarTema(tema);
                Dispose();
            }
        }
    }
}
