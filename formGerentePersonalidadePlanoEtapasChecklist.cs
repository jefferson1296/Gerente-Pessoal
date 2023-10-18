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
    public partial class formGerentePersonalidadePlanoEtapasChecklist : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int ordem;
        formGerentePersonalidadePlanoEtapas pai = new formGerentePersonalidadePlanoEtapas();

        int selecao;

        public formGerentePersonalidadePlanoEtapasChecklist()
        {
            InitializeComponent();
        }

        public formGerentePersonalidadePlanoEtapasChecklist(formGerentePersonalidadePlanoEtapas Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formGestaoProjetoEtapasChecklist_Load(object sender, EventArgs e)
        {
            AtualizarOrdem();
            AtualizarDataGrid();

            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                if (coluna.Index != 2)
                {
                    coluna.ReadOnly = true;
                }
            }
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            pai.checklist = pai.checklist.OrderBy(x => x.Ordem).ToList();

            foreach (Checklist checklist in pai.checklist)
            {
                if (pai.pai.cadastramento || pai.cadastramento)
                {
                    if (pai.etapa.Ordem == checklist.Referencia)
                    {
                        dataGridViewLista.Rows.Add(false, checklist.Ordem, checklist.Descricao);
                    }
                }
                else
                {
                    if (pai.pai.Projeto.Etapas.Any(x => x.ID_Etapa == checklist.Referencia))
                    {
                        dataGridViewLista.Rows.Add(false, checklist.Ordem, checklist.Descricao);
                    }
                }
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void AtualizarOrdem()
        {
            if (pai.pai.cadastramento || pai.cadastramento)
            {
                ordem = pai.pai.Projeto.Checklist.Where(x => x.Referencia == pai.etapa.Ordem).Count() + 1;
            }
            else
            {
                ordem = pai.pai.Projeto.Checklist.Where(x => x.Referencia == pai.etapa.ID_Etapa).Count() + 1;
            }
        }

        private void dataGridViewEtapas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string descricao = dataGridViewLista[2, e.RowIndex].Value.ToString();

            if (dataGridViewLista[1, e.RowIndex].Value == null)
            {

                if (descricao != string.Empty)
                {
                    dataGridViewLista[1, e.RowIndex].Value = ordem;                    

                    Checklist check = new Checklist();
                    check.Referencia = pai.etapa.Ordem;
                    check.Ordem = ordem;
                    check.Descricao = descricao;
                    check.Confirmacao = false;

                    if (pai.pai.cadastramento)
                    {
                        pai.checklist.Add(check);
                    }
                    else
                    {
                        if (pai.cadastramento)
                        {
                            pai.checklist.Add(check);
                        }
                        else
                        {
                            check.Referencia = pai.etapa.ID_Etapa;
                            comandos.AdicionarItemAoCheckList(check);
                            pai.pai.AtualizarChecklist();
                        }
                    }

                    ordem++;
                }
            }
            else
            {
                foreach (Checklist check in pai.checklist)
                {
                    int ordem = Convert.ToInt32(dataGridViewLista[1, e.RowIndex].Value);

                    if (check.Ordem == ordem)
                    {
                        check.Descricao = descricao;
                    }

                    if (!pai.pai.cadastramento && !pai.cadastramento)
                    {
                        Checklist checklist = new Checklist { Referencia = pai.etapa.ID_Etapa, Ordem = ordem, Descricao = descricao };
                        comandos.EditarItemDoCheckList(checklist);
                        pai.pai.AtualizarChecklist();
                    }
                }
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridViewEtapas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    selecao = Convert.ToInt32(dataGridViewLista[1, e.RowIndex].Value);
                }
                catch
                {
                    selecao = 0;
                }
            }
            else
            {
                selecao = 0;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selecao != 0)
            {
                Checklist check = new Checklist();

                check.Ordem = selecao;
                check.Confirmacao = false;

                if (pai.cadastramento)
                {
                    check.Referencia = pai.etapa.Ordem;
                    pai.checklist.RemoveAll(x => x.Ordem == selecao && x.Referencia == check.Referencia);

                    int ordem = 1;

                    foreach (Checklist checklist in pai.checklist)
                    {
                        if (checklist.Referencia == check.Referencia)
                        {
                            checklist.Ordem = ordem;
                            ordem++;
                        }
                    }
                }
                else
                {
                    check.Referencia = pai.etapa.ID_Etapa;
                    comandos.ApagarItemDoCheckList(check);
                    comandos.ReordenarChecklist(check.Referencia);
                    pai.pai.AtualizarChecklist();

                    pai.checklist.RemoveAll(x => x.Ordem == selecao && x.Referencia == check.Referencia);
                }
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (selecao == 0) { }
            else if (selecao == 1) { }
            else if (pai.checklist.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = pai.checklist.Where(x => x.Ordem == selecao - 1).Select(i => i.Descricao).FirstOrDefault();
                string descricao_baixo = pai.checklist.Where(x => x.Ordem == selecao).Select(i => i.Descricao).FirstOrDefault();

                int nova_ordem;

                if (pai.cadastramento || !pai.cadastramento && pai.pai.cadastramento)
                {
                    foreach (Checklist check in pai.checklist)
                    {
                        if (check.Descricao == descricao_baixo && check.Ordem == selecao)
                        {
                            check.Ordem = selecao - 1;
                        }
                        else if (check.Descricao == descricao_cima && check.Ordem == selecao - 1)
                        {
                            check.Ordem = selecao;
                        }
                    }
                }
                else
                {
                    foreach (Checklist check in pai.checklist)
                    {
                        if (check.Descricao == descricao_baixo && check.Ordem == selecao)
                        {
                            nova_ordem = selecao - 1;
                            comandos.AlterarOrdemDoChecklist(check.ID, nova_ordem);
                        }
                        else if (check.Descricao == descricao_cima && check.Ordem == selecao - 1)
                        {
                            nova_ordem = selecao;
                            comandos.AlterarOrdemDoChecklist(check.ID, nova_ordem);
                        }
                    }

                    pai.pai.AtualizarChecklist();
                    pai.AtualizarChecklist();
                }

                AtualizarDataGrid();

                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];
                selecao = selecao - 1;
            }
        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (selecao == 0) { }
            else if (selecao == pai.checklist.Count) { }
            else if (pai.checklist.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                string descricao_cima = pai.checklist.Where(x => x.Ordem == selecao).Select(i => i.Descricao).FirstOrDefault();
                string descricao_baixo = pai.checklist.Where(x => x.Ordem == selecao + 1).Select(i => i.Descricao).FirstOrDefault();

                int nova_ordem;

                if (pai.cadastramento || !pai.cadastramento && pai.pai.cadastramento)
                {
                    foreach (Checklist check in pai.checklist)
                    {
                        if (check.Descricao == descricao_baixo && check.Ordem == selecao + 1)
                        {
                            check.Ordem = selecao;
                        }
                        else if (check.Descricao == descricao_cima && check.Ordem == selecao)
                        {
                            check.Ordem = selecao + 1;
                        }
                    }
                }
                else
                {
                    foreach (Checklist check in pai.checklist)
                    {
                        if (check.Descricao == descricao_baixo && check.Ordem == selecao + 1)
                        {
                            nova_ordem = selecao;
                            comandos.AlterarOrdemDoChecklist(check.ID, nova_ordem);
                        }
                        else if (check.Descricao == descricao_cima && check.Ordem == selecao)
                        {
                            nova_ordem = selecao + 1;
                            comandos.AlterarOrdemDoChecklist(check.ID, nova_ordem);
                        }
                    }

                    pai.pai.AtualizarChecklist();
                    pai.AtualizarChecklist();
                }

                AtualizarDataGrid();

                try
                {
                    dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }

                selecao = selecao + 1;
            }
        }
    }
}
