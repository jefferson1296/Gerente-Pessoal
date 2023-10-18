using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciamentoPessoal
{
    public partial class formGerenteTreinamentosExercicios : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        private List<Exercicio> exercicios = new List<Exercicio>();

        Exercicio exercicio = new Exercicio();

        public bool alteracao;

        public formGerenteTreinamentosExercicios()
        {
            InitializeComponent();
        }

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetTreeViewTheme(IntPtr treeHandle)
        {
            SetWindowTheme(treeHandle, "explorer", null);
        }

        private void formGerenteTreinamentosExercicios_Load(object sender, EventArgs e)
        {
            PreencherArvore();
            SetTreeViewTheme(treeView1.Handle);
        }

        private void ExcluirNos()
        {
            List<Exercicio> exercicios = comandos.GruposMuscularesEExercicios();
            List<TreeNode> excluir_nos = new List<TreeNode>();

            foreach (Exercicio exercicio in this.exercicios)
            {
                if (!exercicios.Any(x => x.Descricao == exercicio.Descricao))
                {
                    foreach (TreeNode no in treeView1.Nodes)
                    {
                        if (exercicio.ID_Grupo != 0)
                        {
                            foreach (TreeNode no_filho in no.Nodes)
                            {
                                if (no_filho.Text == exercicio.Descricao)
                                {
                                    excluir_nos.Add(no_filho);
                                }   
                            }
                        }
                        else if (no.Text == exercicio.Descricao)
                        {
                            excluir_nos.Add(no);
                        }
                    }
                }
            }

            foreach(TreeNode no in excluir_nos)
            {
                treeView1.Nodes.Remove(no);
                this.exercicios.RemoveAll(x => x.Descricao == no.Text);
            }
        }

        private void PreencherArvore()
        {
            List<Exercicio> exercicios = comandos.GruposMuscularesEExercicios();

            foreach (Exercicio exercicio in exercicios)
            {
                if (!this.exercicios.Any(x => x.Descricao == exercicio.Descricao))
                {
                    TreeNode nó = new TreeNode(exercicio.Descricao);

                    if (exercicio.ID_Grupo == 0)
                    {
                        treeView1.Nodes.Add(nó);
                    }
                    else
                    {
                        string nome_pai = exercicios.Where(x => x.ID_Exercicio == exercicio.ID_Grupo).Select(x => x.Descricao).FirstOrDefault();

                        foreach (TreeNode nó_pai in treeView1.Nodes)
                        {
                            if (nó_pai.Text == nome_pai)
                            {
                                nó_pai.Nodes.Add(nó);
                            }

                            foreach (TreeNode nó_filho in nó_pai.Nodes)
                            {
                                if (nó_filho.Text == nome_pai)
                                {
                                    nó_filho.Nodes.Add(nó);
                                }
                            }
                        }
                    }
                }
            }

            this.exercicios = exercicios;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                treeView1.SelectedNode = e.Node;

                exercicio.Descricao = e.Node.Text;
                exercicio.ID_Exercicio = exercicios.Where(x => x.Descricao == exercicio.Descricao).Select(x => x.ID_Exercicio).FirstOrDefault();
                exercicio.ID_Grupo = exercicios.Where(x => x.Descricao == exercicio.Descricao).Select(x => x.ID_Grupo).FirstOrDefault();

                if (exercicio.ID_Grupo == 0)
                {
                    adicionarToolStripMenuItem.Visible = true;
                    editarExercicioToolStripMenuItem.Visible = false;
                    editarToolStripMenuItem.Visible = true;
                }
                else
                {
                    adicionarToolStripMenuItem.Visible = false;
                    editarExercicioToolStripMenuItem.Visible = true;
                    editarToolStripMenuItem.Visible = false;
                }
            }
            catch { }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosGruposAdicionar editar_grupo = new formGerenteTreinamentosGruposAdicionar(exercicio.ID_Exercicio, this);
            editar_grupo.ShowDialog();

            if (alteracao)
            {
                alteracao = false;
                PreencherArvore();
            }
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosExerciciosAdicionar editar_exercicio = new formGerenteTreinamentosExerciciosAdicionar(exercicio.Descricao, this);
            editar_exercicio.ShowDialog();

            if (alteracao)
            {
                alteracao = false;
                PreencherArvore();
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (exercicio.ID_Grupo == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Além do grupo, todos os exercícios registrados\r\npara esse grupo também serão apagados.\r\n\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarGrupoMuscular(exercicio.ID_Exercicio);
                    comandos.ApagarExerciciosDoGrupoMuscular(exercicio.ID_Exercicio);
                    ExcluirNos();
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o exercício?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarExercicio(exercicio.ID_Exercicio);
                    ExcluirNos();
                }
            }
        }

        private void editarExercicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosExerciciosAdicionar editar_exercicio = new formGerenteTreinamentosExerciciosAdicionar(exercicio.ID_Exercicio, this);
            editar_exercicio.ShowDialog();

            if (alteracao)
            {
                alteracao = false;
                PreencherArvore();
            }
        }

        private void labelGrupo_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentosGruposAdicionar adicionar = new formGerenteTreinamentosGruposAdicionar(this);
            adicionar.ShowDialog();

            if (alteracao)
            {
                alteracao = false;
                PreencherArvore();
            }
        }
    }
}
