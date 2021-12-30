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
        </div>
    </form>
</body>
</html>
