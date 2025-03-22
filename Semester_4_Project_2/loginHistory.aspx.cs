using System;
using System.Collections.Generic;
using System.Data;
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
            //dropdownList();
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }

            if (!IsPostBack)
            {
                LoadLoginLogs();
            }
        }


        //public void dropdownList()
        //{
        //    ddlCat.Items.Add("I am a value and a text");
        //    ddlCat.Items.Add("adwfeafeaef");
        //    ddlCat.Items.Add("test");
        //}

        protected void btnSearch(object sender, EventArgs e)
        {
            string username = adminUsernameForm.Text.Trim();
            string status = ddlStat.SelectedValue;

            ClassLoginHis adminControl = new ClassLoginHis();
            DataTable dt = adminControl.SearchLoginLogs(username, status);

            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                // Kosongkan Repeater jika tidak ada data
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                Response.Write("<script>alert('No results found');</script>");
            }
        }

        private void LoadLoginLogs()
        {
            ClassLoginHis loginHistory = new ClassLoginHis();
            DataTable dt = loginHistory.GetLoginHistory();

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }


    }
}