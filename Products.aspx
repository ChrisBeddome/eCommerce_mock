<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Chris_eCommerce.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Products.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Panel ID="ProductPanel" CssClass="Panels" runat="server">


            <asp:Button ID="btnNew" CssClass="navButtons" runat="server" Text="New" OnClick="btnNew_Click" />
            <asp:Button ID="btnAdd" CssClass="navButtons" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" CssClass="navButtons" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" CssClass="navButtons" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnFind" CssClass="navButtons" runat="server" Text="Find" OnClick="btnFind_Click" />



            <asp:Label ID="lblProductID" CssClass="Labels" runat="server" Text="Product ID: "></asp:Label>
            <asp:TextBox ID="txtProductID" CssClass="TextBoxes" runat="server"></asp:TextBox>

            <asp:Label ID="lblManufactureCode" CssClass="Labels" runat="server" Text="Manufacturer #: "></asp:Label>
            <asp:TextBox ID="txtManufactureCode" CssClass="TextBoxes" runat="server"></asp:TextBox>

            <asp:Label ID="lblDescription" CssClass="Labels" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="txtDescription" CssClass="TextBoxes" runat="server"></asp:TextBox>

            <asp:Label ID="lblStock" CssClass="Labels" runat="server" Text="Stock: "></asp:Label>
            <asp:TextBox ID="txtStock" CssClass="TextBoxes" runat="server"></asp:TextBox>

            <asp:Label ID="lblPrice" CssClass="Labels" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice" CssClass="TextBoxes" runat="server"></asp:TextBox>

            <asp:Label ID="lblImage" CssClass="Labels" runat="server" Text="Image:"></asp:Label>
            <asp:TextBox ID="txtImage" CssClass="TextBoxes" runat="server"></asp:TextBox>
            
            
            
            <asp:FileUpload ID="ImageFileUpload" CssClass="Buttons" runat="server" />
            <asp:Button ID="BtnUpload" CssClass="Buttons" runat="server" Text="Upload" OnClick="BtnUpload_Click" />
            <asp:Image ID="ImgUploadedFile" CssClass="Images" runat="server" />

        </asp:Panel>

        <asp:Label ID="lblMessages" runat="server" CssClass="Messages" style="left:10px; top:300px; right:10px; height:16px; background-color:aliceBlue" Text=""></asp:Label>

        



    </div>
    </form>
</body>
</html>
