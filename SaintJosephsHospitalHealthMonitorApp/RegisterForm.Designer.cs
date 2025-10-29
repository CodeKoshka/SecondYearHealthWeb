namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtBloodType;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.CheckBox chkChangePassword;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelPatientInfo;
        private System.Windows.Forms.Panel panelDoctorInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblAllergies;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button btnUploadPhoto;
        private System.Windows.Forms.Button btnRemovePhoto;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            pictureBoxProfile = new System.Windows.Forms.PictureBox();
            btnUploadPhoto = new System.Windows.Forms.Button();
            btnRemovePhoto = new System.Windows.Forms.Button();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            chkChangePassword = new System.Windows.Forms.CheckBox();
            lblPassword = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            chkShowPassword = new System.Windows.Forms.CheckBox();
            lblAge = new System.Windows.Forms.Label();
            txtAge = new System.Windows.Forms.TextBox();
            lblGender = new System.Windows.Forms.Label();
            cmbGender = new System.Windows.Forms.ComboBox();
            lblRole = new System.Windows.Forms.Label();
            cmbRole = new System.Windows.Forms.ComboBox();
            panelPatientInfo = new System.Windows.Forms.Panel();
            lblBloodType = new System.Windows.Forms.Label();
            txtBloodType = new System.Windows.Forms.TextBox();
            lblAllergies = new System.Windows.Forms.Label();
            txtAllergies = new System.Windows.Forms.TextBox();
            panelDoctorInfo = new System.Windows.Forms.Panel();
            lblSpecialization = new System.Windows.Forms.Label();
            txtSpecialization = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            panelPatientInfo.SuspendLayout();
            panelDoctorInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(600, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(230, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New User";
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            pictureBoxProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBoxProfile.Location = new System.Drawing.Point(450, 100);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new System.Drawing.Size(120, 120);
            pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 21;
            pictureBoxProfile.TabStop = false;
            // 
            // btnUploadPhoto
            // 
            btnUploadPhoto.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            btnUploadPhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnUploadPhoto.FlatAppearance.BorderSize = 0;
            btnUploadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUploadPhoto.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            btnUploadPhoto.ForeColor = System.Drawing.Color.White;
            btnUploadPhoto.Location = new System.Drawing.Point(450, 230);
            btnUploadPhoto.Name = "btnUploadPhoto";
            btnUploadPhoto.Size = new System.Drawing.Size(120, 30);
            btnUploadPhoto.TabIndex = 22;
            btnUploadPhoto.Text = "📷 Upload Photo";
            btnUploadPhoto.UseVisualStyleBackColor = false;
            btnUploadPhoto.Click += BtnUploadPhoto_Click;
            // 
            // btnRemovePhoto
            // 
            btnRemovePhoto.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnRemovePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRemovePhoto.FlatAppearance.BorderSize = 0;
            btnRemovePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRemovePhoto.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            btnRemovePhoto.ForeColor = System.Drawing.Color.White;
            btnRemovePhoto.Location = new System.Drawing.Point(450, 265);
            btnRemovePhoto.Name = "btnRemovePhoto";
            btnRemovePhoto.Size = new System.Drawing.Size(120, 25);
            btnRemovePhoto.TabIndex = 23;
            btnRemovePhoto.Text = "❌ Remove";
            btnRemovePhoto.UseVisualStyleBackColor = false;
            btnRemovePhoto.Visible = false;
            btnRemovePhoto.Click += BtnRemovePhoto_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblName.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblName.Location = new System.Drawing.Point(30, 100);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(83, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Full Name *";
            // 
            // txtName
            // 
            txtName.BackColor = System.Drawing.Color.White;
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtName.Location = new System.Drawing.Point(30, 125);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(400, 25);
            txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblEmail.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblEmail.Location = new System.Drawing.Point(30, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(116, 19);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email Address *";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = System.Drawing.Color.White;
            txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new System.Drawing.Point(30, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(400, 25);
            txtEmail.TabIndex = 4;
            // 
            // chkChangePassword
            // 
            chkChangePassword.AutoSize = true;
            chkChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            chkChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            chkChangePassword.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            chkChangePassword.Location = new System.Drawing.Point(30, 230);
            chkChangePassword.Name = "chkChangePassword";
            chkChangePassword.Size = new System.Drawing.Size(151, 23);
            chkChangePassword.TabIndex = 5;
            chkChangePassword.Text = "✏️ Change Password";
            chkChangePassword.UseVisualStyleBackColor = true;
            chkChangePassword.Visible = false;
            chkChangePassword.CheckedChanged += ChkChangePassword_CheckedChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblPassword.Location = new System.Drawing.Point(30, 265);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(80, 19);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password *";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = System.Drawing.Color.White;
            txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new System.Drawing.Point(30, 290);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new System.Drawing.Size(540, 25);
            txtPassword.TabIndex = 7;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblConfirmPassword.Location = new System.Drawing.Point(30, 330);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(146, 19);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm Password *";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = System.Drawing.Color.White;
            txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new System.Drawing.Point(30, 355);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '•';
            txtConfirmPassword.Size = new System.Drawing.Size(540, 25);
            txtConfirmPassword.TabIndex = 9;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(108, 117, 125);
            chkShowPassword.Location = new System.Drawing.Point(30, 390);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new System.Drawing.Size(114, 19);
            chkShowPassword.TabIndex = 10;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblAge.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblAge.Location = new System.Drawing.Point(30, 425);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(42, 19);
            lblAge.TabIndex = 11;
            lblAge.Text = "Age *";
            // 
            // txtAge
            // 
            txtAge.BackColor = System.Drawing.Color.White;
            txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtAge.Location = new System.Drawing.Point(30, 450);
            txtAge.Name = "txtAge";
            txtAge.Size = new System.Drawing.Size(120, 25);
            txtAge.TabIndex = 12;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblGender.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblGender.Location = new System.Drawing.Point(170, 425);
            lblGender.Name = "lblGender";
            lblGender.Size = new System.Drawing.Size(68, 19);
            lblGender.TabIndex = 13;
            lblGender.Text = "Gender *";
            // 
            // cmbGender
            // 
            cmbGender.BackColor = System.Drawing.Color.White;
            cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cmbGender.Location = new System.Drawing.Point(170, 450);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new System.Drawing.Size(180, 25);
            cmbGender.TabIndex = 14;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblRole.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblRole.Location = new System.Drawing.Point(370, 425);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(47, 19);
            lblRole.TabIndex = 15;
            lblRole.Text = "Role *";
            // 
            // cmbRole
            // 
            cmbRole.BackColor = System.Drawing.Color.White;
            cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new System.Drawing.Point(370, 450);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new System.Drawing.Size(200, 25);
            cmbRole.TabIndex = 16;
            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // panelPatientInfo
            // 
            panelPatientInfo.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            panelPatientInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelPatientInfo.Controls.Add(lblBloodType);
            panelPatientInfo.Controls.Add(txtBloodType);
            panelPatientInfo.Controls.Add(lblAllergies);
            panelPatientInfo.Controls.Add(txtAllergies);
            panelPatientInfo.Location = new System.Drawing.Point(30, 495);
            panelPatientInfo.Name = "panelPatientInfo";
            panelPatientInfo.Size = new System.Drawing.Size(540, 130);
            panelPatientInfo.TabIndex = 17;
            panelPatientInfo.Visible = false;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblBloodType.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblBloodType.Location = new System.Drawing.Point(15, 15);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new System.Drawing.Size(70, 15);
            lblBloodType.TabIndex = 0;
            lblBloodType.Text = "Blood Type";
            // 
            // txtBloodType
            // 
            txtBloodType.BackColor = System.Drawing.Color.White;
            txtBloodType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBloodType.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBloodType.Location = new System.Drawing.Point(15, 35);
            txtBloodType.Name = "txtBloodType";
            txtBloodType.Size = new System.Drawing.Size(120, 23);
            txtBloodType.TabIndex = 1;
            // 
            // lblAllergies
            // 
            lblAllergies.AutoSize = true;
            lblAllergies.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblAllergies.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblAllergies.Location = new System.Drawing.Point(15, 70);
            lblAllergies.Name = "lblAllergies";
            lblAllergies.Size = new System.Drawing.Size(56, 15);
            lblAllergies.TabIndex = 2;
            lblAllergies.Text = "Allergies";
            // 
            // txtAllergies
            // 
            txtAllergies.BackColor = System.Drawing.Color.White;
            txtAllergies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAllergies.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtAllergies.Location = new System.Drawing.Point(15, 90);
            txtAllergies.Name = "txtAllergies";
            txtAllergies.Size = new System.Drawing.Size(505, 23);
            txtAllergies.TabIndex = 3;
            // 
            // panelDoctorInfo
            // 
            panelDoctorInfo.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            panelDoctorInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDoctorInfo.Controls.Add(lblSpecialization);
            panelDoctorInfo.Controls.Add(txtSpecialization);
            panelDoctorInfo.Location = new System.Drawing.Point(30, 495);
            panelDoctorInfo.Name = "panelDoctorInfo";
            panelDoctorInfo.Size = new System.Drawing.Size(540, 80);
            panelDoctorInfo.TabIndex = 18;
            panelDoctorInfo.Visible = false;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSpecialization.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblSpecialization.Location = new System.Drawing.Point(15, 15);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new System.Drawing.Size(90, 15);
            lblSpecialization.TabIndex = 0;
            lblSpecialization.Text = "Specialization *";
            // 
            // txtSpecialization
            // 
            txtSpecialization.BackColor = System.Drawing.Color.White;
            txtSpecialization.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSpecialization.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSpecialization.Location = new System.Drawing.Point(15, 35);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new System.Drawing.Size(505, 23);
            txtSpecialization.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(30, 645);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(260, 45);
            btnSubmit.TabIndex = 19;
            btnSubmit.Text = "✔️ Register";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(310, 645);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(260, 45);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "❌ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            ClientSize = new System.Drawing.Size(600, 720);
            Controls.Add(btnRemovePhoto);
            Controls.Add(btnUploadPhoto);
            Controls.Add(pictureBoxProfile);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(panelDoctorInfo);
            Controls.Add(panelPatientInfo);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(cmbGender);
            Controls.Add(lblGender);
            Controls.Add(txtAge);
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
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimumSize = new System.Drawing.Size(616, 759);
            Name = "RegisterForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "User Management - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelPatientInfo.ResumeLayout(false);
            panelPatientInfo.PerformLayout();
            panelDoctorInfo.ResumeLayout(false);
            panelDoctorInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}