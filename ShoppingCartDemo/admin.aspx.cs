using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingCartDemo
{
    public partial class admin : System.Web.UI.Page
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rd;
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShoppingCartDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();
            String name = Request.Form["name"];
            String image = Request.Form["image"];
            String price = Request.Form["price"];
            cmd.CommandText = "insert into [Products]( [ProductName], [Price], [ProductImage]) values ('"+name+"', "+price+", '"+image+"');";
            //cmd.CommandText = "select * from [user] where [name]='raghuvararora' and [password]='qwert123' ;";
            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("admin.aspx");
        }
    }
}