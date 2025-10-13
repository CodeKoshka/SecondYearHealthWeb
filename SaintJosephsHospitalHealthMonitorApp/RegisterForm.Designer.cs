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
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtBloodType;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelPatientInfo;
        private System.Windows.Forms.Panel panelDoctorInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
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
            panelHeader = new Panel();
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            panelPatientInfo = new Panel();
            lblBloodType = new Label();
            txtBloodType = new TextBox();
            lblAllergies = new Label();
            txtAllergies = new TextBox();
            panelDoctorInfo = new Panel();
            lblSpecialization = new Label();
            txtSpecialization = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            panelPatientInfo.SuspendLayout();
            panelDoctorInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 3, 4, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(583, 92);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(176, 34);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New User";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F);
            lblName.Location = new Point(35, 115);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Full Name:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(35, 144);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(489, 25);
            txtName.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F);
            lblEmail.Location = new Point(35, 196);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(44, 19);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(35, 225);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(489, 25);
            txtEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(35, 277);
            lblPassword.Margin = new Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 19);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(35, 306);
            txtPassword.Margin = new Padding(4, 3, 4, 3);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(489, 25);
            txtPassword.TabIndex = 6;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 10F);
            lblAge.Location = new Point(35, 358);
            lblAge.Margin = new Padding(4, 0, 4, 0);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(36, 19);
            lblAge.TabIndex = 7;
            lblAge.Text = "Age:";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 10F);
            txtAge.Location = new Point(35, 387);
            txtAge.Margin = new Padding(4, 3, 4, 3);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(116, 25);
            txtAge.TabIndex = 8;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 10F);
            lblGender.Location = new Point(187, 358);
            lblGender.Margin = new Padding(4, 0, 4, 0);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(57, 19);
            lblGender.TabIndex = 9;
            lblGender.Text = "Gender:";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 10F);
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cmbGender.Location = new Point(187, 387);
            cmbGender.Margin = new Padding(4, 3, 4, 3);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(139, 25);
            cmbGender.TabIndex = 10;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F);
            lblRole.Location = new Point(35, 438);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(78, 19);
            lblRole.TabIndex = 11;
            lblRole.Text = "Register as:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Patient", "Doctor" });
            cmbRole.Location = new Point(35, 467);
            cmbRole.Margin = new Padding(4, 3, 4, 3);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(233, 25);
            cmbRole.TabIndex = 12;
            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // panelPatientInfo
            // 
            panelPatientInfo.BorderStyle = BorderStyle.FixedSingle;
            panelPatientInfo.Controls.Add(lblBloodType);
            panelPatientInfo.Controls.Add(txtBloodType);
            panelPatientInfo.Controls.Add(lblAllergies);
            panelPatientInfo.Controls.Add(txtAllergies);
            panelPatientInfo.Location = new Point(35, 519);
            panelPatientInfo.Margin = new Padding(4, 3, 4, 3);
            panelPatientInfo.Name = "panelPatientInfo";
            panelPatientInfo.Size = new Size(490, 115);
            panelPatientInfo.TabIndex = 13;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new Font("Segoe UI", 9F);
            lblBloodType.Location = new Point(12, 12);
            lblBloodType.Margin = new Padding(4, 0, 4, 0);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new Size(69, 15);
            lblBloodType.TabIndex = 0;
            lblBloodType.Text = "Blood Type:";
            // 
            // txtBloodType
            // 
            txtBloodType.Font = new Font("Segoe UI", 9F);
            txtBloodType.Location = new Point(12, 40);
            txtBloodType.Margin = new Padding(4, 3, 4, 3);
            txtBloodType.Name = "txtBloodType";
            txtBloodType.Size = new Size(116, 23);
            txtBloodType.TabIndex = 1;
            // 
            // lblAllergies
            // 
            lblAllergies.AutoSize = true;
            lblAllergies.Font = new Font("Segoe UI", 9F);
            lblAllergies.Location = new Point(152, 12);
            lblAllergies.Margin = new Padding(4, 0, 4, 0);
            lblAllergies.Name = "lblAllergies";
            lblAllergies.Size = new Size(55, 15);
            lblAllergies.TabIndex = 2;
            lblAllergies.Text = "Allergies:";
            // 
            // txtAllergies
            // 
            txtAllergies.Font = new Font("Segoe UI", 9F);
            txtAllergies.Location = new Point(152, 40);
            txtAllergies.Margin = new Padding(4, 3, 4, 3);
            txtAllergies.Name = "txtAllergies";
            txtAllergies.Size = new Size(314, 23);
            txtAllergies.TabIndex = 3;
            // 
            // panelDoctorInfo
            // 
            panelDoctorInfo.BorderStyle = BorderStyle.FixedSingle;
            panelDoctorInfo.Controls.Add(lblSpecialization);
            panelDoctorInfo.Controls.Add(txtSpecialization);
            panelDoctorInfo.Location = new Point(35, 519);
            panelDoctorInfo.Margin = new Padding(4, 3, 4, 3);
            panelDoctorInfo.Name = "panelDoctorInfo";
            panelDoctorInfo.Size = new Size(490, 115);
            panelDoctorInfo.TabIndex = 14;
            panelDoctorInfo.Visible = false;
            // 
            // lblSpecialization
            // 
            lblSpecialization.AutoSize = true;
            lblSpecialization.Font = new Font("Segoe UI", 9F);
            lblSpecialization.Location = new Point(12, 12);
            lblSpecialization.Margin = new Padding(4, 0, 4, 0);
            lblSpecialization.Name = "lblSpecialization";
            lblSpecialization.Size = new Size(82, 15);
            lblSpecialization.TabIndex = 0;
            lblSpecialization.Text = "Specialization:";
            // 
            // txtSpecialization
            // 
            txtSpecialization.Font = new Font("Segoe UI", 9F);
            txtSpecialization.Location = new Point(12, 40);
            txtSpecialization.Margin = new Padding(4, 3, 4, 3);
            txtSpecialization.Name = "txtSpecialization";
            txtSpecialization.Size = new Size(454, 23);
            txtSpecialization.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(46, 204, 113);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(35, 658);
            btnRegister.Margin = new Padding(4, 3, 4, 3);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(233, 46);
            btnRegister.TabIndex = 15;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(292, 658);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(233, 46);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 248);
            ClientSize = new Size(565, 763);
            Controls.Add(btnCancel);
            Controls.Add(btnRegister);
            Controls.Add(panelDoctorInfo);
            Controls.Add(panelPatientInfo);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(cmbGender);
            Controls.Add(lblGender);
            Controls.Add(txtAge);
            Controls.Add(lblAge);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register New User";
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