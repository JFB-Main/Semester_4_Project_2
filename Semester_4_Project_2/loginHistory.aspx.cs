using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semester_4_Project_2.Class;

namespace Semester_4_Project_2
{
    public partial class loginHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dropdownList();
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }
        }


        public void dropdownList()
        {
            ddlCat.Items.Add("I am a value and a text");
            ddlCat.Items.Add("adwfeafeaef");
            ddlCat.Items.Add("test");
        }

        public void btnSearch(object sender, EventArgs e)
        {
            ddlCat.Items.Clear();
            ddlCat.Items.Add("I am a value and a text");
            ddlCat.Items.Add("adwfeafeaef");
            ddlCat.Items.Add("test");
        }

    }
}