using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient; 
using System.Configuration;
using System.Data;
using Semester_4_Project_2.Class;

namespace Semester_4_Project_2
{
    public partial class home_product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    LoadProducts("", ""); // Menampilkan semua data saat pertama kali dibuka
                }
            }
        }

        ClassCompanyStocks companyProduct = new ClassCompanyStocks();

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = productNameForm.Text.Trim();
            string supplierName = supplierForm.Text.Trim();
            LoadProducts(productName, supplierName);
        }

        private void LoadProducts(string productName, string supplierName)
        {
            DataTable dt = companyProduct.GetProducts(productName, supplierName);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

    }
}