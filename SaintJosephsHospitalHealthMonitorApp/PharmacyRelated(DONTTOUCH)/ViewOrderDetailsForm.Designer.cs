
namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ViewOrderDetailsForm
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
            lblTitle = new Label();
            lblOrderIdTitle = new Label();
            lblOrderIdValue = new Label();
            grpPatient = new GroupBox();
            lblPatientName = new Label();
            lblPatientValue = new Label();
            lblPatientId = new Label();
            lblPatientIdValue = new Label();
            grpDoctor = new GroupBox();
            lblDoctor = new Label();
            lblDoctorValue = new Label();
            grpMedication = new GroupBox();
            lblMedicine = new Label();
            lblMedicineValue = new Label();
            lblDosage = new Label();
            lblDosageValue = new Label();
            lblFrequency = new Label();
            lblFrequencyValue = new Label();
            lblQuantity = new Label();
            lblQuantityValue = new Label();
            grpStatus = new GroupBox();
            lblStatus = new Label();
            lblStatusValue = new Label();
            lblPriority = new Label();
            lblPriorityValue = new Label();
            lblOrderDate = new Label();
            lblOrderDateValue = new Label();
            btnClose = new Button();
            grpPatient.SuspendLayout();
            grpDoctor.SuspendLayout();
            grpMedication.SuspendLayout();
            grpStatus.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(282, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Medication Order Details";
            // 
            // lblOrderIdTitle
            // 
            lblOrderIdTitle.AutoSize = true;
            lblOrderIdTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblOrderIdTitle.Location = new System.Drawing.Point(20, 70);
            lblOrderIdTitle.Name = "lblOrderIdTitle";
            lblOrderIdTitle.Size = new System.Drawing.Size(72, 19);
            lblOrderIdTitle.TabIndex = 1;
            lblOrderIdTitle.Text = "Order ID:";
            // 
            // lblOrderIdValue
            // 
            lblOrderIdValue.AutoSize = true;
            lblOrderIdValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblOrderIdValue.Location = new System.Drawing.Point(150, 70);
            lblOrderIdValue.Name = "lblOrderIdValue";
            lblOrderIdValue.Size = new System.Drawing.Size(17, 19);
            lblOrderIdValue.TabIndex = 2;
            lblOrderIdValue.Text = "0";
            // 
            // grpPatient
            // 
            grpPatient.Controls.Add(lblPatientName);
            grpPatient.Controls.Add(lblPatientValue);
            grpPatient.Controls.Add(lblPatientId);
            grpPatient.Controls.Add(lblPatientIdValue);
            grpPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grpPatient.Location = new System.Drawing.Point(20, 110);
            grpPatient.Name = "grpPatient";
            grpPatient.Size = new System.Drawing.Size(640, 100);
            grpPatient.TabIndex = 3;
            grpPatient.TabStop = false;
            grpPatient.Text = "Patient Information";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPatientName.Location = new System.Drawing.Point(15, 30);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new System.Drawing.Size(42, 15);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Name:";
            // 
            // lblPatientValue
            // 
            lblPatientValue.AutoSize = true;
            lblPatientValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPatientValue.Location = new System.Drawing.Point(120, 30);
            lblPatientValue.Name = "lblPatientValue";
            lblPatientValue.Size = new System.Drawing.Size(12, 15);
            lblPatientValue.TabIndex = 1;
            lblPatientValue.Text = "-";
            // 
            // lblPatientId
            // 
            lblPatientId.AutoSize = true;
            lblPatientId.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPatientId.Location = new System.Drawing.Point(15, 60);
            lblPatientId.Name = "lblPatientId";
            lblPatientId.Size = new System.Drawing.Size(62, 15);
            lblPatientId.TabIndex = 2;
            lblPatientId.Text = "Patient ID:";
            // 
            // lblPatientIdValue
            // 
            lblPatientIdValue.AutoSize = true;
            lblPatientIdValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPatientIdValue.Location = new System.Drawing.Point(120, 60);
            lblPatientIdValue.Name = "lblPatientIdValue";
            lblPatientIdValue.Size = new System.Drawing.Size(12, 15);
            lblPatientIdValue.TabIndex = 3;
            lblPatientIdValue.Text = "-";
            // 
            // grpDoctor
            // 
            grpDoctor.Controls.Add(lblDoctor);
            grpDoctor.Controls.Add(lblDoctorValue);
            grpDoctor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grpDoctor.Location = new System.Drawing.Point(20, 220);
            grpDoctor.Name = "grpDoctor";
            grpDoctor.Size = new System.Drawing.Size(640, 70);
            grpDoctor.TabIndex = 4;
            grpDoctor.TabStop = false;
            grpDoctor.Text = "Prescribing Doctor";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDoctor.Location = new System.Drawing.Point(15, 30);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new System.Drawing.Size(47, 15);
            lblDoctor.TabIndex = 0;
            lblDoctor.Text = "Doctor:";
            // 
            // lblDoctorValue
            // 
            lblDoctorValue.AutoSize = true;
            lblDoctorValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDoctorValue.Location = new System.Drawing.Point(120, 30);
            lblDoctorValue.Name = "lblDoctorValue";
            lblDoctorValue.Size = new System.Drawing.Size(12, 15);
            lblDoctorValue.TabIndex = 1;
            lblDoctorValue.Text = "-";
            // 
            // grpMedication
            // 
            grpMedication.Controls.Add(lblMedicine);
            grpMedication.Controls.Add(lblMedicineValue);
            grpMedication.Controls.Add(lblDosage);
            grpMedication.Controls.Add(lblDosageValue);
            grpMedication.Controls.Add(lblFrequency);
            grpMedication.Controls.Add(lblFrequencyValue);
            grpMedication.Controls.Add(lblQuantity);
            grpMedication.Controls.Add(lblQuantityValue);
            grpMedication.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grpMedication.Location = new System.Drawing.Point(20, 300);
            grpMedication.Name = "grpMedication";
            grpMedication.Size = new System.Drawing.Size(640, 160);
            grpMedication.TabIndex = 5;
            grpMedication.TabStop = false;
            grpMedication.Text = "Medication Details";
            // 
            // lblMedicine
            // 
            lblMedicine.AutoSize = true;
            lblMedicine.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblMedicine.Location = new System.Drawing.Point(15, 30);
            lblMedicine.Name = "lblMedicine";
            lblMedicine.Size = new System.Drawing.Size(60, 15);
            lblMedicine.TabIndex = 0;
            lblMedicine.Text = "Medicine:";
            // 
            // lblMedicineValue
            // 
            lblMedicineValue.AutoSize = true;
            lblMedicineValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMedicineValue.Location = new System.Drawing.Point(120, 30);
            lblMedicineValue.Name = "lblMedicineValue";
            lblMedicineValue.Size = new System.Drawing.Size(12, 15);
            lblMedicineValue.TabIndex = 1;
            lblMedicineValue.Text = "-";
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDosage.Location = new System.Drawing.Point(15, 60);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new System.Drawing.Size(50, 15);
            lblDosage.TabIndex = 2;
            lblDosage.Text = "Dosage:";
            // 
            // lblDosageValue
            // 
            lblDosageValue.AutoSize = true;
            lblDosageValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDosageValue.Location = new System.Drawing.Point(120, 60);
            lblDosageValue.Name = "lblDosageValue";
            lblDosageValue.Size = new System.Drawing.Size(12, 15);
            lblDosageValue.TabIndex = 3;
            lblDosageValue.Text = "-";
            // 
            // lblFrequency
            // 
            lblFrequency.AutoSize = true;
            lblFrequency.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFrequency.Location = new System.Drawing.Point(15, 90);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new System.Drawing.Size(64, 15);
            lblFrequency.TabIndex = 4;
            lblFrequency.Text = "Frequency:";
            // 
            // lblFrequencyValue
            // 
            lblFrequencyValue.AutoSize = true;
            lblFrequencyValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblFrequencyValue.Location = new System.Drawing.Point(120, 90);
            lblFrequencyValue.Name = "lblFrequencyValue";
            lblFrequencyValue.Size = new System.Drawing.Size(12, 15);
            lblFrequencyValue.TabIndex = 5;
            lblFrequencyValue.Text = "-";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblQuantity.Location = new System.Drawing.Point(15, 120);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(56, 15);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity:";
            // 
            // lblQuantityValue
            // 
            lblQuantityValue.AutoSize = true;
            lblQuantityValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblQuantityValue.Location = new System.Drawing.Point(120, 120);
            lblQuantityValue.Name = "lblQuantityValue";
            lblQuantityValue.Size = new System.Drawing.Size(12, 15);
            lblQuantityValue.TabIndex = 7;
            lblQuantityValue.Text = "-";
            // 
            // grpStatus
            // 
            grpStatus.Controls.Add(lblStatus);
            grpStatus.Controls.Add(lblStatusValue);
            grpStatus.Controls.Add(lblPriority);
            grpStatus.Controls.Add(lblPriorityValue);
            grpStatus.Controls.Add(lblOrderDate);
            grpStatus.Controls.Add(lblOrderDateValue);
            grpStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            grpStatus.Location = new System.Drawing.Point(20, 470);
            grpStatus.Name = "grpStatus";
            grpStatus.Size = new System.Drawing.Size(640, 100);
            grpStatus.TabIndex = 6;
            grpStatus.TabStop = false;
            grpStatus.Text = "Order Status && Timeline";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStatus.Location = new System.Drawing.Point(15, 30);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(42, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStatusValue.Location = new System.Drawing.Point(120, 30);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new System.Drawing.Size(12, 15);
            lblStatusValue.TabIndex = 1;
            lblStatusValue.Text = "-";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPriority.Location = new System.Drawing.Point(300, 30);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new System.Drawing.Size(48, 15);
            lblPriority.TabIndex = 2;
            lblPriority.Text = "Priority:";
            // 
            // lblPriorityValue
            // 
            lblPriorityValue.AutoSize = true;
            lblPriorityValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPriorityValue.Location = new System.Drawing.Point(380, 30);
            lblPriorityValue.Name = "lblPriorityValue";
            lblPriorityValue.Size = new System.Drawing.Size(12, 15);
            lblPriorityValue.TabIndex = 3;
            lblPriorityValue.Text = "-";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOrderDate.Location = new System.Drawing.Point(15, 60);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new System.Drawing.Size(68, 15);
            lblOrderDate.TabIndex = 4;
            lblOrderDate.Text = "Order Date:";
            // 
            // lblOrderDateValue
            // 
            lblOrderDateValue.AutoSize = true;
            lblOrderDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblOrderDateValue.Location = new System.Drawing.Point(120, 60);
            lblOrderDateValue.Name = "lblOrderDateValue";
            lblOrderDateValue.Size = new System.Drawing.Size(12, 15);
            lblOrderDateValue.TabIndex = 5;
            lblOrderDateValue.Text = "-";
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(560, 575);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(100, 35);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(BtnClose_Click);
            // 
            // ViewOrderDetailsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            ClientSize = new System.Drawing.Size(684, 621);
            Controls.Add(btnClose);
            Controls.Add(grpStatus);
            Controls.Add(grpMedication);
            Controls.Add(grpDoctor);
            Controls.Add(grpPatient);
            Controls.Add(lblOrderIdValue);
            Controls.Add(lblOrderIdTitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ViewOrderDetailsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Order Details";
            grpPatient.ResumeLayout(false);
            grpPatient.PerformLayout();
            grpDoctor.ResumeLayout(false);
            grpDoctor.PerformLayout();
            grpMedication.ResumeLayout(false);
            grpMedication.PerformLayout();
            grpStatus.ResumeLayout(false);
            grpStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblOrderIdTitle;
        private Label lblOrderIdValue;
        private GroupBox grpPatient;
        private Label lblPatientName;
        private Label lblPatientValue;
        private Label lblPatientId;
        private Label lblPatientIdValue;
        private GroupBox grpDoctor;
        private Label lblDoctor;
        private Label lblDoctorValue;
        private GroupBox grpMedication;
        private Label lblMedicine;
        private Label lblMedicineValue;
        private Label lblDosage;
        private Label lblDosageValue;
        private Label lblFrequency;
        private Label lblFrequencyValue;
        private Label lblQuantity;
        private Label lblQuantityValue;
        private GroupBox grpStatus;
        private Label lblStatus;
        private Label lblStatusValue;
        private Label lblPriority;
        private Label lblPriorityValue;
        private Label lblOrderDate;
        private Label lblOrderDateValue;
        private Button btnClose;
    }
}