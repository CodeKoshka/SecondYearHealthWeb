namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class DebugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabDashboard = new TabPage();
            lblDashboardNote = new Label();
            chkPharmacist = new CheckBox();
            chkDoctor = new CheckBox();
            chkReceptionist = new CheckBox();
            chkAdmin = new CheckBox();
            lblDashboardTitle = new Label();
            tabRoleCreation = new TabPage();
            lblRoleCreationNote = new Label();
            lblAllowPatientDetails = new Label();
            chkAllowPatient = new CheckBox();
            lblAllowPharmacistDetails = new Label();
            chkAllowPharmacist = new CheckBox();
            lblAllowDoctorDetails = new Label();
            chkAllowDoctor = new CheckBox();
            lblAllowReceptionistDetails = new Label();
            chkAllowReceptionist = new CheckBox();
            lblAllowAdminDetails = new Label();
            chkAllowAdmin = new CheckBox();
            lblRoleCreationInfo = new Label();
            lblRoleCreationTitle = new Label();
            tabDefaultUsers = new TabPage();
            lblDefaultUsersWarning = new Label();
            lblPatientDetails = new Label();
            chkCreatePatient = new CheckBox();
            lblDoctorDetails = new Label();
            chkCreateDoctor = new CheckBox();
            lblPharmacistDetails = new Label();
            chkCreatePharmacist = new CheckBox();
            lblReceptionistDetails = new Label();
            chkCreateReceptionist = new CheckBox();
            lblAdminDetails = new Label();
            chkCreateAdmin = new CheckBox();
            lblHeadadminDetails = new Label();
            lblHeadadminTitle = new Label();
            lblDefaultUsersInfo = new Label();
            lblDefaultUsersTitle = new Label();
            btnSave = new Button();
            btnReset = new Button();
            btnClose = new Button();
            tabControl.SuspendLayout();
            tabDashboard.SuspendLayout();
            tabRoleCreation.SuspendLayout();
            tabDefaultUsers.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabDashboard);
            tabControl.Controls.Add(tabRoleCreation);
            tabControl.Controls.Add(tabDefaultUsers);
            tabControl.Font = new Font("Segoe UI", 9F);
            tabControl.Location = new Point(10, 10);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(470, 450);
            tabControl.TabIndex = 0;
            // 
            // tabDashboard
            // 
            tabDashboard.BackColor = Color.FromArgb(247, 250, 252);
            tabDashboard.Controls.Add(lblDashboardNote);
            tabDashboard.Controls.Add(chkPharmacist);
            tabDashboard.Controls.Add(chkDoctor);
            tabDashboard.Controls.Add(chkReceptionist);
            tabDashboard.Controls.Add(chkAdmin);
            tabDashboard.Controls.Add(lblDashboardTitle);
            tabDashboard.Location = new Point(4, 24);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Padding = new Padding(3);
            tabDashboard.Size = new Size(462, 422);
            tabDashboard.TabIndex = 0;
            tabDashboard.Text = "Dashboard Access";
            // 
            // lblDashboardNote
            // 
            lblDashboardNote.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDashboardNote.ForeColor = Color.FromArgb(113, 128, 150);
            lblDashboardNote.Location = new Point(20, 215);
            lblDashboardNote.Name = "lblDashboardNote";
            lblDashboardNote.Size = new Size(420, 40);
            lblDashboardNote.TabIndex = 5;
            lblDashboardNote.Text = "Head Admin access is always enabled\r\nDisabling dashboard access will also disable role creation";
            // 
            // chkPharmacist
            // 
            chkPharmacist.Font = new Font("Segoe UI", 10F);
            chkPharmacist.ForeColor = Color.FromArgb(26, 32, 44);
            chkPharmacist.Location = new Point(20, 175);
            chkPharmacist.Name = "chkPharmacist";
            chkPharmacist.Size = new Size(420, 30);
            chkPharmacist.TabIndex = 4;
            chkPharmacist.Text = "Pharmacist Dashboard";
            chkPharmacist.UseVisualStyleBackColor = true;
            chkPharmacist.CheckedChanged += ChkDashboardRole_CheckedChanged;
            // 
            // chkDoctor
            // 
            chkDoctor.Font = new Font("Segoe UI", 10F);
            chkDoctor.ForeColor = Color.FromArgb(26, 32, 44);
            chkDoctor.Location = new Point(20, 135);
            chkDoctor.Name = "chkDoctor";
            chkDoctor.Size = new Size(420, 30);
            chkDoctor.TabIndex = 3;
            chkDoctor.Text = "Doctor Dashboard";
            chkDoctor.UseVisualStyleBackColor = true;
            chkDoctor.CheckedChanged += ChkDashboardRole_CheckedChanged;
            // 
            // chkReceptionist
            // 
            chkReceptionist.Font = new Font("Segoe UI", 10F);
            chkReceptionist.ForeColor = Color.FromArgb(26, 32, 44);
            chkReceptionist.Location = new Point(20, 95);
            chkReceptionist.Name = "chkReceptionist";
            chkReceptionist.Size = new Size(420, 30);
            chkReceptionist.TabIndex = 2;
            chkReceptionist.Text = "Receptionist Dashboard";
            chkReceptionist.UseVisualStyleBackColor = true;
            chkReceptionist.CheckedChanged += ChkDashboardRole_CheckedChanged;
            // 
            // chkAdmin
            // 
            chkAdmin.Font = new Font("Segoe UI", 10F);
            chkAdmin.ForeColor = Color.FromArgb(26, 32, 44);
            chkAdmin.Location = new Point(20, 55);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(420, 30);
            chkAdmin.TabIndex = 1;
            chkAdmin.Text = "Admin Dashboard";
            chkAdmin.UseVisualStyleBackColor = true;
            chkAdmin.CheckedChanged += ChkDashboardRole_CheckedChanged;
            // 
            // lblDashboardTitle
            // 
            lblDashboardTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDashboardTitle.ForeColor = Color.FromArgb(26, 32, 44);
            lblDashboardTitle.Location = new Point(15, 15);
            lblDashboardTitle.Name = "lblDashboardTitle";
            lblDashboardTitle.Size = new Size(430, 25);
            lblDashboardTitle.TabIndex = 0;
            lblDashboardTitle.Text = "Enable/Disable Dashboard Access";
            // 
            // tabRoleCreation
            // 
            tabRoleCreation.AutoScroll = true;
            tabRoleCreation.BackColor = Color.FromArgb(247, 250, 252);
            tabRoleCreation.Controls.Add(lblRoleCreationNote);
            tabRoleCreation.Controls.Add(lblAllowPatientDetails);
            tabRoleCreation.Controls.Add(chkAllowPatient);
            tabRoleCreation.Controls.Add(lblAllowPharmacistDetails);
            tabRoleCreation.Controls.Add(chkAllowPharmacist);
            tabRoleCreation.Controls.Add(lblAllowDoctorDetails);
            tabRoleCreation.Controls.Add(chkAllowDoctor);
            tabRoleCreation.Controls.Add(lblAllowReceptionistDetails);
            tabRoleCreation.Controls.Add(chkAllowReceptionist);
            tabRoleCreation.Controls.Add(lblAllowAdminDetails);
            tabRoleCreation.Controls.Add(chkAllowAdmin);
            tabRoleCreation.Controls.Add(lblRoleCreationInfo);
            tabRoleCreation.Controls.Add(lblRoleCreationTitle);
            tabRoleCreation.Location = new Point(4, 24);
            tabRoleCreation.Name = "tabRoleCreation";
            tabRoleCreation.Padding = new Padding(3);
            tabRoleCreation.Size = new Size(462, 422);
            tabRoleCreation.TabIndex = 2;
            tabRoleCreation.Text = "Role Creation";
            // 
            // lblRoleCreationNote
            // 
            lblRoleCreationNote.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoleCreationNote.ForeColor = Color.FromArgb(220, 53, 69);
            lblRoleCreationNote.Location = new Point(15, 315);
            lblRoleCreationNote.Name = "lblRoleCreationNote";
            lblRoleCreationNote.Size = new Size(420, 40);
            lblRoleCreationNote.TabIndex = 12;
            lblRoleCreationNote.Text = "⚠️ Head Admin can always be created by system\r\n⚠️ Disabled roles cannot be created by any user";
            // 
            // lblAllowPatientDetails
            // 
            lblAllowPatientDetails.Font = new Font("Segoe UI", 8F);
            lblAllowPatientDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblAllowPatientDetails.Location = new Point(40, 289);
            lblAllowPatientDetails.Name = "lblAllowPatientDetails";
            lblAllowPatientDetails.Size = new Size(400, 15);
            lblAllowPatientDetails.TabIndex = 11;
            lblAllowPatientDetails.Text = "Allow users to register/create patient records";
            // 
            // chkAllowPatient
            // 
            chkAllowPatient.Font = new Font("Segoe UI", 10F);
            chkAllowPatient.ForeColor = Color.FromArgb(26, 32, 44);
            chkAllowPatient.Location = new Point(20, 259);
            chkAllowPatient.Name = "chkAllowPatient";
            chkAllowPatient.Size = new Size(420, 30);
            chkAllowPatient.TabIndex = 10;
            chkAllowPatient.Text = "Allow Patient Creation";
            chkAllowPatient.UseVisualStyleBackColor = true;
            // 
            // lblAllowPharmacistDetails
            // 
            lblAllowPharmacistDetails.Font = new Font("Segoe UI", 8F);
            lblAllowPharmacistDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblAllowPharmacistDetails.Location = new Point(40, 193);
            lblAllowPharmacistDetails.Name = "lblAllowPharmacistDetails";
            lblAllowPharmacistDetails.Size = new Size(400, 15);
            lblAllowPharmacistDetails.TabIndex = 9;
            lblAllowPharmacistDetails.Text = "Allow creation of pharmacist accounts";
            // 
            // chkAllowPharmacist
            // 
            chkAllowPharmacist.Font = new Font("Segoe UI", 10F);
            chkAllowPharmacist.ForeColor = Color.FromArgb(26, 32, 44);
            chkAllowPharmacist.Location = new Point(20, 163);
            chkAllowPharmacist.Name = "chkAllowPharmacist";
            chkAllowPharmacist.Size = new Size(420, 30);
            chkAllowPharmacist.TabIndex = 8;
            chkAllowPharmacist.Text = "Allow Pharmacist Creation";
            chkAllowPharmacist.UseVisualStyleBackColor = true;
            // 
            // lblAllowDoctorDetails
            // 
            lblAllowDoctorDetails.Font = new Font("Segoe UI", 8F);
            lblAllowDoctorDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblAllowDoctorDetails.Location = new Point(40, 241);
            lblAllowDoctorDetails.Name = "lblAllowDoctorDetails";
            lblAllowDoctorDetails.Size = new Size(400, 15);
            lblAllowDoctorDetails.TabIndex = 7;
            lblAllowDoctorDetails.Text = "Allow creation of doctor accounts";
            // 
            // chkAllowDoctor
            // 
            chkAllowDoctor.Font = new Font("Segoe UI", 10F);
            chkAllowDoctor.ForeColor = Color.FromArgb(26, 32, 44);
            chkAllowDoctor.Location = new Point(20, 211);
            chkAllowDoctor.Name = "chkAllowDoctor";
            chkAllowDoctor.Size = new Size(420, 30);
            chkAllowDoctor.TabIndex = 6;
            chkAllowDoctor.Text = "Allow Doctor Creation";
            chkAllowDoctor.UseVisualStyleBackColor = true;
            // 
            // lblAllowReceptionistDetails
            // 
            lblAllowReceptionistDetails.Font = new Font("Segoe UI", 8F);
            lblAllowReceptionistDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblAllowReceptionistDetails.Location = new Point(40, 145);
            lblAllowReceptionistDetails.Name = "lblAllowReceptionistDetails";
            lblAllowReceptionistDetails.Size = new Size(400, 15);
            lblAllowReceptionistDetails.TabIndex = 5;
            lblAllowReceptionistDetails.Text = "Allow creation of receptionist accounts";
            // 
            // chkAllowReceptionist
            // 
            chkAllowReceptionist.Font = new Font("Segoe UI", 10F);
            chkAllowReceptionist.ForeColor = Color.FromArgb(26, 32, 44);
            chkAllowReceptionist.Location = new Point(20, 115);
            chkAllowReceptionist.Name = "chkAllowReceptionist";
            chkAllowReceptionist.Size = new Size(420, 30);
            chkAllowReceptionist.TabIndex = 4;
            chkAllowReceptionist.Text = "Allow Receptionist Creation";
            chkAllowReceptionist.UseVisualStyleBackColor = true;
            // 
            // lblAllowAdminDetails
            // 
            lblAllowAdminDetails.Font = new Font("Segoe UI", 8F);
            lblAllowAdminDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblAllowAdminDetails.Location = new Point(40, 97);
            lblAllowAdminDetails.Name = "lblAllowAdminDetails";
            lblAllowAdminDetails.Size = new Size(400, 15);
            lblAllowAdminDetails.TabIndex = 3;
            lblAllowAdminDetails.Text = "Allow creation of admin accounts";
            // 
            // chkAllowAdmin
            // 
            chkAllowAdmin.Font = new Font("Segoe UI", 10F);
            chkAllowAdmin.ForeColor = Color.FromArgb(26, 32, 44);
            chkAllowAdmin.Location = new Point(20, 67);
            chkAllowAdmin.Name = "chkAllowAdmin";
            chkAllowAdmin.Size = new Size(420, 30);
            chkAllowAdmin.TabIndex = 2;
            chkAllowAdmin.Text = "Allow Admin Creation";
            chkAllowAdmin.UseVisualStyleBackColor = true;
            // 
            // lblRoleCreationInfo
            // 
            lblRoleCreationInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblRoleCreationInfo.ForeColor = Color.FromArgb(113, 128, 150);
            lblRoleCreationInfo.Location = new Point(15, 45);
            lblRoleCreationInfo.Name = "lblRoleCreationInfo";
            lblRoleCreationInfo.Size = new Size(430, 20);
            lblRoleCreationInfo.TabIndex = 1;
            lblRoleCreationInfo.Text = "Control which user roles can be created through the user management system";
            // 
            // lblRoleCreationTitle
            // 
            lblRoleCreationTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRoleCreationTitle.ForeColor = Color.FromArgb(26, 32, 44);
            lblRoleCreationTitle.Location = new Point(15, 15);
            lblRoleCreationTitle.Name = "lblRoleCreationTitle";
            lblRoleCreationTitle.Size = new Size(430, 25);
            lblRoleCreationTitle.TabIndex = 0;
            lblRoleCreationTitle.Text = "Role Creation Permissions";
            // 
            // tabDefaultUsers
            // 
            tabDefaultUsers.AutoScroll = true;
            tabDefaultUsers.BackColor = Color.FromArgb(247, 250, 252);
            tabDefaultUsers.Controls.Add(lblDefaultUsersWarning);
            tabDefaultUsers.Controls.Add(lblPatientDetails);
            tabDefaultUsers.Controls.Add(chkCreatePatient);
            tabDefaultUsers.Controls.Add(lblDoctorDetails);
            tabDefaultUsers.Controls.Add(chkCreateDoctor);
            tabDefaultUsers.Controls.Add(lblPharmacistDetails);
            tabDefaultUsers.Controls.Add(chkCreatePharmacist);
            tabDefaultUsers.Controls.Add(lblReceptionistDetails);
            tabDefaultUsers.Controls.Add(chkCreateReceptionist);
            tabDefaultUsers.Controls.Add(lblAdminDetails);
            tabDefaultUsers.Controls.Add(chkCreateAdmin);
            tabDefaultUsers.Controls.Add(lblHeadadminDetails);
            tabDefaultUsers.Controls.Add(lblHeadadminTitle);
            tabDefaultUsers.Controls.Add(lblDefaultUsersInfo);
            tabDefaultUsers.Controls.Add(lblDefaultUsersTitle);
            tabDefaultUsers.Location = new Point(4, 24);
            tabDefaultUsers.Name = "tabDefaultUsers";
            tabDefaultUsers.Padding = new Padding(3);
            tabDefaultUsers.Size = new Size(462, 422);
            tabDefaultUsers.TabIndex = 1;
            tabDefaultUsers.Text = "Default Users";
            // 
            // lblDefaultUsersWarning
            // 
            lblDefaultUsersWarning.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblDefaultUsersWarning.ForeColor = Color.FromArgb(220, 53, 69);
            lblDefaultUsersWarning.Location = new Point(15, 385);
            lblDefaultUsersWarning.Name = "lblDefaultUsersWarning";
            lblDefaultUsersWarning.Size = new Size(420, 20);
            lblDefaultUsersWarning.TabIndex = 14;
            lblDefaultUsersWarning.Text = "⚠️ Changes take effect after database re-initialization";
            // 
            // lblPatientDetails
            // 
            lblPatientDetails.Font = new Font("Segoe UI", 8F);
            lblPatientDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblPatientDetails.Location = new Point(35, 370);
            lblPatientDetails.Name = "lblPatientDetails";
            lblPatientDetails.Size = new Size(400, 15);
            lblPatientDetails.TabIndex = 13;
            lblPatientDetails.Text = "Email: Patient@hospital.com | Sample test patient";
            // 
            // chkCreatePatient
            // 
            chkCreatePatient.Font = new Font("Segoe UI", 10F);
            chkCreatePatient.ForeColor = Color.FromArgb(26, 32, 44);
            chkCreatePatient.Location = new Point(15, 342);
            chkCreatePatient.Name = "chkCreatePatient";
            chkCreatePatient.Size = new Size(420, 30);
            chkCreatePatient.TabIndex = 12;
            chkCreatePatient.Text = "Create Default Patient";
            chkCreatePatient.UseVisualStyleBackColor = true;
            // 
            // lblDoctorDetails
            // 
            lblDoctorDetails.Font = new Font("Segoe UI", 8F);
            lblDoctorDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblDoctorDetails.Location = new Point(35, 315);
            lblDoctorDetails.Name = "lblDoctorDetails";
            lblDoctorDetails.Size = new Size(400, 15);
            lblDoctorDetails.TabIndex = 11;
            lblDoctorDetails.Text = "Email: Doctor@hospital.com | Password: doctor123";
            // 
            // chkCreateDoctor
            // 
            chkCreateDoctor.Font = new Font("Segoe UI", 10F);
            chkCreateDoctor.ForeColor = Color.FromArgb(26, 32, 44);
            chkCreateDoctor.Location = new Point(15, 287);
            chkCreateDoctor.Name = "chkCreateDoctor";
            chkCreateDoctor.Size = new Size(420, 30);
            chkCreateDoctor.TabIndex = 10;
            chkCreateDoctor.Text = "Create Default Doctor";
            chkCreateDoctor.UseVisualStyleBackColor = true;
            // 
            // lblPharmacistDetails
            // 
            lblPharmacistDetails.Font = new Font("Segoe UI", 8F);
            lblPharmacistDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblPharmacistDetails.Location = new Point(35, 260);
            lblPharmacistDetails.Name = "lblPharmacistDetails";
            lblPharmacistDetails.Size = new Size(400, 15);
            lblPharmacistDetails.TabIndex = 9;
            lblPharmacistDetails.Text = "Email: Pharmacist@hospital.com | Password: pharmacist123";
            // 
            // chkCreatePharmacist
            // 
            chkCreatePharmacist.Font = new Font("Segoe UI", 10F);
            chkCreatePharmacist.ForeColor = Color.FromArgb(26, 32, 44);
            chkCreatePharmacist.Location = new Point(15, 232);
            chkCreatePharmacist.Name = "chkCreatePharmacist";
            chkCreatePharmacist.Size = new Size(420, 30);
            chkCreatePharmacist.TabIndex = 8;
            chkCreatePharmacist.Text = "Create Default Pharmacist";
            chkCreatePharmacist.UseVisualStyleBackColor = true;
            // 
            // lblReceptionistDetails
            // 
            lblReceptionistDetails.Font = new Font("Segoe UI", 8F);
            lblReceptionistDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblReceptionistDetails.Location = new Point(35, 205);
            lblReceptionistDetails.Name = "lblReceptionistDetails";
            lblReceptionistDetails.Size = new Size(400, 15);
            lblReceptionistDetails.TabIndex = 7;
            lblReceptionistDetails.Text = "Email: Receptionist@hospital.com | Password: receptionist123";
            // 
            // chkCreateReceptionist
            // 
            chkCreateReceptionist.Font = new Font("Segoe UI", 10F);
            chkCreateReceptionist.ForeColor = Color.FromArgb(26, 32, 44);
            chkCreateReceptionist.Location = new Point(15, 177);
            chkCreateReceptionist.Name = "chkCreateReceptionist";
            chkCreateReceptionist.Size = new Size(420, 30);
            chkCreateReceptionist.TabIndex = 6;
            chkCreateReceptionist.Text = "Create Default Receptionist";
            chkCreateReceptionist.UseVisualStyleBackColor = true;
            // 
            // lblAdminDetails
            // 
            lblAdminDetails.Font = new Font("Segoe UI", 8F);
            lblAdminDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblAdminDetails.Location = new Point(35, 150);
            lblAdminDetails.Name = "lblAdminDetails";
            lblAdminDetails.Size = new Size(400, 15);
            lblAdminDetails.TabIndex = 5;
            lblAdminDetails.Text = "Email: Admin@hospital.com | Password: admin123";
            // 
            // chkCreateAdmin
            // 
            chkCreateAdmin.Font = new Font("Segoe UI", 10F);
            chkCreateAdmin.ForeColor = Color.FromArgb(26, 32, 44);
            chkCreateAdmin.Location = new Point(15, 122);
            chkCreateAdmin.Name = "chkCreateAdmin";
            chkCreateAdmin.Size = new Size(420, 30);
            chkCreateAdmin.TabIndex = 4;
            chkCreateAdmin.Text = "Create Default Admin";
            chkCreateAdmin.UseVisualStyleBackColor = true;
            // 
            // lblHeadadminDetails
            // 
            lblHeadadminDetails.Font = new Font("Segoe UI", 8F);
            lblHeadadminDetails.ForeColor = Color.FromArgb(113, 128, 150);
            lblHeadadminDetails.Location = new Point(35, 95);
            lblHeadadminDetails.Name = "lblHeadadminDetails";
            lblHeadadminDetails.Size = new Size(400, 15);
            lblHeadadminDetails.TabIndex = 3;
            lblHeadadminDetails.Text = "Email: Headadmin@hospital.com | Password: admin123";
            // 
            // lblHeadadminTitle
            // 
            lblHeadadminTitle.Enabled = false;
            lblHeadadminTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHeadadminTitle.ForeColor = Color.FromArgb(220, 53, 69);
            lblHeadadminTitle.Location = new Point(15, 67);
            lblHeadadminTitle.Name = "lblHeadadminTitle";
            lblHeadadminTitle.Size = new Size(420, 30);
            lblHeadadminTitle.TabIndex = 2;
            lblHeadadminTitle.Text = "🔒 Head Admin (Always Created - System Required)";
            // 
            // lblDefaultUsersInfo
            // 
            lblDefaultUsersInfo.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDefaultUsersInfo.ForeColor = Color.FromArgb(113, 128, 150);
            lblDefaultUsersInfo.Location = new Point(15, 45);
            lblDefaultUsersInfo.Name = "lblDefaultUsersInfo";
            lblDefaultUsersInfo.Size = new Size(430, 20);
            lblDefaultUsersInfo.TabIndex = 1;
            lblDefaultUsersInfo.Text = "These users will be automatically created when the database is initialized";
            // 
            // lblDefaultUsersTitle
            // 
            lblDefaultUsersTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDefaultUsersTitle.ForeColor = Color.FromArgb(26, 32, 44);
            lblDefaultUsersTitle.Location = new Point(15, 15);
            lblDefaultUsersTitle.Name = "lblDefaultUsersTitle";
            lblDefaultUsersTitle.Size = new Size(430, 25);
            lblDefaultUsersTitle.TabIndex = 0;
            lblDefaultUsersTitle.Text = "Auto-Create Default Users on Startup";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(66, 153, 225);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(320, 475);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Save All Settings";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(203, 213, 224);
            btnReset.Cursor = Cursors.Hand;
            btnReset.FlatAppearance.BorderSize = 0;
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Segoe UI", 9F);
            btnReset.ForeColor = Color.FromArgb(26, 32, 44);
            btnReset.Location = new Point(155, 475);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(150, 40);
            btnReset.TabIndex = 2;
            btnReset.Text = "↺ Reset to Default";
            btnReset.UseVisualStyleBackColor = false;
            btnReset.Click += btnReset_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(10, 475);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(130, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "✕ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // DebugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(500, 550);
            Controls.Add(btnClose);
            Controls.Add(btnReset);
            Controls.Add(btnSave);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DebugForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Debug Dashboard Settings";
            tabControl.ResumeLayout(false);
            tabDashboard.ResumeLayout(false);
            tabRoleCreation.ResumeLayout(false);
            tabDefaultUsers.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.Label lblDashboardNote;
        private System.Windows.Forms.CheckBox chkPharmacist;
        private System.Windows.Forms.CheckBox chkDoctor;
        private System.Windows.Forms.CheckBox chkReceptionist;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.TabPage tabDefaultUsers;
        private System.Windows.Forms.Label lblDefaultUsersWarning;
        private System.Windows.Forms.Label lblPatientDetails;
        private System.Windows.Forms.CheckBox chkCreatePatient;
        private System.Windows.Forms.Label lblDoctorDetails;
        private System.Windows.Forms.CheckBox chkCreateDoctor;
        private System.Windows.Forms.Label lblPharmacistDetails;
        private System.Windows.Forms.CheckBox chkCreatePharmacist;
        private System.Windows.Forms.Label lblReceptionistDetails;
        private System.Windows.Forms.CheckBox chkCreateReceptionist;
        private System.Windows.Forms.Label lblAdminDetails;
        private System.Windows.Forms.CheckBox chkCreateAdmin;
        private System.Windows.Forms.Label lblHeadadminDetails;
        private System.Windows.Forms.Label lblHeadadminTitle;
        private System.Windows.Forms.Label lblDefaultUsersInfo;
        private System.Windows.Forms.Label lblDefaultUsersTitle;
        private System.Windows.Forms.TabPage tabRoleCreation;
        private System.Windows.Forms.Label lblRoleCreationNote;
        private System.Windows.Forms.Label lblAllowPatientDetails;
        private System.Windows.Forms.CheckBox chkAllowPatient;
        private System.Windows.Forms.CheckBox chkAllowPharmacist;
        private System.Windows.Forms.Label lblAllowDoctorDetails;
        private System.Windows.Forms.CheckBox chkAllowDoctor;
        private System.Windows.Forms.Label lblAllowReceptionistDetails;
        private System.Windows.Forms.CheckBox chkAllowReceptionist;
        private System.Windows.Forms.Label lblAllowAdminDetails;
        private System.Windows.Forms.CheckBox chkAllowAdmin;
        private System.Windows.Forms.Label lblRoleCreationInfo;
        private System.Windows.Forms.Label lblRoleCreationTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;
        private Label lblAllowPharmacistDetails;
    }
}