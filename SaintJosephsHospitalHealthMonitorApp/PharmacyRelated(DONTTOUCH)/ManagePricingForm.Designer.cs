namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ManagePricingForm
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
            lblTitle = new Label();
            panelSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvPricing = new DataGridView();
            lblTotalItems = new Label();
            panelPricing = new Panel();
            lblWarning = new Label();
            lblProfit = new Label();
            btnUpdatePrice = new Button();
            txtMarkupPercent = new TextBox();
            lblMarkupPercent = new Label();
            txtSellingPrice = new TextBox();
            lblSellingPrice = new Label();
            txtCostPrice = new TextBox();
            lblCostPrice = new Label();
            lblSelectedMedicine = new Label();
            lblPricingSection = new Label();
            panelBulk = new Panel();
            btnBulkUpdate = new Button();
            txtBulkMarkup = new TextBox();
            lblBulkMarkup = new Label();
            lblBulkSection = new Label();
            panelButtons = new Panel();
            btnExportPricing = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPricing)).BeginInit();
            panelPricing.SuspendLayout();
            panelBulk.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1200, 70);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(298, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Medicine Pricing Manager";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = System.Drawing.Color.White;
            panelSearch.BorderStyle = BorderStyle.FixedSingle;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Location = new System.Drawing.Point(20, 85);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new System.Drawing.Size(750, 60);
            panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(620, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(110, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtSearch.Location = new System.Drawing.Point(170, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(430, 27);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblSearch.Location = new System.Drawing.Point(15, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(139, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search Medicine:";
            // 
            // dgvPricing
            // 
            dgvPricing.AllowUserToAddRows = false;
            dgvPricing.AllowUserToDeleteRows = false;
            dgvPricing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPricing.BackgroundColor = System.Drawing.Color.White;
            dgvPricing.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPricing.Location = new System.Drawing.Point(20, 160);
            dgvPricing.MultiSelect = false;
            dgvPricing.Name = "dgvPricing";
            dgvPricing.ReadOnly = true;
            dgvPricing.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPricing.Size = new System.Drawing.Size(750, 450);
            dgvPricing.TabIndex = 2;
            dgvPricing.SelectionChanged += new System.EventHandler(DgvPricing_SelectionChanged);
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTotalItems.Location = new System.Drawing.Point(20, 620);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new System.Drawing.Size(101, 19);
            lblTotalItems.TabIndex = 3;
            lblTotalItems.Text = "Total Items: 0";
            // 
            // panelPricing
            // 
            panelPricing.BackColor = System.Drawing.Color.White;
            panelPricing.BorderStyle = BorderStyle.FixedSingle;
            panelPricing.Controls.Add(lblWarning);
            panelPricing.Controls.Add(lblProfit);
            panelPricing.Controls.Add(btnUpdatePrice);
            panelPricing.Controls.Add(txtMarkupPercent);
            panelPricing.Controls.Add(lblMarkupPercent);
            panelPricing.Controls.Add(txtSellingPrice);
            panelPricing.Controls.Add(lblSellingPrice);
            panelPricing.Controls.Add(txtCostPrice);
            panelPricing.Controls.Add(lblCostPrice);
            panelPricing.Controls.Add(lblSelectedMedicine);
            panelPricing.Controls.Add(lblPricingSection);
            panelPricing.Location = new System.Drawing.Point(790, 85);
            panelPricing.Name = "panelPricing";
            panelPricing.Size = new System.Drawing.Size(390, 340);
            panelPricing.TabIndex = 4;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblWarning.ForeColor = System.Drawing.Color.Red;
            lblWarning.Location = new System.Drawing.Point(20, 250);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new System.Drawing.Size(59, 15);
            lblWarning.TabIndex = 10;
            lblWarning.Text = "⚠ Warning";
            lblWarning.Visible = false;
            // 
            // lblProfit
            // 
            lblProfit.AutoSize = true;
            lblProfit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblProfit.ForeColor = System.Drawing.Color.Green;
            lblProfit.Location = new System.Drawing.Point(20, 220);
            lblProfit.Name = "lblProfit";
            lblProfit.Size = new System.Drawing.Size(98, 21);
            lblProfit.TabIndex = 9;
            lblProfit.Text = "Profit: ₱0.00";
            // 
            // btnUpdatePrice
            // 
            btnUpdatePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnUpdatePrice.FlatStyle = FlatStyle.Flat;
            btnUpdatePrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnUpdatePrice.ForeColor = System.Drawing.Color.White;
            btnUpdatePrice.Location = new System.Drawing.Point(20, 280);
            btnUpdatePrice.Name = "btnUpdatePrice";
            btnUpdatePrice.Size = new System.Drawing.Size(350, 45);
            btnUpdatePrice.TabIndex = 8;
            btnUpdatePrice.Text = "Update Price";
            btnUpdatePrice.UseVisualStyleBackColor = false;
            btnUpdatePrice.Click += new System.EventHandler(BtnUpdatePrice_Click);
            // 
            // txtMarkupPercent
            // 
            txtMarkupPercent.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtMarkupPercent.Location = new System.Drawing.Point(160, 175);
            txtMarkupPercent.Name = "txtMarkupPercent";
            txtMarkupPercent.Size = new System.Drawing.Size(210, 27);
            txtMarkupPercent.TabIndex = 7;
            txtMarkupPercent.TextChanged += new System.EventHandler(TxtMarkupPercent_TextChanged);
            // 
            // lblMarkupPercent
            // 
            lblMarkupPercent.AutoSize = true;
            lblMarkupPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblMarkupPercent.Location = new System.Drawing.Point(20, 178);
            lblMarkupPercent.Name = "lblMarkupPercent";
            lblMarkupPercent.Size = new System.Drawing.Size(86, 19);
            lblMarkupPercent.TabIndex = 6;
            lblMarkupPercent.Text = "Markup %:";
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtSellingPrice.Location = new System.Drawing.Point(160, 135);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new System.Drawing.Size(210, 27);
            txtSellingPrice.TabIndex = 5;
            txtSellingPrice.TextChanged += new System.EventHandler(TxtSellingPrice_TextChanged);
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSellingPrice.Location = new System.Drawing.Point(20, 138);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new System.Drawing.Size(100, 19);
            lblSellingPrice.TabIndex = 4;
            lblSellingPrice.Text = "Selling Price:";
            // 
            // txtCostPrice
            // 
            txtCostPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtCostPrice.Location = new System.Drawing.Point(160, 95);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new System.Drawing.Size(210, 27);
            txtCostPrice.TabIndex = 3;
            txtCostPrice.TextChanged += new System.EventHandler(TxtCostPrice_TextChanged);
            // 
            // lblCostPrice
            // 
            lblCostPrice.AutoSize = true;
            lblCostPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblCostPrice.Location = new System.Drawing.Point(20, 98);
            lblCostPrice.Name = "lblCostPrice";
            lblCostPrice.Size = new System.Drawing.Size(81, 19);
            lblCostPrice.TabIndex = 2;
            lblCostPrice.Text = "Cost Price:";
            // 
            // lblSelectedMedicine
            // 
            lblSelectedMedicine.AutoSize = true;
            lblSelectedMedicine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            lblSelectedMedicine.ForeColor = System.Drawing.Color.Gray;
            lblSelectedMedicine.Location = new System.Drawing.Point(20, 60);
            lblSelectedMedicine.Name = "lblSelectedMedicine";
            lblSelectedMedicine.Size = new System.Drawing.Size(209, 19);
            lblSelectedMedicine.TabIndex = 1;
            lblSelectedMedicine.Text = "Selected: No medicine selected";
            // 
            // lblPricingSection
            // 
            lblPricingSection.AutoSize = true;
            lblPricingSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPricingSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            lblPricingSection.Location = new System.Drawing.Point(15, 15);
            lblPricingSection.Name = "lblPricingSection";
            lblPricingSection.Size = new System.Drawing.Size(179, 21);
            lblPricingSection.TabIndex = 0;
            lblPricingSection.Text = "Individual Price Edit";
            // 
            // panelBulk
            // 
            panelBulk.BackColor = System.Drawing.Color.White;
            panelBulk.BorderStyle = BorderStyle.FixedSingle;
            panelBulk.Controls.Add(btnBulkUpdate);
            panelBulk.Controls.Add(txtBulkMarkup);
            panelBulk.Controls.Add(lblBulkMarkup);
            panelBulk.Controls.Add(lblBulkSection);
            panelBulk.Location = new System.Drawing.Point(790, 440);
            panelBulk.Name = "panelBulk";
            panelBulk.Size = new System.Drawing.Size(390, 170);
            panelBulk.TabIndex = 5;
            // 
            // btnBulkUpdate
            // 
            btnBulkUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            btnBulkUpdate.FlatStyle = FlatStyle.Flat;
            btnBulkUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnBulkUpdate.ForeColor = System.Drawing.Color.White;
            btnBulkUpdate.Location = new System.Drawing.Point(20, 105);
            btnBulkUpdate.Name = "btnBulkUpdate";
            btnBulkUpdate.Size = new System.Drawing.Size(350, 45);
            btnBulkUpdate.TabIndex = 3;
            btnBulkUpdate.Text = "Apply Bulk Markup";
            btnBulkUpdate.UseVisualStyleBackColor = false;
            btnBulkUpdate.Click += new System.EventHandler(BtnBulkUpdate_Click);
            // 
            // txtBulkMarkup
            // 
            txtBulkMarkup.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtBulkMarkup.Location = new System.Drawing.Point(160, 60);
            txtBulkMarkup.Name = "txtBulkMarkup";
            txtBulkMarkup.Size = new System.Drawing.Size(210, 27);
            txtBulkMarkup.TabIndex = 2;
            // 
            // lblBulkMarkup
            // 
            lblBulkMarkup.AutoSize = true;
            lblBulkMarkup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblBulkMarkup.Location = new System.Drawing.Point(20, 63);
            lblBulkMarkup.Name = "lblBulkMarkup";
            lblBulkMarkup.Size = new System.Drawing.Size(86, 19);
            lblBulkMarkup.TabIndex = 1;
            lblBulkMarkup.Text = "Markup %:";
            // 
            // lblBulkSection
            // 
            lblBulkSection.AutoSize = true;
            lblBulkSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblBulkSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            lblBulkSection.Location = new System.Drawing.Point(15, 15);
            lblBulkSection.Name = "lblBulkSection";
            lblBulkSection.Size = new System.Drawing.Size(160, 21);
            lblBulkSection.TabIndex = 0;
            lblBulkSection.Text = "Bulk Price Update";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = System.Drawing.Color.White;
            panelButtons.BorderStyle = BorderStyle.FixedSingle;
            panelButtons.Controls.Add(btnExportPricing);
            panelButtons.Controls.Add(btnClose);
            panelButtons.Location = new System.Drawing.Point(20, 655);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(1160, 70);
            panelButtons.TabIndex = 6;
            // 
            // btnExportPricing
            // 
            btnExportPricing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            btnExportPricing.FlatStyle = FlatStyle.Flat;
            btnExportPricing.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnExportPricing.ForeColor = System.Drawing.Color.White;
            btnExportPricing.Location = new System.Drawing.Point(15, 12);
            btnExportPricing.Name = "btnExportPricing";
            btnExportPricing.Size = new System.Drawing.Size(180, 45);
            btnExportPricing.TabIndex = 0;
            btnExportPricing.Text = "Export to CSV";
            btnExportPricing.UseVisualStyleBackColor = false;
            btnExportPricing.Click += new System.EventHandler(BtnExportPricing_Click);
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(960, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(180, 45);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(BtnClose_Click);
            // 
            // ManagePricingForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            ClientSize = new System.Drawing.Size(1200, 740);
            Controls.Add(panelButtons);
            Controls.Add(panelBulk);
            Controls.Add(panelPricing);
            Controls.Add(lblTotalItems);
            Controls.Add(dgvPricing);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ManagePricingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Medicine Pricing - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPricing)).EndInit();
            panelPricing.ResumeLayout(false);
            panelPricing.PerformLayout();
            panelBulk.ResumeLayout(false);
            panelBulk.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvPricing;
        private Label lblTotalItems;
        private Panel panelPricing;
        private Label lblWarning;
        private Label lblProfit;
        private Button btnUpdatePrice;
        private TextBox txtMarkupPercent;
        private Label lblMarkupPercent;
        private TextBox txtSellingPrice;
        private Label lblSellingPrice;
        private TextBox txtCostPrice;
        private Label lblCostPrice;
        private Label lblSelectedMedicine;
        private Label lblPricingSection;
        private Panel panelBulk;
        private Button btnBulkUpdate;
        private TextBox txtBulkMarkup;
        private Label lblBulkMarkup;
        private Label lblBulkSection;
        private Panel panelButtons;
        private Button btnExportPricing;
        private Button btnClose;
    }
}