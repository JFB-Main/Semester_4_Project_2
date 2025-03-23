using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassCompanyStocks
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Method untuk mengambil semua produk atau mencari berdasarkan nama produk dan supplier
        public DataTable GetProducts(string productName, string supplierName)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT p.stock_name AS ProductName, p.description, s.name AS SupplierName " +
                               "FROM stocks p " +
                               "LEFT JOIN suppliers s ON p.supplier_id = s.id " +
                               "WHERE (@productName = '' OR p.stock_name LIKE @productName) " +
                               "AND (@supplierName = '' OR s.name LIKE @supplierName)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", "%" + productName + "%");
                    cmd.Parameters.AddWithValue("@supplierName", "%" + supplierName + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

    }
}