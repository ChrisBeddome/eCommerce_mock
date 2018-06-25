<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Chris_eCommerce.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Details.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Fjalla+One" rel="stylesheet">
</head>
<body>
    <div class="wrap">
        <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" CssClass="CellStyle"></asp:Table>
            <br />
            <div id="totalWrap">
                <asp:Label ID="LblTotal" runat="server" CssClass="LabelTotal" Text="0.00"></asp:Label>
            </div>
            <div id="mailWrap">
                <asp:CheckBox ID="ChkMailingList" runat="server" CssClass="Checkboxes" AutoPostback="false" Text="Add me to the Mailing List" OnCheckedChanged="AddMe" />
            </div>
            <asp:Button ID="BtnPay" runat="server" Text="Pay for my Order" CssClass="Buttons" OnClick="PayForOrder"/>
        </div>
        </form>
    </div>
</body>
</html>

