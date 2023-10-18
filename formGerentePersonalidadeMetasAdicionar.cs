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
    public partial class formGerentePersonalidadeMetasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        bool cadastramento;

        Objetivo objetivo = new Objetivo();

        public formGerentePersonalidadeMetasAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGerentePersonalidadeMetasAdicionar(int ID)
        {
            InitializeComponent();
            id = ID;
            cadastramento = false;
        }

        private void formGerenteTreinamentosFrasesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                objetivo = comandos.TrazerObjetivo(id);
                textBoxDescricao.Text = objetivo.Descricao;
                dateTimePickerInicio.Value = objetivo.Inicio;
                dateTimePickerConclusao.Value = objetivo.Termino;
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
                MessageBox.Show("É necessário informar a descrição para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objetivo.Descricao = descricao;
                objetivo.ID_Objetivo = id;
                objetivo.Inicio = dateTimePickerInicio.Value;
                objetivo.Termino = dateTimePickerConclusao.Value;

                if (cadastramento)
                {
                    comandos.CadastrarObjetivo(objetivo);
                }
                else
                {
                    comandos.EditarObjetivo(objetivo);
                }
            }

            Dispose();
        }
    }
}
