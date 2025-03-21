using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Text;
using System.Data;
using System.Configuration;

namespace Semester_4_Project_2.Class
{
	public class ClassLogin
	{

        private static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public static bool LoginUser(string username, string password, out string role)
        {
            bool isAuthenticated = false;
            role = "";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT password_hash, role FROM users WHERE username = @username";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString(0);
                            role = reader.GetString(1);

                            // Verifikasi password menggunakan BCrypt
                            if (BCrypt.Net.BCrypt.Verify(password, storedHash))
                            {
                                // Jika role admin, blok login
                                if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    LogLogin(username, "blocked");
                                    return false;
                                }

                                isAuthenticated = true;
                                LogLogin(username, "success");
                            }
                            else
                            {
                                LogLogin(username, "failed");
                            }
                        }
                        else
                        {
                            LogLogin(username, "failed");
                        }
                    }
                }
            }

            return isAuthenticated;
        }

        // Fungsi untuk hashing password baru saat user dibuat
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private static void LogLogin(string username, string status)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO login_logs (username, status, login_time) VALUES (@username, @status, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}