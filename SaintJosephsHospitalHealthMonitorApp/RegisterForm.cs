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
        private int? createdByUserId;
        private int? userId;

        private static Random random = new Random();
        private System.Windows.Forms.Timer inputCheckTimer;

        public RegisterForm(int userIdToEdit)
        {
            userId = userIdToEdit;
            isEditMode = true;
            InitializeComponent();
            SetPlaceholderImage();
            InitializeRoleOptions();
            InitializeDoctorSpecializations();
            InitializePhoneNumberType();
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
            InitializeDoctorSpecializations();
            InitializePhoneNumberType();
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
            InitializeDoctorSpecializations();
            InitializePhoneNumberType();
            ConfigureForRegistrationMode();
        }

        private void InitializeDoctorSpecializations()
        {
            cmbSpecialization.Items.Clear();
            cmbSpecialization.Items.AddRange(new string[]
            {
                "General Practitioner",
                "Cardiologist",
                "Dermatologist",
                "Endocrinologist",
                "Gastroenterologist",
                "Neurologist",
                "Obstetrician-Gynecologist (OB-GYN)",
                "Ophthalmologist",
                "Orthopedic Surgeon",
                "Pediatrician",
                "Psychiatrist",
                "Pulmonologist",
                "Radiologist",
                "Surgeon",
                "Urologist",
                "Other (Specify)"
            });

            cmbSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecialization.SelectedIndex = 0;
        }

        private void InitializePhoneNumberType()
        {
            cmbPhoneType.Items.Clear();
            cmbPhoneType.Items.AddRange(new string[] { "Mobile", "Landline" });
            cmbPhoneType.SelectedIndex = 0;
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
                profileImageData = null;
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
            string query = @"SELECT name, email, age, gender, role, profile_image 
                     FROM Users WHERE user_id = @userId";
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
                            btnRemovePhoto.Visible = true;
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
                if (role == "Patient")
                {
                    string query = @"SELECT allergies, phone_number FROM Patients WHERE user_id = @userId";
                    DataTable dt = DatabaseHelper.ExecuteQuery(query, new MySqlParameter("@userId", userId));

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        txtAllergies.Text = row["allergies"]?.ToString() ?? "";

                        string phoneNumber = row["phone_number"]?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(phoneNumber))
                        {
                            if (phoneNumber.StartsWith("09") || phoneNumber.StartsWith("+639"))
                            {
                                cmbPhoneType.SelectedItem = "Mobile";
                                txtPhoneNumber.Text = phoneNumber.Replace("+63", "0");
                            }
                            else
                            {
                                cmbPhoneType.SelectedItem = "Landline";
                                txtPhoneNumber.Text = phoneNumber;
                            }
                        }
                    }
                }
                else if (role == "Doctor")
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
            panelPatientInfo.Visible = false;
            panelDoctorInfo.Visible = false;

            if (cmbRole.SelectedItem != null)
            {
                string selectedRole = cmbRole.SelectedItem.ToString();

                if (selectedRole == "Patient")
                {
                    panelPatientInfo.Visible = false;

                    lblEmail.Text = "Email Address (Optional)";

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

                    lblEmail.Text = "Email Address *";

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
                    lblEmail.Text = "Email Address *";

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

        private void CmbSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecialization.SelectedItem != null)
            {
                string selected = cmbSpecialization.SelectedItem.ToString();

                if (selected == "Other (Specify)")
                {
                    txtSpecialization.Visible = true;
                    txtSpecialization.Clear();
                    txtSpecialization.Focus();
                }
                else
                {
                    txtSpecialization.Visible = false;
                    txtSpecialization.Clear();
                }
            }
        }

        private void CmbPhoneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPhoneNumber.Clear();

            if (cmbPhoneType.SelectedItem != null)
            {
                string phoneType = cmbPhoneType.SelectedItem.ToString();

                if (phoneType == "Mobile")
                {
                    txtPhoneNumber.MaxLength = 11;
                    lblPhoneNumber.Text = "Phone Number (09XXXXXXXXX)";
                }
                else
                {
                    txtPhoneNumber.MaxLength = 9;
                    lblPhoneNumber.Text = "Phone Number (0X-XXX-XXXX)";
                }
            }
        }

        private void TxtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private bool ValidatePhilippinePhoneNumber(string phoneNumber, string phoneType)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return true; // Phone number is now optional for patients

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "");

            if (phoneType == "Mobile")
            {
                if (phoneNumber.Length == 11 && phoneNumber.StartsWith("09"))
                {
                    return phoneNumber.All(char.IsDigit);
                }

                MessageBox.Show("Invalid mobile number format. Must be 11 digits starting with 09 (e.g., 09171234567).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (phoneNumber.Length >= 8 && phoneNumber.Length <= 10 && phoneNumber.StartsWith("0"))
                {
                    return phoneNumber.All(char.IsDigit);
                }

                MessageBox.Show("Invalid landline number format. Must be 8-10 digits starting with 0 (e.g., 028-1234567 for Metro Manila, 032-1234567 for Cebu).",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private string FormatPhoneNumberForStorage(string phoneNumber, string phoneType)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return "";

            phoneNumber = phoneNumber.Replace(" ", "").Replace("-", "");

            if (phoneType == "Mobile")
            {
                if (phoneNumber.StartsWith("09"))
                {
                    return "+63" + phoneNumber.Substring(1);
                }
            }

            return phoneNumber;
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

            if (currentRole == "Patient")
            {
                // Phone number is now optional, but validate if provided
                if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    if (cmbPhoneType.SelectedItem == null)
                    {
                        MessageBox.Show("Please select phone type.", "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!ValidatePhilippinePhoneNumber(txtPhoneNumber.Text.Trim(), cmbPhoneType.SelectedItem.ToString()))
                    {
                        return;
                    }
                }
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

        private void CreateUser()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
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

            if (role != "Patient")
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

            if (!int.TryParse(txtAge.Text, out int age) || age < 1 || age > 120)
            {
                MessageBox.Show("Please enter a valid age between 1 and 120.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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

            // Validate phone number only if provided (it's optional now)
            if (role == "Patient" && !string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                if (cmbPhoneType.SelectedItem == null)
                {
                    MessageBox.Show("Please select phone type.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidatePhilippinePhoneNumber(txtPhoneNumber.Text.Trim(), cmbPhoneType.SelectedItem.ToString()))
                {
                    return;
                }
            }

            // CHANGED: Set email to null if not provided, instead of fake email
            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ?
                null : // Set to null instead of fake email
                txtEmail.Text.Trim();

            string name = txtName.Text.Trim();
            string gender = cmbGender.SelectedItem.ToString();

            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // CHANGED: Only check email if one was provided (not null)
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

                        string insertUser = @"INSERT INTO Users (name, role, email, password, age, gender, created_by, profile_image) 
                      VALUES (@name, @role, @email, @password, @age, @gender, @createdBy, @profileImage)";
                        using (MySqlCommand cmdInsertUser = new MySqlCommand(insertUser, conn, transaction))
                        {
                            cmdInsertUser.Parameters.AddWithValue("@name", name);
                            cmdInsertUser.Parameters.AddWithValue("@role", role);

                            // CHANGED: Set email to DBNull.Value if null/empty, otherwise use the email
                            if (string.IsNullOrEmpty(email))
                                cmdInsertUser.Parameters.AddWithValue("@email", DBNull.Value);
                            else
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

                        int newPatientId = 0;

                        if (role == "Patient")
                        {
                            string phoneNumber = "";
                            if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && cmbPhoneType.SelectedItem != null)
                            {
                                phoneNumber = FormatPhoneNumberForStorage(txtPhoneNumber.Text.Trim(), cmbPhoneType.SelectedItem.ToString());
                            }

                            // Insert patient without blood_type - it will be added in PatientIntakeForm
                            string insertPatient = @"INSERT INTO Patients (user_id, allergies, phone_number, medical_history) 
                             VALUES (@userId, @allergies, @phoneNumber, '')";
                            using (MySqlCommand cmdInsertPatient = new MySqlCommand(insertPatient, conn, transaction))
                            {
                                cmdInsertPatient.Parameters.AddWithValue("@userId", newUserId);
                                cmdInsertPatient.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());
                                cmdInsertPatient.Parameters.AddWithValue("@phoneNumber", phoneNumber);
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

                            // CHANGED: Show "Not provided" instead of fake email
                            successMessage = $"✓ Patient record created successfully!\n\n" +
                                           $"Name: {name}\n" +
                                           $"Phone: {(string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ? "Not provided" : txtPhoneNumber.Text)}\n" +
                                           $"Email: {(string.IsNullOrEmpty(email) ? "Not provided" : email)}\n\n" +
                                           $"Patient is now registered in the system.";

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

                    string phoneNumber = "";
                    if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && cmbPhoneType.SelectedItem != null)
                    {
                        phoneNumber = FormatPhoneNumberForStorage(txtPhoneNumber.Text.Trim(), cmbPhoneType.SelectedItem.ToString());
                    }

                    if (count > 0)
                    {
                        string query = @"UPDATE Patients 
                                       SET allergies = @allergies, phone_number = @phoneNumber
                                       WHERE user_id = @userId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());
                            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string query = @"INSERT INTO Patients (user_id, allergies, phone_number)
                                       VALUES (@userId, @allergies, @phoneNumber)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@allergies", txtAllergies.Text.Trim());
                            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
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