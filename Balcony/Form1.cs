using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balcony.Server;
using System.ServiceModel;

namespace Balcony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FinancialOpsClient server = new FinancialOpsClient();
            Boolean op = server.NewOrder(1, "asd@asd.com", 0, 1, 10);
            if(op)
            MessageBox.Show("YEAH");
            else MessageBox.Show("Ohh");
            server.Close();
        }
    }
}
