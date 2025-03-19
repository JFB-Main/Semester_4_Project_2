using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using Semester_4_Project_2.Class;



namespace Semester_4_Project_2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClassSession.IsLoggedIn())
            {
                Response.Redirect("supplierControl.aspx"); // Redirect jika sudah login
            }
        }


        public void btnLogIn(object sender, EventArgs e)
        {
            string user = username.Text.Trim();
            string pass = password.Text.Trim();
            string role;

            if (ClassLogin.LoginUser(user, pass, out role))
            {
                // Simpan session
                ClassSession.Username = user;
                ClassSession.Role = role;

                HttpContext.Current.Session["Username"] = user; // Tambahan
                HttpContext.Current.Session["Role"] = role; // Tambahan

                Response.Redirect("home_supplier.aspx");
            }
            else
            {
                lblError.Text = "Login gagal atau admin tidak diperbolehkan!";
                lblError.Visible = true;
            }
        }
    }
}