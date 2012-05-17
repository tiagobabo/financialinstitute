using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Server;

public partial class ConsultarOrdens : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FinancialOpsClient server = new FinancialOpsClient();
        try
        {
            int id = Convert.ToInt16(TextBox1.Text);
            String[][] requests = server.GetRequestsByClient(id);
            string script = "<script type=text/javascript> alert('Recebi!') </script>";
            if(!this.ClientScript.IsStartupScriptRegistered("script"))
                this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
            
        }
        catch
        {
            string script = "<script type=text/javascript> alert('Ocorreu um erro!') </script>";
            if (!this.ClientScript.IsStartupScriptRegistered("script"))
                this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
        }
        finally
        {
            server.Close();
        }

    }
}