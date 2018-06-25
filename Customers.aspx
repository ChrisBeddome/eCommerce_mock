<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Chris_eCommerce.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customers</title>

    <link rel="stylesheet" href="Styles/Customers.css">
    <link href="https://fonts.googleapis.com/css?family=Fjalla+One" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="MainPanel" runat="server" Class="Panels">

            <asp:Label ID="lblCustomerID" CssClass="Labels" runat="server" Text="Customer ID"></asp:Label>
            <asp:TextBox ID="txtCustomerID" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblFirstName" CssClass="Labels" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblLastName" CssClass="Labels" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblAddress" CssClass="Labels" runat="server" Text="Address"></asp:Label>
            <asp:TextBox ID="txtAddress" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblCity" CssClass="Labels" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="txtCity" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblProvince" CssClass="Labels" runat="server" Text="Province"></asp:Label>
            <asp:TextBox ID="txtProvince" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPostal" CssClass="Labels" runat="server" Text="Postal"></asp:Label>
            <asp:TextBox ID="txtPostal" CssClass="TextBoxes" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnNew" runat="server" Text="New" CssClass="buttons" OnClick="btnNew_Click" />
            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="buttons" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="buttons" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="buttons" OnClick="btnDelete_Click" />
            <asp:Button ID="btnFind" runat="server" Text="Find" CssClass="buttons" OnClick="btnFind_Click" />

            <asp:Label ID="lblMessages" runat="server" CssClass="Messages" Text=""></asp:Label>
        </asp:Panel>

        
    </div>
    </form>
</body>
</html>