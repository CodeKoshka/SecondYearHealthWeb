using MySqlConnector;
using System;
using System.Data;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public static class UniqueIDHelper
    {
        private static readonly Random random = new Random();

        public static string GetRolePrefix(string role)
        {
            return role switch
            {
                "Headadmin" => "hd",
                "Admin" => "ad",
                "Receptionist" => "rt",
                "Pharmacist" => "pt",
                "Doctor" => "dr",
                _ => "us"
            };
        }

        public static string GenerateUniqueID(string role, string email = null)
        {
            if (role == "Patient")
                return null;

            string prefix = GetRolePrefix(role);
            int maxAttempts = 100;

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                int firstPart = random.Next(0, 100);
                int secondPart = random.Next(1, 611693);

                string uniqueID = $"{prefix}{firstPart:D2}{secondPart:D6}";

                if (!UniqueIDExists(uniqueID))
                    return uniqueID;
            }

            throw new Exception("Failed to generate unique ID after maximum attempts");
        }

        private static bool UniqueIDExists(string uniqueID)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Users WHERE unique_id = @uniqueID";
                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@uniqueID", uniqueID));

                return Convert.ToInt64(result) > 0;
            }
            catch
            {
                return false;
            }
        }

        public static void AssignUniqueIDToUser(int userId, string role, string email = null)
        {
            try
            {
                if (role == "Patient")
                    return;

                string uniqueID = GenerateUniqueID(role, email);

                if (uniqueID == null)
                    return;

                string query = "UPDATE Users SET unique_id = @uniqueID WHERE user_id = @userId";
                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@uniqueID", uniqueID),
                    new MySqlParameter("@userId", userId));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[UniqueIDHelper] Failed to assign unique ID: {ex.Message}");
            }
        }

        public static string GetUniqueIDForUser(int userId)
        {
            try
            {
                string query = "SELECT unique_id FROM Users WHERE user_id = @userId";
                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@userId", userId));

                return result?.ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}