namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class BillDetailsViewForm
    {
        private System.ComponentModel.IContainer components = null;

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
            pictureBoxLogo = new PictureBox();
            lblHospitalName = new Label();
            lblStatementTitle = new Label();
            panelPatientInfo = new Panel();
            lblPatientLabel = new Label();
            lblPatientName = new Label();
            lblAgeLabel = new Label();
            lblAge = new Label();
            lblSexLabel = new Label();
            lblSex = new Label();
            lblPhysicianLabel = new Label();
            lblAttendingPhysician = new Label();
            lblAccountNumber = new Label();
            lblDateAdmittedLabel = new Label();
            lblDateAdmitted = new Label();
            lblTimeAdmittedLabel = new Label();
            lblTimeAdmitted = new Label();
            lblDateTodayLabel = new Label();
            lblDateToday = new Label();
            lblStatusLabel = new Label();
            lblStatus = new Label();
            grpHospitalCharges = new GroupBox();
            dgvHospitalCharges = new DataGridView();
            colParticulars = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colPHIC = new DataGridViewTextBoxColumn();
            colMSS = new DataGridViewTextBoxColumn();
            colCash = new DataGridViewTextBoxColumn();
            colBalance = new DataGridViewTextBoxColumn();
            lblGrandTotal = new Label();
            panelFooter = new Panel();
            lblAcknowledgement = new Label();
            lblSignatureLine = new Label();
            lblSignatureText = new Label();
            lblPreparedByLabel = new Label();
            lblPreparedBy = new Label();
            lblCertifiedLabel = new Label();
            lblCertifiedName = new Label();
            lblCertifiedTitle1 = new Label();
            lblCertifiedTitle2 = new Label();
            panelButtons = new Panel();
            btnPreviewPDF = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelPatientInfo.SuspendLayout();
            grpHospitalCharges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHospitalCharges).BeginInit();
            panelFooter.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(lblHospitalName);
            panelHeader.Controls.Add(lblStatementTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20);
            panelHeader.Size = new Size(900, 100);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(20, 20);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 60);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // lblHospitalName
            // 
            lblHospitalName.AutoSize = true;
            lblHospitalName.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblHospitalName.Location = new Point(100, 25);
            lblHospitalName.Name = "lblHospitalName";
            lblHospitalName.Size = new Size(191, 19);
            lblHospitalName.TabIndex = 1;
            lblHospitalName.Text = "ST. JOSEPH'S HOSPITAL";
            // 
            // lblStatementTitle
            // 
            lblStatementTitle.AutoSize = true;
            lblStatementTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblStatementTitle.Location = new Point(100, 50);
            lblStatementTitle.Name = "lblStatementTitle";
            lblStatementTitle.Size = new Size(248, 22);
            lblStatementTitle.TabIndex = 2;
            lblStatementTitle.Text = "STATEMENT OF ACCOUNT";
            // 
            // panelPatientInfo
            // 
            panelPatientInfo.BackColor = Color.White;
            panelPatientInfo.BorderStyle = BorderStyle.FixedSingle;
            panelPatientInfo.Controls.Add(lblPatientLabel);
            panelPatientInfo.Controls.Add(lblPatientName);
            panelPatientInfo.Controls.Add(lblAgeLabel);
            panelPatientInfo.Controls.Add(lblAge);
            panelPatientInfo.Controls.Add(lblSexLabel);
            panelPatientInfo.Controls.Add(lblSex);
            panelPatientInfo.Controls.Add(lblPhysicianLabel);
            panelPatientInfo.Controls.Add(lblAttendingPhysician);
            panelPatientInfo.Controls.Add(lblAccountNumber);
            panelPatientInfo.Controls.Add(lblDateAdmittedLabel);
            panelPatientInfo.Controls.Add(lblDateAdmitted);
            panelPatientInfo.Controls.Add(lblTimeAdmittedLabel);
            panelPatientInfo.Controls.Add(lblTimeAdmitted);
            panelPatientInfo.Controls.Add(lblDateTodayLabel);
            panelPatientInfo.Controls.Add(lblDateToday);
            panelPatientInfo.Controls.Add(lblStatusLabel);
            panelPatientInfo.Controls.Add(lblStatus);
            panelPatientInfo.Location = new Point(12, 112);
            panelPatientInfo.Name = "panelPatientInfo";
            panelPatientInfo.Padding = new Padding(15);
            panelPatientInfo.Size = new Size(876, 110);
            panelPatientInfo.TabIndex = 1;
            // 
            // lblPatientLabel
            // 
            lblPatientLabel.AutoSize = true;
            lblPatientLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblPatientLabel.Location = new Point(15, 15);
            lblPatientLabel.Name = "lblPatientLabel";
            lblPatientLabel.Size = new Size(53, 15);
            lblPatientLabel.TabIndex = 0;
            lblPatientLabel.Text = "Patient:";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Arial", 9F);
            lblPatientName.Location = new Point(120, 15);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(88, 15);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "PATIENT NAME";
            // 
            // lblAgeLabel
            // 
            lblAgeLabel.AutoSize = true;
            lblAgeLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblAgeLabel.Location = new Point(15, 40);
            lblAgeLabel.Name = "lblAgeLabel";
            lblAgeLabel.Size = new Size(31, 15);
            lblAgeLabel.TabIndex = 2;
            lblAgeLabel.Text = "Age:";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Arial", 9F);
            lblAge.Location = new Point(120, 40);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(14, 15);
            lblAge.TabIndex = 3;
            lblAge.Text = "0";
            // 
            // lblSexLabel
            // 
            lblSexLabel.AutoSize = true;
            lblSexLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblSexLabel.Location = new Point(180, 40);
            lblSexLabel.Name = "lblSexLabel";
            lblSexLabel.Size = new Size(31, 15);
            lblSexLabel.TabIndex = 4;
            lblSexLabel.Text = "Sex:";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Font = new Font("Arial", 9F);
            lblSex.Location = new Point(220, 40);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(44, 15);
            lblSex.TabIndex = 5;
            lblSex.Text = "Female";
            //
            // lblPhysicianLabel
            //
            lblPhysicianLabel.AutoSize = true;
            lblPhysicianLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblPhysicianLabel.Location = new Point(15, 65);
            lblPhysicianLabel.Name = "lblPhysicianLabel";
            lblPhysicianLabel.Size = new Size(130, 15);
            lblPhysicianLabel.TabIndex = 6;
            lblPhysicianLabel.Text = "Attending Physician:";
            //
            // lblAttendingPhysician
            //
            lblAttendingPhysician.AutoSize = true;
            lblAttendingPhysician.Font = new Font("Arial", 9F);
            lblAttendingPhysician.Location = new Point(150, 65);
            lblAttendingPhysician.Name = "lblAttendingPhysician";
            lblAttendingPhysician.Size = new Size(27, 15);
            lblAttendingPhysician.TabIndex = 7;
            lblAttendingPhysician.Text = "N/A";
            //
            // lblAccountNumber
            //
            lblAccountNumber.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblAccountNumber.Location = new Point(550, 15);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(300, 20);
            lblAccountNumber.TabIndex = 8;
            lblAccountNumber.Text = "ACCOUNT NO. 0000";
            lblAccountNumber.TextAlign = ContentAlignment.TopRight;
            //
            // lblDateAdmittedLabel
            //
            lblDateAdmittedLabel.AutoSize = true;
            lblDateAdmittedLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblDateAdmittedLabel.Location = new Point(550, 40);
            lblDateAdmittedLabel.Name = "lblDateAdmittedLabel";
            lblDateAdmittedLabel.Size = new Size(97, 15);
            lblDateAdmittedLabel.TabIndex = 9;
            lblDateAdmittedLabel.Text = "Date Admitted:";
            //
            // lblDateAdmitted
            //
            lblDateAdmitted.AutoSize = true;
            lblDateAdmitted.Font = new Font("Arial", 9F);
            lblDateAdmitted.Location = new Point(650, 40);
            lblDateAdmitted.Name = "lblDateAdmitted";
            lblDateAdmitted.Size = new Size(27, 15);
            lblDateAdmitted.TabIndex = 10;
            lblDateAdmitted.Text = "N/A";
            //
            // lblTimeAdmittedLabel
            //
            lblTimeAdmittedLabel.AutoSize = true;
            lblTimeAdmittedLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTimeAdmittedLabel.Location = new Point(550, 60);
            lblTimeAdmittedLabel.Name = "lblTimeAdmittedLabel";
            lblTimeAdmittedLabel.Size = new Size(98, 15);
            lblTimeAdmittedLabel.TabIndex = 11;
            lblTimeAdmittedLabel.Text = "Time Admitted:";
            //
            // lblTimeAdmitted
            //
            lblTimeAdmitted.AutoSize = true;
            lblTimeAdmitted.Font = new Font("Arial", 9F);
            lblTimeAdmitted.Location = new Point(650, 60);
            lblTimeAdmitted.Name = "lblTimeAdmitted";
            lblTimeAdmitted.Size = new Size(27, 15);
            lblTimeAdmitted.TabIndex = 12;
            lblTimeAdmitted.Text = "N/A";
            //
            // lblDateTodayLabel
            //
            lblDateTodayLabel.AutoSize = true;
            lblDateTodayLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblDateTodayLabel.Location = new Point(550, 80);
            lblDateTodayLabel.Name = "lblDateTodayLabel";
            lblDateTodayLabel.Size = new Size(76, 15);
            lblDateTodayLabel.TabIndex = 13;
            lblDateTodayLabel.Text = "Date Today:";
            //
            // lblDateToday
            //
            lblDateToday.AutoSize = true;
            lblDateToday.Font = new Font("Arial", 9F);
            lblDateToday.Location = new Point(650, 80);
            lblDateToday.Name = "lblDateToday";
            lblDateToday.Size = new Size(27, 15);
            lblDateToday.TabIndex = 14;
            lblDateToday.Text = "N/A";
            //
            // lblStatusLabel
            //
            lblStatusLabel.AutoSize = true;
            lblStatusLabel.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblStatusLabel.Location = new Point(350, 40);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(47, 15);
            lblStatusLabel.TabIndex = 15;
            lblStatusLabel.Text = "Status:";
            //
            // lblStatus
            //
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblStatus.Location = new Point(405, 40);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(64, 16);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "PENDING";
            //
            // grpHospitalCharges
            //
            grpHospitalCharges.Controls.Add(dgvHospitalCharges);
            grpHospitalCharges.Font = new Font("Arial", 10F, FontStyle.Bold);
            grpHospitalCharges.Location = new Point(12, 235);
            grpHospitalCharges.Name = "grpHospitalCharges";
            grpHospitalCharges.Padding = new Padding(10);
            grpHospitalCharges.Size = new Size(876, 300);
            grpHospitalCharges.TabIndex = 2;
            grpHospitalCharges.TabStop = false;
            grpHospitalCharges.Text = "HOSPITAL CHARGES";
            //
            // dgvHospitalCharges
            //
            dgvHospitalCharges.AllowUserToAddRows = false;
            dgvHospitalCharges.AllowUserToDeleteRows = false;
            dgvHospitalCharges.BackgroundColor = Color.White;
            dgvHospitalCharges.BorderStyle = BorderStyle.None;
            dgvHospitalCharges.ColumnHeadersHeight = 30;
            dgvHospitalCharges.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHospitalCharges.Columns.AddRange(new DataGridViewColumn[] { colParticulars, colTotal, colPHIC, colMSS, colCash, colBalance });
            dgvHospitalCharges.Dock = DockStyle.Fill;
            dgvHospitalCharges.Location = new Point(10, 26);
            dgvHospitalCharges.Name = "dgvHospitalCharges";
            dgvHospitalCharges.ReadOnly = true;
            dgvHospitalCharges.RowHeadersVisible = false;
            dgvHospitalCharges.RowTemplate.Height = 25;
            dgvHospitalCharges.Size = new Size(856, 264);
            dgvHospitalCharges.TabIndex = 0;
            //
            // colParticulars
            //
            colParticulars.HeaderText = "PARTICULARS";
            colParticulars.Name = "colParticulars";
            colParticulars.ReadOnly = true;
            colParticulars.Width = 300;
            //
            // colTotal
            //
            colTotal.HeaderText = "TOTAL";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 110;
            //
            // colPHIC
            //
            colPHIC.HeaderText = "PHIC";
            colPHIC.Name = "colPHIC";
            colPHIC.ReadOnly = true;
            colPHIC.Width = 90;
            //
            // colMSS
            //
            colMSS.HeaderText = "MSS DISCOUNT";
            colMSS.Name = "colMSS";
            colMSS.ReadOnly = true;
            colMSS.Width = 120;
            //
            // colCash
            //
            colCash.HeaderText = "CASH";
            colCash.Name = "colCash";
            colCash.ReadOnly = true;
            colCash.Width = 90;
            //
            // colBalance
            //
            colBalance.HeaderText = "BALANCE";
            colBalance.Name = "colBalance";
            colBalance.ReadOnly = true;
            colBalance.Width = 120;
            //
            // lblGrandTotal
            //
            lblGrandTotal.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblGrandTotal.Location = new Point(500, 545);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(388, 25);
            lblGrandTotal.TabIndex = 3;
            lblGrandTotal.Text = "GRAND TOTAL:   ₱0.00";
            lblGrandTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // panelFooter
            //
            panelFooter.BackColor = Color.White;
            panelFooter.BorderStyle = BorderStyle.FixedSingle;
            panelFooter.Controls.Add(lblAcknowledgement);
            panelFooter.Controls.Add(lblSignatureLine);
            panelFooter.Controls.Add(lblSignatureText);
            panelFooter.Controls.Add(lblPreparedByLabel);
            panelFooter.Controls.Add(lblPreparedBy);
            panelFooter.Controls.Add(lblCertifiedLabel);
            panelFooter.Controls.Add(lblCertifiedName);
            panelFooter.Controls.Add(lblCertifiedTitle1);
            panelFooter.Controls.Add(lblCertifiedTitle2);
            panelFooter.Location = new Point(12, 585);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(15);
            panelFooter.Size = new Size(876, 130);
            panelFooter.TabIndex = 4;
            //
            // lblAcknowledgement
            //
            lblAcknowledgement.AutoSize = true;
            lblAcknowledgement.Font = new Font("Arial", 8F);
            lblAcknowledgement.Location = new Point(15, 15);
            lblAcknowledgement.Name = "lblAcknowledgement";
            lblAcknowledgement.Size = new Size(267, 14);
            lblAcknowledgement.TabIndex = 0;
            lblAcknowledgement.Text = "ACKNOWLEDGEMENT OF MEMBER/REPRESENTATIVE";
            //
            // lblSignatureLine
            //
            lblSignatureLine.BorderStyle = BorderStyle.FixedSingle;
            lblSignatureLine.Location = new Point(15, 50);
            lblSignatureLine.Name = "lblSignatureLine";
            lblSignatureLine.Size = new Size(250, 1);
            lblSignatureLine.TabIndex = 1;
            //
            // lblSignatureText
            //
            lblSignatureText.AutoSize = true;
            lblSignatureText.Font = new Font("Arial", 8F);
            lblSignatureText.Location = new Point(15, 55);
            lblSignatureText.Name = "lblSignatureText";
            lblSignatureText.Size = new Size(152, 14);
            lblSignatureText.TabIndex = 2;
            lblSignatureText.Text = "Signature Over Printed Name";
            //
            // lblPreparedByLabel
            //
            lblPreparedByLabel.AutoSize = true;
            lblPreparedByLabel.Font = new Font("Arial", 8F);
            lblPreparedByLabel.Location = new Point(15, 85);
            lblPreparedByLabel.Name = "lblPreparedByLabel";
            lblPreparedByLabel.Size = new Size(69, 14);
            lblPreparedByLabel.TabIndex = 3;
            lblPreparedByLabel.Text = "Prepared by:";
            //
            // lblPreparedBy
            //
            lblPreparedBy.AutoSize = true;
            lblPreparedBy.Font = new Font("Arial", 8F, FontStyle.Bold);
            lblPreparedBy.Location = new Point(90, 85);
            lblPreparedBy.Name = "lblPreparedBy";
            lblPreparedBy.Size = new Size(67, 14);
            lblPreparedBy.TabIndex = 4;
            lblPreparedBy.Text = "Clerk Name";
            //
            // lblCertifiedLabel
            //
            lblCertifiedLabel.AutoSize = true;
            lblCertifiedLabel.Font = new Font("Arial", 8F);
            lblCertifiedLabel.Location = new Point(600, 85);
            lblCertifiedLabel.Name = "lblCertifiedLabel";
            lblCertifiedLabel.Size = new Size(90, 14);
            lblCertifiedLabel.TabIndex = 5;
            lblCertifiedLabel.Text = "Certified Correct:";
            //
            // lblCertifiedName
            //
            lblCertifiedName.BorderStyle = BorderStyle.FixedSingle;
            lblCertifiedName.Location = new Point(600, 100);
            lblCertifiedName.Name = "lblCertifiedName";
            lblCertifiedName.Size = new Size(250, 1);
            lblCertifiedName.TabIndex = 6;
            //
            // lblCertifiedTitle1
            //
            lblCertifiedTitle1.AutoSize = true;
            lblCertifiedTitle1.Font = new Font("Arial", 7F);
            lblCertifiedTitle1.Location = new Point(600, 105);
            lblCertifiedTitle1.Name = "lblCertifiedTitle1";
            lblCertifiedTitle1.Size = new Size(122, 13);
            lblCertifiedTitle1.TabIndex = 7;
            lblCertifiedTitle1.Text = "Cashier/Officer-in-Charge";
            //
            // lblCertifiedTitle2
            //
            lblCertifiedTitle2.AutoSize = true;
            lblCertifiedTitle2.Font = new Font("Arial", 7F);
            lblCertifiedTitle2.Location = new Point(600, 118);
            lblCertifiedTitle2.Name = "lblCertifiedTitle2";
            lblCertifiedTitle2.Size = new Size(137, 13);
            lblCertifiedTitle2.TabIndex = 8;
            lblCertifiedTitle2.Text = "Head, Billing and Claim Unit";
            //
            // panelButtons
            //
            panelButtons.BackColor = Color.FromArgb(247, 250, 252);
            panelButtons.Controls.Add(btnPreviewPDF);
            panelButtons.Controls.Add(btnClose);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 730);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(12, 10, 12, 10);
            panelButtons.Size = new Size(900, 60);
            panelButtons.TabIndex = 5;
            //
            // btnPreviewPDF
            //
            btnPreviewPDF.BackColor = Color.FromArgb(52, 152, 219);
            btnPreviewPDF.Cursor = Cursors.Hand;
            btnPreviewPDF.FlatAppearance.BorderSize = 0;
            btnPreviewPDF.FlatStyle = FlatStyle.Flat;
            btnPreviewPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPreviewPDF.ForeColor = Color.White;
            btnPreviewPDF.Location = new Point(380, 10);
            btnPreviewPDF.Name = "btnPreviewPDF";
            btnPreviewPDF.Size = new Size(200, 40);
            btnPreviewPDF.TabIndex = 0;
            btnPreviewPDF.Text = "👁️ Preview & Save PDF";
            btnPreviewPDF.UseVisualStyleBackColor = false;
            btnPreviewPDF.Click += BtnPreviewPDF_Click;
            //
            // btnClose
            //
            btnClose.BackColor = Color.FromArgb(149, 165, 166);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(590, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            //
            // BillDetailsViewForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(920, 790);
            Controls.Add(panelButtons);
            Controls.Add(panelFooter);
            Controls.Add(lblGrandTotal);
            Controls.Add(grpHospitalCharges);
            Controls.Add(panelPatientInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BillDetailsViewForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Statement of Account - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelPatientInfo.ResumeLayout(false);
            panelPatientInfo.PerformLayout();
            grpHospitalCharges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHospitalCharges).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        private Panel panelHeader;
        private PictureBox pictureBoxLogo;
        private Label lblHospitalName;
        private Label lblStatementTitle;
        private Panel panelPatientInfo;
        private Label lblPatientLabel;
        private Label lblPatientName;
        private Label lblAgeLabel;
        private Label lblAge;
        private Label lblSexLabel;
        private Label lblSex;
        private Label lblPhysicianLabel;
        private Label lblAttendingPhysician;
        private Label lblAccountNumber;
        private Label lblDateAdmittedLabel;
        private Label lblDateAdmitted;
        private Label lblTimeAdmittedLabel;
        private Label lblTimeAdmitted;
        private Label lblDateTodayLabel;
        private Label lblDateToday;
        private Label lblStatusLabel;
        private Label lblStatus;
        private GroupBox grpHospitalCharges;
        private DataGridView dgvHospitalCharges;
        private DataGridViewTextBoxColumn colParticulars;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colPHIC;
        private DataGridViewTextBoxColumn colMSS;
        private DataGridViewTextBoxColumn colCash;
        private DataGridViewTextBoxColumn colBalance;
        private Label lblGrandTotal;
        private Panel panelFooter;
        private Label lblAcknowledgement;
        private Label lblSignatureLine;
        private Label lblSignatureText;
        private Label lblPreparedByLabel;
        private Label lblPreparedBy;
        private Label lblCertifiedLabel;
        private Label lblCertifiedName;
        private Label lblCertifiedTitle1;
        private Label lblCertifiedTitle2;
        private Panel panelButtons;
        private Button btnPreviewPDF;
        private Button btnClose;
    }
}