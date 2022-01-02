<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerPage.aspx.cs" Inherits="Milestone3.registerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <a href="registerPage.aspx">registerPage.aspx</a>
        <div>
            <asp:Button ID="Button1" runat="server" Text="GUCian" onclick="registerGUCianF"/>
            <asp:Button ID="Button2" runat="server" Text="NonGUCian" onclick="registerNonGUCianF"/>
            <asp:Button ID="Button3" runat="server" Text="Supervisor" onclick="registerSupervisorF"/>
            <asp:Button ID="Button4" runat="server" Text="Examiner" onclick="registerExaminerF"/>
        </div>
    </form>
</body>
</html>
