using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Semester_4_Project_2.Class;

namespace Semester_4_Project_2
{
    public partial class historyMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string actionType = ddlActionType.SelectedValue;
            string name = txtMailUsername.Text.Trim();
            string username = txtAdminUsername.Text.Trim();

            //ClassSupplierHis supplierHis = new ClassSupplierHis();
            //List<ClassSupplierHis.SupplierHistory> historyList = supplierHis.SearchHistory(actionType, name, username);

            //if (historyList.Count == 0)
            //{
            //    Response.Write("<script>alert('No results found');</script>");
            //}

            //Repeater1.DataSource = historyList;
            //Repeater1.DataBind();
        }
    }
}