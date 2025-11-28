namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class AddToQueueForm
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
            lblInstruction = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblPatientCount = new Label();
            dgvPatients = new DataGridView();
            panelButtons = new Panel();
            btnSelect = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            panelHeader.Controls.Add(this.lblTitle);
            panelHeader.Controls.Add(this.lblInstruction);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1000, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(285, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "➕ Add Patient to Queue";
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblInstruction.ForeColor = System.Drawing.Color.White;
            lblInstruction.Location = new System.Drawing.Point(20, 50);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new System.Drawing.Size(531, 19);
            lblInstruction.TabIndex = 1;
            lblInstruction.Text = "Click on any patient row to select, then click 'Select & Continue to Intake'";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSearch.Location = new System.Drawing.Point(20, 100);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(111, 19);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "🔍 Search Patient:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtSearch.Location = new System.Drawing.Point(20, 125);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name, blood type, or gender...";
            txtSearch.Size = new System.Drawing.Size(500, 27);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblPatientCount
            // 
            lblPatientCount.AutoSize = true;
            lblPatientCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblPatientCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            lblPatientCount.Location = new System.Drawing.Point(530, 130);
            lblPatientCount.Name = "lblPatientCount";
            lblPatientCount.Size = new System.Drawing.Size(145, 19);
            lblPatientCount.TabIndex = 3;
            lblPatientCount.Text = "Available Patients: 0";
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = System.Drawing.Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.ColumnHeadersHeight = 40;
            dgvPatients.Cursor = Cursors.Hand;
            dgvPatients.Location = new System.Drawing.Point(20, 165);
            dgvPatients.MultiSelect = false;
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.RowTemplate.Height = 35;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new System.Drawing.Size(960, 385);
            dgvPatients.TabIndex = 4;
            dgvPatients.CellClick += new DataGridViewCellEventHandler(this.DgvPatients_CellClick);
            dgvPatients.CellDoubleClick += new DataGridViewCellEventHandler(this.DgvPatients_CellDoubleClick);
            // 
            // panelButtons
            // 
            panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            panelButtons.Controls.Add(this.btnSelect);
            panelButtons.Controls.Add(this.btnCancel);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new System.Drawing.Point(0, 565);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(1000, 75);
            panelButtons.TabIndex = 5;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnSelect.Cursor = Cursors.Hand;
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSelect.ForeColor = System.Drawing.Color.White;
            btnSelect.Location = new System.Drawing.Point(630, 15);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new System.Drawing.Size(250, 45);
            btnSelect.TabIndex = 0;
            btnSelect.Text = "✓ Select && Continue to Intake";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(890, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(90, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // AddToQueueForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1000, 640);
            Controls.Add(this.panelButtons);
            Controls.Add(this.dgvPatients);
            Controls.Add(this.lblPatientCount);
            Controls.Add(this.txtSearch);
            Controls.Add(this.lblSearch);
            Controls.Add(this.panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddToQueueForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Patient to Queue";
            Load += new System.EventHandler(this.AddToQueueForm_Load);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPatients;
        private Button btnSelect;
        private Button btnCancel;
        private Label lblTitle;
        private Label lblInstruction;
        private Label lblPatientCount;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel panelHeader;
        private Panel panelButtons;
    }
}