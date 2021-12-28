<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUC_System.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml%22%3E">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Label ID="Label1" runat="server" Text="Please Log in"></asp:Label>
            <br />
            <br />
            ID:<br />
            <asp:TextBox ID="ID" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:<br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="login" Text="Login" />
        </div>
    </form>
</body>
</html>