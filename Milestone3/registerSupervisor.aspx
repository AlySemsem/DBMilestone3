<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerSupervisor.aspx.cs" Inherits="Milestone3.registerSupervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1S" runat="server" Text="Supervisor Register Page"></asp:Label>
            <br />
            <br />
            <asp:Label ID="ErrorBox" runat="server" Text= "" Forecolor="red" Font-Bold="true" Font-Size="Large"> </asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2S" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:TextBox ID="firstNameS" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3S" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:TextBox ID="lastNameS" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4S" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="passwordS" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5S" runat="server" Text="Faculty"></asp:Label>
            <br />
            <asp:TextBox ID="facultyS" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6S" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="emailS" runat="server"></asp:TextBox>

            <br />
            <br />
                        <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" style="height: 29px" />

            <br />

        </div>
    </form>
</body>
</html>
