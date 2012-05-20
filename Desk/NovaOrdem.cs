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
            cbOp.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean op = server.NewOrder(Convert.ToInt32(txtID.Text), txtEmail.Text, cbOp.SelectedIndex, cbTipo.SelectedIndex,
                    Convert.ToInt32(txtQuantidade.Text));
                if (op)
                    MessageBox.Show("Ordem adicionada com sucesso.");
                else
                    MessageBox.Show("Erro ao adicionar ao ordem no servidor.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao inserir a ordem. Verifique os campos e tente novamente.");
            }
        }

        private void NovaOrdem_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }
    }
}
