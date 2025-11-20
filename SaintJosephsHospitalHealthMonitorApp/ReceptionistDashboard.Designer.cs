namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ReceptionistDashboard
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
        private System.Windows.Forms.Button btnQueueMenu;
        private System.Windows.Forms.Button btnPatientsMenu;
        private System.Windows.Forms.Button btnBillingMenu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabQueue;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Panel panelQueueButtons;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.Button btnAssignDoctor;
        private System.Windows.Forms.Button btnCallNext;
        private System.Windows.Forms.Button btnRemoveFromQueue;
        private System.Windows.Forms.Button BtnAddPatient;
        private System.Windows.Forms.Label lblQueueCount;
        private System.Windows.Forms.Panel panelPatientButtons;
        private System.Windows.Forms.Button btnViewPatient;
        private System.Windows.Forms.Button BtnEditIntake;
        private System.Windows.Forms.Button btnCheckMedicalHistory;
        private System.Windows.Forms.Panel panelBillingButtons;
        private System.Windows.Forms.Button btnDoctorServiceReport;
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Button btnUpdateBill;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnDischargePatient;
        private System.Windows.Forms.Panel panelUniversalSearch;
        private System.Windows.Forms.TextBox txtUniversalSearch;
        private System.Windows.Forms.Button btnClearUniversalSearch;
        private System.Windows.Forms.Label lblUniversalSearchIcon;
        private System.Windows.Forms.Button btnCreateBill;
        private ListBox searchSuggestionsListBox;
        private Label lblSearchStatus;
        private Panel panelSearchCategories;
        private CheckBox chkSearchQueue;
        private CheckBox chkSearchPatients;
        private CheckBox chkSearchBilling;

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
            btnQueueMenu = new Button();
            btnPatientsMenu = new Button();
            btnBillingMenu = new Button();
            btnLogout = new Button();
            panelMainContent = new Panel();
            tabControl = new TabControl();
            tabQueue = new TabPage();
            dgvQueue = new DataGridView();
            panelQueueButtons = new Panel();
            btnRemoveAllFromQueue = new Button();
            btnAddToQueue = new Button();
            btnAssignDoctor = new Button();
            btnCallNext = new Button();
            BtnAddPatient = new Button();
            btnRemoveFromQueue = new Button();
            tabPatients = new TabPage();
            dgvPatients = new DataGridView();
            panelPatientButtons = new Panel();
            btnEditPatient = new Button();
            BtnViewProfile = new Button();
            btnViewPatient = new Button();
            BtnEditIntake = new Button();
            btnCheckMedicalHistory = new Button();
            tabBilling = new TabPage();
            dgvBilling = new DataGridView();
            panelBillingButtons = new Panel();
            BtnCancelBill = new Button();
            btnViewBill = new Button();
            btnUpdateBill = new Button();
            btnProcessPayment = new Button();
            btnDischargePatient = new Button();
            btnDoctorServiceReport = new Button();
            btnCreateBill = new Button();
            panelHeader = new Panel();
            label1 = new Label();
            lblQueueCount = new Label();
            panelUniversalSearch = new Panel();
            lblUniversalSearchIcon = new Label();
            btnClearUniversalSearch = new Button();
            txtUniversalSearch = new TextBox();
            lblHospitalName = new Label();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).BeginInit();
            panelMainContent.SuspendLayout();
            tabControl.SuspendLayout();
            tabQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            panelQueueButtons.SuspendLayout();
            tabPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            panelPatientButtons.SuspendLayout();
            tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).BeginInit();
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
            panelSidebar.Controls.Add(btnQueueMenu);
            panelSidebar.Controls.Add(btnPatientsMenu);
            panelSidebar.Controls.Add(btnBillingMenu);
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
            lblWelcome.Text = "Welcome, Receptionist";
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
            lblRole.Text = "Role: Receptionist";
            lblRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnQueueMenu
            // 
            btnQueueMenu.BackColor = Color.FromArgb(231, 76, 60);
            btnQueueMenu.Cursor = Cursors.Hand;
            btnQueueMenu.FlatAppearance.BorderSize = 0;
            btnQueueMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnQueueMenu.FlatStyle = FlatStyle.Flat;
            btnQueueMenu.Font = new Font("Segoe UI", 10F);
            btnQueueMenu.ForeColor = Color.White;
            btnQueueMenu.Location = new Point(15, 290);
            btnQueueMenu.Name = "btnQueueMenu";
            btnQueueMenu.Padding = new Padding(20, 0, 0, 0);
            btnQueueMenu.Size = new Size(250, 45);
            btnQueueMenu.TabIndex = 4;
            btnQueueMenu.Text = "  👥  Patient Queue";
            btnQueueMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnQueueMenu.UseVisualStyleBackColor = false;
            btnQueueMenu.Click += BtnQueueMenu_Click;
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
            btnPatientsMenu.Text = "  📋  Patient Records";
            btnPatientsMenu.TextAlign = ContentAlignment.MiddleLeft;
            btnPatientsMenu.UseVisualStyleBackColor = false;
            btnPatientsMenu.Click += BtnPatientsMenu_Click;
            // 
            // btnBillingMenu
            // 
            btnBillingMenu.BackColor = Color.Transparent;
            btnBillingMenu.Cursor = Cursors.Hand;
            btnBillingMenu.FlatAppearance.BorderSize = 0;
            btnBillingMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 72);
            btnBillingMenu.FlatStyle = FlatStyle.Flat;
            btnBillingMenu.Font = new Font("Segoe UI", 10F);
            btnBillingMenu.ForeColor = Color.FromArgb(226, 232, 240);
            btnBillingMenu.Location = new Point(15, 400);
            btnBillingMenu.Name = "btnBillingMenu";
            btnBillingMenu.Padding = new Padding(20, 0, 0, 0);
            btnBillingMenu.Size = new Size(250, 45);
            btnBillingMenu.TabIndex = 6;
            btnBillingMenu.Text = "  💰  Billing & Discharge";
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
            tabControl.Controls.Add(tabQueue);
            tabControl.Controls.Add(tabPatients);
            tabControl.Controls.Add(tabBilling);
            tabControl.Dock = DockStyle.Fill;
            tabControl.ItemSize = new Size(120, 30);
            tabControl.Location = new Point(0, 70);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1204, 691);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabQueue
            // 
            tabQueue.BackColor = Color.FromArgb(247, 250, 252);
            tabQueue.Controls.Add(dgvQueue);
            tabQueue.Controls.Add(panelQueueButtons);
            tabQueue.Location = new Point(4, 34);
            tabQueue.Name = "tabQueue";
            tabQueue.Padding = new Padding(20);
            tabQueue.Size = new Size(1196, 653);
            tabQueue.TabIndex = 0;
            // 
            // dgvQueue
            // 
            dgvQueue.AllowUserToAddRows = false;
            dgvQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQueue.BackgroundColor = Color.White;
            dgvQueue.BorderStyle = BorderStyle.None;
            dgvQueue.ColumnHeadersHeight = 50;
            dgvQueue.Dock = DockStyle.Fill;
            dgvQueue.Location = new Point(20, 100);
            dgvQueue.Name = "dgvQueue";
            dgvQueue.ReadOnly = true;
            dgvQueue.RowHeadersVisible = false;
            dgvQueue.RowTemplate.Height = 45;
            dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQueue.Size = new Size(1156, 533);
            dgvQueue.TabIndex = 0;
            // 
            // panelQueueButtons
            // 
            panelQueueButtons.BackColor = Color.White;
            panelQueueButtons.Controls.Add(btnRemoveAllFromQueue);
            panelQueueButtons.Controls.Add(btnAddToQueue);
            panelQueueButtons.Controls.Add(btnAssignDoctor);
            panelQueueButtons.Controls.Add(btnCallNext);
            panelQueueButtons.Controls.Add(BtnAddPatient);
            panelQueueButtons.Controls.Add(btnRemoveFromQueue);
            panelQueueButtons.Dock = DockStyle.Top;
            panelQueueButtons.Location = new Point(20, 20);
            panelQueueButtons.Name = "panelQueueButtons";
            panelQueueButtons.Padding = new Padding(20, 15, 20, 15);
            panelQueueButtons.Size = new Size(1156, 80);
            panelQueueButtons.TabIndex = 1;
            // 
            // btnRemoveAllFromQueue
            // 
            btnRemoveAllFromQueue.BackColor = Color.FromArgb(220, 53, 69);
            btnRemoveAllFromQueue.Cursor = Cursors.Hand;
            btnRemoveAllFromQueue.FlatAppearance.BorderSize = 0;
            btnRemoveAllFromQueue.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            btnRemoveAllFromQueue.FlatStyle = FlatStyle.Flat;
            btnRemoveAllFromQueue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemoveAllFromQueue.ForeColor = Color.White;
            btnRemoveAllFromQueue.Location = new Point(790, 15);
            btnRemoveAllFromQueue.Name = "btnRemoveAllFromQueue";
            btnRemoveAllFromQueue.Size = new Size(150, 45);
            btnRemoveAllFromQueue.TabIndex = 5;
            btnRemoveAllFromQueue.Text = "🗑️ Remove All";
            btnRemoveAllFromQueue.UseVisualStyleBackColor = false;
            btnRemoveAllFromQueue.Click += BtnRemoveAllFromQueue_Click;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.BackColor = Color.FromArgb(46, 204, 113);
            btnAddToQueue.Cursor = Cursors.Hand;
            btnAddToQueue.FlatAppearance.BorderSize = 0;
            btnAddToQueue.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            btnAddToQueue.FlatStyle = FlatStyle.Flat;
            btnAddToQueue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddToQueue.ForeColor = Color.White;
            btnAddToQueue.Location = new Point(20, 15);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(150, 45);
            btnAddToQueue.TabIndex = 0;
            btnAddToQueue.Text = "➕ Add to Queue";
            btnAddToQueue.UseVisualStyleBackColor = false;
            btnAddToQueue.Click += BtnAddToQueue_Click;
            // 
            // btnAssignDoctor
            // 
            btnAssignDoctor.BackColor = Color.FromArgb(52, 152, 219);
            btnAssignDoctor.Cursor = Cursors.Hand;
            btnAssignDoctor.FlatAppearance.BorderSize = 0;
            btnAssignDoctor.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnAssignDoctor.FlatStyle = FlatStyle.Flat;
            btnAssignDoctor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAssignDoctor.ForeColor = Color.White;
            btnAssignDoctor.Location = new Point(180, 15);
            btnAssignDoctor.Name = "btnAssignDoctor";
            btnAssignDoctor.Size = new Size(150, 45);
            btnAssignDoctor.TabIndex = 1;
            btnAssignDoctor.Text = "👨‍⚕️ Assign Doctor";
            btnAssignDoctor.UseVisualStyleBackColor = false;
            btnAssignDoctor.Click += BtnAssignDoctor_Click;
            // 
            // btnCallNext
            // 
            btnCallNext.BackColor = Color.FromArgb(241, 196, 15);
            btnCallNext.Cursor = Cursors.Hand;
            btnCallNext.FlatAppearance.BorderSize = 0;
            btnCallNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 156, 18);
            btnCallNext.FlatStyle = FlatStyle.Flat;
            btnCallNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCallNext.ForeColor = Color.White;
            btnCallNext.Location = new Point(340, 15);
            btnCallNext.Name = "btnCallNext";
            btnCallNext.Size = new Size(150, 45);
            btnCallNext.TabIndex = 2;
            btnCallNext.Text = "📢 Call Patient";
            btnCallNext.UseVisualStyleBackColor = false;
            btnCallNext.Click += BtnCallNext_Click;
            // 
            // BtnAddPatient
            // 
            BtnAddPatient.BackColor = Color.FromArgb(155, 89, 182);
            BtnAddPatient.Cursor = Cursors.Hand;
            BtnAddPatient.FlatAppearance.BorderSize = 0;
            BtnAddPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(142, 68, 173);
            BtnAddPatient.FlatStyle = FlatStyle.Flat;
            BtnAddPatient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnAddPatient.ForeColor = Color.White;
            BtnAddPatient.Location = new Point(500, 15);
            BtnAddPatient.Name = "BtnAddPatient";
            BtnAddPatient.Size = new Size(150, 45);
            BtnAddPatient.TabIndex = 3;
            BtnAddPatient.Text = "👤 Add Patient";
            BtnAddPatient.UseVisualStyleBackColor = false;
            BtnAddPatient.Click += BtnAddPatient_Click;
            // 
            // btnRemoveFromQueue
            // 
            btnRemoveFromQueue.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveFromQueue.Cursor = Cursors.Hand;
            btnRemoveFromQueue.FlatAppearance.BorderSize = 0;
            btnRemoveFromQueue.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnRemoveFromQueue.FlatStyle = FlatStyle.Flat;
            btnRemoveFromQueue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemoveFromQueue.ForeColor = Color.White;
            btnRemoveFromQueue.Location = new Point(660, 15);
            btnRemoveFromQueue.Name = "btnRemoveFromQueue";
            btnRemoveFromQueue.Size = new Size(120, 45);
            btnRemoveFromQueue.TabIndex = 4;
            btnRemoveFromQueue.Text = "✕ Remove";
            btnRemoveFromQueue.UseVisualStyleBackColor = false;
            btnRemoveFromQueue.Click += BtnRemoveFromQueue_Click;
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
            panelPatientButtons.Controls.Add(btnEditPatient);
            panelPatientButtons.Controls.Add(BtnViewProfile);
            panelPatientButtons.Controls.Add(btnViewPatient);
            panelPatientButtons.Controls.Add(BtnEditIntake);
            panelPatientButtons.Controls.Add(btnCheckMedicalHistory);
            panelPatientButtons.Dock = DockStyle.Top;
            panelPatientButtons.Location = new Point(20, 20);
            panelPatientButtons.Name = "panelPatientButtons";
            panelPatientButtons.Padding = new Padding(20, 15, 20, 15);
            panelPatientButtons.Size = new Size(1156, 80);
            panelPatientButtons.TabIndex = 1;
            // 
            // btnEditPatient
            // 
            btnEditPatient.BackColor = Color.FromArgb(255, 152, 0);
            btnEditPatient.Cursor = Cursors.Hand;
            btnEditPatient.FlatAppearance.BorderSize = 0;
            btnEditPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 124, 0);
            btnEditPatient.FlatStyle = FlatStyle.Flat;
            btnEditPatient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditPatient.ForeColor = Color.White;
            btnEditPatient.Location = new Point(199, 18);
            btnEditPatient.Name = "btnEditPatient";
            btnEditPatient.Size = new Size(170, 45);
            btnEditPatient.TabIndex = 4;
            btnEditPatient.Text = "✏ Edit Profile";
            btnEditPatient.UseVisualStyleBackColor = false;
            btnEditPatient.Click += BtnEditPatient_Click;
            // 
            // BtnViewProfile
            // 
            BtnViewProfile.BackColor = Color.FromArgb(52, 152, 219);
            BtnViewProfile.Cursor = Cursors.Hand;
            BtnViewProfile.FlatAppearance.BorderSize = 0;
            BtnViewProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            BtnViewProfile.FlatStyle = FlatStyle.Flat;
            BtnViewProfile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnViewProfile.ForeColor = Color.White;
            BtnViewProfile.Location = new Point(23, 18);
            BtnViewProfile.Name = "BtnViewProfile";
            BtnViewProfile.Size = new Size(170, 45);
            BtnViewProfile.TabIndex = 3;
            BtnViewProfile.Text = "👁 View Profile";
            BtnViewProfile.UseVisualStyleBackColor = false;
            // 
            // btnViewPatient
            // 
            btnViewPatient.BackColor = Color.FromArgb(52, 152, 219);
            btnViewPatient.Cursor = Cursors.Hand;
            btnViewPatient.FlatAppearance.BorderSize = 0;
            btnViewPatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnViewPatient.FlatStyle = FlatStyle.Flat;
            btnViewPatient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewPatient.ForeColor = Color.White;
            btnViewPatient.Location = new Point(375, 18);
            btnViewPatient.Name = "btnViewPatient";
            btnViewPatient.Size = new Size(170, 45);
            btnViewPatient.TabIndex = 0;
            btnViewPatient.Text = "👁 View Details";
            btnViewPatient.UseVisualStyleBackColor = false;
            btnViewPatient.Click += BtnViewPatient_Click;
            // 
            // BtnEditIntake
            // 
            BtnEditIntake.BackColor = Color.FromArgb(255, 152, 0);
            BtnEditIntake.Cursor = Cursors.Hand;
            BtnEditIntake.FlatAppearance.BorderSize = 0;
            BtnEditIntake.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 124, 0);
            BtnEditIntake.FlatStyle = FlatStyle.Flat;
            BtnEditIntake.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnEditIntake.ForeColor = Color.White;
            BtnEditIntake.Location = new Point(551, 18);
            BtnEditIntake.Name = "BtnEditIntake";
            BtnEditIntake.Size = new Size(170, 45);
            BtnEditIntake.TabIndex = 1;
            BtnEditIntake.Text = "✏ Edit Details";
            BtnEditIntake.UseVisualStyleBackColor = false;
            BtnEditIntake.Click += BtnEditIntake_Click;
            // 
            // btnCheckMedicalHistory
            // 
            btnCheckMedicalHistory.BackColor = Color.FromArgb(156, 39, 176);
            btnCheckMedicalHistory.Cursor = Cursors.Hand;
            btnCheckMedicalHistory.FlatAppearance.BorderSize = 0;
            btnCheckMedicalHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(142, 36, 170);
            btnCheckMedicalHistory.FlatStyle = FlatStyle.Flat;
            btnCheckMedicalHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCheckMedicalHistory.ForeColor = Color.White;
            btnCheckMedicalHistory.Location = new Point(727, 18);
            btnCheckMedicalHistory.Name = "btnCheckMedicalHistory";
            btnCheckMedicalHistory.Size = new Size(190, 45);
            btnCheckMedicalHistory.TabIndex = 2;
            btnCheckMedicalHistory.Text = "📋 Medical History";
            btnCheckMedicalHistory.UseVisualStyleBackColor = false;
            btnCheckMedicalHistory.Click += BtnCheckMedicalHistory_Click;
            // 
            // tabBilling
            // 
            tabBilling.BackColor = Color.FromArgb(247, 250, 252);
            tabBilling.Controls.Add(dgvBilling);
            tabBilling.Controls.Add(panelBillingButtons);
            tabBilling.Location = new Point(4, 34);
            tabBilling.Name = "tabBilling";
            tabBilling.Padding = new Padding(20);
            tabBilling.Size = new Size(1196, 653);
            tabBilling.TabIndex = 2;
            // 
            // dgvBilling
            // 
            dgvBilling.AllowUserToAddRows = false;
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilling.BackgroundColor = Color.White;
            dgvBilling.BorderStyle = BorderStyle.None;
            dgvBilling.ColumnHeadersHeight = 50;
            dgvBilling.Dock = DockStyle.Fill;
            dgvBilling.Location = new Point(20, 100);
            dgvBilling.Name = "dgvBilling";
            dgvBilling.ReadOnly = true;
            dgvBilling.RowHeadersVisible = false;
            dgvBilling.RowTemplate.Height = 45;
            dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilling.Size = new Size(1156, 533);
            dgvBilling.TabIndex = 0;
            // 
            // panelBillingButtons
            // 
            panelBillingButtons.BackColor = Color.White;
            panelBillingButtons.Controls.Add(BtnCancelBill);
            panelBillingButtons.Controls.Add(btnViewBill);
            panelBillingButtons.Controls.Add(btnUpdateBill);
            panelBillingButtons.Controls.Add(btnProcessPayment);
            panelBillingButtons.Controls.Add(btnDischargePatient);
            panelBillingButtons.Controls.Add(btnDoctorServiceReport);
            panelBillingButtons.Controls.Add(btnCreateBill);
            panelBillingButtons.Dock = DockStyle.Top;
            panelBillingButtons.Location = new Point(20, 20);
            panelBillingButtons.Name = "panelBillingButtons";
            panelBillingButtons.Padding = new Padding(20, 15, 20, 15);
            panelBillingButtons.Size = new Size(1156, 80);
            panelBillingButtons.TabIndex = 1;
            // 
            // BtnCancelBill
            // 
            BtnCancelBill.BackColor = Color.FromArgb(220, 53, 69);
            BtnCancelBill.Cursor = Cursors.Hand;
            BtnCancelBill.FlatAppearance.BorderSize = 0;
            BtnCancelBill.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 35, 51);
            BtnCancelBill.FlatStyle = FlatStyle.Flat;
            BtnCancelBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnCancelBill.ForeColor = Color.White;
            BtnCancelBill.Location = new Point(637, 18);
            BtnCancelBill.Name = "BtnCancelBill";
            BtnCancelBill.Size = new Size(130, 45);
            BtnCancelBill.TabIndex = 6;
            BtnCancelBill.Text = "🗑️ Cancel Bill";
            BtnCancelBill.UseVisualStyleBackColor = false;
            BtnCancelBill.Click += BtnCancelBill_Click;
            // 
            // btnViewBill
            // 
            btnViewBill.BackColor = Color.FromArgb(149, 165, 166);
            btnViewBill.Cursor = Cursors.Hand;
            btnViewBill.FlatAppearance.BorderSize = 0;
            btnViewBill.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 140, 141);
            btnViewBill.FlatStyle = FlatStyle.Flat;
            btnViewBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewBill.ForeColor = Color.White;
            btnViewBill.Location = new Point(501, 18);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.Size = new Size(130, 45);
            btnViewBill.TabIndex = 0;
            btnViewBill.Text = "👁️ View Bill";
            btnViewBill.UseVisualStyleBackColor = false;
            btnViewBill.Click += BtnViewBill_Click;
            // 
            // btnUpdateBill
            // 
            btnUpdateBill.BackColor = Color.FromArgb(243, 156, 18);
            btnUpdateBill.Cursor = Cursors.Hand;
            btnUpdateBill.FlatAppearance.BorderSize = 0;
            btnUpdateBill.FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 136, 16);
            btnUpdateBill.FlatStyle = FlatStyle.Flat;
            btnUpdateBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateBill.ForeColor = Color.White;
            btnUpdateBill.Location = new Point(365, 18);
            btnUpdateBill.Name = "btnUpdateBill";
            btnUpdateBill.Size = new Size(130, 45);
            btnUpdateBill.TabIndex = 1;
            btnUpdateBill.Text = "✏️ Update Bill";
            btnUpdateBill.UseVisualStyleBackColor = false;
            btnUpdateBill.Click += BtnUpdateBill_Click;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.BackColor = Color.FromArgb(52, 152, 219);
            btnProcessPayment.Cursor = Cursors.Hand;
            btnProcessPayment.FlatAppearance.BorderSize = 0;
            btnProcessPayment.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
            btnProcessPayment.FlatStyle = FlatStyle.Flat;
            btnProcessPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcessPayment.ForeColor = Color.White;
            btnProcessPayment.Location = new Point(773, 18);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(160, 45);
            btnProcessPayment.TabIndex = 2;
            btnProcessPayment.Text = "💳 Process Payment";
            btnProcessPayment.UseVisualStyleBackColor = false;
            btnProcessPayment.Click += BtnProcessPayment_Click;
            // 
            // btnDischargePatient
            // 
            btnDischargePatient.BackColor = Color.FromArgb(46, 204, 113);
            btnDischargePatient.Cursor = Cursors.Hand;
            btnDischargePatient.FlatAppearance.BorderSize = 0;
            btnDischargePatient.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            btnDischargePatient.FlatStyle = FlatStyle.Flat;
            btnDischargePatient.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDischargePatient.ForeColor = Color.White;
            btnDischargePatient.Location = new Point(939, 18);
            btnDischargePatient.Name = "btnDischargePatient";
            btnDischargePatient.Size = new Size(200, 45);
            btnDischargePatient.TabIndex = 3;
            btnDischargePatient.Text = "🚪 Discharge Patient";
            btnDischargePatient.UseVisualStyleBackColor = false;
            btnDischargePatient.Click += BtnDischargePatient_Click;
            // 
            // btnDoctorServiceReport
            // 
            btnDoctorServiceReport.BackColor = Color.FromArgb(156, 39, 176);
            btnDoctorServiceReport.Cursor = Cursors.Hand;
            btnDoctorServiceReport.FlatAppearance.BorderSize = 0;
            btnDoctorServiceReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(142, 36, 170);
            btnDoctorServiceReport.FlatStyle = FlatStyle.Flat;
            btnDoctorServiceReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDoctorServiceReport.ForeColor = Color.White;
            btnDoctorServiceReport.Location = new Point(23, 18);
            btnDoctorServiceReport.Name = "btnDoctorServiceReport";
            btnDoctorServiceReport.Size = new Size(200, 45);
            btnDoctorServiceReport.TabIndex = 4;
            btnDoctorServiceReport.Text = "📋 Doctor Service Report";
            btnDoctorServiceReport.UseVisualStyleBackColor = false;
            btnDoctorServiceReport.Click += BtnDoctorServiceReport_Click;
            // 
            // btnCreateBill
            // 
            btnCreateBill.BackColor = Color.FromArgb(46, 204, 113);
            btnCreateBill.Cursor = Cursors.Hand;
            btnCreateBill.FlatAppearance.BorderSize = 0;
            btnCreateBill.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 174, 96);
            btnCreateBill.FlatStyle = FlatStyle.Flat;
            btnCreateBill.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateBill.ForeColor = Color.White;
            btnCreateBill.Location = new Point(229, 18);
            btnCreateBill.Name = "btnCreateBill";
            btnCreateBill.Size = new Size(130, 45);
            btnCreateBill.TabIndex = 5;
            btnCreateBill.Text = "➕ Create Bill";
            btnCreateBill.UseVisualStyleBackColor = false;
            btnCreateBill.Click += BtnCreateBill_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(231, 76, 60);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(lblQueueCount);
            panelHeader.Controls.Add(panelUniversalSearch);
            panelHeader.Controls.Add(lblHospitalName);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1204, 70);
            panelHeader.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 41);
            label1.Name = "label1";
            label1.Size = new Size(157, 19);
            label1.TabIndex = 7;
            label1.Text = "Hospital Management\r\n";
            // 
            // lblQueueCount
            // 
            lblQueueCount.AutoSize = true;
            lblQueueCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQueueCount.ForeColor = Color.White;
            lblQueueCount.Location = new Point(989, 29);
            lblQueueCount.Name = "lblQueueCount";
            lblQueueCount.Size = new Size(121, 19);
            lblQueueCount.TabIndex = 6;
            lblQueueCount.Text = "Total in Queue: 0";
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
            txtUniversalSearch.PlaceholderText = "Search queue, patients, billing...";
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
            lblHospitalName.Location = new Point(6, 9);
            lblHospitalName.Name = "lblHospitalName";
            lblHospitalName.Size = new Size(247, 32);
            lblHospitalName.TabIndex = 0;
            lblHospitalName.Text = "St. Joseph's Hospital";
            // 
            // ReceptionistDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(1484, 761);
            Controls.Add(panelMainContent);
            Controls.Add(panelSidebar);
            MinimumSize = new Size(1200, 700);
            Name = "ReceptionistDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "St. Joseph's Hospital - Receptionist Dashboard";
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProfile).EndInit();
            panelMainContent.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabQueue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQueue).EndInit();
            panelQueueButtons.ResumeLayout(false);
            tabPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            panelPatientButtons.ResumeLayout(false);
            tabBilling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBilling).EndInit();
            panelBillingButtons.ResumeLayout(false);
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

            chkSearchQueue = new CheckBox();
            chkSearchQueue.Text = "👥 Queue";
            chkSearchQueue.Checked = true;
            chkSearchQueue.Font = new Font("Segoe UI", 9F);
            chkSearchQueue.Location = new Point(15, 10);
            chkSearchQueue.AutoSize = true;
            chkSearchQueue.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchPatients = new CheckBox();
            chkSearchPatients.Text = "📋 Patients";
            chkSearchPatients.Checked = true;
            chkSearchPatients.Font = new Font("Segoe UI", 9F);
            chkSearchPatients.Location = new Point(130, 10);
            chkSearchPatients.AutoSize = true;
            chkSearchPatients.CheckedChanged += (s, e) => RefreshSearchResults();

            chkSearchBilling = new CheckBox();
            chkSearchBilling.Text = "💰 Billing";
            chkSearchBilling.Checked = true;
            chkSearchBilling.Font = new Font("Segoe UI", 9F);
            chkSearchBilling.Location = new Point(260, 10);
            chkSearchBilling.AutoSize = true;
            chkSearchBilling.CheckedChanged += (s, e) => RefreshSearchResults();

            panelSearchCategories.Controls.AddRange(new Control[] {
                chkSearchQueue, chkSearchPatients, chkSearchBilling
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
                using (SolidBrush highlightBrush = new SolidBrush(Color.FromArgb(231, 76, 60)))
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
        private Label label1;
        private Button btnRemoveAllFromQueue;
        private Button btnEditPatient;
        private Button BtnViewProfile;
        private Button BtnCancelBill;
    }
}