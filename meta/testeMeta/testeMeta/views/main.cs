using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testeMeta.views;

namespace testeMeta
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnCadClientes_Click(object sender, EventArgs e)
        {
            clientes clientes = new clientes();
            clientes.ShowDialog();
        }

        private void btnCadProdutos_Click(object sender, EventArgs e)
        {
            produtos produtos = new produtos();
            produtos.ShowDialog();
        }

        private void btnOrcamentos_Click(object sender, EventArgs e)
        {
             orcamento orcamento = new orcamento();
             orcamento.ShowDialog();
        }
    }
}
