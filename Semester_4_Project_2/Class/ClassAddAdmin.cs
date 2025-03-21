using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using BCrypt.Net;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassAddAdmin
	{

        //private string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;


        // Menambahkan admin baru
        public bool AddAdmin(string username, string password, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                string query = "INSERT INTO users (username, password_hash, role) VALUES (@username, @password, 'adminweb')";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        // Update password admin berdasarkan ID
        public bool UpdatePasswordByUsername(string username, string newPassword, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                string query = "UPDATE users SET password_hash = @password, updated_at = NOW() WHERE username = @username";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            errorMessage = "User not found or no changes made.";
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }


        // Hapus admin berdasarkan username
        public bool DeleteUserByUsername(string username, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string query = "DELETE FROM users WHERE username = @username";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }



        public static DataTable LoadUsers()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id, username, role, created_at, updated_at FROM users";

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
    }
}