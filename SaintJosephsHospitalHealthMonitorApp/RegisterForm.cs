using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class RegisterForm : Form
    {
        private int? userId; // null = new user, value = edit mode
        private int? createdByUserId;
        private string creatorRole;
        private bool isEditMode;
        private string originalEmail;
        private string originalRole;

        // Constructor for editing existing user
        public RegisterForm(int userIdToEdit)
        {
            userId = userIdToEdit;
            isEditMode = true;
            InitializeComponent();
            InitializeRoleOptions();
            ConfigureForEditMode();
            LoadExistingUserData();
        }

        // Constructor for creating new user (admin/receptionist mode)
        public RegisterForm(int creatorId, string role)
        {
            userId = null;
            isEditMode = false;
            createdByUserId = creatorId;
            creatorRole = role;
            InitializeComponent();
            InitializeRoleOptions();
            ConfigureForCreateMode();
        }

        // Constructor for registration mode (no creator)
        public RegisterForm()
        {
            userId = null;
            isEditMode = false;
            createdByUserId = null;
            creatorRole = "Registration";
            InitializeComponent();
            InitializeRoleOptions();
            ConfigureForRegistrationMode();
        }

        private void InitializeRoleOptions()
        {
            cmbRole.Items.Clear();

            if (isEditMode)
            {
                // Edit mode: Show all 5 roles
                cmbRole.Items.AddRange(new string[] {
                    "Headadmin",
                    "Receptionist",
                    "Doctor",
                    "Pharmacist",
                    "Patient"
                });
            }
            else if (creatorRole == "Registration")
            {
                // Registration: Admin, Receptionist, Doctor only
                cmbRole.Items.AddRange(new string[] { "Headadmin", "Receptionist", "Doctor" });
            }
            else if (creatorRole == "Headadmin")
            {
                // Headadmin can create all roles except Headadmin
                cmbRole.Items.AddRange(new string[] { "Receptionist", "Doctor", "Pharmacist", "Patient" });
            }
            else if (creatorRole == "Receptionist")
            {
                // Receptionist can only create Patients
                cmbRole.Items.AddRange(new string[] { "Patient" });
            }

            if (cmbRole.Items.Count > 0 && !isEditMode)
                cmbRole.SelectedIndex = 0;
        }

        private void ConfigureForEditMode()
        {
            lblTitle.Text = "Edit User Information";
            this.Text = "Edit User - St. Joseph's Hospital";
            btnSubmit.Text = "Save Changes";

            // Hide password fields initially - will show change password button
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            chkShowPassword.Visible = false;

            // Add Change Password button
            Button btnChangePassword = new Button();
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Text = "Change Password";
            btnChangePassword.Location = new Point(292, 529);
            btnChangePassword.Size = new Size(233, 35);
            btnChangePassword.BackColor = Color.FromArgb(52, 152, 219);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.Click += BtnChangePassword_Click;
            this.Controls.Add(btnChangePassword);
        }

        private void ConfigureForCreateMode()
        {
            lblTitle.Text = "Create New User";
            this.Text = "Create User - St. Joseph's Hospital";
            btnSubmit.Text = "Create User";

            // Password visibility will be controlled by role selection
            if (creatorRole == "Receptionist")
            {
                // Hide password fields initially since they can only create Patients
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                chkShowPassword.Visible = false;
            }
            else
            {
                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;
                chkShowPassword.Visible = true;
            }
        }

        private void ConfigureForRegistrationMode()
        {
            lblTitle.Text = "Register New User";
            this.Text = "Register New User";
            btnSubmit.Text = "Register";

            lblPassword.Visible = true;
            txtPassword.Visible = true;
            lblConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            chkShowPassword.Visible = true;
        }

        private void LoadExistingUserData()
        {
            string query = @"SELECT name, email, age, gender, role FROM Users WHERE user_id = @userId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["name"].ToString();
                txtEmail.Text = row["email"].ToString();
                originalEmail = txtEmail.Text;
                txtAge.Text = row["age"].ToString();
                cmbGender.SelectedItem = row["gender"].ToString();
                cmbRole.SelectedItem = row["role"].ToString();
                originalRole = row["role"].ToString();

                LoadRoleSpecificData(originalRole);
            }
        }

        private void LoadRoleSpecificData(string role)
        {
            try
            {
                if (role == "Patient")
                {
                    string query = @"SELECT blood_type, allergies FROM Patients WHERE user_id = @userId";
                    DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtBloodType.Text = row["blood_type"]?.ToString() ?? "";
                        txtAllergies.Text = row["allergies"]?.ToString() ?? "";
                    }
                }
                else if (role == "Doctor")
                {
                    string query = @"SELECT specialization FROM Doctors WHERE user_id = @userId";
                    DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtSpecialization.Text = row["specialization"]?.ToString() ?? "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading role-specific data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            Form passwordForm = new Form();
            passwordForm.Text = "Change Password";
            passwordForm.Size = new Size(400, 280);
            passwordForm.StartPosition = FormStartPosition.CenterParent;
            passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordForm.MaximizeBox = false;
            passwordForm.BackColor = Color.FromArgb(240, 244, 248);

            Label lblNewPassword = new Label();
            lblNewPassword.Text = "New Password:";
            lblNewPassword.Location = new Point(20, 20);
            lblNewPassword.AutoSize = true;

            TextBox txtNewPassword = new TextBox();
            txtNewPassword.Location = new Point(20, 45);
            txtNewPassword.Size = new Size(340, 25);
            txtNewPassword.PasswordChar = '•';

            Label lblConfirmPassword = new Label();
            lblConfirmPassword.Text = "Confirm Password:";
            lblConfirmPassword.Location = new Point(20, 80);
            lblConfirmPassword.AutoSize = true;

            TextBox txtConfirmPassword = new TextBox();
            txtConfirmPassword.Location = new Point(20, 105);
            txtConfirmPassword.Size = new Size(340, 25);
            txtConfirmPassword.PasswordChar = '•';

            CheckBox chkShowPassword = new CheckBox();
            chkShowPassword.Text = "Show Password";
            chkShowPassword.Location = new Point(20, 140);
            chkShowPassword.AutoSize = true;
            chkShowPassword.CheckedChanged += (s, ev) =>
            {
                char passChar = chkShowPassword.Checked ? '\0' : '•';
                txtNewPassword.PasswordChar = passChar;
                txtConfirmPassword.PasswordChar = passChar;
            };

            Button btnSavePassword = new Button();
            btnSavePassword.Text = "Change Password";
            btnSavePassword.Location = new Point(20, 180);
            btnSavePassword.Size = new Size(160, 40);
            btnSavePassword.BackColor = Color.FromArgb(46, 204, 113);
            btnSavePassword.ForeColor = Color.White;
            btnSavePassword.FlatStyle = FlatStyle.Flat;
            btnSavePassword.FlatAppearance.BorderSize = 0;
            btnSavePassword.Cursor = Cursors.Hand;
            btnSavePassword.Click += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    MessageBox.Show("Please enter a new password.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Clear();
                    txtConfirmPassword.Focus();
                    return;
                }

                try
                {
                    string query = "UPDATE Users SET password = @password WHERE user_id = @userId";
                    DatabaseHelper.ExecuteNonQuery(query,
                        new MySqlParameter("@password", txtNewPassword.Text),
                        new MySqlParameter("@userId", userId));

                    MessageBox.Show("Password changed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    passwordForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error changing password: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Button btnCancelPassword = new Button();
            btnCancelPassword.Text = "Cancel";
            btnCancelPassword.Location = new Point(200, 180);
            btnCancelPassword.Size = new Size(160, 40);
            btnCancelPassword.BackColor = Color.FromArgb(149, 165, 166);
            btnCancelPassword.ForeColor = Color.White;
            btnCancelPassword.FlatStyle = FlatStyle.Flat;
            btnCancelPassword.FlatAppearance.BorderSize = 0;
            btnCancelPassword.Cursor = Cursors.Hand;
            btnCancelPassword.Click += (s, ev) => passwordForm.Close();

            passwordForm.Controls.AddRange(new Control[] {
                lblNewPassword, txtNewPassword, lblConfirmPassword, txtConfirmPassword,
                chkShowPassword, btnSavePassword, btnCancelPassword
            });

            passwordForm.ShowDialog();
        }

        private void CmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelPatientInfo.Visible = false;
            panelDoctorInfo.Visible = false;

            if (cmbRole.SelectedItem != null)
            {
                string selectedRole = cmbRole.SelectedItem.ToString();

                if (selectedRole == "Patient")
                {
                    panelPatientInfo.Visible = true;

                    // Hide password fields for Patient creation (not in edit mode)
                    if (!isEditMode)
                    {
                        lblPassword.Visible = false;
                        txtPassword.Visible = false;
                        lblConfirmPassword.Visible = false;
                        txtConfirmPassword.Visible = false;
                        chkShowPassword.Visible = false;
                    }
                }
                else if (selectedRole == "Doctor")
                {
                    panelDoctorInfo.Visible = true;

                    // Show password fields for Doctor creation
                    if (!isEditMode)
                    {
                        lblPassword.Visible = true;
                        txtPassword.Visible = true;
                        lblConfirmPassword.Visible = true;
                        txtConfirmPassword.Visible = true;
                        chkShowPassword.Visible = true;
                    }
                }
                else
                {
                    // Headadmin, Receptionist, Pharmacist
                    // Show password fields for creation
                    if (!isEditMode)
                    {
                        lblPassword.Visible = true;
                        txtPassword.Visible = true;
                        lblConfirmPassword.Visible = true;
                        txtConfirmPassword.Visible = true;
                        chkShowPassword.Visible = true;
                    }
                }
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirmPassword.PasswordChar = '•';
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                UpdateUser();
            }
            else
            {
                CreateUser();
            }
        }

        private void UpdateUser()
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                cmbRole.SelectedItem == null ||
                cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if email is already used by another user
            if (txtEmail.Text.Trim() != originalEmail)
            {
                string checkEmail = "SELECT COUNT(*) FROM Users WHERE email = @email AND user_id != @userId";
                object result = DatabaseHelper.ExecuteScalar(checkEmail,
                    new MySqlParameter("@email", txtEmail.Text.Trim()),
                    new MySqlParameter("@userId", userId));

                if (Convert.ToInt32(result) > 0)
                {
                    MessageBox.Show("This email is already in use by another user.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Validate age
            if (!int.TryParse(txtAge.Text, out int age) || age < 18 || age > 100)
            {
                MessageBox.Show("Please enter a valid age between 18 and 100.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentRole = cmbRole.SelectedItem.ToString();

            // Validate role-specific fields
            if (currentRole == "Doctor" && string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                MessageBox.Show("Please enter doctor's specialization.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Warn about role change
                        if (currentRole != originalRole)
                        {
                            DialogResult result = MessageBox.Show(
                                "Changing user role will affect their access permissions. Continue?",
                                "Role Change Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                            {
                                transaction.Rollback();
                                return;
                            }
                        }

                        // Update Users table
                        string query = @"UPDATE Users 
                                       SET name = @name, email = @email, age = @age, 
                                           gender = @gender, role = @role
                                       WHERE user_id = @userId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@age", age);
                            cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@role", currentRole);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        // Update role-specific tables
                        UpdateRoleSpecificTable(conn, transaction, currentRole);

                        transaction.Commit();

                        MessageBox.Show("User information updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        MessageBox.Show("Error updating user: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateRoleSpecificTable(MySqlConnection conn, MySqlTransaction transaction, string role)
        {
            if (role == "Patient")
            {
                string checkQuery = "SELECT COUNT(*) FROM Patients WHERE user_id = @userId";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        string query = @"UPDATE Patients 
                                       SET blood_type = @bloodType, allergies = @allergies
                                       WHERE user_id = @userId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bloodType", txtBloodType.Text.Trim());
                            cmd.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Patients (user_id, blood_type, allergies)
                                       VALUES (@userId, @bloodType, @allergies)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@bloodType", txtBloodType.Text.Trim());
                            cmd.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            else if (role == "Doctor")
            {
                string checkQuery = "SELECT COUNT(*) FROM Doctors WHERE user_id = @userId";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        string query = @"UPDATE Doctors 
                                       SET specialization = @specialization
                                       WHERE user_id = @userId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text.Trim());
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Doctors (user_id, specialization, is_available)
                                       VALUES (@userId, @specialization, 1)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void CreateUser()
        {

            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                cmbRole.SelectedItem == null ||
                cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cmbRole.SelectedItem.ToString();

            // Validate password based on role
            bool requirePassword = role != "Patient";

            if (requirePassword)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    MessageBox.Show("Please enter a password.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match. Please try again.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Clear();
                    txtConfirmPassword.Focus();
                    return;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 18 || age > 100)
            {
                MessageBox.Show("Please enter a valid age between 18 and 100.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role == "Doctor" && string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                MessageBox.Show("Please enter doctor's specialization.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmail.Text.Trim();
            string name = txtName.Text.Trim();
            string gender = cmbGender.SelectedItem.ToString();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {

                        string checkEmail = "SELECT COUNT(*) FROM Users WHERE email = @email";
                        using (MySqlCommand cmdCheckEmail = new MySqlCommand(checkEmail, conn, transaction))
                        {
                            cmdCheckEmail.Parameters.AddWithValue("@email", email);
                            long emailCount = Convert.ToInt64(cmdCheckEmail.ExecuteScalar());
                            if (emailCount > 0)
                            {
                                MessageBox.Show("This email is already registered.", "Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string password = role == "Patient" ? null : txtPassword.Text;

                        int? creatorId = createdByUserId;
                        if (!creatorId.HasValue && creatorRole != "Registration")
                        {
                            string getAdminId = "SELECT user_id FROM Users WHERE role = 'Headadmin' LIMIT 1";
                            using (MySqlCommand cmdGetAdmin = new MySqlCommand(getAdminId, conn, transaction))
                            {
                                object result = cmdGetAdmin.ExecuteScalar();
                                if (result != null && result != DBNull.Value)
                                    creatorId = Convert.ToInt32(result);
                            }
                        }

                        string insertUser = @"INSERT INTO Users (name, role, email, password, age, gender, created_by) 
                                              VALUES (@name, @role, @email, @password, @age, @gender, @createdBy)";
                        using (MySqlCommand cmdInsertUser = new MySqlCommand(insertUser, conn, transaction))
                        {
                            cmdInsertUser.Parameters.AddWithValue("@name", name);
                            cmdInsertUser.Parameters.AddWithValue("@role", role);
                            cmdInsertUser.Parameters.AddWithValue("@email", email);

                            if (password != null)
                                cmdInsertUser.Parameters.AddWithValue("@password", password);
                            else
                                cmdInsertUser.Parameters.AddWithValue("@password", DBNull.Value);

                            cmdInsertUser.Parameters.AddWithValue("@age", age);
                            cmdInsertUser.Parameters.AddWithValue("@gender", gender);

                            if (creatorId.HasValue)
                                cmdInsertUser.Parameters.AddWithValue("@createdBy", creatorId.Value);
                            else
                                cmdInsertUser.Parameters.AddWithValue("@createdBy", DBNull.Value);

                            cmdInsertUser.ExecuteNonQuery();
                        }

                        int newUserId;
                        using (MySqlCommand cmdGetLastId = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction))
                        {
                            newUserId = Convert.ToInt32(cmdGetLastId.ExecuteScalar());
                        }

                        if (role == "Patient")
                        {
                            string insertPatient = @"INSERT INTO Patients (user_id, blood_type, allergies) 
                                                     VALUES (@userId, @bloodType, @allergies)";
                            using (MySqlCommand cmdInsertPatient = new MySqlCommand(insertPatient, conn, transaction))
                            {
                                cmdInsertPatient.Parameters.AddWithValue("@userId", newUserId);
                                cmdInsertPatient.Parameters.AddWithValue("@bloodType", txtBloodType.Text.Trim());
                                cmdInsertPatient.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());
                                cmdInsertPatient.ExecuteNonQuery();
                            }
                        }
                        else if (role == "Doctor")
                        {
                            string insertDoctor = @"INSERT INTO Doctors (user_id, specialization, is_available) 
                                                    VALUES (@userId, @specialization, 1)";
                            using (MySqlCommand cmdInsertDoctor = new MySqlCommand(insertDoctor, conn, transaction))
                            {
                                cmdInsertDoctor.Parameters.AddWithValue("@userId", newUserId);
                                cmdInsertDoctor.Parameters.AddWithValue("@specialization", txtSpecialization.Text.Trim());
                                cmdInsertDoctor.ExecuteNonQuery();
                            }
                        }
                        else if (role == "Headadmin" || role == "Receptionist" || role == "Pharmacist")
                        {
                            string insertStaff = @"INSERT INTO Staff (user_id, position, department) 
                                                   VALUES (@userId, @position, @department)";
                            using (MySqlCommand cmdInsertStaff = new MySqlCommand(insertStaff, conn, transaction))
                            {
                                cmdInsertStaff.Parameters.AddWithValue("@userId", newUserId);

                                string position = role;
                                string department = role == "Headadmin" ? "Administration" :
                                                   role == "Receptionist" ? "Reception" :
                                                   "Pharmacy";

                                cmdInsertStaff.Parameters.AddWithValue("@position", position);
                                cmdInsertStaff.Parameters.AddWithValue("@department", department);
                                cmdInsertStaff.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();

                        string successMessage;
                        if (role == "Patient")
                        {
                            successMessage = $"Patient record created successfully!\n\n" +
                                           $"Name: {name}\n" +
                                           $"Email: {email}\n\n" +
                                           $"Note: Patients do not have login credentials.";
                        }
                        else
                        {
                            successMessage = $"{role} account created successfully!\n\n" +
                                           $"Name: {name}\n" +
                                           $"Email: {email}\n" +
                                           $"Password: {password}\n\n" +
                                           $"User can now login with these credentials.";
                        }

                        MessageBox.Show(successMessage, "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { }
                        MessageBox.Show($"User creation failed: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}