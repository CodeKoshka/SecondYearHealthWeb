namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class AssignDoctorForm
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
            lblPatientInfo = new Label();
            panelSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            panelFilters = new Panel();
            rbAll = new RadioButton();
            rbOnDuty = new RadioButton();
            rbOffDuty = new RadioButton();
            lblDoctorCount = new Label();
            dgvDoctors = new DataGridView();
            panelButtons = new Panel();
            btnAssign = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            panelSearch.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            panelHeader.Controls.Add(this.lblTitle);
            panelHeader.Controls.Add(this.lblPatientInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(900, 90);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(220, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👨‍⚕️ Assign Doctor";
            // 
            // lblPatientInfo
            // 
            lblPatientInfo.AutoSize = true;
            lblPatientInfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblPatientInfo.ForeColor = System.Drawing.Color.White;
            lblPatientInfo.Location = new System.Drawing.Point(20, 55);
            lblPatientInfo.Name = "lblPatientInfo";
            lblPatientInfo.Size = new System.Drawing.Size(150, 20);
            lblPatientInfo.TabIndex = 1;
            lblPatientInfo.Text = "Assigning doctor for: ";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = System.Drawing.Color.White;
            panelSearch.Controls.Add(this.lblSearch);
            panelSearch.Controls.Add(this.txtSearch);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new System.Drawing.Point(0, 90);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(20, 15, 20, 15);
            panelSearch.Size = new System.Drawing.Size(900, 70);
            panelSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSearch.Location = new System.Drawing.Point(20, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(216, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "🔍 Search by name or specialization:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location = new System.Drawing.Point(20, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Type doctor name or specialization...";
            txtSearch.Size = new System.Drawing.Size(400, 25);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // panelFilters
            // 
            panelFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            panelFilters.Controls.Add(this.lblDoctorCount);
            panelFilters.Controls.Add(this.rbAll);
            panelFilters.Controls.Add(this.rbOnDuty);
            panelFilters.Controls.Add(this.rbOffDuty);
            panelFilters.Dock = DockStyle.Top;
            panelFilters.Location = new System.Drawing.Point(0, 160);
            panelFilters.Name = "panelFilters";
            panelFilters.Padding = new Padding(20, 10, 20, 10);
            panelFilters.Size = new System.Drawing.Size(900, 60);
            panelFilters.TabIndex = 2;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Checked = true;
            rbAll.Cursor = Cursors.Hand;
            rbAll.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            rbAll.Location = new System.Drawing.Point(20, 18);
            rbAll.Name = "rbAll";
            rbAll.Size = new System.Drawing.Size(107, 23);
            rbAll.TabIndex = 0;
            rbAll.TabStop = true;
            rbAll.Text = "📋 All (Show All)";
            rbAll.UseVisualStyleBackColor = true;
            rbAll.CheckedChanged += new System.EventHandler(this.RbAll_CheckedChanged);
            // 
            // rbOnDuty
            // 
            rbOnDuty.AutoSize = true;
            rbOnDuty.Cursor = Cursors.Hand;
            rbOnDuty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            rbOnDuty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            rbOnDuty.Location = new System.Drawing.Point(200, 18);
            rbOnDuty.Name = "rbOnDuty";
            rbOnDuty.Size = new System.Drawing.Size(106, 23);
            rbOnDuty.TabIndex = 1;
            rbOnDuty.Text = "🟢 On Duty";
            rbOnDuty.UseVisualStyleBackColor = true;
            rbOnDuty.CheckedChanged += new System.EventHandler(this.RbOnDuty_CheckedChanged);
            // 
            // rbOffDuty
            // 
            rbOffDuty.AutoSize = true;
            rbOffDuty.Cursor = Cursors.Hand;
            rbOffDuty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            rbOffDuty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            rbOffDuty.Location = new System.Drawing.Point(360, 18);
            rbOffDuty.Name = "rbOffDuty";
            rbOffDuty.Size = new System.Drawing.Size(111, 23);
            rbOffDuty.TabIndex = 2;
            rbOffDuty.Text = "🔴 Off Duty";
            rbOffDuty.UseVisualStyleBackColor = true;
            rbOffDuty.CheckedChanged += new System.EventHandler(this.RbOffDuty_CheckedChanged);
            // 
            // lblDoctorCount
            // 
            lblDoctorCount.AutoSize = true;
            lblDoctorCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDoctorCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            lblDoctorCount.Location = new System.Drawing.Point(550, 20);
            lblDoctorCount.Name = "lblDoctorCount";
            lblDoctorCount.Size = new System.Drawing.Size(0, 15);
            lblDoctorCount.TabIndex = 3;
            // 
            // dgvDoctors
            // 
            dgvDoctors.AllowUserToAddRows = false;
            dgvDoctors.AllowUserToDeleteRows = false;
            dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctors.BackgroundColor = System.Drawing.Color.White;
            dgvDoctors.BorderStyle = BorderStyle.None;
            dgvDoctors.ColumnHeadersHeight = 45;
            dgvDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDoctors.Cursor = Cursors.Hand;
            dgvDoctors.Dock = DockStyle.Fill;
            dgvDoctors.Location = new System.Drawing.Point(0, 220);
            dgvDoctors.MultiSelect = false;
            dgvDoctors.Name = "dgvDoctors";
            dgvDoctors.ReadOnly = true;
            dgvDoctors.RowHeadersVisible = false;
            dgvDoctors.RowTemplate.Height = 40;
            dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctors.Size = new System.Drawing.Size(900, 320);
            dgvDoctors.TabIndex = 3;
            dgvDoctors.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvDoctors_CellDoubleClick);
            dgvDoctors.CellFormatting += new DataGridViewCellFormattingEventHandler(this.DgvDoctors_CellFormatting);
            dgvDoctors.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.DgvDoctors_RowPrePaint);
            // 
            // panelButtons
            // 
            panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            panelButtons.Controls.Add(this.btnAssign);
            panelButtons.Controls.Add(this.btnCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new System.Drawing.Point(0, 540);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(20, 15, 20, 15);
            panelButtons.Size = new System.Drawing.Size(900, 80);
            panelButtons.TabIndex = 4;
            // 
            // btnAssign
            // 
            btnAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnAssign.Cursor = Cursors.Hand;
            btnAssign.FlatAppearance.BorderSize = 0;
            btnAssign.FlatStyle = FlatStyle.Flat;
            btnAssign.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnAssign.ForeColor = System.Drawing.Color.White;
            btnAssign.Location = new System.Drawing.Point(580, 15);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new System.Drawing.Size(150, 50);
            btnAssign.TabIndex = 0;
            btnAssign.Text = "✓ Assign";
            btnAssign.UseVisualStyleBackColor = false;
            btnAssign.Click += new System.EventHandler(this.BtnAssign_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(740, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(150, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AssignDoctorForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(900, 620);
            Controls.Add(this.dgvDoctors);
            Controls.Add(this.panelFilters);
            Controls.Add(this.panelSearch);
            Controls.Add(this.panelHeader);
            Controls.Add(this.panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AssignDoctorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Assign Doctor - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAssign;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblPatientInfo;
        private DataGridView dgvDoctors;
        private Panel panelHeader;
        private Panel panelSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel panelFilters;
        private RadioButton rbAll;
        private RadioButton rbOnDuty;
        private RadioButton rbOffDuty;
        private Label lblDoctorCount;
        private Panel panelButtons;
    }
}