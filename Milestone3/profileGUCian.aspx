<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileGUCian.aspx.cs" Inherits="Milestone3.profileGUCian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            position: absolute;
            top: 15px;
            left: 102px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            
        <p>
            <asp:Label ID="Name" runat="server"></asp:Label>
            <br>
            <asp:Label ID="Type" runat="server"></asp:Label>
            <br>
            <asp:Label ID="Faculty" runat="server"></asp:Label>
            <br>
            <asp:Label ID="GPA" runat="server"></asp:Label>
            <br>
            <asp:Label ID="UndergradID" runat="server"></asp:Label>
            <br>
            <br>
            My Theses:</p>
        <table border ="1">
                <thead>
                <tr>
                    <th>serialNumber</th>
                    <th>field</th>
                    <th>type</th>
                    <th>title</th>
                    <th>startDate</th>
                    <th>endDate</th>
                    <th>defenseDate</th>
                    <th>years</th>
                    <th>grade</th>
                    <th>payment_id</th>
                    <th>noOfExtensions</th>
                 </tr>
                 </thead>
                <tbody id="ThesisBody" runat="server">
                </tbody>
            </table>
    </form>
</body>
</html>
