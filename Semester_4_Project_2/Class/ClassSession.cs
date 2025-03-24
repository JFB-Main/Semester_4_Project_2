using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassSession
	{

        private static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public static string Username
        {
            get { return HttpContext.Current.Session["Username"] as string ?? ""; }
            set { HttpContext.Current.Session["Username"] = value; }
        }

        public static string Role
        {
            get { return HttpContext.Current.Session["Role"] as string ?? ""; }
            set { HttpContext.Current.Session["Role"] = value; }
        }

        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(Username);
        }

        public static void Logout()
        {
            string user = Username;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();

            if (!string.IsNullOrEmpty(user))
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO login_logs (username, status, login_time) VALUES (@username, 'logout', NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", user);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        //public static string GetUserRole()
        //{
        //    if (HttpContext.Current.Session["UserRole"] != null)
        //    {
        //        return HttpContext.Current.Session["UserRole"].ToString();
        //    }
        //    return string.Empty; // Jika tidak ada role, kembalikan string kosong
        //}

    }
}