using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace FinancialInstitute
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ServiceHost host = new ServiceHost(typeof(FinancialInstituteOps.FinancialInstituteOps));
            host.Open();
            Console.WriteLine("Service Supervisor Active. Press <Enter> to close.");
            Console.ReadLine();
            host.Close();
        }
    }
}
