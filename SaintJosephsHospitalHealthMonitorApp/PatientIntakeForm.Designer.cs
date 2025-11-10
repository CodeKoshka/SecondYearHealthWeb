namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PatientIntakeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblEmergency;
        private System.Windows.Forms.Label lblPatientStatus;
        private System.Windows.Forms.GroupBox grpIntakeInfo;
        private System.Windows.Forms.Label lblChiefComplaint;
        private System.Windows.Forms.TextBox txtChiefComplaint;
        private System.Windows.Forms.Label lblSymptoms;
        private System.Windows.Forms.TextBox txtSymptoms;
        private System.Windows.Forms.Label lblCurrentMeds;
        private System.Windows.Forms.TextBox txtCurrentMedications;
        private System.Windows.Forms.GroupBox grpPatientInfo;
        private System.Windows.Forms.Label lblBloodTypeInput;
        private System.Windows.Forms.ComboBox cmbBloodType;
        private System.Windows.Forms.Label lblPhoneType;
        private System.Windows.Forms.ComboBox cmbPhoneType;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmergencyContactPhoneType;
        private System.Windows.Forms.ComboBox cmbEmergencyContactPhoneType;
        private System.Windows.Forms.Label lblEmergencyContact;
        private System.Windows.Forms.TextBox txtEmergencyContact;
        private System.Windows.Forms.Label lblAllergies;
        private System.Windows.Forms.TextBox txtAllergies;
        private System.Windows.Forms.Label lblMedicalHistory;
        private System.Windows.Forms.TextBox txtMedicalHistory;
        private System.Windows.Forms.Panel panelPriorityInfo;
        private System.Windows.Forms.Label lblPriorityLabel;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriorityInfo;
        private System.Windows.Forms.Button btnSaveAndQueue;
        private System.Windows.Forms.Button btnCancel;

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
            lblPatientName = new Label();
            lblAge = new Label();
            lblBloodType = new Label();
            lblContact = new Label();
            lblEmergency = new Label();
            lblPatientStatus = new Label();
            grpIntakeInfo = new GroupBox();
            lblChiefComplaint = new Label();
            txtChiefComplaint = new TextBox();
            lblSymptoms = new Label();
            txtSymptoms = new TextBox();
            lblCurrentMeds = new Label();
            txtCurrentMedications = new TextBox();
            grpPatientInfo = new GroupBox();
            lblBloodTypeInput = new Label();
            cmbBloodType = new ComboBox();
            lblPhoneType = new Label();
            cmbPhoneType = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmergencyContactPhoneType = new Label();
            cmbEmergencyContactPhoneType = new ComboBox();
            lblEmergencyContact = new Label();
            txtEmergencyContact = new TextBox();
            lblAllergies = new Label();
            txtAllergies = new TextBox();
            lblMedicalHistory = new Label();
            txtMedicalHistory = new TextBox();
            panelPriorityInfo = new Panel();
            lblPriorityLabel = new Label();
            cmbPriority = new ComboBox();
            lblPriorityInfo = new Label();
            btnSaveAndQueue = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            grpIntakeInfo.SuspendLayout();
            grpPatientInfo.SuspendLayout();
            panelPriorityInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(26, 32, 44);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblPatientName);
            panelHeader.Controls.Add(lblAge);
            panelHeader.Controls.Add(lblBloodType);
            panelHeader.Controls.Add(lblContact);
            panelHeader.Controls.Add(lblEmergency);
            panelHeader.Controls.Add(lblPatientStatus);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1004, 150);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📋 PATIENT INTAKE - ST. JOSEPH'S CARDIAC HOSPITAL";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.White;
            lblPatientName.Location = new Point(20, 55);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(131, 21);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Patient: [Name]";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 10F);
            lblAge.ForeColor = Color.FromArgb(160, 174, 192);
            lblAge.Location = new Point(20, 85);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(127, 19);
            lblAge.TabIndex = 2;
            lblAge.Text = "Age: -- | Gender: --";
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new Font("Segoe UI", 10F);
            lblBloodType.ForeColor = Color.FromArgb(160, 174, 192);
            lblBloodType.Location = new Point(483, 85);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new Size(95, 19);
            lblBloodType.TabIndex = 3;
            lblBloodType.Text = "Blood Type: --";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 10F);
            lblContact.ForeColor = Color.FromArgb(160, 174, 192);
            lblContact.Location = new Point(20, 110);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(129, 19);
            lblContact.TabIndex = 4;
            lblContact.Text = "Phone: -- | Email: --";
            // 
            // lblEmergency
            // 
            lblEmergency.AutoSize = true;
            lblEmergency.Font = new Font("Segoe UI", 10F);
            lblEmergency.ForeColor = Color.FromArgb(160, 174, 192);
            lblEmergency.Location = new Point(483, 110);
            lblEmergency.Name = "lblEmergency";
            lblEmergency.Size = new Size(147, 19);
            lblEmergency.TabIndex = 5;
            lblEmergency.Text = "Emergency Contact: --";
            // 
            // lblPatientStatus
            // 
            lblPatientStatus.AutoSize = true;
            lblPatientStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPatientStatus.ForeColor = Color.White;
            lblPatientStatus.Location = new Point(666, 23);
            lblPatientStatus.Name = "lblPatientStatus";
            lblPatientStatus.Size = new Size(123, 20);
            lblPatientStatus.TabIndex = 6;
            lblPatientStatus.Text = "✓ Patient Status";
            // 
            // grpIntakeInfo
            // 
            grpIntakeInfo.Controls.Add(lblChiefComplaint);
            grpIntakeInfo.Controls.Add(txtChiefComplaint);
            grpIntakeInfo.Controls.Add(lblSymptoms);
            grpIntakeInfo.Controls.Add(txtSymptoms);
            grpIntakeInfo.Controls.Add(lblCurrentMeds);
            grpIntakeInfo.Controls.Add(txtCurrentMedications);
            grpIntakeInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpIntakeInfo.ForeColor = Color.FromArgb(26, 32, 44);
            grpIntakeInfo.Location = new Point(20, 160);
            grpIntakeInfo.Name = "grpIntakeInfo";
            grpIntakeInfo.Size = new Size(960, 380);
            grpIntakeInfo.TabIndex = 1;
            grpIntakeInfo.TabStop = false;
            grpIntakeInfo.Text = "Visit Information";
            // 
            // lblChiefComplaint
            // 
            lblChiefComplaint.AutoSize = true;
            lblChiefComplaint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChiefComplaint.ForeColor = Color.FromArgb(229, 62, 62);
            lblChiefComplaint.Location = new Point(15, 30);
            lblChiefComplaint.Name = "lblChiefComplaint";
            lblChiefComplaint.Size = new Size(248, 19);
            lblChiefComplaint.TabIndex = 0;
            lblChiefComplaint.Text = "* Reason for Visit / Chief Complaint:";
            // 
            // txtChiefComplaint
            // 
            txtChiefComplaint.BorderStyle = BorderStyle.FixedSingle;
            txtChiefComplaint.Font = new Font("Segoe UI", 10F);
            txtChiefComplaint.Location = new Point(15, 55);
            txtChiefComplaint.Multiline = true;
            txtChiefComplaint.Name = "txtChiefComplaint";
            txtChiefComplaint.Size = new Size(925, 80);
            txtChiefComplaint.TabIndex = 1;
            // 
            // lblSymptoms
            // 
            lblSymptoms.AutoSize = true;
            lblSymptoms.Font = new Font("Segoe UI", 10F);
            lblSymptoms.ForeColor = Color.FromArgb(74, 85, 104);
            lblSymptoms.Location = new Point(15, 145);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(128, 19);
            lblSymptoms.TabIndex = 2;
            lblSymptoms.Text = "Current Symptoms:";
            // 
            // txtSymptoms
            // 
            txtSymptoms.BorderStyle = BorderStyle.FixedSingle;
            txtSymptoms.Font = new Font("Segoe UI", 10F);
            txtSymptoms.Location = new Point(15, 170);
            txtSymptoms.Multiline = true;
            txtSymptoms.Name = "txtSymptoms";
            txtSymptoms.ScrollBars = ScrollBars.Vertical;
            txtSymptoms.Size = new Size(450, 180);
            txtSymptoms.TabIndex = 3;
            // 
            // lblCurrentMeds
            // 
            lblCurrentMeds.AutoSize = true;
            lblCurrentMeds.Font = new Font("Segoe UI", 10F);
            lblCurrentMeds.ForeColor = Color.FromArgb(74, 85, 104);
            lblCurrentMeds.Location = new Point(490, 145);
            lblCurrentMeds.Name = "lblCurrentMeds";
            lblCurrentMeds.Size = new Size(137, 19);
            lblCurrentMeds.TabIndex = 4;
            lblCurrentMeds.Text = "Current Medications:";
            // 
            // txtCurrentMedications
            // 
            txtCurrentMedications.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentMedications.Font = new Font("Segoe UI", 10F);
            txtCurrentMedications.Location = new Point(490, 170);
            txtCurrentMedications.Multiline = true;
            txtCurrentMedications.Name = "txtCurrentMedications";
            txtCurrentMedications.ScrollBars = ScrollBars.Vertical;
            txtCurrentMedications.Size = new Size(450, 180);
            txtCurrentMedications.TabIndex = 5;
            // 
            // grpPatientInfo
            // 
            grpPatientInfo.Controls.Add(lblBloodTypeInput);
            grpPatientInfo.Controls.Add(cmbBloodType);
            grpPatientInfo.Controls.Add(lblPhoneType);
            grpPatientInfo.Controls.Add(cmbPhoneType);
            grpPatientInfo.Controls.Add(lblPhone);
            grpPatientInfo.Controls.Add(txtPhone);
            grpPatientInfo.Controls.Add(lblEmergencyContactPhoneType);
            grpPatientInfo.Controls.Add(cmbEmergencyContactPhoneType);
            grpPatientInfo.Controls.Add(lblEmergencyContact);
            grpPatientInfo.Controls.Add(txtEmergencyContact);
            grpPatientInfo.Controls.Add(lblAllergies);
            grpPatientInfo.Controls.Add(txtAllergies);
            grpPatientInfo.Controls.Add(lblMedicalHistory);
            grpPatientInfo.Controls.Add(txtMedicalHistory);
            grpPatientInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPatientInfo.ForeColor = Color.FromArgb(26, 32, 44);
            grpPatientInfo.Location = new Point(20, 546);
            grpPatientInfo.Name = "grpPatientInfo";
            grpPatientInfo.Size = new Size(960, 237);
            grpPatientInfo.TabIndex = 2;
            grpPatientInfo.TabStop = false;
            grpPatientInfo.Text = "Patient Information";
            // 
            // lblBloodTypeInput
            // 
            lblBloodTypeInput.AutoSize = true;
            lblBloodTypeInput.Font = new Font("Segoe UI", 10F);
            lblBloodTypeInput.ForeColor = Color.FromArgb(74, 85, 104);
            lblBloodTypeInput.Location = new Point(15, 22);
            lblBloodTypeInput.Name = "lblBloodTypeInput";
            lblBloodTypeInput.Size = new Size(124, 19);
            lblBloodTypeInput.TabIndex = 0;
            lblBloodTypeInput.Text = "Blood Type (Opt):";
            // 
            // cmbBloodType
            // 
            cmbBloodType.BackColor = Color.White;
            cmbBloodType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBloodType.FlatStyle = FlatStyle.Flat;
            cmbBloodType.Font = new Font("Segoe UI", 10F);
            cmbBloodType.FormattingEnabled = true;
            cmbBloodType.Items.AddRange(new object[] { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" });
            cmbBloodType.Location = new Point(15, 47);
            cmbBloodType.Name = "cmbBloodType";
            cmbBloodType.Size = new Size(120, 25);
            cmbBloodType.TabIndex = 1;
            // 
            // lblPhoneType
            // 
            lblPhoneType.AutoSize = true;
            lblPhoneType.Font = new Font("Segoe UI", 10F);
            lblPhoneType.ForeColor = Color.FromArgb(74, 85, 104);
            lblPhoneType.Location = new Point(150, 22);
            lblPhoneType.Name = "lblPhoneType";
            lblPhoneType.Size = new Size(116, 19);
            lblPhoneType.TabIndex = 2;
            lblPhoneType.Text = "Phone Type (Opt):";
            // 
            // cmbPhoneType
            // 
            cmbPhoneType.BackColor = Color.White;
            cmbPhoneType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhoneType.FlatStyle = FlatStyle.Flat;
            cmbPhoneType.Font = new Font("Segoe UI", 10F);
            cmbPhoneType.FormattingEnabled = true;
            cmbPhoneType.Items.AddRange(new object[] { "Mobile", "Landline" });
            cmbPhoneType.Location = new Point(150, 47);
            cmbPhoneType.Name = "cmbPhoneType";
            cmbPhoneType.Size = new Size(120, 25);
            cmbPhoneType.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F);
            lblPhone.ForeColor = Color.FromArgb(74, 85, 104);
            lblPhone.Location = new Point(285, 22);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(205, 19);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone Number (09XXXXXXXXX):";
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(285, 47);
            txtPhone.MaxLength = 11;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(180, 25);
            txtPhone.TabIndex = 5;
            // 
            // lblEmergencyContactPhoneType
            // 
            lblEmergencyContactPhoneType.AutoSize = true;
            lblEmergencyContactPhoneType.Font = new Font("Segoe UI", 10F);
            lblEmergencyContactPhoneType.ForeColor = Color.FromArgb(74, 85, 104);
            lblEmergencyContactPhoneType.Location = new Point(490, 22);
            lblEmergencyContactPhoneType.Name = "lblEmergencyContactPhoneType";
            lblEmergencyContactPhoneType.Size = new Size(116, 19);
            lblEmergencyContactPhoneType.TabIndex = 6;
            lblEmergencyContactPhoneType.Text = "Phone Type (Opt):";
            // 
            // cmbEmergencyContactPhoneType
            // 
            cmbEmergencyContactPhoneType.BackColor = Color.White;
            cmbEmergencyContactPhoneType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmergencyContactPhoneType.FlatStyle = FlatStyle.Flat;
            cmbEmergencyContactPhoneType.Font = new Font("Segoe UI", 10F);
            cmbEmergencyContactPhoneType.FormattingEnabled = true;
            cmbEmergencyContactPhoneType.Items.AddRange(new object[] { "Mobile", "Landline" });
            cmbEmergencyContactPhoneType.Location = new Point(490, 47);
            cmbEmergencyContactPhoneType.Name = "cmbEmergencyContactPhoneType";
            cmbEmergencyContactPhoneType.Size = new Size(120, 25);
            cmbEmergencyContactPhoneType.TabIndex = 7;
            // 
            // lblEmergencyContact
            // 
            lblEmergencyContact.AutoSize = true;
            lblEmergencyContact.Font = new Font("Segoe UI", 10F);
            lblEmergencyContact.ForeColor = Color.FromArgb(74, 85, 104);
            lblEmergencyContact.Location = new Point(625, 22);
            lblEmergencyContact.Name = "lblEmergencyContact";
            lblEmergencyContact.Size = new Size(231, 19);
            lblEmergencyContact.TabIndex = 8;
            lblEmergencyContact.Text = "Emergency Contact (09XXXXXXXXX):";
            // 
            // txtEmergencyContact
            // 
            txtEmergencyContact.BorderStyle = BorderStyle.FixedSingle;
            txtEmergencyContact.Font = new Font("Segoe UI", 10F);
            txtEmergencyContact.Location = new Point(625, 47);
            txtEmergencyContact.MaxLength = 11;
            txtEmergencyContact.Name = "txtEmergencyContact";
            txtEmergencyContact.Size = new Size(315, 25);
            txtEmergencyContact.TabIndex = 9;
            // 
            // lblAllergies
            // 
            lblAllergies.AutoSize = true;
            lblAllergies.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAllergies.ForeColor = Color.FromArgb(255, 193, 7);
            lblAllergies.Location = new Point(15, 82);
            lblAllergies.Name = "lblAllergies";
            lblAllergies.Size = new Size(145, 19);
            lblAllergies.TabIndex = 10;
            lblAllergies.Text = "⚠️ Known Allergies:";
            // 
            // txtAllergies
            // 
            txtAllergies.BorderStyle = BorderStyle.FixedSingle;
            txtAllergies.Font = new Font("Segoe UI", 10F);
            txtAllergies.Location = new Point(15, 107);
            txtAllergies.Multiline = true;
            txtAllergies.Name = "txtAllergies";
            txtAllergies.ScrollBars = ScrollBars.Vertical;
            txtAllergies.Size = new Size(450, 114);
            txtAllergies.TabIndex = 11;
            // 
            // lblMedicalHistory
            // 
            lblMedicalHistory.AutoSize = true;
            lblMedicalHistory.Font = new Font("Segoe UI", 10F);
            lblMedicalHistory.ForeColor = Color.FromArgb(74, 85, 104);
            lblMedicalHistory.Location = new Point(490, 82);
            lblMedicalHistory.Name = "lblMedicalHistory";
            lblMedicalHistory.Size = new Size(107, 19);
            lblMedicalHistory.TabIndex = 12;
            lblMedicalHistory.Text = "Medical History:";
            // 
            // txtMedicalHistory
            // 
            txtMedicalHistory.BorderStyle = BorderStyle.FixedSingle;
            txtMedicalHistory.Font = new Font("Segoe UI", 10F);
            txtMedicalHistory.Location = new Point(490, 107);
            txtMedicalHistory.Multiline = true;
            txtMedicalHistory.Name = "txtMedicalHistory";
            txtMedicalHistory.ScrollBars = ScrollBars.Vertical;
            txtMedicalHistory.Size = new Size(450, 114);
            txtMedicalHistory.TabIndex = 13;
            // 
            // panelPriorityInfo
            // 
            panelPriorityInfo.BackColor = Color.FromArgb(72, 187, 120);
            panelPriorityInfo.Controls.Add(lblPriorityLabel);
            panelPriorityInfo.Controls.Add(cmbPriority);
            panelPriorityInfo.Controls.Add(lblPriorityInfo);
            panelPriorityInfo.Location = new Point(20, 789);
            panelPriorityInfo.Name = "panelPriorityInfo";
            panelPriorityInfo.Size = new Size(960, 70);
            panelPriorityInfo.TabIndex = 3;
            // 
            // lblPriorityLabel
            // 
            lblPriorityLabel.AutoSize = true;
            lblPriorityLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPriorityLabel.ForeColor = Color.White;
            lblPriorityLabel.Location = new Point(15, 15);
            lblPriorityLabel.Name = "lblPriorityLabel";
            lblPriorityLabel.Size = new Size(103, 19);
            lblPriorityLabel.TabIndex = 0;
            lblPriorityLabel.Text = "Priority Level:";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.Font = new Font("Segoe UI", 10F);
            cmbPriority.Items.AddRange(new object[] { "Normal", "Urgent", "Emergency" });
            cmbPriority.Location = new Point(130, 12);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(150, 25);
            cmbPriority.TabIndex = 1;
            cmbPriority.SelectedIndexChanged += CmbPriority_SelectedIndexChanged;
            // 
            // lblPriorityInfo
            // 
            lblPriorityInfo.AutoSize = true;
            lblPriorityInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPriorityInfo.ForeColor = Color.White;
            lblPriorityInfo.Location = new Point(15, 45);
            lblPriorityInfo.Name = "lblPriorityInfo";
            lblPriorityInfo.Size = new Size(206, 19);
            lblPriorityInfo.TabIndex = 2;
            lblPriorityInfo.Text = "✓ Standard queue processing";
            // 
            // btnSaveAndQueue
            // 
            btnSaveAndQueue.BackColor = Color.FromArgb(66, 153, 225);
            btnSaveAndQueue.Cursor = Cursors.Hand;
            btnSaveAndQueue.FlatAppearance.BorderSize = 0;
            btnSaveAndQueue.FlatStyle = FlatStyle.Flat;
            btnSaveAndQueue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSaveAndQueue.ForeColor = Color.White;
            btnSaveAndQueue.Location = new Point(20, 874);
            btnSaveAndQueue.Name = "btnSaveAndQueue";
            btnSaveAndQueue.Size = new Size(650, 50);
            btnSaveAndQueue.TabIndex = 4;
            btnSaveAndQueue.Text = "✓ SAVE & ADD TO QUEUE";
            btnSaveAndQueue.UseVisualStyleBackColor = false;
            btnSaveAndQueue.Click += BtnSaveAndQueue_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(113, 128, 150);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(680, 874);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(300, 50);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "❌ CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // PatientIntakeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(1004, 933);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveAndQueue);
            Controls.Add(panelPriorityInfo);
            Controls.Add(grpPatientInfo);
            Controls.Add(grpIntakeInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PatientIntakeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Patient Intake Form - St. Joseph's Cardiac Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpIntakeInfo.ResumeLayout(false);
            grpIntakeInfo.PerformLayout();
            grpPatientInfo.ResumeLayout(false);
            grpPatientInfo.PerformLayout();
            panelPriorityInfo.ResumeLayout(false);
            panelPriorityInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}