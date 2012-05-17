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

        public void ReportToInstitute(int client, string email, int op, int type, int quantity)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "insert into requests(cliente, email, op, tipo, quantidade) values("
                + client + ",'" + email + "'," + op + "," + type + "," + quantity + ");";

                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows != 1)
                    throw new Exception();
            }
            catch(Exception e)
            {
                FinancialInstitute.Form1.test(e.Message);
            }
            finally
            {
                conn.Close();
            }

            FinancialInstitute.Form1.test("Passei");
        }
    }
}
