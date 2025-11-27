namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class AppointmentForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpAppointment = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(262, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Schedule New Appointment";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new System.Drawing.Point(30, 70);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new System.Drawing.Size(88, 15);
            lblPatient.TabIndex = 1;
            lblPatient.Text = "Select Patient:";
            // 
            // cmbPatient
            // 
            cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new System.Drawing.Point(30, 95);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new System.Drawing.Size(420, 23);
            cmbPatient.TabIndex = 2;
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new System.Drawing.Point(30, 140);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new System.Drawing.Size(85, 15);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "Select Doctor:";
            // 
            // cmbDoctor
            // 
            cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbDoctor.FormattingEnabled = true;
            cmbDoctor.Location = new System.Drawing.Point(30, 165);
            cmbDoctor.Name = "cmbDoctor";
            cmbDoctor.Size = new System.Drawing.Size(420, 23);
            cmbDoctor.TabIndex = 4;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(30, 210);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(157, 15);
            lblDate.TabIndex = 5;
            lblDate.Text = "Appointment Date && Time:";
            // 
            // dtpAppointment
            // 
            dtpAppointment.CustomFormat = "MMMM dd, yyyy hh:mm tt";
            dtpAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpAppointment.Location = new System.Drawing.Point(30, 235);
            dtpAppointment.Name = "dtpAppointment";
            dtpAppointment.Size = new System.Drawing.Size(420, 23);
            dtpAppointment.TabIndex = 6;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new System.Drawing.Point(30, 280);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new System.Drawing.Size(96, 15);
            lblNotes.TabIndex = 7;
            lblNotes.Text = "Notes (optional):";
            // 
            // txtNotes
            // 
            txtNotes.Location = new System.Drawing.Point(30, 305);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new System.Drawing.Size(420, 60);
            txtNotes.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(30, 380);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(200, 40);
            btnSave.TabIndex = 9;
            btnSave.Text = "Schedule";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(250, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(200, 40);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            ClientSize = new System.Drawing.Size(484, 450);
            Controls.Add(this.btnCancel);
            Controls.Add(this.btnSave);
            Controls.Add(this.txtNotes);
            Controls.Add(this.lblNotes);
            Controls.Add(this.dtpAppointment);
            Controls.Add(this.lblDate);
            Controls.Add(this.cmbDoctor);
            Controls.Add(this.lblDoctor);
            Controls.Add(this.cmbPatient);
            Controls.Add(this.lblPatient);
            Controls.Add(this.lblTitle);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AppointmentForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Schedule Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblPatient;
        private ComboBox cmbPatient;
        private Label lblDoctor;
        private ComboBox cmbDoctor;
        private Label lblDate;
        private DateTimePicker dtpAppointment;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
    }
}