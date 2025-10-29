using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class RegisterForm : Form
    {
        private int? userId;
        private int? createdByUserId;
        private string creatorRole;
        private bool isEditMode;
        private string originalEmail;
        private string originalRole;
        private byte[] profileImageData;

        public RegisterForm(int userIdToEdit)
        {
            userId = userIdToEdit;
            isEditMode = true;
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            ConfigureForEditMode();
            LoadExistingUserData();
        }

        public RegisterForm(int creatorId, string role)
        {
            userId = null;
            isEditMode = false;
            createdByUserId = creatorId;
            creatorRole = role;
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            ConfigureForCreateMode();
        }

        public RegisterForm()
        {
            userId = null;
            isEditMode = false;
            createdByUserId = null;
            creatorRole = "Registration";
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            ConfigureForRegistrationMode();
        }

        private void SetPlaceholderImage()
        {
            Bitmap placeholder = new Bitmap(120, 120);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.FromArgb(230, 240, 255));

                using (Font font = new Font("Segoe UI", 48, FontStyle.Regular))
                {
                    string icon = "👤";
                    SizeF textSize = g.MeasureString(icon, font);
                    g.DrawString(icon, font, Brushes.Gray,
                        (120 - textSize.Width) / 2, (120 - textSize.Height) / 2);
                }
            }
            pictureBoxProfile.Image = placeholder;
        }

        private void BtnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Profile Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image originalImage = Image.FromFile(openFileDialog.FileName);
                        FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                        if (fileInfo.Length > 2 * 1024 * 1024)
                        {
                            MessageBox.Show("Image file size should not exceed 2MB.", "File Too Large",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        pictureBoxProfile.Image = originalImage;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            originalImage.Save(ms, originalImage.RawFormat);
                            profileImageData = ms.ToArray();
                        }

                        btnRemovePhoto.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRemovePhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remove profile photo?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SetPlaceholderImage();
                profileImageData = null;
                btnRemovePhoto.Visible = false;
            }
        }

        private void InitializeRoleOptions()
        {
            cmbRole.Items.Clear();

            if (isEditMode)
            {
                cmbRole.Items.AddRange(new string[] {
                    "Admin",
                    "Receptionist",
                    "Doctor",
                    "Pharmacist",
                    "Patient"
                });
            }
            else if (creatorRole == "Registration")
            {
                cmbRole.Items.AddRange(new string[] { "Admin", "Receptionist", "Doctor" });
            }
            else if (creatorRole == "Headadmin")
            {
                cmbRole.Items.AddRange(new string[] { "Admin", "Receptionist", "Doctor", "Pharmacist", "Patient" });
            }
            else if (creatorRole == "Receptionist")
            {
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

            lblPassword.Visible = false;
            txtPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;

            chkChangePassword.Visible = true;
            chkShowPassword.Visible = false;
        }

        private void ConfigureForCreateMode()
        {
            lblTitle.Text = "Create New User";
            this.Text = "Create User - St. Joseph's Hospital";
            btnSubmit.Text = "Create User";

            chkChangePassword.Visible = false;

            if (creatorRole == "Receptionist")
            {
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

            chkChangePassword.Visible = false;

            lblPassword.Visible = true;
            txtPassword.Visible = true;
            lblConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            chkShowPassword.Visible = true;
        }

        private void LoadExistingUserData()
        {
            string query = @"SELECT name, email, age, gender, role, profile_image FROM Users WHERE user_id = @userId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["name"].ToString();
                txtEmail.Text = row["email"].ToString();
                originalEmail = txtEmail.Text;
                txtAge.Text = row["age"].ToString();
                cmbGender.SelectedItem = row["gender"].ToString();
                originalRole = row["role"].ToString();

                if (originalRole == "Headadmin")
                {
                    if (!cmbRole.Items.Contains("Headadmin"))
                    {
                        cmbRole.Items.Insert(0, "Headadmin");
                    }
                    cmbRole.SelectedItem = "Headadmin";
                    cmbRole.Enabled = false;
                }
                else
                {
                    cmbRole.SelectedItem = originalRole;
                }

                if (row["profile_image"] != DBNull.Value)
                {
                    profileImageData = (byte[])row["profile_image"];
                    using (MemoryStream ms = new MemoryStream(profileImageData))
                    {
                        pictureBoxProfile.Image = Image.FromStream(ms);
                    }
                    btnRemovePhoto.Visible = true;
                }

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

        private void ChkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            bool showPasswordFields = chkChangePassword.Checked;

            lblPassword.Visible = showPasswordFields;
            txtPassword.Visible = showPasswordFields;
            lblConfirmPassword.Visible = showPasswordFields;
            txtConfirmPassword.Visible = showPasswordFields;
            chkShowPassword.Visible = showPasswordFields;

            if (!showPasswordFields)
            {
                txtPassword.Clear();
                txtConfirmPassword.Clear();
            }
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

                    if (isEditMode)
                    {
                        if (chkChangePassword.Checked)
                        {
                            chkChangePassword.Checked = false;
                        }
                        chkChangePassword.Visible = false;
                        lblPassword.Visible = false;
                        txtPassword.Visible = false;
                        lblConfirmPassword.Visible = false;
                        txtConfirmPassword.Visible = false;
                        chkShowPassword.Visible = false;
                    }
                    else
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

                    if (isEditMode)
                    {
                        chkChangePassword.Visible = true;
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
                else
                {
                    if (isEditMode)
                    {
                        chkChangePassword.Visible = true;
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

        private bool ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                MessageBox.Show("Password must contain at least one uppercase letter.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                MessageBox.Show("Password must contain at least one lowercase letter.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Password must contain at least one number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            /* thinking if i should add this or not
            if (!Regex.IsMatch(password, @"[!@#$%^&*(),.?""':{}|<>]"))
            {
                MessageBox.Show("Password must contain at least one special character (!@#$%^&*...).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            } */

            return true;
        }

        private void UpdateUser()
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

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("Please enter a valid age between 1 and 120.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentRole = cmbRole.SelectedItem.ToString();

            if (currentRole == "Doctor" && string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                MessageBox.Show("Please enter doctor's specialization.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkChangePassword.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter a new password.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidatePassword(txtPassword.Text))
                {
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Clear();
                    txtConfirmPassword.Focus();
                    return;
                }
            }

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (currentRole != originalRole && originalRole != "Headadmin")
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

                        string query = @"UPDATE Users 
                                       SET name = @name, email = @email, age = @age, 
                                           gender = @gender, role = @role, profile_image = @profileImage
                                       WHERE user_id = @userId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@age", age);
                            cmd.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@role", currentRole);

                            if (profileImageData != null)
                                cmd.Parameters.AddWithValue("@profileImage", profileImageData);
                            else
                                cmd.Parameters.AddWithValue("@profileImage", DBNull.Value);

                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        if (chkChangePassword.Checked)
                        {
                            string passwordQuery = "UPDATE Users SET password = @password WHERE user_id = @userId";
                            using (MySqlCommand cmdPassword = new MySqlCommand(passwordQuery, conn, transaction))
                            {
                                cmdPassword.Parameters.AddWithValue("@password", txtPassword.Text);
                                cmdPassword.Parameters.AddWithValue("@userId", userId);
                                cmdPassword.ExecuteNonQuery();
                            }
                        }

                        UpdateRoleSpecificTable(conn, transaction, currentRole);

                        transaction.Commit();

                        string successMsg = chkChangePassword.Checked
                            ? "User information and password updated successfully!"
                            : "User information updated successfully!";

                        MessageBox.Show(successMsg, "Success",
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

            if (creatorRole == "Receptionist" && role != "Patient")
            {
                MessageBox.Show("Receptionists can only create Patient records.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                if (!ValidatePassword(txtPassword.Text))
                {
                    return;
                }
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("Please enter a valid age between 1 and 120.", "Validation Error",
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

                        string insertUser = @"INSERT INTO Users (name, role, email, password, age, gender, created_by, profile_image) 
                                              VALUES (@name, @role, @email, @password, @age, @gender, @createdBy, @profileImage)";
                        using (MySqlCommand cmdInsertUser = new MySqlCommand(insertUser, conn, transaction))
                        {
                            cmdInsertUser.Parameters.AddWithValue("@name", name);
                            cmdInsertUser.Parameters.AddWithValue("@role", role);
                            cmdInsertUser.Parameters.AddWithValue("@email", email);
                            cmdInsertUser.Parameters.AddWithValue("@password", password ?? (object)DBNull.Value);
                            cmdInsertUser.Parameters.AddWithValue("@age", age);
                            cmdInsertUser.Parameters.AddWithValue("@gender", gender);

                            if (creatorId.HasValue)
                                cmdInsertUser.Parameters.AddWithValue("@createdBy", creatorId.Value);
                            else
                                cmdInsertUser.Parameters.AddWithValue("@createdBy", DBNull.Value);

                            if (profileImageData != null)
                                cmdInsertUser.Parameters.AddWithValue("@profileImage", profileImageData);
                            else
                                cmdInsertUser.Parameters.AddWithValue("@profileImage", DBNull.Value);

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

                        else if (role == "Headadmin" || role == "Admin" || role == "Receptionist" || role == "Pharmacist")
                        {
                            string insertStaff = @"INSERT INTO Staff (user_id, position, department) 
                                                   VALUES (@userId, @position, @department)";
                            using (MySqlCommand cmdInsertStaff = new MySqlCommand(insertStaff, conn, transaction))
                            {
                                cmdInsertStaff.Parameters.AddWithValue("@userId", newUserId);

                                string position = role;
                                string department = role == "Headadmin" ? "Administration" :
                                                   role == "Admin" ? "Administration" :
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
                                           $"⚠️ IMPORTANT: Please save these credentials securely.\n" +
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