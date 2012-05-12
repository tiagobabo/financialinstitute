using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(FinancialOps.FinancialOps));
            host.Open();
            Console.WriteLine("Service Active. Press <Enter> to close.");
            Console.ReadLine();
            host.Close();
        }
    }
}
