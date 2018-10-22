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
    public partial class WebForm1 : System.Web.UI.Page
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
            String email = Request.Form["email"];
            String password = Request.Form["password"];
            System.Diagnostics.Debug.WriteLine("email"+email);
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "select * from [user] where [name]='"+email+"' and [password]='"+password+"' ;";
            //cmd.CommandText = "select * from [user] where [name]='raghuvararora' and [password]='qwert123' ;";
            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();
            object result = cmd.ExecuteScalar();
            if (result!= null)
            {
                Response.Redirect("Cart.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "successalert();", true);
            }
          
            System.Diagnostics.Debug.WriteLine("reurlt"+result);
          
        }
    }
}