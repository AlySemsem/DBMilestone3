<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supCancelThesis.aspx.cs" Inherits="Milestone3.supCancelThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="TSN" runat="server" Text="Thesis Serial Number"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
        </div>
    </form>
</body>
</html>
