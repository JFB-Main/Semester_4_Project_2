using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Semester_4_Project_2.Class
{
	public class ClassContactHis
	{


        private static string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public bool UpdateMailStatus(string email, string newStatus, string username, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Ambil status dan message lama sebelum diperbarui
                    string oldStatus = "";
                    string oldMessage = "";
                    string selectQuery = "SELECT status, message FROM contacts WHERE email = @email";

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@email", email);
                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oldStatus = reader["status"].ToString();
                                oldMessage = reader["message"].ToString();
                            }
                            else
                            {
                                errorMessage = "Email tidak ditemukan.";
                                return false;
                            }
                        }
                    }

                    // Perbarui status di tabel contacts
                    string updateQuery = "UPDATE contacts SET status = @newStatus, updated_at = NOW() WHERE email = @email";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@newStatus", newStatus);
                        updateCmd.Parameters.AddWithValue("@email", email);
                        updateCmd.ExecuteNonQuery();
                    }

                    // Simpan riwayat perubahan status beserta pesan ke history_contacts
                    string insertHistoryQuery = @"
                    INSERT INTO history_contacts (email, old_status, new_status, username, message, changed_at) 
                    VALUES (@email, @oldStatus, @newStatus, @updatedBy, @message, NOW())";

                    using (MySqlCommand insertCmd = new MySqlCommand(insertHistoryQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@email", email);
                        insertCmd.Parameters.AddWithValue("@oldStatus", oldStatus);
                        insertCmd.Parameters.AddWithValue("@newStatus", newStatus);
                        insertCmd.Parameters.AddWithValue("@updatedBy", username); // Menyimpan username
                        insertCmd.Parameters.AddWithValue("@message", oldMessage); // Menyimpan pesan lama
                        insertCmd.ExecuteNonQuery();
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


        public DataTable GetContacts(string email, string status)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT name, email, status, message, created_at, updated_at FROM contacts WHERE 1=1";

                    if (!string.IsNullOrEmpty(email))
                    {
                        query += " AND email LIKE @email";
                    }
                    if (!string.IsNullOrEmpty(status))
                    {
                        query += " AND status = @status";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(email))
                        {
                            cmd.Parameters.AddWithValue("@email", "%" + email + "%");
                        }
                        if (!string.IsNullOrEmpty(status))
                        {
                            cmd.Parameters.AddWithValue("@status", status);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }




        public class HistoryContact
        {
            public string Email { get; set; }
            public string OldStatus { get; set; }
            public string NewStatus { get; set; }
            public string Username { get; set; }
            public string Message { get; set; }
            public DateTime ChangedAt { get; set; }
        }

        public List<HistoryContact> SearchHistory(string senderEmail, string adminName, string mailStatus)
        {
            List<HistoryContact> historyList = new List<HistoryContact>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT email, old_status, new_status, username, message, changed_at FROM history_contacts WHERE 1=1";

                    if (!string.IsNullOrEmpty(senderEmail))
                        query += " AND email LIKE @senderEmail";

                    if (!string.IsNullOrEmpty(adminName))
                        query += " AND username LIKE @adminName";

                    if (!string.IsNullOrEmpty(mailStatus))
                        query += " AND new_status = @mailStatus";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(senderEmail))
                            cmd.Parameters.AddWithValue("@senderEmail", "%" + senderEmail + "%");

                        if (!string.IsNullOrEmpty(adminName))
                            cmd.Parameters.AddWithValue("@adminName", "%" + adminName + "%");

                        if (!string.IsNullOrEmpty(mailStatus))
                            cmd.Parameters.AddWithValue("@mailStatus", mailStatus);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                historyList.Add(new HistoryContact
                                {
                                    Email = reader["email"].ToString(),
                                    OldStatus = reader["old_status"].ToString(),
                                    NewStatus = reader["new_status"].ToString(),
                                    Username = reader["username"].ToString(),
                                    Message = reader["message"].ToString(),
                                    ChangedAt = Convert.ToDateTime(reader["changed_at"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return historyList;
        }

        public List<HistoryContact> GetAllHistory()
        {
            List<HistoryContact> historyList = new List<HistoryContact>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT email, old_status, new_status, username, message, changed_at FROM history_contacts ORDER BY changed_at DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                historyList.Add(new HistoryContact
                                {
                                    Email = reader["email"].ToString(),
                                    OldStatus = reader["old_status"].ToString(),
                                    NewStatus = reader["new_status"].ToString(),
                                    Username = reader["username"].ToString(),
                                    Message = reader["message"].ToString(),
                                    ChangedAt = Convert.ToDateTime(reader["changed_at"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return historyList;
        }



        



    }
}