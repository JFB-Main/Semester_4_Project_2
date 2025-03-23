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
    public partial class stocksControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }

            if (!IsPostBack)
            {
                LoadSuppliers();  // Load dropdown supplier
                LoadCategories(); // Load dropdown category
                LoadAllStocks();  // Load semua data saat pertama kali halaman dibuka

            }
        }

        //public void dropdownList()
        //{
        //    ddlCat.Items.Add("I am a value and a text");
        //    ddlCat.Items.Add("adwfeafeaef");
        //    ddlCat.Items.Add("test");
        //}

        //public void btnSearch(object sender, EventArgs e)
        //{
        //    ddlCat.Items.Clear();
        //    ddlCat.Items.Add("I am a value and a text");
        //    ddlCat.Items.Add("adwfeafeaef");
        //    ddlCat.Items.Add("test");
        //}


        private ClassStocksControl stockControl = new ClassStocksControl();

        private void LoadSuppliers()
        {
            DataTable dt = stockControl.GetSuppliers();
            ddlsup.DataSource = dt;
            ddlsup.DataTextField = "name";
            ddlsup.DataValueField = "id";
            ddlsup.DataBind();
            ddlsup.Items.Insert(0, new ListItem("-- Select Supplier --", ""));
        }

        private void LoadCategories()
        {
            DataTable dt = stockControl.GetCategories();
            ddlCat.DataSource = dt;
            ddlCat.DataTextField = "name";
            ddlCat.DataValueField = "id";
            ddlCat.DataBind();
            ddlCat.Items.Insert(0, new ListItem("-- Select Category --", ""));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string supplierId = ddlsup.SelectedValue;
            string categoryId = ddlCat.SelectedValue;
            string stockName = stockNameForm.Text.Trim();

            DataTable dt = stockControl.SearchStocks(supplierId, categoryId, stockName);

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        private void LoadAllStocks()
        {
            DataTable dt = stockControl.SearchStocks("", "", ""); // Parameter kosong untuk menampilkan semua data
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }


    }
}