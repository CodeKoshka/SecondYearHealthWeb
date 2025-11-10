
namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ViewOrderDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOrderIdTitle;
        private System.Windows.Forms.Label lblOrderIdValue;
        private System.Windows.Forms.GroupBox grpPatient;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientValue;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.Label lblPatientIdValue;
        private System.Windows.Forms.GroupBox grpDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblDoctorValue;
        private System.Windows.Forms.GroupBox grpMedication;
        private System.Windows.Forms.Label lblMedicine;
        private System.Windows.Forms.Label lblMedicineValue;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.Label lblDosageValue;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label lblFrequencyValue;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblQuantityValue;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblPriorityValue;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblOrderDateValue;
        private System.Windows.Forms.Button btnClose;

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
            this.lblOrderIdTitle = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.grpPatient = new System.Windows.Forms.GroupBox();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPatientValue = new System.Windows.Forms.Label();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.lblPatientIdValue = new System.Windows.Forms.Label();
            this.grpDoctor = new System.Windows.Forms.GroupBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblDoctorValue = new System.Windows.Forms.Label();
            this.grpMedication = new System.Windows.Forms.GroupBox();
            this.lblMedicine = new System.Windows.Forms.Label();
            this.lblMedicineValue = new System.Windows.Forms.Label();
            this.lblDosage = new System.Windows.Forms.Label();
            this.lblDosageValue = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.lblFrequencyValue = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblQuantityValue = new System.Windows.Forms.Label();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblPriorityValue = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblOrderDateValue = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpPatient.SuspendLayout();
            this.grpDoctor.SuspendLayout();
            this.grpMedication.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Medication Order Details";
            // 
            // lblOrderIdTitle
            // 
            this.lblOrderIdTitle.AutoSize = true;
            this.lblOrderIdTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrderIdTitle.Location = new System.Drawing.Point(20, 70);
            this.lblOrderIdTitle.Name = "lblOrderIdTitle";
            this.lblOrderIdTitle.Size = new System.Drawing.Size(72, 19);
            this.lblOrderIdTitle.TabIndex = 1;
            this.lblOrderIdTitle.Text = "Order ID:";
            // 
            // lblOrderIdValue
            // 
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOrderIdValue.Location = new System.Drawing.Point(150, 70);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(17, 19);
            this.lblOrderIdValue.TabIndex = 2;
            this.lblOrderIdValue.Text = "0";
            // 
            // grpPatient
            // 
            this.grpPatient.Controls.Add(this.lblPatientName);
            this.grpPatient.Controls.Add(this.lblPatientValue);
            this.grpPatient.Controls.Add(this.lblPatientId);
            this.grpPatient.Controls.Add(this.lblPatientIdValue);
            this.grpPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPatient.Location = new System.Drawing.Point(20, 110);
            this.grpPatient.Name = "grpPatient";
            this.grpPatient.Size = new System.Drawing.Size(640, 100);
            this.grpPatient.TabIndex = 3;
            this.grpPatient.TabStop = false;
            this.grpPatient.Text = "Patient Information";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPatientName.Location = new System.Drawing.Point(15, 30);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(42, 15);
            this.lblPatientName.TabIndex = 0;
            this.lblPatientName.Text = "Name:";
            // 
            // lblPatientValue
            // 
            this.lblPatientValue.AutoSize = true;
            this.lblPatientValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatientValue.Location = new System.Drawing.Point(120, 30);
            this.lblPatientValue.Name = "lblPatientValue";
            this.lblPatientValue.Size = new System.Drawing.Size(12, 15);
            this.lblPatientValue.TabIndex = 1;
            this.lblPatientValue.Text = "-";
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPatientId.Location = new System.Drawing.Point(15, 60);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(62, 15);
            this.lblPatientId.TabIndex = 2;
            this.lblPatientId.Text = "Patient ID:";
            // 
            // lblPatientIdValue
            // 
            this.lblPatientIdValue.AutoSize = true;
            this.lblPatientIdValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPatientIdValue.Location = new System.Drawing.Point(120, 60);
            this.lblPatientIdValue.Name = "lblPatientIdValue";
            this.lblPatientIdValue.Size = new System.Drawing.Size(12, 15);
            this.lblPatientIdValue.TabIndex = 3;
            this.lblPatientIdValue.Text = "-";
            // 
            // grpDoctor
            // 
            this.grpDoctor.Controls.Add(this.lblDoctor);
            this.grpDoctor.Controls.Add(this.lblDoctorValue);
            this.grpDoctor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDoctor.Location = new System.Drawing.Point(20, 220);
            this.grpDoctor.Name = "grpDoctor";
            this.grpDoctor.Size = new System.Drawing.Size(640, 70);
            this.grpDoctor.TabIndex = 4;
            this.grpDoctor.TabStop = false;
            this.grpDoctor.Text = "Prescribing Doctor";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDoctor.Location = new System.Drawing.Point(15, 30);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(47, 15);
            this.lblDoctor.TabIndex = 0;
            this.lblDoctor.Text = "Doctor:";
            // 
            // lblDoctorValue
            // 
            this.lblDoctorValue.AutoSize = true;
            this.lblDoctorValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDoctorValue.Location = new System.Drawing.Point(120, 30);
            this.lblDoctorValue.Name = "lblDoctorValue";
            this.lblDoctorValue.Size = new System.Drawing.Size(12, 15);
            this.lblDoctorValue.TabIndex = 1;
            this.lblDoctorValue.Text = "-";
            // 
            // grpMedication
            // 
            this.grpMedication.Controls.Add(this.lblMedicine);
            this.grpMedication.Controls.Add(this.lblMedicineValue);
            this.grpMedication.Controls.Add(this.lblDosage);
            this.grpMedication.Controls.Add(this.lblDosageValue);
            this.grpMedication.Controls.Add(this.lblFrequency);
            this.grpMedication.Controls.Add(this.lblFrequencyValue);
            this.grpMedication.Controls.Add(this.lblQuantity);
            this.grpMedication.Controls.Add(this.lblQuantityValue);
            this.grpMedication.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpMedication.Location = new System.Drawing.Point(20, 300);
            this.grpMedication.Name = "grpMedication";
            this.grpMedication.Size = new System.Drawing.Size(640, 160);
            this.grpMedication.TabIndex = 5;
            this.grpMedication.TabStop = false;
            this.grpMedication.Text = "Medication Details";
            // 
            // lblMedicine
            // 
            this.lblMedicine.AutoSize = true;
            this.lblMedicine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMedicine.Location = new System.Drawing.Point(15, 30);
            this.lblMedicine.Name = "lblMedicine";
            this.lblMedicine.Size = new System.Drawing.Size(60, 15);
            this.lblMedicine.TabIndex = 0;
            this.lblMedicine.Text = "Medicine:";
            // 
            // lblMedicineValue
            // 
            this.lblMedicineValue.AutoSize = true;
            this.lblMedicineValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMedicineValue.Location = new System.Drawing.Point(120, 30);
            this.lblMedicineValue.Name = "lblMedicineValue";
            this.lblMedicineValue.Size = new System.Drawing.Size(12, 15);
            this.lblMedicineValue.TabIndex = 1;
            this.lblMedicineValue.Text = "-";
            // 
            // lblDosage
            // 
            this.lblDosage.AutoSize = true;
            this.lblDosage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDosage.Location = new System.Drawing.Point(15, 60);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(50, 15);
            this.lblDosage.TabIndex = 2;
            this.lblDosage.Text = "Dosage:";
            // 
            // lblDosageValue
            // 
            this.lblDosageValue.AutoSize = true;
            this.lblDosageValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDosageValue.Location = new System.Drawing.Point(120, 60);
            this.lblDosageValue.Name = "lblDosageValue";
            this.lblDosageValue.Size = new System.Drawing.Size(12, 15);
            this.lblDosageValue.TabIndex = 3;
            this.lblDosageValue.Text = "-";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrequency.Location = new System.Drawing.Point(15, 90);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(64, 15);
            this.lblFrequency.TabIndex = 4;
            this.lblFrequency.Text = "Frequency:";
            // 
            // lblFrequencyValue
            // 
            this.lblFrequencyValue.AutoSize = true;
            this.lblFrequencyValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFrequencyValue.Location = new System.Drawing.Point(120, 90);
            this.lblFrequencyValue.Name = "lblFrequencyValue";
            this.lblFrequencyValue.Size = new System.Drawing.Size(12, 15);
            this.lblFrequencyValue.TabIndex = 5;
            this.lblFrequencyValue.Text = "-";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantity.Location = new System.Drawing.Point(15, 120);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 15);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblQuantityValue
            // 
            this.lblQuantityValue.AutoSize = true;
            this.lblQuantityValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantityValue.Location = new System.Drawing.Point(120, 120);
            this.lblQuantityValue.Name = "lblQuantityValue";
            this.lblQuantityValue.Size = new System.Drawing.Size(12, 15);
            this.lblQuantityValue.TabIndex = 7;
            this.lblQuantityValue.Text = "-";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatus);
            this.grpStatus.Controls.Add(this.lblStatusValue);
            this.grpStatus.Controls.Add(this.lblPriority);
            this.grpStatus.Controls.Add(this.lblPriorityValue);
            this.grpStatus.Controls.Add(this.lblOrderDate);
            this.grpStatus.Controls.Add(this.lblOrderDateValue);
            this.grpStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpStatus.Location = new System.Drawing.Point(20, 470);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(640, 100);
            this.grpStatus.TabIndex = 6;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Order Status && Timeline";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(15, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusValue.Location = new System.Drawing.Point(120, 30);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(12, 15);
            this.lblStatusValue.TabIndex = 1;
            this.lblStatusValue.Text = "-";
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPriority.Location = new System.Drawing.Point(300, 30);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 15);
            this.lblPriority.TabIndex = 2;
            this.lblPriority.Text = "Priority:";
            // 
            // lblPriorityValue
            // 
            this.lblPriorityValue.AutoSize = true;
            this.lblPriorityValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPriorityValue.Location = new System.Drawing.Point(380, 30);
            this.lblPriorityValue.Name = "lblPriorityValue";
            this.lblPriorityValue.Size = new System.Drawing.Size(12, 15);
            this.lblPriorityValue.TabIndex = 3;
            this.lblPriorityValue.Text = "-";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderDate.Location = new System.Drawing.Point(15, 60);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(68, 15);
            this.lblOrderDate.TabIndex = 4;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // lblOrderDateValue
            // 
            this.lblOrderDateValue.AutoSize = true;
            this.lblOrderDateValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOrderDateValue.Location = new System.Drawing.Point(120, 60);
            this.lblOrderDateValue.Name = "lblOrderDateValue";
            this.lblOrderDateValue.Size = new System.Drawing.Size(12, 15);
            this.lblOrderDateValue.TabIndex = 5;
            this.lblOrderDateValue.Text = "-";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(560, 575);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ViewOrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(684, 621);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpMedication);
            this.Controls.Add(this.grpDoctor);
            this.Controls.Add(this.grpPatient);
            this.Controls.Add(this.lblOrderIdValue);
            this.Controls.Add(this.lblOrderIdTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewOrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Order Details";
            this.grpPatient.ResumeLayout(false);
            this.grpPatient.PerformLayout();
            this.grpDoctor.ResumeLayout(false);
            this.grpDoctor.PerformLayout();
            this.grpMedication.ResumeLayout(false);
            this.grpMedication.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}