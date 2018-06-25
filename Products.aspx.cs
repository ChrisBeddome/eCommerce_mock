using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Chris_eCommerce
{
    public partial class Products : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=Store";

        protected void Page_Load(object sender, EventArgs e)
        {

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        // **************************
        // Clears out all form fields
        //
        // No input arguments
        protected void btnNew_Click(object sender, EventArgs e)
        {
           txtProductID.Text = "";
            txtManufactureCode.Text = "";
            txtDescription.Text = "";
            txtStock.Text = "";
            txtPrice.Text = "";
            txtImage.Text = "";

            ImgUploadedFile.ImageUrl = "";


            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // check for blank customer number
            if (txtProductID.Text != "")
            {
                // create the objects needed for CRUD
                SqlDataAdapter sqlDataAdapter = null;
                DataSet ds = null;
                SqlConnection connectFill = null;
                SqlConnection connectCmd = null;
                SqlCommand cmd = null;
                SqlCommand scmd = null;

                // open a connection to the database
                connectCmd = new SqlConnection(dbConnect);
                connectCmd.Open();

                // now make a change to the customer last name
                string sqlString = "UPDATE Products SET ManufactureCode=@ManufactureCode, Description=@Description, Stock=@Stock, Price=@Price, Image=@Image WHERE ProID=@ProID";

                int count = 0;
                try
                {
                    cmd = new SqlCommand(sqlString, connectCmd);
                    cmd.Parameters.AddWithValue("@ManufactureCode", txtManufactureCode.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Stock", txtStock.Text);
                    cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@Image", txtImage.Text);
                    cmd.Parameters.AddWithValue("@ProID", txtProductID.Text);
                    count = cmd.ExecuteNonQuery();
                    lblMessages.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessages.Text = ex.Message;
                    DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
                }
                Console.WriteLine("Record updated");
                Console.WriteLine();

                // release all database resources (memory)
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            // open a connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            // define SQL string to delete customer by Products ID
            string sqlString = "DELETE FROM Products WHERE ProID = @ProID";

            // create an int variable to receive number of records deleted
            int count = 0;
            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ProID", txtProductID.Text);
                count = cmd.ExecuteNonQuery();

                txtProductID.Text = "";
                txtManufactureCode.Text = "";
                txtDescription.Text = "";
                txtStock.Text = "";
                txtPrice.Text = "";
                txtImage.Text = "";

                ImgUploadedFile.ImageUrl = "";

            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }
            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
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
                string sqlString = "SELECT * FROM Products WHERE ProID = @ProID";

                // create new SQL command object based on SQL string and connection
                scmd = new SqlCommand(sqlString, connectFill);

                // add the parameter to SQL string and validate
                scmd.Parameters.AddWithValue("@ProID", txtProductID.Text);

                // create a new SQL data adapter to retrieve the data and
                // fill the data set
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = scmd;
                sqlDataAdapter.Fill(ds, "Products");
            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

            if (ds.Tables["Products"].Rows.Count == 1)
            {
                txtManufactureCode.Text = ds.Tables["Products"].Rows[0]["ManufactureCode"].ToString();
                txtDescription.Text = ds.Tables["Products"].Rows[0]["Description"].ToString();
                txtStock.Text = ((int)ds.Tables["Products"].Rows[0]["Stock"]).ToString();
                txtPrice.Text = ((decimal)ds.Tables["Products"].Rows[0]["Price"]).ToString();
                txtImage.Text = ds.Tables["Products"].Rows[0]["Image"].ToString();

                //update photo
                string fileName = txtImage.Text;
                ImgUploadedFile.ImageUrl = "Pictures/" + fileName;

                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                lblMessages.Text = "";
            }
            else
            {
                lblMessages.Text = "Product Number not found!";
                ImgUploadedFile.ImageUrl = "";
            }

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);


           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // create the objects needed for CRUD
            SqlDataAdapter sqlDataAdapter = null;
            DataSet ds = null;
            SqlConnection connectFill = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;
            SqlCommand scmd = null;

            // open a connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            // create our SQL string with VALUE parameters
            string sqlString = "INSERT INTO Products (ManufactureCode, Description, Stock, Price, Image) VALUES (@ManufactureCode, @Description, @Stock, @Price, @Image)";

            try
            {
                cmd = new SqlCommand(sqlString, connectCmd);
                cmd.Parameters.AddWithValue("@ManufactureCode", txtManufactureCode.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Stock", txtStock.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Image", txtImage.Text);
  
                cmd.ExecuteNonQuery();
                lblMessages.Text = "";


                // get the primary key identity just inserted
                string identRequest = "SELECT IDENT_CURRENT('Products') FROM Products";
                cmd = new SqlCommand(identRequest, connectCmd);
                int identValue = Convert.ToInt32(cmd.ExecuteScalar());
                txtProductID.Text = identValue.ToString();



            }
            catch (Exception ex)
            {
                lblMessages.Text = ex.Message;
                DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
            }

           

            // release all database resources (memory)
            DisposeResources(ref sqlDataAdapter, ref ds, ref connectFill, ref connectCmd, ref cmd, ref scmd);
        }

        // **************************************************************
        // method releases all database resources that have been assigned
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




        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string fileName = ImageFileUpload.FileName;

            if (fileName != "")
            {
                ImageFileUpload.SaveAs(HttpContext.Current.Server.MapPath(".") + @"\Pictures\" + fileName);
                ImgUploadedFile.ImageUrl = "Pictures/" + fileName;
                txtImage.Text = fileName;
            }
        }
    }
}