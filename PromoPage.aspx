<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PromoPage.aspx.cs" Inherits="Chris_eCommerce.PromoPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Promotions</title>
    <link href="Styles/Promotions.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Fjalla+One" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>SHMOOPY DOOP</h1>
        <asp:button ID="btnViewCatalog" CssClass="btn"  runat="server" text="View Catalog" OnClick="btnViewCatalog_Click" />
    </div>
    </form>
</body>
</html>

