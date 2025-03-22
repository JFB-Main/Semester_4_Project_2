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
    public partial class userMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack) // Hanya di-load pertama kali
            //{
            //    PopulateDropDownList();
            //}

            if (!IsPostBack)
            {
                LoadAllContacts();
            }
        }

        //public void dropdownList()
        //{
        //    ddlStatus.Items.Add("I am a value and a text");
        //    ddlStatus.Items.Add("adwfeafeaef");
        //    ddlStatus.Items.Add("test");
        //}
        //public void btnSearch(object sender, EventArgs e)
        //{
        //    ddlStatus.Items.Clear();
        //    ddlStatus.Items.Add("I am a value and a text");
        //    ddlStatus.Items.Add("adwfeafeaef");
        //    ddlStatus.Items.Add("test");
        //}

        public void btnSearch(object sender, EventArgs e)
        {
            string email = userEmailForm.Text.Trim();
            string status = ddlStatus.SelectedValue;

            ClassContactHis contactManager = new ClassContactHis();
            DataTable dt = contactManager.GetContacts(email, status);

            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
                // Kosongkan repeater jika tidak ada hasil
                Repeater1.DataSource = null;
                Repeater1.DataBind();
                Response.Write("<script>alert('No results found');</script>");
            }
        }



        //private void PopulateDropDownList()
        //{
        //    ddlStatus.Items.Clear(); // Bersihkan item lama sebelum mengisi ulang
        //    ddlStatus.Items.Add(new ListItem("Pending", "pending"));
        //    ddlStatus.Items.Add(new ListItem("Responded", "responded"));
        //}

        public void btnUpdate(object sender, EventArgs e)
        {
            string email = userEmailForm.Text.Trim();
            string newStatus = ddlStatus.SelectedValue;
            string username = ClassSession.Username; // Ambil username dari session

            ClassContactHis mailStatus = new ClassContactHis();
            string errorMessage;

            if (mailStatus.UpdateMailStatus(email, newStatus, username, out errorMessage))
            {
                Response.Write("<script>alert('Status berhasil diperbarui oleh " + username + "');</script>");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>alert('Error: " + errorMessage + "');</script>");
            }
        }



        private void LoadAllContacts()
        {
            ClassContactHis contactManager = new ClassContactHis();
            DataTable dt = contactManager.GetContacts("", ""); // Tanpa filter untuk menampilkan semua

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
}