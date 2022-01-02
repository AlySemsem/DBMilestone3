<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerExaminer.aspx.cs" Inherits="Milestone3.registerExaminer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label1" runat="server" Text="Examiner Register Page"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2E" runat="server" Text="Examiner Name"></asp:Label>
            <br />
            <asp:TextBox ID="ExaminerName" runat="server"></asp:TextBox>
             <br />
             <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
             <br />
             <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3E" runat="server" Text="Thesis Serial Number"></asp:Label>
            <br />
            <asp:TextBox ID="ThesisSerialNo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4E" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5E" runat="server" Text="Field Of Work"></asp:Label>
            <br />
            <asp:TextBox ID="fieldOfWork" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6E" runat="server" Text="Defence Date"></asp:Label>
            <br />
            <asp:TextBox ID="defdate" runat="server" type ="date"></asp:TextBox>
            <br />
            <asp:Label ID="Label7E" runat="server" Text="National"></asp:Label>
            <br />
            
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" GroupName="gender" OnCheckedChanged="RadioButton1_CheckedChanged" />
            <asp:RadioButton ID="RadioButton2" runat="server" Text="No" GroupName="gender" OnCheckedChanged="RadioButton2_CheckedChanged" />

            <br />
            <br />
               <asp:Button ID="registerE" runat="server" Text="Register" OnClick="register_Click" style="height: 29px" />


        </div>
    </form>
</body>
</html>
