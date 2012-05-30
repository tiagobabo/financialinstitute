using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Server;
using System.Net.Mail;

public partial class CriarOrdem : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        FinancialOpsClient server = new FinancialOpsClient();
        try
        {
            MailAddress dummy = new MailAddress(TextBox2.Text);

            Boolean op = server.NewOrder(Convert.ToInt32(TextBox1.Text), TextBox2.Text, RadioButtonList1.SelectedIndex,                                                             RadioButtonList2.SelectedIndex+1, Convert.ToInt32(TextBox3.Text));
            if (op)
            {
                string script = "<script type=text/javascript>alert('Ordem Criada com sucesso!')</script>";
                if (!this.ClientScript.IsStartupScriptRegistered("script"))
                    this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
                Server.Transfer("Default.aspx");
            }
            else
            {
                string script = "<script type=text/javascript>alert('Ocorreu um erro, tente novamente!')</script>";
                if (!this.ClientScript.IsStartupScriptRegistered("script"))
                    this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
            }
        }
        catch
        {
            string script = "<script type=text/javascript> alert('Um dos campos está incorreto!')</script>";
            if (!this.ClientScript.IsStartupScriptRegistered("script"))
                this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
        }
        finally
        {
            server.Close();
        }
        
    }
}