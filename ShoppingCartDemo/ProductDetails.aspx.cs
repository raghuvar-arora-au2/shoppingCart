using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCartDemo
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingCartDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

            int pid = int.Parse(Request.QueryString["pid"]);
           // int pid = 1;
            SqlConnection con = new SqlConnection(ConnectionString);

            

            SqlCommand cmd = new SqlCommand("select * from Products where ProductID="+pid, con);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                lblProductID.Text = pid.ToString();
                lblProductName.Text = dr[1].ToString();
                lblProductPrice.Text = dr[2].ToString();
                Image1.ImageUrl = dr[3].ToString();
                lblAmount.Text = CalculateAmount(txtQuantity.Text, dr[2].ToString());
            }

            dr.Close();
            con.Open();
            cmd = new SqlCommand("select count(*) from Cart where CartID='" + Session.SessionID + "';", con);
            object items = cmd.ExecuteScalar();
            number.Text = items.ToString();

            cmd.Dispose();

            DatabaseConnection.CloseConnection(con);
        }

        private string CalculateAmount(string Quantity, string Price)
        {
            int qty = int.Parse(Quantity);

            Decimal price = Decimal.Parse(Price);

            Decimal amount = qty * price;

            return amount.ToString();
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            lblAmount.Text = CalculateAmount(txtQuantity.Text, lblProductPrice.Text);
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            

            string query = "insert into Cart (ProductID, Quantity, Price, Amount, CartID) values (" + lblProductID.Text + ", " + txtQuantity.Text +", " + lblProductPrice.Text + ", " + lblAmount.Text +", '" + Session.SessionID+ "')";

            SqlCommand cmd = new SqlCommand(query,con);
            con.Open();
            cmd.ExecuteNonQuery();

            Session["CartID"] = Session.SessionID;

            cmd.Dispose();

            DatabaseConnection.CloseConnection(con);

            ClientScript.RegisterStartupScript(GetType(), "Popup", "successalert();", true);
        }
    }
}