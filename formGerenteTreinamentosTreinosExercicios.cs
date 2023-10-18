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
    public partial class formGerenteTreinamentosTreinosExercicios : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        List<GrupoMuscular> grupos = new List<GrupoMuscular>();
        List<Exercicio> exercicios = new List<Exercicio>();

        bool cadastramento;

        int id_treino;
        string descricao;

        int id_grupo;
        int id_exercicio;

        int ordem;

        public formGerenteTreinamentosTreinosExercicios(string Descricao)
        {
            InitializeComponent();
            cadastramento = true;
            descricao = Descricao;
        }

        public formGerenteTreinamentosTreinosExercicios(int ID_Treino, string Descricao)
        {
            InitializeComponent();
            id_treino = ID_Treino;
            cadastramento = false;
            descricao = Descricao;
        }

        private void formGerenteTreinamentosTreinosAdicionar_Load(object sender, EventArgs e)
        {
            if (cadastramento) { id_treino = comandos.TrazerUltimoTreinoCadastrado(); }

            List<string> status = new List<string>();
            status.Add("Regular");
            status.Add("Bi-set");
            status.Add("Tri-set");
            status.Add("Super série");
            status.Add("Drop-set");
            status.Add("Circuito");
            status.Add("Pirâmide crescente");
            status.Add("Pirâmide decrescente");
            status.Add("Pré-exaustão");
            status.Add("Exaustão");
            status.Add("Isométrico");
            status.Add("Rest-pause");
            status.Add("Excêntrico (toque)");
            status.Add("Superlento");
            status.Add("6/20");
            status.Add("Agonista/Antagonista");
            

            ColumnTipo.DataSource = status;

            foreach (DataGridViewColumn Coluna in dataGridViewExercicios.Columns)
            {
                if (Coluna.Index != 3 && Coluna.Index != 4 && Coluna.Index != 5 && Coluna.Index != 6)
                {
                    dataGridViewExercicios.Columns[Coluna.Index].ReadOnly = true;
                }
            }

            labelDescricao.Text = descricao;

            AtualizarDataGridGrupos();
        }

        private void AtualizarDataGridGrupos()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewGrupos.CurrentRow != null)
            {
                primeira_linha = dataGridViewGrupos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewGrupos.CurrentRow.Index;
            }

            dataGridViewGrupos.Rows.Clear();

            grupos = comandos.TrazerGruposDoTreino(id_treino);

            foreach (GrupoMuscular grupo in grupos)
            {
                dataGridViewGrupos.Rows.Add(grupo.ID_Grupo, grupo.Descricao, grupo.Check);
            }

            try
            {
                dataGridViewGrupos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewGrupos.CurrentCell = dataGridViewGrupos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewGrupos.CurrentRow != null)
                dataGridViewGrupos.CurrentRow.Selected = false;
        }



        private void AtualizarDataGridExercicios()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewExercicios.CurrentRow != null)
            {
                primeira_linha = dataGridViewExercicios.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewExercicios.CurrentRow.Index;
            }

            exercicios = comandos.TrazerExerciciosDoTreino(id_treino);

            dataGridViewExercicios.Rows.Clear();

            foreach (Exercicio exercicio in exercicios)
            {
                string ordem;
                if (exercicio.Ordem == 0) { ordem = ""; }
                else { ordem = exercicio.Ordem.ToString(); }

                if (exercicio.ID_Grupo == id_grupo)
                {
                    dataGridViewExercicios.Rows.Add(exercicio.ID_Exercicio, ordem, exercicio.Descricao, exercicio.Peso, exercicio.Series, exercicio.Tipo, exercicio.Ajuste, exercicio.Check);
                }
            }

            try
            {
                dataGridViewExercicios.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewExercicios.CurrentCell = dataGridViewExercicios.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewExercicios.CurrentRow != null)
                dataGridViewExercicios.CurrentRow.Selected = false;
        }



        private void dataGridViewGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                id_grupo = Convert.ToInt32(dataGridViewGrupos[0, e.RowIndex].Value);

                if (Convert.ToBoolean(dataGridViewGrupos.Rows[e.RowIndex].Cells[2].Value) == true)
                {
                    dataGridViewGrupos.Rows[e.RowIndex].Cells[2].Value = false;

                    comandos.RemoverGrupoDoTreino(id_treino, id_grupo);

                    AtualizarDataGridExercicios();
                }
                else
                {
                    dataGridViewGrupos.Rows[e.RowIndex].Cells[2].Value = true;

                    comandos.AdicionarGrupoAoTreino(id_treino, id_grupo);
                }

                AtualizarDataGridGrupos();
            }
        }

        private void dataGridViewExercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_exercicio = Convert.ToInt32(dataGridViewExercicios.Rows[e.RowIndex].Cells[0].Value);

            if (e.ColumnIndex == 7 && grupos.Where(x => x.ID_Grupo == id_grupo).Select(x => x.Check).FirstOrDefault())
            {
                id_exercicio = Convert.ToInt32(dataGridViewExercicios[0, e.RowIndex].Value);

                if (Convert.ToBoolean(dataGridViewExercicios.Rows[e.RowIndex].Cells[7].Value) == true)
                {
                    dataGridViewExercicios.Rows[e.RowIndex].Cells[7].Value = false;

                    ordem = Convert.ToInt32(dataGridViewExercicios[1, e.RowIndex].Value);

                    if (ordem != 0)
                    {
                        this.id_exercicio = exercicios.Where(x => x.Ordem == ordem && x.ID_Grupo == id_grupo).Select(x => x.ID_Exercicio).FirstOrDefault();

                        comandos.RemoverExercicioDoTreino(id_treino, this.id_exercicio);

                        int i = ordem;
                        int id_exercicio;
                        int nova_ordem;

                        foreach (Exercicio exercicio in exercicios)
                        {
                            if (exercicio.Ordem > ordem && exercicio.ID_Grupo == id_grupo)
                            {
                                nova_ordem = i;
                                i++;
                                id_exercicio = exercicios.Where(x => x.Ordem == exercicio.Ordem && x.ID_Grupo == id_grupo).Select(x => x.ID_Exercicio).FirstOrDefault();

                                comandos.AlterarOrdemDoExercicio(id_exercicio, id_treino, id_grupo, nova_ordem);
                            }
                        }
                    }


                    foreach (Exercicio exercicio in exercicios)
                    {
                        if (exercicio.ID_Exercicio == id_exercicio) { exercicio.Check = false; }
                    }
                }
                else
                {
                    dataGridViewExercicios.Rows[e.RowIndex].Cells[7].Value = true;

                    Exercicio exercicio = new Exercicio();

                    exercicio.ID_Grupo = id_grupo;
                    exercicio.ID_Exercicio = id_exercicio;
                    exercicio.Tipo = dataGridViewExercicios.Rows[e.RowIndex].Cells[5].Value.ToString();
                    exercicio.Ajuste = dataGridViewExercicios.Rows[e.RowIndex].Cells[6].Value.ToString();
                    exercicio.Series = dataGridViewExercicios.Rows[e.RowIndex].Cells[4].Value.ToString();                
                    exercicio.Peso = dataGridViewExercicios.Rows[e.RowIndex].Cells[3].Value.ToString();                

                    comandos.AdicionarExercicioAoTreino(id_treino, exercicio);

                    foreach (Exercicio Exercicio in exercicios)
                    {
                        if (Exercicio.ID_Exercicio == id_exercicio) { Exercicio.Check = true; }
                    }
                }

                AtualizarDataGridExercicios();
            }
        }

        private void dataGridViewGrupos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id_grupo = Convert.ToInt32(dataGridViewGrupos[0, e.RowIndex].Value);
                AtualizarDataGridExercicios();
            }
        }

        private void dataGridViewGrupos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewGrupos.Rows[e.RowIndex];

            if (e.ColumnIndex == 2)
            {
                bool check = Convert.ToBoolean(dataGridViewGrupos[e.ColumnIndex, e.RowIndex].Value);

                if (!check)
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    linha.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.Black;
                    linha.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dataGridViewExercicios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewExercicios.Rows[e.RowIndex];

            if (e.ColumnIndex == 7)
            {
                bool check = Convert.ToBoolean(dataGridViewExercicios[e.ColumnIndex, e.RowIndex].Value);

                if (!check)
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    linha.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
                else
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.Black;
                    linha.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dataGridViewExercicios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
                {
                    bool check = Convert.ToBoolean(dataGridViewExercicios[7, e.RowIndex].Value);

                    if (check)
                    {
                        Exercicio exercicio = new Exercicio();

                        exercicio.ID_Exercicio = Convert.ToInt32(dataGridViewExercicios.Rows[e.RowIndex].Cells[0].Value);
                        exercicio.Peso = dataGridViewExercicios.Rows[e.RowIndex].Cells[3].Value.ToString();
                        exercicio.Series = dataGridViewExercicios.Rows[e.RowIndex].Cells[4].Value.ToString();
                        exercicio.Tipo = dataGridViewExercicios.Rows[e.RowIndex].Cells[5].Value.ToString();
                        exercicio.Ajuste = dataGridViewExercicios.Rows[e.RowIndex].Cells[6].Value.ToString();

                        comandos.EditarConfiguracoesDoExercicio(exercicio, id_treino);
                    }
                }
            }
            catch { }

        }

        private void dataGridViewExercicios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewExercicios.IsCurrentCellDirty)
            {
                dataGridViewExercicios.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {

            if (ordem == 0) { }
            else if (ordem == 1) { }
            else if (exercicios.Where(x => x.ID_Grupo == id_grupo && x.Check == true).ToList().Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewExercicios.CurrentRow != null)
                {
                    primeira_linha = dataGridViewExercicios.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewExercicios.CurrentRow.Index;
                }

                int nova_ordem;
                int id_exercicio;

                foreach (Exercicio exercicio in exercicios)
                {
                    if (exercicio.Ordem == ordem - 1 && exercicio.ID_Grupo == id_grupo)
                    {
                        id_exercicio = exercicios.Where(x => x.Ordem == ordem - 1 && x.ID_Grupo == id_grupo).Select(x => x.ID_Exercicio).FirstOrDefault();
                        nova_ordem = ordem;
                        comandos.AlterarOrdemDoExercicio(id_exercicio, id_treino, id_grupo, nova_ordem);
                    }
                    else if (exercicio.Ordem == ordem && exercicio.ID_Grupo == id_grupo)
                    {
                        id_exercicio = exercicios.Where(x => x.Ordem == ordem && x.ID_Grupo == id_grupo).Select(x => x.ID_Exercicio).FirstOrDefault();
                        nova_ordem = ordem - 1;
                        comandos.AlterarOrdemDoExercicio(id_exercicio, id_treino, id_grupo, nova_ordem);
                    }
                }

                AtualizarDataGridExercicios();

                try
                {
                    dataGridViewExercicios.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewExercicios.CurrentCell = dataGridViewExercicios.Rows[linha_selecionada - 1].Cells[0];
                }
                catch { }

                ordem = ordem - 1;
            }

        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == exercicios.Count) { }
            else if (exercicios.Where(x => x.ID_Grupo == id_grupo && x.Check == true).ToList().Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewExercicios.CurrentRow != null)
                {
                    primeira_linha = dataGridViewExercicios.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewExercicios.CurrentRow.Index;
                }

                int id_exercicio;
                int nova_ordem;

                foreach (Exercicio exercicio in exercicios)
                {
                    if (exercicio.Ordem == ordem && exercicio.ID_Grupo == id_grupo)
                    {
                        nova_ordem = ordem + 1;
                        id_exercicio = exercicios.Where(x => x.Ordem == ordem && x.ID_Grupo == id_grupo).Select(x => x.ID_Exercicio).FirstOrDefault();
                        comandos.AlterarOrdemDoExercicio(id_exercicio, id_treino, id_grupo, nova_ordem);
                    }
                    else if (exercicio.Ordem == ordem + 1 && exercicio.ID_Grupo == id_grupo)
                    {
                        id_exercicio = exercicios.Where(x => x.Ordem == ordem + 1 && x.ID_Grupo == id_grupo).Select(x => x.ID_Exercicio).FirstOrDefault();
                        nova_ordem = ordem;
                        comandos.AlterarOrdemDoExercicio(id_exercicio, id_treino, id_grupo, nova_ordem);
                    }
                }

                AtualizarDataGridExercicios();

                try
                {
                    dataGridViewExercicios.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewExercicios.CurrentCell = dataGridViewExercicios.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }

                ordem = ordem + 1;
            }
        }

        private void dataGridViewExercicios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewExercicios[1, e.RowIndex].Value);
                    id_exercicio = exercicios.Where(x => x.Ordem == ordem).Select(x => x.ID_Exercicio).FirstOrDefault();
                }
            }
            catch
            {
                ordem = 0;
            }
        }
    }
}
