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
    public partial class formGerentePersonalidade : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        DateTime Atual = new DateTime();
        DateTime Dia1 = new DateTime();

        CultureInfo cultura = new CultureInfo("pt-BR");
        DateTimeFormatInfo formato = new DateTimeFormatInfo();

        List<Tarefa_Semanal> tarefas = new List<Tarefa_Semanal>();
        List<Tarefa_Semanal> tarefas_disponiveis = new List<Tarefa_Semanal>();

        string exibicao;
        string tipo;

        Tarefa_Semanal tarefa = new Tarefa_Semanal();

        int id_tarefa;

        bool arrastar;
        bool atualizar_listas;

        public formGerentePersonalidade()
        {
            InitializeComponent();
        }

        private void formGerenteGerenciamentoPessoal_Load(object sender, EventArgs e)
        {
            List<string> tipos = comandos.TrazerTipos();
            foreach (string x in tipos) { comboBoxTipo.Items.Add(x); }

            comboBoxTipo.SelectedIndex = -1;

            comboBoxTipo.DropDownHeight = 120;

            tipo = comandos.ObterValorDoParametroDeTextoPeloUsuario("Tipo de exibição");
            comboBoxTipo.Text = tipo;

            formato = cultura.DateTimeFormat;

            Atual = DateTime.Now;

            AtualizarDatas();
            AtualizarListas();

            AplicarTema();

            menuStrip1.Focus();

            comboBoxExibicao.Text = comandos.ObterValorDoParametroDeTextoPeloUsuario("Exibição do dia no planejamento semanal");

            atualizar_listas = true;
        }

        private void AplicarTema()
        {
            Font fonte = new Font("Georgia", 8, FontStyle.Bold, GraphicsUnit.Point);


            buttonMissao.ForeColor = Program.tema.Cor_Principal;
            buttonPapeis.ForeColor = Program.tema.Cor_Principal;
            buttonSemanal.ForeColor = Program.tema.Cor_Principal;
            buttonMetas.ForeColor = Program.tema.Cor_Principal;
            buttonIdeias.ForeColor = Program.tema.Cor_Principal;
            buttonPlano.ForeColor = Program.tema.Cor_Principal;
            buttonAddDiaria.ForeColor = Program.tema.Cor_Principal;
            buttonDiarias.ForeColor = Program.tema.Cor_Principal;

            int r = Program.tema.Cor_Secundaria.R + 50; 
            int g = Program.tema.Cor_Secundaria.G + 50; ;
            int b = Program.tema.Cor_Secundaria.B + 50; ;

            if (r > 255) { r = 255; }
            if (g > 255) { g = 255; }
            if (b > 255) { b = 255; }

            tableLayoutPanel3.BackColor = Color.FromArgb(r, g, b);

            buttonMissao.Font = fonte;
            buttonPapeis.Font = fonte;
            buttonSemanal.Font = fonte;
            buttonMetas.Font = fonte;
            buttonIdeias.Font = fonte;
            buttonPlano.Font = fonte;
            buttonAddDiaria.Font = fonte;
            buttonDiarias.Font = fonte;            
        }

        private void AlterarExibicao()
        {
            if (exibicao == "Dia útil")
            {
                foreach (DataGridViewRow linha in dataGridPlanejamento.Rows)
                {
                    if (linha.Index <= 4 || linha.Index == 23)
                    {
                        linha.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow linha in dataGridPlanejamento.Rows)
                {
                    linha.Visible = true;
                }
            }
        }



        private void buttonSemanal_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadeTarefaSemanal semanal = new formGerentePersonalidadeTarefaSemanal();
            semanal.ShowDialog();

            comboBoxTipo.Items.Clear();

            List<string> tipos = comandos.TrazerTipos();
            foreach (string x in tipos) { comboBoxTipo.Items.Add(x); }
            comboBoxTipo.Text = tipo;

            AtualizarListas();
        }

        private void AtualizarDatas()
        {
            int dia = Atual.Day;
            int semana = dia / 7;
            if (dia % 7 > 0) { semana++; }

            string mes_ = Atual.ToString(@"MMMM");
            string Mes = mes_.PrimeiraLetraMaiuscula().Substring(0, 3);
            string data = "Semana " + semana + " - " + Mes + "/" + Convert.ToString(Atual.Year);
            labelData.Text = data;

            string dia_da_semana = comandos.PrimeiraLetraMaiuscula(formato.GetDayName(Atual.DayOfWeek));

            if (dia_da_semana == "Domingo") { Dia1 = Atual; }
            else if (dia_da_semana == "Segunda-feira") { Dia1 = Atual.AddDays(-1); }
            else if (dia_da_semana == "Terça-feira") { Dia1 = Atual.AddDays(-2); }
            else if (dia_da_semana == "Quarta-feira") { Dia1 = Atual.AddDays(-3); }
            else if (dia_da_semana == "Quinta-feira") { Dia1 = Atual.AddDays(-4); }
            else if (dia_da_semana == "Sexta-feira") { Dia1 = Atual.AddDays(-5); }
            else if (dia_da_semana == "Sábado") { Dia1 = Atual.AddDays(-6); }

            ColunaDomingo.HeaderText = "Domingo " + Dia1.ToShortDateString().Substring(0, 5);
            ColunaSegunda.HeaderText = "Segunda-feira " + Dia1.AddDays(1).ToShortDateString().Substring(0, 5);
            ColunaTerca.HeaderText = "Terça-feira " + Dia1.AddDays(2).ToShortDateString().Substring(0, 5);
            ColunaQuarta.HeaderText = "Quarta-feira " + Dia1.AddDays(3).ToShortDateString().Substring(0, 5);
            ColunaQuinta.HeaderText = "Quinta-feira " + Dia1.AddDays(4).ToShortDateString().Substring(0, 5);
            ColunaSexta.HeaderText = "Sexta-feira " + Dia1.AddDays(5).ToShortDateString().Substring(0, 5);
            ColunaSabado.HeaderText = "Sábado " + Dia1.AddDays(6).ToShortDateString().Substring(0, 5);

            foreach (DataGridViewColumn coluna in dataGridPlanejamento.Columns)
            {
                string[] partir = coluna.HeaderText.Split(' ');

                if (partir[0] == dia_da_semana)
                {
                    coluna.HeaderCell.Style.BackColor = Color.White;
                    coluna.HeaderCell.Style.Font = new Font("Century", 9, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
        }

        private void CriarMatriz()
        {
            int x;
            int y;
            string hora;

            tarefas.Clear();

            for (x = 1; x <= 7; x++)
            {
                for (y = 0; y <= 23; y++)
                {
                    Tarefa_Semanal tarefa = new Tarefa_Semanal();

                    tarefa.X = x;
                    tarefa.Y = y;

                    if (x == 1) { tarefa.Dia = "Domingo"; }
                    if (x == 2) { tarefa.Dia = "Segunda-feira"; }
                    if (x == 3) { tarefa.Dia = "Terça-feira"; }
                    if (x == 4) { tarefa.Dia = "Quarta-feira"; }
                    if (x == 5) { tarefa.Dia = "Quinta-feira"; }
                    if (x == 6) { tarefa.Dia = "Sexta-feira"; }
                    if (x == 7) { tarefa.Dia = "Sábado"; }

                    if (y <= 9) { hora = "0" + y + ":00"; } else { hora = y.ToString() + ":00"; }

                    tarefa.Data = Convert.ToDateTime(Dia1.AddDays(x - 1).ToShortDateString() + " " +  hora);

                    tarefas.Add(tarefa);
                }
            }
        }

        private void AtualizarPlanejamentoSemanal()
        {
            CriarMatriz();

            string hora;
            comandos.PreencherPlanejamentoSemanal(Dia1, tarefas, tipo);

            dataGridPlanejamento.Rows.Clear();

            for (int y = 0; y <=23; y++)
            {
                if (y <= 9) { hora = "0" + y + ":00"; } else { hora = y.ToString() + ":00"; }

                dataGridPlanejamento.Rows.Add(
                    hora,
                    tarefas.Where(t => t.Y == y && t.X == 1).Select(x => x.Descricao).FirstOrDefault(),
                    tarefas.Where(t => t.Y == y && t.X == 2).Select(x => x.Descricao).FirstOrDefault(),
                    tarefas.Where(t => t.Y == y && t.X == 3).Select(x => x.Descricao).FirstOrDefault(),
                    tarefas.Where(t => t.Y == y && t.X == 4).Select(x => x.Descricao).FirstOrDefault(),
                    tarefas.Where(t => t.Y == y && t.X == 5).Select(x => x.Descricao).FirstOrDefault(),
                    tarefas.Where(t => t.Y == y && t.X == 6).Select(x => x.Descricao).FirstOrDefault(),
                    tarefas.Where(t => t.Y == y && t.X == 7).Select(x => x.Descricao).FirstOrDefault()
                    );
            }

            if (dataGridPlanejamento.CurrentRow != null)
                dataGridPlanejamento.CurrentRow.Selected = false;
        }

        private void AtualizarListaDeAtividadesDisponiveis()
        {
            tarefas_disponiveis = comandos.PreencherPainelDeTarefas(Dia1);

            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewTarefas.CurrentRow != null)
            {
                primeira_linha = dataGridViewTarefas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewTarefas.CurrentRow.Index;
            }

            dataGridViewTarefas.Rows.Clear();

            foreach (Tarefa_Semanal tarefa in tarefas_disponiveis)
            {
                dataGridViewTarefas.Rows.Add(tarefa.ID_Tarefa, tarefa.Descricao, tarefa.ID_Papel);
            }

            try
            {
                dataGridViewTarefas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewTarefas.CurrentCell = dataGridViewTarefas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewTarefas.CurrentRow != null)
                dataGridViewTarefas.CurrentRow.Selected = false;
        }


        private void dataGridPlanejamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridPlanejamento.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.White;
                dataGridPlanejamento.Rows[e.RowIndex].Cells[0].Style.SelectionBackColor = Color.White;

                Font minhafonte = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
                DataGridViewRow linha_estilizada = dataGridPlanejamento.Rows[e.RowIndex];
                linha_estilizada.Height = 30;
                DataGridViewCell celula_estilizada = dataGridPlanejamento.Rows[e.RowIndex].Cells[0];
                celula_estilizada.Style.Font = minhafonte;
            }
            {
                int id_tarefa = tarefas.Where(t => t.X == e.ColumnIndex && t.Y == e.RowIndex).Select(t => t.ID_Tarefa).FirstOrDefault();

                if (id_tarefa != 0)
                {
                    Color cor = tarefas.Where(x => x.ID_Tarefa == id_tarefa).Select(x => x.Cor).FirstOrDefault();
                    dataGridPlanejamento[e.ColumnIndex, e.RowIndex].Style.BackColor = cor;
                    dataGridPlanejamento[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = cor;;
                }
            }
        }


        bool pintar_celula;

        private void dataGridPlanejamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pintar_celula = true;
        }


        private void buttonAddDiaria_Click(object sender, EventArgs e)
        {
            formTarefasDoDia tarefas = new formTarefasDoDia();
            tarefas.ShowDialog();
        }

        private void pictureBoxAnterior_Click(object sender, EventArgs e)
        {
            Atual = Atual.AddDays(-7);
            AtualizarDatas();
            AtualizarPlanejamentoSemanal();
            AlterarExibicao();
        }

        private void pictureBoxProximo_Click(object sender, EventArgs e)
        {
            Atual = Atual.AddDays(7);
            AtualizarDatas();
            AtualizarPlanejamentoSemanal();
            AlterarExibicao();
        }

        private void buttonPapeis_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadePapeis papeis = new formGerentePersonalidadePapeis(Dia1);
            papeis.ShowDialog();
        }

        private void comboBoxPapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            exibicao = comboBoxExibicao.Text;

            Parametro parametro = new Parametro { Tipo = "Texto", Descricao = "Exibição do dia no planejamento semanal", Valor = exibicao };
            comandos.EditarParametro(parametro);
            AlterarExibicao();
        }

        private void dataGridPlanejamento_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (pintar_celula)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DestacarBordasDasCelulasSeparadas(e);
                }
            }

            pintar_celula = false;
        }

        private void DestacarBordasDasCelulasSeparadas(DataGridViewCellPaintingEventArgs e)
        {

            if (dataGridPlanejamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                using (Pen p = new Pen(Color.DarkGoldenrod, 2))
                {
                    Rectangle rect = e.CellBounds;
                    rect.Width -= 2;
                    rect.Height -= 2;
                    e.Graphics.DrawRectangle(p, rect);
                }
                e.Handled = true;
            }

        }

        private void formGerentePersonalidade_Resize(object sender, EventArgs e)
        {
            panelLateral.Width = this.Width / 5;
        }

        private void dataGridViewTarefas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                try
                {
                    int id_papel = Convert.ToInt32(dataGridViewTarefas[2, e.RowIndex].Value);

                    if (id_papel != 0)
                    {
                        Color cor = tarefas_disponiveis.Where(x => x.ID_Papel == id_papel).Select(x => x.Cor).FirstOrDefault();
                        dataGridViewTarefas[e.ColumnIndex, e.RowIndex].Style.BackColor = cor;
                        dataGridViewTarefas[e.ColumnIndex, e.RowIndex].Style.SelectionBackColor = cor; ;
                    }
                }
                catch { }

            }
        }


        #region Drag e Drop

        private void AtualizarListas()
        {
            AtualizarPlanejamentoSemanal();
            AtualizarListaDeAtividadesDisponiveis();
            AlterarExibicao();
        }

        private void dataGridViewTarefas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    arrastar = true;
                }
            }

            try
            {
                int ID_Tarefa = Convert.ToInt32(dataGridViewTarefas.Rows[e.RowIndex].Cells[0].Value);
                int ID_Papel = Convert.ToInt32(dataGridViewTarefas.Rows[e.RowIndex].Cells[2].Value);

                tarefa = tarefas_disponiveis.Where(x => x.ID_Tarefa == ID_Tarefa && x.ID_Papel == ID_Papel).FirstOrDefault();
                id_tarefa = ID_Tarefa;
            }
            catch { tarefa = new Tarefa_Semanal(); }
        }

        private void dataGridViewTarefas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewTarefas.CurrentCell = dataGridViewTarefas.Rows[e.RowIndex].Cells[0];
            }
            catch { }

            try
            {
                if (arrastar)
                {
                    Label label = new Label();
                    int ID_Tarefa = Convert.ToInt32(dataGridViewTarefas.Rows[e.RowIndex].Cells[0].Value);
                    int ID_Papel = Convert.ToInt32(dataGridViewTarefas.Rows[e.RowIndex].Cells[2].Value);

                    tarefa = tarefas_disponiveis.Where(x => x.ID_Tarefa == ID_Tarefa && x.ID_Papel == ID_Papel).FirstOrDefault();

                    label.DoDragDrop("tarefa", DragDropEffects.Copy);

                    arrastar = false;
                }
            } 
            catch { }
        }

        bool adicionar_tarefa;
        bool apagar_tarefa;

        private void dataGridPlanejamento_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
                if (tarefa.ID_Tarefa != 0)
                    adicionar_tarefa = true;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                adicionar_tarefa = false;
            }
        }

        private void dataGridPlanejamento_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    arrastar = true;
                    apagar_tarefa = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    try
                    {
                        id_tarefa = tarefas.Where(t => t.X == e.ColumnIndex && t.Y == e.RowIndex).Select(t => t.ID_Tarefa).FirstOrDefault();
                        tarefa = tarefas.Where(t => t.ID_Tarefa == id_tarefa).FirstOrDefault();
                    }
                    catch
                    {
                        id_tarefa = 0;
                    }
                }
            }
        }

        private void dataGridPlanejamento_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridPlanejamento.CurrentCell = dataGridPlanejamento.Rows[e.RowIndex].Cells[0];
            }
            catch { }

            if (adicionar_tarefa)
            {
                try
                {
                    tarefa.Data = tarefas.Where(t => t.X == e.ColumnIndex && t.Y == e.RowIndex).Select(t => t.Data).FirstOrDefault();

                    if (tarefa.Descricao != null && tarefa.Data != Convert.ToDateTime("01/01/0001 00:00:00"))
                    {
                        comandos.AdicionarTarefaAoPlanejamento(tarefa);
                    }
  
                    AtualizarListas();

                    adicionar_tarefa = false;
                }
                catch { }
            }

            //try
            //{
            //    if (arrastar)
            //    {
            //        Label label = new Label();
            //        tarefa = tarefas.Where(t => t.X == e.ColumnIndex && t.Y == e.RowIndex).FirstOrDefault();

            //        label.DoDragDrop("tarefa", DragDropEffects.Copy);
            //        arrastar = false;
            //    }
            //}
            //catch { }
        }

        private void dataGridViewTarefas_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (apagar_tarefa)
                {
                    comandos.RemoverTarefaDoPlanejamento(tarefa);
                    AtualizarListas();
                    apagar_tarefa = false;
                }

            }
            catch { }
        }

        private void dataGridViewTarefas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_tarefa != 0)
            {
                comandos.ApagarTarefa(tarefa);
                AtualizarListas();
            }
        }

        private void removerDoPlanejamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_tarefa != 0)
            {
                comandos.RemoverTarefaDoPlanejamento(tarefa);
                AtualizarListas();
            }
        }

        private void dataGridViewTarefas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_tarefa = tarefas.Where(t => t.X == e.ColumnIndex && t.Y == e.RowIndex).Select(t => t.ID_Tarefa).FirstOrDefault();
                bool fixa = tarefas.Where(t => t.ID_Tarefa == id_tarefa).Select(x => x.Fixa).FirstOrDefault();

                if (fixa)
                {
                    MessageBox.Show("Não é possível editar tarefas fixas no painel de tarefas.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    formGerentePersonalidadeTarefaSemanal editar = new formGerentePersonalidadeTarefaSemanal(id_tarefa);
                    editar.ShowDialog();
                    AtualizarListas();
                }
            }
            catch
            {
                id_tarefa = 0;
            }
        }

        private void editarAtividadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_tarefa != 0)
                {
                    formGerentePersonalidadeTarefaSemanal editar = new formGerentePersonalidadeTarefaSemanal(id_tarefa);
                    editar.ShowDialog();
                    AtualizarListas();
                }
            }
            catch
            {
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (atualizar_listas)
            {
                tipo = comboBoxTipo.Text;

                Parametro parametro = new Parametro { Tipo = "Texto", Descricao = "Tipo de exibição", Valor = tipo };
                comandos.EditarParametro(parametro);
                AtualizarListas();
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Os registros da semana atual serão sobrepostos.\r\n\r\nDeseja continuar?", "Copiar planejamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                comandos.CopiarPlanejamentoDaSemanaPassada(Dia1);
                AtualizarListas();
            }
        }

        private void organizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelOrganizar.Visible == false)
            {
                AtualizarListaDeAtividadesDisponiveis();

                organizarToolStripMenuItem.Text = "Ocultar painel de tarefas";
                panelLateral.Width = this.Width / 4;
                panelOrganizar.Visible = true;
                panelOrganizar.BringToFront();

                labelMensagem.Left = (panelLateral.Width / 2) - (labelMensagem.Width / 2);
                labelMensagem.BringToFront();

                if (tarefas_disponiveis.Count == 0) { labelMensagem.Visible = true; }
                else { labelMensagem.Visible = false; }
            }
            else
            {
                organizarToolStripMenuItem.Text = "Organizar tarefas";
                panelLateral.Width = this.Width / 5;
                panelOrganizar.Visible = false;
                panelOrganizar.SendToBack();

                labelMensagem.Visible = false;
            }
        }

        private void apagarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("O planejamento semanal será apagado\r\n e essa ação não poderá ser desfeita.\r\n\r\nDeseja continuar?", "Apagar planejamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                comandos.ApagarPlanejamentoAtual(Dia1);
                AtualizarListas();
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteLogins logins = new formGerenteLogins();
            logins.ShowDialog();
        }

        private void exercíciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteTreinamentos treinamentos = new formGerenteTreinamentos();
            treinamentos.ShowDialog();
        }

        private void metasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadeMetas metas = new formGerentePersonalidadeMetas();
            metas.ShowDialog();
        }

        private void cronoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerenteProfissional profissional = new formGerenteProfissional();
            profissional.ShowDialog();
        }

        private void planoDeAcaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGerentePersonalidadePlano plano = new formGerentePersonalidadePlano();
            plano.ShowDialog();
        }
    }
}
