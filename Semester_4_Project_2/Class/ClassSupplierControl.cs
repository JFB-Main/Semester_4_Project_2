using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassSupplierControl
	{
        public static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        public string SaveUploadedFile(HttpPostedFile uploadedFile)
        {
            if (uploadedFile != null && uploadedFile.ContentLength > 0)
            {
                string fileExtension = Path.GetExtension(uploadedFile.FileName);
                string newFileName = $"{Guid.NewGuid()}{fileExtension}"; // Nama unik dengan GUID
                string savePath = HttpContext.Current.Server.MapPath("/images/" + newFileName);

                uploadedFile.SaveAs(savePath); // Simpan file ke folder

                return "/images/" + newFileName; // Kembalikan path yang akan disimpan di database
            }
            return ""; // Jika tidak ada file yang diupload, return string kosong
        }


        // Method untuk menambahkan supplier
        public string InsertSupplier(string name, string description, string address, HttpPostedFile uploadedFile, string username)
        {
            string imagePath = SaveUploadedFile(uploadedFile); // Panggil method penyimpanan file

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (conn == null) return "Gagal terhubung ke database.";

                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    // Insert ke suppliers_web
                    string query = "INSERT INTO suppliers_web (name, description, address, image_path) VALUES (@name, @description, @address, @imagePath)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                    cmd.ExecuteNonQuery();

                    // Insert ke history_suppliers_web
                    string historyQuery = "INSERT INTO history_suppliers_web (name, description, address, image_path, username, action_type) " +
                                          "VALUES (@name, @description, @address, @imagePath, @username, 'INSERT')";
                    MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn);
                    historyCmd.Parameters.AddWithValue("@name", name);
                    historyCmd.Parameters.AddWithValue("@description", description);
                    historyCmd.Parameters.AddWithValue("@address", address);
                    historyCmd.Parameters.AddWithValue("@imagePath", imagePath);
                    historyCmd.Parameters.AddWithValue("@username", username);
                    historyCmd.ExecuteNonQuery();

                    return "success";
                }
                catch (MySqlException ex)
                {
                    return "Database Error: " + ex.Message;
                }
            }
        }

        public string DeleteSupplierByName(string name, string username)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                if (conn == null) return "Gagal terhubung ke database.";

                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Ambil informasi supplier sebelum dihapus
                            string selectQuery = "SELECT description, address, image_path FROM suppliers_web WHERE name = @name LIMIT 1";
                            MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn, transaction);
                            selectCmd.Parameters.AddWithValue("@name", name);

                            string description = "", address = "", imagePath = "";

                            using (MySqlDataReader reader = selectCmd.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    return "Supplier tidak ditemukan.";
                                }

                                description = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                address = reader.GetString(1);
                                imagePath = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            }

                            // Simpan history DELETE sebelum supplier dihapus
                            string historyQuery = "INSERT INTO history_suppliers_web (name, description, address, image_path, username, action_type) " +
                                                  "VALUES (@name, @description, @address, @imagePath, @username, 'DELETE')";
                            MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn, transaction);
                            historyCmd.Parameters.AddWithValue("@name", name);
                            historyCmd.Parameters.AddWithValue("@description", description);
                            historyCmd.Parameters.AddWithValue("@address", address);
                            historyCmd.Parameters.AddWithValue("@imagePath", imagePath);
                            historyCmd.Parameters.AddWithValue("@username", username);
                            historyCmd.ExecuteNonQuery();

                            // Hapus supplier setelah history DELETE tersimpan
                            string deleteQuery = "DELETE FROM suppliers_web WHERE name = @name";
                            MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn, transaction);
                            deleteCmd.Parameters.AddWithValue("@name", name);
                            int rowsAffected = deleteCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit(); // Simpan semua perubahan jika sukses

                                // Hapus file gambar dari folder jika ada
                                if (!string.IsNullOrEmpty(imagePath))
                                {
                                    string fullPath = HttpContext.Current.Server.MapPath(imagePath);
                                    if (File.Exists(fullPath))
                                    {
                                        File.Delete(fullPath);
                                    }
                                }

                                return "success";
                            }
                            else
                            {
                                transaction.Rollback(); // Batalkan jika gagal hapus supplier
                                return "Gagal menghapus supplier.";
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Batalkan transaksi jika ada error
                            return "Database Error: " + ex.Message;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    return "Database Error: " + ex.Message;
                }
            }
        }


        public bool UpdateSupplier(int supplierId, string name, string description, string address, string newImagePath, string username)
        {
            bool success = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Cek apakah supplier dengan ID tersebut ada
                    string oldImagePath = null;
                    string checkQuery = "SELECT image_path FROM suppliers_web WHERE id = @id";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", supplierId);
                        using (MySqlDataReader reader = checkCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldImagePath = reader["image_path"].ToString();
                            }
                            else
                            {
                                throw new Exception("Supplier tidak ditemukan.");
                            }
                        }
                    }

                    // Hapus gambar lama jika ada
                    if (!string.IsNullOrEmpty(oldImagePath))
                    {
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, oldImagePath);
                        if (File.Exists(fullPath))
                        {
                            File.Delete(fullPath);
                        }
                    }

                    // Update data supplier
                    string updateQuery = "UPDATE suppliers_web SET name = @name, description = @description, address = @address, image_path = @imagePath WHERE id = @id";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@id", supplierId);
                        updateCmd.Parameters.AddWithValue("@name", name);
                        updateCmd.Parameters.AddWithValue("@description", description);
                        updateCmd.Parameters.AddWithValue("@address", address);
                        updateCmd.Parameters.AddWithValue("@imagePath", newImagePath);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Insert ke history_suppliers_web
                    string historyQuery = "INSERT INTO history_suppliers_web (name, description, address, image_path, username, action_type) " +
                                          "VALUES (@name, @description, @address, @imagePath, @username, 'UPDATE')";
                    using (MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn))
                    {
                        historyCmd.Parameters.AddWithValue("@name", name);
                        historyCmd.Parameters.AddWithValue("@description", description);
                        historyCmd.Parameters.AddWithValue("@address", address);
                        historyCmd.Parameters.AddWithValue("@imagePath", newImagePath);
                        historyCmd.Parameters.AddWithValue("@username", username);
                        historyCmd.ExecuteNonQuery();
                    }

                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return success;
        }



        public class Supplier
        {
            public string SupplierName { get; set; }
            public string Description { get; set; }
            public string Address { get; set; }
            public string image_path { get; set; }
        }

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT name AS supplier_name, description, address, image_path FROM suppliers_web";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier
                            {
                                SupplierName = reader["supplier_name"].ToString(),
                                Description = reader["description"].ToString(),
                                Address = reader["address"].ToString(),
                                image_path = reader["image_path"].ToString()
                            });
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Database Error: " + ex.Message);
                }
            }
            return suppliers;
        }


        public Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = null;

            string query = "SELECT name, description, address, image_path FROM suppliers_web WHERE id = @supplierId";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@supplierId", supplierId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            supplier = new Supplier
                            {
                                SupplierName = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                Address = reader["address"].ToString(),
                                image_path = reader["image_path"].ToString()
                            };
                        }
                    }
                }
            }
            return supplier;
        }


    }
}