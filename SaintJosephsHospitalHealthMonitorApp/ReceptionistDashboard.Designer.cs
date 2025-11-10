namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ReceptionistDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabQueue;
        private System.Windows.Forms.TabPage tabPatients;
        private System.Windows.Forms.TabPage tabBilling;
        private System.Windows.Forms.DataGridView dgvQueue;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridView dgvBilling;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblQueueCount;
        private System.Windows.Forms.Label lblBillingStats;
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
        private System.Windows.Forms.Button btnViewBill;
        private System.Windows.Forms.Button btnUpdateBill;
        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnDischargePatient;
        private System.Windows.Forms.Button btnRefreshBills;
        private System.Windows.Forms.Button BtnAddPatient;

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
            btnCheckMedicalHistory = new Button();
            btnViewPatient = new Button();
            btnEditPatient = new Button();
            btnRefreshPatients = new Button();
            dgvPatients = new DataGridView();
            tabBilling = new TabPage();
            lblBillingStats = new Label();
            btnDischargePatient = new Button();
            btnProcessPayment = new Button();
            btnUpdateBill = new Button();
            btnViewBill = new Button();
            btnRefreshBills = new Button();
            dgvBilling = new DataGridView();
            panelHeader.SuspendLayout();
            tabControl.SuspendLayout();
            tabQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQueue).BeginInit();
            tabPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            tabBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(142, 68, 173);
            panelHeader.Controls.Add(lblWelcome);
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Location = new Point(0, 0);
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
            tabControl.Controls.Add(tabBilling);  
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(23, 115);
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
            dgvQueue.Name = "dgvQueue";
            dgvQueue.ReadOnly = true;
            dgvQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQueue.Size = new Size(1283, 496);
            dgvQueue.TabIndex = 5;
            // 
            // tabPatients
            // 
            tabPatients.Controls.Add(btnCheckMedicalHistory);
            tabPatients.Controls.Add(btnViewPatient);
            tabPatients.Controls.Add(btnEditPatient);
            tabPatients.Controls.Add(btnRefreshPatients);
            tabPatients.Controls.Add(dgvPatients);
            tabPatients.Location = new Point(4, 26);
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
            dgvPatients.Name = "dgvPatients";
            dgvPatients.ReadOnly = true;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.Size = new Size(1283, 496);
            dgvPatients.TabIndex = 3;
            // 
            // tabBilling
            // 
            tabBilling.Controls.Add(lblBillingStats);  
            tabBilling.Controls.Add(btnDischargePatient);
            tabBilling.Controls.Add(btnProcessPayment);
            tabBilling.Controls.Add(btnUpdateBill);
            tabBilling.Controls.Add(btnViewBill);
            tabBilling.Controls.Add(btnRefreshBills);
            tabBilling.Controls.Add(dgvBilling);  
            tabBilling.Location = new Point(4, 26);
            tabBilling.Name = "tabBilling";  
            tabBilling.Padding = new Padding(4, 3, 4, 3);
            tabBilling.Size = new Size(1322, 593);
            tabBilling.TabIndex = 2;
            tabBilling.Text = "💰 Billing";  // CHANGED TEXT
            tabBilling.UseVisualStyleBackColor = true;
            // 
            // lblBillingStats
            // 
            lblBillingStats.AutoSize = true;
            lblBillingStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBillingStats.ForeColor = Color.FromArgb(231, 76, 60);
            lblBillingStats.Location = new Point(950, 21);
            lblBillingStats.Name = "lblBillingStats";  
            lblBillingStats.Size = new Size(240, 19);
            lblBillingStats.TabIndex = 6;
            lblBillingStats.Text = "Unpaid Bills: 0 | Total: ₱0.00";
            // 
            // btnDischargePatient
            // 
            btnDischargePatient.BackColor = Color.FromArgb(46, 204, 113);
            btnDischargePatient.Cursor = Cursors.Hand;
            btnDischargePatient.FlatAppearance.BorderSize = 0;
            btnDischargePatient.FlatStyle = FlatStyle.Flat;
            btnDischargePatient.ForeColor = Color.White;
            btnDischargePatient.Location = new Point(563, 12);
            btnDischargePatient.Name = "btnDischargePatient";
            btnDischargePatient.Size = new Size(170, 40);
            btnDischargePatient.TabIndex = 5;
            btnDischargePatient.Text = "🚪 Discharge Patient";
            btnDischargePatient.UseVisualStyleBackColor = false;
            btnDischargePatient.Click += BtnDischargePatient_Click;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.BackColor = Color.FromArgb(52, 152, 219);
            btnProcessPayment.Cursor = Cursors.Hand;
            btnProcessPayment.FlatAppearance.BorderSize = 0;
            btnProcessPayment.FlatStyle = FlatStyle.Flat;
            btnProcessPayment.ForeColor = Color.White;
            btnProcessPayment.Location = new Point(378, 12);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(170, 40);
            btnProcessPayment.TabIndex = 4;
            btnProcessPayment.Text = "💳 Process Payment";
            btnProcessPayment.UseVisualStyleBackColor = false;
            btnProcessPayment.Click += BtnProcessPayment_Click;
            // 
            // btnUpdateBill
            // 
            btnUpdateBill.BackColor = Color.FromArgb(243, 156, 18);
            btnUpdateBill.Cursor = Cursors.Hand;
            btnUpdateBill.FlatAppearance.BorderSize = 0;
            btnUpdateBill.FlatStyle = FlatStyle.Flat;
            btnUpdateBill.ForeColor = Color.White;
            btnUpdateBill.Location = new Point(193, 12);
            btnUpdateBill.Name = "btnUpdateBill";
            btnUpdateBill.Size = new Size(170, 40);
            btnUpdateBill.TabIndex = 3;
            btnUpdateBill.Text = "✏️ Update Bill";
            btnUpdateBill.UseVisualStyleBackColor = false;
            btnUpdateBill.Click += BtnUpdateBill_Click;
            // 
            // btnViewBill
            // 
            btnViewBill.BackColor = Color.FromArgb(149, 165, 166);
            btnViewBill.Cursor = Cursors.Hand;
            btnViewBill.FlatAppearance.BorderSize = 0;
            btnViewBill.FlatStyle = FlatStyle.Flat;
            btnViewBill.ForeColor = Color.White;
            btnViewBill.Location = new Point(12, 12);
            btnViewBill.Name = "btnViewBill";
            btnViewBill.Size = new Size(170, 40);
            btnViewBill.TabIndex = 2;
            btnViewBill.Text = "👁️ View Bill";
            btnViewBill.UseVisualStyleBackColor = false;
            btnViewBill.Click += BtnViewBill_Click;
            // 
            // btnRefreshBills
            // 
            btnRefreshBills.BackColor = Color.FromArgb(149, 165, 166);
            btnRefreshBills.Cursor = Cursors.Hand;
            btnRefreshBills.FlatAppearance.BorderSize = 0;
            btnRefreshBills.FlatStyle = FlatStyle.Flat;
            btnRefreshBills.ForeColor = Color.White;
            btnRefreshBills.Location = new Point(748, 12);
            btnRefreshBills.Name = "btnRefreshBills";
            btnRefreshBills.Size = new Size(128, 40);
            btnRefreshBills.TabIndex = 1;
            btnRefreshBills.Text = "🔄 Refresh";
            btnRefreshBills.UseVisualStyleBackColor = false;
            btnRefreshBills.Click += BtnRefresh_Click;
            // 
            // dgvBilling
            // 
            dgvBilling.AllowUserToAddRows = false;
            dgvBilling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilling.BackgroundColor = Color.White;
            dgvBilling.BorderStyle = BorderStyle.None;
            dgvBilling.Location = new Point(12, 69);
            dgvBilling.Name = "dgvBilling";
            dgvBilling.ReadOnly = true;
            dgvBilling.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilling.Size = new Size(1283, 496);
            dgvBilling.TabIndex = 0;
            // 
            // ReceptionistDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(1381, 763);
            Controls.Add(tabControl);
            Controls.Add(panelHeader);
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
            tabBilling.ResumeLayout(false);
            tabBilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBilling).EndInit();
            ResumeLayout(false);
        }
    }
}