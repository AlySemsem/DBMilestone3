<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addMobileNumber.aspx.cs" Inherits="Milestone3.addMobileNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Add Mobile Number"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="mobNoTB" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="msgTB" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="loginBtn" runat="server" Text="Go to login page" OnClick="loginBtn_Click" />
        </div>
    </form>
</body>
</html>
