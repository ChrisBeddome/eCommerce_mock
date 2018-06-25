using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chris_eCommerce
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateCartGrid();
            CalculateTotal();
            CheckIfEmpty();
           
        }

        protected void RemoveFromCart(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int row = int.Parse(b.ID);

            Default.qtySold[Default.cartInfo[row]] = "1";
            // delete the cart item from the Main.cartInfo array
            // ... then rebuild the cart grid
            for (int i = row; i < Default.numItems; i++)
                Default.cartInfo[i] = Default.cartInfo[i + 1];

            Default.numItems--;
            CreateCartGrid();
            CalculateTotal();
            CheckIfEmpty();
           

        }

        private void CreateCartGrid()
        {
            Table1.Rows.Clear();

           /*
            TableRow head = new TableRow();
            TableCell headCell1 = new TableCell();
            TableCell headCell2 = new TableCell();
            TableCell headCell3 = new TableCell();
            TableCell headCell4 = new TableCell();
            TableCell headCell5 = new TableCell();
            TableCell headCell6 = new TableCell();
            TableCell headCell7 = new TableCell();

            headCell1.Text = "Image";
            headCell2.Text = "Product Number";
            headCell3.Text = "Item";
            headCell4.Text = "Stock";
            headCell5.Text = "Price";
            headCell6.Text = "";
            headCell7.Text = "Quantity";



            head.Cells.Add(headCell1);
            head.Cells.Add(headCell2);
            head.Cells.Add(headCell3);
            head.Cells.Add(headCell4);
            head.Cells.Add(headCell5);
            head.Cells.Add(headCell6);
            head.Cells.Add(headCell7);

            Table1.Rows.Add(head);
*/
    

            for (int i = 0; i < Default.numItems; i++)
            {
                // add new empty row object
                TableRow row = new TableRow();
                for (int j = 0; j < 7; j++)
                {
                    // add new empty cell object
                    TableCell cell = new TableCell();

                    if (j == 0)
                    {
                        Image pic = new Image();
                        pic.ImageUrl = "pictures/" + Default.pics[Default.cartInfo[i]];
                        pic.Height = 100;
                        pic.Width = 120;
                        cell.Controls.Add(pic);
                    }
                    else if (j == 1)
                    {
                        cell.Text = Default.modelNum[Default.cartInfo[i]];
                    }
                    else if (j == 2)
                    {
                        cell.Text = Default.descrip[Default.cartInfo[i]];
                    }
                    else if (j == 3)
                    {
                        cell.Text = Default.qty[Default.cartInfo[i]];
                    }
                    else if (j == 4)
                    {
                        Label price = new Label();
                        price.Text = Default.price[Default.cartInfo[i]];

                        // this is the line of code we were missing in class
                        cell.Controls.Add(price);
                    }
                    else if (j == 5)
                    {
                        Button btnAddToCart = new Button();
                        btnAddToCart.ID = i.ToString();

                        btnAddToCart.Click += new EventHandler(RemoveFromCart);
                        btnAddToCart.Text = "Remove from Cart";
                        cell.Controls.Add(btnAddToCart);
                        btnAddToCart.CssClass = "btn";
                    }
                    else
                    {
                        TextBox text = new TextBox();
                        text.Text = Default.qtySold[Default.cartInfo[i]]; 
                        text.CssClass = "TextBoxes";

                        cell.Controls.Add(text);
                    }
                    // now add all the cells for the current row
                    row.Cells.Add(cell);
                }
                // finally, add the current row to the table
                Table1.Rows.Add(row);
            }
        }

        protected void RecalculateTotal(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            for (int i = 0; i < Default.numItems; i++) 
            {
                TableRow row = Table1.Rows[i];
                decimal rowPrice = 0;

                for (int j = 0; j < 7; j++)
                {
                    TableCell cell = row.Cells[j];

                    if (j == 4)
                    {
                        Control ctrl = cell.Controls[0];
                        Label lbl = (Label)ctrl;
                        string price = lbl.Text;
                        rowPrice = decimal.Parse(price);
                    }
                    else if (j == 6)
                    {
                        Control ctrl = cell.Controls[0];
                        TextBox txt = (TextBox)ctrl;
                        string qty = txt.Text;
                        Default.qtySold[Default.cartInfo[i]] = qty;

                        decimal rowTotal = rowPrice * int.Parse(qty);
                        total += rowTotal;
                    }
                }
            }

            LblTotal.Text = total.ToString("$##,##0.#0");
        }

        protected void LoadCheckoutPage(object sender, EventArgs e)
        {
            Server.Transfer("Checkout.aspx");
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("Catalog.aspx");
        }

        private void CheckIfEmpty()
        {
            if (Default.numItems != 0)
            {
                LblEmpty.Style["visibility"] = "hidden";
                returnButton.Style["visibility"] = "hidden";
                btnCheckOut.Style["visibility"] = "visible";
                LblTotal.Style["visibility"] = "visible";
                btnRecalculate.Style["visibility"] = "visible";
                Table1.Style["visibility"] = "visible";
                cart.Style["visibility"] = "visible";
            }
            else
            {
                LblEmpty.Style["visibility"] = "visible";
                returnButton.Style["visibility"] = "visible";
                btnCheckOut.Style["visibility"] = "hidden";
                LblTotal.Style["visibility"] = "hidden";
                btnRecalculate.Style["visibility"] = "hidden";
                Table1.Style["visibility"] = "hidden";
                cart.Style["visibility"] = "hidden";
            }
        }
    }
}