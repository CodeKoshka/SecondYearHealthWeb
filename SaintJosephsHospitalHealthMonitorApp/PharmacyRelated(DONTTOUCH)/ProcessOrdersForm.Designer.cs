namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ProcessOrdersForm
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
            pnlTop = new Panel();
            lblTitle = new Label();
            pnlFilter = new Panel();
            lblStatusFilter = new Label();
            cmbStatusFilter = new ComboBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            dgvOrders = new DataGridView();
            pnlBottom = new Panel();
            lblTotalOrders = new Label();
            btnViewDetails = new Button();
            btnValidateOrder = new Button();
            btnDispenseOrder = new Button();
            btnCancelOrder = new Button();
            btnClose = new Button();
            pnlTop.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvOrders)).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(1200, 70);
            pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(367, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Process Medication Orders";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            pnlFilter.Controls.Add(lblStatusFilter);
            pnlFilter.Controls.Add(cmbStatusFilter);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new System.Drawing.Point(0, 70);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(1200, 80);
            pnlFilter.TabIndex = 1;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblStatusFilter.Location = new System.Drawing.Point(20, 28);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new System.Drawing.Size(93, 19);
            lblStatusFilter.TabIndex = 0;
            lblStatusFilter.Text = "Filter by Status:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new System.Drawing.Point(120, 25);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new System.Drawing.Size(180, 25);
            cmbStatusFilter.TabIndex = 1;
            cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(CmbStatusFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location = new System.Drawing.Point(330, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(300, 25);
            txtSearch.TabIndex = 2;
            txtSearch.PlaceholderText = "Search by Patient, Doctor, Medicine, or Order ID";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(640, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(100, 32);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(750, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(100, 32);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += new System.EventHandler(BtnRefresh_Click);
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = System.Drawing.Color.White;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new System.Drawing.Point(0, 150);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new System.Drawing.Size(1200, 420);
            dgvOrders.TabIndex = 2;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            pnlBottom.Controls.Add(lblTotalOrders);
            pnlBottom.Controls.Add(btnViewDetails);
            pnlBottom.Controls.Add(btnValidateOrder);
            pnlBottom.Controls.Add(btnDispenseOrder);
            pnlBottom.Controls.Add(btnCancelOrder);
            pnlBottom.Controls.Add(btnClose);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new System.Drawing.Point(0, 570);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new System.Drawing.Size(1200, 80);
            pnlBottom.TabIndex = 3;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTotalOrders.Location = new System.Drawing.Point(20, 30);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new System.Drawing.Size(103, 19);
            lblTotalOrders.TabIndex = 0;
            lblTotalOrders.Text = "Total Orders: 0";
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnViewDetails.ForeColor = System.Drawing.Color.White;
            btnViewDetails.Location = new System.Drawing.Point(420, 20);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new System.Drawing.Size(130, 40);
            btnViewDetails.TabIndex = 1;
            btnViewDetails.Text = "📋 View Details";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += new System.EventHandler(BtnViewDetails_Click);
            // 
            // btnValidateOrder
            // 
            btnValidateOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnValidateOrder.FlatStyle = FlatStyle.Flat;
            btnValidateOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnValidateOrder.ForeColor = System.Drawing.Color.White;
            btnValidateOrder.Location = new System.Drawing.Point(560, 20);
            btnValidateOrder.Name = "btnValidateOrder";
            btnValidateOrder.Size = new System.Drawing.Size(130, 40);
            btnValidateOrder.TabIndex = 2;
            btnValidateOrder.Text = "✓ Validate";
            btnValidateOrder.UseVisualStyleBackColor = false;
            btnValidateOrder.Click += new System.EventHandler(BtnValidateOrder_Click);
            // 
            // btnDispenseOrder
            // 
            btnDispenseOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            btnDispenseOrder.FlatStyle = FlatStyle.Flat;
            btnDispenseOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDispenseOrder.ForeColor = System.Drawing.Color.White;
            btnDispenseOrder.Location = new System.Drawing.Point(700, 20);
            btnDispenseOrder.Name = "btnDispenseOrder";
            btnDispenseOrder.Size = new System.Drawing.Size(130, 40);
            btnDispenseOrder.TabIndex = 3;
            btnDispenseOrder.Text = "💊 Dispense";
            btnDispenseOrder.UseVisualStyleBackColor = false;
            btnDispenseOrder.Click += new System.EventHandler(BtnDispenseOrder_Click);
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnCancelOrder.FlatStyle = FlatStyle.Flat;
            btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCancelOrder.ForeColor = System.Drawing.Color.White;
            btnCancelOrder.Location = new System.Drawing.Point(840, 20);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new System.Drawing.Size(130, 40);
            btnCancelOrder.TabIndex = 4;
            btnCancelOrder.Text = "✖ Cancel Order";
            btnCancelOrder.UseVisualStyleBackColor = false;
            btnCancelOrder.Click += new System.EventHandler(BtnCancelOrder_Click);
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1050, 20);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(130, 40);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(BtnClose_Click);
            // 
            // ProcessOrdersForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1200, 650);
            Controls.Add(dgvOrders);
            Controls.Add(pnlBottom);
            Controls.Add(pnlFilter);
            Controls.Add(pnlTop);
            Name = "ProcessOrdersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Process Medication Orders - St. Joseph's Hospital";
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvOrders)).EndInit();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Panel pnlFilter;
        private Label lblStatusFilter;
        private ComboBox cmbStatusFilter;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private DataGridView dgvOrders;
        private Panel pnlBottom;
        private Label lblTotalOrders;
        private Button btnViewDetails;
        private Button btnValidateOrder;
        private Button btnDispenseOrder;
        private Button btnCancelOrder;
        private Button btnClose;
    }
}