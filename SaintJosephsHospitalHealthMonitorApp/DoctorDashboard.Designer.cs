namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class DoctorDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblHospitalName;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAppointmentsMenu;
        private System.Windows.Forms.Button btnPatientsMenu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Panel panelAppointmentButtons;
        private System.Windows.Forms.Button btnViewPatient;
        private System.Windows.Forms.Button btnCompleteAppt;
        private System.Windows.Forms.Button btnServiceChecklist;
        private System.Windows.Forms.Button btnRefreshAppt;
        private System.Windows.Forms.Panel panelPatientButtons;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Button btnAddRecord;
        private System.Windows.Forms.Button btnRefreshPatients;
        private System.Windows.Forms.Panel panelUniversalSearch;
        private System.Windows.Forms.TextBox txtUniversalSearch;
        private System.Windows.Forms.Button btnClearUniversalSearch;
        private System.Windows.Forms.Label lblUniversalSearchIcon;

        // Universal search components
        private ListBox searchSuggestionsListBox;
        private Label lblSearchStatus;
        private Panel panelSearchCategories;
        private CheckBox chkSearchAppointments;
        private CheckBox chkSearchPatients;

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
            panelSidebar = new Panel();
            pictureBoxProfile = new PictureBox();
            lblWelcome = new Label();
            lblRole = new Label();
            btnAppointmentsMenu = new Button();
            btnPatientsMenu = new Button();
            btnLogout = new Button();
            panelMainContent = new Panel();
            tabControl = new TabControl();
            tabAppointments = new TabPage();
            dgvAppointments = new DataGridView();
            panelAppointmentButtons = new Panel();
            btnRefreshAppt = new Button();
            btnServiceChecklist = new Button();
            btnCompleteAppt = new Button();
            btnViewPatient = new Button();
            tabPatients = new TabPage();
            dgvPatients = new DataGridView();
            panelPatientButtons = new Panel();
            btnRefreshPatients = new Button();
            btnAddRecord = new Button();
            btnViewHistory = new Button();
            panelHeader = new Panel();
            panelUniversalSearch = new Panel();
            lblUniversalSearchIcon = new Label();
            btnClearUniversalSearch = new Button();
            txtUniversalSearch = new TextBox();
            lblHospitalName = new Label();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            panelMainContent.SuspendLayout();
            tabControl.SuspendLayout();
            tabAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            panelAppointmentButtons.SuspendLayout();
            tabPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            panelPatientButtons.SuspendLayout();
            panelHeader.SuspendLayout();
            panelUniversalSearch.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(26, 32, 44);
            panelSidebar.Controls.Add(pictureBoxProfile);
            panelSidebar.Controls.Add(lblWelcome);
            panelSidebar.Controls.Add(lblRole);
            panelSidebar.Controls.Add(btnAppointmentsMenu);
            panelSidebar.Controls.Add(btnPatientsMenu);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(280, 761);
            panelSidebar.TabIndex = 1;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.White;
            pictureBoxProfile.Location = new Point(90, 80);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(100, 100);
            pictureBoxProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProfile.TabIndex = 1;
            pictureBoxProfile.TabStop = false;
            // 
            // lblWelcome
            // 
            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(20, 200);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(240, 25);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome, Doctor";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRole
            // 
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.ForeColor = Color.FromArgb(160, 174, 192);
            lblRole.Location = new Point(20, 225);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(240, 20);
            lblRole.TabIndex = 3;
            lblRole.Text = "Role: Doctor";
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAppointmentsMenu
            // 
            btnAppointmentsMenu.BackColor = Color.FromArgb(26, 188, 156);
            btnAppointmentsMenu.Cursor = Cursors.Hand;
            btnAppointmentsMenu.FlatAppearance.BorderSize = 0;
            btnAppointmentsMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnAppointmentsMenu.FlatStyle = FlatStyle.Flat;
            btnAppointmentsMenu.Font = new Font("Segoe UI", 10F);
            btnAppointmentsMenu.ForeColor = Color.White;
            btnAppointmentsMenu.Location = new Point(15, 290);
            btnAppointmentsMenu.Name = "btnAppointmentsMenu";
            btnAppointmentsMenu.Padding = new Padding(20, 0, 0, 0);
            btnAppointmentsMenu.Size = new Size(250, 45);
            btnAppointmentsMenu.TabIndex = 4;
            btnAppointmentsMenu.Text = "  📅  My Appointments";
            btnAppointmentsMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnAppointmentsMenu.UseVisualStyleBackColor = false;
            btnAppointmentsMenu.Click += BtnAppointmentsMenu_Click;
            // 
            // btnPatientsMenu
            // 
            btnPatientsMenu.BackColor = Color.Transparent;
            btnPatientsMenu.Cursor = Cursors.Hand;
            btnPatientsMenu.FlatAppearance.BorderSize = 0;
            btnPatientsMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnPatientsMenu.FlatStyle = FlatStyle.Flat;
            btnPatientsMenu.Font = new Font("Segoe UI", 10F);
            btnPatientsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnPatientsMenu.Location = new Point(15, 345);
            btnPatientsMenu.Name = "btnPatientsMenu";
            btnPatientsMenu.Padding = new Padding(20, 0, 0, 0);
            btnPatientsMenu.Size = new Size(250, 45);
            btnPatientsMenu.TabIndex = 5;
            btnPatientsMenu.Text = "  👥  My Patients Records";
            btnPatientsMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnPatientsMenu.UseVisualStyleBackColor = false;
            btnPatientsMenu.Click += BtnPatientsMenu_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(15, 681);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(250, 50);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "🚪 LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(247, 250, 252);
            panelMainContent.Controls.Add(tabControl);
            panelMainContent.Controls.Add(panelHeader);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(280, 0);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1204, 761);
            panelMainContent.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabAppointments);
            tabControl.Controls.Add(tabPatients);
            tabControl.Dock = DockStyle.Fill;
            tabControl.ItemSize = new Size(120, 30);
            tabControl.Location = new Point(0, 70);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1204, 691);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabAppointments
            // 
            tabAppointments.BackColor = Color.FromArgb(247, 250, 252);
            tabAppointments.Controls.Add(dgvAppointments);
            tabAppointments.Controls.Add(panelAppointmentButtons);
            tabAppointments.Location = new Point(4, 34);
            tabAppointments.Name = "tabAppointments";
            tabAppointments.Padding = new Padding(20);
            tabAppointments.Size = new Size(1196, 653);
            tabAppointments.TabIndex = 0;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.ColumnHeadersHeight = 50;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(20, 100);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowTemplate.Height = 45;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(1156, 533);
            dgvAppointments.TabIndex = 0;
            // 
            // panelAppointmentButtons
            // 
            panelAppointmentButtons.BackColor = Color.White;
            panelAppointmentButtons.Controls.Add(btnRefreshAppt);
            panelAppointmentButtons.Controls.Add(btnServiceChecklist);
            panelAppointmentButtons.Controls.Add(btnCompleteAppt);
            panelAppointmentButtons.Controls.Add(btnViewPatient);
            panelAppointmentButtons.Dock = DockStyle.Top;
            panelAppointmentButtons.Location = new Point(20, 20);
            panelAppointmentButtons.Name = "panelAppointmentButtons";
            panelAppointmentButtons.Padding = new Padding(20, 15, 20, 15);
            panelAppointmentButtons.Size = new Size(1156, 80);
            panelAppointmentButtons.TabIndex = 1;
            // 
            // btnRefreshAppt
            // 
            btnRefreshAppt.BackColor = Color.FromArgb(113, 128, 150);
            btnRefreshAppt.Cursor = Cursors.Hand;
            btnRefreshAppt.FlatAppearance.BorderSize = 0;
            btnRefreshAppt.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 103, 122);
            btnRefreshAppt.FlatStyle = FlatStyle.Flat;
            btnRefreshAppt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefreshAppt.ForeColor = Color.White;
            btnRefreshAppt.Location = new Point(610, 15);
            btnRefreshAppt.Name = "btnRefreshAppt";
            btnRefreshAppt.Size = new Size(150, 45);
            btnRefreshAppt.TabIndex = 0;
            btnRefreshAppt.Text = "🔄 Refresh";
            btnRefreshAppt.UseVisualStyleBackColor = false;
            btnRefreshAppt.Click += BtnRefresh_Click;
            // 
            // btnServiceChecklist
            // 
            btnServiceChecklist.BackColor = Color.FromArgb(155, 89, 182);
            btnServiceChecklist.Cursor = Cursors.Hand;
            btnServiceChecklist.FlatAppearance.BorderSize = 0;
            btnServiceChecklist.FlatAppearance.MouseOverBackColor = Color.FromArgb(142, 68, 173);
            btnServiceChecklist.FlatStyle = FlatStyle.Flat;
            btnServiceChecklist.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnServiceChecklist.ForeColor = Color.White;
            btnServiceChecklist.Location = new Point(400, 15);
            btnServiceChecklist.Name = "btnServiceChecklist";
            btnServiceChecklist.Size = new Size(200, 45);
            btnServiceChecklist.TabIndex = 3;
            btnServiceChecklist.Text = "📋 Service Checklist";
            btnServiceChecklist.UseVisualStyleBackColor = false;
            btnServiceChecklist.Click += BtnServiceChecklist_Click;
            // 
            // btnCompleteAppt
            // 
            btnCompleteAppt.BackColor = Color.FromArgb(72, 187, 120);
            btnCompleteAppt.Cursor = Cursors.Hand;
            btnCompleteAppt.FlatAppearance.BorderSize = 0;
            btnCompleteAppt.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 161, 105);
            btnCompleteAppt.FlatStyle = FlatStyle.Flat;
            btnCompleteAppt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCompleteAppt.ForeColor = Color.White;
            btnCompleteAppt.Location = new Point(200, 15);
            btnCompleteAppt.Name = "btnCompleteAppt";
            btnCompleteAppt.Size = new Size(190, 45);
            btnCompleteAppt.TabIndex = 1;
            btnCompleteAppt.Text = "✅ Mark Completed";
            btnCompleteAppt.UseVisualStyleBackColor = false;
            btnCompleteAppt.Click += BtnCompleteAppointment_Click;
            // 
            // btnViewPatient
            // 
            btnViewPatient.BackColor = Color.FromArgb(66, 153, 225);
            btnViewPatient.Cursor = Cursors.Hand;
            btnViewPatient.FlatAppearance.BorderSize = 0;
            btnViewPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnViewPatient.FlatStyle = FlatStyle.Flat;
            btnViewPatient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewPatient.ForeColor = Color.White;
            btnViewPatient.Location = new Point(20, 15);
            btnViewPatient.Name = "btnViewPatient";
            btnViewPatient.Size = new Size(170, 45);
            btnViewPatient.TabIndex = 2;
            btnViewPatient.Text = "👁️ View Details";
            btnViewPatient.UseVisualStyleBackColor = false;
            btnViewPatient.Click += BtnViewPatient_Click;
            // 
            // tabPatients
            // 
            tabPatients.BackColor = Color.FromArgb(247, 250, 252);
            tabPatients.Controls.Add(dgvPatients);
            tabPatients.Controls.Add(panelPatientButtons);
            tabPatients.Location = new Point(4, 34);
            tabPatients.Name = "tabPatients";
            tabPatients.Padding = new Padding(20);
            tabPatients.Size = new Size(1196, 653);
            tabPatients.TabIndex = 1;
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.ColumnHeadersHeight = 50;
            dgvPatients.Dock = DockStyle.Fill;
            dgvPatients.Location = new Point(20, 100);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;
            dgvPatients.RowTemplate.Height = 45;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(1156, 533);
            dgvPatients.TabIndex = 0;
            // 
            // panelPatientButtons
            // 
            panelPatientButtons.BackColor = Color.White;
            panelPatientButtons.Controls.Add(btnRefreshPatients);
            panelPatientButtons.Controls.Add(btnAddRecord);
            panelPatientButtons.Controls.Add(btnViewHistory);
            panelPatientButtons.Dock = DockStyle.Top;
            panelPatientButtons.Location = new Point(20, 20);
            panelPatientButtons.Name = "panelPatientButtons";
            panelPatientButtons.Padding = new Padding(20, 15, 20, 15);
            panelPatientButtons.Size = new Size(1156, 80);
            panelPatientButtons.TabIndex = 1;
            // 
            // btnRefreshPatients
            // 
            btnRefreshPatients.BackColor = Color.FromArgb(113, 128, 150);
            btnRefreshPatients.Cursor = Cursors.Hand;
            btnRefreshPatients.FlatAppearance.BorderSize = 0;
            btnRefreshPatients.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 103, 122);
            btnRefreshPatients.FlatStyle = FlatStyle.Flat;
            btnRefreshPatients.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefreshPatients.ForeColor = Color.White;
            btnRefreshPatients.Location = new Point(420, 15);
            btnRefreshPatients.Name = "btnRefreshPatients";
            btnRefreshPatients.Size = new Size(150, 45);
            btnRefreshPatients.TabIndex = 0;
            btnRefreshPatients.Text = "🔄 Refresh";
            btnRefreshPatients.UseVisualStyleBackColor = false;
            btnRefreshPatients.Click += BtnRefresh_Click;
            // 
            // btnAddRecord
            // 
            btnAddRecord.BackColor = Color.FromArgb(72, 187, 120);
            btnAddRecord.Cursor = Cursors.Hand;
            btnAddRecord.FlatAppearance.BorderSize = 0;
            btnAddRecord.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 161, 105);
            btnAddRecord.FlatStyle = FlatStyle.Flat;
            btnAddRecord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddRecord.ForeColor = Color.White;
            btnAddRecord.Location = new Point(220, 15);
            btnAddRecord.Name = "btnAddRecord";
            btnAddRecord.Size = new Size(190, 45);
            btnAddRecord.TabIndex = 1;
            btnAddRecord.Text = "➕ Add Medical Record";
            btnAddRecord.UseVisualStyleBackColor = false;
            btnAddRecord.Click += BtnAddMedicalRecord_Click;
            // 
            // btnViewHistory
            // 
            btnViewHistory.BackColor = Color.FromArgb(66, 153, 225);
            btnViewHistory.Cursor = Cursors.Hand;
            btnViewHistory.FlatAppearance.BorderSize = 0;
            btnViewHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewHistory.ForeColor = Color.White;
            btnViewHistory.Location = new Point(20, 15);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(190, 45);
            btnViewHistory.TabIndex = 2;
            btnViewHistory.Text = "📋 View Full History";
            btnViewHistory.UseVisualStyleBackColor = false;
            btnViewHistory.Click += BtnViewHistory_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(26, 188, 156);
            panelHeader.Controls.Add(panelUniversalSearch);
            panelHeader.Controls.Add(lblHospitalName);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1204, 70);
            panelHeader.TabIndex = 1;
            // 
            // panelUniversalSearch
            // 
            panelUniversalSearch.BackColor = Color.White;
            panelUniversalSearch.BorderStyle = BorderStyle.FixedSingle;
            panelUniversalSearch.Controls.Add(lblUniversalSearchIcon);
            panelUniversalSearch.Controls.Add(btnClearUniversalSearch);
            panelUniversalSearch.Controls.Add(txtUniversalSearch);
            panelUniversalSearch.Location = new Point(296, 15);
            panelUniversalSearch.Name = "panelUniversalSearch";
            panelUniversalSearch.Size = new Size(588, 45);
            panelUniversalSearch.TabIndex = 4;
            // 
            // lblUniversalSearchIcon
            // 
            lblUniversalSearchIcon.AutoSize = true;
            lblUniversalSearchIcon.Cursor = Cursors.IBeam;
            lblUniversalSearchIcon.Font = new Font("Segoe UI", 14F);
            lblUniversalSearchIcon.ForeColor = Color.FromArgb(154, 160, 166);
            lblUniversalSearchIcon.Location = new Point(18, 10);
            lblUniversalSearchIcon.Name = "lblUniversalSearchIcon";
            lblUniversalSearchIcon.Size = new Size(33, 25);
            lblUniversalSearchIcon.TabIndex = 0;
            lblUniversalSearchIcon.Text = "🔍";
            lblUniversalSearchIcon.Click += LblUniversalSearchIcon_Click;
            // 
            // btnClearUniversalSearch
            // 
            btnClearUniversalSearch.BackColor = Color.Transparent;
            btnClearUniversalSearch.Cursor = Cursors.Hand;
            btnClearUniversalSearch.FlatAppearance.BorderSize = 0;
            btnClearUniversalSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnClearUniversalSearch.FlatStyle = FlatStyle.Flat;
            btnClearUniversalSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClearUniversalSearch.ForeColor = Color.FromArgb(128, 134, 139);
            btnClearUniversalSearch.Location = new Point(543, 5);
            btnClearUniversalSearch.Name = "btnClearUniversalSearch";
            btnClearUniversalSearch.Size = new Size(40, 32);
            btnClearUniversalSearch.TabIndex = 2;
            btnClearUniversalSearch.Text = "✕";
            btnClearUniversalSearch.UseVisualStyleBackColor = false;
            btnClearUniversalSearch.Visible = false;
            btnClearUniversalSearch.Click += BtnClearUniversalSearch_Click;
            // 
            // txtUniversalSearch
            // 
            txtUniversalSearch.BackColor = Color.White;
            txtUniversalSearch.BorderStyle = BorderStyle.None;
            txtUniversalSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUniversalSearch.Location = new Point(57, 13);
            txtUniversalSearch.Name = "txtUniversalSearch";
            txtUniversalSearch.PlaceholderText = "Search appointments, patients...";
            txtUniversalSearch.Size = new Size(478, 22);
            txtUniversalSearch.TabIndex = 1;
            txtUniversalSearch.TextChanged += TxtUniversalSearch_TextChanged;
            txtUniversalSearch.KeyDown += TxtUniversalSearch_KeyDown;
            // 
            // lblHospitalName
            // 
            lblHospitalName.AutoSize = true;
            lblHospitalName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHospitalName.ForeColor = Color.White;
            lblHospitalName.Location = new Point(28, 20);
            lblHospitalName.Name = "lblHospitalName";
            lblHospitalName.Size = new Size(247, 32);
            lblHospitalName.TabIndex = 0;
            lblHospitalName.Text = "St. Joseph's Hospital";
            // 
            // DoctorDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(1484, 761);
            Controls.Add(panelMainContent);
            Controls.Add(panelSidebar);
            MinimumSize = new Size(1200, 700);
            Name = "DoctorDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "St. Joseph's Hospital - Doctor Dashboard";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelMainContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            panelAppointmentButtons.ResumeLayout(false);
            tabPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            panelPatientButtons.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUniversalSearch.ResumeLayout(false);
            panelUniversalSearch.PerformLayout();
            ResumeLayout(false);
        }

        private void InitializeSearchComponents()
        {
            panelSearchCategories = new Panel();
            panelSearchCategories.BackColor = Color.White;
            panelSearchCategories.Height = 40;
            panelSearchCategories.Visible = false;
            panelSearchCategories.Name = "panelSearchCategories";

            chkSearchAppointments = new CheckBox();
            chkSearchAppointments.Text = "📅 Appointments";
            chkSearchAppointments.Checked = true;
            chkSearchAppointments.Font = new Font("Segoe UI", 9F);
            chkSearchAppointments.Location = new Point(15, 10);
            chkSearchAppointments.AutoSize = true;
            chkSearchAppointments.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchPatients = new CheckBox();
            chkSearchPatients.Text = "👥 Patients";
            chkSearchPatients.Checked = true;
            chkSearchPatients.Font = new Font("Segoe UI", 9F);
            chkSearchPatients.Location = new Point(160, 10);
            chkSearchPatients.AutoSize = true;
            chkSearchPatients.CheckedChanged += (s, e) => RefreshSearchResults();

            panelSearchCategories.Controls.AddRange(new Control[] {
                chkSearchAppointments, chkSearchPatients
            });

            lblSearchStatus = new Label();
            lblSearchStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblSearchStatus.ForeColor = Color.FromArgb(113, 128, 150);
            lblSearchStatus.Visible = false;
            lblSearchStatus.AutoSize = true;
            lblSearchStatus.Name = "lblSearchStatus";

            Panel suggestionsContainer = new Panel();
            suggestionsContainer.BackColor = Color.Transparent;
            suggestionsContainer.Visible = false;
            suggestionsContainer.Name = "suggestionsContainer";

            Panel suggestionsShadow = new Panel();
            suggestionsShadow.BackColor = Color.FromArgb(40, 0, 0, 0);
            suggestionsShadow.Visible = false;
            suggestionsShadow.Name = "suggestionsShadow";

            this.Controls.Add(lblSearchStatus);
            this.Controls.Add(panelSearchCategories);
            this.Controls.Add(suggestionsShadow);
            this.Controls.Add(suggestionsContainer);

            suggestionsShadow.SendToBack();
            suggestionsContainer.BringToFront();
            panelSearchCategories.BringToFront();
        }

        private void SetupSearchSuggestionsList()
        {
            searchSuggestionsListBox = new ListBox();
            searchSuggestionsListBox.Font = new Font("Segoe UI", 10F);
            searchSuggestionsListBox.BorderStyle = BorderStyle.None;
            searchSuggestionsListBox.BackColor = Color.White;
            searchSuggestionsListBox.ForeColor = Color.FromArgb(26, 32, 44);
            searchSuggestionsListBox.IntegralHeight = false;
            searchSuggestionsListBox.DrawMode = DrawMode.OwnerDrawFixed;
            searchSuggestionsListBox.ItemHeight = 50;
            searchSuggestionsListBox.Click += SearchSuggestionsListBox_Click;
            searchSuggestionsListBox.KeyDown += SearchSuggestionsListBox_KeyDown;
            searchSuggestionsListBox.MouseMove += SearchSuggestionsListBox_MouseMove;

            searchSuggestionsListBox.DrawItem += SearchSuggestionsListBox_DrawItem;

            // Find the container and shadow from the Controls
            Panel suggestionsContainer = this.Controls.Find("suggestionsContainer", true).FirstOrDefault() as Panel;
            Panel suggestionsShadow = this.Controls.Find("suggestionsShadow", true).FirstOrDefault() as Panel;

            if (suggestionsContainer != null)
            {
                suggestionsContainer.Controls.Add(searchSuggestionsListBox);
            }

            searchSuggestionsListBox.Tag = new
            {
                Container = suggestionsContainer,
                Shadow = suggestionsShadow
            };
        }

        private void SearchSuggestionsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.DrawBackground();

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            if (isSelected)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(237, 242, 247)))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }

            if (searchSuggestionsListBox.Items[e.Index] is UniversalSearchItem item)
            {
                int photoSize = 36;
                int photoX = e.Bounds.X + 8;
                int photoY = e.Bounds.Y + (e.Bounds.Height - photoSize) / 2;

                using (SolidBrush iconBg = new SolidBrush(GetCategoryColor(item.Source)))
                {
                    e.Graphics.FillEllipse(iconBg, photoX, photoY, photoSize, photoSize);
                }

                string icon = GetCategoryIcon(item.Source);
                using (Font iconFont = new Font("Segoe UI Emoji", 16F))
                using (SolidBrush iconBrush = new SolidBrush(Color.White))
                {
                    SizeF iconSize = e.Graphics.MeasureString(icon, iconFont);
                    e.Graphics.DrawString(icon, iconFont, iconBrush,
                        photoX + (photoSize - iconSize.Width) / 2,
                        photoY + (photoSize - iconSize.Height) / 2);
                }

                string searchTerm = txtUniversalSearch.Text.Trim();
                string displayText = item.DisplayText;

                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(26, 32, 44)))
                using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(26, 188, 156)))
                using (Font boldFont = new Font(e.Font, FontStyle.Bold))
                {
                    float x = photoX + photoSize + 12;
                    float y = e.Bounds.Y + (e.Bounds.Height - e.Font.GetHeight(e.Graphics)) / 2;

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        int index = displayText.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase);
                        if (index >= 0)
                        {
                            string before = displayText.Substring(0, index);
                            string match = displayText.Substring(index, Math.Min(searchTerm.Length, displayText.Length - index));
                            string after = displayText.Substring(index + match.Length);

                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            using (StringFormat format = new StringFormat(StringFormat.GenericTypographic))
                            {
                                float currentX = x;

                                if (!string.IsNullOrEmpty(before))
                                {
                                    e.Graphics.DrawString(before, e.Font, textBrush, currentX, y, format);
                                    SizeF beforeSize = e.Graphics.MeasureString(before, e.Font, new PointF(currentX, y), format);
                                    currentX += beforeSize.Width;
                                }

                                if (!string.IsNullOrEmpty(match))
                                {
                                    e.Graphics.DrawString(match, boldFont, highlightBrush, currentX, y, format);
                                    SizeF matchSize = e.Graphics.MeasureString(match, boldFont, new PointF(currentX, y), format);
                                    currentX += matchSize.Width;
                                }

                                if (!string.IsNullOrEmpty(after))
                                {
                                    e.Graphics.DrawString(after, e.Font, textBrush, currentX, y, format);
                                }
                            }
                        }
                        else
                        {
                            e.Graphics.DrawString(displayText, e.Font, textBrush, x, y);
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(displayText, e.Font, textBrush, x, y);
                    }
                }
            }

            if (e.Index < searchSuggestionsListBox.Items.Count - 1)
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240)))
                {
                    e.Graphics.DrawLine(pen,
                        e.Bounds.Left + 15,
                        e.Bounds.Bottom - 1,
                        e.Bounds.Right - 15,
                        e.Bounds.Bottom - 1);
                }
            }

            e.DrawFocusRectangle();
        }

        private void PositionSearchSuggestions()
        {
            dynamic refs = searchSuggestionsListBox.Tag;
            Panel container = refs.Container;
            Panel shadow = refs.Shadow;

            Point searchPanelLocation = this.PointToClient(panelUniversalSearch.Parent.PointToScreen(panelUniversalSearch.Location));
            int searchPanelBottom = searchPanelLocation.Y + panelUniversalSearch.Height;

            int width = panelUniversalSearch.Width;
            int itemCount = searchSuggestionsListBox.Items.Count;
            int maxVisibleItems = 6;

            int statusHeight = 35;
            int filterHeight = 40;
            int listHeight = Math.Min(itemCount, maxVisibleItems) * searchSuggestionsListBox.ItemHeight;
            int totalHeight = statusHeight + filterHeight + listHeight + 2;

            container.Location = new Point(searchPanelLocation.X, searchPanelBottom);
            container.Size = new Size(width, totalHeight);
            container.BackColor = Color.White;
            container.Padding = new Padding(0);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 12;

            path.AddLine(0, 0, width, 0);
            path.AddLine(width, 0, width, totalHeight - radius);
            path.AddArc(width - radius, totalHeight - radius, radius, radius, 0, 90);
            path.AddLine(width - radius, totalHeight, radius, totalHeight);
            path.AddArc(0, totalHeight - radius, radius, radius, 90, 90);
            path.AddLine(0, totalHeight - radius, 0, 0);
            path.CloseFigure();

            container.Region = new Region(path);

            lblSearchStatus.Parent = container;
            lblSearchStatus.Location = new Point(20, 8);
            lblSearchStatus.AutoSize = true;
            lblSearchStatus.BringToFront();

            panelSearchCategories.Parent = container;
            panelSearchCategories.Location = new Point(0, statusHeight);
            panelSearchCategories.Size = new Size(width, filterHeight);
            panelSearchCategories.BackColor = Color.FromArgb(249, 250, 251);
            panelSearchCategories.Visible = true;
            panelSearchCategories.BorderStyle = BorderStyle.None;

            Panel filterTopBorder = panelSearchCategories.Controls.Find("filterTopBorder", false).FirstOrDefault() as Panel;
            if (filterTopBorder == null)
            {
                filterTopBorder = new Panel();
                filterTopBorder.Name = "filterTopBorder";
                filterTopBorder.Dock = DockStyle.Top;
                filterTopBorder.Height = 1;
                filterTopBorder.BackColor = Color.FromArgb(226, 232, 240);
                panelSearchCategories.Controls.Add(filterTopBorder);
                filterTopBorder.BringToFront();
            }

            searchSuggestionsListBox.Parent = container;
            searchSuggestionsListBox.Location = new Point(1, statusHeight + filterHeight);
            searchSuggestionsListBox.Size = new Size(width - 2, listHeight);
            searchSuggestionsListBox.BorderStyle = BorderStyle.FixedSingle;
            searchSuggestionsListBox.Region = null;

            shadow.Location = new Point(searchPanelLocation.X + 2, searchPanelBottom + 2);
            shadow.Size = new Size(width, totalHeight);
            shadow.Region = new Region(path.Clone() as System.Drawing.Drawing2D.GraphicsPath);

            shadow.Visible = true;
            container.Visible = true;
            lblSearchStatus.Visible = true;

            container.BringToFront();
            shadow.SendToBack();
        }
    }
}