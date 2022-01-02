<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supViewPublications.aspx.cs" Inherits="Milestone3.supViewPublications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please enter the student ID"></asp:Label>
            <br />
            <asp:TextBox ID="studentID_TB" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="view" runat="server" Text="View" OnClick="view_Click" style="height: 29px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /> 
            &nbsp;<asp:Label ID="ErrorBox" runat="server" Text= "" Forecolor="red" Font-Bold="true" Font-Size="Large"> </asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
