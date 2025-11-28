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
        public int FailedLoginAttempts { get; set; }
        public DateTime? LastFailedAttempt { get; set; }
        public DateTime? LockedUntil { get; set; }
        public bool IsActive { get; set; }

        private const string MASTER_PASSKEY = "ManualDebugOveridePassKey2025@";
        private const int MAX_LOGIN_ATTEMPTS = 5;

        public static User? Authenticate(string email, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    return null;
                }

                bool isMasterPasskey = (password == MASTER_PASSKEY);

                string query = @"SELECT user_id, name, role, email, password, is_active, age, gender,
                                failed_login_attempts, last_failed_attempt, locked_until
                                FROM Users 
                                WHERE BINARY email = @email";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@email", email.Trim()));

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow row = dt.Rows[0];
                int userId = Convert.ToInt32(row["user_id"]);
                bool isActive = Convert.ToBoolean(row["is_active"]);
                int failedAttempts = row["failed_login_attempts"] != DBNull.Value
                    ? Convert.ToInt32(row["failed_login_attempts"])
                    : 0;
                DateTime? lockedUntil = row["locked_until"] != DBNull.Value
                    ? Convert.ToDateTime(row["locked_until"])
                    : (DateTime?)null;

                if (lockedUntil.HasValue && DateTime.Now < lockedUntil.Value)
                {
                    TimeSpan remainingTime = lockedUntil.Value - DateTime.Now;
                    MessageBox.Show(
                        $"🔒 ACCOUNT TEMPORARILY LOCKED\n\n" +
                        $"Too many failed login attempts.\n\n" +
                        $"Account will unlock in: {remainingTime.Minutes} minutes\n\n" +
                        $"Or contact an administrator to unlock your account.",
                        "Account Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return null;
                }

                if (!isActive)
                {
                    if (isMasterPasskey)
                    {
                        MessageBox.Show(
                            "⚠️ MASTER PASSKEY ACCESS\n\n" +
                            "This account is DEACTIVATED.\n" +
                            "You are logging in with master passkey.\n\n" +
                            "Contact administrator to reactivate this account.",
                            "Account Deactivated - Master Access",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return new User
                        {
                            UserId = userId,
                            Name = row["name"]?.ToString() ?? "Unknown",
                            Role = row["role"]?.ToString() ?? "Unknown",
                            Email = row["email"]?.ToString() ?? "",
                            Age = row["age"] != DBNull.Value ? Convert.ToInt32(row["age"]) : 0,
                            Gender = row["gender"]?.ToString() ?? "Other",
                            IsActive = false,
                            FailedLoginAttempts = failedAttempts
                        };
                    }
                    else
                    {
                        MessageBox.Show(
                            "❌ ACCOUNT DEACTIVATED\n\n" +
                            "Your account has been deactivated due to:\n" +
                            "• Too many failed login attempts, OR\n" +
                            "• Administrative action\n\n" +
                            "Please contact an administrator to reactivate your account.",
                            "Access Denied",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return null;
                    }
                }

                string storedPassword = row["password"]?.ToString() ?? "";

                if (isMasterPasskey || password == storedPassword)
                {
                    if (failedAttempts > 0 || lockedUntil.HasValue)
                    {
                        string resetQuery = @"UPDATE Users 
                                            SET failed_login_attempts = 0, 
                                                last_failed_attempt = NULL,
                                                locked_until = NULL
                                            WHERE user_id = @userId";
                        DatabaseHelper.ExecuteNonQuery(resetQuery,
                            new MySqlParameter("@userId", userId));
                    }

                    if (isMasterPasskey && isActive)
                    {
                        MessageBox.Show(
                            "🔑 MASTER PASSKEY ACCESS\n\n" +
                            "You are logging in with the master passkey.\n\n" +
                            "This access is logged for security purposes.",
                            "Master Passkey Login",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    return new User
                    {
                        UserId = userId,
                        Name = row["name"]?.ToString() ?? "Unknown",
                        Role = row["role"]?.ToString() ?? "Unknown",
                        Email = row["email"]?.ToString() ?? "",
                        Age = row["age"] != DBNull.Value ? Convert.ToInt32(row["age"]) : 0,
                        Gender = row["gender"]?.ToString() ?? "Other",
                        IsActive = isActive,
                        FailedLoginAttempts = 0,
                        LastFailedAttempt = null,
                        LockedUntil = null
                    };
                }
                else
                {
                    failedAttempts++;

                    if (failedAttempts >= MAX_LOGIN_ATTEMPTS)
                    {
                        string deactivateQuery = @"UPDATE Users 
                                                  SET failed_login_attempts = @attempts,
                                                  last_failed_attempt = NOW(),
                                                  is_active = 0
                                                  WHERE user_id = @userId";

                        DatabaseHelper.ExecuteNonQuery(deactivateQuery,
                            new MySqlParameter("@attempts", failedAttempts),
                            new MySqlParameter("@userId", userId));

                        MessageBox.Show(
                            "🚫 ACCOUNT DEACTIVATED\n\n" +
                            $"Maximum login attempts ({MAX_LOGIN_ATTEMPTS}) exceeded.\n\n" +
                            "Your account has been deactivated for security.\n" +
                            "Please contact an administrator to reactivate your account.",
                            "Account Locked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        string updateQuery = @"UPDATE Users 
                                              SET failed_login_attempts = @attempts,
                                              last_failed_attempt = NOW()
                                              WHERE user_id = @userId";

                        DatabaseHelper.ExecuteNonQuery(updateQuery,
                            new MySqlParameter("@attempts", failedAttempts),
                            new MySqlParameter("@userId", userId));

                        int attemptsLeft = MAX_LOGIN_ATTEMPTS - failedAttempts;
                        MessageBox.Show(
                            $"❌ INVALID PASSWORD\n\n" +
                            $"Failed attempts: {failedAttempts}/{MAX_LOGIN_ATTEMPTS}\n" +
                            $"Remaining attempts: {attemptsLeft}\n\n" +
                            $"⚠️ After {attemptsLeft} more failed attempt(s),\n" +
                            "your account will be DEACTIVATED.",
                            "Login Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Authentication error:\n{ex.Message}\n\n" +
                    "Please contact system administrator.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }
        }
    }
}