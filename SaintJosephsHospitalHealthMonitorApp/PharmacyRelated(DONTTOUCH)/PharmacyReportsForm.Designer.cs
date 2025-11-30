namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PharmacyReportsForm
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
            lblWelcome = new Label();
            panelFilters = new Panel();
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnGenerateReport = new Button();
            panelReport = new Panel();
            dgvReport = new DataGridView();
            lblRecordCount = new Label();
            btnExport = new Button();
            btnPrint = new Button();
            btnClose = new Button();
            panelFilters.SuspendLayout();
            panelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvReport)).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            lblWelcome.Location = new System.Drawing.Point(20, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(195, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Pharmacy Reports";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = System.Drawing.Color.White;
            panelFilters.BorderStyle = BorderStyle.FixedSingle;
            panelFilters.Controls.Add(lblReportType);
            panelFilters.Controls.Add(cmbReportType);
            panelFilters.Controls.Add(lblStartDate);
            panelFilters.Controls.Add(dtpStartDate);
            panelFilters.Controls.Add(lblEndDate);
            panelFilters.Controls.Add(dtpEndDate);
            panelFilters.Controls.Add(btnGenerateReport);
            panelFilters.Location = new System.Drawing.Point(20, 70);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new System.Drawing.Size(1160, 120);
            panelFilters.TabIndex = 1;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblReportType.Location = new System.Drawing.Point(20, 20);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new System.Drawing.Size(88, 19);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Report Type:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Sales Summary", "Inventory Status", "Low Stock Items", "Expired Medicines", "Dispensing History", "Medication Orders", "Controlled Substances Log", "Returns Summary" });
            cmbReportType.Location = new System.Drawing.Point(20, 45);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new System.Drawing.Size(300, 25);
            cmbReportType.TabIndex = 1;
            cmbReportType.SelectedIndexChanged += new System.EventHandler(CmbReportType_SelectedIndexChanged);
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStartDate.Location = new System.Drawing.Point(350, 20);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(75, 19);
            lblStartDate.TabIndex = 2;
            lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new System.Drawing.Point(350, 45);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(200, 25);
            dtpStartDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblEndDate.Location = new System.Drawing.Point(580, 20);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new System.Drawing.Size(68, 19);
            lblEndDate.TabIndex = 4;
            lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new System.Drawing.Point(580, 45);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new System.Drawing.Size(200, 25);
            dtpEndDate.TabIndex = 5;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnGenerateReport.Cursor = Cursors.Hand;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnGenerateReport.ForeColor = System.Drawing.Color.White;
            btnGenerateReport.Location = new System.Drawing.Point(820, 35);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new System.Drawing.Size(180, 45);
            btnGenerateReport.TabIndex = 6;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += new System.EventHandler(BtnGenerateReport_Click);
            // 
            // panelReport
            // 
            panelReport.BackColor = System.Drawing.Color.White;
            panelReport.BorderStyle = BorderStyle.FixedSingle;
            panelReport.Controls.Add(dgvReport);
            panelReport.Location = new System.Drawing.Point(20, 210);
            panelReport.Name = "panelReport";
            panelReport.Size = new System.Drawing.Size(1160, 450);
            panelReport.TabIndex = 2;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = System.Drawing.Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new System.Drawing.Point(10, 10);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new System.Drawing.Size(1138, 428);
            dgvReport.TabIndex = 0;
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblRecordCount.Location = new System.Drawing.Point(20, 675);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new System.Drawing.Size(112, 19);
            lblRecordCount.TabIndex = 3;
            lblRecordCount.Text = "Total Records: 0";
            // 
            // btnExport
            // 
            btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnExport.Cursor = Cursors.Hand;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnExport.ForeColor = System.Drawing.Color.White;
            btnExport.Location = new System.Drawing.Point(780, 670);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(120, 40);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += new System.EventHandler(BtnExport_Click);
            // 
            // btnPrint
            // 
            btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnPrint.ForeColor = System.Drawing.Color.White;
            btnPrint.Location = new System.Drawing.Point(920, 670);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(120, 40);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += new System.EventHandler(BtnPrint_Click);
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1060, 670);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(120, 40);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(BtnClose_Click);
            // 
            // PharmacyReportsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            ClientSize = new System.Drawing.Size(1200, 730);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(btnExport);
            Controls.Add(lblRecordCount);
            Controls.Add(panelReport);
            Controls.Add(panelFilters);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PharmacyReportsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pharmacy Reports - St. Joseph's Hospital";
            Load += new System.EventHandler(PharmacyReportsForm_Load);
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            panelReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(dgvReport)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblReportType;
        private ComboBox cmbReportType;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerateReport;
        private DataGridView dgvReport;
        private Label lblRecordCount;
        private Button btnExport;
        private Button btnPrint;
        private Button btnClose;
        private Panel panelFilters;
        private Panel panelReport;
    }
}