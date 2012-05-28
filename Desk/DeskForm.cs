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
    public partial class DeskForm : Form
    {
        FinancialOpsClient server;
        public DeskForm()
        {
            InitializeComponent();
            server = new FinancialOpsClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NovaOrdem no = new NovaOrdem();
            no.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarEstado no = new ConsultarEstado();
            no.ShowDialog();
        }
    }
}
