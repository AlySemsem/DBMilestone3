<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editExaminerProfile.aspx.cs" Inherits="Milestone3.editExaminerProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h3>Edit your profile</h3>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Field of work"></asp:Label>
            <asp:TextBox ID="fieldofwork" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="errorEdit" runat="server" Text="" style="color:red"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Confirm Changes" OnClick="Button1_Click" />
            <br />
        </div>
    </form>
</body>
</html>
