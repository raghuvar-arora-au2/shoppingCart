using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCartDemo
{
    public partial class Cart : System.Web.UI.Page
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingCartDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(ConnectionString);
           

            //string query = "insert into Orders (CustomerID, OrderDateTime, TotalAmount) values (1, GETDATE() , " + Decimal.Parse(lblTotalAmount.Text) + "); SELECT SCOPE_IDENTITY();";

            //SqlCommand cmd = new SqlCommand(query, con);
            //con.Open();
            //int OrderID = Convert.ToInt32(cmd.ExecuteScalar());

            //query = "insert into OrderDetails (OrderID, ProductID, Quantity, Amount) select " + OrderID + " AS OrderID, ProductID, Quantity, Amount from Cart where CartID='" + Session.SessionID + "'";

            //cmd = new SqlCommand(query, con);

            //cmd.ExecuteNonQuery();

            //query = "delete from Cart where CartID='" + Session.SessionID + "'";

            //cmd = new SqlCommand(query, con);

            //cmd.ExecuteNonQuery();

            //cmd.Dispose();

            //DatabaseConnection.CloseConnection(con);

            ClientScript.RegisterStartupScript(GetType(), "Popup", "successalert();", true);
        }

        private void CalculateTotalAmount()
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("select sum(Amount) from Cart where CartID='" + Session.SessionID + "'", con);
            con.Open();
            lblTotalAmount.Text = cmd.ExecuteScalar().ToString();

            cmd.Dispose();
            

            con.Close() ;
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            CalculateTotalAmount();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            CalculateTotalAmount();
        }
    }
}