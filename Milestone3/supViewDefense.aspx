<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supViewDefense.aspx.cs" Inherits="Milestone3.supViewDefense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Add defense for a GUCian or a non GUCian Student ? "></asp:Label>
            <br />
            <br />
            <asp:Button ID="GUCian" runat="server" Text="GUCian" OnClick="GUCian_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="nonGucian" runat="server" Text="non Gucian" OnClick="nonGucian_Click" />
        &nbsp;</div>
    </form>
</body>
</html>
