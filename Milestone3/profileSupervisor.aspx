<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileSupervisor.aspx.cs" Inherits="Milestone3.profileSupervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             What do you want to do ?<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Students" Text="View Students" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Publications" Text="View Publications" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Defense" Text="Add Defense" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="PR" Text="Evaluate Progress Report" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Thesis" Text="Cancel Thesis" />
        </div>
    </form>
</body>
</html>
