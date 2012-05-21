<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultarOrdens.aspx.cs" Inherits="ConsultarOrdens" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/bootstrap.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <title>Consultar Ordem</title>
</head>
<body>
<div class="container">
<div class="hero-unit" align="center">
<h1>Consultar ordens</h1>
<br />
<br />
<br />
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="ID do cliente:"></asp:Label>
         <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Atualizar" 
            onclick="Button1_Click" />
    </div>
    </form>
    </div>
    </div>
</body>
</html>
