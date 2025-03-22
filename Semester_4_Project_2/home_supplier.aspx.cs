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
    public partial class home_supplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCompanyProfile();
            }
        }


        private void LoadCompanyProfile()
        {
            ClassCompanyProfile companyProfile = new ClassCompanyProfile();
            DataTable dt = companyProfile.GetCompanyProfile();

            if (dt.Rows.Count > 0)
            {
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
    }
}