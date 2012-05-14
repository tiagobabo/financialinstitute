using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Desk.Server;

namespace Desk
{
    public partial class NovaOrdem : Form
    {
        FinancialOpsClient server;
        public NovaOrdem()
        {
            this.server = new FinancialOpsClient();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Boolean op = server.NewOrder(Convert.ToInt32(txtID.Text), txtEmail.Text, cbOp.SelectedIndex, cbTipo.SelectedIndex, 
                 Convert.ToInt32(txtQuantidade.Text));
             if (op)
                MessageBox.Show("Ordem adicionada com sucesso.");
             else 
                MessageBox.Show("Erro ao adicionar ao ordem.");
            
            this.Close();
        }

        private void NovaOrdem_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }
    }
}
