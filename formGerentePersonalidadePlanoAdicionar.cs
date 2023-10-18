using MarbaSoftware;
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
    public partial class formGerentePersonalidadePlanoAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public Plano Projeto = new Plano();

        public bool cadastramento;
        public int id_projeto;

        int ordem_etapa;
        int ordem_custo;

        public formGerentePersonalidadePlanoAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGerentePersonalidadePlanoAdicionar(int ID_Projeto)
        {
            InitializeComponent();
            cadastramento = false;
            id_projeto = ID_Projeto;
        }

        private void formGestaoProjeto_Load(object sender, EventArgs e)
        {
            altura_total = Height;
            painel_descricao = panelDescricao.Height;
            text_descricao = textBoxDescricao.Height;
            painel_que = panelQue.Height;
            text_que = textBoxQue.Height;
            painel_porque = panelPorQue.Height;
            text_porque = textBoxPorQue.Height;
            painel_onde = panelOnde.Height;
            text_onde = textBoxOnde.Height;

            textBoxDescricao.TextChanged += new EventHandler(textBox_TextChanged);
            textBoxQue.TextChanged += new EventHandler(textBox_TextChanged);
            textBoxPorQue.TextChanged += new EventHandler(textBox_TextChanged);
            textBoxOnde.TextChanged += new EventHandler(textBox_TextChanged);

            textBoxDescricao.Multiline = true;
            textBoxDescricao.ScrollBars = ScrollBars.None;
            textBoxQue.Multiline = true;
            textBoxQue.ScrollBars = ScrollBars.None;
            textBoxPorQue.Multiline = true;
            textBoxPorQue.ScrollBars = ScrollBars.None;
            textBoxOnde.Multiline = true;
            textBoxOnde.ScrollBars = ScrollBars.None;

            textBoxDescricao.Text = "Informe a descrição do projeto";
            textBoxQue.Text = "Descreva os detalhes do que deve ser realizado neste projeto";
            textBoxPorQue.Text = "Descreva o motivo pelo qual os colaboradores deverão se empenhar neste projeto";
            textBoxOnde.Text = "Em que local as ações serão realizadas?";

            if (cadastramento)
            {
                Projeto.Etapas = new List<Etapa>();
                Projeto.Custos = new List<Custo>();
                Projeto.Checklist = new List<Checklist>();


                textBoxDescricao.ForeColor = Color.DarkGray;
                textBoxQue.ForeColor = Color.DarkGray;
                textBoxPorQue.ForeColor = Color.DarkGray;
                textBoxOnde.ForeColor = Color.DarkGray;
            }
            else
            {
                Projeto = comandos.TrazerInformacoesDoPlanoDeAcao(id_projeto);
                textBoxDescricao.Text = Projeto.Descricao;
                textBoxQue.Text = Projeto.O_Que;
                textBoxPorQue.Text = Projeto.Por_Que;
                textBoxOnde.Text = Projeto.Onde;


                textBoxDescricao.ForeColor = Color.Black;
                textBoxQue.ForeColor = Color.Black;
                textBoxPorQue.ForeColor = Color.Black;
                textBoxOnde.ForeColor = Color.Black;
            }


            AtualizarDataGridEtapas();
            AtualizarDataGridCustos();

            textBoxDescricao.SelectionStart = textBoxDescricao.Text.Length;
            textBoxQue.SelectionStart = textBoxQue.Text.Length;
            textBoxDescricao.Focus();
        }

        #region Texto e Redimensionamento

        int altura_total;
        int painel_descricao;
        int text_descricao;
        int painel_que;
        int text_que;
        int painel_porque;
        int text_porque;
        int painel_onde;
        int text_onde;

        private void RedimensionarPanelDescricao(TextBox text)
        {
            int largura_original = text.ClientSize.Width;
            int altura_original = text.Font.Height;

            Size tamanho = TextRenderer.MeasureText(text.Text, text.Font);

            int largura_texto = tamanho.Width;
            int altura_texto = tamanho.Height;

            if (altura_texto == 0) { altura_texto = altura_original; }


            int linhas = (largura_texto / largura_original) + 1;
            int altura_final = altura_texto * linhas;

            text.ClientSize = new Size(largura_original, altura_final);

            int diferenca = text.Height - text_descricao;

            if (diferenca > 0)
            {
                Height = altura_total + diferenca;
                panelDescricao.Height = painel_descricao + diferenca;
            }
            else
            {
                 Height = altura_total;
                panelDescricao.Height = painel_descricao;
            }
            
        }

        private void RedimensionarPainelQue(TextBox text)
        {
            int largura_original = text.ClientSize.Width;
            int altura_original = text.Font.Height;

            Size tamanho = TextRenderer.MeasureText(text.Text, text.Font);

            int largura_texto = tamanho.Width;
            int altura_texto = tamanho.Height;

            if (altura_texto == 0) { altura_texto = altura_original; }


            int linhas = (largura_texto / largura_original) + 1;
            int altura_final = altura_texto * linhas;

            text.ClientSize = new Size(largura_original, altura_final);

            int diferenca = text.Height - text_que;

            if (diferenca > 0)
            {
                panelQue.Height = painel_que + diferenca;
            }
            else
            {
                panelQue.Height = painel_que;
            }

        }

        private void RedimensionarPainelPorQue(TextBox text)
        {
            int largura_original = text.ClientSize.Width;
            int altura_original = text.Font.Height;

            Size tamanho = TextRenderer.MeasureText(text.Text, text.Font);

            int largura_texto = tamanho.Width;
            int altura_texto = tamanho.Height;

            if (altura_texto == 0) { altura_texto = altura_original; }


            int linhas = (largura_texto / largura_original) + 1;
            int altura_final = altura_texto * linhas;

            text.ClientSize = new Size(largura_original, altura_final);

            int diferenca = text.Height - text_porque;

            if (diferenca > 0)
            {
                panelPorQue.Height = painel_porque + diferenca;
            }
            else
            {
                panelPorQue.Height = painel_porque;
            }

        }

        private void RedimensionarPainelOnde(TextBox text)
        {
            int largura_original = text.ClientSize.Width;
            int altura_original = text.Font.Height;

            Size tamanho = TextRenderer.MeasureText(text.Text, text.Font);

            int largura_texto = tamanho.Width;
            int altura_texto = tamanho.Height;

            if (altura_texto == 0) { altura_texto = altura_original; }


            int linhas = (largura_texto / largura_original) + 1;
            int altura_final = altura_texto * linhas;

            text.ClientSize = new Size(largura_original, altura_final);

            int diferenca = text.Height - text_onde;

            if (diferenca > 0)
            {
                panelOnde.Height = painel_onde + diferenca;
            }
            else
            {
                panelOnde.Height = painel_onde;
            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Name == "textBoxDescricao")
            {
                RedimensionarPanelDescricao(text);
            }
            else if (text.Name == "textBoxQue")
            {
                RedimensionarPainelQue(text);
            }
            else if (text.Name == "textBoxPorQue")
            {
                RedimensionarPainelPorQue(text);
            }
            else if (text.Name == "textBoxOnde")
            {
                RedimensionarPainelOnde(text);
            }
        }

        private void textBoxPorQue_Enter(object sender, EventArgs e)
        {
            if (textBoxPorQue.Text == "Descreva o motivo pelo qual os colaboradores deverão se empenhar neste projeto")
            {
                textBoxPorQue.Clear();
            }

            textBoxPorQue.ForeColor = Color.Black;
        }

        private void textBoxPorQue_Leave(object sender, EventArgs e)
        {
            if (textBoxPorQue.Text == string.Empty)
            {
                textBoxPorQue.Text = "Descreva o motivo pelo qual os colaboradores deverão se empenhar neste projeto";
                textBoxPorQue.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxQue_Enter(object sender, EventArgs e)
        {
            if (textBoxQue.Text == "Descreva os detalhes do que deve ser realizado neste projeto")
            {
                textBoxQue.Clear();
            }

            textBoxQue.ForeColor = Color.Black;
        }

        private void textBoxQue_Leave(object sender, EventArgs e)
        {
            if (textBoxQue.Text == string.Empty)
            {
                textBoxQue.Text = "Descreva os detalhes do que deve ser realizado neste projeto";
                textBoxQue.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxOnde_Enter(object sender, EventArgs e)
        {
            if (textBoxOnde.Text == "Em que local as ações serão realizadas?")
            {
                textBoxOnde.Clear();
            }

            textBoxOnde.ForeColor = Color.Black;
        }

        private void textBoxOnde_Leave(object sender, EventArgs e)
        {
            if (textBoxOnde.Text == string.Empty)
            {
                textBoxOnde.Text = "Em que local as ações serão realizadas?";
                textBoxOnde.ForeColor = Color.DarkGray;
            }
        }

        #endregion

        private void AtualizarDataGridEtapas()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewEtapas.CurrentRow != null)
            {
                primeira_linha = dataGridViewEtapas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewEtapas.CurrentRow.Index;
            }

            dataGridViewEtapas.Rows.Clear();

            Projeto.Etapas = Projeto.Etapas.OrderBy(x => x.Ordem).ToList();

            if (Projeto.Etapas.Count > 0)
            {
                labelEtapas.Visible = false;
                dataGridViewEtapas.ColumnHeadersVisible = true;

                foreach (Etapa Etapa in Projeto.Etapas)
                {
                    dataGridViewEtapas.Rows.Add(Etapa.Ordem, Etapa.O_Que, Etapa.Prazo);
                }
            }
            else
            {
                dataGridViewEtapas.ColumnHeadersVisible = false;
                labelEtapas.Visible = true;
            }


            try
            {
                dataGridViewEtapas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewEtapas.CurrentCell = dataGridViewEtapas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewEtapas.CurrentRow != null)
                dataGridViewEtapas.CurrentRow.Selected = false;
        }

        public void AtualizarEtapas()
        {
            Projeto.Etapas = comandos.AtualizarEtapasDoPlano(id_projeto);
        }

        public void AtualizarChecklist()
        {
            Projeto.Checklist = comandos.AtualizarCheckListDoPlano(id_projeto);
        }

        public void AtualizarCustos()
        {
            Projeto.Custos = comandos.AtualizarCustosDoPlano(id_projeto);
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {
            if (ordem_etapa == 0) { }
            else if (ordem_etapa == 1) { }
            else if (Projeto.Etapas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewEtapas.CurrentRow != null)
                {
                    primeira_linha = dataGridViewEtapas.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewEtapas.CurrentRow.Index;
                }

                string descricao_cima = Projeto.Etapas.Where(x => x.Ordem == ordem_etapa - 1).Select(i => i.Descricao).FirstOrDefault();
                string descricao_baixo = Projeto.Etapas.Where(x => x.Ordem == ordem_etapa).Select(i => i.Descricao).FirstOrDefault();

                int nova_ordem;

                if (cadastramento)
                {
                    foreach (Etapa etapa in Projeto.Etapas)
                    {
                        if (etapa.Descricao == descricao_baixo && etapa.Ordem == ordem_etapa)
                        {
                            etapa.Ordem = ordem_etapa - 1;
                        }
                        else if (etapa.Descricao == descricao_cima && etapa.Ordem == ordem_etapa - 1)
                        {
                            etapa.Ordem = ordem_etapa;
                        }
                    }
                }
                else
                {
                    foreach (Etapa etapa in Projeto.Etapas)
                    {
                        if (etapa.Descricao == descricao_baixo && etapa.Ordem == ordem_etapa)
                        {
                            nova_ordem = ordem_etapa - 1;
                            comandos.AlterarOrdemDoChecklist(Projeto.ID_Projeto, nova_ordem);
                        }
                        else if (etapa.Descricao == descricao_cima && etapa.Ordem == ordem_etapa - 1)
                        {
                            nova_ordem = ordem_etapa;
                            comandos.AlterarOrdemDoChecklist(Projeto.ID_Projeto, nova_ordem);
                        }
                    }

                    AtualizarEtapas();
                }

                AtualizarDataGridEtapas();

                dataGridViewEtapas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewEtapas.CurrentCell = dataGridViewEtapas.Rows[linha_selecionada - 1].Cells[0];
                ordem_etapa = ordem_etapa - 1;
            }
        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (ordem_etapa == 0) { }
            else if (ordem_etapa == Projeto.Etapas.Count) { }
            else if (Projeto.Etapas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewEtapas.CurrentRow != null)
                {
                    primeira_linha = dataGridViewEtapas.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewEtapas.CurrentRow.Index;
                }

                string descricao_cima = Projeto.Etapas.Where(x => x.Ordem == ordem_etapa).Select(i => i.Descricao).FirstOrDefault();
                string descricao_baixo = Projeto.Etapas.Where(x => x.Ordem == ordem_etapa + 1).Select(i => i.Descricao).FirstOrDefault();

                int nova_ordem;

                if (cadastramento)
                {
                    foreach (Etapa etapa in Projeto.Etapas)
                    {
                        if (etapa.Descricao == descricao_baixo && etapa.Ordem == ordem_etapa + 1)
                        {
                            etapa.Ordem = ordem_etapa;
                        }
                        else if (etapa.Descricao == descricao_cima && etapa.Ordem == ordem_etapa)
                        {
                            etapa.Ordem = ordem_etapa + 1;
                        }
                    }
                }
                else
                {
                    foreach (Etapa etapa in Projeto.Etapas)
                    {
                        if (etapa.Descricao == descricao_baixo && etapa.Ordem == ordem_etapa + 1)
                        {
                            nova_ordem = ordem_etapa;
                            comandos.AlterarOrdemDaEtapa(etapa.ID_Etapa, nova_ordem);
                        }
                        else if (etapa.Descricao == descricao_cima && etapa.Ordem == ordem_etapa)
                        {
                            nova_ordem = ordem_etapa + 1;
                            comandos.AlterarOrdemDaEtapa(etapa.ID_Etapa, nova_ordem);
                        }
                    }

                    AtualizarEtapas();
                }

                AtualizarDataGridEtapas();

                try
                {
                    dataGridViewEtapas.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewEtapas.CurrentCell = dataGridViewEtapas.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }

                ordem_etapa = ordem_etapa + 1;
            }
        }

        private void dataGridViewEtapas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    ordem_etapa = Convert.ToInt32(dataGridViewEtapas[0, e.RowIndex].Value);
                }
                catch
                {
                    ordem_etapa = 0;
                }
            }
            else
            {
                ordem_etapa = 0;
            }
        }

        private void dataGridViewCustos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    ordem_custo = Convert.ToInt32(dataGridViewCustos[0, e.RowIndex].Value);
                }
                catch
                {
                    ordem_custo = 0;
                }
            }
            else
            {
                ordem_custo = 0;
            }
        }

        private void AtualizarDataGridCustos()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewCustos.CurrentRow != null)
            {
                primeira_linha = dataGridViewCustos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewCustos.CurrentRow.Index;
            }

            dataGridViewCustos.Rows.Clear();

            foreach (Custo Custo in Projeto.Custos)
            {
                dataGridViewCustos.Rows.Add(Custo.Ordem, Custo.Descricao, Custo.Valor.ToString("C"), Custo.Categoria);
            }

            if (Projeto.Custos.Count > 0)
            {
                dataGridViewCustos.ColumnHeadersVisible = true;
            }
            else
            {
                dataGridViewCustos.ColumnHeadersVisible = false;
            }

            try
            {
                dataGridViewCustos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewCustos.CurrentCell = dataGridViewCustos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewCustos.CurrentRow != null)
                dataGridViewCustos.CurrentRow.Selected = false;
        }

        private void buttonEtapa_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadePlanoEtapas etapas = new formGerentePersonalidadePlanoEtapas(this);
            etapas.ShowDialog();
            AtualizarDataGridEtapas();
        }

        private void dataGridViewEtapas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem_etapa = Convert.ToInt32(dataGridViewEtapas[0, e.RowIndex].Value);
                    Etapa etapa = Projeto.Etapas.Where(x => x.Ordem == ordem_etapa).FirstOrDefault();

                    formGerentePersonalidadePlanoEtapas etapas = new formGerentePersonalidadePlanoEtapas(this, etapa);
                    etapas.ShowDialog();
                    AtualizarDataGridEtapas();
                }
            }
            catch
            {
                ordem_etapa = 0;
            }
        }

        private void textBoxDescricao_Enter(object sender, EventArgs e)
        {
            if (textBoxDescricao.Text == "Informe a descrição do projeto")
            {
                textBoxDescricao.Clear();
            }

            textBoxDescricao.ForeColor = Color.Black;
        }

        private void textBoxDescricao_Leave(object sender, EventArgs e)
        {
            if (textBoxDescricao.Text == string.Empty)
            {
                textBoxDescricao.Text = "Informe a descrição do projeto";
                textBoxDescricao.ForeColor = Color.DarkGray;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem_etapa != 0)
            {
                if (cadastramento)
                {
                    Projeto.Etapas.RemoveAll(x => x.Ordem == ordem_etapa);

                    int ordem = 1;

                    foreach (Etapa etapa in Projeto.Etapas)
                    {
                        etapa.Ordem = ordem;
                        ordem++;
                    }
                }
                else
                {
                    int id_etapa = Projeto.Etapas.Where(x => x.Ordem == ordem_etapa).Select(x => x.ID_Etapa).FirstOrDefault();
                    comandos.ApagarEtapaDoPlanoDeAcao(id_etapa);
                    comandos.ReordenarEtapasDoPlano(Projeto.ID_Projeto);
                    AtualizarEtapas();
                    AtualizarDataGridEtapas();
                }
            }
        }

        private void apagarCustoMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem_custo != 0)
            {
                if (cadastramento)
                {
                    Projeto.Custos.RemoveAll(x => x.Ordem == ordem_custo);

                    int ordem = 1;

                    foreach (Custo custo in Projeto.Custos)
                    {
                        custo.Ordem = ordem;
                        ordem++;
                    }
                }
                else
                {
                    int id_custo = Projeto.Custos.Where(x => x.Ordem == ordem_custo).Select(x => x.ID).FirstOrDefault();
                    comandos.ApagarCustoDoPlanoDeAcao(id_custo);
                    comandos.ReordenarCustosDoPlano(Projeto.ID_Projeto);
                    AtualizarCustos();
                }

                AtualizarDataGridCustos();
            }
        }

        private void buttonCusto_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadePlanoCustos custos = new formGerentePersonalidadePlanoCustos(this);
            custos.ShowDialog();
            AtualizarDataGridCustos();
        }

        private void dataGridViewCustos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem_custo = Convert.ToInt32(dataGridViewCustos[0, e.RowIndex].Value);
                    Custo custo = Projeto.Custos.Where(x => x.Ordem == ordem_custo).FirstOrDefault();

                    formGerentePersonalidadePlanoCustos custos = new formGerentePersonalidadePlanoCustos(this, custo);
                    custos.ShowDialog();
                    AtualizarDataGridCustos();
                }
            }
            catch
            {

            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string o_que = textBoxQue.Text;
            string porque = textBoxPorQue.Text;
            string onde = textBoxOnde.Text;

            if (descricao == "Informe a descrição do projeto")
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (o_que == "Descreva os detalhes do que deve ser realizado neste projeto")
            {
                MessageBox.Show("Informe o que deve ser feito para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (porque == "Descreva o motivo pelo qual os colaboradores deverão se empenhar neste projeto")
            {
                MessageBox.Show("Informe o motivo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (onde == "Em que local as ações serão realizadas?")
            {
                MessageBox.Show("Informe o local para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Projeto.Etapas.Count == 0)
            {
                MessageBox.Show("Não é possível salvar um plano de ação sem nenhuma etapa!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Projeto.Descricao = descricao;
                Projeto.O_Que = o_que;
                Projeto.Por_Que = porque;
                Projeto.Onde = onde;

                if (cadastramento)
                {
                    comandos.RegistrarPlanoDeAcao(Projeto);
                }
                else
                {
                    comandos.EditarPlanoDeAcao(Projeto);
                }

                Dispose();
            }
        }

    }
}
