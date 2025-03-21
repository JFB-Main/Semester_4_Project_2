using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassSupplierHis
	{

        private static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Model untuk menampung data history
        public class SupplierHistory
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Address { get; set; }
            public string ImagePath { get; set; }
            public string Username { get; set; }
            public string ActionType { get; set; }
            public DateTime ActionDate { get; set; }
        }

        // ✅ 1️⃣ Method untuk menampilkan semua history supplier
        public List<SupplierHistory> GetAllHistory()
        {
            List<SupplierHistory> historyList = new List<SupplierHistory>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM history_suppliers_web ORDER BY created_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            historyList.Add(new SupplierHistory
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                Address = reader["address"].ToString(),
                                ImagePath = reader["image_path"].ToString(),
                                Username = reader["username"].ToString(),
                                ActionType = reader["action_type"].ToString(),
                                ActionDate = Convert.ToDateTime(reader["created_at"])
                            });
                        }
                    }
                }
            }
            return historyList;
        }

        // ✅ 2️⃣ Method untuk mencari berdasarkan ActionType, Name, atau Username
        public List<SupplierHistory> SearchHistory(string actionType, string name, string username)
        {
            List<SupplierHistory> historyList = new List<SupplierHistory>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM history_suppliers_web WHERE 1=1";

                // Tambahkan filter jika ada input dari user
                if (!string.IsNullOrEmpty(actionType))
                    query += " AND action_type = @actionType";
                if (!string.IsNullOrEmpty(name))
                    query += " AND name LIKE @name";
                if (!string.IsNullOrEmpty(username))
                    query += " AND username LIKE @username";

                query += " ORDER BY created_at DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(actionType))
                        cmd.Parameters.AddWithValue("@actionType", actionType);
                    if (!string.IsNullOrEmpty(name))
                        cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                    if (!string.IsNullOrEmpty(username))
                        cmd.Parameters.AddWithValue("@username", "%" + username + "%");

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            historyList.Add(new SupplierHistory
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Description = reader["description"].ToString(),
                                Address = reader["address"].ToString(),
                                ImagePath = reader["image_path"].ToString(),
                                Username = reader["username"].ToString(),
                                ActionType = reader["action_type"].ToString(),
                                ActionDate = Convert.ToDateTime(reader["created_at"])
                            });
                        }
                    }
                }
            }
            return historyList;
        }



    }
}