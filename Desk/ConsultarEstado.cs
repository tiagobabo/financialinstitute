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
    public partial class ConsultarEstado : Form
    {
        FinancialOpsClient server;
        public ConsultarEstado()
        {
            InitializeComponent();
            this.server = new FinancialOpsClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            String[][] requests = server.GetRequestsByClient(id);
            int i = 0;
            if (requests.Length == 0)
                return;
            do
            {
                ListViewItem lv = new ListViewItem(requests[i]);
                listView1.Items.Add(lv);
                i++;

            } while (i != requests.Length);
        }
    }
}
