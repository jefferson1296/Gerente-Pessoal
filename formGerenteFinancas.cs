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
    public partial class formGerenteFinancas : Form
    {
        public bool alteracao;
        ComandosSQL comandos = new ComandosSQL();
        public formGerenteFinancas()
        {
            InitializeComponent();
        }

        private void formFinancas_Load(object sender, EventArgs e)
        {

        }
    }
}
