using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Chris_eCommerce
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Label2.Text = Default.numItems.ToString();

            string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=Store";

            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            try
            {
                // create a new data set object called ds
                ds = new DataSet();
                // create a connection to the database called connectFill
                connectFill = new SqlConnection(dbConnect);

                // create SQL string to select customer record
                string sqlString = "SELECT * FROM Products";

                // create new SQL command object based on SQL string and connection
                scmd = new SqlCommand(sqlString, connectFill);

                // create a new SQL data adapter to retrieve the data and
                // fill the data set
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            int numProducts = 0;
            if (ds.Tables["Products"].Rows.Count > 0)
            {
                numProducts = ds.Tables["Products"].Rows.Count;

                Default.modelNum = new string[numProducts];
                Default.pics = new string[numProducts];
                Default.descrip = new string[numProducts];
                Default.qty = new string[numProducts];
                Default.price = new string[numProducts];

                for (int i = 0; i < numProducts; i++)
                {
                    Default.modelNum[i] = ((int)ds.Tables["Products"].Rows[i]["ProID"]).ToString();
                    Default.descrip[i] = ds.Tables["Products"].Rows[i]["Description"].ToString();
                    Default.pics[i] = ds.Tables["Products"].Rows[i]["Image"].ToString();
                    Default.qty[i] = ((int)ds.Tables["Products"].Rows[i]["Stock"]).ToString();
                    Default.price[i] = ((decimal)ds.Tables["Products"].Rows[i]["Price"]).ToString();
                }
            }
            



            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);

            TableRow head = new TableRow();
            TableCell headCell1 = new TableCell();
            TableCell headCell2 = new TableCell();
            TableCell headCell3 = new TableCell();
            TableCell headCell4 = new TableCell();
            TableCell headCell5 = new TableCell();
            TableCell headCell6 = new TableCell();

            headCell1.Text = "Image";
            headCell2.Text = "Product Number";
            headCell3.Text = "Item";
            headCell4.Text = "Stock";
            headCell5.Text = "Price";
            headCell6.Text = "";

            head.Cells.Add(headCell1);
            head.Cells.Add(headCell2);
            head.Cells.Add(headCell3);
            head.Cells.Add(headCell4);
            head.Cells.Add(headCell5);
            head.Cells.Add(headCell6);

            Table1.Rows.Add(head);




            for (int i = 0; i < numProducts; i++)
            {
                // add new empty row object
                TableRow row = new TableRow();
                for (int j = 0; j < 6; j++)
                {

                  
                    // add new empty cell object
                    TableCell cell = new TableCell();

                    if (j == 0)
                    {
                        Image pic = new Image();
                        pic.ImageUrl = "pictures/" + Default.pics[i];
                        pic.Height = 130;
                        pic.Width = 170;
                        cell.Controls.Add(pic);
                    }
                    else if (j == 1)
                    {
                        cell.Text = Default.modelNum[i];
                    }
                    else if (j == 2)
                    {
                        cell.Text = Default.descrip[i];
                    }
                    else if (j == 3)
                    {
                        cell.Text = Default.qty[i];
                    }
                    else if (j == 4)
                    {
                        cell.Text = Default.price[i];
                    }
                    else
                    {
                        Button btnAddToCart = new Button();
                        //btnAddToCart.ID = "Row_" + i;
                        btnAddToCart.ID = i.ToString();
                        btnAddToCart.CssClass = "btn";

                        btnAddToCart.Click += new EventHandler(Button1_Click);
                        btnAddToCart.Text = "Add To Cart";
                        cell.Controls.Add(btnAddToCart);
                    }
                    // now add all the cells for the current row
                    row.Cells.Add(cell);
                }
                // finally, add the current row to the table
                Table1.Rows.Add(row);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // create a button object from the sender
            // and cast the sender object to a button
            Button b = (Button)sender;
            int row = int.Parse(b.ID);

            if (Default.numItems > 0)
            {
                bool matchRow = false;
                for (int i = 0; i < Default.numItems; i++)
                {
                    if (row == Default.cartInfo[i])
                    {
                        matchRow = true;
                        break;
                    }
                }

                if (!matchRow)
                {
                    Default.cartInfo[Default.numItems] = row;
                    Default.numItems++;
                    Label2.Text = Default.numItems.ToString();
                    
                }
            }
            else
            {
                Default.cartInfo[Default.numItems] = row;
                Default.numItems++;
                Label2.Text = Default.numItems.ToString();

            }
        }


        private static void DisposeResources(ref SqlDataAdapter sqlDataAdapter,
            ref DataSet ds,
            ref SqlConnection connectFill,
            ref SqlConnection connectCmd,
            ref SqlCommand cmd,
            ref SqlCommand scmd)
        {
            if (sqlDataAdapter != null)
                sqlDataAdapter.Dispose();
            if (ds != null)
                ds.Dispose();
            if (connectFill != null)
                connectFill.Dispose();
            if (connectCmd != null)
                connectCmd.Dispose();
            if (cmd != null)
                cmd.Dispose();
            if (scmd != null)
                scmd.Dispose();
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Server.Transfer("Cart.aspx");
        }
    }
}