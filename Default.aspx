<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chris_eCommerce.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Default.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Fjalla+One" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>

        
	    <header>
		    <asp:panel ID="nav" runat="server">
                <h1>SHMOOPY DOOP SHOPPING</h1>
			    <ul>
                    
				    <li><asp:LinkButton  runat="server" OnClick="BtnPromoPage_Click" Text="Home" /></li>
				    <li><asp:LinkButton  runat="server" OnClick="BtnCatalog_Click" Text="Catalog" /></li>
				    <li><asp:LinkButton ID="cartButton"  runat="server" OnClick="BtnCart_Click" Text="Cart" /></li>
				    <li><asp:LinkButton  runat="server" OnClick="BtnCustomers_Click" Text="Customers" /></li>
                    <li><asp:LinkButton  runat="server" OnClick="BtnProducts_Click" Text="Products" /></li>

			    </ul>
		   </asp:panel>
	    </header>
        
        
           
        
        <iframe id="MainFrame" class="MainContainer" src="" runat="server"> </iframe>    
    </div>
    </form>
</body>
</html>

