<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Chris_eCommerce.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalog</title>
    <link href="Styles/Catalog.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Fjalla+One" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        
        
        <asp:Table ID="Table1" CssClass="CellStyle" runat="server"> </asp:Table>
        <asp:Button  ID="Button1" runat="server" style="visibility:hidden" Text="Button" OnClick="Button1_Click" />
        <footer>
         
            <asp:LinkButton ID="btnCart" runat="server" OnClick="btnCart_Click">View Cart</asp:LinkButton>


            <asp:Label ID="Label1" runat="server" Text="ITEMS IN CART:"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
        </footer>
    </div>
    </form>
</body>
</html>
