namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class MedicalRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblPrescription;
        private System.Windows.Forms.TextBox txtPrescription;
        private System.Windows.Forms.Label lblLabTests;
        private System.Windows.Forms.TextBox txtLabTests;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.lblPrescription = new System.Windows.Forms.Label();
            this.txtPrescription = new System.Windows.Forms.TextBox();
            this.lblLabTests = new System.Windows.Forms.Label();
            this.txtLabTests = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(202, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "New Medical Record";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientName.Location = new System.Drawing.Point(30, 55);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(0, 19);
            this.lblPatientName.TabIndex = 1;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Location = new System.Drawing.Point(30, 90);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(61, 13);
            this.lblDiagnosis.TabIndex = 2;
            this.lblDiagnosis.Text = "Diagnosis:";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(30, 115);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(520, 80);
            this.txtDiagnosis.TabIndex = 3;
            // 
            // lblPrescription
            // 
            this.lblPrescription.AutoSize = true;
            this.lblPrescription.Location = new System.Drawing.Point(30, 210);
            this.lblPrescription.Name = "lblPrescription";
            this.lblPrescription.Size = new System.Drawing.Size(70, 13);
            this.lblPrescription.TabIndex = 4;
            this.lblPrescription.Text = "Prescription:";
            // 
            // txtPrescription
            // 
            this.txtPrescription.Location = new System.Drawing.Point(30, 235);
            this.txtPrescription.Multiline = true;
            this.txtPrescription.Name = "txtPrescription";
            this.txtPrescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrescription.Size = new System.Drawing.Size(520, 80);
            this.txtPrescription.TabIndex = 5;
            // 
            // lblLabTests
            // 
            this.lblLabTests.AutoSize = true;
            this.lblLabTests.Location = new System.Drawing.Point(30, 330);
            this.lblLabTests.Name = "lblLabTests";
            this.lblLabTests.Size = new System.Drawing.Size(114, 13);
            this.lblLabTests.TabIndex = 6;
            this.lblLabTests.Text = "Lab Tests Requested:";
            // 
            // txtLabTests
            // 
            this.txtLabTests.Location = new System.Drawing.Point(30, 355);
            this.txtLabTests.Multiline = true;
            this.txtLabTests.Name = "txtLabTests";
            this.txtLabTests.Size = new System.Drawing.Size(520, 60);
            this.txtLabTests.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(300, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(250, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // MedicalRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLabTests);
            this.Controls.Add(this.lblLabTests);
            this.Controls.Add(this.txtPrescription);
            this.Controls.Add(this.lblPrescription);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.lblDiagnosis);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MedicalRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Medical Record";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}