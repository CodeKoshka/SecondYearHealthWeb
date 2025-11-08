namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ReceptionistDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabQueue;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblQueueCount;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.Button btnAssignDoctor;
        private System.Windows.Forms.Button btnCallNext;
        private System.Windows.Forms.Button btnRemoveFromQueue;
        private System.Windows.Forms.Button btnRefreshQueue;
        private System.Windows.Forms.Button btnViewPatient;
        private System.Windows.Forms.Button btnEditPatient;
        private System.Windows.Forms.Button btnRefreshPatients;
        private System.Windows.Forms.Button btnCheckMedicalHistory;

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
            panelHeader = new Panel();
            lblWelcome = new Label();
            btnLogout = new Button();
            tabControl = new TabControl();
            tabQueue = new TabPage();
            BtnAddPatient = new Button();
            lblQueueCount = new Label();
            btnAddToQueue = new Button();
            btnAssignDoctor = new Button();
            btnCallNext = new Button();
            btnRemoveFromQueue = new Button();
            btnRefreshQueue = new Button();
            dgvQueue = new DataGridView();
            tabPatients = new TabPage();
            btnCheckMedicalHistory = new Button(); // NEW
            btnViewPatient = new Button();
            btnEditPatient = new Button();
            btnRefreshPatients = new Button();
            dgvPatients = new DataGridView();
            panelHeader.SuspendLayout();
            tabControl.SuspendLayout();
            tabQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            tabPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(142, 68, 173);
            panelHeader.Controls.Add(lblWelcome);
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 3, 4, 3);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1400, 92);
            panelHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(35, 29);
            lblWelcome.Margin = new Padding(4, 0, 4, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(248, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Receptionist";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1225, 23);
            btnLogout.Margin = new Padding(4, 3, 4, 3);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 46);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabQueue);
            tabControl.Controls.Add(tabPatients);
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(23, 115);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1330, 623);
            tabControl.TabIndex = 1;
            // 
            // tabQueue
            // 
            tabQueue.Controls.Add(BtnAddPatient);
            tabQueue.Controls.Add(lblQueueCount);
            tabQueue.Controls.Add(btnAddToQueue);
            tabQueue.Controls.Add(btnAssignDoctor);
            tabQueue.Controls.Add(btnCallNext);
            tabQueue.Controls.Add(btnRemoveFromQueue);
            tabQueue.Controls.Add(btnRefreshQueue);
            tabQueue.Controls.Add(dgvQueue);
            tabQueue.Location = new Point(4, 26);
            tabQueue.Margin = new Padding(4, 3, 4, 3);
            tabQueue.Name = "tabQueue";
            tabQueue.Padding = new Padding(4, 3, 4, 3);
            tabQueue.Size = new Size(1322, 593);
            tabQueue.TabIndex = 0;
            tabQueue.Text = "Patient Queue";
            tabQueue.UseVisualStyleBackColor = true;
            // 
            // BtnAddPatient
            // 
            BtnAddPatient.BackColor = Color.FromArgb(52, 152, 219);
            BtnAddPatient.Cursor = Cursors.Hand;
            BtnAddPatient.FlatAppearance.BorderSize = 0;
            BtnAddPatient.FlatStyle = FlatStyle.Flat;
            BtnAddPatient.ForeColor = Color.White;
            BtnAddPatient.Location = new Point(533, 12);
            BtnAddPatient.Margin = new Padding(4, 3, 4, 3);
            BtnAddPatient.Name = "BtnAddPatient";
            BtnAddPatient.Size = new Size(167, 40);
            BtnAddPatient.TabIndex = 7;
            BtnAddPatient.Text = "Add Patient";
            BtnAddPatient.UseVisualStyleBackColor = false;
            BtnAddPatient.Click += BtnAddPatient_Click;
            // 
            // lblQueueCount
            // 
            lblQueueCount.AutoSize = true;
            lblQueueCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQueueCount.ForeColor = Color.FromArgb(142, 68, 173);
            lblQueueCount.Location = new Point(1050, 21);
            lblQueueCount.Margin = new Padding(4, 0, 4, 0);
            lblQueueCount.Name = "lblQueueCount";
            lblQueueCount.Size = new Size(166, 19);
            lblQueueCount.TabIndex = 6;
            lblQueueCount.Text = "Total in Queue Today: 0";
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.BackColor = Color.FromArgb(46, 204, 113);
            btnAddToQueue.Cursor = Cursors.Hand;
            btnAddToQueue.FlatAppearance.BorderSize = 0;
            btnAddToQueue.FlatStyle = FlatStyle.Flat;
            btnAddToQueue.ForeColor = Color.White;
            btnAddToQueue.Location = new Point(12, 12);
            btnAddToQueue.Margin = new Padding(4, 3, 4, 3);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(163, 40);
            btnAddToQueue.TabIndex = 0;
            btnAddToQueue.Text = "Add to Queue";
            btnAddToQueue.UseVisualStyleBackColor = false;
            btnAddToQueue.Click += BtnAddToQueue_Click;
            // 
            // btnAssignDoctor
            // 
            btnAssignDoctor.BackColor = Color.FromArgb(52, 152, 219);
            btnAssignDoctor.Cursor = Cursors.Hand;
            btnAssignDoctor.FlatAppearance.BorderSize = 0;
            btnAssignDoctor.FlatStyle = FlatStyle.Flat;
            btnAssignDoctor.ForeColor = Color.White;
            btnAssignDoctor.Location = new Point(187, 12);
            btnAssignDoctor.Margin = new Padding(4, 3, 4, 3);
            btnAssignDoctor.Name = "btnAssignDoctor";
            btnAssignDoctor.Size = new Size(163, 40);
            btnAssignDoctor.TabIndex = 1;
            btnAssignDoctor.Text = "Assign Doctor";
            btnAssignDoctor.UseVisualStyleBackColor = false;
            btnAssignDoctor.Click += BtnAssignDoctor_Click;
            // 
            // btnCallNext
            // 
            btnCallNext.BackColor = Color.FromArgb(241, 196, 15);
            btnCallNext.Cursor = Cursors.Hand;
            btnCallNext.FlatAppearance.BorderSize = 0;
            btnCallNext.FlatStyle = FlatStyle.Flat;
            btnCallNext.ForeColor = Color.White;
            btnCallNext.Location = new Point(362, 12);
            btnCallNext.Margin = new Padding(4, 3, 4, 3);
            btnCallNext.Name = "btnCallNext";
            btnCallNext.Size = new Size(163, 40);
            btnCallNext.TabIndex = 2;
            btnCallNext.Text = "Call Patient";
            btnCallNext.UseVisualStyleBackColor = false;
            btnCallNext.Click += BtnCallNext_Click;
            // 
            // btnRemoveFromQueue
            // 
            btnRemoveFromQueue.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveFromQueue.Cursor = Cursors.Hand;
            btnRemoveFromQueue.FlatAppearance.BorderSize = 0;
            btnRemoveFromQueue.FlatStyle = FlatStyle.Flat;
            btnRemoveFromQueue.ForeColor = Color.White;
            btnRemoveFromQueue.Location = new Point(708, 12);
            btnRemoveFromQueue.Margin = new Padding(4, 3, 4, 3);
            btnRemoveFromQueue.Name = "btnRemoveFromQueue";
            btnRemoveFromQueue.Size = new Size(163, 40);
            btnRemoveFromQueue.TabIndex = 3;
            btnRemoveFromQueue.Text = "Remove";
            btnRemoveFromQueue.UseVisualStyleBackColor = false;
            btnRemoveFromQueue.Click += BtnRemoveFromQueue_Click;
            // 
            // btnRefreshQueue
            // 
            btnRefreshQueue.BackColor = Color.FromArgb(149, 165, 166);
            btnRefreshQueue.Cursor = Cursors.Hand;
            btnRefreshQueue.FlatAppearance.BorderSize = 0;
            btnRefreshQueue.FlatStyle = FlatStyle.Flat;
            btnRefreshQueue.ForeColor = Color.White;
            btnRefreshQueue.Location = new Point(879, 12);
            btnRefreshQueue.Margin = new Padding(4, 3, 4, 3);
            btnRefreshQueue.Name = "btnRefreshQueue";
            btnRefreshQueue.Size = new Size(128, 40);
            btnRefreshQueue.TabIndex = 4;
            btnRefreshQueue.Text = "Refresh";
            btnRefreshQueue.UseVisualStyleBackColor = false;
            btnRefreshQueue.Click += BtnRefresh_Click;
            // 
            // dgvQueue
            // 
            dgvQueue.AllowUserToAddRows = false;
            dgvQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvQueue.BackgroundColor = Color.White;
            dgvQueue.BorderStyle = BorderStyle.None;
            dgvQueue.Location = new Point(12, 69);
            dgvQueue.Margin = new Padding(4, 3, 4, 3);
            dgvQueue.Name = "dgvQueue";
            dgvQueue.ReadOnly = true;
            dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQueue.Size = new Size(1283, 496);
            dgvQueue.TabIndex = 5;
            // 
            // tabPatients
            // 
            tabPatients.Controls.Add(btnCheckMedicalHistory); // NEW
            tabPatients.Controls.Add(btnViewPatient);
            tabPatients.Controls.Add(btnEditPatient);
            tabPatients.Controls.Add(btnRefreshPatients);
            tabPatients.Controls.Add(dgvPatients);
            tabPatients.Location = new Point(4, 26);
            tabPatients.Margin = new Padding(4, 3, 4, 3);
            tabPatients.Name = "tabPatients";
            tabPatients.Padding = new Padding(4, 3, 4, 3);
            tabPatients.Size = new Size(1322, 593);
            tabPatients.TabIndex = 1;
            tabPatients.Text = "Patient Records";
            tabPatients.UseVisualStyleBackColor = true;
            // 
            // btnCheckMedicalHistory
            // 
            btnCheckMedicalHistory.BackColor = Color.FromArgb(156, 39, 176);
            btnCheckMedicalHistory.Cursor = Cursors.Hand;
            btnCheckMedicalHistory.FlatAppearance.BorderSize = 0;
            btnCheckMedicalHistory.FlatStyle = FlatStyle.Flat;
            btnCheckMedicalHistory.ForeColor = Color.White;
            btnCheckMedicalHistory.Location = new Point(362, 12);
            btnCheckMedicalHistory.Margin = new Padding(4, 3, 4, 3);
            btnCheckMedicalHistory.Name = "btnCheckMedicalHistory";
            btnCheckMedicalHistory.Size = new Size(190, 40);
            btnCheckMedicalHistory.TabIndex = 4;
            btnCheckMedicalHistory.Text = "📋 Medical History";
            btnCheckMedicalHistory.UseVisualStyleBackColor = false;
            btnCheckMedicalHistory.Click += BtnCheckMedicalHistory_Click;
            // 
            // btnViewPatient
            // 
            btnViewPatient.BackColor = Color.FromArgb(52, 152, 219);
            btnViewPatient.Cursor = Cursors.Hand;
            btnViewPatient.FlatAppearance.BorderSize = 0;
            btnViewPatient.FlatStyle = FlatStyle.Flat;
            btnViewPatient.ForeColor = Color.White;
            btnViewPatient.Location = new Point(12, 12);
            btnViewPatient.Margin = new Padding(4, 3, 4, 3);
            btnViewPatient.Name = "btnViewPatient";
            btnViewPatient.Size = new Size(163, 40);
            btnViewPatient.TabIndex = 0;
            btnViewPatient.Text = "👁 View Details";
            btnViewPatient.UseVisualStyleBackColor = false;
            btnViewPatient.Click += BtnViewPatient_Click;
            // 
            // btnEditPatient
            // 
            btnEditPatient.BackColor = Color.FromArgb(255, 152, 0);
            btnEditPatient.Cursor = Cursors.Hand;
            btnEditPatient.FlatAppearance.BorderSize = 0;
            btnEditPatient.FlatStyle = FlatStyle.Flat;
            btnEditPatient.ForeColor = Color.White;
            btnEditPatient.Location = new Point(187, 12);
            btnEditPatient.Margin = new Padding(4, 3, 4, 3);
            btnEditPatient.Name = "btnEditPatient";
            btnEditPatient.Size = new Size(163, 40);
            btnEditPatient.TabIndex = 1;
            btnEditPatient.Text = "✏ Edit Details";
            btnEditPatient.UseVisualStyleBackColor = false;
            btnEditPatient.Click += BtnEditPatient_Click;
            // 
            // btnRefreshPatients
            // 
            btnRefreshPatients.BackColor = Color.FromArgb(149, 165, 166);
            btnRefreshPatients.Cursor = Cursors.Hand;
            btnRefreshPatients.FlatAppearance.BorderSize = 0;
            btnRefreshPatients.FlatStyle = FlatStyle.Flat;
            btnRefreshPatients.ForeColor = Color.White;
            btnRefreshPatients.Location = new Point(565, 12);
            btnRefreshPatients.Margin = new Padding(4, 3, 4, 3);
            btnRefreshPatients.Name = "btnRefreshPatients";
            btnRefreshPatients.Size = new Size(128, 40);
            btnRefreshPatients.TabIndex = 2;
            btnRefreshPatients.Text = "Refresh";
            btnRefreshPatients.UseVisualStyleBackColor = false;
            btnRefreshPatients.Click += BtnRefresh_Click;
            // 
            // dgvPatients
            // 
            dgvPatients.AllowUserToAddRows = false;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.BackgroundColor = Color.White;
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.Location = new Point(12, 69);
            dgvPatients.Margin = new Padding(4, 3, 4, 3);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(1283, 496);
            dgvPatients.TabIndex = 3;
            // 
            // ReceptionistDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1381, 763);
            Controls.Add(tabControl);
            Controls.Add(panelHeader);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ReceptionistDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hospital Management System - Receptionist Dashboard";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl.ResumeLayout(false);
            tabQueue.ResumeLayout(false);
            tabQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).EndInit();
            tabPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ResumeLayout(false);
        }
        private Button BtnAddPatient;
    }
}