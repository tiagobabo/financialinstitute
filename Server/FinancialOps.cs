using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Configuration;
using Server.FinancialInstitute;
using System.Threading;
using System.Net.Mail;

namespace FinancialOps
{
    public class Email
    {

        string email;
        string id;
        string cotacao;

        public Email(string email, string id, string cotacao)
        {
            this.email = email;
            this.id = id;
            this.cotacao = cotacao;
        }

        public void DoWork()
        {
            Thread t = new Thread(new ThreadStart(DoWorkCore));
            t.Start();
        }

        private void DoWorkCore()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("financialinstitutetdin@gmail.com");
            message.To.Add(new MailAddress(email));

            message.Subject = "Financial Institute";
            message.Body = "O pedido com o id " + id + " foi executado com a cotação: ";
            message.Body += cotacao + ".";

            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Send(message);
        }
    }

    class FinancialOps : IFinancialOps
    {
        public static string connString = ConfigurationManager.ConnectionStrings["FinancialServer"].ToString();
        public FinancialInstituteOpsClient financialinstitute = new FinancialInstituteOpsClient();


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
                {
                    string newsql = "SELECT MAX(ID) FROM requests";

                    cmd = new SqlCommand(newsql, conn);
                    int id = Convert.ToInt16(cmd.ExecuteScalar());

                    financialinstitute.ReportToInstitute(DateTime.Now.ToString(), client, email, op, type, quantity, id);
                }
                else throw new Exception();
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

        public Boolean ChangeOrder(int id, double cotation, String email)
        {
            SqlConnection conn = new SqlConnection(connString);
            int rows;
            try
            {
                conn.Open();
                string sqlcmd = "update requests set estado = 1, data=getdate(), cotacao=" + cotation + ", valor=quantidade*" + cotation +
                           " where id=" + id;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rows = cmd.ExecuteNonQuery();

                Email t = new Email(email, id + "", cotation + "");
                t.DoWork();
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

        public List<List<String>> GetRequestsByClient(int client)
        {
            SqlConnection conn = new SqlConnection(connString);
            List<List<String>> requests = new List<List<String>>();
            SqlDataReader rdr;
            try
            {
                conn.Open();
                string sqlcmd = "select * from requests where cliente=" + client;
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    List<String> list = new List<String>();
                    list.Add(rdr["data"].ToString());
                    list.Add(rdr["email"].ToString());
                    list.Add(rdr["op"].ToString());
                    list.Add(rdr["tipo"].ToString());
                    list.Add(rdr["quantidade"].ToString());
                    list.Add(rdr["cotacao"].ToString());
                    list.Add(rdr["valor"].ToString());
                    list.Add(rdr["estado"].ToString());
                    requests.Add(list);
                }
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
