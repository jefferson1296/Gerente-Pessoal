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
    public partial class formGerenteTreinamentos : Form
    {
        bool inicial;
        bool exercicios;
        bool treinos;

        public formGerenteTreinamentos()
        {
            InitializeComponent();
        }

        private void formGerenteTreinamentos_Load(object sender, EventArgs e)
        {
            inicial = true;
            AlterarExibicao();
        }

        private void buttonInicial_Click(object sender, EventArgs e)
        {
            if (!inicial)
            {
                inicial = true;
                exercicios = false;
                treinos = false;
                AlterarExibicao();
            }
        }

        private void buttonExercicios_Click(object sender, EventArgs e)
        {
            if (!exercicios)
            {
                inicial = false;
                exercicios = true;
                treinos = false;
                AlterarExibicao();
            }
        }

        private void buttonTreinos_Click(object sender, EventArgs e)
        {
            if (!treinos)
            {
                inicial = false;
                exercicios = false;
                treinos = true;
                AlterarExibicao();
            }
        }

        private void AlterarExibicao()
        {
            if (inicial)
            {
                formGerenteTreinamentosInicial inicial = new formGerenteTreinamentosInicial { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(inicial);
                inicial.Show();
            }
            else if (exercicios)
            {
                formGerenteTreinamentosExercicios exercicios = new formGerenteTreinamentosExercicios { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(exercicios);
                exercicios.Show();
            } 
            else if (treinos)
            {
                formGerenteTreinamentosTreinos treinos = new formGerenteTreinamentosTreinos { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(treinos);
                treinos.Show();
            }
        }

        private void buttonFrases_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosFrases frases = new formGerenteTreinamentosFrases();
            frases.ShowDialog();
        }
    }
}
