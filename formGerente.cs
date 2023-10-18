using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formGerente : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool personalidade;
        bool finanças;

        public formGerente()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formPlanejamentoSemanal_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            AplicarTema();

            personalidade = true;
            finanças = false;

            DestacarBotoes();

            timerAfazeres.Start();
        }

        private void AplicarTema()
        {
            comandos.ObterTemaPeloUsuario();

            panelLinha1.BackColor = Program.tema.Cor_Principal;
            panelLinha2.BackColor = Program.tema.Cor_Secundaria;
            panelLinha3.BackColor = Program.tema.Cor_Principal;

            if (personalidade)
            {
                buttonPersonalidade.BackColor = Program.tema.Cor_Principal;
                buttonPersonalidade.ForeColor = Program.tema.Cor_Secundaria;
                buttonPersonalidade.Font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

                buttonFinanças.BackColor = Program.tema.Cor_Secundaria;
                buttonFinanças.ForeColor = Program.tema.Cor_Principal;
            }
            else if (finanças)
            {
                buttonFinanças.BackColor = Program.tema.Cor_Principal;
                buttonFinanças.ForeColor = Program.tema.Cor_Secundaria;

                buttonPersonalidade.BackColor = Program.tema.Cor_Secundaria;
                buttonPersonalidade.ForeColor = Program.tema.Cor_Principal;
            }
        }

        private void DestacarBotoes()
        {
            if (personalidade)
            {
                formGerentePersonalidade pessoal = new formGerentePersonalidade() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(pessoal);
                pessoal.Show();

                buttonPersonalidade.BackColor = Program.tema.Cor_Principal;
                buttonPersonalidade.ForeColor = Program.tema.Cor_Secundaria;
            }
            else
            {
                buttonPersonalidade.BackColor = Program.tema.Cor_Secundaria;
                buttonPersonalidade.ForeColor = Program.tema.Cor_Principal;
            }
            if (finanças)
            {
                formGerenteFinanceiro fin = new formGerenteFinanceiro() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(fin);
                fin.Show();
                buttonFinanças.BackColor = Program.tema.Cor_Principal;
                buttonFinanças.ForeColor = Program.tema.Cor_Secundaria;
            }
            else
            {
                buttonFinanças.BackColor = Program.tema.Cor_Secundaria;
                buttonFinanças.ForeColor = Program.tema.Cor_Principal;
            }
        }


        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;

        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void buttonFinanças_Click(object sender, EventArgs e)
        {
            if (!finanças)
            {
                finanças = true;
                personalidade = false;

                DestacarBotoes();
            }            
        }

        private void buttonPersonalidade_Click(object sender, EventArgs e)
        {
            if (!personalidade)
            {
                finanças = false;
                personalidade = true;

                DestacarBotoes();
            }
        }

        private void temaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTema tema = new formTema();
            tema.ShowDialog();
            AplicarTema();
        }

        private void timerAfazeres_Tick(object sender, EventArgs e)
        {
            timerAfazeres.Stop();

            string rotina = "Lançamento de rotinas";

            if (!comandos.VerificarLancamentoDeMetodoAutomaticoDiario(rotina))
            {
                if (DialogResult.Yes == MessageBox.Show("Deseja lançar as rotinas de hoje?", "Horários", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    comandos.DefinirRotinasDoDia();
                    comandos.AtualizarLancamentoDeMetodoAutomatico(rotina);
                }
            }

            if (comandos.VerificarAfazeresPendentes())
            {
                comandos.AtualizarDataDosAfazeresPendentes();
                formGerenteProfissional afazeres = new formGerenteProfissional();
                afazeres.ShowDialog();
            }
        }
    }
}
