using BrightIdeasSoftware;
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
    public partial class formGerenteFinanceiroFluxo : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        private List<Nó> nós;
        int mes;
        int ano;

        List<FluxoDeCaixa> fluxo = new List<FluxoDeCaixa>();
        public formGerenteFinanceiroFluxo()
        {
            InitializeComponent();
        }

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public static void SetTreeViewTheme(IntPtr treeHandle)
        {
            SetWindowTheme(treeHandle, "explorer", null);
        }

        class Nó
        {
            public string Name { get; private set; }
            public string Column1 { get; private set; }
            public string Column2 { get; private set; }
            public string Column3 { get; private set; }
            public string Column4 { get; private set; }
            public string Column5 { get; private set; }
            public string Column6 { get; private set; }
            public string Column7 { get; private set; }
            public string Column8 { get; private set; }
            public string Column9 { get; private set; }
            public string Column10 { get; private set; }
            public string Column11 { get; private set; }
            public string Column12 { get; private set; }
            public string Column13 { get; private set; }
            public string Column14 { get; private set; }
            public string Column15 { get; private set; }
            public List<Nó> Children { get; private set; }

            public Nó(string name, string col1, string col2, string col3, string col4, string col5, string col6, string col7, string col8, string col9, string col10, string col11, string col12, string col13, string col14, string col15)
            {
                Name = name;
                Column1 = col1;
                Column2 = col2;
                Column3 = col3;
                Column4 = col4;
                Column5 = col5;
                Column6 = col6;
                Column7 = col7;
                Column8 = col8;
                Column9 = col9;
                Column10 = col10;
                Column11 = col11;
                Column12 = col12;
                Column13 = col13;
                Column14 = col14;
                Column15 = col15;
                Children = new List<Nó>();
            }
        }

        private void formFinanceiroFluxo_Load(object sender, EventArgs e)
        {
            AplicarTema();

            List<string> Meses = comandos.MesesDoFluxoDeCaixa();
            foreach (string mes in Meses) { comboBoxMes.Items.Add(mes); }

            string Mes = comandos.ConverterMesIntParaExtenso(DateTime.Now.Month).ToUpper() + "/" + DateTime.Now.Year.ToString();
            Mes = comandos.ObterValorDoParametroDeTextoPeloUsuario("Período do fluxo de caixa"); 
            comboBoxMes.Text = Mes;

            SetTreeViewTheme(treeListView.Handle);

            buttonCategorias.Focus();
        }

        private void AplicarTema()
        {
            buttonCategorias.ForeColor = Program.tema.Cor_Principal;
            buttonRelatorios.ForeColor = Program.tema.Cor_Principal;
        }

        private void DefinirPeriodo()
        {
            string data = comboBoxMes.Text;
            string[] partir = data.Split('/');
            string Mes = partir[0];
            mes = comandos.ConverterMesPorExtensoEmInt(Mes);
            ano = Convert.ToInt32(partir[1]);
        }

        private void PreencherTreeView()
        {
            string data = comboBoxMes.Text;
            string[] partir = data.Split('/');
            string Mes = partir[0];
            mes = comandos.ConverterMesPorExtensoEmInt(Mes);
            ano = Convert.ToInt32(partir[1]);

            string mes_2 = comandos.ConverterMesIntParaExtenso(new DateTime(ano, mes, 1).AddMonths(-1).Month);
            string mes_3 = comandos.ConverterMesIntParaExtenso(new DateTime(ano, mes, 1).AddMonths(-2).Month);
            string mes_4 = comandos.ConverterMesIntParaExtenso(new DateTime(ano, mes, 1).AddMonths(-3).Month);

            // defina o Delegate que a árvore usa para saber se um nó é expansível
            treeListView.CanExpandGetter = x => (x as Nó).Children.Count > 0;

            // defina o Delegate que a árvore usa para conhecer os filhos de um nó
            treeListView.ChildrenGetter = x => (x as Nó).Children;
  
            // crie as colunas da árvore e defina os delegates para exibir a propriedade do objeto desejado
            var nameCol = new OLVColumn("", "");
            nameCol.AspectGetter = x => (x as Nó).Name;

            var esperado4 = new OLVColumn("Esperado", "Column1");
            esperado4.AspectGetter = x => (x as Nó).Column1;

            var mes4 = new OLVColumn(mes_4.ToLower().PrimeiraLetraMaiuscula(), "Column2");
            mes4.AspectGetter = x => (x as Nó).Column2;

            var av4 = new OLVColumn("AV%", "Column3");
            av4.AspectGetter = x => (x as Nó).Column3;

            var ah3 = new OLVColumn("AH%", "Column4");
            ah3.AspectGetter = x => (x as Nó).Column4;

            var esperado3 = new OLVColumn("Esperado", "Column5");
            esperado3.AspectGetter = x => (x as Nó).Column5;

            var mes3 = new OLVColumn(mes_3.ToLower().PrimeiraLetraMaiuscula(), "Column6");
            mes3.AspectGetter = x => (x as Nó).Column6;

            var av3 = new OLVColumn("AV%", "Column7");
            av3.AspectGetter = x => (x as Nó).Column7;

            var ah2 = new OLVColumn("AH%", "Column8");
            ah2.AspectGetter = x => (x as Nó).Column8;

            var esperado2 = new OLVColumn("Esperado", "Column9");
            esperado2.AspectGetter = x => (x as Nó).Column9;

            var mes2 = new OLVColumn(mes_2.ToLower().PrimeiraLetraMaiuscula(), "Column10");
            mes2.AspectGetter = x => (x as Nó).Column10;

            var av2 = new OLVColumn("AV%", "Column11");
            av2.AspectGetter = x => (x as Nó).Column11;

            var ah1 = new OLVColumn("AH%", "Column12");
            ah1.AspectGetter = x => (x as Nó).Column12;

            var esperado1 = new OLVColumn("Esperado", "Column13");
            esperado1.AspectGetter = x => (x as Nó).Column13;

            var mes1 = new OLVColumn(Mes.ToLower().PrimeiraLetraMaiuscula(), "Column14");
            mes1.AspectGetter = x => (x as Nó).Column14;

            var av1 = new OLVColumn("AV%", "Column15");
            av1.AspectGetter = x => (x as Nó).Column15;


            //adiciona as colunas na árvore
            treeListView.Columns.Add(nameCol);
            //treeListView.Columns.Add(esperado4);
            //treeListView.Columns.Add(mes4);
            //treeListView.Columns.Add(av4);
            //treeListView.Columns.Add(ah3);
            treeListView.Columns.Add(esperado3);
            treeListView.Columns.Add(mes3);
            treeListView.Columns.Add(av3);
            treeListView.Columns.Add(ah2);
            treeListView.Columns.Add(esperado2);
            treeListView.Columns.Add(mes2);
            treeListView.Columns.Add(av2);
            treeListView.Columns.Add(ah1);
            treeListView.Columns.Add(esperado1);
            treeListView.Columns.Add(mes1);
            treeListView.Columns.Add(av1);

            //define as raízes da árvore
            treeListView.Roots = nós;

            treeListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            treeListView.HeaderUsesThemes = false;

            HeaderFormatStyle cabecalho = new HeaderFormatStyle();

            cabecalho.SetBackColor(Program.tema.Cor_Principal);
            cabecalho.SetFont(new Font("Verdana", 7, FontStyle.Bold, GraphicsUnit.Point));
            cabecalho.SetForeColor(Program.tema.Cor_Secundaria);

            treeListView.UseAlternatingBackColors = true;
            treeListView.UseCellFormatEvents = false;


            treeListView.Font = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);
            //treeListView.Root.Font = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            treeListView.AlternateRowBackColor = Color.LightGray;
            treeListView.BackColor = Color.WhiteSmoke;
            treeListView.ForeColor = Color.Black;

            //Destacar colunas
            var MyTint = new TintedColumnDecoration(mes1);
            var MyTint1 = new TintedColumnDecoration(mes2);
            var MyTint2 = new TintedColumnDecoration(mes3);
            var MyTint3 = new TintedColumnDecoration(mes4);

            Color cor = Color.FromArgb(50, Program.tema.Cor_Principal);
            Color cor2 = Color.FromArgb(100, Program.tema.Cor_Principal);

            MyTint.Tint = cor;
            MyTint1.Tint = cor;
            MyTint2.Tint = cor;
            MyTint3.Tint = cor;
            treeListView.AddDecoration(MyTint);
            treeListView.AddDecoration(MyTint1);
            treeListView.AddDecoration(MyTint2);
            treeListView.AddDecoration(MyTint3);

            var MyTint4 = new TintedColumnDecoration(esperado1);
            var MyTint5 = new TintedColumnDecoration(esperado2);
            var MyTint6 = new TintedColumnDecoration(esperado3);
            var MyTint7 = new TintedColumnDecoration(esperado4);

            MyTint4.Tint = cor2;
            MyTint5.Tint = cor2;
            MyTint6.Tint = cor2;
            MyTint7.Tint = cor2;
            treeListView.AddDecoration(MyTint4);
            treeListView.AddDecoration(MyTint5);
            treeListView.AddDecoration(MyTint6);
            treeListView.AddDecoration(MyTint7);

            treeListView.HeaderFormatStyle = cabecalho;

            int largura = 70;
            int meia = 45;

            treeListView.RowHeight = 28;
            treeListView.Columns[0].Width = 360;
            treeListView.Columns[1].Width = largura;
            treeListView.Columns[2].Width = largura;
            treeListView.Columns[3].Width = meia;
            treeListView.Columns[4].Width = meia;
            treeListView.Columns[5].Width = largura;
            treeListView.Columns[6].Width = largura;
            treeListView.Columns[7].Width = meia;
            treeListView.Columns[8].Width = meia;
            treeListView.Columns[9].Width = largura;
            treeListView.Columns[10].Width = largura;
            treeListView.Columns[11].Width = meia;
            //treeListView.Columns[12].Width = meia;
            //treeListView.Columns[13].Width = largura;
            //treeListView.Columns[14].Width = largura;
            //treeListView.Columns[15].Width = meia;

            treeListView.Columns[0].TextAlign = HorizontalAlignment.Left;
            treeListView.Columns[1].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[2].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[3].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[4].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[5].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[6].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[7].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[8].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[9].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[10].TextAlign = HorizontalAlignment.Center;
            treeListView.Columns[11].TextAlign = HorizontalAlignment.Center;
            //treeListView.Columns[12].TextAlign = HorizontalAlignment.Center;
            //treeListView.Columns[13].TextAlign = HorizontalAlignment.Center;
            //treeListView.Columns[14].TextAlign = HorizontalAlignment.Center;
            //treeListView.Columns[15].TextAlign = HorizontalAlignment.Center;
        }

        private void Raizes()
        {
            string f_dinheiro = "F";
            string f_decimal = "F";

            decimal ah3;
            decimal ah2;
            decimal ah1;
                       ;
            decimal av4;
            decimal av3;
            decimal av2;
            decimal av1;

            FluxoDeCaixa receitas = fluxo.Where(x => x.Categoria == "Receitas").FirstOrDefault();
            FluxoDeCaixa despesas = fluxo.Where(x => x.Categoria == "Despesas").FirstOrDefault();
            FluxoDeCaixa investimentos = fluxo.Where(x => x.Categoria == "Investimentos").FirstOrDefault();
            FluxoDeCaixa outras_movimentacoes = fluxo.Where(x => x.Categoria == "Outras movimentações").FirstOrDefault();
            FluxoDeCaixa acerto = fluxo.Where(x => x.Categoria == "Acerto do caixa").FirstOrDefault();
            FluxoDeCaixa saldo_inicial = fluxo.Where(x => x.Categoria == "Saldo inicial").FirstOrDefault();
            FluxoDeCaixa saldo_final = fluxo.Where(x => x.Categoria == "Saldo final").FirstOrDefault();

            FluxoDeCaixa loai = new FluxoDeCaixa //Lucro operacional antes dos investimentos
            {
                Categoria = "Lucro/Prejuízo antes dos investimentos",
                Valor4 = receitas.Valor4 + despesas.Valor4,
                Valor3 = receitas.Valor3 + despesas.Valor3,
                Valor2 = receitas.Valor2 + despesas.Valor2,
                Valor1 = receitas.Valor1 + despesas.Valor1,
                Esperado4 = receitas.Esperado4 + despesas.Esperado4,
                Esperado3 = receitas.Esperado3 + despesas.Esperado3,
                Esperado2 = receitas.Esperado2 + despesas.Esperado2,
                Esperado1 = receitas.Esperado1 + despesas.Esperado1
            };

            FluxoDeCaixa lucro_bruto = new FluxoDeCaixa
            {
                Categoria = "Lucro bruto",
                Valor4 = loai.Valor4 + investimentos.Valor4,
                Valor3 = loai.Valor3 + investimentos.Valor3,
                Valor2 = loai.Valor2 + investimentos.Valor2,
                Valor1 = loai.Valor1 + investimentos.Valor1,
                Esperado4 = loai.Esperado4 + investimentos.Esperado4,
                Esperado3 = loai.Esperado3 + investimentos.Esperado3,
                Esperado2 = loai.Esperado2 + investimentos.Esperado2,
                Esperado1 = loai.Esperado1 + investimentos.Esperado1
            };

            FluxoDeCaixa lucro_liquido = new FluxoDeCaixa
            {
                Categoria = "Lucro líquido",
                Valor4 = lucro_bruto.Valor4 + outras_movimentacoes.Valor4,
                Valor3 = lucro_bruto.Valor3 + outras_movimentacoes.Valor3,
                Valor2 = lucro_bruto.Valor2 + outras_movimentacoes.Valor2,
                Valor1 = lucro_bruto.Valor1 + outras_movimentacoes.Valor1,
                Esperado4 = lucro_bruto.Esperado4 + outras_movimentacoes.Esperado4,
                Esperado3 = lucro_bruto.Esperado3 + outras_movimentacoes.Esperado3,
                Esperado2 = lucro_bruto.Esperado2 + outras_movimentacoes.Esperado2,
                Esperado1 = lucro_bruto.Esperado1 + outras_movimentacoes.Esperado1
            };

            try 
            { 
                ah3 = ((receitas.Valor3 / receitas.Valor4) - 1) * 100;
            }
            catch { ah3 = 0; }
    
            try 
            { 
                ah2 = ((receitas.Valor2 / receitas.Valor3) - 1) * 100;
            }
            catch { ah2 = 0; }

            try 
            { 
                ah1 = ((receitas.Valor1 / receitas.Valor2) - 1) * 100;
            }
            catch { ah1 = 0; }
            //ah_receita = ((receita / receita_anterior) - 1) * 100

            Nó no_receitas = new Nó(receitas.Categoria, receitas.Esperado4.ToString(f_dinheiro), receitas.Valor4.ToString(f_dinheiro), 100.ToString(f_decimal), ah3.ToString(f_decimal), receitas.Esperado3.ToString(f_dinheiro), receitas.Valor3.ToString(f_dinheiro), 100.ToString(f_decimal), ah2.ToString(f_decimal), receitas.Esperado2.ToString(f_dinheiro), receitas.Valor2.ToString(f_dinheiro), 100.ToString(f_decimal), ah1.ToString(f_decimal), receitas.Esperado1.ToString(f_dinheiro), receitas.Valor1.ToString(f_dinheiro), 100.ToString(f_decimal));

            try { ah3 = ((despesas.Valor3 / despesas.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((despesas.Valor2 / despesas.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((despesas.Valor3 / despesas.Valor4) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = despesas.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = despesas.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = despesas.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = despesas.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }


            Nó no_despesas = new Nó(despesas.Categoria, despesas.Esperado4.ToString(f_dinheiro), despesas.Valor4.ToString(f_dinheiro), 
                av4.ToString(f_decimal), ah3.ToString(f_decimal), despesas.Esperado3.ToString(f_dinheiro), despesas.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                despesas.Esperado2.ToString(f_dinheiro), despesas.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                despesas.Esperado1.ToString(f_dinheiro), despesas.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));


            try { ah3 = ((loai.Valor3 / loai.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((loai.Valor2 / loai.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((loai.Valor1 / loai.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = loai.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = loai.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = loai.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = loai.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_loai = new Nó(loai.Categoria, loai.Esperado4.ToString(f_dinheiro), loai.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), loai.Esperado3.ToString(f_dinheiro), loai.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                loai.Esperado2.ToString(f_dinheiro), loai.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                loai.Esperado1.ToString(f_dinheiro), loai.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((investimentos.Valor3 / investimentos.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((investimentos.Valor2 / investimentos.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((investimentos.Valor1 / investimentos.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = investimentos.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = investimentos.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = investimentos.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = investimentos.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_investimentos = new Nó(investimentos.Categoria, investimentos.Esperado4.ToString(f_dinheiro), investimentos.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), investimentos.Esperado3.ToString(f_dinheiro), investimentos.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                investimentos.Esperado2.ToString(f_dinheiro), investimentos.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                investimentos.Esperado1.ToString(f_dinheiro), investimentos.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((lucro_bruto.Valor3 / lucro_bruto.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((lucro_bruto.Valor2 / lucro_bruto.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((lucro_bruto.Valor1 / lucro_bruto.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = lucro_bruto.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = lucro_bruto.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = lucro_bruto.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = lucro_bruto.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_lucro_bruto = new Nó(lucro_bruto.Categoria, lucro_bruto.Esperado4.ToString(f_dinheiro), lucro_bruto.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), lucro_bruto.Esperado3.ToString(f_dinheiro), lucro_bruto.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                lucro_bruto.Esperado2.ToString(f_dinheiro), lucro_bruto.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                lucro_bruto.Esperado1.ToString(f_dinheiro), lucro_bruto.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((outras_movimentacoes.Valor3 / outras_movimentacoes.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = (outras_movimentacoes.Valor2 / outras_movimentacoes.Valor3 - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((outras_movimentacoes.Valor1 / outras_movimentacoes.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = outras_movimentacoes.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = outras_movimentacoes.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = outras_movimentacoes.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = outras_movimentacoes.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_outras_movimentacoes = new Nó(outras_movimentacoes.Categoria, outras_movimentacoes.Esperado4.ToString(f_dinheiro), outras_movimentacoes.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), outras_movimentacoes.Esperado3.ToString(f_dinheiro), outras_movimentacoes.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                outras_movimentacoes.Esperado2.ToString(f_dinheiro), outras_movimentacoes.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                outras_movimentacoes.Esperado1.ToString(f_dinheiro), outras_movimentacoes.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((lucro_liquido.Valor3 / lucro_liquido.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((lucro_liquido.Valor2 / lucro_liquido.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((lucro_liquido.Valor1 / lucro_liquido.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = lucro_liquido.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = lucro_liquido.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = lucro_liquido.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = lucro_liquido.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_liquido = new Nó(lucro_liquido.Categoria, lucro_liquido.Esperado4.ToString(f_dinheiro), lucro_liquido.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), lucro_liquido.Esperado3.ToString(f_dinheiro), lucro_liquido.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                lucro_liquido.Esperado2.ToString(f_dinheiro), lucro_liquido.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                lucro_liquido.Esperado1.ToString(f_dinheiro), lucro_liquido.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((acerto.Valor3 / acerto.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((acerto.Valor2 / acerto.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((acerto.Valor1 / acerto.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = acerto.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = acerto.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = acerto.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = acerto.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_acerto = new Nó(acerto.Categoria, acerto.Esperado4.ToString(f_dinheiro), acerto.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), acerto.Esperado3.ToString(f_dinheiro), acerto.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                acerto.Esperado2.ToString(f_dinheiro), acerto.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                acerto.Esperado1.ToString(f_dinheiro), acerto.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((saldo_inicial.Valor3 / saldo_inicial.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((saldo_inicial.Valor2 / saldo_inicial.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((saldo_inicial.Valor1 / saldo_inicial.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = saldo_inicial.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = saldo_inicial.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = saldo_inicial.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = saldo_inicial.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_inicial = new Nó(saldo_inicial.Categoria, saldo_inicial.Esperado4.ToString(f_dinheiro), saldo_inicial.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), saldo_inicial.Esperado3.ToString(f_dinheiro), saldo_inicial.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                saldo_inicial.Esperado2.ToString(f_dinheiro), saldo_inicial.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                saldo_inicial.Esperado1.ToString(f_dinheiro), saldo_inicial.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            try { ah3 = ((saldo_final.Valor3 / saldo_final.Valor4) - 1) * 100; }
            catch { ah3 = 0; }
            try { ah2 = ((saldo_final.Valor2 / saldo_final.Valor3) - 1) * 100; }
            catch { ah2 = 0; }
            try { ah1 = ((saldo_final.Valor1 / saldo_final.Valor2) - 1) * 100; }
            catch { ah1 = 0; }

            try { av4 = saldo_final.Valor4 / (receitas.Valor4 / 100); }
            catch { av4 = 0; }

            try { av3 = saldo_final.Valor3 / (receitas.Valor3 / 100); }
            catch { av3 = 0; }

            try { av2 = saldo_final.Valor2 / (receitas.Valor2 / 100); }
            catch { av2 = 0; }

            try { av1 = saldo_final.Valor1 / (receitas.Valor1 / 100); }
            catch { av1 = 0; }

            Nó no_final = new Nó(saldo_final.Categoria, saldo_final.Esperado4.ToString(f_dinheiro), saldo_final.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                ah3.ToString(f_decimal), saldo_final.Esperado3.ToString(f_dinheiro), saldo_final.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                saldo_final.Esperado2.ToString(f_dinheiro), saldo_final.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                saldo_final.Esperado1.ToString(f_dinheiro), saldo_final.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

            foreach (FluxoDeCaixa info in fluxo)
            {
                if (info.ID_Parente == receitas.ID || info.ID_Parente == despesas.ID
                    || info.ID_Parente == investimentos.ID || info.ID_Parente == outras_movimentacoes.ID)
                {
                    try { ah3 = ((info.Valor3 / info.Valor4) - 1) * 100; }
                    catch { ah3 = 0; }
                    try { ah2 = ((info.Valor2 / info.Valor3) - 1) * 100; }
                    catch { ah2 = 0; }
                    try { ah1 = ((info.Valor1 / info.Valor2) - 1) * 100; }
                    catch { ah1 = 0; }

                    try { av4 = info.Valor4 / (receitas.Valor4 / 100); }
                    catch { av4 = 0; }

                    try { av3 = info.Valor3 / (receitas.Valor3 / 100); }
                    catch { av3 = 0; }

                    try { av2 = info.Valor2 / (receitas.Valor2 / 100); }
                    catch { av2 = 0; }

                    try { av1 = info.Valor1 / (receitas.Valor1 / 100); }
                    catch { av1 = 0; }

                    Nó no_info = new Nó(info.Categoria, info.Esperado4.ToString(f_dinheiro), info.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                        ah3.ToString(f_decimal), info.Esperado3.ToString(f_dinheiro), info.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                        info.Esperado2.ToString(f_dinheiro), info.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                        info.Esperado1.ToString(f_dinheiro), info.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

                    foreach (FluxoDeCaixa children in fluxo)
                    {
                        if (children.ID_Parente == info.ID)
                        {
                            try { ah3 = ((children.Valor3 / children.Valor4) - 1) * 100; }
                            catch { ah3 = 0; }
                            try { ah2 = ((children.Valor2 / children.Valor3) - 1) * 100; }
                            catch { ah2 = 0; }
                            try { ah1 = ((children.Valor1 / children.Valor2) - 1) * 100; }
                            catch { ah1 = 0; }

                            try { av4 = children.Valor4 / (receitas.Valor4 / 100); }
                            catch { av4 = 0; }

                            try { av3 = children.Valor3 / (receitas.Valor3 / 100); }
                            catch { av3 = 0; }

                            try { av2 = children.Valor2 / (receitas.Valor2 / 100); }
                            catch { av2 = 0; }

                            try { av1 = children.Valor1 / (receitas.Valor1 / 100); }
                            catch { av1 = 0; }

                            Nó no_children = new Nó(children.Categoria, children.Esperado4.ToString(f_dinheiro), children.Valor4.ToString(f_dinheiro), av4.ToString(f_decimal),
                                ah3.ToString(f_decimal), children.Esperado3.ToString(f_dinheiro), children.Valor3.ToString(f_dinheiro), av3.ToString(f_decimal), ah2.ToString(f_decimal),
                                children.Esperado2.ToString(f_dinheiro), children.Valor2.ToString(f_dinheiro), av2.ToString(f_decimal), ah1.ToString(f_decimal),
                                children.Esperado1.ToString(f_dinheiro), children.Valor1.ToString(f_dinheiro), av1.ToString(f_decimal));

                            no_info.Children.Add(no_children);
                        }
                    }

                    if (info.ID_Parente == receitas.ID) { no_receitas.Children.Add(no_info); }
                    if (info.ID_Parente == despesas.ID) { no_despesas.Children.Add(no_info); }
                    if (info.ID_Parente == investimentos.ID) { no_investimentos.Children.Add(no_info); }
                    if (info.ID_Parente == outras_movimentacoes.ID) { no_outras_movimentacoes.Children.Add(no_info); }
                }

                nós = new List<Nó> { no_receitas, no_despesas, no_loai, no_investimentos, no_lucro_bruto, no_outras_movimentacoes, no_liquido, no_acerto, no_inicial, no_final };
            }
        }

        private void comboBoxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Parametro parametro = new Parametro { Descricao = "Período do fluxo de caixa", Edicao = true, Tipo = "Texto", Valor = comboBoxMes.Text };

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(parametro);

                comandos.EditarParametrosDoUsuario(parametros);

                treeListView.Clear();
                DefinirPeriodo();
                fluxo = comandos.InformacoesDoFluxoDeCaixa(mes, ano);
                Raizes();
                PreencherTreeView();
            }
            catch { }
        }

        private void treeListView_FormatRow(object sender, FormatRowEventArgs e)
        {

        }

        private void treeListView_CellClick(object sender, CellClickEventArgs e)
        {
            //if (e.RowIndex % 2 > 0)
            //{
            //    treeListView.SelectedBackColor = Color.FromArgb(255, 128, 128);
            //    treeListView.SelectedForeColor = Color.WhiteSmoke;                
            //}
            //else
            //{
            //    treeListView.SelectedBackColor = Color.WhiteSmoke;
            //    treeListView.SelectedForeColor = Color.FromArgb(255, 128, 128);
            //}
        }

        private void buttonRelatorios_Click(object sender, EventArgs e)
        {

        }

        private void buttonCategorias_Click(object sender, EventArgs e)
        {
            formGerenteFinanceiroFluxoCategorias categorias = new formGerenteFinanceiroFluxoCategorias();
            categorias.ShowDialog();
        }
    }
}
