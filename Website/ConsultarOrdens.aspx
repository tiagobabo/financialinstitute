<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultarOrdens.aspx.cs" Inherits="ConsultarOrdens" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h1>Consultar ordens</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="ID do cliente:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Atualizar" 
            onclick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
