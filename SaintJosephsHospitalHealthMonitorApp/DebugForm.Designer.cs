namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class DebugForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabDefaultUsers;
        private System.Windows.Forms.Label lblDashboardTitle;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.CheckBox chkReceptionist;
        private System.Windows.Forms.CheckBox chkDoctor;
        private System.Windows.Forms.CheckBox chkPharmacist;
        private System.Windows.Forms.Label lblDashboardNote;
        private System.Windows.Forms.Label lblDefaultUsersTitle;
        private System.Windows.Forms.Label lblDefaultUsersInfo;
        private System.Windows.Forms.Label lblHeadadminTitle;
        private System.Windows.Forms.Label lblHeadadminDetails;
        private System.Windows.Forms.CheckBox chkCreateAdmin;
        private System.Windows.Forms.Label lblAdminDetails;
        private System.Windows.Forms.CheckBox chkCreateReceptionist;
        private System.Windows.Forms.Label lblReceptionistDetails;
        private System.Windows.Forms.CheckBox chkCreatePharmacist;
        private System.Windows.Forms.Label lblPharmacistDetails;
        private System.Windows.Forms.CheckBox chkCreateDoctor;
        private System.Windows.Forms.Label lblDoctorDetails;
        private System.Windows.Forms.CheckBox chkCreatePatient;
        private System.Windows.Forms.Label lblPatientDetails;
        private System.Windows.Forms.Label lblDefaultUsersWarning;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClose;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.lblDashboardNote = new System.Windows.Forms.Label();
            this.chkPharmacist = new System.Windows.Forms.CheckBox();
            this.chkDoctor = new System.Windows.Forms.CheckBox();
            this.chkReceptionist = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.lblDashboardTitle = new System.Windows.Forms.Label();
            this.tabDefaultUsers = new System.Windows.Forms.TabPage();
            this.lblDefaultUsersWarning = new System.Windows.Forms.Label();
            this.lblPatientDetails = new System.Windows.Forms.Label();
            this.chkCreatePatient = new System.Windows.Forms.CheckBox();
            this.lblDoctorDetails = new System.Windows.Forms.Label();
            this.chkCreateDoctor = new System.Windows.Forms.CheckBox();
            this.lblPharmacistDetails = new System.Windows.Forms.Label();
            this.chkCreatePharmacist = new System.Windows.Forms.CheckBox();
            this.lblReceptionistDetails = new System.Windows.Forms.Label();
            this.chkCreateReceptionist = new System.Windows.Forms.CheckBox();
            this.lblAdminDetails = new System.Windows.Forms.Label();
            this.chkCreateAdmin = new System.Windows.Forms.CheckBox();
            this.lblHeadadminDetails = new System.Windows.Forms.Label();
            this.lblHeadadminTitle = new System.Windows.Forms.Label();
            this.lblDefaultUsersInfo = new System.Windows.Forms.Label();
            this.lblDefaultUsersTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            this.tabDefaultUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDashboard);
            this.tabControl.Controls.Add(this.tabDefaultUsers);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(470, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabDashboard
            // 
            this.tabDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabDashboard.Controls.Add(this.lblDashboardNote);
            this.tabDashboard.Controls.Add(this.chkPharmacist);
            this.tabDashboard.Controls.Add(this.chkDoctor);
            this.tabDashboard.Controls.Add(this.chkReceptionist);
            this.tabDashboard.Controls.Add(this.chkAdmin);
            this.tabDashboard.Controls.Add(this.lblDashboardTitle);
            this.tabDashboard.Location = new System.Drawing.Point(4, 24);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(462, 422);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard Access";
            // 
            // lblDashboardNote
            // 
            this.lblDashboardNote.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblDashboardNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblDashboardNote.Location = new System.Drawing.Point(20, 215);
            this.lblDashboardNote.Name = "lblDashboardNote";
            this.lblDashboardNote.Size = new System.Drawing.Size(420, 20);
            this.lblDashboardNote.TabIndex = 5;
            this.lblDashboardNote.Text = "Head Admin access is always enabled";
            // 
            // chkPharmacist
            // 
            this.chkPharmacist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkPharmacist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkPharmacist.Location = new System.Drawing.Point(20, 175);
            this.chkPharmacist.Name = "chkPharmacist";
            this.chkPharmacist.Size = new System.Drawing.Size(420, 30);
            this.chkPharmacist.TabIndex = 4;
            this.chkPharmacist.Text = "Pharmacist Dashboard";
            this.chkPharmacist.UseVisualStyleBackColor = true;
            // 
            // chkDoctor
            // 
            this.chkDoctor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkDoctor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkDoctor.Location = new System.Drawing.Point(20, 135);
            this.chkDoctor.Name = "chkDoctor";
            this.chkDoctor.Size = new System.Drawing.Size(420, 30);
            this.chkDoctor.TabIndex = 3;
            this.chkDoctor.Text = "Doctor Dashboard";
            this.chkDoctor.UseVisualStyleBackColor = true;
            // 
            // chkReceptionist
            // 
            this.chkReceptionist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkReceptionist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkReceptionist.Location = new System.Drawing.Point(20, 95);
            this.chkReceptionist.Name = "chkReceptionist";
            this.chkReceptionist.Size = new System.Drawing.Size(420, 30);
            this.chkReceptionist.TabIndex = 2;
            this.chkReceptionist.Text = "Receptionist Dashboard";
            this.chkReceptionist.UseVisualStyleBackColor = true;
            // 
            // chkAdmin
            // 
            this.chkAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkAdmin.Location = new System.Drawing.Point(20, 55);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(420, 30);
            this.chkAdmin.TabIndex = 1;
            this.chkAdmin.Text = "Admin Dashboard";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // lblDashboardTitle
            // 
            this.lblDashboardTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDashboardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.lblDashboardTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDashboardTitle.Name = "lblDashboardTitle";
            this.lblDashboardTitle.Size = new System.Drawing.Size(430, 25);
            this.lblDashboardTitle.TabIndex = 0;
            this.lblDashboardTitle.Text = "Enable/Disable Dashboard Access";
            // 
            // tabDefaultUsers
            // 
            this.tabDefaultUsers.AutoScroll = true;
            this.tabDefaultUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tabDefaultUsers.Controls.Add(this.lblDefaultUsersWarning);
            this.tabDefaultUsers.Controls.Add(this.lblPatientDetails);
            this.tabDefaultUsers.Controls.Add(this.chkCreatePatient);
            this.tabDefaultUsers.Controls.Add(this.lblDoctorDetails);
            this.tabDefaultUsers.Controls.Add(this.chkCreateDoctor);
            this.tabDefaultUsers.Controls.Add(this.lblPharmacistDetails);
            this.tabDefaultUsers.Controls.Add(this.chkCreatePharmacist);
            this.tabDefaultUsers.Controls.Add(this.lblReceptionistDetails);
            this.tabDefaultUsers.Controls.Add(this.chkCreateReceptionist);
            this.tabDefaultUsers.Controls.Add(this.lblAdminDetails);
            this.tabDefaultUsers.Controls.Add(this.chkCreateAdmin);
            this.tabDefaultUsers.Controls.Add(this.lblHeadadminDetails);
            this.tabDefaultUsers.Controls.Add(this.lblHeadadminTitle);
            this.tabDefaultUsers.Controls.Add(this.lblDefaultUsersInfo);
            this.tabDefaultUsers.Controls.Add(this.lblDefaultUsersTitle);
            this.tabDefaultUsers.Location = new System.Drawing.Point(4, 24);
            this.tabDefaultUsers.Name = "tabDefaultUsers";
            this.tabDefaultUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefaultUsers.Size = new System.Drawing.Size(462, 422);
            this.tabDefaultUsers.TabIndex = 1;
            this.tabDefaultUsers.Text = "Default Users";
            // 
            // lblDefaultUsersWarning
            // 
            this.lblDefaultUsersWarning.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblDefaultUsersWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblDefaultUsersWarning.Location = new System.Drawing.Point(20, 408);
            this.lblDefaultUsersWarning.Name = "lblDefaultUsersWarning";
            this.lblDefaultUsersWarning.Size = new System.Drawing.Size(420, 20);
            this.lblDefaultUsersWarning.TabIndex = 14;
            this.lblDefaultUsersWarning.Text = "⚠️ Changes take effect after database re-initialization";
            // 
            // lblPatientDetails
            // 
            this.lblPatientDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPatientDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblPatientDetails.Location = new System.Drawing.Point(40, 383);
            this.lblPatientDetails.Name = "lblPatientDetails";
            this.lblPatientDetails.Size = new System.Drawing.Size(400, 15);
            this.lblPatientDetails.TabIndex = 13;
            this.lblPatientDetails.Text = "Email: Patient@hospital.com | Sample test patient";
            // 
            // chkCreatePatient
            // 
            this.chkCreatePatient.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkCreatePatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkCreatePatient.Location = new System.Drawing.Point(20, 355);
            this.chkCreatePatient.Name = "chkCreatePatient";
            this.chkCreatePatient.Size = new System.Drawing.Size(420, 30);
            this.chkCreatePatient.TabIndex = 12;
            this.chkCreatePatient.Text = "Create Default Patient";
            this.chkCreatePatient.UseVisualStyleBackColor = true;
            // 
            // lblDoctorDetails
            // 
            this.lblDoctorDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDoctorDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblDoctorDetails.Location = new System.Drawing.Point(40, 328);
            this.lblDoctorDetails.Name = "lblDoctorDetails";
            this.lblDoctorDetails.Size = new System.Drawing.Size(400, 15);
            this.lblDoctorDetails.TabIndex = 11;
            this.lblDoctorDetails.Text = "Email: Doctor@hospital.com | Password: doctor123";
            // 
            // chkCreateDoctor
            // 
            this.chkCreateDoctor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkCreateDoctor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkCreateDoctor.Location = new System.Drawing.Point(20, 300);
            this.chkCreateDoctor.Name = "chkCreateDoctor";
            this.chkCreateDoctor.Size = new System.Drawing.Size(420, 30);
            this.chkCreateDoctor.TabIndex = 10;
            this.chkCreateDoctor.Text = "Create Default Doctor";
            this.chkCreateDoctor.UseVisualStyleBackColor = true;
            // 
            // lblPharmacistDetails
            // 
            this.lblPharmacistDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPharmacistDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblPharmacistDetails.Location = new System.Drawing.Point(40, 273);
            this.lblPharmacistDetails.Name = "lblPharmacistDetails";
            this.lblPharmacistDetails.Size = new System.Drawing.Size(400, 15);
            this.lblPharmacistDetails.TabIndex = 9;
            this.lblPharmacistDetails.Text = "Email: Pharmacist@hospital.com | Password: pharmacist123";
            // 
            // chkCreatePharmacist
            // 
            this.chkCreatePharmacist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkCreatePharmacist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkCreatePharmacist.Location = new System.Drawing.Point(20, 245);
            this.chkCreatePharmacist.Name = "chkCreatePharmacist";
            this.chkCreatePharmacist.Size = new System.Drawing.Size(420, 30);
            this.chkCreatePharmacist.TabIndex = 8;
            this.chkCreatePharmacist.Text = "Create Default Pharmacist";
            this.chkCreatePharmacist.UseVisualStyleBackColor = true;
            // 
            // lblReceptionistDetails
            // 
            this.lblReceptionistDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblReceptionistDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblReceptionistDetails.Location = new System.Drawing.Point(40, 218);
            this.lblReceptionistDetails.Name = "lblReceptionistDetails";
            this.lblReceptionistDetails.Size = new System.Drawing.Size(400, 15);
            this.lblReceptionistDetails.TabIndex = 7;
            this.lblReceptionistDetails.Text = "Email: Receptionist@hospital.com | Password: receptionist123";
            // 
            // chkCreateReceptionist
            // 
            this.chkCreateReceptionist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkCreateReceptionist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkCreateReceptionist.Location = new System.Drawing.Point(20, 190);
            this.chkCreateReceptionist.Name = "chkCreateReceptionist";
            this.chkCreateReceptionist.Size = new System.Drawing.Size(420, 30);
            this.chkCreateReceptionist.TabIndex = 6;
            this.chkCreateReceptionist.Text = "Create Default Receptionist";
            this.chkCreateReceptionist.UseVisualStyleBackColor = true;
            // 
            // lblAdminDetails
            // 
            this.lblAdminDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAdminDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblAdminDetails.Location = new System.Drawing.Point(40, 163);
            this.lblAdminDetails.Name = "lblAdminDetails";
            this.lblAdminDetails.Size = new System.Drawing.Size(400, 15);
            this.lblAdminDetails.TabIndex = 5;
            this.lblAdminDetails.Text = "Email: Admin@hospital.com | Password: admin123";
            // 
            // chkCreateAdmin
            // 
            this.chkCreateAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkCreateAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chkCreateAdmin.Location = new System.Drawing.Point(20, 135);
            this.chkCreateAdmin.Name = "chkCreateAdmin";
            this.chkCreateAdmin.Size = new System.Drawing.Size(420, 30);
            this.chkCreateAdmin.TabIndex = 4;
            this.chkCreateAdmin.Text = "Create Default Admin";
            this.chkCreateAdmin.UseVisualStyleBackColor = true;
            // 
            // lblHeadadminDetails
            // 
            this.lblHeadadminDetails.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHeadadminDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblHeadadminDetails.Location = new System.Drawing.Point(40, 108);
            this.lblHeadadminDetails.Name = "lblHeadadminDetails";
            this.lblHeadadminDetails.Size = new System.Drawing.Size(400, 15);
            this.lblHeadadminDetails.TabIndex = 3;
            this.lblHeadadminDetails.Text = "Email: Headadmin@hospital.com | Password: admin123";
            // 
            // lblHeadadminTitle
            // 
            this.lblHeadadminTitle.Enabled = false;
            this.lblHeadadminTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeadadminTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblHeadadminTitle.Location = new System.Drawing.Point(20, 80);
            this.lblHeadadminTitle.Name = "lblHeadadminTitle";
            this.lblHeadadminTitle.Size = new System.Drawing.Size(420, 30);
            this.lblHeadadminTitle.TabIndex = 2;
            this.lblHeadadminTitle.Text = "🔒 Head Admin (Always Created - System Required)";
            // 
            // lblDefaultUsersInfo
            // 
            this.lblDefaultUsersInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblDefaultUsersInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.lblDefaultUsersInfo.Location = new System.Drawing.Point(15, 45);
            this.lblDefaultUsersInfo.Name = "lblDefaultUsersInfo";
            this.lblDefaultUsersInfo.Size = new System.Drawing.Size(430, 20);
            this.lblDefaultUsersInfo.TabIndex = 1;
            this.lblDefaultUsersInfo.Text = "These users will be automatically created when the database is initialized";
            // 
            // lblDefaultUsersTitle
            // 
            this.lblDefaultUsersTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDefaultUsersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.lblDefaultUsersTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDefaultUsersTitle.Name = "lblDefaultUsersTitle";
            this.lblDefaultUsersTitle.Size = new System.Drawing.Size(430, 25);
            this.lblDefaultUsersTitle.TabIndex = 0;
            this.lblDefaultUsersTitle.Text = "Auto-Create Default Users on Startup";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(153)))), ((int)(((byte)(225)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(320, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "💾 Save All Settings";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(224)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.btnReset.Location = new System.Drawing.Point(155, 475);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 40);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "↺ Reset to Default";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(10, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "✕ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(500, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Debug Dashboard Settings";
            this.tabControl.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.tabDefaultUsers.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}