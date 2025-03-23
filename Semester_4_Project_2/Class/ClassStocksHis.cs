using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassStocksHis
	{

        private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public DataTable SearchStockHistory(string adminUsername, string stockName, string categoryId, string supplierId, string actionType)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT h.id, h.stock_name, h.stock_price, h.stock_amount, 
                                    h.description, h.username, h.supplier_name, 
                                    h.action_type, h.action_time, c.name AS category_name
                             FROM history_stocks h
                             LEFT JOIN categories c ON h.category_id = c.id
                             WHERE (@adminUsername = '' OR h.username LIKE CONCAT('%', @adminUsername, '%'))
                             AND (@stockName = '' OR h.stock_name LIKE CONCAT('%', @stockName, '%'))
                             AND (@categoryId = '' OR h.category_id = @categoryId)
                             AND (@supplierId = '' OR h.supplier_id = @supplierId)
                             AND (@actionType = '' OR h.action_type = @actionType)
                             ORDER BY h.action_time DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@adminUsername", adminUsername);
                    cmd.Parameters.AddWithValue("@stockName", stockName);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@supplierId", supplierId);
                    cmd.Parameters.AddWithValue("@actionType", actionType);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, name FROM categories ORDER BY name ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetSuppliers()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, name FROM suppliers ORDER BY name ASC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}