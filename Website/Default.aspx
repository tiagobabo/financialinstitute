<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="pt">
<head runat="server">
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <title>Cliente Online</title>
</head>
<body>
<div class="container">
<div class="hero-unit" align="center">
<h1>Cliente Online</h1>
<br />
<br />
<br />
<form id="form1" runat="server">
<asp:Button class="btn btn-primary btn-large" ID="Button1" runat="server" onclick="Button1_Click" Text="Criar nova ordem" />
<asp:Button class="btn btn-primary btn-large" ID="Button2" runat="server" onclick="Button2_Click" Text="Consultar ordens" />
</form>
</div>
</body>
</html>
