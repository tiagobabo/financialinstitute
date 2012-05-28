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
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Threading;

namespace FinancialInstitute
{
    public partial class FinancialInstituteForm : Form
    {

        ServiceHost host;
        FinancialOpsClient server;
        public List<int> idserver;
        int selected_index = -1;
        
        public FinancialInstituteForm()
        {
            InitializeComponent();

            host = new ServiceHost(typeof(FinancialInstituteOps.FinancialInstituteOps));
            host.Open();
            server = new FinancialOpsClient();
            server.Open();

            idserver = new List<int>();

            string connString = ConfigurationManager.ConnectionStrings["FinancialInstitute"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            List<List<String>> requests = new List<List<String>>();
            SqlDataReader rdr;
            try
            {
                conn.Open();
                string sqlcmd = "select * from requests where estado=0";
                SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    List<String> list = new List<String>();
                    list.Add(rdr["data"].ToString());
                    list.Add(rdr["email"].ToString());
                    list.Add(rdr["op"].ToString());
                    list.Add("Tipo " + rdr["tipo"].ToString());
                    list.Add(rdr["quantidade"].ToString());
                    list.Add(rdr["cotacao"].ToString());
                    list.Add(rdr["valor"].ToString());
                    list.Add(rdr["estado"].ToString());
                    idserver.Add(Int16.Parse(rdr["idserver"].ToString()));
                    requests.Add(list);
                }
            }
            finally
            {
                conn.Close();
            }
            
            int i = 0;
            //listView1.Items.Clear();
            if (requests.Count == 0)
                return;
            do
            {
                if (requests[i][2] == "0")
                    requests[i][2] = "Compra";
                else
                    requests[i][2] = "Venda";
                if (requests[i][5] == "-1,0000")
                    requests[i][5] = "-";
                if (requests[i][6] == "-1,0000")
                    requests[i][6] = "-";
                
                requests[i][7] = "Por executar";

                ListViewItem lv = new ListViewItem(requests[i].ToArray());
                listView1.Items.Add(lv);
                i++;

            } while (i != requests.Count);

            button1.Visible = false;
            cotation.Visible = false;
            label1.Visible = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
            server.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                selected_index = this.listView1.SelectedIndices[0];
                button1.Visible = true;
                cotation.Visible = true;
                label1.Visible = true;
            }
            else
            {
                button1.Visible = false;
                cotation.Visible = false;
                label1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cotation.Text != "" && selected_index != -1)
            {
                Boolean success = server.ChangeOrder(idserver[selected_index], Convert.ToDouble(cotation.Text), listView1.SelectedItems[0].SubItems[1].Text);
                if (success)
                {
                    try
                    {
                        string connString = ConfigurationManager.ConnectionStrings["FinancialInstitute"].ToString();
                        SqlConnection conn = new SqlConnection(connString);
                        conn.Open();
                        string sqlcmd = "delete from requests" +
                                   " where idserver=" + idserver[selected_index];
                        SqlCommand cmd = new SqlCommand(sqlcmd, conn);
                        cmd.ExecuteNonQuery();
                        
             
                    }
                    catch
                    {
                        MessageBox.Show("Tente novamente!");
                    }

                    cotation.Text = "";
                    listView1.Items[selected_index].Remove();
                    idserver.RemoveAt(selected_index);
                    button1.Visible = false;
                    cotation.Visible = false;
                    label1.Visible = false;
                    selected_index = -1;

                }
                else MessageBox.Show("Tente novamente!");
                
            }
            else
                MessageBox.Show("Tente novamente!");
        }


    }
}
