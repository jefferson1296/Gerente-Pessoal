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
    public partial class formGerentePersonalidadeMetasResultadosAcompanhamento : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<Acompanhamento> acompanhamentos = new List<Acompanhamento>();
        Acompanhamento acompanhamento = new Acompanhamento();

        int id_resultado;
        string resultado;

        Resultado resultado_parcial = new Resultado();

        DateTimePicker datetime = new DateTimePicker();

        DateTime data_atual = new DateTime();

        public formGerentePersonalidadeMetasResultadosAcompanhamento()
        {
            InitializeComponent();
        }

        public formGerentePersonalidadeMetasResultadosAcompanhamento(int ID_Resultado, string Resultado)
        {
            InitializeComponent();
            id_resultado = ID_Resultado;
            resultado = Resultado;
        }

        private void formAtividadesProcessos_Load(object sender, EventArgs e)
        {
            data_atual = DateTime.Now;

            resultado_parcial = comandos.NivelDoAcompanhamento(id_resultado);

            if (resultado_parcial.Inicio.Year == resultado_parcial.Termino.Year)
            {
                labelPeriodo.Text = resultado_parcial.Inicio.ToShortDateString().Substring(0, 5) + " até " + resultado_parcial.Termino.ToShortDateString().Substring(0, 5);
            }
            else
            {
                labelPeriodo.Text = resultado_parcial.Inicio.ToShortDateString() + " até " + resultado_parcial.Termino.ToShortDateString();
            }

            AtualizarDataGrid();
            labelResultado.Text = resultado;

            datetime.Format = DateTimePickerFormat.Short;
            datetime.Visible = false;
            //masked.SelectionStart = 1;
            //masked.SelectionLength = 0;

            dataGridViewLista.Controls.Add(datetime);

            dataGridViewLista.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridViewLista_CellBeginEdit);
            dataGridViewLista.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewLista_CellEndEdit);
            dataGridViewLista.Scroll += new ScrollEventHandler(dataGridViewLista_Scroll);

            datetime.VisibleChanged += new EventHandler(datetime_VisibleChanged);
            datetime.Leave += new EventHandler(datetime_Leave);
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            acompanhamentos = comandos.TrazerAcompanhamento(id_resultado);
            dataGridViewLista.Rows.Clear();
            int i = 0;

            foreach (Acompanhamento acompanhamento in acompanhamentos)
            {
                dataGridViewLista.Rows.Add(acompanhamento.ID_Acompanhamento, acompanhamento.Data.ToShortDateString(), acompanhamento.Atual);
            }

            NivelDoAcompanhamento();

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void NivelDoAcompanhamento()
        {
            foreach (Acompanhamento acompanhamento in acompanhamentos)
            {
                if (acompanhamento.Data <= data_atual)
                {
                    decimal dias_atual = (acompanhamento.Data.Subtract(resultado_parcial.Inicio).Days);
                    decimal dias_total = (resultado_parcial.Termino.Subtract(resultado_parcial.Inicio).Days);

                    decimal percentual_prazo;
                    decimal percentual_valor;

                    try { percentual_prazo = dias_atual / (dias_total / 100); } catch { percentual_prazo = 0; }
                    try { percentual_valor = (acompanhamento.Atual - resultado_parcial.Inicial) / ((resultado_parcial.Meta - resultado_parcial.Inicial) / 100); } catch { percentual_valor = 0; }


                    if (percentual_valor >= percentual_prazo) { acompanhamento.Cor = Color.Green; }
                    else if (percentual_valor < percentual_prazo && percentual_valor >= (percentual_prazo / 2)) { acompanhamento.Cor = Color.Yellow; }
                    else { acompanhamento.Cor = Color.Red; }
                }
                else
                {
                    acompanhamento.Cor = Color.White;
                }
            }

            foreach (DataGridViewRow linha in dataGridViewLista.Rows)
            {
                int id = Convert.ToInt32(dataGridViewLista[0, linha.Index].Value);

                dataGridViewLista[3, linha.Index].Style.SelectionBackColor = acompanhamentos.Where(x => x.ID_Acompanhamento == id).Select(x => x.Cor).FirstOrDefault();
                dataGridViewLista[3, linha.Index].Style.BackColor = acompanhamentos.Where(x => x.ID_Acompanhamento == id).Select(x => x.Cor).FirstOrDefault();
            }
        }

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    acompanhamento.ID_Acompanhamento = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    acompanhamento.Data = Convert.ToDateTime(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);
                    acompanhamento.Atual = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value);
                }
            }
            catch { }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acompanhamento.ID_Acompanhamento != 0)
            {
                comandos.ApagarAcompanhamento(acompanhamento.ID_Acompanhamento);
                AtualizarDataGrid();
            }
        }

        private void dataGridViewLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            //    {
            //        acompanhamento.ID_Acompanhamento = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
            //        acompanhamento.Data = Convert.ToDateTime(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);
            //        acompanhamento.Atual = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value);

            //        comandos.EditarAcompanhamento(acompanhamento);

            //        foreach (Acompanhamento acompanhamento in acompanhamentos)
            //        {
            //            if (acompanhamento.ID_Acompanhamento == this.acompanhamento.ID_Acompanhamento)
            //            {
            //                acompanhamento.Data =  this.acompanhamento.Data;
            //                acompanhamento.Atual = this.acompanhamento.Atual;

            //                break;
            //            }
            //        }
            //    }
            //}
            //catch { }
        }

        private void dataGridViewLista_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewLista.IsCurrentCellDirty)
            {
                dataGridViewLista.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private void dataGridViewLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                Rectangle retangulo = dataGridViewLista.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                datetime.Location = retangulo.Location;
                datetime.Size = retangulo.Size;

                if (dataGridViewLista[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    datetime.Value = Convert.ToDateTime(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);
                }
                else { datetime.Value = DateTime.Now; }

                data = datetime.Value;

                datetime.Visible = true;
                datetime.Focus();
                focus = true;
            }
        }

        private void dataGridViewLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (datetime.Visible)
            {
                DateTime data = datetime.Value;
                dataGridViewLista.CurrentCell.Value = data.ToShortDateString();

                datetime.Visible = false;
            }

            try
            {
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    acompanhamento.ID_Acompanhamento = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                    acompanhamento.Data = Convert.ToDateTime(dataGridViewLista.Rows[e.RowIndex].Cells[1].Value);
                    acompanhamento.Atual = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[2].Value);

                    comandos.EditarAcompanhamento(acompanhamento);

                    foreach (Acompanhamento acompanhamento in acompanhamentos)
                    {
                        if (acompanhamento.ID_Acompanhamento == this.acompanhamento.ID_Acompanhamento)
                        {
                            acompanhamento.Data = this.acompanhamento.Data;
                            acompanhamento.Atual = this.acompanhamento.Atual;

                            break;
                        }
                    }
                }
            }
            catch { }

            NivelDoAcompanhamento();
        }

        private void dataGridViewLista_Scroll(object sender, ScrollEventArgs e)
        {
            if (datetime.Visible)
            {
                Rectangle retangulo = dataGridViewLista.GetCellDisplayRectangle(dataGridViewLista.CurrentCell.ColumnIndex, dataGridViewLista.CurrentCell.RowIndex, true);
                datetime.Location = retangulo.Location;
            }
        }

        bool focus = true;
        DateTime data;

        private void datetime_VisibleChanged(object sender, EventArgs e)
        {
            datetime.Focus();
        }

        private void datetime_Leave(object sender, EventArgs e)
        {
            if (focus)
            {
                datetime.Focus();
                focus = false;
            }

        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow linha = dataGridViewLista.Rows[e.RowIndex];

            if (e.ColumnIndex == 1)
            {
                DateTime data = Convert.ToDateTime(dataGridViewLista[e.ColumnIndex, e.RowIndex].Value);

                if (data.Date > DateTime.Now.Date)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data_atual = dateTimePicker1.Value;
            NivelDoAcompanhamento();
        }
    }
}
