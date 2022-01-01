﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileGUCian.aspx.cs" Inherits="Milestone3.profileGUCian" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style4 {
            position: absolute;
            top: 490px;
            left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <p style="font-size:50px">Student Profile</p>
        <p>
            <asp:Label ID="Name" runat="server"></asp:Label>
            <br>
            <asp:Label ID="Type" runat="server"></asp:Label>
            <br>
            <asp:Label ID="Faculty" runat="server"></asp:Label>
            <br>
            <asp:Label ID="GPA" runat="server"></asp:Label>
            <br>
            <asp:Label ID="UndergradID" OnClick="edit" runat="server"></asp:Label>
            <br>
            <br>
            <asp:Button ID="editButton" runat="server" Text="Edit Profile" OnClick="editButton_Click" />
            <br>
            <br>
           <p style="font-size:20px">My Theses:</p></p>
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
        <br />
        <p style="font-size:20px">Add Progress Report:</p>
            <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number: "></asp:Label>
            <asp:TextBox ID="thesisSerialBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Progress Report Date: "></asp:Label>
        <asp:TextBox ID="reportDateBox" runat="server" type="date"></asp:TextBox>
        <br />
        <asp:Button ID="addProgressReport" runat="server" Text="Add" OnClick="addProgressReport_Click" />
            </p>
        <p style="font-size:20px">Fill Progress Report:</p>
            <asp:Label ID="Label3" runat="server" Text="Thesis Serial Number: "></asp:Label>
            <asp:TextBox ID="thesisSerialBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Progress Report Number: "></asp:Label>
        <asp:TextBox ID="progressReportNumberBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="State: "></asp:Label>
        <asp:TextBox ID="stateBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Description: "></asp:Label>
        <asp:TextBox ID="descriptionBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="fillProgressReport" runat="server" Text="Fill" OnClick="fillProgressReport_Click" />
            </p>
        <br />
        <p style="font-size:20px">Add Publication:</p>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Title: "></asp:Label>
        <asp:TextBox ID="titleBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Publication Date: "></asp:Label>
        <asp:TextBox ID="pubDateBox" runat="server" type="date"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Host: "></asp:Label>
        <asp:TextBox ID="hostBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Place: "></asp:Label>
        <asp:TextBox ID="placeBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label11" runat="server" Text="Accepted: "></asp:Label>
        <asp:DropDownList ID="acceptedList" runat="server">
            <asp:ListItem Value="1"> Yes </asp:ListItem>
            <asp:ListItem Value="0"> No </asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="pubAddButton" runat="server" Text="Add" OnClick="pubAddButton_Click" />
        <br />
        <br />
        <p style="font-size:20px">Fill Publication:</p>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Publication ID: "></asp:Label>
        <asp:TextBox ID="pubIDBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Thesis Serial Number: "></asp:Label>
        <asp:TextBox ID="thesisSerialNoBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="pubLinkButton" runat="server" Text="Link" OnClick="pubLinkButton_Click" />

    </form>
</body>
</html>
