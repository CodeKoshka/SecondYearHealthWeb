namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class IncomeReportForm
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
            panelHeader = new Panel();
            lblDescription = new Label();
            grpDateSelection = new GroupBox();
            rbCustomRange = new RadioButton();
            rbLastMonth = new RadioButton();
            rbThisMonth = new RadioButton();
            panelDateRange = new Panel();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnGenerateReport = new Button();
            panelHeader.SuspendLayout();
            grpDateSelection.SuspendLayout();
            panelDateRange.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(293, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Income Report Generator";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblDescription);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20);
            panelHeader.Size = new Size(520, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 9F);
            lblDescription.ForeColor = Color.FromArgb(113, 128, 150);
            lblDescription.Location = new Point(23, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(392, 15);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Generate a detailed income report with billing information and totals";
            // 
            // grpDateSelection
            // 
            grpDateSelection.BackColor = Color.White;
            grpDateSelection.Controls.Add(rbCustomRange);
            grpDateSelection.Controls.Add(rbLastMonth);
            grpDateSelection.Controls.Add(rbThisMonth);
            grpDateSelection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDateSelection.ForeColor = Color.FromArgb(52, 73, 94);
            grpDateSelection.Location = new Point(20, 120);
            grpDateSelection.Name = "grpDateSelection";
            grpDateSelection.Padding = new Padding(20);
            grpDateSelection.Size = new Size(480, 120);
            grpDateSelection.TabIndex = 1;
            grpDateSelection.TabStop = false;
            grpDateSelection.Text = "Select Report Period";
            // 
            // rbCustomRange
            // 
            rbCustomRange.AutoSize = true;
            rbCustomRange.Font = new Font("Segoe UI", 9F);
            rbCustomRange.Location = new Point(30, 80);
            rbCustomRange.Name = "rbCustomRange";
            rbCustomRange.Size = new Size(137, 19);
            rbCustomRange.TabIndex = 2;
            rbCustomRange.Text = "📅 Custom Date Range";
            rbCustomRange.UseVisualStyleBackColor = true;
            // 
            // rbLastMonth
            // 
            rbLastMonth.AutoSize = true;
            rbLastMonth.Font = new Font("Segoe UI", 9F);
            rbLastMonth.Location = new Point(30, 55);
            rbLastMonth.Name = "rbLastMonth";
            rbLastMonth.Size = new Size(95, 19);
            rbLastMonth.TabIndex = 1;
            rbLastMonth.Text = "◀️ Last Month";
            rbLastMonth.UseVisualStyleBackColor = true;
            // 
            // rbThisMonth
            // 
            rbThisMonth.AutoSize = true;
            rbThisMonth.Checked = true;
            rbThisMonth.Font = new Font("Segoe UI", 9F);
            rbThisMonth.Location = new Point(30, 30);
            rbThisMonth.Name = "rbThisMonth";
            rbThisMonth.Size = new Size(93, 19);
            rbThisMonth.TabIndex = 0;
            rbThisMonth.TabStop = true;
            rbThisMonth.Text = "📆 This Month";
            rbThisMonth.UseVisualStyleBackColor = true;
            // 
            // panelDateRange
            // 
            panelDateRange.BackColor = Color.White;
            panelDateRange.Controls.Add(dtpEndDate);
            panelDateRange.Controls.Add(lblEndDate);
            panelDateRange.Controls.Add(dtpStartDate);
            panelDateRange.Controls.Add(lblStartDate);
            panelDateRange.Location = new Point(20, 260);
            panelDateRange.Name = "panelDateRange";
            panelDateRange.Padding = new Padding(20);
            panelDateRange.Size = new Size(480, 120);
            panelDateRange.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CalendarFont = new Font("Segoe UI", 9F);
            dtpEndDate.Enabled = false;
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Long;
            dtpEndDate.Location = new Point(240, 70);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(220, 25);
            dtpEndDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEndDate.ForeColor = Color.FromArgb(52, 73, 94);
            lblEndDate.Location = new Point(240, 50);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(60, 15);
            lblEndDate.TabIndex = 2;
            lblEndDate.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CalendarFont = new Font("Segoe UI", 9F);
            dtpStartDate.Enabled = false;
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Long;
            dtpStartDate.Location = new Point(20, 70);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(210, 25);
            dtpStartDate.TabIndex = 1;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStartDate.ForeColor = Color.FromArgb(52, 73, 94);
            lblStartDate.Location = new Point(20, 50);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(66, 15);
            lblStartDate.TabIndex = 0;
            lblStartDate.Text = "Start Date:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(247, 250, 252);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnGenerateReport);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 400);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(20);
            panelButtons.Size = new Size(520, 90);
            panelButtons.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(275, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(225, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(46, 204, 113);
            btnGenerateReport.Cursor = Cursors.Hand;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(20, 20);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(240, 50);
            btnGenerateReport.TabIndex = 0;
            btnGenerateReport.Text = "💾 Save as PDF";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += BtnGenerateReport_Click;
            // 
            // IncomeReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(520, 490);
            Controls.Add(panelButtons);
            Controls.Add(panelDateRange);
            Controls.Add(grpDateSelection);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IncomeReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Income Report Generator - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpDateSelection.ResumeLayout(false);
            grpDateSelection.PerformLayout();
            panelDateRange.ResumeLayout(false);
            panelDateRange.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Panel panelHeader;
        private Label lblDescription;
        private GroupBox grpDateSelection;
        private RadioButton rbCustomRange;
        private RadioButton rbLastMonth;
        private RadioButton rbThisMonth;
        private Panel panelDateRange;
        private DateTimePicker dtpEndDate;
        private Label lblEndDate;
        private DateTimePicker dtpStartDate;
        private Label lblStartDate;
        private Panel panelButtons;
        private Button btnCancel;
        private Button btnGenerateReport;
    }
}