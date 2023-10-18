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
    public partial class formGerenteFinanceiroFluxoCategorias : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        private List<Categoria_Financeira> categorias = new List<Categoria_Financeira>();
        Categoria_Financeira categoria = new Categoria_Financeira();

        public formGerenteFinanceiroFluxoCategorias()
        {
            InitializeComponent();
        }

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetTreeViewTheme(IntPtr treeHandle)
        {
            SetWindowTheme(treeHandle, "explorer", null);
        }

        private void formFinanceiroFluxoCategoria_Load(object sender, EventArgs e)
        {
            PreencherArvore();
            SetTreeViewTheme(treeView1.Handle);
        }

        private void PreencherArvore()
        {
            categorias = comandos.PlanoDeContas();
            treeView1.Nodes.Clear();

            foreach (Categoria_Financeira categoria in categorias)
            {
                TreeNode nó = new TreeNode(categoria.Categoria);

                if (categoria.ID_Parente == 0)
                {
                    treeView1.Nodes.Add(nó);
                }
                else
                {
                    string nome_pai = categorias.Where(x => x.ID == categoria.ID_Parente).Select(x => x.Categoria).FirstOrDefault();

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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {                
                treeView1.SelectedNode = e.Node;

                categoria.Categoria = e.Node.Text;
                categoria.ID = categorias.Where(x => x.Categoria == categoria.Categoria).Select(x => x.ID).FirstOrDefault();
                categoria.ID_Parente = categorias.Where(x => x.Categoria == categoria.Categoria).Select(x => x.ID_Parente).FirstOrDefault();
                categoria.Tipo = categorias.Where(x => x.Categoria == categoria.Categoria).Select(x => x.Tipo).FirstOrDefault();

                //if (e.Node.Nodes.Count == 0)
                //{
                //    adicionarToolStripMenuItem.Visible = false;
                //}
                //else
                //{
                //    adicionarToolStripMenuItem.Visible = true;
                //}

                if (categorias.Where(x => x.Categoria == categoria.Categoria).Select(x => x.ID_Parente).FirstOrDefault() == 0)
                {
                    excluirToolStripMenuItem.Visible = false;
                }
                else
                {
                    excluirToolStripMenuItem.Visible = true;
                }
            }
            catch { }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoria.ID != 0)
            {
                formGerenteFinanceiroFluxoCategoriasAdicionar editar = new formGerenteFinanceiroFluxoCategoriasAdicionar(categoria, false);
                editar.ShowDialog();
                PreencherArvore();
            }
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categoria.ID != 0)
            {
                Categoria_Financeira categoria = new Categoria_Financeira { ID_Parente = this.categoria.ID, Tipo = this.categoria.Tipo };
                formGerenteFinanceiroFluxoCategoriasAdicionar cadastrar = new formGerenteFinanceiroFluxoCategoriasAdicionar(categoria, true);
                cadastrar.ShowDialog();
                PreencherArvore();
            }

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("A categoria " + categoria.Categoria + "será excluída permanentemente.\r\n\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                comandos.ApagarCategoriaDoPlanoDeContas(categoria.ID);
                PreencherArvore();
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroFluxoCategoriasAdicionar cadastrar = new formGerenteFinanceiroFluxoCategoriasAdicionar();
            cadastrar.ShowDialog();
            PreencherArvore();
        }
    }
}
