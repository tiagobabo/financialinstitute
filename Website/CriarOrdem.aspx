<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CriarOrdem.aspx.cs" Inherits="CriarOrdem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h1>Criar nova ordem</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="ID do cliente:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </br>
        <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </br>
         <asp:Label ID="Label4" runat="server" Text="Operação:"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Compra</asp:ListItem>
            <asp:ListItem>Venda</asp:ListItem>
        </asp:RadioButtonList>
            </br>
             <asp:Label ID="Label5" runat="server" Text="Tipo:"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonList2" runat="server">
            <asp:ListItem>Tipo 1</asp:ListItem>
            <asp:ListItem>Tipo 2</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label3" runat="server" Text="Quantidade:"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        
        <asp:Button ID="Button1" runat="server" Text="Criar" onclick="Button1_Click" />
        
    </div>
    </form>
</body>
</html>
