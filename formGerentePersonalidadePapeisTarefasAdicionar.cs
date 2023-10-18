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
    public partial class formGerentePersonalidadePapeisTarefasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Tarefa_Semanal tarefa = new Tarefa_Semanal();

        int id_papel;

        bool cadastramento;

        public formGerentePersonalidadePapeisTarefasAdicionar(int ID_Papel)
        {
            InitializeComponent();

            cadastramento = true;
            id_papel = ID_Papel;
        }

        public formGerentePersonalidadePapeisTarefasAdicionar(int ID_Tarefa, int ID_Papel)
        {
            InitializeComponent();
            tarefa.ID_Tarefa = ID_Tarefa;
            id_papel = ID_Papel;

            cadastramento = false;
        }

        private void formGerentePersonalidadePapeisTarefasAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                tarefa = comandos.TrazerTarefaFixa(tarefa.ID_Tarefa);

                textBoxDescricao.Text = tarefa.Descricao;
                textBoxObservacoes.Text = tarefa.Observacao;
                textBoxMulti.Text = tarefa.Multiplicador.ToString();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            tarefa.Descricao = textBoxDescricao.Text;
            tarefa.Observacao = textBoxObservacoes.Text;
            tarefa.Multiplicador = Convert.ToInt32(textBoxMulti.Text);
            tarefa.ID_Papel = id_papel;

            if (textBoxDescricao.Text == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tarefa.Multiplicador < 1)
            {
                MessageBox.Show("O multplicador não pode ser menor que 1.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cadastramento)
                {
                    comandos.CadastrarTarefaFixa(tarefa);
                }
                else
                {
                    comandos.EditarTarefaFixa(tarefa);
                }

                Dispose();
            }
        }

        private void textBoxMulti_Enter(object sender, EventArgs e)
        {
            textBoxMulti.ForeColor = Color.Black;
        }

        private void textBoxMulti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxMulti_Leave(object sender, EventArgs e)
        {
            if (textBoxMulti.Text == string.Empty)
            {
                textBoxMulti.Text = "1";
            }
        }
    }
}
