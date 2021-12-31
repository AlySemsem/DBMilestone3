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
            <br />
            <asp:Button ID="studentIDbtn" runat="server" Text="Submit" OnClick="studentIDbtn_Click" />
        </div>
    </form>
</body>
</html>
