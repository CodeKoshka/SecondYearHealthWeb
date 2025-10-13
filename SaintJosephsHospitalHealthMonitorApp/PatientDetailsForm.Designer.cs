namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PatientDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmergency;
        private System.Windows.Forms.Label lblAllergiesLabel;
        private System.Windows.Forms.Label lblHistoryLabel;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.TextBox txtMedicalHistory;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelInfo;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblBloodType = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmergency = new System.Windows.Forms.Label();
            this.lblAllergiesLabel = new System.Windows.Forms.Label();
            this.txtAllergies = new System.Windows.Forms.TextBox();
            this.lblHistoryLabel = new System.Windows.Forms.Label();
            this.txtMedicalHistory = new System.Windows.Forms.TextBox();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(137, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Patient Details";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.lblName);
            this.panelInfo.Controls.Add(this.lblAge);
            this.panelInfo.Controls.Add(this.lblGender);
            this.panelInfo.Controls.Add(this.lblEmail);
            this.panelInfo.Controls.Add(this.lblBloodType);
            this.panelInfo.Controls.Add(this.lblPhone);
            this.panelInfo.Controls.Add(this.lblEmergency);
            this.panelInfo.Location = new System.Drawing.Point(20, 60);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(740, 120);
            this.panelInfo.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.Location = new System.Drawing.Point(15, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAge.Location = new System.Drawing.Point(300, 15);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(37, 19);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGender.Location = new System.Drawing.Point(450, 15);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(59, 19);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(15, 50);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 19);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // lblBloodType
            // 
            this.lblBloodType.AutoSize = true;
            this.lblBloodType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBloodType.Location = new System.Drawing.Point(450, 50);
            this.lblBloodType.Name = "lblBloodType";
            this.lblBloodType.Size = new System.Drawing.Size(85, 19);
            this.lblBloodType.TabIndex = 4;
            this.lblBloodType.Text = "Blood Type:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.Location = new System.Drawing.Point(15, 85);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 19);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone:";
            // 
            // lblEmergency
            // 
            this.lblEmergency.AutoSize = true;
            this.lblEmergency.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmergency.Location = new System.Drawing.Point(300, 85);
            this.lblEmergency.Name = "lblEmergency";
            this.lblEmergency.Size = new System.Drawing.Size(138, 19);
            this.lblEmergency.TabIndex = 6;
            this.lblEmergency.Text = "Emergency Contact:";
            // 
            // lblAllergiesLabel
            // 
            this.lblAllergiesLabel.AutoSize = true;
            this.lblAllergiesLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAllergiesLabel.Location = new System.Drawing.Point(20, 200);
            this.lblAllergiesLabel.Name = "lblAllergiesLabel";
            this.lblAllergiesLabel.Size = new System.Drawing.Size(71, 19);
            this.lblAllergiesLabel.TabIndex = 2;
            this.lblAllergiesLabel.Text = "Allergies:";
            // 
            // txtAllergies
            // 
            this.txtAllergies.BackColor = System.Drawing.Color.White;
            this.txtAllergies.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAllergies.Location = new System.Drawing.Point(20, 225);
            this.txtAllergies.Multiline = true;
            this.txtAllergies.Name = "txtAllergies";
            this.txtAllergies.ReadOnly = true;
            this.txtAllergies.Size = new System.Drawing.Size(740, 50);
            this.txtAllergies.TabIndex = 3;
            // 
            // lblHistoryLabel
            // 
            this.lblHistoryLabel.AutoSize = true;
            this.lblHistoryLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistoryLabel.Location = new System.Drawing.Point(20, 295);
            this.lblHistoryLabel.Name = "lblHistoryLabel";
            this.lblHistoryLabel.Size = new System.Drawing.Size(121, 19);
            this.lblHistoryLabel.TabIndex = 4;
            this.lblHistoryLabel.Text = "Medical History:";
            // 
            // txtMedicalHistory
            // 
            this.txtMedicalHistory.BackColor = System.Drawing.Color.White;
            this.txtMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedicalHistory.Location = new System.Drawing.Point(20, 320);
            this.txtMedicalHistory.Multiline = true;
            this.txtMedicalHistory.Name = "txtMedicalHistory";
            this.txtMedicalHistory.ReadOnly = true;
            this.txtMedicalHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMedicalHistory.Size = new System.Drawing.Size(740, 70);
            this.txtMedicalHistory.TabIndex = 5;
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecords.Location = new System.Drawing.Point(20, 420);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecords.Size = new System.Drawing.Size(740, 150);
            this.dgvRecords.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(320, 590);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PatientDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(784, 661);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.txtMedicalHistory);
            this.Controls.Add(this.lblHistoryLabel);
            this.Controls.Add(this.txtAllergies);
            this.Controls.Add(this.lblAllergiesLabel);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PatientDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patient Details";
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}