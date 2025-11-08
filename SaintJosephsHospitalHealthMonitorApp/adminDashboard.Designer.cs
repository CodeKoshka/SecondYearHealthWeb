namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class AdminDashboard
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
        private System.Windows.Forms.Button btnUsersMenu;
        private System.Windows.Forms.Button btnAppointmentsMenu;
        private System.Windows.Forms.Button btnBillingMenu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUsersMain;
        private System.Windows.Forms.TabControl tabUsers;
        private System.Windows.Forms.TabPage tabAllUsers;
        private System.Windows.Forms.TabPage tabAdmins;
        private System.Windows.Forms.TabPage tabDoctors;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridView dgvAdmins;
        private System.Windows.Forms.DataGridView dgvDoctors;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Panel panelUserButtons;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnRefreshUsers;
        private System.Windows.Forms.TabPage tabAppointments;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Panel panelAppointmentButtons;
        private System.Windows.Forms.Button btnAddAppointment;
        private System.Windows.Forms.Button btnEditAppointment;
        private System.Windows.Forms.Button btnDeleteAppointment;
        private System.Windows.Forms.Button btnRefreshAppointments;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Panel panelBillingButtons;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.Button btnUpdateBill;
        private System.Windows.Forms.Button btnRefreshBilling;
        private Panel buttonShadow;
        private Panel apptBtnShadow;
        private Panel billBtnShadow;
        private Panel panelUniversalSearch;
        private TextBox txtUniversalSearch;
        private Button btnClearUniversalSearch;
        private Label lblUniversalSearchIcon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            pictureBoxProfile = new PictureBox();
            lblWelcome = new Label();
            lblRole = new Label();
            btnUsersMenu = new Button();
            btnAppointmentsMenu = new Button();
            btnBillingMenu = new Button();
            btnLogout = new Button();
            panelMainContent = new Panel();
            tabControl = new TabControl();
            tabUsersMain = new TabPage();
            tabUsers = new TabControl();
            tabAllUsers = new TabPage();
            tabAdmins = new TabPage();
            tabDoctors = new TabPage();
            tabPatients = new TabPage();
            tabStaff = new TabPage();
            panelUserButtons = new Panel();
            btnRefreshUsers = new Button();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            btnAddUser = new Button();
            buttonShadow = new Panel();
            tabAppointments = new TabPage();
            panelAppointmentButtons = new Panel();
            btnRefreshAppointments = new Button();
            btnDeleteAppointment = new Button();
            btnEditAppointment = new Button();
            btnAddAppointment = new Button();
            apptBtnShadow = new Panel();
            tabBilling = new TabPage();
            panelBillingButtons = new Panel();
            btnRefreshBilling = new Button();
            btnUpdateBill = new Button();
            btnAddBill = new Button();
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
            panelUserButtons.SuspendLayout();
            tabAppointments.SuspendLayout();
            panelAppointmentButtons.SuspendLayout();
            tabBilling.SuspendLayout();
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
            panelSidebar.Controls.Add(btnAppointmentsMenu);
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
            // btnAppointmentsMenu
            // 
            btnAppointmentsMenu.BackColor = Color.Transparent;
            btnAppointmentsMenu.Cursor = Cursors.Hand;
            btnAppointmentsMenu.FlatAppearance.BorderSize = 0;
            btnAppointmentsMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnAppointmentsMenu.FlatStyle = FlatStyle.Flat;
            btnAppointmentsMenu.Font = new Font("Segoe UI", 10F);
            btnAppointmentsMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnAppointmentsMenu.Location = new Point(15, 345);
            btnAppointmentsMenu.Name = "btnAppointmentsMenu";
            btnAppointmentsMenu.Padding = new Padding(20, 0, 0, 0);
            btnAppointmentsMenu.Size = new Size(250, 45);
            btnAppointmentsMenu.TabIndex = 5;
            btnAppointmentsMenu.Text = "  📅  Appointments";
            btnAppointmentsMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnAppointmentsMenu.UseVisualStyleBackColor = false;
            btnAppointmentsMenu.Click += BtnAppointmentsMenu_Click;
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
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 174, 192);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(15, 774);
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
            panelMainContent.Size = new Size(1213, 854);
            panelMainContent.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.Controls.Add(tabUsersMain);
            tabControl.Controls.Add(tabAppointments);
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
            tabUsers.Controls.Add(tabPatients);
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
            tabAllUsers.Location = new Point(4, 26);
            tabAllUsers.Name = "tabAllUsers";
            tabAllUsers.Padding = new Padding(15);
            tabAllUsers.Size = new Size(1157, 596);
            tabAllUsers.TabIndex = 0;
            tabAllUsers.Text = "📋 All Users";
            // 
            // tabAdmins
            // 
            tabAdmins.BackColor = Color.White;
            tabAdmins.Location = new Point(4, 26);
            tabAdmins.Name = "tabAdmins";
            tabAdmins.Padding = new Padding(15);
            tabAdmins.Size = new Size(1157, 596);
            tabAdmins.TabIndex = 1;
            tabAdmins.Text = "👔 Admins";
            // 
            // tabDoctors
            // 
            tabDoctors.BackColor = Color.White;
            tabDoctors.Location = new Point(4, 26);
            tabDoctors.Name = "tabDoctors";
            tabDoctors.Padding = new Padding(15);
            tabDoctors.Size = new Size(1157, 596);
            tabDoctors.TabIndex = 2;
            tabDoctors.Text = "\U0001fa7a Doctors";
            // 
            // tabPatients
            // 
            tabPatients.BackColor = Color.White;
            tabPatients.Location = new Point(4, 26);
            tabPatients.Name = "tabPatients";
            tabPatients.Padding = new Padding(15);
            tabPatients.Size = new Size(1157, 596);
            tabPatients.TabIndex = 3;
            tabPatients.Text = "🏥 Patients";
            // 
            // tabStaff
            // 
            tabStaff.BackColor = Color.White;
            tabStaff.Location = new Point(4, 26);
            tabStaff.Name = "tabStaff";
            tabStaff.Padding = new Padding(15);
            tabStaff.Size = new Size(1157, 596);
            tabStaff.TabIndex = 4;
            tabStaff.Text = "👨‍💼 Staff";
            // 
            // panelUserButtons
            // 
            panelUserButtons.BackColor = Color.White;
            panelUserButtons.Controls.Add(btnRefreshUsers);
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
            // btnRefreshUsers
            // 
            btnRefreshUsers.BackColor = Color.FromArgb(113, 128, 150);
            btnRefreshUsers.Cursor = Cursors.Hand;
            btnRefreshUsers.FlatAppearance.BorderSize = 0;
            btnRefreshUsers.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 103, 122);
            btnRefreshUsers.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefreshUsers.ForeColor = Color.White;
            btnRefreshUsers.Location = new Point(560, 15);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(150, 45);
            btnRefreshUsers.TabIndex = 0;
            btnRefreshUsers.Text = "🔄 Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = false;
            btnRefreshUsers.Click += BtnRefresh_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.BackColor = Color.FromArgb(229, 62, 62);
            btnDeleteUser.Cursor = Cursors.Hand;
            btnDeleteUser.FlatAppearance.BorderSize = 0;
            btnDeleteUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 48, 48);
            btnDeleteUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteUser.ForeColor = Color.White;
            btnDeleteUser.Location = new Point(380, 15);
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
            btnEditUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(200, 15);
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
            btnAddUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(20, 15);
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
            // tabAppointments
            // 
            tabAppointments.BackColor = Color.FromArgb(247, 250, 252);
            tabAppointments.Controls.Add(panelAppointmentButtons);
            tabAppointments.Location = new Point(4, 34);
            tabAppointments.Name = "tabAppointments";
            tabAppointments.Padding = new Padding(20);
            tabAppointments.Size = new Size(1205, 746);
            tabAppointments.TabIndex = 1;
            // 
            // panelAppointmentButtons
            // 
            panelAppointmentButtons.BackColor = Color.White;
            panelAppointmentButtons.Controls.Add(btnRefreshAppointments);
            panelAppointmentButtons.Controls.Add(btnDeleteAppointment);
            panelAppointmentButtons.Controls.Add(btnEditAppointment);
            panelAppointmentButtons.Controls.Add(btnAddAppointment);
            panelAppointmentButtons.Controls.Add(apptBtnShadow);
            panelAppointmentButtons.Dock = DockStyle.Top;
            panelAppointmentButtons.Location = new Point(20, 20);
            panelAppointmentButtons.Name = "panelAppointmentButtons";
            panelAppointmentButtons.Padding = new Padding(20, 15, 20, 15);
            panelAppointmentButtons.Size = new Size(1165, 80);
            panelAppointmentButtons.TabIndex = 1;
            // 
            // btnRefreshAppointments
            // 
            btnRefreshAppointments.BackColor = Color.FromArgb(113, 128, 150);
            btnRefreshAppointments.Cursor = Cursors.Hand;
            btnRefreshAppointments.FlatAppearance.BorderSize = 0;
            btnRefreshAppointments.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 103, 122);
            btnRefreshAppointments.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefreshAppointments.ForeColor = Color.White;
            btnRefreshAppointments.Location = new Point(560, 15);
            btnRefreshAppointments.Name = "btnRefreshAppointments";
            btnRefreshAppointments.Size = new Size(150, 45);
            btnRefreshAppointments.TabIndex = 0;
            btnRefreshAppointments.Text = "🔄 Refresh";
            btnRefreshAppointments.UseVisualStyleBackColor = false;
            btnRefreshAppointments.Click += BtnRefresh_Click;
            // 
            // btnDeleteAppointment
            // 
            btnDeleteAppointment.BackColor = Color.FromArgb(229, 62, 62);
            btnDeleteAppointment.Cursor = Cursors.Hand;
            btnDeleteAppointment.FlatAppearance.BorderSize = 0;
            btnDeleteAppointment.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 48, 48);
            btnDeleteAppointment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteAppointment.ForeColor = Color.White;
            btnDeleteAppointment.Location = new Point(390, 15);
            btnDeleteAppointment.Name = "btnDeleteAppointment";
            btnDeleteAppointment.Size = new Size(160, 45);
            btnDeleteAppointment.TabIndex = 1;
            btnDeleteAppointment.Text = "❌ Cancel";
            btnDeleteAppointment.UseVisualStyleBackColor = false;
            btnDeleteAppointment.Click += BtnDeleteAppointment_Click;
            // 
            // btnEditAppointment
            // 
            btnEditAppointment.BackColor = Color.FromArgb(66, 153, 225);
            btnEditAppointment.Cursor = Cursors.Hand;
            btnEditAppointment.FlatAppearance.BorderSize = 0;
            btnEditAppointment.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnEditAppointment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditAppointment.ForeColor = Color.White;
            btnEditAppointment.Location = new Point(200, 15);
            btnEditAppointment.Name = "btnEditAppointment";
            btnEditAppointment.Size = new Size(180, 45);
            btnEditAppointment.TabIndex = 2;
            btnEditAppointment.Text = "📝 Update Status";
            btnEditAppointment.UseVisualStyleBackColor = false;
            btnEditAppointment.Click += BtnEditAppointment_Click;
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.BackColor = Color.FromArgb(72, 187, 120);
            btnAddAppointment.Cursor = Cursors.Hand;
            btnAddAppointment.FlatAppearance.BorderSize = 0;
            btnAddAppointment.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 161, 105);
            btnAddAppointment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddAppointment.ForeColor = Color.White;
            btnAddAppointment.Location = new Point(20, 15);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(170, 45);
            btnAddAppointment.TabIndex = 3;
            btnAddAppointment.Text = "➕ Schedule";
            btnAddAppointment.UseVisualStyleBackColor = false;
            btnAddAppointment.Click += BtnAddAppointment_Click;
            // 
            // apptBtnShadow
            // 
            apptBtnShadow.BackColor = Color.FromArgb(226, 232, 240);
            apptBtnShadow.Dock = DockStyle.Bottom;
            apptBtnShadow.Location = new Point(20, 64);
            apptBtnShadow.Name = "apptBtnShadow";
            apptBtnShadow.Size = new Size(1125, 1);
            apptBtnShadow.TabIndex = 4;
            // 
            // tabBilling
            // 
            tabBilling.BackColor = Color.FromArgb(247, 250, 252);
            tabBilling.Controls.Add(panelBillingButtons);
            tabBilling.Location = new Point(4, 34);
            tabBilling.Name = "tabBilling";
            tabBilling.Padding = new Padding(20);
            tabBilling.Size = new Size(1205, 746);
            tabBilling.TabIndex = 2;
            // 
            // panelBillingButtons
            // 
            panelBillingButtons.BackColor = Color.White;
            panelBillingButtons.Controls.Add(btnRefreshBilling);
            panelBillingButtons.Controls.Add(btnUpdateBill);
            panelBillingButtons.Controls.Add(btnAddBill);
            panelBillingButtons.Controls.Add(billBtnShadow);
            panelBillingButtons.Dock = DockStyle.Top;
            panelBillingButtons.Location = new Point(20, 20);
            panelBillingButtons.Name = "panelBillingButtons";
            panelBillingButtons.Padding = new Padding(20, 15, 20, 15);
            panelBillingButtons.Size = new Size(1165, 80);
            panelBillingButtons.TabIndex = 1;
            // 
            // btnRefreshBilling
            // 
            btnRefreshBilling.BackColor = Color.FromArgb(113, 128, 150);
            btnRefreshBilling.Cursor = Cursors.Hand;
            btnRefreshBilling.FlatAppearance.BorderSize = 0;
            btnRefreshBilling.FlatAppearance.MouseOverBackColor = Color.FromArgb(90, 103, 122);
            btnRefreshBilling.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefreshBilling.ForeColor = Color.White;
            btnRefreshBilling.Location = new Point(420, 15);
            btnRefreshBilling.Name = "btnRefreshBilling";
            btnRefreshBilling.Size = new Size(150, 45);
            btnRefreshBilling.TabIndex = 0;
            btnRefreshBilling.Text = "🔄 Refresh";
            btnRefreshBilling.UseVisualStyleBackColor = false;
            btnRefreshBilling.Click += BtnRefresh_Click;
            // 
            // btnUpdateBill
            // 
            btnUpdateBill.BackColor = Color.FromArgb(66, 153, 225);
            btnUpdateBill.Cursor = Cursors.Hand;
            btnUpdateBill.FlatAppearance.BorderSize = 0;
            btnUpdateBill.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 131, 186);
            btnUpdateBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateBill.ForeColor = Color.White;
            btnUpdateBill.Location = new Point(220, 15);
            btnUpdateBill.Name = "btnUpdateBill";
            btnUpdateBill.Size = new Size(190, 45);
            btnUpdateBill.TabIndex = 1;
            btnUpdateBill.Text = "💳 Mark as Paid";
            btnUpdateBill.UseVisualStyleBackColor = false;
            btnUpdateBill.Click += BtnUpdateBill_Click;
            // 
            // btnAddBill
            // 
            btnAddBill.BackColor = Color.FromArgb(72, 187, 120);
            btnAddBill.Cursor = Cursors.Hand;
            btnAddBill.FlatAppearance.BorderSize = 0;
            btnAddBill.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 161, 105);
            btnAddBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddBill.ForeColor = Color.White;
            btnAddBill.Location = new Point(20, 15);
            btnAddBill.Name = "btnAddBill";
            btnAddBill.Size = new Size(190, 45);
            btnAddBill.TabIndex = 2;
            btnAddBill.Text = "➕ Create Invoice";
            btnAddBill.UseVisualStyleBackColor = false;
            btnAddBill.Click += BtnAddBill_Click;
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
            txtUniversalSearch.PlaceholderText = "Search users, appointments, billing...";
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
            MinimumSize = new Size(1200, 700);
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "St. Joseph's Hospital - Admin Dashboard";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelMainContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabUsersMain.ResumeLayout(false);
            tabUsers.ResumeLayout(false);
            panelUserButtons.ResumeLayout(false);
            tabAppointments.ResumeLayout(false);
            panelAppointmentButtons.ResumeLayout(false);
            tabBilling.ResumeLayout(false);
            panelBillingButtons.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelUniversalSearch.ResumeLayout(false);
            panelUniversalSearch.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView CreateStyledDataGridView()
        {
            Color headerBg = Color.FromArgb(66, 153, 225);
            Color cellBg = Color.White;
            Color cellText = Color.FromArgb(26, 32, 44);
            Color selectedBg = Color.FromArgb(191, 219, 254);
            Color selectedText = Color.FromArgb(26, 32, 44);
            Color gridColor = Color.FromArgb(226, 232, 240);

            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = headerBg;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = Color.White;
            headerStyle.SelectionBackColor = headerBg;
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            headerStyle.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);

            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            cellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = cellBg;
            cellStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            cellStyle.ForeColor = cellText;
            cellStyle.SelectionBackColor = selectedBg;
            cellStyle.SelectionForeColor = selectedText;
            cellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            cellStyle.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);

            var dgv = new System.Windows.Forms.DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = cellBg;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle = cellStyle;
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = gridColor;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 45;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // Enable double buffering for smoother rendering
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, dgv, new object[] { true });

            return dgv;
        }
        private Label label1;
        private Panel panelHeaderRight;
    }
}
