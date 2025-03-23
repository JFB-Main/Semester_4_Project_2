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
    public partial class addAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }
            else
            {
                string userRole = ClassSession.GetUserRole(); // Ambil role pengguna dari session

                if (userRole != "superadmin") // Jika bukan superadmin, redirect
                {
                    Response.Redirect("supplierControl.aspx"); // Redirect ke halaman lain (misalnya unauthorized)
                }
            }

            if (!IsPostBack)
            {
                LoadUsers();
            }
        }


        //private void LoadUsers()
        //{
        //    if (!IsPostBack)
        //    {
        //        LoadUsers();
        //    }
        //}
        //public void dropdownList()
        //{
        //    ddlCat.Items.Add("I am a value and a text");
        //    ddlCat.Items.Add("adwfeafeaef");
        //    ddlCat.Items.Add("test");
        //}

        public void btnAdd(object sender, EventArgs e)
        {
            string username = adminUsernameForm.Text.Trim();
            string password = adminPasswordForm.Text.Trim();
            ClassAddAdmin adminControl = new ClassAddAdmin();
            string errorMessage;

            if (adminControl.AddAdmin(username, password, out errorMessage))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("Error: " + errorMessage);
            }
        }

        public void btnUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(adminUsernameForm.Text.Trim()))
            {
                Response.Write("Error: Username is required.");
                return;
            }

            string username = adminUsernameForm.Text.Trim();
            string newPassword = adminPasswordForm.Text.Trim();
            ClassAddAdmin adminControl = new ClassAddAdmin();
            string errorMessage;

            if (adminControl.UpdatePasswordByUsername(username, newPassword, out errorMessage))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("Error: " + errorMessage);
            }
        }


        public void btnDelete(object sender, EventArgs e)
        {
            string username = adminUsernameForm.Text.Trim();
            ClassAddAdmin adminControl = new ClassAddAdmin();
            string errorMessage;

            if (adminControl.DeleteUserByUsername(username, out errorMessage))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("Error: " + errorMessage);
            }
        }



        private void LoadUsers()
        {
            DataTable dt = ClassAddAdmin.LoadUsers();
            if (dt.Rows.Count > 0)
            {
                RepeaterUsers.DataSource = dt;
                RepeaterUsers.DataBind();
            }
        }


    }
}