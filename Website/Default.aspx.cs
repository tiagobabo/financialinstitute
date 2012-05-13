using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Server;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {
    }

    protected void Button1_Click(object sender, EventArgs e) {
        FinancialOpsClient server = new FinancialOpsClient();
        Boolean op = server.NewOrder(1, "asd@asd.com", 0, 1, 10);
        server.Close();
    }
}