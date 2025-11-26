using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;

        public static User? Authenticate(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    return null;
                }
                string query = @"SELECT user_id, name, role, email, password, age, gender 
                               FROM Users 
                               WHERE BINARY email = @email AND is_active = 1";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@email", email.Trim()));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string storedPassword = row["password"]?.ToString() ?? "";

                    if (storedPassword == password)
                    {
                        return new User
                        {
                            UserId = Convert.ToInt32(row["user_id"]),
                            Name = row["name"]?.ToString() ?? "Unknown",
                            Role = row["role"]?.ToString() ?? "Unknown",
                            Email = row["email"]?.ToString() ?? "",
                            Age = row["age"] != DBNull.Value ? Convert.ToInt32(row["age"]) : 0,
                            Gender = row["gender"]?.ToString() ?? "Other"
                        };
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication error:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}