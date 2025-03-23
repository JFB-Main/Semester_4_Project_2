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
    public partial class stocksHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }

            if (!IsPostBack)
            {
                LoadCategories();
                LoadSuppliers();
                LoadStockHistory(); // Load semua history saat pertama kali halaman dibuka
                LoadActionTypes();
            }
        }

        ClassStocksHis stockHistory = new ClassStocksHis();


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string adminUsername = AdminUsernameForm.Text.Trim();
            string stockName = stockForm.Text.Trim();
            string categoryId = ddlCat.SelectedValue;
            string supplierId = DropDownList1.SelectedValue;
            string actionType = ddlActionType.SelectedValue;

            DataTable dt = stockHistory.SearchStockHistory(adminUsername, stockName, categoryId, supplierId, actionType);

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        private void LoadCategories()
        {
            DataTable dt = stockHistory.GetCategories();
            ddlCat.DataSource = dt;
            ddlCat.DataTextField = "name";
            ddlCat.DataValueField = "id";
            ddlCat.DataBind();
            ddlCat.Items.Insert(0, new ListItem("-- Select Category --", ""));
        }

        private void LoadSuppliers()
        {
            DataTable dt = stockHistory.GetSuppliers();
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-- Select Supplier --", ""));
        }

        private void LoadActionTypes()
        {
            ddlActionType.Items.Clear();
            ddlActionType.Items.Add(new ListItem("-- Select Action Type --", ""));
            ddlActionType.Items.Add(new ListItem("INSERT", "INSERT"));
            ddlActionType.Items.Add(new ListItem("DELETE", "DELETE"));
            ddlActionType.Items.Add(new ListItem("UPDATE", "UPDATE"));
            ddlActionType.Items.Add(new ListItem("IN", "IN"));
            ddlActionType.Items.Add(new ListItem("OUT", "OUT"));
        }

        private void LoadStockHistory()
        {
            DataTable dt = stockHistory.SearchStockHistory("", "", "", "", "");
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }


    }
}