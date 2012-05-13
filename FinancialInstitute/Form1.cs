using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using FinancialInstitute.Server;

namespace FinancialInstitute
{
    public partial class Form1 : Form
    {

        ServiceHost host;
        FinancialOpsClient server;
        
        public Form1()
        {
            InitializeComponent();

            host = new ServiceHost(typeof(FinancialInstituteOps.FinancialInstituteOps));
            host.Open();
            server = new FinancialOpsClient();
            server.Open();
        }

        static public void test(string msg)
        {
            MessageBox.Show(msg);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
            server.Close();
        }
    }
}
