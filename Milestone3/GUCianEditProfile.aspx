<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GUCianEditProfile.aspx.cs" Inherits="Milestone3.GUCianEditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            position: absolute;
            top: 237px;
            left: 44px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="font-size:30px">Edit your profile</p>
        </div>
        <asp:Label ID="Label1" runat="server" Text="First Name: "></asp:Label>
        <asp:TextBox ID="firstNameBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name: "></asp:Label>
        <asp:TextBox ID="lastNameBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="passBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Address: "></asp:Label>
        <asp:TextBox ID="addressBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Degree: "></asp:Label>
        <asp:TextBox ID="typeBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

    </form>
</body>
</html>
