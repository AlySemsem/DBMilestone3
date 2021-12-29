<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerNonGUCian.aspx.cs" Inherits="Milestone3.registerNonGUCian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1N" runat="server" Text="NonGUCian Register Page"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2N" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:TextBox ID="firstNameN" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3N" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:TextBox ID="lastNameN" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4N" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="passwordN" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5N" runat="server" Text="Faculty"></asp:Label>
            <br />
            <asp:TextBox ID="facultyN" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6N" runat="server" Text="Email"></asp:Label>
            <br />
            <asp:TextBox ID="emailN" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7N" runat="server" Text="Address"></asp:Label>
            <br />
            <asp:TextBox ID="addressN" runat="server"></asp:TextBox>

            <br />
            <br />
                   <asp:Button ID="registerN" runat="server" Text="Register" OnClick="register_Click" style="height: 29px" />

        </div>
    </form>
</body>
</html>
