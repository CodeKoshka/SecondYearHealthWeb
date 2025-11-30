namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PharmacyStaffDashboard
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
            panelTop = new Panel();
            lblTitle = new Label();
            lblWelcome = new Label();
            btnLogout = new Button();
            panelStats = new Panel();
            panelTotalMeds = new Panel();
            lblTotalMedicines = new Label();
            lblTotalMedsLabel = new Label();
            panelPendingOrders = new Panel();
            lblPendingOrders = new Label();
            lblPendingOrdersLabel = new Label();
            panelLowStock = new Panel();
            lblLowStock = new Label();
            lblLowStockLabel = new Label();
            panelExpired = new Panel();
            lblExpiredMeds = new Label();
            lblExpiredMedsLabel = new Label();
            panelActions = new Panel();
            btnManageInventory = new Button();
            btnProcessOrders = new Button();
            btnDispenseMedicine = new Button();
            btnManagePricing = new Button();
            btnReturnMedication = new Button();
            btnReports = new Button();
            btnRefresh = new Button();
            panelPendingOrdersList = new Panel();
            lblPendingOrdersTitle = new Label();
            dgvPendingOrders = new DataGridView();
            panelLowStockList = new Panel();
            lblLowStockTitle = new Label();
            dgvLowStock = new DataGridView();
            panelTop.SuspendLayout();
            panelStats.SuspendLayout();
            panelTotalMeds.SuspendLayout();
            panelPendingOrders.SuspendLayout();
            panelLowStock.SuspendLayout();
            panelExpired.SuspendLayout();
            panelActions.SuspendLayout();
            panelPendingOrdersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPendingOrders)).BeginInit();
            panelLowStockList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvLowStock)).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblWelcome);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(1400, 80);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(288, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Pharmacy Management";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblWelcome.ForeColor = System.Drawing.Color.White;
            lblWelcome.Location = new System.Drawing.Point(22, 50);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(128, 19);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome, Pharmacist";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.Location = new System.Drawing.Point(1260, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(120, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += new System.EventHandler(BtnLogout_Click);
            // 
            // panelStats
            // 
            panelStats.Controls.Add(panelTotalMeds);
            panelStats.Controls.Add(panelPendingOrders);
            panelStats.Controls.Add(panelLowStock);
            panelStats.Controls.Add(panelExpired);
            panelStats.Location = new System.Drawing.Point(20, 100);
            panelStats.Name = "panelStats";
            panelStats.Size = new System.Drawing.Size(1360, 120);
            panelStats.TabIndex = 1;
            // 
            // panelTotalMeds
            // 
            panelTotalMeds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            panelTotalMeds.Controls.Add(lblTotalMedicines);
            panelTotalMeds.Controls.Add(lblTotalMedsLabel);
            panelTotalMeds.Location = new System.Drawing.Point(0, 0);
            panelTotalMeds.Name = "panelTotalMeds";
            panelTotalMeds.Size = new System.Drawing.Size(330, 120);
            panelTotalMeds.TabIndex = 0;
            // 
            // lblTotalMedicines
            // 
            lblTotalMedicines.AutoSize = true;
            lblTotalMedicines.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            lblTotalMedicines.ForeColor = System.Drawing.Color.White;
            lblTotalMedicines.Location = new System.Drawing.Point(15, 40);
            lblTotalMedicines.Name = "lblTotalMedicines";
            lblTotalMedicines.Size = new System.Drawing.Size(51, 59);
            lblTotalMedicines.TabIndex = 0;
            lblTotalMedicines.Text = "0";
            // 
            // lblTotalMedsLabel
            // 
            lblTotalMedsLabel.AutoSize = true;
            lblTotalMedsLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblTotalMedsLabel.ForeColor = System.Drawing.Color.White;
            lblTotalMedsLabel.Location = new System.Drawing.Point(15, 10);
            lblTotalMedsLabel.Name = "lblTotalMedsLabel";
            lblTotalMedsLabel.Size = new System.Drawing.Size(118, 21);
            lblTotalMedsLabel.TabIndex = 1;
            lblTotalMedsLabel.Text = "Total Medicines";
            // 
            // panelPendingOrders
            // 
            panelPendingOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            panelPendingOrders.Controls.Add(lblPendingOrders);
            panelPendingOrders.Controls.Add(lblPendingOrdersLabel);
            panelPendingOrders.Location = new System.Drawing.Point(340, 0);
            panelPendingOrders.Name = "panelPendingOrders";
            panelPendingOrders.Size = new System.Drawing.Size(330, 120);
            panelPendingOrders.TabIndex = 1;
            // 
            // lblPendingOrders
            // 
            lblPendingOrders.AutoSize = true;
            lblPendingOrders.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            lblPendingOrders.ForeColor = System.Drawing.Color.White;
            lblPendingOrders.Location = new System.Drawing.Point(15, 40);
            lblPendingOrders.Name = "lblPendingOrders";
            lblPendingOrders.Size = new System.Drawing.Size(51, 59);
            lblPendingOrders.TabIndex = 0;
            lblPendingOrders.Text = "0";
            // 
            // lblPendingOrdersLabel
            // 
            lblPendingOrdersLabel.AutoSize = true;
            lblPendingOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblPendingOrdersLabel.ForeColor = System.Drawing.Color.White;
            lblPendingOrdersLabel.Location = new System.Drawing.Point(15, 10);
            lblPendingOrdersLabel.Name = "lblPendingOrdersLabel";
            lblPendingOrdersLabel.Size = new System.Drawing.Size(118, 21);
            lblPendingOrdersLabel.TabIndex = 1;
            lblPendingOrdersLabel.Text = "Pending Orders";
            // 
            // panelLowStock
            // 
            panelLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            panelLowStock.Controls.Add(lblLowStock);
            panelLowStock.Controls.Add(lblLowStockLabel);
            panelLowStock.Location = new System.Drawing.Point(680, 0);
            panelLowStock.Name = "panelLowStock";
            panelLowStock.Size = new System.Drawing.Size(330, 120);
            panelLowStock.TabIndex = 2;
            // 
            // lblLowStock
            // 
            lblLowStock.AutoSize = true;
            lblLowStock.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            lblLowStock.ForeColor = System.Drawing.Color.White;
            lblLowStock.Location = new System.Drawing.Point(15, 40);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new System.Drawing.Size(51, 59);
            lblLowStock.TabIndex = 0;
            lblLowStock.Text = "0";
            // 
            // lblLowStockLabel
            // 
            lblLowStockLabel.AutoSize = true;
            lblLowStockLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblLowStockLabel.ForeColor = System.Drawing.Color.White;
            lblLowStockLabel.Location = new System.Drawing.Point(15, 10);
            lblLowStockLabel.Name = "lblLowStockLabel";
            lblLowStockLabel.Size = new System.Drawing.Size(116, 21);
            lblLowStockLabel.TabIndex = 1;
            lblLowStockLabel.Text = "Low Stock Items";
            // 
            // panelExpired
            // 
            panelExpired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            panelExpired.Controls.Add(lblExpiredMeds);
            panelExpired.Controls.Add(lblExpiredMedsLabel);
            panelExpired.Location = new System.Drawing.Point(1020, 0);
            panelExpired.Name = "panelExpired";
            panelExpired.Size = new System.Drawing.Size(330, 120);
            panelExpired.TabIndex = 3;
            // 
            // lblExpiredMeds
            // 
            lblExpiredMeds.AutoSize = true;
            lblExpiredMeds.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            lblExpiredMeds.ForeColor = System.Drawing.Color.White;
            lblExpiredMeds.Location = new System.Drawing.Point(15, 40);
            lblExpiredMeds.Name = "lblExpiredMeds";
            lblExpiredMeds.Size = new System.Drawing.Size(51, 59);
            lblExpiredMeds.TabIndex = 0;
            lblExpiredMeds.Text = "0";
            // 
            // lblExpiredMedsLabel
            // 
            lblExpiredMedsLabel.AutoSize = true;
            lblExpiredMedsLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblExpiredMedsLabel.ForeColor = System.Drawing.Color.White;
            lblExpiredMedsLabel.Location = new System.Drawing.Point(15, 10);
            lblExpiredMedsLabel.Name = "lblExpiredMedsLabel";
            lblExpiredMedsLabel.Size = new System.Drawing.Size(136, 21);
            lblExpiredMedsLabel.TabIndex = 1;
            lblExpiredMedsLabel.Text = "Expired Medicines";
            // 
            // panelActions
            // 
            panelActions.BackColor = System.Drawing.Color.White;
            panelActions.Controls.Add(btnManageInventory);
            panelActions.Controls.Add(btnProcessOrders);
            panelActions.Controls.Add(btnDispenseMedicine);
            panelActions.Controls.Add(btnManagePricing);
            panelActions.Controls.Add(btnReturnMedication);
            panelActions.Controls.Add(btnReports);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Location = new System.Drawing.Point(20, 240);
            panelActions.Name = "panelActions";
            panelActions.Size = new System.Drawing.Size(1360, 80);
            panelActions.TabIndex = 2;
            // 
            // btnManageInventory
            // 
            btnManageInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnManageInventory.Cursor = Cursors.Hand;
            btnManageInventory.FlatAppearance.BorderSize = 0;
            btnManageInventory.FlatStyle = FlatStyle.Flat;
            btnManageInventory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnManageInventory.ForeColor = System.Drawing.Color.White;
            btnManageInventory.Location = new System.Drawing.Point(20, 20);
            btnManageInventory.Name = "btnManageInventory";
            btnManageInventory.Size = new System.Drawing.Size(180, 45);
            btnManageInventory.TabIndex = 0;
            btnManageInventory.Text = "Manage Inventory";
            btnManageInventory.UseVisualStyleBackColor = false;
            btnManageInventory.Click += new System.EventHandler(BtnManageInventory_Click);
            // 
            // btnProcessOrders
            // 
            btnProcessOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnProcessOrders.Cursor = Cursors.Hand;
            btnProcessOrders.FlatAppearance.BorderSize = 0;
            btnProcessOrders.FlatStyle = FlatStyle.Flat;
            btnProcessOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProcessOrders.ForeColor = System.Drawing.Color.White;
            btnProcessOrders.Location = new System.Drawing.Point(215, 20);
            btnProcessOrders.Name = "btnProcessOrders";
            btnProcessOrders.Size = new System.Drawing.Size(180, 45);
            btnProcessOrders.TabIndex = 1;
            btnProcessOrders.Text = "Process Orders";
            btnProcessOrders.UseVisualStyleBackColor = false;
            btnProcessOrders.Click += new System.EventHandler(BtnProcessOrders_Click);
            // 
            // btnDispenseMedicine
            // 
            btnDispenseMedicine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            btnDispenseMedicine.Cursor = Cursors.Hand;
            btnDispenseMedicine.FlatAppearance.BorderSize = 0;
            btnDispenseMedicine.FlatStyle = FlatStyle.Flat;
            btnDispenseMedicine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDispenseMedicine.ForeColor = System.Drawing.Color.White;
            btnDispenseMedicine.Location = new System.Drawing.Point(410, 20);
            btnDispenseMedicine.Name = "btnDispenseMedicine";
            btnDispenseMedicine.Size = new System.Drawing.Size(180, 45);
            btnDispenseMedicine.TabIndex = 2;
            btnDispenseMedicine.Text = "Dispense Medicine";
            btnDispenseMedicine.UseVisualStyleBackColor = false;
            btnDispenseMedicine.Click += new System.EventHandler(BtnDispenseMedicine_Click);
            // 
            // btnManagePricing
            // 
            btnManagePricing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            btnManagePricing.Cursor = Cursors.Hand;
            btnManagePricing.FlatAppearance.BorderSize = 0;
            btnManagePricing.FlatStyle = FlatStyle.Flat;
            btnManagePricing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnManagePricing.ForeColor = System.Drawing.Color.White;
            btnManagePricing.Location = new System.Drawing.Point(605, 20);
            btnManagePricing.Name = "btnManagePricing";
            btnManagePricing.Size = new System.Drawing.Size(180, 45);
            btnManagePricing.TabIndex = 3;
            btnManagePricing.Text = "Manage Pricing";
            btnManagePricing.UseVisualStyleBackColor = false;
            btnManagePricing.Click += new System.EventHandler(BtnManagePricing_Click);
            // 
            // btnReturnMedication
            // 
            btnReturnMedication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            btnReturnMedication.Cursor = Cursors.Hand;
            btnReturnMedication.FlatAppearance.BorderSize = 0;
            btnReturnMedication.FlatStyle = FlatStyle.Flat;
            btnReturnMedication.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnReturnMedication.ForeColor = System.Drawing.Color.White;
            btnReturnMedication.Location = new System.Drawing.Point(800, 20);
            btnReturnMedication.Name = "btnReturnMedication";
            btnReturnMedication.Size = new System.Drawing.Size(180, 45);
            btnReturnMedication.TabIndex = 4;
            btnReturnMedication.Text = "Return Medication";
            btnReturnMedication.UseVisualStyleBackColor = false;
            btnReturnMedication.Click += new System.EventHandler(BtnReturnMedication_Click);
            // 
            // btnReports
            // 
            btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            btnReports.Cursor = Cursors.Hand;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnReports.ForeColor = System.Drawing.Color.White;
            btnReports.Location = new System.Drawing.Point(995, 20);
            btnReports.Name = "btnReports";
            btnReports.Size = new System.Drawing.Size(180, 45);
            btnReports.TabIndex = 5;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += new System.EventHandler(BtnReports_Click);
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(1190, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(150, 45);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += new System.EventHandler(BtnRefresh_Click);
            // 
            // panelPendingOrdersList
            // 
            panelPendingOrdersList.BackColor = System.Drawing.Color.White;
            panelPendingOrdersList.Controls.Add(lblPendingOrdersTitle);
            panelPendingOrdersList.Controls.Add(dgvPendingOrders);
            panelPendingOrdersList.Location = new System.Drawing.Point(20, 340);
            panelPendingOrdersList.Name = "panelPendingOrdersList";
            panelPendingOrdersList.Size = new System.Drawing.Size(880, 380);
            panelPendingOrdersList.TabIndex = 3;
            // 
            // lblPendingOrdersTitle
            // 
            lblPendingOrdersTitle.AutoSize = true;
            lblPendingOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblPendingOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            lblPendingOrdersTitle.Location = new System.Drawing.Point(15, 15);
            lblPendingOrdersTitle.Name = "lblPendingOrdersTitle";
            lblPendingOrdersTitle.Size = new System.Drawing.Size(239, 25);
            lblPendingOrdersTitle.TabIndex = 0;
            lblPendingOrdersTitle.Text = "Pending Medication Orders";
            // 
            // dgvPendingOrders
            // 
            dgvPendingOrders.AllowUserToAddRows = false;
            dgvPendingOrders.AllowUserToDeleteRows = false;
            dgvPendingOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPendingOrders.BackgroundColor = System.Drawing.Color.White;
            dgvPendingOrders.BorderStyle = BorderStyle.None;
            dgvPendingOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingOrders.Location = new System.Drawing.Point(15, 55);
            dgvPendingOrders.Name = "dgvPendingOrders";
            dgvPendingOrders.ReadOnly = true;
            dgvPendingOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingOrders.Size = new System.Drawing.Size(850, 310);
            dgvPendingOrders.TabIndex = 1;
            dgvPendingOrders.CellDoubleClick += new DataGridViewCellEventHandler(DgvPendingOrders_CellDoubleClick);
            // 
            // panelLowStockList
            // 
            panelLowStockList.BackColor = System.Drawing.Color.White;
            panelLowStockList.Controls.Add(lblLowStockTitle);
            panelLowStockList.Controls.Add(dgvLowStock);
            panelLowStockList.Location = new System.Drawing.Point(920, 340);
            panelLowStockList.Name = "panelLowStockList";
            panelLowStockList.Size = new System.Drawing.Size(460, 380);
            panelLowStockList.TabIndex = 4;
            // 
            // lblLowStockTitle
            // 
            lblLowStockTitle.AutoSize = true;
            lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            lblLowStockTitle.Location = new System.Drawing.Point(15, 15);
            lblLowStockTitle.Name = "lblLowStockTitle";
            lblLowStockTitle.Size = new System.Drawing.Size(203, 25);
            lblLowStockTitle.TabIndex = 0;
            lblLowStockTitle.Text = "Low Stock Alert Items";
            // 
            // dgvLowStock
            // 
            dgvLowStock.AllowUserToAddRows = false;
            dgvLowStock.AllowUserToDeleteRows = false;
            dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            dgvLowStock.BorderStyle = BorderStyle.None;
            dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLowStock.Location = new System.Drawing.Point(15, 55);
            dgvLowStock.Name = "dgvLowStock";
            dgvLowStock.ReadOnly = true;
            dgvLowStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLowStock.Size = new System.Drawing.Size(430, 310);
            dgvLowStock.TabIndex = 1;
            // 
            // PharmacyStaffForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            ClientSize = new System.Drawing.Size(1400, 750);
            Controls.Add(panelLowStockList);
            Controls.Add(panelPendingOrdersList);
            Controls.Add(panelActions);
            Controls.Add(panelStats);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PharmacyStaffForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pharmacy Staff Dashboard";
            Load += new System.EventHandler(PharmacyStaffForm_Load);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelStats.ResumeLayout(false);
            panelTotalMeds.ResumeLayout(false);
            panelTotalMeds.PerformLayout();
            panelPendingOrders.ResumeLayout(false);
            panelPendingOrders.PerformLayout();
            panelLowStock.ResumeLayout(false);
            panelLowStock.PerformLayout();
            panelExpired.ResumeLayout(false);
            panelExpired.PerformLayout();
            panelActions.ResumeLayout(false);
            panelPendingOrdersList.ResumeLayout(false);
            panelPendingOrdersList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPendingOrders)).EndInit();
            panelLowStockList.ResumeLayout(false);
            panelLowStockList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvLowStock)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Label lblWelcome;
        private Button btnLogout;
        private Panel panelStats;
        private Panel panelTotalMeds;
        private Label lblTotalMedicines;
        private Label lblTotalMedsLabel;
        private Panel panelPendingOrders;
        private Label lblPendingOrders;
        private Label lblPendingOrdersLabel;
        private Panel panelLowStock;
        private Label lblLowStock;
        private Label lblLowStockLabel;
        private Panel panelExpired;
        private Label lblExpiredMeds;
        private Label lblExpiredMedsLabel;
        private Panel panelActions;
        private Button btnManageInventory;
        private Button btnProcessOrders;
        private Button btnDispenseMedicine;
        private Button btnManagePricing;
        private Button btnReturnMedication;
        private Button btnReports;
        private Button btnRefresh;
        private Panel panelPendingOrdersList;
        private Label lblPendingOrdersTitle;
        private DataGridView dgvPendingOrders;
        private Panel panelLowStockList;
        private Label lblLowStockTitle;
        private DataGridView dgvLowStock;
    }
}