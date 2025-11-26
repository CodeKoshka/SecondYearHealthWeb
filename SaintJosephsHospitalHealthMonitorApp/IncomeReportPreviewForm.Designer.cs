namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class IncomeReportPreviewForm
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
            panelHeader = new Panel();
            lblDateRange = new Label();
            lblReportTitle = new Label();
            lblHospital = new Label();
            panelSummary = new Panel();
            lblNetIncome = new Label();
            lblTotalTax = new Label();
            lblTotalDiscount = new Label();
            lblGrossIncome = new Label();
            lblTotalRecords = new Label();
            lblSummaryTitle = new Label();
            dgvPreview = new DataGridView();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSavePDF = new Button();
            panelHeader.SuspendLayout();
            panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblDateRange);
            panelHeader.Controls.Add(lblReportTitle);
            panelHeader.Controls.Add(lblHospital);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 20, 30, 20);
            panelHeader.Size = new Size(1000, 110);
            panelHeader.TabIndex = 0;
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Arial", 10F);
            lblDateRange.ForeColor = Color.FromArgb(52, 73, 94);
            lblDateRange.Location = new Point(40, 75);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(154, 16);
            lblDateRange.TabIndex = 2;
            lblDateRange.Text = "From [Date] to [Date]";
            // 
            // lblReportTitle
            // 
            lblReportTitle.AutoSize = true;
            lblReportTitle.Font = new Font("Arial", 14F, FontStyle.Bold);
            lblReportTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblReportTitle.Location = new Point(40, 50);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Size = new Size(138, 22);
            lblReportTitle.TabIndex = 1;
            lblReportTitle.Text = "Income Report";
            // 
            // lblHospital
            // 
            lblHospital.AutoSize = true;
            lblHospital.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblHospital.ForeColor = Color.FromArgb(0, 102, 204);
            lblHospital.Location = new Point(40, 20);
            lblHospital.Name = "lblHospital";
            lblHospital.Size = new Size(233, 26);
            lblHospital.TabIndex = 0;
            lblHospital.Text = "St. Joseph's Hospital";
            // 
            // panelSummary
            // 
            panelSummary.BackColor = Color.White;
            panelSummary.BorderStyle = BorderStyle.None;
            panelSummary.Controls.Add(lblNetIncome);
            panelSummary.Controls.Add(lblTotalTax);
            panelSummary.Controls.Add(lblTotalDiscount);
            panelSummary.Controls.Add(lblGrossIncome);
            panelSummary.Controls.Add(lblTotalRecords);
            panelSummary.Controls.Add(lblSummaryTitle);
            panelSummary.Location = new Point(20, 120);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(960, 90);
            panelSummary.TabIndex = 1;
            panelSummary.Visible = false;
            // 
            // lblNetIncome
            // 
            lblNetIncome.AutoSize = true;
            lblNetIncome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNetIncome.ForeColor = Color.FromArgb(46, 204, 113);
            lblNetIncome.Location = new Point(600, 60);
            lblNetIncome.Name = "lblNetIncome";
            lblNetIncome.Size = new Size(190, 25);
            lblNetIncome.TabIndex = 5;
            lblNetIncome.Text = "NET INCOME: ₱0.00";
            // 
            // lblTotalTax
            // 
            lblTotalTax.AutoSize = true;
            lblTotalTax.Font = new Font("Segoe UI", 10F);
            lblTotalTax.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalTax.Location = new Point(300, 75);
            lblTotalTax.Name = "lblTotalTax";
            lblTotalTax.Size = new Size(172, 19);
            lblTotalTax.TabIndex = 4;
            lblTotalTax.Text = "Total Tax Collected: ₱0.00";
            // 
            // lblTotalDiscount
            // 
            lblTotalDiscount.AutoSize = true;
            lblTotalDiscount.Font = new Font("Segoe UI", 10F);
            lblTotalDiscount.ForeColor = Color.FromArgb(231, 76, 60);
            lblTotalDiscount.Location = new Point(20, 75);
            lblTotalDiscount.Name = "lblTotalDiscount";
            lblTotalDiscount.Size = new Size(153, 19);
            lblTotalDiscount.TabIndex = 3;
            lblTotalDiscount.Text = "Total Discounts: -₱0.00";
            // 
            // lblGrossIncome
            // 
            lblGrossIncome.AutoSize = true;
            lblGrossIncome.Font = new Font("Segoe UI", 10F);
            lblGrossIncome.ForeColor = Color.FromArgb(52, 73, 94);
            lblGrossIncome.Location = new Point(300, 50);
            lblGrossIncome.Name = "lblGrossIncome";
            lblGrossIncome.Size = new Size(130, 19);
            lblGrossIncome.TabIndex = 2;
            lblGrossIncome.Text = "Gross Income: ₱0.00";
            // 
            // lblTotalRecords
            // 
            lblTotalRecords.AutoSize = true;
            lblTotalRecords.Font = new Font("Segoe UI", 10F);
            lblTotalRecords.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotalRecords.Location = new Point(20, 50);
            lblTotalRecords.Name = "lblTotalRecords";
            lblTotalRecords.Size = new Size(131, 19);
            lblTotalRecords.TabIndex = 1;
            lblTotalRecords.Text = "Total Transactions: 0";
            // 
            // lblSummaryTitle
            // 
            lblSummaryTitle.AutoSize = true;
            lblSummaryTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSummaryTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblSummaryTitle.Location = new Point(20, 15);
            lblSummaryTitle.Name = "lblSummaryTitle";
            lblSummaryTitle.Size = new Size(195, 21);
            lblSummaryTitle.TabIndex = 0;
            lblSummaryTitle.Text = "📊 FINANCIAL SUMMARY";
            // 
            // dgvPreview
            // 
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToDeleteRows = false;
            dgvPreview.AllowUserToResizeColumns = false;
            dgvPreview.AllowUserToResizeRows = false;
            dgvPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvPreview.BackgroundColor = Color.White;
            dgvPreview.BorderStyle = BorderStyle.FixedSingle;
            dgvPreview.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPreview.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvPreview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPreview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvPreview.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
            dgvPreview.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvPreview.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
            dgvPreview.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPreview.ColumnHeadersHeight = 40;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPreview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPreview.DefaultCellStyle.BackColor = Color.White;
            dgvPreview.DefaultCellStyle.Font = new Font("Arial", 9F);
            dgvPreview.DefaultCellStyle.ForeColor = Color.Black;
            dgvPreview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dgvPreview.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPreview.EnableHeadersVisualStyles = false;
            dgvPreview.GridColor = Color.FromArgb(200, 200, 200);
            dgvPreview.Location = new Point(20, 120);
            dgvPreview.MultiSelect = false;
            dgvPreview.Name = "dgvPreview";
            dgvPreview.ReadOnly = true;
            dgvPreview.RowHeadersVisible = false;
            dgvPreview.RowHeadersWidth = 51;
            dgvPreview.RowTemplate.Height = 30;
            dgvPreview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPreview.Size = new Size(960, 450);
            dgvPreview.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSavePDF);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 650);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(20);
            panelButtons.Size = new Size(1000, 80);
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
            btnCancel.Location = new Point(840, 20);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSavePDF
            // 
            btnSavePDF.BackColor = Color.FromArgb(46, 204, 113);
            btnSavePDF.Cursor = Cursors.Hand;
            btnSavePDF.FlatAppearance.BorderSize = 0;
            btnSavePDF.FlatStyle = FlatStyle.Flat;
            btnSavePDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSavePDF.ForeColor = Color.White;
            btnSavePDF.Location = new Point(640, 20);
            btnSavePDF.Name = "btnSavePDF";
            btnSavePDF.Size = new Size(180, 40);
            btnSavePDF.TabIndex = 0;
            btnSavePDF.Text = "💾 Save as PDF";
            btnSavePDF.UseVisualStyleBackColor = false;
            btnSavePDF.Click += BtnSavePDF_Click;
            // 
            // IncomeReportPreviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 730);
            Controls.Add(panelButtons);
            Controls.Add(dgvPreview);
            Controls.Add(panelSummary);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IncomeReportPreviewForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Income Report Preview - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblDateRange;
        private Label lblReportTitle;
        private Label lblHospital;
        private Panel panelSummary;
        private Label lblNetIncome;
        private Label lblTotalTax;
        private Label lblTotalDiscount;
        private Label lblGrossIncome;
        private Label lblTotalRecords;
        private Label lblSummaryTitle;
        private DataGridView dgvPreview;
        private Panel panelButtons;
        private Button btnCancel;
        private Button btnSavePDF;
    }
}