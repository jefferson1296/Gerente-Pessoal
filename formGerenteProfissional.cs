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
    public partial class formGerenteProfissional : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public List<Afazer> afazeres = new List<Afazer>();
        public List<Rotina> rotinas = new List<Rotina>();
        int ordem;
        int id_afazer;
        int id_rotina;
        DateTime data;

        int ordem_rotina;

        public formGerenteProfissional()
        {
            InitializeComponent();
        }

        private void formTelaInicialPrincipalGestaoAfazeres_Load(object sender, EventArgs e)
        {
            data = dateTimePicker.Value;
            AplicarTema();
            AtualizarListas();
        }

        private void AplicarTema()
        {
            labelLista.ForeColor = Program.tema.Cor_Principal;

            buttonAdicionar.BackColor = Program.tema.Cor_Principal;
            buttonAdicionar.ForeColor = Program.tema.Cor_Secundaria;
        }

        private void AtualizarListas()
        {
            AtualizarDataGridAtividades();
            AtualizarDataGridRotinas();
        }

        private void AtualizarDataGridAtividades()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            afazeres = comandos.ListaDeAfazeres(data);
            dataGridViewLista.Rows.Clear();

            foreach (Afazer afazer in afazeres)
            {
                DateTime tempo = Convert.ToDateTime("00:00");
                tempo = tempo.AddMinutes(afazer.Minutos);

                string Tempo = tempo.ToShortTimeString();
                
                if (Tempo == "00:00") { Tempo = string.Empty; }

                dataGridViewLista.Rows.Add(afazer.Ordem, afazer.Descricao, Tempo, afazer.Conclusao);
            }

            if (afazeres.Count == 0) { labelRegistros.Visible = true; }
            else { labelRegistros.Visible = false; }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void AtualizarDataGridRotinas()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewRotinas.CurrentRow != null)
            {
                primeira_linha = dataGridViewRotinas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewRotinas.CurrentRow.Index;
            }

            dataGridViewRotinas.Rows.Clear();

            if (data.Date <= DateTime.Now.Date)
            {
                rotinas = comandos.ListaDeRotinasDoDia(data);
                dataGridViewRotinas.Columns[3].Visible = true;
            }
            else
            {
                rotinas = comandos.ListaDeRotinas(data);
                dataGridViewRotinas.Columns[3].Visible = false;
            }


            foreach (Afazer afazer in rotinas)
            {
                DateTime tempo = Convert.ToDateTime("00:00");
                tempo = tempo.AddMinutes(afazer.Minutos);

                string Tempo = tempo.ToShortTimeString();

                if (Tempo == "00:00") { Tempo = string.Empty; }

                dataGridViewRotinas.Rows.Add(afazer.Ordem, afazer.Descricao, Tempo, afazer.Conclusao);
            }

            if (rotinas.Count == 0) { labelRotinas.Visible = true; }
            else { labelRotinas.Visible = false; }

            try
            {
                dataGridViewRotinas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewRotinas.CurrentCell = dataGridViewRotinas.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewRotinas.CurrentRow != null)
                dataGridViewRotinas.CurrentRow.Selected = false;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            formGerenteProfissionalAdicionar adicionar = new formGerenteProfissionalAdicionar(data);
            adicionar.ShowDialog();
            AtualizarListas();
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                    formGerenteProfissionalAdicionar editar = new formGerenteProfissionalAdicionar(id_afazer, this, false);
                    editar.ShowDialog();
                    AtualizarDataGridAtividades();
                }
            }
            catch { }
        }

        private void dataGridViewLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                    if (e.ColumnIndex == 3)
                    {
                        bool conclusao = !Convert.ToBoolean(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);
                        id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x =>x.ID_Afazer).FirstOrDefault();

                        comandos.AlterarConclusaoDoAfazer(id_afazer, conclusao);


                        AtualizarDataGridAtividades();
                    }
                }
            }
            catch { }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker.Value;
            AtualizarListas();
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);
                    id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                }
            }
            catch 
            {
                ordem = 0;
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                this.id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                comandos.ApagarAfazer(this.id_afazer);

                int i = ordem;
                int id_afazer;
                int nova_ordem;

                foreach (Afazer afazer in afazeres)
                {
                    if (afazer.Ordem > ordem)
                    {                       
                        nova_ordem = i;
                        i++;
                        id_afazer = afazeres.Where(x => x.Ordem == afazer.Ordem).Select(x => x.ID_Afazer).FirstOrDefault();

                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                }

                AtualizarDataGridAtividades();
            }
        }

        private void buttonSubir_Click(object sender, EventArgs e)
        {

            if (ordem == 0) { }
            else if (ordem == 1) { }
            else if (afazeres.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                int nova_ordem;
                int id_afazer;

                foreach (Afazer afazer in afazeres)
                {
                    if (afazer.Ordem == ordem - 1)
                    {
                        id_afazer = afazeres.Where(x => x.Ordem == ordem - 1).Select(x => x.ID_Afazer).FirstOrDefault();
                        nova_ordem = ordem;
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                    else if (afazer.Ordem == ordem)
                    {
                        id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                        nova_ordem = ordem - 1;
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                }

                AtualizarDataGridAtividades();

                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada - 1].Cells[0];

                ordem = ordem - 1;
            }

        }

        private void buttonDescer_Click(object sender, EventArgs e)
        {
            if (ordem == 0) { }
            else if (ordem == afazeres.Count) { }
            else if (afazeres.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewLista.CurrentRow != null)
                {
                    primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewLista.CurrentRow.Index;
                }

                int id_afazer;
                int nova_ordem;

                foreach (Afazer afazer in afazeres)
                {
                    if (afazer.Ordem == ordem)
                    {
                        nova_ordem = ordem + 1;
                        id_afazer = afazeres.Where(x => x.Ordem == ordem).Select(x => x.ID_Afazer).FirstOrDefault();
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                    else if (afazer.Ordem == ordem + 1)
                    {
                        id_afazer = afazeres.Where(x => x.Ordem == ordem + 1).Select(x => x.ID_Afazer).FirstOrDefault();
                        nova_ordem = ordem;
                        comandos.AlterarOrdemDoAfazer(id_afazer, nova_ordem);
                    }
                }

                AtualizarDataGridAtividades();

                try
                {
                    dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }
                ordem = ordem + 1;
            }
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewLista.Rows[e.RowIndex];

            if (e.ColumnIndex == 0)
            {
                int ordem = Convert.ToInt32(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);

                if (ordem > 6)
                {
                    linha.DefaultCellStyle.SelectionForeColor = Color.DarkGray;
                    linha.DefaultCellStyle.ForeColor = Color.DarkGray;
                }
            }

            if (e.ColumnIndex == 3)
            {
                Font fonte = new Font("Arial", 9, FontStyle.Strikeout, GraphicsUnit.Point);

                bool conclusao = Convert.ToBoolean(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);
                
                if (conclusao)
                {
                    linha.DefaultCellStyle.Font = fonte;
                }
            }
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
        }

        private void agendarParaAmanhãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem != 0)
            {
                comandos.AgendarAfazerParaAmanha(id_afazer);
            }
        }

        private void dataGridViewRotinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && data.Date <= DateTime.Now.Date)
                {
                    ordem_rotina = Convert.ToInt32(dataGridViewRotinas[0, e.RowIndex].Value);

                    if (e.ColumnIndex == 3)
                    {
                        bool conclusao = !Convert.ToBoolean(dataGridViewRotinas[e.ColumnIndex, e.RowIndex].Value);
                        id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina).Select(x => x.ID_Rotina).FirstOrDefault();

                        comandos.AlterarConclusaoDaRotina(id_rotina, conclusao);


                        AtualizarDataGridRotinas();
                    }
                }
            }
            catch { }
        }

        private void dataGridViewRotinas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && data.Date <= DateTime.Now.Date)
                {
                    ordem_rotina = Convert.ToInt32(dataGridViewRotinas[0, e.RowIndex].Value);
                    id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina).Select(x => x.ID_Rotina).FirstOrDefault();
                    formGerenteProfissionalAdicionar editar = new formGerenteProfissionalAdicionar(id_rotina, this, true);
                    editar.ShowDialog();
                    AtualizarDataGridRotinas();
                }
            }
            catch { }
        }

        private void dataGridViewRotinas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewRotinas.Rows[e.RowIndex];

            if (e.ColumnIndex == 3)
            {
                Font fonte = new Font("Arial", 9, FontStyle.Strikeout, GraphicsUnit.Point);

                bool conclusao = Convert.ToBoolean(dataGridViewRotinas[e.ColumnIndex, e.RowIndex].Value);

                if (conclusao)
                {
                    linha.DefaultCellStyle.Font = fonte;
                }
            }
        }

        private void buttonSubirRotina_Click(object sender, EventArgs e)
        {
            if (ordem_rotina == 0) { }
            else if (ordem_rotina == 1) { }
            else if (rotinas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewRotinas.CurrentRow != null)
                {
                    primeira_linha = dataGridViewRotinas.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewRotinas.CurrentRow.Index;
                }

                int nova_ordem;
                int id_rotina;

                foreach (Afazer afazer in rotinas)
                {
                    if (afazer.Ordem == ordem_rotina - 1)
                    {
                        id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina - 1).Select(x => x.ID_Rotina).FirstOrDefault();
                        nova_ordem = ordem_rotina;
                        comandos.AlterarOrdemDaRotina(id_rotina, nova_ordem);
                        comandos.AlterarOrdemDoAfazerAPartirDaRotina(id_rotina, data, nova_ordem);
                    }
                    else if (afazer.Ordem == ordem_rotina)
                    {
                        id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina).Select(x => x.ID_Rotina).FirstOrDefault();
                        nova_ordem = ordem_rotina - 1;
                        comandos.AlterarOrdemDaRotina(id_rotina, nova_ordem);
                        comandos.AlterarOrdemDoAfazerAPartirDaRotina(id_rotina, data, nova_ordem);
                    }
                }

                AtualizarDataGridRotinas();

                dataGridViewRotinas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewRotinas.CurrentCell = dataGridViewRotinas.Rows[linha_selecionada - 1].Cells[0];
                ordem_rotina = ordem_rotina - 1;
            }
        }

        private void buttonDescerRotina_Click(object sender, EventArgs e)
        {
            if (ordem_rotina == 0) { }
            else if (ordem_rotina == rotinas.Count) { }
            else if (rotinas.Count == 0) { }
            else
            {
                int linha_selecionada = 0, primeira_linha = 0;
                if (dataGridViewRotinas.CurrentRow != null)
                {
                    primeira_linha = dataGridViewRotinas.FirstDisplayedScrollingRowIndex;
                    linha_selecionada = dataGridViewRotinas.CurrentRow.Index;
                }

                int id_rotina;
                int nova_ordem;

                foreach (Afazer afazer in rotinas)
                {
                    if (afazer.Ordem == ordem_rotina)
                    {
                        nova_ordem = ordem_rotina + 1;
                        id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina).Select(x => x.ID_Rotina).FirstOrDefault();
                        comandos.AlterarOrdemDaRotina(id_rotina, nova_ordem);
                        comandos.AlterarOrdemDoAfazerAPartirDaRotina(id_rotina, data, nova_ordem);
                    }
                    else if (afazer.Ordem == ordem_rotina + 1)
                    {
                        id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina + 1).Select(x => x.ID_Rotina).FirstOrDefault();
                        nova_ordem = ordem_rotina;
                        comandos.AlterarOrdemDaRotina(id_rotina, nova_ordem);
                        comandos.AlterarOrdemDoAfazerAPartirDaRotina(id_rotina, data, nova_ordem);
                    }
                }

                AtualizarDataGridRotinas();

                try
                {
                    dataGridViewRotinas.FirstDisplayedScrollingRowIndex = primeira_linha;
                    dataGridViewRotinas.CurrentCell = dataGridViewRotinas.Rows[linha_selecionada + 1].Cells[0];
                }
                catch { }
                ordem_rotina = ordem_rotina + 1;
            }
        }

        private void dataGridViewRotinas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ordem_rotina = Convert.ToInt32(dataGridViewRotinas[0, e.RowIndex].Value);
                    id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina).Select(x => x.ID_Rotina).FirstOrDefault();
                }
            }
            catch
            {
                ordem_rotina = 0;
            }
        }

        private void apagarRotinaTtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ordem_rotina != 0)
            {
                this.id_rotina = rotinas.Where(x => x.Ordem == ordem_rotina).Select(x => x.ID_Rotina).FirstOrDefault();
                comandos.ApagarRotina(this.id_rotina);
                comandos.ApagarAfazerAPartirDaRotina(this.id_rotina, data);

                int i = ordem_rotina;
                int id_rotina;
                int nova_ordem;

                foreach (Afazer rotina in rotinas)
                {
                    if (rotina.Ordem > ordem_rotina)
                    {
                        nova_ordem = i;
                        i++;
                        id_rotina = rotinas.Where(x => x.Ordem == rotina.Ordem).Select(x => x.ID_Rotina).FirstOrDefault();

                        comandos.AlterarOrdemDaRotina(id_rotina, nova_ordem);
                        comandos.AlterarOrdemDoAfazerAPartirDaRotina(id_rotina, data, nova_ordem);
                    }
                }

                AtualizarDataGridRotinas();
            }
        }

        private void labelImprimir_Click(object sender, EventArgs e)
        {
            comandos.ImprimirAfazeresDoDia(data.Date, true);
        }

        private void labelExportar_Click(object sender, EventArgs e)
        {
            comandos.ImprimirAfazeresDoDia(data.Date, false);
        }
    }
}
