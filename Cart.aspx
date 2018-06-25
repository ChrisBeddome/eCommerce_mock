<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Chris_eCommerce.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link href="Styles/Cart.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Fjalla+One" rel="stylesheet">
</head>
<body>
   <form id="form1" runat="server">
    <div>
        
        <asp:Image ID="cart" runat="server" src="Images/cart.png" />
      
        <asp:Table ID="Table1" runat="server" CssClass="CellStyle"></asp:Table>
        <asp:Button ID="BtnRemove" CssClass="btn" runat="server" Text="Button" style="visibility:hidden" OnClick="RemoveFromCart" />
        <br />
        <div id="checkoutControls">
             <asp:Button ID="btnCheckOut" CssClass="btn" runat="server" Text="Checkout" OnClick="LoadCheckoutPage" />
            <asp:Label ID="LblTotal" runat="server" CssClass="LabelTotal" Text="0.00"></asp:Label>
            <asp:Button ID="btnRecalculate" CssClass="btn" runat="server" Text="Total" OnClick="RecalculateTotal" />

            
        </div>
        <div id="emptyNav">
            <asp:Label ID="LblEmpty" runat="server" Text="Your Cart is Empty!"></asp:Label>
            <asp:Button CssClass="btn" ID="returnButton" runat="server" Text="Return to Catalog" OnClick="returnButton_Click" />
        </div>

    </div>
    </form>
</body>
</html>
