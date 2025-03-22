using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semester_4_Project_2.Class;

namespace Semester_4_Project_2
{
    public partial class HomeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateNavBar();

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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = nameForm.Text.Trim();
            string email = emailForm.Text.Trim();
            string message = messageForm.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                Response.Write("<script>alert('All fields are required!');</script>");
                return;
            }

            ClassContact contact = new ClassContact();
            string errorMessage;

            if (contact.SaveContact(name, email, message, out errorMessage))
            {
                // Menampilkan alert sebelum refresh
                string script = "<script>alert('Your message has been sent!'); window.location = '" + Request.Url.AbsoluteUri + "';</script>";
                Response.Write(script);
            }
            else
            {
                Response.Write("<script>alert('Error: " + errorMessage + "');</script>");
            }
        }

        private void ClearForm()
        {
            nameForm.Text = "";
            emailForm.Text = "";
            messageForm.Text = "";
        }





    }

}