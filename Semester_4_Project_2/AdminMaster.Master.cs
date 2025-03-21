using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semester_4_Project_2.Class;


namespace Semester_4_Project_2
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateNavBar();
                
            }

            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }

        }


        private void UpdateNavBar()
        {
            

            if (ClassSession.IsLoggedIn())
            {
                loginNav.Visible = false;
                logoutNav.Visible = true;
                usernameNav.InnerText = "Hello, " + ClassSession.Username;
            }
            else
            {
                loginNav.Visible = true;
                logoutNav.Visible = false;
                usernameNav.InnerText = "";
                supplierControlNav.Visible = false;
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            ClassSession.Logout();
            Response.Redirect("home_supplier.aspx");
        }


    }
}