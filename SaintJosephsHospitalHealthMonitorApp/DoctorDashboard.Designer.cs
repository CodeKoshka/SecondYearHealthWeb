namespace SaintJosephsHospitalHealthMonitorApp
{
partial class DoctorDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.TabPage tabRecords;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridView dgvMedicalRecords;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnViewPatient;
        private System.Windows.Forms.Button btnCompleteAppt;
        private System.Windows.Forms.Button btnRefreshAppt;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnRefreshPatients;
        private System.Windows.Forms.Button btnEditRecord;
        private System.Windows.Forms.Button btnRefreshRecords;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAppointments = new System.Windows.Forms.TabPage();
            this.btnViewPatient = new System.Windows.Forms.Button();
            this.btnCompleteAppt = new System.Windows.Forms.Button();
            this.btnRefreshAppt = new System.Windows.Forms.Button();
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.tabPatients = new System.Windows.Forms.TabPage();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.btnAddRecord = new System.Windows.Forms.Button();
            this.btnRefreshPatients = new System.Windows.Forms.Button();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.tabRecords = new System.Windows.Forms.TabPage();
            this.btnEditRecord = new System.Windows.Forms.Button();
            this.btnRefreshRecords = new System.Windows.Forms.Button();
            this.dgvMedicalRecords = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.tabPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.tabRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
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
            this.lblWelcome.Size = new System.Drawing.Size(150, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Doctor Portal";
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabAppointments);
            this.tabControl.Controls.Add(this.tabPatients);
            this.tabControl.Controls.Add(this.tabRecords);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(20, 100);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1140, 540);
            this.tabControl.TabIndex = 1;
            // 
            // tabAppointments
            // 
            this.tabAppointments.Controls.Add(this.btnViewPatient);
            this.tabAppointments.Controls.Add(this.btnCompleteAppt);
            this.tabAppointments.Controls.Add(this.btnRefreshAppt);
            this.tabAppointments.Controls.Add(this.dgvAppointments);
            this.tabAppointments.Location = new System.Drawing.Point(4, 26);
            this.tabAppointments.Name = "tabAppointments";
            this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppointments.Size = new System.Drawing.Size(1132, 510);
            this.tabAppointments.TabIndex = 0;
            this.tabAppointments.Text = "My Appointments";
            this.tabAppointments.UseVisualStyleBackColor = true;
            // 
            // btnViewPatient
            // 
            this.btnViewPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewPatient.FlatAppearance.BorderSize = 0;
            this.btnViewPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPatient.ForeColor = System.Drawing.Color.White;
            this.btnViewPatient.Location = new System.Drawing.Point(10, 10);
            this.btnViewPatient.Name = "btnViewPatient";
            this.btnViewPatient.Size = new System.Drawing.Size(160, 35);
            this.btnViewPatient.TabIndex = 0;
            this.btnViewPatient.Text = "View Patient Details";
            this.btnViewPatient.UseVisualStyleBackColor = false;
            this.btnViewPatient.Click += new System.EventHandler(this.BtnViewPatient_Click);
            // 
            // btnCompleteAppt
            // 
            this.btnCompleteAppt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCompleteAppt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompleteAppt.FlatAppearance.BorderSize = 0;
            this.btnCompleteAppt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompleteAppt.ForeColor = System.Drawing.Color.White;
            this.btnCompleteAppt.Location = new System.Drawing.Point(180, 10);
            this.btnCompleteAppt.Name = "btnCompleteAppt";
            this.btnCompleteAppt.Size = new System.Drawing.Size(160, 35);
            this.btnCompleteAppt.TabIndex = 1;
            this.btnCompleteAppt.Text = "Mark Completed";
            this.btnCompleteAppt.UseVisualStyleBackColor = false;
            this.btnCompleteAppt.Click += new System.EventHandler(this.BtnCompleteAppointment_Click);
            // 
            // btnRefreshAppt
            // 
            this.btnRefreshAppt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshAppt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshAppt.FlatAppearance.BorderSize = 0;
            this.btnRefreshAppt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAppt.ForeColor = System.Drawing.Color.White;
            this.btnRefreshAppt.Location = new System.Drawing.Point(350, 10);
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
            this.dgvAppointments.Size = new System.Drawing.Size(1100, 430);
            this.dgvAppointments.TabIndex = 3;
            // 
            // tabPatients
            // 
            this.tabPatients.Controls.Add(this.btnViewHistory);
            this.tabPatients.Controls.Add(this.btnAddRecord);
            this.tabPatients.Controls.Add(this.btnRefreshPatients);
            this.tabPatients.Controls.Add(this.dgvPatients);
            this.tabPatients.Location = new System.Drawing.Point(4, 26);
            this.tabPatients.Name = "tabPatients";
            this.tabPatients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPatients.Size = new System.Drawing.Size(1132, 510);
            this.tabPatients.TabIndex = 1;
            this.tabPatients.Text = "My Patients";
            this.tabPatients.UseVisualStyleBackColor = true;
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewHistory.FlatAppearance.BorderSize = 0;
            this.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewHistory.Location = new System.Drawing.Point(10, 10);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(170, 35);
            this.btnViewHistory.TabIndex = 0;
            this.btnViewHistory.Text = "View Medical History";
            this.btnViewHistory.UseVisualStyleBackColor = false;
            this.btnViewHistory.Click += new System.EventHandler(this.BtnViewHistory_Click);
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddRecord.FlatAppearance.BorderSize = 0;
            this.btnAddRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddRecord.Location = new System.Drawing.Point(190, 10);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(160, 35);
            this.btnAddRecord.TabIndex = 1;
            this.btnAddRecord.Text = "Add Medical Record";
            this.btnAddRecord.UseVisualStyleBackColor = false;
            this.btnAddRecord.Click += new System.EventHandler(this.BtnAddMedicalRecord_Click);
            // 
            // btnRefreshPatients
            // 
            this.btnRefreshPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshPatients.FlatAppearance.BorderSize = 0;
            this.btnRefreshPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPatients.ForeColor = System.Drawing.Color.White;
            this.btnRefreshPatients.Location = new System.Drawing.Point(360, 10);
            this.btnRefreshPatients.Name = "btnRefreshPatients";
            this.btnRefreshPatients.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshPatients.TabIndex = 2;
            this.btnRefreshPatients.Text = "Refresh";
            this.btnRefreshPatients.UseVisualStyleBackColor = false;
            this.btnRefreshPatients.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.Location = new System.Drawing.Point(10, 60);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(1100, 430);
            this.dgvPatients.TabIndex = 3;
            // 
            // tabRecords
            // 
            this.tabRecords.Controls.Add(this.btnEditRecord);
            this.tabRecords.Controls.Add(this.btnRefreshRecords);
            this.tabRecords.Controls.Add(this.dgvMedicalRecords);
            this.tabRecords.Location = new System.Drawing.Point(4, 26);
            this.tabRecords.Name = "tabRecords";
            this.tabRecords.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecords.Size = new System.Drawing.Size(1132, 510);
            this.tabRecords.TabIndex = 2;
            this.tabRecords.Text = "Medical Records";
            this.tabRecords.UseVisualStyleBackColor = true;
            // 
            // btnEditRecord
            // 
            this.btnEditRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditRecord.FlatAppearance.BorderSize = 0;
            this.btnEditRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRecord.ForeColor = System.Drawing.Color.White;
            this.btnEditRecord.Location = new System.Drawing.Point(10, 10);
            this.btnEditRecord.Name = "btnEditRecord";
            this.btnEditRecord.Size = new System.Drawing.Size(120, 35);
            this.btnEditRecord.TabIndex = 0;
            this.btnEditRecord.Text = "Edit Record";
            this.btnEditRecord.UseVisualStyleBackColor = false;
            this.btnEditRecord.Click += new System.EventHandler(this.BtnEditRecord_Click);
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
            this.dgvMedicalRecords.Size = new System.Drawing.Size(1100, 430);
            this.dgvMedicalRecords.TabIndex = 2;
            // 
            // DoctorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Name = "DoctorDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management System - Doctor Dashboard";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.tabPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.tabRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).EndInit();
            this.ResumeLayout(false);
        }
    }
}