<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDefenseGucian.aspx.cs" Inherits="Milestone3.AddDefenseGucian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="thesislabel" runat="server" Text="ThesisSerialNo "></asp:Label>
            <br />
            <asp:TextBox ID="TSN" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="errTB" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="DefenseDateC" runat="server" Text="DefenseDate"></asp:Label>
            <br />
            <asp:TextBox ID="DefD" runat="server" Type="date"></asp:TextBox>
            <br />
            <asp:Label ID="label2" runat="server" Text="DefenseLocation"></asp:Label>
            <br />
            <asp:TextBox ID="DefLoc" runat="server"></asp:TextBox>
            <br />
            <br />
            Add examiner for the defense:<br />
            <br />
            <asp:Label ID="label4" runat="server" Text="Examiner Name "></asp:Label>
            <br />
            <asp:TextBox ID="ExamName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="label44" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="passTB" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="National"></asp:Label>
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text= "Yes" GroupName="National" />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" Text= "No" GroupName="National"/>
            <br />
            <br />
            <asp:Label ID="label33" runat="server" Text="Field Of Work "></asp:Label>
            <br />
            <asp:TextBox ID="FoWork" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Submitbtn" runat="server" Text="Submit" OnClick="Submitbtn_Click" />
        </div>
    </form>
</body>
</html>
