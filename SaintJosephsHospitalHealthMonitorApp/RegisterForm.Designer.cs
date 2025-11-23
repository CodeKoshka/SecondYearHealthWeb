namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbSpecialization;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.CheckBox chkChangePassword;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelDoctorInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnRemovePhoto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            pictureBoxProfile = new PictureBox();
            btnUploadPhoto = new Button();
            btnRemovePhoto = new Button();
            lblName = new Label();
            txtName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            chkChangePassword = new CheckBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            chkShowPassword = new CheckBox();
            lblAge = new Label();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            panelDoctorInfo = new Panel();
            lblSpecialization = new Label();
            cmbSpecialization = new ComboBox();
            txtSpecialization = new TextBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            dtpDateOfBirth = new DateTimePicker();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            panelDoctorInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 102, 204);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(600, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New User";
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.FromArgb(245, 250, 255);
            pictureBoxProfile.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxProfile.Location = new Point(450, 100);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(120, 120);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 21;
            pictureBoxProfile.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.BackColor = Color.FromArgb(0, 102, 204);
            btnUploadPhoto.Cursor = Cursors.Hand;
            btnUploadPhoto.FlatAppearance.BorderSize = 0;
            btnUploadPhoto.FlatStyle = FlatStyle.Flat;
            btnUploadPhoto.Font = new Font("Segoe UI", 8F);
            btnUploadPhoto.ForeColor = Color.White;
            btnUploadPhoto.Location = new Point(450, 230);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new Size(120, 30);
            btnUploadPhoto.TabIndex = 22;
            btnUploadPhoto.Text = "📷 Upload Photo";
            btnUploadPhoto.UseVisualStyleBackColor = false;
            btnUploadPhoto.Click += BtnUploadPhoto_Click;
            // 
            // btnRemovePhoto
            // 
            btnRemovePhoto.BackColor = Color.FromArgb(220, 53, 69);
            btnRemovePhoto.Cursor = Cursors.Hand;
            btnRemovePhoto.FlatAppearance.BorderSize = 0;
            btnRemovePhoto.FlatStyle = FlatStyle.Flat;
            btnRemovePhoto.Font = new Font("Segoe UI", 8F);
            btnRemovePhoto.ForeColor = Color.White;
            btnRemovePhoto.Location = new Point(450, 265);
            btnRemovePhoto.Name = "btnRemovePhoto";
            btnRemovePhoto.Size = new Size(120, 25);
            btnRemovePhoto.TabIndex = 23;
            btnRemovePhoto.Text = "❌ Remove";
            btnRemovePhoto.UseVisualStyleBackColor = false;
            btnRemovePhoto.Visible = false;
            btnRemovePhoto.Click += BtnRemovePhoto_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(64, 64, 64);
            lblName.Location = new Point(30, 100);
            lblName.Name = "lblName";
            lblName.Size = new Size(86, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Full Name *";
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(30, 125);
            txtName.Name = "txtName";
            txtName.Size = new Size(400, 25);
            txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(64, 64, 64);
            lblEmail.Location = new Point(30, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(113, 19);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email Address *";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(30, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 25);
            txtEmail.TabIndex = 4;
            // 
            // chkChangePassword
            // 
            chkChangePassword.AutoSize = true;
            chkChangePassword.Cursor = Cursors.Hand;
            chkChangePassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkChangePassword.ForeColor = Color.FromArgb(0, 102, 204);
            chkChangePassword.Location = new Point(30, 230);
            chkChangePassword.Name = "chkChangePassword";
            chkChangePassword.Size = new Size(170, 23);
            chkChangePassword.TabIndex = 5;
            chkChangePassword.Text = "✏️ Change Password";
            chkChangePassword.UseVisualStyleBackColor = true;
            chkChangePassword.Visible = false;
            chkChangePassword.CheckedChanged += ChkChangePassword_CheckedChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblPassword.Location = new Point(30, 265);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(83, 19);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password *";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(30, 290);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(540, 25);
            txtPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(64, 64, 64);
            lblConfirmPassword.Location = new Point(30, 325);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(141, 19);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm Password *";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.White;
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(30, 350);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '•';
            txtConfirmPassword.Size = new Size(540, 25);
            txtConfirmPassword.TabIndex = 9;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = Cursors.Hand;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(108, 117, 125);
            chkShowPassword.Location = new Point(30, 385);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(108, 19);
            chkShowPassword.TabIndex = 10;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAge.ForeColor = Color.FromArgb(64, 64, 64);
            lblAge.Location = new Point(30, 420);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(104, 19);
            lblAge.TabIndex = 11;
            lblAge.Text = "Date of Birth *";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(64, 64, 64);
            lblGender.Location = new Point(244, 420);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 19);
            lblGender.TabIndex = 13;
            lblGender.Text = "Gender *";
            // 
            // cmbGender
            // 
            cmbGender.BackColor = Color.White;
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FlatStyle = FlatStyle.Flat;
            cmbGender.Font = new Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cmbGender.SelectedIndex = 0;
            cmbGender.Location = new Point(244, 445);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(153, 25);
            cmbGender.TabIndex = 14;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(64, 64, 64);
            lblRole.Location = new Point(403, 420);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(49, 19);
            lblRole.TabIndex = 15;
            lblRole.Text = "Role *";
            // 
            // cmbRole
            // 
            cmbRole.BackColor = Color.White;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(403, 445);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(167, 25);
            cmbRole.TabIndex = 16;
            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // panelDoctorInfo
            // 
            panelDoctorInfo.BackColor = Color.FromArgb(245, 250, 255);
            panelDoctorInfo.BorderStyle = BorderStyle.FixedSingle;
            panelDoctorInfo.Controls.Add(lblSpecialization);
            panelDoctorInfo.Controls.Add(cmbSpecialization);
            panelDoctorInfo.Controls.Add(txtSpecialization);
            panelDoctorInfo.Location = new Point(30, 490);
            panelDoctorInfo.Name = "panelDoctorInfo";
            panelDoctorInfo.Size = new Size(540, 120);
            panelDoctorInfo.TabIndex = 18;
            panelDoctorInfo.Visible = false;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSpecialization.ForeColor = Color.FromArgb(64, 64, 64);
            lblSpecialization.Location = new Point(15, 15);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(91, 15);
            lblSpecialization.TabIndex = 0;
            lblSpecialization.Text = "Specialization *";
            // 
            // cmbSpecialization
            // 
            cmbSpecialization.BackColor = Color.White;
            cmbSpecialization.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSpecialization.FlatStyle = FlatStyle.Flat;
            cmbSpecialization.Font = new Font("Segoe UI", 9F);
            cmbSpecialization.FormattingEnabled = true;
            cmbSpecialization.Location = new Point(15, 35);
            cmbSpecialization.Name = "cmbSpecialization";
            cmbSpecialization.Size = new Size(505, 23);
            cmbSpecialization.TabIndex = 1;
            cmbSpecialization.SelectedIndexChanged += CmbSpecialization_SelectedIndexChanged;
            // 
            // txtSpecialization
            // 
            txtSpecialization.BackColor = Color.White;
            txtSpecialization.BorderStyle = BorderStyle.FixedSingle;
            txtSpecialization.Font = new Font("Segoe UI", 9F);
            txtSpecialization.Location = new Point(15, 70);
            txtSpecialization.Multiline = true;
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.PlaceholderText = "Please specify the specialization...";
            txtSpecialization.Size = new Size(505, 35);
            txtSpecialization.TabIndex = 2;
            txtSpecialization.Visible = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(0, 102, 204);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(30, 630);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(260, 45);
            btnSubmit.TabIndex = 19;
            btnSubmit.Text = "✔️ Register";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(310, 630);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(260, 45);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "❌ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.Location = new Point(30, 445);
            dtpDateOfBirth.MaxDate = new DateTime(2025, 11, 17, 0, 0, 0, 0);
            dtpDateOfBirth.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(208, 23);
            dtpDateOfBirth.TabIndex = 12;
            dtpDateOfBirth.Value = new DateTime(1995, 11, 17, 0, 0, 0, 0);
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 250);
            ClientSize = new Size(600, 700);
            Controls.Add(dtpDateOfBirth);
            Controls.Add(btnRemovePhoto);
            Controls.Add(btnUploadPhoto);
            Controls.Add(pictureBoxProfile);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(panelDoctorInfo);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(cmbGender);
            Controls.Add(lblGender);
            Controls.Add(lblAge);
            Controls.Add(chkShowPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(chkChangePassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new Size(616, 739);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Management - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelDoctorInfo.ResumeLayout(false);
            panelDoctorInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private DateTimePicker dtpDateOfBirth;
    }
}