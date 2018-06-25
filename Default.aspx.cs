using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chris_eCommerce
{
    public partial class Default : System.Web.UI.Page
    {


        const int MAXPRODUCTS = 10;

        public static string[] modelNum;
        public static string[] pics;
        public static string[] descrip;
        public static string[] qty;
        public static string[] price;

        public static string[] qtySold = new string[MAXPRODUCTS];
        public static int[] cartInfo = new int[MAXPRODUCTS];
        public static int numItems = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            MainFrame.Attributes.Add("src", "PromoPage.aspx");

            if (!IsPostBack)
            {
                for (int i = 0; i < MAXPRODUCTS; i++)
                    qtySold[i] = "1";
            }
        }

        protected void BtnPromoPage_Click(object sender, EventArgs e)
        {
            MainFrame.Attributes.Add("src", "PromoPage.aspx");
        }

        protected void BtnCustomers_Click(object sender, EventArgs e)
        {
            MainFrame.Attributes.Add("src", "Customers.aspx");
        }

        protected void BtnProducts_Click(object sender, EventArgs e)
        {
            MainFrame.Attributes.Add("src", "Products.aspx");
        }

        protected void BtnCart_Click(object sender, EventArgs e)
        {
            MainFrame.Attributes.Add("src", "Cart.aspx");
        }

        protected void BtnCatalog_Click(object sender, EventArgs e)
        {
            MainFrame.Attributes.Add("src", "Catalog.aspx");
        }

       
    }
}