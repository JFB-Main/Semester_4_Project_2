using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Semester_4_Project_2.Class;
using static Semester_4_Project_2.Class.ClassSupplierControl;

namespace Semester_4_Project_2
{
    public partial class supplierControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ClassSession.IsLoggedIn())
            {
                Response.Redirect("home_supplier.aspx"); // Redirect jika belum login
            }
            if (!IsPostBack)
            {
                LoadSuppliers();
                LoadSupplierData();
            }

        }

        protected void btnAdd(object sender, EventArgs e)
        {
            string supplierName = supplierNameForm.Text.Trim();
            string supplierDesc = supplierDescForm.Text.Trim();
            string supplierAddress = supplierAddressForm.Text.Trim();
            string username = ClassSession.Username; // Ambil username dari session

            if (string.IsNullOrEmpty(username))
            {
                lblMessage.Text = "Session expired. Please login again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(supplierName) || string.IsNullOrEmpty(supplierDesc) || string.IsNullOrEmpty(supplierAddress))
            {
                lblMessage.Text = "All fields are required!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            HttpPostedFile uploadedFile = uploadFile.PostedFile;

            ClassSupplierControl supplierControl = new ClassSupplierControl();
            string result = supplierControl.InsertSupplier(supplierName, supplierDesc, supplierAddress, uploadedFile, username);

            if (result == "success")
            {
                lblMessage.Text = "Supplier added successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearForm();

                // 🔹 Redirect untuk mencegah form resubmission
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }




        protected void btnUpdate(object sender, EventArgs e)
        {
            if (ddlSupplier.SelectedValue == "")
            {
                lblMessage.Text = "Pilih supplier yang ingin diperbarui.";
                return;
            }

            int supplierId = Convert.ToInt32(ddlSupplier.SelectedValue);
            string name = supplierNameForm.Text.Trim();
            string description = supplierDescForm.Text.Trim();
            string address = supplierAddressForm.Text.Trim();
            string username = ClassSession.Username; // Ambil username dari session

            // Ambil data lama dari database
            ClassSupplierControl supplierControl = new ClassSupplierControl();
            Supplier oldSupplier = supplierControl.GetSupplierById(supplierId);

            if (oldSupplier == null)
            {
                lblMessage.Text = "Supplier tidak ditemukan.";
                return;
            }

            // Jika ada file baru yang diunggah, gunakan file baru
            string newImagePath = oldSupplier.image_path; // Gunakan image_path lama sebagai default

            if (uploadFile.HasFile)
            {
                // Hapus gambar lama jika ada
                if (!string.IsNullOrEmpty(oldSupplier.image_path))
                {
                    string oldFilePath = Server.MapPath(oldSupplier.image_path);
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                // Simpan gambar baru
                string fileExtension = Path.GetExtension(uploadFile.FileName);
                string newFileName = "supplier_" + supplierId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                string savePath = "/images/" + newFileName;
                uploadFile.SaveAs(Server.MapPath(savePath));

                newImagePath = savePath; // Perbarui image_path dengan yang baru
            }

            // Gunakan nilai lama jika input kosong
            if (string.IsNullOrEmpty(name)) name = oldSupplier.SupplierName;
            if (string.IsNullOrEmpty(description)) description = oldSupplier.Description;
            if (string.IsNullOrEmpty(address)) address = oldSupplier.Address;

            // Update database
            bool updated = supplierControl.UpdateSupplier(supplierId, name, description, address, newImagePath, username);

            if (updated)
            {
                lblMessage.Text = "Supplier berhasil diperbarui!";
                LoadSupplierData(); // Refresh data di halaman
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                lblMessage.Text = "Terjadi kesalahan saat memperbarui supplier.";
            }
        }









        // Method untuk clear input setelah update


        public void btnDelete(object sender, EventArgs e)
        {
            string supplierName = supplierNameForm.Text.Trim();
            string username = ClassSession.Username; // Mengambil username dari session

            if (string.IsNullOrEmpty(supplierName))
            {
                lblMessage.Text = "Supplier Name harus diisi!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            ClassSupplierControl supplierControl = new ClassSupplierControl();
            string result = supplierControl.DeleteSupplierByName(supplierName, username);

            if (result == "success")
            {
                lblMessage.Text = "Supplier berhasil dihapus.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                ClearForm(); // Bersihkan input setelah berhasil
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                lblMessage.Text = result;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void ClearForm()
        {
            supplierNameForm.Text = "";
            supplierDescForm.Text = "";
            supplierAddressForm.Text = "";
            uploadFile.Attributes.Clear(); // Reset upload file
        }


        private void LoadSupplierData()
        {
            ClassSupplierControl supplierControl = new ClassSupplierControl();
            List<Supplier> suppliers = supplierControl.GetAllSuppliers();

            if (suppliers.Count > 0)
            {
                Repeater1.DataSource = suppliers;
                Repeater1.DataBind();
            }
        }


        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        private void LoadSuppliers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, name FROM suppliers_web";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Response.Write("<script>console.log('Data ditemukan dalam database:');</script>");

                        ddlSupplier.Items.Clear(); // Pastikan tidak ada item duplikat
                        while (reader.Read())
                        {
                            string id = reader["id"].ToString();
                            string name = reader["name"].ToString();

                            Response.Write($"<script>console.log('ID: {id}, Name: {name}');</script>");

                            ddlSupplier.Items.Add(new ListItem(name, id));
                        }
                    }
                    else
                    {
                        Response.Write("<script>console.log('Tidak ada data dalam tabel suppliers_web');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>console.log('Error: {ex.Message}');</script>");
                }
            }

            // Tambahkan item default di dropdown
            
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            int supplierId = Convert.ToInt32(ddlSupplier.SelectedValue);

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT image_path FROM suppliers_web WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", supplierId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            HiddenFieldImagePath.Value = reader["image_path"].ToString();
                        }
                    }
                }
            }
        }
    }
}