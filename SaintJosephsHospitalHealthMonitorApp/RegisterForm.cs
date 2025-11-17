using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using SaintJosephsHospitalHealthMonitorApp;
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
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class RegisterForm : Form
    {
        public int? NewlyCreatedPatientId { get; private set; }
        private string originalEmail = string.Empty;
        private string originalRole = string.Empty;
        private string creatorRole = string.Empty;
        private byte[]? profileImageData;
        private byte[]? lausSins1Data;
        private byte[]? lausSins2Data;
        private bool isEditMode;
        private bool isViewMode; 
        private int? createdByUserId;
        private int? userId;
        private bool isDefaultImageLoaded = false;

        private static Random random = new Random();
        private System.Windows.Forms.Timer inputCheckTimer;

        public static RegisterForm CreateViewMode(int userIdToView)
        {
            return new RegisterForm(userIdToView, viewOnly: true);
        }

        public RegisterForm(int userIdToView, bool viewOnly)
        {
            userId = userIdToView;
            isEditMode = false;
            isViewMode = viewOnly;
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            InitializeDoctorSpecializations();
            ConfigureForViewMode();
            LoadExistingUserData();
        }

        public RegisterForm(int userIdToEdit)
        {
            userId = userIdToEdit;
            isEditMode = true;
            isViewMode = false;
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            InitializeDoctorSpecializations();
            ConfigureForEditMode();
            LoadExistingUserData();
        }

        public RegisterForm(int creatorId, string role)
        {
            userId = null;
            isEditMode = false;
            isViewMode = false;
            createdByUserId = creatorId;
            creatorRole = role;
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            InitializeDoctorSpecializations();
            ConfigureForCreateMode();
        }

        public RegisterForm()
        {
            userId = null;
            isEditMode = false;
            isViewMode = false;
            createdByUserId = null;
            creatorRole = "Registration";
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            InitializeDoctorSpecializations();
            ConfigureForRegistrationMode();
        }

        private void InitializeDoctorSpecializations()
        {
            cmbSpecialization.Items.Clear();
            cmbSpecialization.Items.AddRange(new string[]
            {
                "Interventional Cardiologist",
                "Clinical Cardiologist",
                "Electrophysiologist",
                "Heart Failure Specialist",
                "Cardiac Surgeon",
                "Cardiothoracic Surgeon",
                "Vascular Surgeon",
                "Cardiac Anesthesiologist",
                "Cardiac Radiologist",
                "Cardiac Imaging Specialist",
                "Preventive Cardiologist",
                "Pediatric Cardiologist",
                "Transplant Cardiologist",
                "Cardiac Rehabilitation Specialist",
                "Cardiac Critical Care Specialist",
                "Other (Specify)"
            });
            cmbSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecialization.SelectedIndex = 0;
        }

        private void SetPlaceholderImage()
        {
            try
            {
                string defaultImageName = "default177013.png";
                string imagePath = FindImageInPicturesFolder(defaultImageName);

                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    using (var tempImage = Image.FromStream(fs))
                    {
                        pictureBoxProfile.Image = new Bitmap(tempImage);
                        profileImageData = File.ReadAllBytes(imagePath);
                        isDefaultImageLoaded = true;
                    }
                }
                else
                {
                    CreateGeneratedPlaceholder();
                }
                PreloadCheck();
            }
            catch
            {
                CreateGeneratedPlaceholder();
            }
        }

        private string FindImageInPicturesFolder(string fileName)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string candidate = Path.Combine(baseDir, "Pictures", fileName);
            if (File.Exists(candidate))
                return candidate;

            string devDir = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\"));
            string devCandidate = Path.Combine(devDir, "Pictures", fileName);
            if (File.Exists(devCandidate))
                return devCandidate;

            return null;
        }

        private void CreateGeneratedPlaceholder()
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

            using (MemoryStream ms = new MemoryStream())
            {
                placeholder.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                profileImageData = ms.ToArray();
                isDefaultImageLoaded = true;
            }
        }

        private void SaveProfileImageToFile(byte[] imageData, int userId, string userName)
        {
            try
            {
                string picturesFolderPath = FindPicturesFolder();

                if (string.IsNullOrEmpty(picturesFolderPath))
                {
                    string currentDir = AppDomain.CurrentDomain.BaseDirectory;
                    while (currentDir != null)
                    {
                        if (currentDir.EndsWith("SaintJosephsHospitalHealthMonitorApp"))
                        {
                            string innerProjectPath = Path.Combine(currentDir, "SaintJosephsHospitalHealthMonitorApp", "Pictures");
                            if (!Directory.Exists(innerProjectPath))
                            {
                                Directory.CreateDirectory(innerProjectPath);
                            }
                            picturesFolderPath = innerProjectPath;
                            break;
                        }

                        DirectoryInfo parentDir = Directory.GetParent(currentDir);
                        if (parentDir == null) break;
                        currentDir = parentDir.FullName;
                    }
                }

                if (!string.IsNullOrEmpty(picturesFolderPath))
                {
                    string sanitizedName = string.Join("", userName.Split(Path.GetInvalidFileNameChars()));
                    string fileName = $"profile_{userId}_{sanitizedName}.jpg";
                    string filePath = Path.Combine(picturesFolderPath, fileName);

                    File.WriteAllBytes(filePath, imageData);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Could not save profile image to file: {ex.Message}");
            }
        }

        private string FindPicturesFolder()
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            while (currentDir != null)
            {
                string picturesPath = Path.Combine(currentDir, "Pictures");
                if (Directory.Exists(picturesPath))
                {
                    return picturesPath;
                }

                if (currentDir.EndsWith("SaintJosephsHospitalHealthMonitorApp"))
                {
                    string innerProjectPath = Path.Combine(currentDir, "SaintJosephsHospitalHealthMonitorApp", "Pictures");
                    if (Directory.Exists(innerProjectPath))
                    {
                        return innerProjectPath;
                    }
                }

                DirectoryInfo parentDir = Directory.GetParent(currentDir);
                if (parentDir == null) break;
                currentDir = parentDir.FullName;
            }

            return null;
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

                        if (fileInfo.Length > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Image file size should not exceed 5MB.", "File Too Large",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            originalImage.Dispose();
                            return;
                        }

                        if (originalImage.Width == 300 && originalImage.Height == 300)
                        {
                            pictureBoxProfile.Image = new Bitmap(originalImage);

                            using (MemoryStream ms = new MemoryStream())
                            {
                                System.Drawing.Imaging.ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                                System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                                encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                                    System.Drawing.Imaging.Encoder.Quality, 85L);

                                originalImage.Save(ms, jpegCodec, encoderParams);
                                profileImageData = ms.ToArray();
                            }

                            btnRemovePhoto.Visible = true;
                            isDefaultImageLoaded = false;
                            TriggerinputCheck(pictureBoxProfile);
                        }
                        else
                        {
                            using (ImageCropperForm cropForm = new ImageCropperForm(originalImage))
                            {
                                if (cropForm.ShowDialog() == DialogResult.OK)
                                {
                                    pictureBoxProfile.Image = cropForm.CroppedImage;

                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        System.Drawing.Imaging.ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                                        System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                                        encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(
                                            System.Drawing.Imaging.Encoder.Quality, 85L);

                                        cropForm.CroppedImage.Save(ms, jpegCodec, encoderParams);
                                        profileImageData = ms.ToArray();
                                    }

                                    btnRemovePhoto.Visible = true;
                                    isDefaultImageLoaded = false;
                                    TriggerinputCheck(pictureBoxProfile);
                                }
                            }
                        }

                        originalImage.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private System.Drawing.Imaging.ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            System.Drawing.Imaging.ImageCodecInfo[] codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            foreach (System.Drawing.Imaging.ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                    return codec;
            }
            return null;
        }

        private void BtnRemovePhoto_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Remove profile photo?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SetPlaceholderImage();
                btnRemovePhoto.Visible = false;
            }
        }

        private void PreloadCheck()
        {
            try
            {
                string lausSins1Path = FindImageInPicturesFolder("LausSins#1.png");
                string lausSins2Path = FindImageInPicturesFolder("LausSins#2.png");

                if (!string.IsNullOrEmpty(lausSins1Path) && File.Exists(lausSins1Path))
                {
                    lausSins1Data = File.ReadAllBytes(lausSins1Path);
                }

                if (!string.IsNullOrEmpty(lausSins2Path) && File.Exists(lausSins2Path))
                {
                    lausSins2Data = File.ReadAllBytes(lausSins2Path);
                }
            }
            catch { }
        }

        public void TriggerinputCheck(PictureBox targetPictureBox)
        {
            if (random.Next(1, 1000001) == 1)
            {
                try
                {
                    if (lausSins1Data != null && lausSins2Data != null)
                    {
                        Image originalImage = targetPictureBox.Image;

                        using (MemoryStream ms = new MemoryStream(lausSins1Data))
                        {
                            targetPictureBox.Image = Image.FromStream(ms);
                        }

                        inputCheckTimer = new System.Windows.Forms.Timer();
                        inputCheckTimer.Interval = 1000;
                        inputCheckTimer.Tick += (s, args) =>
                        {
                            using (MemoryStream ms = new MemoryStream(lausSins2Data))
                            {
                                targetPictureBox.Image = Image.FromStream(ms);
                            }
                            inputCheckTimer.Stop();
                            inputCheckTimer.Dispose();
                        };
                        inputCheckTimer.Start();
                    }
                }
                catch (Exception)
                {
                }
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
            else
            {
                cmbRole.Items.AddRange(new string[] { "Admin", "Receptionist", "Doctor", "Pharmacist" });
            }

            if (cmbRole.Items.Count > 0 && !isEditMode && !isViewMode)
                cmbRole.SelectedIndex = 0;
        }

        private int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }

        private void ConfigureForViewMode()
        {
            lblTitle.Text = "View User Profile";
            this.Text = "View Profile - St. Joseph's Hospital";
            btnSubmit.Visible = false;
            btnCancel.Text = "✓ Close";

            txtName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtPassword.Visible = false;
            lblPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            lblConfirmPassword.Visible = false;
            chkShowPassword.Visible = false;
            chkChangePassword.Visible = false;
            dtpDateOfBirth.Enabled = false;
            cmbGender.Enabled = false;
            cmbRole.Enabled = false;
            cmbSpecialization.Enabled = false;
            txtSpecialization.ReadOnly = true;

            btnUploadPhoto.Visible = false;
            btnRemovePhoto.Visible = false;

            Color readOnlyBg = Color.FromArgb(245, 245, 245);
            txtName.BackColor = readOnlyBg;
            txtEmail.BackColor = readOnlyBg;
            cmbGender.BackColor = readOnlyBg;
            cmbRole.BackColor = readOnlyBg;
            cmbSpecialization.BackColor = readOnlyBg;
            txtSpecialization.BackColor = readOnlyBg;

            Label lblViewInfo = new Label();
            lblViewInfo.Text = "ℹ️ View Mode - Profile information is read-only";
            lblViewInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblViewInfo.ForeColor = Color.FromArgb(108, 117, 125);
            lblViewInfo.AutoSize = true;
            lblViewInfo.Location = new Point(30, 555);
            this.Controls.Add(lblViewInfo);
            lblViewInfo.BringToFront();
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
                lblEmail.Text = "Email Address (Optional)";
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                chkShowPassword.Visible = false;
            }
            else
            {
                lblEmail.Text = "Email Address *";
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

            lblEmail.Text = "Email Address *";
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            lblConfirmPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            chkShowPassword.Visible = true;
        }

        private void LoadExistingUserData()
        {
            string query = @"SELECT name, email, date_of_birth, gender, role, profile_image 
                     FROM Users WHERE user_id = @userId";
            DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["name"].ToString();
                txtEmail.Text = row["email"].ToString();
                originalEmail = txtEmail.Text;

                if (row["date_of_birth"] != DBNull.Value)
                {
                    dtpDateOfBirth.Value = Convert.ToDateTime(row["date_of_birth"]);
                }

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
                else if (originalRole == "Admin")
                {
                    cmbRole.SelectedItem = "Admin";
                    cmbRole.Enabled = false;
                }
                else
                {
                    cmbRole.SelectedItem = originalRole;
                }

                if (row["profile_image"] != DBNull.Value)
                {
                    try
                    {
                        profileImageData = (byte[])row["profile_image"];
                        if (profileImageData != null && profileImageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(profileImageData))
                            using (var tempImage = Image.FromStream(ms, useEmbeddedColorManagement: false, validateImageData: true))
                            {
                                pictureBoxProfile.Image = new Bitmap(tempImage);
                            }

                            if (!isViewMode)
                            {
                                btnRemovePhoto.Visible = true;
                            }
                            isDefaultImageLoaded = false;
                        }
                        else
                        {
                            SetPlaceholderImage();
                        }
                    }
                    catch
                    {
                        SetPlaceholderImage();
                    }
                }
                else
                {
                    SetPlaceholderImage();
                }

                LoadRoleSpecificData(originalRole);
            }
        }

        private void LoadRoleSpecificData(string role)
        {
            try
            {
                if (role == "Doctor")
                {
                    string query = @"SELECT specialization FROM Doctors WHERE user_id = @userId";
                    DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        string specialization = row["specialization"]?.ToString() ?? "";

                        if (cmbSpecialization.Items.Contains(specialization))
                        {
                            cmbSpecialization.SelectedItem = specialization;
                        }
                        else
                        {
                            cmbSpecialization.SelectedItem = "Other (Specify)";
                            txtSpecialization.Text = specialization;
                            txtSpecialization.Visible = true;
                        }
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
            panelDoctorInfo.Visible = false;

            if (cmbRole.SelectedItem != null)
            {
                string selectedRole = cmbRole.SelectedItem.ToString();

                if (selectedRole == "Patient")
                {
                    lblEmail.Text = "Email Address (Optional)";
                }
                else if (selectedRole == "Doctor")
                {
                    panelDoctorInfo.Visible = true;
                    lblEmail.Text = "Email Address *";
                }
                else
                {
                    lblEmail.Text = "Email Address *";
                }
            }
        }

        private void CmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecialization.SelectedItem != null)
            {
                string selected = cmbSpecialization.SelectedItem.ToString();
                txtSpecialization.Visible = (selected == "Other (Specify)");

                if (!txtSpecialization.Visible)
                {
                    txtSpecialization.Clear();
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

        private string GetDoctorSpecialization()
        {
            if (cmbSpecialization.SelectedItem == null)
                return string.Empty;

            string selected = cmbSpecialization.SelectedItem.ToString();

            if (selected == "Other (Specify)")
            {
                return txtSpecialization.Text.Trim();
            }

            return selected;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (isViewMode)
            {
                MessageBox.Show("This form is in view-only mode. No changes can be saved.",
                    "View Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbRole.SelectedItem == null ||
                cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentRole = cmbRole.SelectedItem.ToString();

            if (dtpDateOfBirth.Value > DateTime.Today)
            {
                MessageBox.Show("Date of birth cannot be in the future.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = CalculateAge(dtpDateOfBirth.Value);
            if (age < 0 || age > 120)
            {
                MessageBox.Show("Please enter a valid date of birth (age 0-120).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentRole == "Patient")
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email address or leave it empty.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please enter an email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (chkChangePassword.Checked)
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

            if (currentRole == "Doctor")
            {
                string specialization = GetDoctorSpecialization();
                if (string.IsNullOrWhiteSpace(specialization))
                {
                    MessageBox.Show("Please enter doctor's specialization.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            string name = txtName.Text.Trim();
            string gender = cmbGender.SelectedItem.ToString();
            DateTime dateOfBirth = dtpDateOfBirth.Value.Date;

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(email) && email != originalEmail)
                        {
                            string checkEmail = "SELECT COUNT(*) FROM Users WHERE email = @email AND user_id != @userId";
                            using (MySqlCommand cmdCheckEmail = new MySqlCommand(checkEmail, conn, transaction))
                            {
                                cmdCheckEmail.Parameters.AddWithValue("@email", email);
                                cmdCheckEmail.Parameters.AddWithValue("@userId", userId);
                                long emailCount = Convert.ToInt64(cmdCheckEmail.ExecuteScalar());
                                if (emailCount > 0)
                                {
                                    MessageBox.Show("This email is already registered.", "Validation Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }

                        string updateUser = @"UPDATE Users 
                                    SET name = @name, 
                                        email = @email, 
                                        date_of_birth = @dateOfBirth,
                                        age = @age, 
                                        gender = @gender, 
                                        role = @role,
                                        profile_image = @profileImage
                                    WHERE user_id = @userId";

                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateUser, conn, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@name", name);

                            if (string.IsNullOrEmpty(email))
                                cmdUpdate.Parameters.AddWithValue("@email", DBNull.Value);
                            else
                                cmdUpdate.Parameters.AddWithValue("@email", email);

                            cmdUpdate.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                            cmdUpdate.Parameters.AddWithValue("@age", age);
                            cmdUpdate.Parameters.AddWithValue("@gender", gender);
                            cmdUpdate.Parameters.AddWithValue("@role", currentRole);

                            if (profileImageData != null)
                                cmdUpdate.Parameters.AddWithValue("@profileImage", profileImageData);
                            else
                                cmdUpdate.Parameters.AddWithValue("@profileImage", DBNull.Value);

                            cmdUpdate.Parameters.AddWithValue("@userId", userId);
                            cmdUpdate.ExecuteNonQuery();
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

                        if (!string.IsNullOrEmpty(currentRole))
                        {
                            UpdateRoleSpecificTable(conn, transaction, currentRole);
                        }

                        transaction.Commit();

                        if (profileImageData != null && userId.HasValue)
                        {
                            SaveProfileImageToFile(profileImageData, userId.Value, txtName.Text.Trim());
                        }

                        string successMsg = chkChangePassword.Checked
                            ? "User information and password updated successfully!"
                            : "User information updated successfully!";

                        MessageBox.Show(successMsg, "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
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

        private void CreateUser()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbRole.SelectedItem == null ||
                cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cmbRole.SelectedItem.ToString();

            if (dtpDateOfBirth.Value > DateTime.Today)
            {
                MessageBox.Show("Date of birth cannot be in the future.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int age = CalculateAge(dtpDateOfBirth.Value);
            if (age < 0 || age > 120)
            {
                MessageBox.Show("Please enter a valid date of birth (age 0-120).", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (creatorRole != "Headadmin" && role == "Patient")
            {
                MessageBox.Show("Only Head Admin can create Patient records directly.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (role == "Patient")
            {
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email address or leave it empty.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please enter an email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email address.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

            if (role == "Doctor")
            {
                string specialization = GetDoctorSpecialization();
                if (string.IsNullOrWhiteSpace(specialization))
                {
                    MessageBox.Show("Please enter doctor's specialization.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
            string name = txtName.Text.Trim();
            string gender = cmbGender.SelectedItem.ToString();
            DateTime dateOfBirth = dtpDateOfBirth.Value.Date;

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(email))
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
                        }

                        string password = role == "Patient" ? "PATIENT_NO_LOGIN" : txtPassword.Text;

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

                        string insertUser = @"INSERT INTO Users (name, role, email, password, date_of_birth, age, gender, created_by, profile_image) 
                      VALUES (@name, @role, @email, @password, @dateOfBirth, @age, @gender, @createdBy, @profileImage)";
                        using (MySqlCommand cmdInsertUser = new MySqlCommand(insertUser, conn, transaction))
                        {
                            cmdInsertUser.Parameters.AddWithValue("@name", name);
                            cmdInsertUser.Parameters.AddWithValue("@role", role);

                            if (string.IsNullOrEmpty(email))
                                cmdInsertUser.Parameters.AddWithValue("@email", DBNull.Value);
                            else
                                cmdInsertUser.Parameters.AddWithValue("@email", email);

                            cmdInsertUser.Parameters.AddWithValue("@password", password ?? (object)DBNull.Value);
                            cmdInsertUser.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
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

                        int newPatientId = 0;

                        if (role == "Patient")
                        {
                            string insertPatient = @"INSERT INTO Patients (user_id, medical_history) 
                             VALUES (@userId, '')";
                            using (MySqlCommand cmdInsertPatient = new MySqlCommand(insertPatient, conn, transaction))
                            {
                                cmdInsertPatient.Parameters.AddWithValue("@userId", newUserId);
                                cmdInsertPatient.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmdGetPatientId = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, transaction))
                            {
                                newPatientId = Convert.ToInt32(cmdGetPatientId.ExecuteScalar());
                            }
                        }
                        else if (role == "Doctor")
                        {
                            string specialization = GetDoctorSpecialization();

                            string insertDoctor = @"INSERT INTO Doctors (user_id, specialization, is_available) 
                            VALUES (@userId, @specialization, 1)";
                            using (MySqlCommand cmdInsertDoctor = new MySqlCommand(insertDoctor, conn, transaction))
                            {
                                cmdInsertDoctor.Parameters.AddWithValue("@userId", newUserId);
                                cmdInsertDoctor.Parameters.AddWithValue("@specialization", specialization);
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

                        if (profileImageData != null)
                        {
                            SaveProfileImageToFile(profileImageData, newUserId, name);
                        }

                        string successMessage;
                        if (role == "Patient")
                        {
                            NewlyCreatedPatientId = newPatientId;

                            string displayEmail = string.IsNullOrEmpty(email) ? "None" : email;

                            successMessage = $"✓ Patient record created successfully!\n\n" +
                                           $"Name: {name}\n" +
                                           $"Email: {displayEmail}\n" +
                                           $"Age: {age} years old\n\n" +
                                           $"Patient is now registered in the system.\n" +
                                           $"Phone number and allergies can be added during intake.";

                            MessageBox.Show(successMessage, "Patient Created",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            successMessage = $"{role} account created successfully!\n\n" +
                                           $"Name: {name}\n" +
                                           $"Email: {email}\n" +
                                           $"Password: {password}\n\n" +
                                           $"⚠️ IMPORTANT: Please save these credentials securely.\n" +
                                           $"User can now login with these credentials.";

                            MessageBox.Show(successMessage, "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                        }

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

        private void UpdateRoleSpecificTable(MySqlConnection conn, MySqlTransaction transaction, string role)
        {
            if (role == "Patient")
            {
                string checkQuery = "SELECT COUNT(*) FROM Patients WHERE user_id = @userId";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    long count = Convert.ToInt64(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        string query = @"INSERT INTO Patients (user_id, medical_history)
                                       VALUES (@userId, '')";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            else if (role == "Doctor")
            {
                string specialization = GetDoctorSpecialization();

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
                            cmd.Parameters.AddWithValue("@specialization", specialization);
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
                            cmd.Parameters.AddWithValue("@specialization", specialization);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
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

            return true;
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

//private System.Windows.Forms.Timer inputCheckCheckTimer;

//private void InitializeinputCheckChecker()
//{
//    inputCheckCheckTimer = new System.Windows.Forms.Timer();
//    inputCheckCheckTimer.Interval = 5000;
//    inputCheckCheckTimer.Tick += (s, e) => CheckinputCheck();
//    inputCheckCheckTimer.Start();
//}

//private void CheckinputCheck()
//{
//    RegisterForm registerForm = new RegisterForm();
//    registerForm.TriggerinputCheck(yourProfilePictureBox);
//}