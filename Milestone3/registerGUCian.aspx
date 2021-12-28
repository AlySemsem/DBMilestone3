<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerGUCian.aspx.cs" Inherits="Milestone3.registerGUCian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="GUCian Register Page"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:TextBox ID="firstName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:TextBox ID="lastName" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Faculty"></asp:Label>
            <br />
            <asp:TextBox ID="faculty" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
            <br />
            <asp:TextBox ID="address" runat="server"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="register" runat="server" Text="Register" OnClick="register_Click" style="height: 29px" />

        </div>
    </form>
</body>
</html>
