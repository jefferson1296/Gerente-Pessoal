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
    public partial class formGerenteTreinamentosExerciciosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id; string grupo;

        bool cadastramento;


        Exercicio exercicio = new Exercicio();

        formGerenteTreinamentosExercicios pai = new formGerenteTreinamentosExercicios();

        public formGerenteTreinamentosExerciciosAdicionar(string Grupo, formGerenteTreinamentosExercicios Pai)
        {
            InitializeComponent();
            cadastramento = true;
            grupo = Grupo;
            pai = Pai;
        }

        public formGerenteTreinamentosExerciciosAdicionar(int ID, formGerenteTreinamentosExercicios Pai)
        {
            InitializeComponent();
            id = ID;
            cadastramento = false;
            pai = Pai;
        }

        private void formGerenteTreinamentosGrupo_Load(object sender, EventArgs e)
        {
            comboBoxGrupo.DataSource = comandos.PreencherComboGruposMusculares();
            comboBoxGrupo.DisplayMember = "Descricao";
            comboBoxGrupo.ValueMember = "ID_Grupo";
            comboBoxGrupo.DropDownHeight = 120;
            comboBoxGrupo.SelectedIndex = -1;

            if (cadastramento)
            {
                comboBoxGrupo.Text = grupo;
                comboBoxGrupo.Enabled = false;
            }
            else
            {
                exercicio = comandos.TrazerExercicio(id);
                textBoxDescricao.Text = exercicio.Descricao;
                
                if (exercicio.Aerobico) { radioButtonAerobico.Checked = true; }
                else { radioButtonAnaerobico.Checked = true; }

                comboBoxGrupo.SelectedValue = exercicio.ID_Grupo;
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
            string grupo = comboBoxGrupo.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("É necessário informar a descrição do exercício para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (grupo == string.Empty)
            {
                MessageBox.Show("É necessário informar o grupo para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                exercicio.Descricao = descricao;
                exercicio.ID_Grupo = (int)comboBoxGrupo.SelectedValue;
                exercicio.Aerobico = radioButtonAerobico.Checked;

                if (cadastramento)
                {
                    comandos.AdicionarExercicio(exercicio);
                }
                else
                {
                    comandos.EditarExercicio(exercicio);
                }

                pai.alteracao = true;
            }

            Dispose();
        }
    }
}
