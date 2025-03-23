using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semester_4_Project_2.Class;
using static Semester_4_Project_2.Class.ClassContactHis;

namespace Semester_4_Project_2
{
    public partial class historyMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }

            if (!IsPostBack)
            {
                LoadHistoryContacts();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string senderEmail = txtMailUsername.Text.Trim();
            string adminName = txtAdminUsername.Text.Trim();
            string mailStatus = ddlActionType.SelectedValue;

            ClassContactHis contactHistory = new ClassContactHis();
            List<HistoryContact> historyList = contactHistory.SearchHistory(senderEmail, adminName, mailStatus);

            if (historyList.Count == 0)
            {
                Response.Write("<script>alert('No results found');</script>");
            }

            Repeater1.DataSource = historyList;
            Repeater1.DataBind();
        }

        private void LoadHistoryContacts()
        {
            ClassContactHis contactHistory = new ClassContactHis();
            List<HistoryContact> historyList = contactHistory.GetAllHistory();

            if (historyList.Count == 0)
            {
                Response.Write("<script>alert('No history found');</script>");
            }

            Repeater1.DataSource = historyList;
            Repeater1.DataBind();
        }

    }
}