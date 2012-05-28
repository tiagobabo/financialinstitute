using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FinancialInstitute
{
    static class Program
    {

        public static FinancialInstitute f;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f = new FinancialInstitute();
            Application.Run(f);
        }

        public static void updateView(List<string> request, int idserver)
        {
            //listView1.Items.Clear();

            if (request[2] == "0")
                request[2] = "Compra";
            else
                request[2] = "Venda";
            if (request[5] == "-1.0")
                request[5] = "-";
            if (request[6] == "-1.0")
                request[6] = "-";
            if (request[7] == "0")
                request[7] = "Por executar";
            else
                request[7] = "Executado";

            ListViewItem lv = new ListViewItem(request.ToArray());
            f.listView1.Items.Add(lv);

            f.idserver.Add(idserver);

        }
    }
}
