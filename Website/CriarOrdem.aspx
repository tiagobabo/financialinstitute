<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CriarOrdem.aspx.cs" Inherits="CriarOrdem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/bootstrap.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <title>Criar Ordem</title>
</head>
<body>
<div class="container">
<div class="hero-unit" align="center">
<h1>Criar nova ordem</h1>
<br />
<br />
<br />
    <form class="form-horizontal" id="form1" runat="server">
    <fieldset>
    <div class="control-group">
        <asp:Label class="control-label" ID="Label1" runat="server" Text="ID do cliente:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </br>
        <asp:Label class="control-label" ID="Label2" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </br>
         <asp:Label class="control-label" ID="Label4" runat="server" Text="Operação:"></asp:Label>


        <asp:RadioButtonList class="radio" ID="RadioButtonList1" runat="server">
            <asp:ListItem>Compra</asp:ListItem>
            <asp:ListItem>Venda</asp:ListItem>
        </asp:RadioButtonList>

            </br>
             <asp:Label class="control-label" ID="Label5" runat="server" Text="Tipo:"></asp:Label>
             
        <asp:RadioButtonList class="radio" ID="RadioButtonList2" runat="server">
            <asp:ListItem>Ordinária</asp:ListItem>
            <asp:ListItem>Preferencial</asp:ListItem>
        </asp:RadioButtonList>


        <asp:Label class="control-label" ID="Label3" runat="server" Text="Quantidade:"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
<br />
<br />
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Criar" onclick="Button1_Click" />
        
    </div>
    </fieldset>
    </form>
</div>
</body>
</html>
