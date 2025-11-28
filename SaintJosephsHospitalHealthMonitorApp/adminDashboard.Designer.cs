namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class AdminDashboard
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
            panelSidebar = new Panel();
            pictureBoxProfile = new PictureBox();
            lblWelcome = new Label();
            lblRole = new Label();
            btnUsersMenu = new Button();
            btnMedicalRecordsMenu = new Button();
            btnBillingMenu = new Button();
            btnLogout = new Button();
            panelMainContent = new Panel();
            tabControl = new TabControl();
            tabUsersMain = new TabPage();
            tabUsers = new TabControl();
            tabAllUsers = new TabPage();
            dgvUsers = new DataGridView();
            tabAdmins = new TabPage();
            dgvAdmins = new DataGridView();
            tabDoctors = new TabPage();
            dgvDoctors = new DataGridView();
            tabStaff = new TabPage();
            dgvStaff = new DataGridView();
            panelUserButtons = new Panel();
            btnToggleAccountStatus = new Button();
            btnViewUserProfile = new Button();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            btnAddUser = new Button();
            buttonShadow = new Panel();
            tabMedicalRecords = new TabPage();
            dgvPatients = new DataGridView();
            panelMedicalButtons = new Panel();
            btnDeletePatient = new Button();
            BtnViewPatientProfile = new Button();
            btnEditPatient = new Button();
            btnAddPatient = new Button();
            btnViewPatientRecord = new Button();
            medicalBtnShadow = new Panel();
            tabBilling = new TabPage();
            tabBillingControl = new TabControl();
            tabActiveBills = new TabPage();
            dgvBilling = new DataGridView();
            tabDischargedBills = new TabPage();
            dgvDischargedBills = new DataGridView();
            panelBillingStats = new Panel();
            panelBillingButtons = new Panel();
            btnGenerateIncomeReport = new Button();
            btnViewBillDetails = new Button();
            billBtnShadow = new Panel();
            panelHeader = new Panel();
            panelUniversalSearch = new Panel();
            lblUniversalSearchIcon = new Label();
            btnClearUniversalSearch = new Button();
            txtUniversalSearch = new TextBox();
            label1 = new Label();
            lblHospitalName = new Label();
            panelHeaderRight = new Panel();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            panelMainContent.SuspendLayout();
            tabControl.SuspendLayout();
            tabUsersMain.SuspendLayout();
            tabUsers.SuspendLayout();
            tabAllUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            tabAdmins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).BeginInit();
            tabDoctors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).BeginInit();
            tabStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaff).BeginInit();
            panelUserButtons.SuspendLayout();
            tabMedicalRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            panelMedicalButtons.SuspendLayout();
            tabBilling.SuspendLayout();
            tabBillingControl.SuspendLayout();
            tabActiveBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).BeginInit();
            tabDischargedBills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDischargedBills).BeginInit();
            panelBillingButtons.SuspendLayout();
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
            panelSidebar.Controls.Add(btnUsersMenu);
            panelSidebar.Controls.Add(btnMedicalRecordsMenu);
            panelSidebar.Controls.Add(btnBillingMenu);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(280, 854);
            panelSidebar.TabIndex = 1;
            // 
            // pictureBoxProfile
            // 
            pictureBoxProfile.BackColor = Color.White;
            pictureBoxProfile.Location = new Point(66, 44);
            pictureBoxProfile.Name = "pictureBoxProfile";
            pictureBoxProfile.Size = new Size(150, 150);
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
            lblWelcome.Text = "Welcome, Admin";
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
            lblRole.Text = "Role: Admin";
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUsersMenu
            // 
            btnUsersMenu.BackColor = Color.FromArgb(66, 153, 225);
            btnUsersMenu.Cursor = Cursors.Hand;
            btnUsersMenu.FlatAppearance.BorderSize = 0;
            btnUsersMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnUsersMenu.FlatStyle = FlatStyle.Flat;
            btnUsersMenu.Font = new Font("Segoe UI", 10F);
            btnUsersMenu.ForeColor = Color.White;
            btnUsersMenu.Location = new Point(15, 290);
            btnUsersMenu.Name = "btnUsersMenu";
            btnUsersMenu.Padding = new Padding(20, 0, 0, 0);
            btnUsersMenu.Size = new Size(250, 45);
            btnUsersMenu.TabIndex = 4;
            btnUsersMenu.Text = "  👥  User Management";
            btnUsersMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnUsersMenu.UseVisualStyleBackColor = false;
            btnUsersMenu.Click += BtnUsersMenu_Click;
            // 
            // btnMedicalRecordsMenu
            // 
            btnMedicalRecordsMenu.BackColor = Color.Transparent;
            btnMedicalRecordsMenu.Cursor = Cursors.Hand;
            btnMedicalRecordsMenu.FlatAppearance.BorderSize = 0;
            btnMedicalRecordsMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnMedicalRecordsMenu.FlatStyle = FlatStyle.Flat;
            btnMedicalRecordsMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMedicalRecordsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnMedicalRecordsMenu.Location = new Point(15, 345);
            btnMedicalRecordsMenu.Name = "btnMedicalRecordsMenu";
            btnMedicalRecordsMenu.Padding = new Padding(20, 0, 0, 0);
            btnMedicalRecordsMenu.Size = new Size(250, 45);
            btnMedicalRecordsMenu.TabIndex = 5;
            btnMedicalRecordsMenu.Text = "  📋  Medical Records";
            btnMedicalRecordsMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnMedicalRecordsMenu.UseVisualStyleBackColor = false;
            btnMedicalRecordsMenu.Click += BtnMedicalRecordsMenu_Click;
            // 
            // btnBillingMenu
            // 
            btnBillingMenu.BackColor = Color.Transparent;
            btnBillingMenu.Cursor = Cursors.Hand;
            btnBillingMenu.FlatAppearance.BorderSize = 0;
            btnBillingMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnBillingMenu.FlatStyle = FlatStyle.Flat;
            btnBillingMenu.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBillingMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnBillingMenu.Location = new Point(15, 400);
            btnBillingMenu.Name = "btnBillingMenu";
            btnBillingMenu.Padding = new Padding(20, 0, 0, 0);
            btnBillingMenu.Size = new Size(250, 45);
            btnBillingMenu.TabIndex = 6;
            btnBillingMenu.Text = "  💰  Billing And Payments";
            btnBillingMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnBillingMenu.UseVisualStyleBackColor = false;
            btnBillingMenu.Click += BtnBillingMenu_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(74, 85, 104);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 804);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(280, 50);
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
            panelMainContent.Size = new Size(1213, 854);
            panelMainContent.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabUsersMain);
            tabControl.Controls.Add(tabMedicalRecords);
            tabControl.Controls.Add(tabBilling);
            tabControl.Dock = DockStyle.Fill;
            tabControl.ItemSize = new Size(120, 30);
            tabControl.Location = new Point(0, 70);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1213, 784);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabUsersMain
            // 
            tabUsersMain.BackColor = Color.FromArgb(247, 250, 252);
            tabUsersMain.Controls.Add(tabUsers);
            tabUsersMain.Controls.Add(panelUserButtons);
            tabUsersMain.Location = new Point(4, 34);
            tabUsersMain.Name = "tabUsersMain";
            tabUsersMain.Padding = new Padding(20);
            tabUsersMain.Size = new Size(1205, 746);
            tabUsersMain.TabIndex = 0;
            // 
            // tabUsers
            // 
            tabUsers.Controls.Add(tabAllUsers);
            tabUsers.Controls.Add(tabAdmins);
            tabUsers.Controls.Add(tabDoctors);
            tabUsers.Controls.Add(tabStaff);
            tabUsers.Dock = DockStyle.Fill;
            tabUsers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabUsers.Location = new Point(20, 100);
            tabUsers.Name = "tabUsers";
            tabUsers.SelectedIndex = 0;
            tabUsers.Size = new Size(1165, 626);
            tabUsers.TabIndex = 0;
            // 
            // tabAllUsers
            // 
            tabAllUsers.BackColor = Color.White;
            tabAllUsers.Controls.Add(dgvUsers);
            tabAllUsers.Location = new Point(4, 26);
            tabAllUsers.Name = "tabAllUsers";
            tabAllUsers.Padding = new Padding(15);
            tabAllUsers.Size = new Size(1157, 596);
            tabAllUsers.TabIndex = 0;
            tabAllUsers.Text = "📋 All Users";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 50;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(15, 15);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 45;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1127, 566);
            dgvUsers.TabIndex = 0;
            // 
            // tabAdmins
            // 
            tabAdmins.BackColor = Color.White;
            tabAdmins.Controls.Add(dgvAdmins);
            tabAdmins.Location = new Point(4, 26);
            tabAdmins.Name = "tabAdmins";
            tabAdmins.Padding = new Padding(15);
            tabAdmins.Size = new Size(1157, 596);
            tabAdmins.TabIndex = 1;
            tabAdmins.Text = "👔 Admins";
            // 
            // dgvAdmins
            // 
            dgvAdmins.AllowUserToAddRows = false;
            dgvAdmins.AllowUserToDeleteRows = false;
            dgvAdmins.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmins.BackgroundColor = Color.White;
            dgvAdmins.BorderStyle = BorderStyle.None;
            dgvAdmins.ColumnHeadersHeight = 50;
            dgvAdmins.Dock = DockStyle.Fill;
            dgvAdmins.Location = new Point(15, 15);
            dgvAdmins.Name = "dgvAdmins";
            dgvAdmins.ReadOnly = true;
            dgvAdmins.RowHeadersVisible = false;
            dgvAdmins.RowTemplate.Height = 45;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.Size = new Size(1127, 566);
            dgvAdmins.TabIndex = 0;
            // 
            // tabDoctors
            // 
            tabDoctors.BackColor = Color.White;
            tabDoctors.Controls.Add(dgvDoctors);
            tabDoctors.Location = new Point(4, 26);
            tabDoctors.Name = "tabDoctors";
            tabDoctors.Padding = new Padding(15);
            tabDoctors.Size = new Size(1157, 596);
            tabDoctors.TabIndex = 2;
            tabDoctors.Text = "\U0001fa7a Doctors";
            // 
            // dgvDoctors
            // 
            dgvDoctors.AllowUserToAddRows = false;
            dgvDoctors.AllowUserToDeleteRows = false;
            dgvDoctors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoctors.BackgroundColor = Color.White;
            dgvDoctors.BorderStyle = BorderStyle.None;
            dgvDoctors.ColumnHeadersHeight = 50;
            dgvDoctors.Dock = DockStyle.Fill;
            dgvDoctors.Location = new Point(15, 15);
            dgvDoctors.Name = "dgvDoctors";
            dgvDoctors.ReadOnly = true;
            dgvDoctors.RowHeadersVisible = false;
            dgvDoctors.RowTemplate.Height = 45;
            dgvDoctors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoctors.Size = new Size(1127, 566);
            dgvDoctors.TabIndex = 0;
            // 
            // tabStaff
            // 
            tabStaff.BackColor = Color.White;
            tabStaff.Controls.Add(dgvStaff);
            tabStaff.Location = new Point(4, 26);
            tabStaff.Name = "tabStaff";
            tabStaff.Padding = new Padding(15);
            tabStaff.Size = new Size(1157, 596);
            tabStaff.TabIndex = 4;
            tabStaff.Text = "👨‍💼 Staff";
            // 
            // dgvStaff
            // 
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.BackgroundColor = Color.White;
            dgvStaff.BorderStyle = BorderStyle.None;
            dgvStaff.ColumnHeadersHeight = 50;
            dgvStaff.Dock = DockStyle.Fill;
            dgvStaff.Location = new Point(15, 15);
            dgvStaff.Name = "dgvStaff";
            dgvStaff.ReadOnly = true;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.RowTemplate.Height = 45;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.Size = new Size(1127, 566);
            dgvStaff.TabIndex = 0;
            // 
            // panelUserButtons
            // 
            panelUserButtons.BackColor = Color.White;
            panelUserButtons.Controls.Add(btnToggleAccountStatus);
            panelUserButtons.Controls.Add(btnViewUserProfile);
            panelUserButtons.Controls.Add(btnDeleteUser);
            panelUserButtons.Controls.Add(btnEditUser);
            panelUserButtons.Controls.Add(btnAddUser);
            panelUserButtons.Controls.Add(buttonShadow);
            panelUserButtons.Dock = DockStyle.Top;
            panelUserButtons.Location = new Point(20, 20);
            panelUserButtons.Name = "panelUserButtons";
            panelUserButtons.Padding = new Padding(20, 15, 20, 15);
            panelUserButtons.Size = new Size(1165, 80);
            panelUserButtons.TabIndex = 2;
            // 
            // btnToggleAccountStatus
            // 
            btnToggleAccountStatus.BackColor = Color.FromArgb(52, 152, 219);
            btnToggleAccountStatus.Cursor = Cursors.Hand;
            btnToggleAccountStatus.FlatAppearance.BorderSize = 0;
            btnToggleAccountStatus.FlatStyle = FlatStyle.Flat;
            btnToggleAccountStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnToggleAccountStatus.ForeColor = Color.White;
            btnToggleAccountStatus.Location = new Point(723, 13);
            btnToggleAccountStatus.Name = "btnToggleAccountStatus";
            btnToggleAccountStatus.Size = new Size(180, 45);
            btnToggleAccountStatus.TabIndex = 0;
            btnToggleAccountStatus.Text = "🔓 Activate Account";
            btnToggleAccountStatus.UseVisualStyleBackColor = false;
            btnToggleAccountStatus.Visible = false;
            btnToggleAccountStatus.Click += btnToggleAccountStatus_Click;
            // 
            // btnViewUserProfile
            // 
            btnViewUserProfile.BackColor = Color.FromArgb(52, 152, 219);
            btnViewUserProfile.Cursor = Cursors.Hand;
            btnViewUserProfile.FlatAppearance.BorderSize = 0;
            btnViewUserProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnViewUserProfile.FlatStyle = FlatStyle.Flat;
            btnViewUserProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewUserProfile.ForeColor = Color.White;
            btnViewUserProfile.Location = new Point(19, 13);
            btnViewUserProfile.Name = "btnViewUserProfile";
            btnViewUserProfile.Size = new Size(170, 45);
            btnViewUserProfile.TabIndex = 6;
            btnViewUserProfile.Text = "👁 View Profile";
            btnViewUserProfile.UseVisualStyleBackColor = false;
            btnViewUserProfile.Click += btnViewUserProfile_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.FromArgb(229, 62, 62);
            btnDeleteUser.Cursor = Cursors.Hand;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 48, 48);
            btnDeleteUser.FlatStyle = FlatStyle.Flat;
            btnDeleteUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(547, 13);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(170, 45);
            btnDeleteUser.TabIndex = 1;
            btnDeleteUser.Text = "🗑️ Delete User";
            btnDeleteUser.UseVisualStyleBackColor = false;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.FromArgb(66, 153, 225);
            btnEditUser.Cursor = Cursors.Hand;
            btnEditUser.FlatAppearance.BorderSize = 0;
            btnEditUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(371, 13);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(170, 45);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "✏️ Edit User";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += BtnEditUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.FromArgb(72, 187, 120);
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 161, 105);
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(195, 13);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(170, 45);
            btnAddUser.TabIndex = 3;
            btnAddUser.Text = "➕ Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += BtnAddUser_Click;
            // 
            // buttonShadow
            // 
            buttonShadow.BackColor = Color.FromArgb(226, 232, 240);
            buttonShadow.Dock = DockStyle.Bottom;
            buttonShadow.Location = new Point(20, 64);
            buttonShadow.Name = "buttonShadow";
            buttonShadow.Size = new Size(1125, 1);
            buttonShadow.TabIndex = 4;
            // 
            // tabMedicalRecords
            // 
            tabMedicalRecords.BackColor = Color.FromArgb(247, 250, 252);
            tabMedicalRecords.Controls.Add(dgvPatients);
            tabMedicalRecords.Controls.Add(panelMedicalButtons);
            tabMedicalRecords.Location = new Point(4, 34);
            tabMedicalRecords.Name = "tabMedicalRecords";
            tabMedicalRecords.Padding = new Padding(20);
            tabMedicalRecords.Size = new Size(1205, 746);
            tabMedicalRecords.TabIndex = 1;
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AllowUserToDeleteRows = false;
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
            dgvPatients.Size = new Size(1165, 626);
            dgvPatients.TabIndex = 1;
            // 
            // panelMedicalButtons
            // 
            panelMedicalButtons.BackColor = Color.White;
            panelMedicalButtons.Controls.Add(btnDeletePatient);
            panelMedicalButtons.Controls.Add(BtnViewPatientProfile);
            panelMedicalButtons.Controls.Add(btnEditPatient);
            panelMedicalButtons.Controls.Add(btnAddPatient);
            panelMedicalButtons.Controls.Add(btnViewPatientRecord);
            panelMedicalButtons.Controls.Add(medicalBtnShadow);
            panelMedicalButtons.Dock = DockStyle.Top;
            panelMedicalButtons.Location = new Point(20, 20);
            panelMedicalButtons.Name = "panelMedicalButtons";
            panelMedicalButtons.Padding = new Padding(20, 15, 20, 15);
            panelMedicalButtons.Size = new Size(1165, 80);
            panelMedicalButtons.TabIndex = 2;
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.BackColor = Color.FromArgb(229, 62, 62);
            btnDeletePatient.Cursor = Cursors.Hand;
            btnDeletePatient.FlatAppearance.BorderSize = 0;
            btnDeletePatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 48, 48);
            btnDeletePatient.FlatStyle = FlatStyle.Flat;
            btnDeletePatient.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeletePatient.ForeColor = Color.White;
            btnDeletePatient.Location = new Point(743, 12);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(170, 45);
            btnDeletePatient.TabIndex = 5;
            btnDeletePatient.Text = "🗑️ Delete User";
            btnDeletePatient.UseVisualStyleBackColor = false;
            btnDeletePatient.Click += btnDeletePatient_Click;
            // 
            // BtnViewPatientProfile
            // 
            BtnViewPatientProfile.BackColor = Color.FromArgb(52, 152, 219);
            BtnViewPatientProfile.Cursor = Cursors.Hand;
            BtnViewPatientProfile.FlatAppearance.BorderSize = 0;
            BtnViewPatientProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            BtnViewPatientProfile.FlatStyle = FlatStyle.Flat;
            BtnViewPatientProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnViewPatientProfile.ForeColor = Color.White;
            BtnViewPatientProfile.Location = new Point(215, 13);
            BtnViewPatientProfile.Name = "BtnViewPatientProfile";
            BtnViewPatientProfile.Size = new Size(170, 45);
            BtnViewPatientProfile.TabIndex = 5;
            BtnViewPatientProfile.Text = "👁 View Profile";
            BtnViewPatientProfile.UseVisualStyleBackColor = false;
            BtnViewPatientProfile.Click += BtnViewPatientProfile_Click;
            // 
            // btnEditPatient
            // 
            btnEditPatient.BackColor = Color.FromArgb(66, 153, 225);
            btnEditPatient.Cursor = Cursors.Hand;
            btnEditPatient.FlatAppearance.BorderSize = 0;
            btnEditPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnEditPatient.FlatStyle = FlatStyle.Flat;
            btnEditPatient.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditPatient.ForeColor = Color.White;
            btnEditPatient.Location = new Point(567, 12);
            btnEditPatient.Name = "btnEditPatient";
            btnEditPatient.Size = new Size(170, 45);
            btnEditPatient.TabIndex = 6;
            btnEditPatient.Text = "✏️ Edit Patient";
            btnEditPatient.UseVisualStyleBackColor = false;
            btnEditPatient.Click += btnEditPatient_Click;
            // 
            // btnAddPatient
            // 
            btnAddPatient.BackColor = Color.FromArgb(72, 187, 120);
            btnAddPatient.Cursor = Cursors.Hand;
            btnAddPatient.FlatAppearance.BorderSize = 0;
            btnAddPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 161, 105);
            btnAddPatient.FlatStyle = FlatStyle.Flat;
            btnAddPatient.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddPatient.ForeColor = Color.White;
            btnAddPatient.Location = new Point(391, 13);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(170, 45);
            btnAddPatient.TabIndex = 7;
            btnAddPatient.Text = "➕ Add Patient";
            btnAddPatient.UseVisualStyleBackColor = false;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // btnViewPatientRecord
            // 
            btnViewPatientRecord.BackColor = Color.FromArgb(66, 153, 225);
            btnViewPatientRecord.Cursor = Cursors.Hand;
            btnViewPatientRecord.FlatAppearance.BorderSize = 0;
            btnViewPatientRecord.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnViewPatientRecord.FlatStyle = FlatStyle.Flat;
            btnViewPatientRecord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewPatientRecord.ForeColor = Color.White;
            btnViewPatientRecord.Location = new Point(19, 13);
            btnViewPatientRecord.Name = "btnViewPatientRecord";
            btnViewPatientRecord.Size = new Size(190, 45);
            btnViewPatientRecord.TabIndex = 1;
            btnViewPatientRecord.Text = "📋 View Records";
            btnViewPatientRecord.UseVisualStyleBackColor = false;
            btnViewPatientRecord.Click += BtnViewPatientRecord_Click;
            // 
            // medicalBtnShadow
            // 
            medicalBtnShadow.BackColor = Color.FromArgb(226, 232, 240);
            medicalBtnShadow.Dock = DockStyle.Bottom;
            medicalBtnShadow.Location = new Point(20, 64);
            medicalBtnShadow.Name = "medicalBtnShadow";
            medicalBtnShadow.Size = new Size(1125, 1);
            medicalBtnShadow.TabIndex = 4;
            // 
            // tabBilling
            // 
            tabBilling.BackColor = Color.FromArgb(247, 250, 252);
            tabBilling.Controls.Add(tabBillingControl);
            tabBilling.Controls.Add(panelBillingStats);
            tabBilling.Controls.Add(panelBillingButtons);
            tabBilling.Location = new Point(4, 34);
            tabBilling.Name = "tabBilling";
            tabBilling.Padding = new Padding(20);
            tabBilling.Size = new Size(1205, 746);
            tabBilling.TabIndex = 2;
            // 
            // tabBillingControl
            // 
            tabBillingControl.Controls.Add(tabActiveBills);
            tabBillingControl.Controls.Add(tabDischargedBills);
            tabBillingControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabBillingControl.Location = new Point(20, 200);
            tabBillingControl.Name = "tabBillingControl";
            tabBillingControl.SelectedIndex = 0;
            tabBillingControl.Size = new Size(1165, 526);
            tabBillingControl.TabIndex = 2;
            // 
            // tabActiveBills
            // 
            tabActiveBills.BackColor = Color.White;
            tabActiveBills.Controls.Add(dgvBilling);
            tabActiveBills.Location = new Point(4, 26);
            tabActiveBills.Name = "tabActiveBills";
            tabActiveBills.Padding = new Padding(15);
            tabActiveBills.Size = new Size(1157, 496);
            tabActiveBills.TabIndex = 0;
            tabActiveBills.Text = "📋 Active Bills";
            // 
            // dgvBilling
            // 
            dgvBilling.AllowUserToAddRows = false;
            dgvBilling.AllowUserToDeleteRows = false;
            dgvBilling.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilling.BackgroundColor = Color.White;
            dgvBilling.BorderStyle = BorderStyle.None;
            dgvBilling.ColumnHeadersHeight = 50;
            dgvBilling.Location = new Point(20, 215);
            dgvBilling.Name = "dgvBilling";
            dgvBilling.ReadOnly = true;
            dgvBilling.RowHeadersVisible = false;
            dgvBilling.RowTemplate.Height = 45;
            dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilling.Size = new Size(1165, 200);
            dgvBilling.TabIndex = 1;
            // 
            // tabDischargedBills
            // 
            tabDischargedBills.BackColor = Color.White;
            tabDischargedBills.Controls.Add(dgvDischargedBills);
            tabDischargedBills.Location = new Point(4, 26);
            tabDischargedBills.Name = "tabDischargedBills";
            tabDischargedBills.Padding = new Padding(15);
            tabDischargedBills.Size = new Size(1157, 496);
            tabDischargedBills.TabIndex = 1;
            tabDischargedBills.Text = "✅ Discharged Bills";
            // 
            // dgvDischargedBills
            // 
            dgvDischargedBills.AllowUserToAddRows = false;
            dgvDischargedBills.AllowUserToDeleteRows = false;
            dgvDischargedBills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDischargedBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDischargedBills.BackgroundColor = Color.White;
            dgvDischargedBills.BorderStyle = BorderStyle.None;
            dgvDischargedBills.ColumnHeadersHeight = 50;
            dgvDischargedBills.Location = new Point(20, 455);
            dgvDischargedBills.Name = "dgvDischargedBills";
            dgvDischargedBills.ReadOnly = true;
            dgvDischargedBills.RowHeadersVisible = false;
            dgvDischargedBills.RowTemplate.Height = 45;
            dgvDischargedBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDischargedBills.Size = new Size(1165, 271);
            dgvDischargedBills.TabIndex = 6;
            // 
            // panelBillingStats
            // 
            panelBillingStats.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBillingStats.BackColor = Color.White;
            panelBillingStats.BorderStyle = BorderStyle.FixedSingle;
            panelBillingStats.Location = new Point(20, 100);
            panelBillingStats.Name = "panelBillingStats";
            panelBillingStats.Size = new Size(1165, 80);
            panelBillingStats.TabIndex = 3;
            // 
            // panelBillingButtons
            // 
            panelBillingButtons.BackColor = Color.White;
            panelBillingButtons.Controls.Add(btnGenerateIncomeReport);
            panelBillingButtons.Controls.Add(btnViewBillDetails);
            panelBillingButtons.Controls.Add(billBtnShadow);
            panelBillingButtons.Location = new Point(20, 20);
            panelBillingButtons.Name = "panelBillingButtons";
            panelBillingButtons.Padding = new Padding(20, 15, 20, 15);
            panelBillingButtons.Size = new Size(1165, 80);
            panelBillingButtons.TabIndex = 0;
            // 
            // btnGenerateIncomeReport
            // 
            btnGenerateIncomeReport.BackColor = Color.FromArgb(66, 153, 225);
            btnGenerateIncomeReport.Cursor = Cursors.Hand;
            btnGenerateIncomeReport.FlatAppearance.BorderSize = 0;
            btnGenerateIncomeReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnGenerateIncomeReport.FlatStyle = FlatStyle.Flat;
            btnGenerateIncomeReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGenerateIncomeReport.ForeColor = Color.White;
            btnGenerateIncomeReport.Location = new Point(225, 13);
            btnGenerateIncomeReport.Name = "btnGenerateIncomeReport";
            btnGenerateIncomeReport.Size = new Size(190, 45);
            btnGenerateIncomeReport.TabIndex = 4;
            btnGenerateIncomeReport.Text = "📄 Print Income";
            btnGenerateIncomeReport.UseVisualStyleBackColor = false;
            btnGenerateIncomeReport.Click += btnGenerateIncomeReport_Click;
            // 
            // btnViewBillDetails
            // 
            btnViewBillDetails.BackColor = Color.FromArgb(66, 153, 225);
            btnViewBillDetails.Cursor = Cursors.Hand;
            btnViewBillDetails.FlatAppearance.BorderSize = 0;
            btnViewBillDetails.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnViewBillDetails.FlatStyle = FlatStyle.Flat;
            btnViewBillDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewBillDetails.ForeColor = Color.White;
            btnViewBillDetails.Location = new Point(29, 13);
            btnViewBillDetails.Name = "btnViewBillDetails";
            btnViewBillDetails.Size = new Size(190, 45);
            btnViewBillDetails.TabIndex = 1;
            btnViewBillDetails.Text = "📄 View Bill Details";
            btnViewBillDetails.UseVisualStyleBackColor = false;
            btnViewBillDetails.Click += BtnViewBillDetails_Click;
            // 
            // billBtnShadow
            // 
            billBtnShadow.BackColor = Color.FromArgb(226, 232, 240);
            billBtnShadow.Dock = DockStyle.Bottom;
            billBtnShadow.Location = new Point(20, 64);
            billBtnShadow.Name = "billBtnShadow";
            billBtnShadow.Size = new Size(1125, 1);
            billBtnShadow.TabIndex = 3;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.HotTrack;
            panelHeader.Controls.Add(panelUniversalSearch);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(lblHospitalName);
            panelHeader.Controls.Add(panelHeaderRight);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1213, 70);
            panelHeader.TabIndex = 1;
            // 
            // panelUniversalSearch
            // 
            panelUniversalSearch.Anchor = AnchorStyles.None;
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
            txtUniversalSearch.Size = new Size(478, 22);
            txtUniversalSearch.TabIndex = 1;
            txtUniversalSearch.TextChanged += TxtUniversalSearch_TextChanged;
            txtUniversalSearch.KeyDown += TxtUniversalSearch_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.FromArgb(224, 224, 224);
            label1.Location = new Point(28, 42);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 3;
            label1.Text = "Management Portal";
            // 
            // lblHospitalName
            // 
            lblHospitalName.AutoSize = true;
            lblHospitalName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHospitalName.ForeColor = Color.FromArgb(224, 224, 224);
            lblHospitalName.Location = new Point(28, 8);
            lblHospitalName.Name = "lblHospitalName";
            lblHospitalName.Size = new Size(247, 32);
            lblHospitalName.TabIndex = 0;
            lblHospitalName.Text = "St. Joseph's Hospital";
            // 
            // panelHeaderRight
            // 
            panelHeaderRight.BackColor = Color.Transparent;
            panelHeaderRight.Dock = DockStyle.Right;
            panelHeaderRight.Location = new Point(1213, 0);
            panelHeaderRight.Name = "panelHeaderRight";
            panelHeaderRight.Size = new Size(0, 70);
            panelHeaderRight.TabIndex = 1;
            panelHeaderRight.Visible = false;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(1493, 854);
            Controls.Add(panelMainContent);
            Controls.Add(panelSidebar);
            MinimizeBox = false;
            MinimumSize = new Size(1200, 700);
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "St. Joseph's Hospital - Admin Dashboard";
            WindowState = FormWindowState.Maximized;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelMainContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabUsersMain.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            tabAllUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            tabAdmins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).EndInit();
            tabDoctors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDoctors).EndInit();
            tabStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStaff).EndInit();
            panelUserButtons.ResumeLayout(false);
            tabMedicalRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            panelMedicalButtons.ResumeLayout(false);
            tabBilling.ResumeLayout(false);
            tabBillingControl.ResumeLayout(false);
            tabActiveBills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBilling).EndInit();
            tabDischargedBills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDischargedBills).EndInit();
            panelBillingButtons.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUniversalSearch.ResumeLayout(false);
            panelUniversalSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelMainContent;
        private Panel panelHeader;
        private PictureBox pictureBoxProfile;
        private Label lblRole;
        private Label lblHospitalName;
        private Label lblWelcome;
        private Button btnLogout;
        private Button btnUsersMenu;
        private Button btnMedicalRecordsMenu;
        private Button btnBillingMenu;
        private TabControl tabControl;
        private TabPage tabUsersMain;
        private TabControl tabUsers;
        private TabPage tabAllUsers;
        private TabPage tabAdmins;
        private TabPage tabDoctors;
        private TabPage tabStaff;
        private TabControl tabBillingControl;
        private TabPage tabActiveBills;
        private TabPage tabDischargedBills;
        private DataGridView dgvUsers;
        private DataGridView dgvAdmins;
        private DataGridView dgvDoctors;
        private DataGridView dgvStaff;
        private Panel panelUserButtons;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private TabPage tabMedicalRecords;
        private DataGridView dgvPatients;
        private Panel panelMedicalButtons;
        private Button btnViewPatientRecord;
        private TabPage tabBilling;
        private DataGridView dgvBilling;
        private DataGridView dgvDischargedBills;
        private Panel panelBillingStats;
        private Panel panelBillingButtons;
        private Button btnViewBillDetails;
        private Panel buttonShadow;
        private Panel medicalBtnShadow;
        private Panel billBtnShadow;
        private Panel panelUniversalSearch;
        private TextBox txtUniversalSearch;
        private Button btnClearUniversalSearch;
        private Label lblUniversalSearchIcon;
        private Label label1;
        private Panel panelHeaderRight;
        private Button btnGenerateIncomeReport;
        private Button btnDeletePatient;
        private Button btnEditPatient;
        private Button btnAddPatient;
        private Button BtnViewPatientProfile;
        private Button btnViewUserProfile;
        private Button btnToggleAccountStatus;
    }
}