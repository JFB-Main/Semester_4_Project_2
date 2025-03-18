using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient; 
using System.Configuration;
using System.Data;

namespace Semester_4_Project_2
{
    public partial class home_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT stock_name, description FROM stocks";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle any errors here
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

    }
}