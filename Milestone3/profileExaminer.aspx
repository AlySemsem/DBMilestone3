<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileExaminer.aspx.cs" Inherits="Milestone3.profileExaminer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <h2>
        Examiner Profile
    </h2>

    <div>
        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Field of work: "></asp:Label>
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Email: "></asp:Label>
        <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Password: "></asp:Label>
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Edit Profile" OnClick="Button1_Click" />
        <br />
        <h3>Current Defenses</h3>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Add Comment or Grade" OnClick="Button2_Click" />
        <br />
        <br />
        <br />
        <h3>Search for Thesis</h3>
        <asp:TextBox ID="search" runat="server"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="Search" OnClick="Button3_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
        <br />

        
    </div>

    </form>
</body>
</html>
