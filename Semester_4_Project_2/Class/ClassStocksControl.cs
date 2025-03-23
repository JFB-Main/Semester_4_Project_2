using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassStocksControl
	{


        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Ambil daftar Supplier
        public DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id, name FROM suppliers";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Ambil daftar Category
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            string query = "SELECT id, name FROM categories";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

        //  Pencarian Stok berdasarkan Supplier, Kategori, dan Nama Stok
        public DataTable SearchStocks(string supplierId, string categoryId, string stockName)
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT s.stock_name, s.stock_price, c.name AS category_name, 
                   s.stock_amount, s.description 
            FROM stocks s
            LEFT JOIN categories c ON s.category_id = c.id
            WHERE 1=1";

            if (!string.IsNullOrEmpty(supplierId))
                query += " AND s.supplier_id = @SupplierId";
            if (!string.IsNullOrEmpty(categoryId))
                query += " AND s.category_id = @CategoryId";
            if (!string.IsNullOrEmpty(stockName))
                query += " AND s.stock_name LIKE @StockName";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(supplierId))
                        cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    if (!string.IsNullOrEmpty(categoryId))
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    if (!string.IsNullOrEmpty(stockName))
                        cmd.Parameters.AddWithValue("@StockName", "%" + stockName + "%");

                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}