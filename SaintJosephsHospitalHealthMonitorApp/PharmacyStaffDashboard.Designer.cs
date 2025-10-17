namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PharmacyStaffDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Panel panelTotalMeds;
        private System.Windows.Forms.Label lblTotalMedicines;
        private System.Windows.Forms.Label lblTotalMedsLabel;
        private System.Windows.Forms.Panel panelPendingOrders;
        private System.Windows.Forms.Label lblPendingOrders;
        private System.Windows.Forms.Label lblPendingOrdersLabel;
        private System.Windows.Forms.Panel panelLowStock;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblLowStockLabel;
        private System.Windows.Forms.Panel panelExpired;
        private System.Windows.Forms.Label lblExpiredMeds;
        private System.Windows.Forms.Label lblExpiredMedsLabel;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnManageInventory;
        private System.Windows.Forms.Button btnProcessOrders;
        private System.Windows.Forms.Button btnDispenseMedicine;
        private System.Windows.Forms.Button btnManagePricing;
        private System.Windows.Forms.Button btnReturnMedication;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelPendingOrdersList;
        private System.Windows.Forms.Label lblPendingOrdersTitle;
        private System.Windows.Forms.DataGridView dgvPendingOrders;
        private System.Windows.Forms.Panel panelLowStockList;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.DataGridView dgvLowStock;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.panelTotalMeds = new System.Windows.Forms.Panel();
            this.lblTotalMedicines = new System.Windows.Forms.Label();
            this.lblTotalMedsLabel = new System.Windows.Forms.Label();
            this.panelPendingOrders = new System.Windows.Forms.Panel();
            this.lblPendingOrders = new System.Windows.Forms.Label();
            this.lblPendingOrdersLabel = new System.Windows.Forms.Label();
            this.panelLowStock = new System.Windows.Forms.Panel();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblLowStockLabel = new System.Windows.Forms.Label();
            this.panelExpired = new System.Windows.Forms.Panel();
            this.lblExpiredMeds = new System.Windows.Forms.Label();
            this.lblExpiredMedsLabel = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnManageInventory = new System.Windows.Forms.Button();
            this.btnProcessOrders = new System.Windows.Forms.Button();
            this.btnDispenseMedicine = new System.Windows.Forms.Button();
            this.btnManagePricing = new System.Windows.Forms.Button();
            this.btnReturnMedication = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelPendingOrdersList = new System.Windows.Forms.Panel();
            this.lblPendingOrdersTitle = new System.Windows.Forms.Label();
            this.dgvPendingOrders = new System.Windows.Forms.DataGridView();
            this.panelLowStockList = new System.Windows.Forms.Panel();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.panelTotalMeds.SuspendLayout();
            this.panelPendingOrders.SuspendLayout();
            this.panelLowStock.SuspendLayout();
            this.panelExpired.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelPendingOrdersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).BeginInit();
            this.panelLowStockList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Pharmacy Management";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(22, 50);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(128, 19);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome, Pharmacist";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1260, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 40);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.panelTotalMeds);
            this.panelStats.Controls.Add(this.panelPendingOrders);
            this.panelStats.Controls.Add(this.panelLowStock);
            this.panelStats.Controls.Add(this.panelExpired);
            this.panelStats.Location = new System.Drawing.Point(20, 100);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(1360, 120);
            this.panelStats.TabIndex = 1;
            // 
            // panelTotalMeds
            // 
            this.panelTotalMeds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelTotalMeds.Controls.Add(this.lblTotalMedicines);
            this.panelTotalMeds.Controls.Add(this.lblTotalMedsLabel);
            this.panelTotalMeds.Location = new System.Drawing.Point(0, 0);
            this.panelTotalMeds.Name = "panelTotalMeds";
            this.panelTotalMeds.Size = new System.Drawing.Size(330, 120);
            this.panelTotalMeds.TabIndex = 0;
            // 
            // lblTotalMedicines
            // 
            this.lblTotalMedicines.AutoSize = true;
            this.lblTotalMedicines.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalMedicines.ForeColor = System.Drawing.Color.White;
            this.lblTotalMedicines.Location = new System.Drawing.Point(15, 40);
            this.lblTotalMedicines.Name = "lblTotalMedicines";
            this.lblTotalMedicines.Size = new System.Drawing.Size(51, 59);
            this.lblTotalMedicines.TabIndex = 0;
            this.lblTotalMedicines.Text = "0";
            // 
            // lblTotalMedsLabel
            // 
            this.lblTotalMedsLabel.AutoSize = true;
            this.lblTotalMedsLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalMedsLabel.ForeColor = System.Drawing.Color.White;
            this.lblTotalMedsLabel.Location = new System.Drawing.Point(15, 10);
            this.lblTotalMedsLabel.Name = "lblTotalMedsLabel";
            this.lblTotalMedsLabel.Size = new System.Drawing.Size(118, 21);
            this.lblTotalMedsLabel.TabIndex = 1;
            this.lblTotalMedsLabel.Text = "Total Medicines";
            // 
            // panelPendingOrders
            // 
            this.panelPendingOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelPendingOrders.Controls.Add(this.lblPendingOrders);
            this.panelPendingOrders.Controls.Add(this.lblPendingOrdersLabel);
            this.panelPendingOrders.Location = new System.Drawing.Point(340, 0);
            this.panelPendingOrders.Name = "panelPendingOrders";
            this.panelPendingOrders.Size = new System.Drawing.Size(330, 120);
            this.panelPendingOrders.TabIndex = 1;
            // 
            // lblPendingOrders
            // 
            this.lblPendingOrders.AutoSize = true;
            this.lblPendingOrders.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblPendingOrders.ForeColor = System.Drawing.Color.White;
            this.lblPendingOrders.Location = new System.Drawing.Point(15, 40);
            this.lblPendingOrders.Name = "lblPendingOrders";
            this.lblPendingOrders.Size = new System.Drawing.Size(51, 59);
            this.lblPendingOrders.TabIndex = 0;
            this.lblPendingOrders.Text = "0";
            // 
            // lblPendingOrdersLabel
            // 
            this.lblPendingOrdersLabel.AutoSize = true;
            this.lblPendingOrdersLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPendingOrdersLabel.ForeColor = System.Drawing.Color.White;
            this.lblPendingOrdersLabel.Location = new System.Drawing.Point(15, 10);
            this.lblPendingOrdersLabel.Name = "lblPendingOrdersLabel";
            this.lblPendingOrdersLabel.Size = new System.Drawing.Size(118, 21);
            this.lblPendingOrdersLabel.TabIndex = 1;
            this.lblPendingOrdersLabel.Text = "Pending Orders";
            // 
            // panelLowStock
            // 
            this.panelLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelLowStock.Controls.Add(this.lblLowStock);
            this.panelLowStock.Controls.Add(this.lblLowStockLabel);
            this.panelLowStock.Location = new System.Drawing.Point(680, 0);
            this.panelLowStock.Name = "panelLowStock";
            this.panelLowStock.Size = new System.Drawing.Size(330, 120);
            this.panelLowStock.TabIndex = 2;
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.ForeColor = System.Drawing.Color.White;
            this.lblLowStock.Location = new System.Drawing.Point(15, 40);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(51, 59);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "0";
            // 
            // lblLowStockLabel
            // 
            this.lblLowStockLabel.AutoSize = true;
            this.lblLowStockLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLowStockLabel.ForeColor = System.Drawing.Color.White;
            this.lblLowStockLabel.Location = new System.Drawing.Point(15, 10);
            this.lblLowStockLabel.Name = "lblLowStockLabel";
            this.lblLowStockLabel.Size = new System.Drawing.Size(116, 21);
            this.lblLowStockLabel.TabIndex = 1;
            this.lblLowStockLabel.Text = "Low Stock Items";
            // 
            // panelExpired
            // 
            this.panelExpired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.panelExpired.Controls.Add(this.lblExpiredMeds);
            this.panelExpired.Controls.Add(this.lblExpiredMedsLabel);
            this.panelExpired.Location = new System.Drawing.Point(1020, 0);
            this.panelExpired.Name = "panelExpired";
            this.panelExpired.Size = new System.Drawing.Size(330, 120);
            this.panelExpired.TabIndex = 3;
            // 
            // lblExpiredMeds
            // 
            this.lblExpiredMeds.AutoSize = true;
            this.lblExpiredMeds.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblExpiredMeds.ForeColor = System.Drawing.Color.White;
            this.lblExpiredMeds.Location = new System.Drawing.Point(15, 40);
            this.lblExpiredMeds.Name = "lblExpiredMeds";
            this.lblExpiredMeds.Size = new System.Drawing.Size(51, 59);
            this.lblExpiredMeds.TabIndex = 0;
            this.lblExpiredMeds.Text = "0";
            // 
            // lblExpiredMedsLabel
            // 
            this.lblExpiredMedsLabel.AutoSize = true;
            this.lblExpiredMedsLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblExpiredMedsLabel.ForeColor = System.Drawing.Color.White;
            this.lblExpiredMedsLabel.Location = new System.Drawing.Point(15, 10);
            this.lblExpiredMedsLabel.Name = "lblExpiredMedsLabel";
            this.lblExpiredMedsLabel.Size = new System.Drawing.Size(136, 21);
            this.lblExpiredMedsLabel.TabIndex = 1;
            this.lblExpiredMedsLabel.Text = "Expired Medicines";
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.Controls.Add(this.btnManageInventory);
            this.panelActions.Controls.Add(this.btnProcessOrders);
            this.panelActions.Controls.Add(this.btnDispenseMedicine);
            this.panelActions.Controls.Add(this.btnManagePricing);
            this.panelActions.Controls.Add(this.btnReturnMedication);
            this.panelActions.Controls.Add(this.btnReports);
            this.panelActions.Controls.Add(this.btnRefresh);
            this.panelActions.Location = new System.Drawing.Point(20, 240);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1360, 80);
            this.panelActions.TabIndex = 2;
            // 
            // btnManageInventory
            // 
            this.btnManageInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnManageInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageInventory.FlatAppearance.BorderSize = 0;
            this.btnManageInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageInventory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageInventory.ForeColor = System.Drawing.Color.White;
            this.btnManageInventory.Location = new System.Drawing.Point(20, 20);
            this.btnManageInventory.Name = "btnManageInventory";
            this.btnManageInventory.Size = new System.Drawing.Size(180, 45);
            this.btnManageInventory.TabIndex = 0;
            this.btnManageInventory.Text = "Manage Inventory";
            this.btnManageInventory.UseVisualStyleBackColor = false;
            this.btnManageInventory.Click += new System.EventHandler(this.BtnManageInventory_Click);
            // 
            // btnProcessOrders
            // 
            this.btnProcessOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProcessOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessOrders.FlatAppearance.BorderSize = 0;
            this.btnProcessOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessOrders.ForeColor = System.Drawing.Color.White;
            this.btnProcessOrders.Location = new System.Drawing.Point(215, 20);
            this.btnProcessOrders.Name = "btnProcessOrders";
            this.btnProcessOrders.Size = new System.Drawing.Size(180, 45);
            this.btnProcessOrders.TabIndex = 1;
            this.btnProcessOrders.Text = "Process Orders";
            this.btnProcessOrders.UseVisualStyleBackColor = false;
            this.btnProcessOrders.Click += new System.EventHandler(this.BtnProcessOrders_Click);
            // 
            // btnDispenseMedicine
            // 
            this.btnDispenseMedicine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnDispenseMedicine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispenseMedicine.FlatAppearance.BorderSize = 0;
            this.btnDispenseMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispenseMedicine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDispenseMedicine.ForeColor = System.Drawing.Color.White;
            this.btnDispenseMedicine.Location = new System.Drawing.Point(410, 20);
            this.btnDispenseMedicine.Name = "btnDispenseMedicine";
            this.btnDispenseMedicine.Size = new System.Drawing.Size(180, 45);
            this.btnDispenseMedicine.TabIndex = 2;
            this.btnDispenseMedicine.Text = "Dispense Medicine";
            this.btnDispenseMedicine.UseVisualStyleBackColor = false;
            this.btnDispenseMedicine.Click += new System.EventHandler(this.BtnDispenseMedicine_Click);
            // 
            // btnManagePricing
            // 
            this.btnManagePricing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnManagePricing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManagePricing.FlatAppearance.BorderSize = 0;
            this.btnManagePricing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagePricing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManagePricing.ForeColor = System.Drawing.Color.White;
            this.btnManagePricing.Location = new System.Drawing.Point(605, 20);
            this.btnManagePricing.Name = "btnManagePricing";
            this.btnManagePricing.Size = new System.Drawing.Size(180, 45);
            this.btnManagePricing.TabIndex = 3;
            this.btnManagePricing.Text = "Manage Pricing";
            this.btnManagePricing.UseVisualStyleBackColor = false;
            this.btnManagePricing.Click += new System.EventHandler(this.BtnManagePricing_Click);
            // 
            // btnReturnMedication
            // 
            this.btnReturnMedication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnReturnMedication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturnMedication.FlatAppearance.BorderSize = 0;
            this.btnReturnMedication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnMedication.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReturnMedication.ForeColor = System.Drawing.Color.White;
            this.btnReturnMedication.Location = new System.Drawing.Point(800, 20);
            this.btnReturnMedication.Name = "btnReturnMedication";
            this.btnReturnMedication.Size = new System.Drawing.Size(180, 45);
            this.btnReturnMedication.TabIndex = 4;
            this.btnReturnMedication.Text = "Return Medication";
            this.btnReturnMedication.UseVisualStyleBackColor = false;
            this.btnReturnMedication.Click += new System.EventHandler(this.BtnReturnMedication_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(995, 20);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(180, 45);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1190, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 45);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // panelPendingOrdersList
            // 
            this.panelPendingOrdersList.BackColor = System.Drawing.Color.White;
            this.panelPendingOrdersList.Controls.Add(this.lblPendingOrdersTitle);
            this.panelPendingOrdersList.Controls.Add(this.dgvPendingOrders);
            this.panelPendingOrdersList.Location = new System.Drawing.Point(20, 340);
            this.panelPendingOrdersList.Name = "panelPendingOrdersList";
            this.panelPendingOrdersList.Size = new System.Drawing.Size(880, 380);
            this.panelPendingOrdersList.TabIndex = 3;
            // 
            // lblPendingOrdersTitle
            // 
            this.lblPendingOrdersTitle.AutoSize = true;
            this.lblPendingOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPendingOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPendingOrdersTitle.Location = new System.Drawing.Point(15, 15);
            this.lblPendingOrdersTitle.Name = "lblPendingOrdersTitle";
            this.lblPendingOrdersTitle.Size = new System.Drawing.Size(239, 25);
            this.lblPendingOrdersTitle.TabIndex = 0;
            this.lblPendingOrdersTitle.Text = "Pending Medication Orders";
            // 
            // dgvPendingOrders
            // 
            this.dgvPendingOrders.AllowUserToAddRows = false;
            this.dgvPendingOrders.AllowUserToDeleteRows = false;
            this.dgvPendingOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendingOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvPendingOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPendingOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingOrders.Location = new System.Drawing.Point(15, 55);
            this.dgvPendingOrders.Name = "dgvPendingOrders";
            this.dgvPendingOrders.ReadOnly = true;
            this.dgvPendingOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingOrders.Size = new System.Drawing.Size(850, 310);
            this.dgvPendingOrders.TabIndex = 1;
            this.dgvPendingOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPendingOrders_CellDoubleClick);
            // 
            // panelLowStockList
            // 
            this.panelLowStockList.BackColor = System.Drawing.Color.White;
            this.panelLowStockList.Controls.Add(this.lblLowStockTitle);
            this.panelLowStockList.Controls.Add(this.dgvLowStock);
            this.panelLowStockList.Location = new System.Drawing.Point(920, 340);
            this.panelLowStockList.Name = "panelLowStockList";
            this.panelLowStockList.Size = new System.Drawing.Size(460, 380);
            this.panelLowStockList.TabIndex = 4;
            // 
            // lblLowStockTitle
            // 
            this.lblLowStockTitle.AutoSize = true;
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblLowStockTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLowStockTitle.Name = "lblLowStockTitle";
            this.lblLowStockTitle.Size = new System.Drawing.Size(203, 25);
            this.lblLowStockTitle.TabIndex = 0;
            this.lblLowStockTitle.Text = "Low Stock Alert Items";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvLowStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Location = new System.Drawing.Point(15, 55);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(430, 310);
            this.dgvLowStock.TabIndex = 1;
            // 
            // PharmacyStaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.panelLowStockList);
            this.Controls.Add(this.panelPendingOrdersList);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PharmacyStaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pharmacy Staff Dashboard";
            this.Load += new System.EventHandler(this.PharmacyStaffForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelStats.ResumeLayout(false);
            this.panelTotalMeds.ResumeLayout(false);
            this.panelTotalMeds.PerformLayout();
            this.panelPendingOrders.ResumeLayout(false);
            this.panelPendingOrders.PerformLayout();
            this.panelLowStock.ResumeLayout(false);
            this.panelLowStock.PerformLayout();
            this.panelExpired.ResumeLayout(false);
            this.panelExpired.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelPendingOrdersList.ResumeLayout(false);
            this.panelPendingOrdersList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingOrders)).EndInit();
            this.panelLowStockList.ResumeLayout(false);
            this.panelLowStockList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false);
        }
    }
}