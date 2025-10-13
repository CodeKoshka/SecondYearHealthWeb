namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PatientDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.TabPage tabRecords;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridView dgvMedicalRecords;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblAllergies;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnRequestAppt;
        private System.Windows.Forms.Button btnCancelAppt;
        private System.Windows.Forms.Button btnRefreshAppt;
        private System.Windows.Forms.Button btnViewRecord;
        private System.Windows.Forms.Button btnRefreshRecords;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Button btnRefreshBill;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelProfile = new System.Windows.Forms.Panel();
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblBloodType = new System.Windows.Forms.Label();
            this.lblAllergies = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.btnRequestAppt = new System.Windows.Forms.Button();
            this.btnCancelAppt = new System.Windows.Forms.Button();
            this.btnRefreshAppt = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.tabRecords = new System.Windows.Forms.TabPage();
            this.btnViewRecord = new System.Windows.Forms.Button();
            this.btnRefreshRecords = new System.Windows.Forms.Button();
            this.dgvMedicalRecords = new System.Windows.Forms.DataGridView();
            this.tabBilling = new System.Windows.Forms.TabPage();
            this.btnViewBill = new System.Windows.Forms.Button();
            this.btnRefreshBill = new System.Windows.Forms.Button();
            this.dgvBilling = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.panelProfile.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.tabRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).BeginInit();
            this.tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(30, 25);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(100, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1050, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // panelProfile
            // 
            this.panelProfile.BackColor = System.Drawing.Color.White;
            this.panelProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProfile.Controls.Add(this.lblProfileTitle);
            this.panelProfile.Controls.Add(this.lblName);
            this.panelProfile.Controls.Add(this.lblAge);
            this.panelProfile.Controls.Add(this.lblGender);
            this.panelProfile.Controls.Add(this.lblBloodType);
            this.panelProfile.Controls.Add(this.lblAllergies);
            this.panelProfile.Location = new System.Drawing.Point(20, 100);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(1140, 120);
            this.panelProfile.TabIndex = 1;
            // 
            // lblProfileTitle
            // 
            this.lblProfileTitle.AutoSize = true;
            this.lblProfileTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProfileTitle.Location = new System.Drawing.Point(20, 15);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(100, 25);
            this.lblProfileTitle.TabIndex = 0;
            this.lblProfileTitle.Text = "My Profile";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.Location = new System.Drawing.Point(20, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAge.Location = new System.Drawing.Point(300, 50);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(35, 19);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGender.Location = new System.Drawing.Point(450, 50);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(58, 19);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender:";
            // 
            // lblBloodType
            // 
            this.lblBloodType.AutoSize = true;
            this.lblBloodType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBloodType.Location = new System.Drawing.Point(20, 80);
            this.lblBloodType.Name = "lblBloodType";
            this.lblBloodType.Size = new System.Drawing.Size(83, 19);
            this.lblBloodType.TabIndex = 4;
            this.lblBloodType.Text = "Blood Type:";
            // 
            // lblAllergies
            // 
            this.lblAllergies.AutoSize = true;
            this.lblAllergies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAllergies.Location = new System.Drawing.Point(300, 80);
            this.lblAllergies.Name = "lblAllergies";
            this.lblAllergies.Size = new System.Drawing.Size(67, 19);
            this.lblAllergies.TabIndex = 5;
            this.lblAllergies.Text = "Allergies:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAppointments);
            this.tabControl.Controls.Add(this.tabRecords);
            this.tabControl.Controls.Add(this.tabBilling);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(20, 240);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1140, 450);
            this.tabControl.TabIndex = 2;
            // 
            // tabAppointments
            // 
            this.tabAppointments.Controls.Add(this.btnRequestAppt);
            this.tabAppointments.Controls.Add(this.btnCancelAppt);
            this.tabAppointments.Controls.Add(this.btnRefreshAppt);
            this.tabAppointments.Controls.Add(this.dgvAppointments);
            this.tabAppointments.Location = new System.Drawing.Point(4, 26);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(1132, 420);
            this.tabAppointments.TabIndex = 0;
            this.tabAppointments.Text = "My Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // btnRequestAppt
            // 
            this.btnRequestAppt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRequestAppt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequestAppt.FlatAppearance.BorderSize = 0;
            this.btnRequestAppt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestAppt.ForeColor = System.Drawing.Color.White;
            this.btnRequestAppt.Location = new System.Drawing.Point(10, 10);
            this.btnRequestAppt.Name = "btnRequestAppt";
            this.btnRequestAppt.Size = new System.Drawing.Size(170, 35);
            this.btnRequestAppt.TabIndex = 0;
            this.btnRequestAppt.Text = "Request Appointment";
            this.btnRequestAppt.UseVisualStyleBackColor = false;
            this.btnRequestAppt.Click += new System.EventHandler(this.BtnRequestAppointment_Click);
            // 
            // btnCancelAppt
            // 
            this.btnCancelAppt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCancelAppt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelAppt.FlatAppearance.BorderSize = 0;
            this.btnCancelAppt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAppt.ForeColor = System.Drawing.Color.White;
            this.btnCancelAppt.Location = new System.Drawing.Point(190, 10);
            this.btnCancelAppt.Name = "btnCancelAppt";
            this.btnCancelAppt.Size = new System.Drawing.Size(170, 35);
            this.btnCancelAppt.TabIndex = 1;
            this.btnCancelAppt.Text = "Cancel Appointment";
            this.btnCancelAppt.UseVisualStyleBackColor = false;
            this.btnCancelAppt.Click += new System.EventHandler(this.BtnCancelAppointment_Click);
            // 
            // btnRefreshAppt
            // 
            this.btnRefreshAppt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshAppt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshAppt.FlatAppearance.BorderSize = 0;
            this.btnRefreshAppt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAppt.ForeColor = System.Drawing.Color.White;
            this.btnRefreshAppt.Location = new System.Drawing.Point(370, 10);
            this.btnRefreshAppt.Name = "btnRefreshAppt";
            this.btnRefreshAppt.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshAppt.TabIndex = 2;
            this.btnRefreshAppt.Text = "Refresh";
            this.btnRefreshAppt.UseVisualStyleBackColor = false;
            this.btnRefreshAppt.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.AllowUserToAddRows = false;
            this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
            this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppointments.Location = new System.Drawing.Point(10, 60);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.ReadOnly = true;
            this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointments.Size = new System.Drawing.Size(1100, 340);
            this.dgvAppointments.TabIndex = 3;
            // 
            // tabRecords
            // 
            this.tabRecords.Controls.Add(this.btnViewRecord);
            this.tabRecords.Controls.Add(this.btnRefreshRecords);
            this.tabRecords.Controls.Add(this.dgvMedicalRecords);
            this.tabRecords.Location = new System.Drawing.Point(4, 26);
            this.tabRecords.Name = "tabRecords";
            this.tabRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecords.Size = new System.Drawing.Size(1132, 420);
            this.tabRecords.TabIndex = 1;
            this.tabRecords.Text = "My Medical Records";
            this.tabRecords.UseVisualStyleBackColor = true;
            // 
            // btnViewRecord
            // 
            this.btnViewRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewRecord.FlatAppearance.BorderSize = 0;
            this.btnViewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewRecord.ForeColor = System.Drawing.Color.White;
            this.btnViewRecord.Location = new System.Drawing.Point(10, 10);
            this.btnViewRecord.Name = "btnViewRecord";
            this.btnViewRecord.Size = new System.Drawing.Size(120, 35);
            this.btnViewRecord.TabIndex = 0;
            this.btnViewRecord.Text = "View Details";
            this.btnViewRecord.UseVisualStyleBackColor = false;
            this.btnViewRecord.Click += new System.EventHandler(this.BtnViewRecord_Click);
            // 
            // btnRefreshRecords
            // 
            this.btnRefreshRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshRecords.FlatAppearance.BorderSize = 0;
            this.btnRefreshRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshRecords.ForeColor = System.Drawing.Color.White;
            this.btnRefreshRecords.Location = new System.Drawing.Point(140, 10);
            this.btnRefreshRecords.Name = "btnRefreshRecords";
            this.btnRefreshRecords.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshRecords.TabIndex = 1;
            this.btnRefreshRecords.Text = "Refresh";
            this.btnRefreshRecords.UseVisualStyleBackColor = false;
            this.btnRefreshRecords.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvMedicalRecords
            // 
            this.dgvMedicalRecords.AllowUserToAddRows = false;
            this.dgvMedicalRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicalRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicalRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicalRecords.Location = new System.Drawing.Point(10, 60);
            this.dgvMedicalRecords.Name = "dgvMedicalRecords";
            this.dgvMedicalRecords.ReadOnly = true;
            this.dgvMedicalRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicalRecords.Size = new System.Drawing.Size(1100, 340);
            this.dgvMedicalRecords.TabIndex = 2;
            // 
            // tabBilling
            // 
            this.tabBilling.Controls.Add(this.btnViewBill);
            this.tabBilling.Controls.Add(this.btnRefreshBill);
            this.tabBilling.Controls.Add(this.dgvBilling);
            this.tabBilling.Location = new System.Drawing.Point(4, 26);
            this.tabBilling.Name = "tabBilling";
            this.tabBilling.Padding = new System.Windows.Forms.Padding(3);
            this.tabBilling.Size = new System.Drawing.Size(1132, 420);
            this.tabBilling.TabIndex = 2;
            this.tabBilling.Text = "My Bills & Payments";
            this.tabBilling.UseVisualStyleBackColor = true;
            // 
            // btnViewBill
            // 
            this.btnViewBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewBill.FlatAppearance.BorderSize = 0;
            this.btnViewBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBill.ForeColor = System.Drawing.Color.White;
            this.btnViewBill.Location = new System.Drawing.Point(10, 10);
            this.btnViewBill.Name = "btnViewBill";
            this.btnViewBill.Size = new System.Drawing.Size(150, 35);
            this.btnViewBill.TabIndex = 0;
            this.btnViewBill.Text = "View Bill Details";
            this.btnViewBill.UseVisualStyleBackColor = false;
            this.btnViewBill.Click += new System.EventHandler(this.BtnViewBill_Click);
            // 
            // btnRefreshBill
            // 
            this.btnRefreshBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshBill.FlatAppearance.BorderSize = 0;
            this.btnRefreshBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBill.ForeColor = System.Drawing.Color.White;
            this.btnRefreshBill.Location = new System.Drawing.Point(170, 10);
            this.btnRefreshBill.Name = "btnRefreshBill";
            this.btnRefreshBill.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshBill.TabIndex = 1;
            this.btnRefreshBill.Text = "Refresh";
            this.btnRefreshBill.UseVisualStyleBackColor = false;
            this.btnRefreshBill.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvBilling
            // 
            this.dgvBilling.AllowUserToAddRows = false;
            this.dgvBilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBilling.BackgroundColor = System.Drawing.Color.White;
            this.dgvBilling.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBilling.Location = new System.Drawing.Point(10, 60);
            this.dgvBilling.Name = "dgvBilling";
            this.dgvBilling.ReadOnly = true;
            this.dgvBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBilling.Size = new System.Drawing.Size(1100, 340);
            this.dgvBilling.TabIndex = 2;
            // 
            // PatientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelProfile);
            this.Controls.Add(this.panelHeader);
            this.Name = "PatientDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management System - Patient Portal";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.tabRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).EndInit();
            this.tabBilling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
            this.ResumeLayout(false);
        }
    }
}