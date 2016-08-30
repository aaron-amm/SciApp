<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="SciHospital.WebApp.MyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        <br/>
        <br/>

        <asp:Button ID="btnSay" runat="server" Text="say something" OnClick="btnSay_OnClick"></asp:Button>
    </div>
    </form>
</body>
</html>
