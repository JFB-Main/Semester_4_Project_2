using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Semester_4_Project_2
{
    public partial class userMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dropdownList();
        }

        public void dropdownList()
        {
            ddlStatus.Items.Add("I am a value and a text");
            ddlStatus.Items.Add("adwfeafeaef");
            ddlStatus.Items.Add("test");
        }
        public void btnSearch(object sender, EventArgs e)
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add("I am a value and a text");
            ddlStatus.Items.Add("adwfeafeaef");
            ddlStatus.Items.Add("test");
        }

        public void btnUpdate(object sender, EventArgs e)
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add("I am a value and a text");
            ddlStatus.Items.Add("adwfeafeaef");
            ddlStatus.Items.Add("test");
        }
    }
}