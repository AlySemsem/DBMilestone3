<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDefenseNonGucian.aspx.cs" Inherits="Milestone3.AddDefenseNonGucian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="ThesisSerialNoTB" runat="server" Text="ThesisSerialNo "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="DefenseDateC" runat="server" Text="DefenseDate"></asp:Label>
            <br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <asp:Label ID="DefenseLocationTB" runat="server" Text="DefenseLocation"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            Add examiner for the defense:<br />
            <br />
            <asp:Label ID="eName" runat="server" Text="Examiner Name "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="pass" runat="server" Text="Password"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="National"></asp:Label>
            <br />
            <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text= "Yes" />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" OnCheckedChanged="RadioButton2_CheckedChanged" Text= "No" />
            <br />
            <br />
            <asp:Label ID="fow" runat="server" Text="Field Of Work "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Submitbtn" runat="server" Text="Submit" OnClick="Submitbtn_Click" />
        </div>
    </form>
</body>
</html>
