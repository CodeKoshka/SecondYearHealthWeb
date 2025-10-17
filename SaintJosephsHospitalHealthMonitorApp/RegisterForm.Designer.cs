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
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
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
            panelPatientInfo.SuspendLayout();
            panelDoctorInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(583, 92);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(176, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(204, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New User";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblName.Location = new System.Drawing.Point(35, 115);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(73, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Full Name:";
            // 
            // txtName
            // 
            txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtName.Location = new System.Drawing.Point(35, 144);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(489, 25);
            txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblEmail.Location = new System.Drawing.Point(35, 186);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(44, 19);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEmail.Location = new System.Drawing.Point(35, 215);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(489, 25);
            txtEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPassword.Location = new System.Drawing.Point(35, 257);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(70, 19);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPassword.Location = new System.Drawing.Point(35, 286);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new System.Drawing.Size(489, 25);
            txtPassword.TabIndex = 6;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblConfirmPassword.Location = new System.Drawing.Point(35, 328);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(127, 19);
            lblConfirmPassword.TabIndex = 7;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new System.Drawing.Point(35, 357);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '•';
            txtConfirmPassword.Size = new System.Drawing.Size(489, 25);
            txtConfirmPassword.TabIndex = 8;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkShowPassword.Location = new System.Drawing.Point(35, 395);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new System.Drawing.Size(108, 19);
            chkShowPassword.TabIndex = 9;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblAge.Location = new System.Drawing.Point(35, 430);
            lblAge.Name = "lblAge";
            lblAge.Size = new System.Drawing.Size(36, 19);
            lblAge.TabIndex = 10;
            lblAge.Text = "Age:";
            // 
            // txtAge
            // 
            txtAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtAge.Location = new System.Drawing.Point(35, 459);
            txtAge.Name = "txtAge";
            txtAge.Size = new System.Drawing.Size(116, 25);
            txtAge.TabIndex = 11;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblGender.Location = new System.Drawing.Point(187, 430);
            lblGender.Name = "lblGender";
            lblGender.Size = new System.Drawing.Size(57, 19);
            lblGender.TabIndex = 12;
            lblGender.Text = "Gender:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cmbGender.Location = new System.Drawing.Point(187, 459);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new System.Drawing.Size(139, 25);
            cmbGender.TabIndex = 13;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblRole.Location = new System.Drawing.Point(35, 500);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(78, 19);
            lblRole.TabIndex = 14;
            lblRole.Text = "Register as:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new System.Drawing.Point(35, 529);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new System.Drawing.Size(233, 25);
            cmbRole.TabIndex = 15;
            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // panelPatientInfo
            // 
            panelPatientInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelPatientInfo.Controls.Add(lblBloodType);
            panelPatientInfo.Controls.Add(txtBloodType);
            panelPatientInfo.Controls.Add(lblAllergies);
            panelPatientInfo.Controls.Add(txtAllergies);
            panelPatientInfo.Location = new System.Drawing.Point(35, 571);
            panelPatientInfo.Name = "panelPatientInfo";
            panelPatientInfo.Size = new System.Drawing.Size(490, 115);
            panelPatientInfo.TabIndex = 16;
            panelPatientInfo.Visible = false;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblBloodType.Location = new System.Drawing.Point(12, 12);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new System.Drawing.Size(69, 15);
            lblBloodType.TabIndex = 0;
            lblBloodType.Text = "Blood Type:";
            // 
            // txtBloodType
            // 
            txtBloodType.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBloodType.Location = new System.Drawing.Point(12, 40);
            txtBloodType.Name = "txtBloodType";
            txtBloodType.Size = new System.Drawing.Size(116, 23);
            txtBloodType.TabIndex = 1;
            // 
            // lblAllergies
            // 
            lblAllergies.AutoSize = true;
            lblAllergies.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblAllergies.Location = new System.Drawing.Point(152, 12);
            lblAllergies.Name = "lblAllergies";
            lblAllergies.Size = new System.Drawing.Size(55, 15);
            lblAllergies.TabIndex = 2;
            lblAllergies.Text = "Allergies:";
            // 
            // txtAllergies
            // 
            txtAllergies.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtAllergies.Location = new System.Drawing.Point(152, 40);
            txtAllergies.Multiline = true;
            txtAllergies.Name = "txtAllergies";
            txtAllergies.Size = new System.Drawing.Size(314, 60);
            txtAllergies.TabIndex = 3;
            // 
            // panelDoctorInfo
            // 
            panelDoctorInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelDoctorInfo.Controls.Add(lblSpecialization);
            panelDoctorInfo.Controls.Add(txtSpecialization);
            panelDoctorInfo.Location = new System.Drawing.Point(35, 571);
            panelDoctorInfo.Name = "panelDoctorInfo";
            panelDoctorInfo.Size = new System.Drawing.Size(490, 115);
            panelDoctorInfo.TabIndex = 17;
            panelDoctorInfo.Visible = false;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSpecialization.Location = new System.Drawing.Point(12, 12);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new System.Drawing.Size(82, 15);
            lblSpecialization.TabIndex = 0;
            lblSpecialization.Text = "Specialization:";
            // 
            // txtSpecialization
            // 
            txtSpecialization.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSpecialization.Location = new System.Drawing.Point(12, 40);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new System.Drawing.Size(454, 23);
            txtSpecialization.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(35, 710);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(233, 46);
            btnSubmit.TabIndex = 18;
            btnSubmit.Text = "Register";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(292, 710);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(233, 46);
            btnCancel.TabIndex = 19;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            ClientSize = new System.Drawing.Size(565, 800);
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
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "User Management";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelPatientInfo.ResumeLayout(false);
            panelPatientInfo.PerformLayout();
            panelDoctorInfo.ResumeLayout(false);
            panelDoctorInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
