
namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class EditMedicalRecordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblRecordDate;
        private System.Windows.Forms.Label lblPatientAge;
        private System.Windows.Forms.Label lblPatientGender;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblAllergies;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabClinicalNotes;
        private System.Windows.Forms.TabPage tabPrescription;

        private System.Windows.Forms.Label lblVisitType;
        private System.Windows.Forms.ComboBox cmbVisitType;
        private System.Windows.Forms.Label lblChiefComplaint;
        private System.Windows.Forms.TextBox txtChiefComplaint;
        private System.Windows.Forms.Label lblVitalSigns;
        private System.Windows.Forms.TextBox txtVitalSigns;
        private System.Windows.Forms.Label lblPhysicalExam;
        private System.Windows.Forms.TextBox txtPhysicalExam;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblTreatmentPlan;
        private System.Windows.Forms.TextBox txtTreatmentPlan;
        private System.Windows.Forms.Label lblFollowUp;
        private System.Windows.Forms.TextBox txtFollowUp;

        private System.Windows.Forms.Button btnTemplateRoutine;
        private System.Windows.Forms.Button btnTemplateEmergency;

        private System.Windows.Forms.Label lblPrescription;
        private System.Windows.Forms.TextBox txtPrescription;
        private System.Windows.Forms.Label lblLabTests;
        private System.Windows.Forms.TextBox txtLabTests;

        private System.Windows.Forms.Button btnSave;
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblRecordDate = new System.Windows.Forms.Label();
            this.lblPatientAge = new System.Windows.Forms.Label();
            this.lblPatientGender = new System.Windows.Forms.Label();
            this.lblBloodType = new System.Windows.Forms.Label();
            this.lblAllergies = new System.Windows.Forms.Label();

            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabClinicalNotes = new System.Windows.Forms.TabPage();
            this.tabPrescription = new System.Windows.Forms.TabPage();

            this.lblVisitType = new System.Windows.Forms.Label();
            this.cmbVisitType = new System.Windows.Forms.ComboBox();
            this.lblChiefComplaint = new System.Windows.Forms.Label();
            this.txtChiefComplaint = new System.Windows.Forms.TextBox();
            this.lblVitalSigns = new System.Windows.Forms.Label();
            this.txtVitalSigns = new System.Windows.Forms.TextBox();
            this.lblPhysicalExam = new System.Windows.Forms.Label();
            this.txtPhysicalExam = new System.Windows.Forms.TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblTreatmentPlan = new System.Windows.Forms.Label();
            this.txtTreatmentPlan = new System.Windows.Forms.TextBox();
            this.lblFollowUp = new System.Windows.Forms.Label();
            this.txtFollowUp = new System.Windows.Forms.TextBox();

            this.btnTemplateRoutine = new System.Windows.Forms.Button();
            this.btnTemplateEmergency = new System.Windows.Forms.Button();

            this.lblPrescription = new System.Windows.Forms.Label();
            this.txtPrescription = new System.Windows.Forms.TextBox();
            this.lblLabTests = new System.Windows.Forms.Label();
            this.txtLabTests = new System.Windows.Forms.TextBox();

            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabClinicalNotes.SuspendLayout();
            this.tabPrescription.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(153)))), ((int)(((byte)(225)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblPatientName);
            this.panelHeader.Controls.Add(this.lblRecordDate);
            this.panelHeader.Controls.Add(this.lblPatientAge);
            this.panelHeader.Controls.Add(this.lblPatientGender);
            this.panelHeader.Controls.Add(this.lblBloodType);
            this.panelHeader.Controls.Add(this.lblAllergies);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 150);
            this.panelHeader.TabIndex = 0;

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(341, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ EDIT MEDICAL RECORD";

            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.ForeColor = System.Drawing.Color.White;
            this.lblPatientName.Location = new System.Drawing.Point(20, 55);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(150, 21);
            this.lblPatientName.TabIndex = 1;
            this.lblPatientName.Text = "Patient: [Name]";

            // 
            // lblRecordDate
            // 
            this.lblRecordDate.AutoSize = true;
            this.lblRecordDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblRecordDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblRecordDate.Location = new System.Drawing.Point(400, 58);
            this.lblRecordDate.Name = "lblRecordDate";
            this.lblRecordDate.Size = new System.Drawing.Size(150, 19);
            this.lblRecordDate.TabIndex = 2;
            this.lblRecordDate.Text = "Record Date: [Date]";

            // 
            // lblPatientAge
            // 
            this.lblPatientAge.AutoSize = true;
            this.lblPatientAge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPatientAge.Location = new System.Drawing.Point(20, 90);
            this.lblPatientAge.Name = "lblPatientAge";
            this.lblPatientAge.Size = new System.Drawing.Size(50, 19);
            this.lblPatientAge.TabIndex = 3;
            this.lblPatientAge.Text = "Age: --";

            // 
            // lblPatientGender
            // 
            this.lblPatientGender.AutoSize = true;
            this.lblPatientGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPatientGender.Location = new System.Drawing.Point(120, 90);
            this.lblPatientGender.Name = "lblPatientGender";
            this.lblPatientGender.Size = new System.Drawing.Size(75, 19);
            this.lblPatientGender.TabIndex = 4;
            this.lblPatientGender.Text = "Gender: --";

            // 
            // lblBloodType
            // 
            this.lblBloodType.AutoSize = true;
            this.lblBloodType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBloodType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBloodType.Location = new System.Drawing.Point(250, 90);
            this.lblBloodType.Name = "lblBloodType";
            this.lblBloodType.Size = new System.Drawing.Size(100, 19);
            this.lblBloodType.TabIndex = 5;
            this.lblBloodType.Text = "Blood Type: --";

            // 
            // lblAllergies
            // 
            this.lblAllergies.AutoSize = true;
            this.lblAllergies.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAllergies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(102)))));
            this.lblAllergies.Location = new System.Drawing.Point(20, 120);
            this.lblAllergies.Name = "lblAllergies";
            this.lblAllergies.Size = new System.Drawing.Size(180, 19);
            this.lblAllergies.TabIndex = 6;
            this.lblAllergies.Text = "⚠️ Known Allergies: None";

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabClinicalNotes);
            this.tabControl.Controls.Add(this.tabPrescription);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(15, 160);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(970, 460);
            this.tabControl.TabIndex = 1;

            // 
            // tabClinicalNotes
            // 
            this.tabClinicalNotes.AutoScroll = true;
            this.tabClinicalNotes.BackColor = System.Drawing.Color.White;
            this.tabClinicalNotes.Controls.Add(this.lblVisitType);
            this.tabClinicalNotes.Controls.Add(this.cmbVisitType);
            this.tabClinicalNotes.Controls.Add(this.btnTemplateRoutine);
            this.tabClinicalNotes.Controls.Add(this.btnTemplateEmergency);
            this.tabClinicalNotes.Controls.Add(this.lblChiefComplaint);
            this.tabClinicalNotes.Controls.Add(this.txtChiefComplaint);
            this.tabClinicalNotes.Controls.Add(this.lblVitalSigns);
            this.tabClinicalNotes.Controls.Add(this.txtVitalSigns);
            this.tabClinicalNotes.Controls.Add(this.lblPhysicalExam);
            this.tabClinicalNotes.Controls.Add(this.txtPhysicalExam);
            this.tabClinicalNotes.Controls.Add(this.lblDiagnosis);
            this.tabClinicalNotes.Controls.Add(this.txtDiagnosis);
            this.tabClinicalNotes.Controls.Add(this.lblTreatmentPlan);
            this.tabClinicalNotes.Controls.Add(this.txtTreatmentPlan);
            this.tabClinicalNotes.Controls.Add(this.lblFollowUp);
            this.tabClinicalNotes.Controls.Add(this.txtFollowUp);
            this.tabClinicalNotes.Location = new System.Drawing.Point(4, 26);
            this.tabClinicalNotes.Name = "tabClinicalNotes";
            this.tabClinicalNotes.Padding = new System.Windows.Forms.Padding(20);
            this.tabClinicalNotes.Size = new System.Drawing.Size(962, 430);
            this.tabClinicalNotes.TabIndex = 0;
            this.tabClinicalNotes.Text = "📝 Clinical Assessment";

            // 
            // lblVisitType
            // 
            this.lblVisitType.AutoSize = true;
            this.lblVisitType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVisitType.Location = new System.Drawing.Point(20, 20);
            this.lblVisitType.Name = "lblVisitType";
            this.lblVisitType.Size = new System.Drawing.Size(82, 19);
            this.lblVisitType.TabIndex = 0;
            this.lblVisitType.Text = "Visit Type:";

            // 
            // cmbVisitType
            // 
            this.cmbVisitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVisitType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbVisitType.FormattingEnabled = true;
            this.cmbVisitType.Items.AddRange(new object[] {
            "Consultation",
            "Follow-up",
            "Emergency",
            "Routine Check-up",
            "Surgical Procedure",
            "Laboratory Follow-up",
            "Vaccination",
            "Other"});
            this.cmbVisitType.Location = new System.Drawing.Point(20, 45);
            this.cmbVisitType.Name = "cmbVisitType";
            this.cmbVisitType.Size = new System.Drawing.Size(250, 25);
            this.cmbVisitType.TabIndex = 1;

            // 
            // btnTemplateRoutine
            // 
            this.btnTemplateRoutine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(153)))), ((int)(((byte)(225)))));
            this.btnTemplateRoutine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemplateRoutine.FlatAppearance.BorderSize = 0;
            this.btnTemplateRoutine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateRoutine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTemplateRoutine.ForeColor = System.Drawing.Color.White;
            this.btnTemplateRoutine.Location = new System.Drawing.Point(300, 20);
            this.btnTemplateRoutine.Name = "btnTemplateRoutine";
            this.btnTemplateRoutine.Size = new System.Drawing.Size(140, 30);
            this.btnTemplateRoutine.TabIndex = 2;
            this.btnTemplateRoutine.Text = "📋 Routine Template";
            this.btnTemplateRoutine.UseVisualStyleBackColor = false;
            this.btnTemplateRoutine.Click += new System.EventHandler(this.BtnTemplateRoutine_Click);

            // 
            // btnTemplateEmergency
            // 
            this.btnTemplateEmergency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnTemplateEmergency.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTemplateEmergency.FlatAppearance.BorderSize = 0;
            this.btnTemplateEmergency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateEmergency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTemplateEmergency.ForeColor = System.Drawing.Color.White;
            this.btnTemplateEmergency.Location = new System.Drawing.Point(300, 55);
            this.btnTemplateEmergency.Name = "btnTemplateEmergency";
            this.btnTemplateEmergency.Size = new System.Drawing.Size(140, 30);
            this.btnTemplateEmergency.TabIndex = 3;
            this.btnTemplateEmergency.Text = "🚨 Emergency";
            this.btnTemplateEmergency.UseVisualStyleBackColor = false;
            this.btnTemplateEmergency.Click += new System.EventHandler(this.BtnTemplateEmergency_Click);

            // Similar controls as MedicalRecordForm for remaining fields
            // lblChiefComplaint, txtChiefComplaint, etc...

            // 
            // lblChiefComplaint
            // 
            this.lblChiefComplaint.AutoSize = true;
            this.lblChiefComplaint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChiefComplaint.Location = new System.Drawing.Point(20, 95);
            this.lblChiefComplaint.Name = "lblChiefComplaint";
            this.lblChiefComplaint.Size = new System.Drawing.Size(229, 19);
            this.lblChiefComplaint.TabIndex = 4;
            this.lblChiefComplaint.Text = "Chief Complaint / Reason for Visit:";

            // 
            // txtChiefComplaint
            // 
            this.txtChiefComplaint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChiefComplaint.Location = new System.Drawing.Point(20, 120);
            this.txtChiefComplaint.Multiline = true;
            this.txtChiefComplaint.Name = "txtChiefComplaint";
            this.txtChiefComplaint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChiefComplaint.Size = new System.Drawing.Size(900, 60);
            this.txtChiefComplaint.TabIndex = 5;

            // (Continue with remaining controls - txtVitalSigns, txtPhysicalExam, txtDiagnosis, etc.)
            // Using same layout as MedicalRecordForm

            // 
            // lblVitalSigns
            // 
            this.lblVitalSigns.AutoSize = true;
            this.lblVitalSigns.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVitalSigns.Location = new System.Drawing.Point(20, 195);
            this.lblVitalSigns.Name = "lblVitalSigns";
            this.lblVitalSigns.Size = new System.Drawing.Size(87, 19);
            this.lblVitalSigns.TabIndex = 6;
            this.lblVitalSigns.Text = "Vital Signs:";

            // 
            // txtVitalSigns
            // 
            this.txtVitalSigns.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtVitalSigns.Location = new System.Drawing.Point(20, 220);
            this.txtVitalSigns.Multiline = true;
            this.txtVitalSigns.Name = "txtVitalSigns";
            this.txtVitalSigns.Size = new System.Drawing.Size(900, 45);
            this.txtVitalSigns.TabIndex = 7;

            // 
            // lblPhysicalExam
            // 
            this.lblPhysicalExam.AutoSize = true;
            this.lblPhysicalExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPhysicalExam.Location = new System.Drawing.Point(20, 280);
            this.lblPhysicalExam.Name = "lblPhysicalExam";
            this.lblPhysicalExam.Size = new System.Drawing.Size(154, 19);
            this.lblPhysicalExam.TabIndex = 8;
            this.lblPhysicalExam.Text = "Physical Examination:";

            // 
            // txtPhysicalExam
            // 
            this.txtPhysicalExam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhysicalExam.Location = new System.Drawing.Point(20, 305);
            this.txtPhysicalExam.Multiline = true;
            this.txtPhysicalExam.Name = "txtPhysicalExam";
            this.txtPhysicalExam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhysicalExam.Size = new System.Drawing.Size(900, 100);
            this.txtPhysicalExam.TabIndex = 9;

            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(20, 420);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(167, 19);
            this.lblDiagnosis.TabIndex = 10;
            this.lblDiagnosis.Text = "* Diagnosis / ICD Code:";

            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiagnosis.Location = new System.Drawing.Point(20, 445);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(900, 80);
            this.txtDiagnosis.TabIndex = 11;

            // 
            // lblTreatmentPlan
            // 
            this.lblTreatmentPlan.AutoSize = true;
            this.lblTreatmentPlan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTreatmentPlan.Location = new System.Drawing.Point(20, 540);
            this.lblTreatmentPlan.Name = "lblTreatmentPlan";
            this.lblTreatmentPlan.Size = new System.Drawing.Size(116, 19);
            this.lblTreatmentPlan.TabIndex = 12;
            this.lblTreatmentPlan.Text = "Treatment Plan:";

            // 
            // txtTreatmentPlan
            // 
            this.txtTreatmentPlan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTreatmentPlan.Location = new System.Drawing.Point(20, 565);
            this.txtTreatmentPlan.Multiline = true;
            this.txtTreatmentPlan.Name = "txtTreatmentPlan";
            this.txtTreatmentPlan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTreatmentPlan.Size = new System.Drawing.Size(900, 80);
            this.txtTreatmentPlan.TabIndex = 13;

            // 
            // lblFollowUp
            // 
            this.lblFollowUp.AutoSize = true;
            this.lblFollowUp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFollowUp.Location = new System.Drawing.Point(20, 660);
            this.lblFollowUp.Name = "lblFollowUp";
            this.lblFollowUp.Size = new System.Drawing.Size(172, 19);
            this.lblFollowUp.TabIndex = 14;
            this.lblFollowUp.Text = "Follow-up Instructions:";

            // 
            // txtFollowUp
            // 
            this.txtFollowUp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFollowUp.Location = new System.Drawing.Point(20, 685);
            this.txtFollowUp.Multiline = true;
            this.txtFollowUp.Name = "txtFollowUp";
            this.txtFollowUp.Size = new System.Drawing.Size(900, 60);
            this.txtFollowUp.TabIndex = 15;

            // 
            // tabPrescription
            // 
            this.tabPrescription.BackColor = System.Drawing.Color.White;
            this.tabPrescription.Controls.Add(this.lblPrescription);
            this.tabPrescription.Controls.Add(this.txtPrescription);
            this.tabPrescription.Controls.Add(this.lblLabTests);
            this.tabPrescription.Controls.Add(this.txtLabTests);
            this.tabPrescription.Location = new System.Drawing.Point(4, 26);
            this.tabPrescription.Name = "tabPrescription";
            this.tabPrescription.Padding = new System.Windows.Forms.Padding(20);
            this.tabPrescription.Size = new System.Drawing.Size(962, 430);
            this.tabPrescription.TabIndex = 1;
            this.tabPrescription.Text = "💊 Prescription & Labs";

            // 
            // lblPrescription
            // 
            this.lblPrescription.AutoSize = true;
            this.lblPrescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrescription.Location = new System.Drawing.Point(20, 20);
            this.lblPrescription.Name = "lblPrescription";
            this.lblPrescription.Size = new System.Drawing.Size(270, 20);
            this.lblPrescription.TabIndex = 0;
            this.lblPrescription.Text = "Prescription (Rx) / Medication Orders:";

            // 
            // txtPrescription
            // 
            this.txtPrescription.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtPrescription.Location = new System.Drawing.Point(20, 50);
            this.txtPrescription.Multiline = true;
            this.txtPrescription.Name = "txtPrescription";
            this.txtPrescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrescription.Size = new System.Drawing.Size(920, 160);
            this.txtPrescription.TabIndex = 1;

            // 
            // lblLabTests
            // 
            this.lblLabTests.AutoSize = true;
            this.lblLabTests.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLabTests.Location = new System.Drawing.Point(20, 225);
            this.lblLabTests.Name = "lblLabTests";
            this.lblLabTests.Size = new System.Drawing.Size(234, 20);
            this.lblLabTests.TabIndex = 2;
            this.lblLabTests.Text = "Laboratory Tests / Procedures:";

            // 
            // txtLabTests
            // 
            this.txtLabTests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLabTests.Location = new System.Drawing.Point(20, 255);
            this.txtLabTests.Multiline = true;
            this.txtLabTests.Name = "txtLabTests";
            this.txtLabTests.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLabTests.Size = new System.Drawing.Size(920, 155);
            this.txtLabTests.TabIndex = 3;

            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(15, 635);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(480, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "💾 SAVE CHANGES";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(505, 635);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(480, 50);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "❌ CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // 
            // EditMedicalRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditMedicalRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "St. Joseph's Hospital - Edit Medical Record";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabClinicalNotes.ResumeLayout(false);
            this.tabClinicalNotes.PerformLayout();
            this.tabPrescription.ResumeLayout(false);
            this.tabPrescription.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}