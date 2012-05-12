using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Configuration;

namespace FinancialOps
{
    class FinancialOps : IFinancialOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["FinancialServer"].ToString();

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public Boolean NewOrder(int client, string email, int op, int type, int quantity) 
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "insert into requests(cliente, email, op, tipo, quantidade) values("
                + client + ",'" + email + "'," + op + "," + type + "," + quantity + ");";
                Console.WriteLine(sqlcmd);
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

            return true;
        }

        public int GetStatus(int id)
        {
            SqlConnection conn = new SqlConnection(connString);
            int status;
            try
            {
                conn.Open();
                string sqlcmd = "select op from requests where id=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                status = Convert.ToInt16(cmd.ExecuteScalar());
            }
            catch
            {
                status = -1;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public Boolean ChangeOrder(int id, double cotation)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "update requests set op = 1, data=getdate(), cotacao=" + cotation +
                           "where id=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    OperationContext.Current.SetTransactionComplete();
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        public List<int> GetWaitingRequests()
        {
            SqlConnection conn = new SqlConnection(connString);
            List<int> requests = new List<int>();
            SqlDataReader rdr;
            try
            {
                conn.Open();
                string sqlcmd = "select id from requests where op=0";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    requests.Add(Convert.ToInt16(rdr["id"]));
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return requests;
        }

        public List<int> GetRequestsByClient(int client)
        {
            SqlConnection conn = new SqlConnection(connString);
            List<int> requests = new List<int>();
            SqlDataReader rdr;
            try
            {
                conn.Open();
                string sqlcmd = "select id from requests where cliente="+client;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    requests.Add(Convert.ToInt16(rdr["id"]));
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return requests;
        }
    }
}
