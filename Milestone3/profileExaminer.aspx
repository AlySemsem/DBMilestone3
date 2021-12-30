<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileExaminer.aspx.cs" Inherits="Milestone3.profileExaminer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>
        Examiner Profile
    </h2>
    <form id="form1" runat="server">

    <div>
        <asp:Label ID="Label1" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Field of work: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Edit Profile" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />

        
    </div>

    </form>
</body>
</html>
