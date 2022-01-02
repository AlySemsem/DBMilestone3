<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCommentOrGrade.aspx.cs" Inherits="Milestone3.addCommentOrGrade" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Add Comment or Grade to Defense</h2>
    <table border="1">
        <thead>
            <tr>
                <th>Thesis ID</th>
                <th>Date/Time</th>
                <th>Location</th>
                <th>Grade</th>
                <th>Comment</th>
            </tr>
        </thead>
        <tbody id="tableBody" runat="server"></tbody>
    </table>
        <br />
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Serial Number "></asp:Label>
        <asp:TextBox ID="SD" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Date/Time "></asp:Label>
        <asp:TextBox ID="DT" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="New Grade "></asp:Label>
        <asp:TextBox ID="newGrade" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="New Comment "></asp:Label>
        <asp:TextBox ID="newComment" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="error" runat="server" Text="" style="color:red"></asp:Label>
        <asp:Label ID="error2" runat="server" Text="" style="color:red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="Edit Grade" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Text="Edit Comment" OnClick="Button3_Click" />
        <br />
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>