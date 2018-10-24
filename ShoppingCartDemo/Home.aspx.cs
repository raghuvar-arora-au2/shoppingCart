using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ShoppingCartDemo
{
    public partial class Home : System.Web.UI.Page
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingCartDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            Literal1.Text += "<div class='row'>";

            SqlConnection con = new SqlConnection(ConnectionString);

            //DatabaseConnection.OpenConnection(con);
            SqlCommand cmd = new SqlCommand("select * from Products", con);
            con.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                Literal1.Text += "<div class='col-sm-4'>";
                Literal1.Text += "<div class='panel panel-primary'>";
                Literal1.Text += "<div class='panel-heading'>" + dr[1] + "</div>";
                Literal1.Text += "<div class='panel-body'>";
                Literal1.Text += "<img src='" + dr[3] + "' class='img-responsive' style='width:100%' alt='Image'>";
                Literal1.Text += "</div>";
                Literal1.Text += "<div class='panel-footer'>&#8377;" + dr[2] + "&nbsp;";
                Literal1.Text += "<a href='ProductDetails.aspx?pid=" + dr[0] + "' class='pull-right btn btn-primary' style='margin-top: -7px;'>Buy Now</a></div>";
                Literal1.Text += "</div>";
                Literal1.Text += "</div>";
            }

            dr.Close();
            con.Open();
            cmd = new SqlCommand("select count(*) from Cart where CartID='" + Session.SessionID + "';", con);
            object items = cmd.ExecuteScalar();
            number.Text = items.ToString();
            

            

            cmd.Dispose();

            DatabaseConnection.CloseConnection(con);
            Literal1.Text += "</div>";
        }
    }
}