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
            Page.Controls.Add(new LiteralControl("<div class='container'><div class='hero-unit' align='center'><table class='table'>"));
            Page.Controls.Add(new LiteralControl("<tr><th>Data</th><th>E-Mail</th><th>Operação</th><th>Tipo</th><th>Quantidade</th><th>Cotação</th><th>Valor</th><th>Estado</th></tr>"));

            for (int i = 0; i < requests.Length; i++)
            {
                Page.Controls.Add(new LiteralControl("<tr>"));
                for (int j = 0; j < requests[i].Length; j++)
                {
                    if (j == 2)
                    {
                        if(requests[i][j] == "0")
                            Page.Controls.Add(new LiteralControl("<td>" + "Compra" + "</td>"));
                        else
                            Page.Controls.Add(new LiteralControl("<td>" + "Venda" + "</td>"));
                    }
                    else if (j == 5 || j == 6)
                    {
                        if (requests[i][j] == "-1,0000")
                            Page.Controls.Add(new LiteralControl("<td>" + "-" + "</td>"));
                        else
                            Page.Controls.Add(new LiteralControl("<td>" + requests[i][j] + "</td>"));
                    }
                    else if (j == 7)
                    {
                        if (requests[i][j] == "0")
                            Page.Controls.Add(new LiteralControl("<td>" + "Por executar" + "</td>"));
                        else
                            Page.Controls.Add(new LiteralControl("<td>" + "Executado" + "</td>"));
                    }
                    else
                        Page.Controls.Add(new LiteralControl("<td>" + requests[i][j] + "</td>"));
                }
                Page.Controls.Add(new LiteralControl("</tr>"));
            }

            Page.Controls.Add(new LiteralControl("</table></div></div>"));
            
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