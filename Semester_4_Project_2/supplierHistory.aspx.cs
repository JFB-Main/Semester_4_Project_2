using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Semester_4_Project_2.Class;

namespace Semester_4_Project_2
{
    public partial class supplierHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }

            if (!IsPostBack)
            {
                LoadHistory();
            }



        }

        private void LoadHistory()
        {
            ClassSupplierHis supplierHis = new ClassSupplierHis();
            List<ClassSupplierHis.SupplierHistory> historyList = supplierHis.GetAllHistory();

            if (historyList.Count == 0)
            {
                Response.Write("<script>alert('No history data found');</script>");
            }

            Repeater1.DataSource = historyList;
            Repeater1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string actionType = ddlActionType.SelectedValue;
            string name = txtName.Text.Trim();
            string username = txtUsername.Text.Trim();

            ClassSupplierHis supplierHis = new ClassSupplierHis();
            List<ClassSupplierHis.SupplierHistory> historyList = supplierHis.SearchHistory(actionType, name, username);

            if (historyList.Count == 0)
            {
                Response.Write("<script>alert('No results found');</script>");
            }

            Repeater1.DataSource = historyList;
            Repeater1.DataBind();
        }



    }
}