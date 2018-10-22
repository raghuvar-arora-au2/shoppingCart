using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ShoppingCartDemo
{
    public partial class checkout : System.Web.UI.Page
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingCartDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            amount.Text = CalculateTotalAmount();
        }

        protected void btn_click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConnectionString);


            string query = "insert into Orders (CustomerID, OrderDateTime, TotalAmount) values (1, GETDATE() , " + (CalculateTotalAmount().ToString()) + "); SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int OrderID = Convert.ToInt32(cmd.ExecuteScalar());

            query = "insert into OrderDetails (OrderID, ProductID, Quantity, Amount) select " + OrderID + " AS OrderID, ProductID, Quantity, Amount from Cart where CartID='" + Session.SessionID + "'";

            cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            query = "delete from Cart where CartID='" + Session.SessionID + "'";

            cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            DatabaseConnection.CloseConnection(con);
            System.Diagnostics.Debug.WriteLine("here");

            ClientScript.RegisterStartupScript(GetType(), "Popup", "successalert();", true);
            System.Diagnostics.Debug.WriteLine("executed?");

        }
        private String CalculateTotalAmount()
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand("select sum(Amount) from Cart where CartID='" + Session.SessionID + "'", con);
            con.Open();
            String total = cmd.ExecuteScalar().ToString();

            cmd.Dispose();

            con.Close();
            return total;
        }
    }
}