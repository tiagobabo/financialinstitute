using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.Data.SqlClient;

namespace FinancialInstituteOps
{
    public class FinancialInstituteOps : IFinancialInstituteOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["FinancialInstitute"].ToString();

        public void ReportToInstitute(String time, int client, string email, int op, int type, int quantity, int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "insert into requests(cliente, email, op, tipo, quantidade, idserver) values("
                + client + ",'" + email + "'," + op + "," + type + "," + quantity + "," + id + ");";

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    throw new Exception();
            } 
            finally
            {
                conn.Close();
            }

            List<String> list = new List<String>();
            list.Add(time.ToString());
            list.Add(email);
            list.Add(""+op);
            list.Add(""+type);
            list.Add("" + quantity);
            list.Add("" + "-1.0");
            list.Add("" + "-1.0");
            list.Add("" + "0");

            FinancialInstitute.Program.updateView(list, id);
        }
    }
}
