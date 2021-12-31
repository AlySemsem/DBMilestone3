<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileAdmin.aspx.cs" Inherits="Milestone3.profileAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Admin Profile Page</h2>
            <br />
             <h3>Supervisors' Information</h3>
            <table border ="1">
                <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Password</th>
                    <th>Faculty</th>
                 </tr>
                 </thead>
                <tbody id="supervisorBody" runat="server">

                </tbody>
            </table>
            <h3>All Available Theses</h3>
            <br />
            <table border ="1">
                <thead>
                <tr>
                    <th>Serial Number</th>
                    <th>Field</th>
                    <th>Type</th>
                    <th>Title</th>
                    <th>Start Date</th>
                    <th>End Date</th>
                    <th>Defense Date</th>
                    <th>Years</th>
                    <th>Grade</th>
                    <th>Payment ID</th>
                    <th>No. Of Extensions</th>
                 </tr>
                 </thead>
                <tbody id="thesisBody" runat="server">

                </tbody>
            </table>
            <br />
            <asp:Label ID="Label1" runat="server" Text="On Going Theses Count: "></asp:Label>
            <br />
            <h3>Issue Thesis Payment</h3>
            <asp:Label ID="Label2" runat="server" Text="Thesis Serial Number: "></asp:Label>
            <br />
            <asp:TextBox ID="ThesisID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Amount:"></asp:Label>
            <br />
            <asp:TextBox ID="amountT" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="No. Of Installments:"></asp:Label>
            <br />
            <asp:TextBox ID="NoIns" runat="server"></asp:TextBox>
            <br />   
            <asp:Label ID="Label5" runat="server" Text="Fund Percentage:"></asp:Label>
            <br />
            <asp:TextBox ID="fundperc" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="registerN" runat="server" Text="Issue" OnClick="Issue_Click" Width="167px"  />
            <br />
            <br />
            <h3>Issue Installments</h3>
            <br />
            <h3>Increase Number Of Extensions</h3>
            <asp:Label ID="Label6" runat="server" Text="Thesis Serial Number: "></asp:Label>
            <br />
            <asp:TextBox ID="ThesisID2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="incExt" runat="server" Text="Increment Extensions" OnClick="increase_Click" Width="168px" />
        </div>
    </form>
</body>
</html>
