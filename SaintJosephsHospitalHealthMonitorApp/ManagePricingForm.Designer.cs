namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ManagePricingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvPricing;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Panel panelPricing;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Button btnUpdatePrice;
        private System.Windows.Forms.TextBox txtMarkupPercent;
        private System.Windows.Forms.Label lblMarkupPercent;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.Label lblSelectedMedicine;
        private System.Windows.Forms.Label lblPricingSection;
        private System.Windows.Forms.Panel panelBulk;
        private System.Windows.Forms.Button btnBulkUpdate;
        private System.Windows.Forms.TextBox txtBulkMarkup;
        private System.Windows.Forms.Label lblBulkMarkup;
        private System.Windows.Forms.Label lblBulkSection;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnExportPricing;
        private System.Windows.Forms.Button btnClose;

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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvPricing = new System.Windows.Forms.DataGridView();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.panelPricing = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.btnUpdatePrice = new System.Windows.Forms.Button();
            this.txtMarkupPercent = new System.Windows.Forms.TextBox();
            this.lblMarkupPercent = new System.Windows.Forms.Label();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.lblSelectedMedicine = new System.Windows.Forms.Label();
            this.lblPricingSection = new System.Windows.Forms.Label();
            this.panelBulk = new System.Windows.Forms.Panel();
            this.btnBulkUpdate = new System.Windows.Forms.Button();
            this.txtBulkMarkup = new System.Windows.Forms.TextBox();
            this.lblBulkMarkup = new System.Windows.Forms.Label();
            this.lblBulkSection = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExportPricing = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPricing)).BeginInit();
            this.panelPricing.SuspendLayout();
            this.panelBulk.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(298, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Medicine Pricing Manager";
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.White;
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Location = new System.Drawing.Point(20, 85);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(750, 60);
            this.panelSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(620, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(170, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(430, 27);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(15, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(139, 20);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Medicine:";
            // 
            // dgvPricing
            // 
            this.dgvPricing.AllowUserToAddRows = false;
            this.dgvPricing.AllowUserToDeleteRows = false;
            this.dgvPricing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPricing.BackgroundColor = System.Drawing.Color.White;
            this.dgvPricing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPricing.Location = new System.Drawing.Point(20, 160);
            this.dgvPricing.MultiSelect = false;
            this.dgvPricing.Name = "dgvPricing";
            this.dgvPricing.ReadOnly = true;
            this.dgvPricing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPricing.Size = new System.Drawing.Size(750, 450);
            this.dgvPricing.TabIndex = 2;
            this.dgvPricing.SelectionChanged += new System.EventHandler(this.DgvPricing_SelectionChanged);
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalItems.Location = new System.Drawing.Point(20, 620);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(101, 19);
            this.lblTotalItems.TabIndex = 3;
            this.lblTotalItems.Text = "Total Items: 0";
            // 
            // panelPricing
            // 
            this.panelPricing.BackColor = System.Drawing.Color.White;
            this.panelPricing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPricing.Controls.Add(this.lblWarning);
            this.panelPricing.Controls.Add(this.lblProfit);
            this.panelPricing.Controls.Add(this.btnUpdatePrice);
            this.panelPricing.Controls.Add(this.txtMarkupPercent);
            this.panelPricing.Controls.Add(this.lblMarkupPercent);
            this.panelPricing.Controls.Add(this.txtSellingPrice);
            this.panelPricing.Controls.Add(this.lblSellingPrice);
            this.panelPricing.Controls.Add(this.txtCostPrice);
            this.panelPricing.Controls.Add(this.lblCostPrice);
            this.panelPricing.Controls.Add(this.lblSelectedMedicine);
            this.panelPricing.Controls.Add(this.lblPricingSection);
            this.panelPricing.Location = new System.Drawing.Point(790, 85);
            this.panelPricing.Name = "panelPricing";
            this.panelPricing.Size = new System.Drawing.Size(390, 340);
            this.panelPricing.TabIndex = 4;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(20, 250);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(59, 15);
            this.lblWarning.TabIndex = 10;
            this.lblWarning.Text = "⚠ Warning";
            this.lblWarning.Visible = false;
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfit.ForeColor = System.Drawing.Color.Green;
            this.lblProfit.Location = new System.Drawing.Point(20, 220);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(98, 21);
            this.lblProfit.TabIndex = 9;
            this.lblProfit.Text = "Profit: ₱0.00";
            // 
            // btnUpdatePrice
            // 
            this.btnUpdatePrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnUpdatePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePrice.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePrice.Location = new System.Drawing.Point(20, 280);
            this.btnUpdatePrice.Name = "btnUpdatePrice";
            this.btnUpdatePrice.Size = new System.Drawing.Size(350, 45);
            this.btnUpdatePrice.TabIndex = 8;
            this.btnUpdatePrice.Text = "Update Price";
            this.btnUpdatePrice.UseVisualStyleBackColor = false;
            this.btnUpdatePrice.Click += new System.EventHandler(this.BtnUpdatePrice_Click);
            // 
            // txtMarkupPercent
            // 
            this.txtMarkupPercent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMarkupPercent.Location = new System.Drawing.Point(160, 175);
            this.txtMarkupPercent.Name = "txtMarkupPercent";
            this.txtMarkupPercent.Size = new System.Drawing.Size(210, 27);
            this.txtMarkupPercent.TabIndex = 7;
            this.txtMarkupPercent.TextChanged += new System.EventHandler(this.TxtMarkupPercent_TextChanged);
            // 
            // lblMarkupPercent
            // 
            this.lblMarkupPercent.AutoSize = true;
            this.lblMarkupPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMarkupPercent.Location = new System.Drawing.Point(20, 178);
            this.lblMarkupPercent.Name = "lblMarkupPercent";
            this.lblMarkupPercent.Size = new System.Drawing.Size(86, 19);
            this.lblMarkupPercent.TabIndex = 6;
            this.lblMarkupPercent.Text = "Markup %:";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSellingPrice.Location = new System.Drawing.Point(160, 135);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(210, 27);
            this.txtSellingPrice.TabIndex = 5;
            this.txtSellingPrice.TextChanged += new System.EventHandler(this.TxtSellingPrice_TextChanged);
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSellingPrice.Location = new System.Drawing.Point(20, 138);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(100, 19);
            this.lblSellingPrice.TabIndex = 4;
            this.lblSellingPrice.Text = "Selling Price:";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCostPrice.Location = new System.Drawing.Point(160, 95);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(210, 27);
            this.txtCostPrice.TabIndex = 3;
            this.txtCostPrice.TextChanged += new System.EventHandler(this.TxtCostPrice_TextChanged);
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCostPrice.Location = new System.Drawing.Point(20, 98);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(81, 19);
            this.lblCostPrice.TabIndex = 2;
            this.lblCostPrice.Text = "Cost Price:";
            // 
            // lblSelectedMedicine
            // 
            this.lblSelectedMedicine.AutoSize = true;
            this.lblSelectedMedicine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblSelectedMedicine.ForeColor = System.Drawing.Color.Gray;
            this.lblSelectedMedicine.Location = new System.Drawing.Point(20, 60);
            this.lblSelectedMedicine.Name = "lblSelectedMedicine";
            this.lblSelectedMedicine.Size = new System.Drawing.Size(209, 19);
            this.lblSelectedMedicine.TabIndex = 1;
            this.lblSelectedMedicine.Text = "Selected: No medicine selected";
            // 
            // lblPricingSection
            // 
            this.lblPricingSection.AutoSize = true;
            this.lblPricingSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPricingSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPricingSection.Location = new System.Drawing.Point(15, 15);
            this.lblPricingSection.Name = "lblPricingSection";
            this.lblPricingSection.Size = new System.Drawing.Size(179, 21);
            this.lblPricingSection.TabIndex = 0;
            this.lblPricingSection.Text = "Individual Price Edit";
            // 
            // panelBulk
            // 
            this.panelBulk.BackColor = System.Drawing.Color.White;
            this.panelBulk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBulk.Controls.Add(this.btnBulkUpdate);
            this.panelBulk.Controls.Add(this.txtBulkMarkup);
            this.panelBulk.Controls.Add(this.lblBulkMarkup);
            this.panelBulk.Controls.Add(this.lblBulkSection);
            this.panelBulk.Location = new System.Drawing.Point(790, 440);
            this.panelBulk.Name = "panelBulk";
            this.panelBulk.Size = new System.Drawing.Size(390, 170);
            this.panelBulk.TabIndex = 5;
            // 
            // btnBulkUpdate
            // 
            this.btnBulkUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnBulkUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBulkUpdate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBulkUpdate.ForeColor = System.Drawing.Color.White;
            this.btnBulkUpdate.Location = new System.Drawing.Point(20, 105);
            this.btnBulkUpdate.Name = "btnBulkUpdate";
            this.btnBulkUpdate.Size = new System.Drawing.Size(350, 45);
            this.btnBulkUpdate.TabIndex = 3;
            this.btnBulkUpdate.Text = "Apply Bulk Markup";
            this.btnBulkUpdate.UseVisualStyleBackColor = false;
            this.btnBulkUpdate.Click += new System.EventHandler(this.BtnBulkUpdate_Click);
            // 
            // txtBulkMarkup
            // 
            this.txtBulkMarkup.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBulkMarkup.Location = new System.Drawing.Point(160, 60);
            this.txtBulkMarkup.Name = "txtBulkMarkup";
            this.txtBulkMarkup.Size = new System.Drawing.Size(210, 27);
            this.txtBulkMarkup.TabIndex = 2;
            // 
            // lblBulkMarkup
            // 
            this.lblBulkMarkup.AutoSize = true;
            this.lblBulkMarkup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBulkMarkup.Location = new System.Drawing.Point(20, 63);
            this.lblBulkMarkup.Name = "lblBulkMarkup";
            this.lblBulkMarkup.Size = new System.Drawing.Size(86, 19);
            this.lblBulkMarkup.TabIndex = 1;
            this.lblBulkMarkup.Text = "Markup %:";
            // 
            // lblBulkSection
            // 
            this.lblBulkSection.AutoSize = true;
            this.lblBulkSection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBulkSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBulkSection.Location = new System.Drawing.Point(15, 15);
            this.lblBulkSection.Name = "lblBulkSection";
            this.lblBulkSection.Size = new System.Drawing.Size(160, 21);
            this.lblBulkSection.TabIndex = 0;
            this.lblBulkSection.Text = "Bulk Price Update";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.White;
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnExportPricing);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Location = new System.Drawing.Point(20, 655);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1160, 70);
            this.panelButtons.TabIndex = 6;
            // 
            // btnExportPricing
            // 
            this.btnExportPricing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnExportPricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPricing.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportPricing.ForeColor = System.Drawing.Color.White;
            this.btnExportPricing.Location = new System.Drawing.Point(15, 12);
            this.btnExportPricing.Name = "btnExportPricing";
            this.btnExportPricing.Size = new System.Drawing.Size(180, 45);
            this.btnExportPricing.TabIndex = 0;
            this.btnExportPricing.Text = "Export to CSV";
            this.btnExportPricing.UseVisualStyleBackColor = false;
            this.btnExportPricing.Click += new System.EventHandler(this.BtnExportPricing_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(960, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ManagePricingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 740);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelBulk);
            this.Controls.Add(this.panelPricing);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.dgvPricing);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ManagePricingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Medicine Pricing - St. Joseph's Hospital";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPricing)).EndInit();
            this.panelPricing.ResumeLayout(false);
            this.panelPricing.PerformLayout();
            this.panelBulk.ResumeLayout(false);
            this.panelBulk.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}