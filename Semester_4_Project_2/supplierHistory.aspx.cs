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

        //public void btnSearch(object sender, EventArgs e)
        //{
        //    ddlCat.Items.Clear();
        //    ddlCat.Items.Add("I am a value and a text");
        //    ddlCat.Items.Add("adwfeafeaef");
        //    ddlCat.Items.Add("test");
        //}

        private void LoadHistory()
        {
            ClassSupplierHis supplierHis = new ClassSupplierHis();
            List<ClassSupplierHis.SupplierHistory> historyList = supplierHis.GetAllHistory();

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

            Repeater1.DataSource = historyList;
            Repeater1.DataBind();
        }
    }
}