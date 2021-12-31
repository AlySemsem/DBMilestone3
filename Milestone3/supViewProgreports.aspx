<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supViewProgreports.aspx.cs" Inherits="Milestone3.supViewProgreports" %>

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
            <asp:Label ID="ProgNo" runat="server" Text="Progress Report Number"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Evaluation"></asp:Label>
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" Text="0" OnCheckedChanged="RadioButton0_CheckedChanged" />
            &nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="1" OnCheckedChanged="RadioButton1_CheckedChanged" />
            &nbsp;<asp:RadioButton ID="RadioButton3" runat="server" Text="2" OnCheckedChanged="RadioButton2_CheckedChanged" />
            &nbsp;<asp:RadioButton ID="RadioButton4" runat="server" Text="3" OnCheckedChanged="RadioButton3_CheckedChanged" />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
