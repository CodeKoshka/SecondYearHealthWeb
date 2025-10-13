namespace SaintJosephsHospitalHealthMonitorApp
{
        partial class AdminDashboard
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
            private System.Windows.Forms.TabControl tabControl;
            private System.Windows.Forms.TabPage tabUsers;
            private System.Windows.Forms.TabPage tabAppointments;
            private System.Windows.Forms.TabPage tabBilling;
            private System.Windows.Forms.DataGridView dgvUsers;
            private System.Windows.Forms.DataGridView dgvAppointments;
            private System.Windows.Forms.DataGridView dgvBilling;
            private System.Windows.Forms.Panel panelHeader;
            private System.Windows.Forms.Label lblWelcome;
            private System.Windows.Forms.Button btnLogout;
            private System.Windows.Forms.Button btnAddUser;
            private System.Windows.Forms.Button btnEditUser;
            private System.Windows.Forms.Button btnDeleteUser;
            private System.Windows.Forms.Button btnRefreshUsers;
            private System.Windows.Forms.Button btnAddAppointment;
            private System.Windows.Forms.Button btnEditAppointment;
            private System.Windows.Forms.Button btnDeleteAppointment;
            private System.Windows.Forms.Button btnRefreshAppointments;
            private System.Windows.Forms.Button btnAddBill;
            private System.Windows.Forms.Button btnUpdateBill;
            private System.Windows.Forms.Button btnRefreshBilling;

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
                this.panelHeader = new System.Windows.Forms.Panel();
                this.lblWelcome = new System.Windows.Forms.Label();
                this.btnLogout = new System.Windows.Forms.Button();
                this.tabControl = new System.Windows.Forms.TabControl();
                this.tabUsers = new System.Windows.Forms.TabPage();
                this.btnAddUser = new System.Windows.Forms.Button();
                this.btnEditUser = new System.Windows.Forms.Button();
                this.btnDeleteUser = new System.Windows.Forms.Button();
                this.btnRefreshUsers = new System.Windows.Forms.Button();
                this.dgvUsers = new System.Windows.Forms.DataGridView();
                this.tabAppointments = new System.Windows.Forms.TabPage();
                this.btnAddAppointment = new System.Windows.Forms.Button();
                this.btnEditAppointment = new System.Windows.Forms.Button();
                this.btnDeleteAppointment = new System.Windows.Forms.Button();
                this.btnRefreshAppointments = new System.Windows.Forms.Button();
                this.dgvAppointments = new System.Windows.Forms.DataGridView();
                this.tabBilling = new System.Windows.Forms.TabPage();
                this.btnAddBill = new System.Windows.Forms.Button();
                this.btnUpdateBill = new System.Windows.Forms.Button();
                this.btnRefreshBilling = new System.Windows.Forms.Button();
                this.dgvBilling = new System.Windows.Forms.DataGridView();
                this.panelHeader.SuspendLayout();
                this.tabControl.SuspendLayout();
                this.tabUsers.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
                this.tabAppointments.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
                this.tabBilling.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).BeginInit();
                this.SuspendLayout();
                // 
                // panelHeader
                // 
                this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
                this.panelHeader.Controls.Add(this.lblWelcome);
                this.panelHeader.Controls.Add(this.btnLogout);
                this.panelHeader.Location = new System.Drawing.Point(0, 0);
                this.panelHeader.Name = "panelHeader";
                this.panelHeader.Size = new System.Drawing.Size(1200, 80);
                this.panelHeader.TabIndex = 0;
                // 
                // lblWelcome
                // 
                this.lblWelcome.AutoSize = true;
                this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
                this.lblWelcome.ForeColor = System.Drawing.Color.White;
                this.lblWelcome.Location = new System.Drawing.Point(30, 25);
                this.lblWelcome.Name = "lblWelcome";
                this.lblWelcome.Size = new System.Drawing.Size(200, 30);
                this.lblWelcome.TabIndex = 0;
                this.lblWelcome.Text = "Welcome, Admin";
                // 
                // btnLogout
                // 
                this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
                this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnLogout.FlatAppearance.BorderSize = 0;
                this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
                this.btnLogout.ForeColor = System.Drawing.Color.White;
                this.btnLogout.Location = new System.Drawing.Point(1050, 20);
                this.btnLogout.Name = "btnLogout";
                this.btnLogout.Size = new System.Drawing.Size(120, 40);
                this.btnLogout.TabIndex = 1;
                this.btnLogout.Text = "Logout";
                this.btnLogout.UseVisualStyleBackColor = false;
                this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
                // 
                // tabControl
                // 
                this.tabControl.Controls.Add(this.tabUsers);
                this.tabControl.Controls.Add(this.tabAppointments);
                this.tabControl.Controls.Add(this.tabBilling);
                this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
                this.tabControl.Location = new System.Drawing.Point(20, 100);
                this.tabControl.Name = "tabControl";
                this.tabControl.SelectedIndex = 0;
                this.tabControl.Size = new System.Drawing.Size(1140, 540);
                this.tabControl.TabIndex = 1;
                // 
                // tabUsers
                // 
                this.tabUsers.Controls.Add(this.btnAddUser);
                this.tabUsers.Controls.Add(this.btnEditUser);
                this.tabUsers.Controls.Add(this.btnDeleteUser);
                this.tabUsers.Controls.Add(this.btnRefreshUsers);
                this.tabUsers.Controls.Add(this.dgvUsers);
                this.tabUsers.Location = new System.Drawing.Point(4, 26);
                this.tabUsers.Name = "tabUsers";
                this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
                this.tabUsers.Size = new System.Drawing.Size(1132, 510);
                this.tabUsers.TabIndex = 0;
                this.tabUsers.Text = "User Management";
                this.tabUsers.UseVisualStyleBackColor = true;
                // 
                // btnAddUser
                // 
                this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnAddUser.FlatAppearance.BorderSize = 0;
                this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnAddUser.ForeColor = System.Drawing.Color.White;
                this.btnAddUser.Location = new System.Drawing.Point(10, 10);
                this.btnAddUser.Name = "btnAddUser";
                this.btnAddUser.Size = new System.Drawing.Size(110, 35);
                this.btnAddUser.TabIndex = 0;
                this.btnAddUser.Text = "Add User";
                this.btnAddUser.UseVisualStyleBackColor = false;
                this.btnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
                // 
                // btnEditUser
                // 
                this.btnEditUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnEditUser.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnEditUser.FlatAppearance.BorderSize = 0;
                this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnEditUser.ForeColor = System.Drawing.Color.White;
                this.btnEditUser.Location = new System.Drawing.Point(130, 10);
                this.btnEditUser.Name = "btnEditUser";
                this.btnEditUser.Size = new System.Drawing.Size(110, 35);
                this.btnEditUser.TabIndex = 1;
                this.btnEditUser.Text = "Edit User";
                this.btnEditUser.UseVisualStyleBackColor = false;
                this.btnEditUser.Click += new System.EventHandler(this.BtnEditUser_Click);
                // 
                // btnDeleteUser
                // 
                this.btnDeleteUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnDeleteUser.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnDeleteUser.FlatAppearance.BorderSize = 0;
                this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
                this.btnDeleteUser.Location = new System.Drawing.Point(250, 10);
                this.btnDeleteUser.Name = "btnDeleteUser";
                this.btnDeleteUser.Size = new System.Drawing.Size(110, 35);
                this.btnDeleteUser.TabIndex = 2;
                this.btnDeleteUser.Text = "Delete User";
                this.btnDeleteUser.UseVisualStyleBackColor = false;
                this.btnDeleteUser.Click += new System.EventHandler(this.BtnDeleteUser_Click);
                // 
                // btnRefreshUsers
                // 
                this.btnRefreshUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnRefreshUsers.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnRefreshUsers.FlatAppearance.BorderSize = 0;
                this.btnRefreshUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnRefreshUsers.ForeColor = System.Drawing.Color.White;
                this.btnRefreshUsers.Location = new System.Drawing.Point(370, 10);
                this.btnRefreshUsers.Name = "btnRefreshUsers";
                this.btnRefreshUsers.Size = new System.Drawing.Size(110, 35);
                this.btnRefreshUsers.TabIndex = 3;
                this.btnRefreshUsers.Text = "Refresh";
                this.btnRefreshUsers.UseVisualStyleBackColor = false;
                this.btnRefreshUsers.Click += new System.EventHandler(this.BtnRefresh_Click);
                // 
                // dgvUsers
                // 
                this.dgvUsers.AllowUserToAddRows = false;
                this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
                this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.dgvUsers.Location = new System.Drawing.Point(10, 60);
                this.dgvUsers.Name = "dgvUsers";
                this.dgvUsers.ReadOnly = true;
                this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dgvUsers.Size = new System.Drawing.Size(1100, 430);
                this.dgvUsers.TabIndex = 4;
                // 
                // tabAppointments
                // 
                this.tabAppointments.Controls.Add(this.btnAddAppointment);
                this.tabAppointments.Controls.Add(this.btnEditAppointment);
                this.tabAppointments.Controls.Add(this.btnDeleteAppointment);
                this.tabAppointments.Controls.Add(this.btnRefreshAppointments);
                this.tabAppointments.Controls.Add(this.dgvAppointments);
                this.tabAppointments.Location = new System.Drawing.Point(4, 26);
                this.tabAppointments.Name = "tabAppointments";
                this.tabAppointments.Padding = new System.Windows.Forms.Padding(3);
                this.tabAppointments.Size = new System.Drawing.Size(1132, 510);
                this.tabAppointments.TabIndex = 1;
                this.tabAppointments.Text = "Appointments";
                this.tabAppointments.UseVisualStyleBackColor = true;
                // 
                // btnAddAppointment
                // 
                this.btnAddAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnAddAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnAddAppointment.FlatAppearance.BorderSize = 0;
                this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
                this.btnAddAppointment.Location = new System.Drawing.Point(10, 10);
                this.btnAddAppointment.Name = "btnAddAppointment";
                this.btnAddAppointment.Size = new System.Drawing.Size(160, 35);
                this.btnAddAppointment.TabIndex = 0;
                this.btnAddAppointment.Text = "Schedule Appointment";
                this.btnAddAppointment.UseVisualStyleBackColor = false;
                this.btnAddAppointment.Click += new System.EventHandler(this.BtnAddAppointment_Click);
                // 
                // btnEditAppointment
                // 
                this.btnEditAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnEditAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnEditAppointment.FlatAppearance.BorderSize = 0;
                this.btnEditAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnEditAppointment.ForeColor = System.Drawing.Color.White;
                this.btnEditAppointment.Location = new System.Drawing.Point(180, 10);
                this.btnEditAppointment.Name = "btnEditAppointment";
                this.btnEditAppointment.Size = new System.Drawing.Size(130, 35);
                this.btnEditAppointment.TabIndex = 1;
                this.btnEditAppointment.Text = "Update Status";
                this.btnEditAppointment.UseVisualStyleBackColor = false;
                this.btnEditAppointment.Click += new System.EventHandler(this.BtnEditAppointment_Click);
                // 
                // btnDeleteAppointment
                // 
                this.btnDeleteAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnDeleteAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnDeleteAppointment.FlatAppearance.BorderSize = 0;
                this.btnDeleteAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnDeleteAppointment.ForeColor = System.Drawing.Color.White;
                this.btnDeleteAppointment.Location = new System.Drawing.Point(320, 10);
                this.btnDeleteAppointment.Name = "btnDeleteAppointment";
                this.btnDeleteAppointment.Size = new System.Drawing.Size(160, 35);
                this.btnDeleteAppointment.TabIndex = 2;
                this.btnDeleteAppointment.Text = "Cancel Appointment";
                this.btnDeleteAppointment.UseVisualStyleBackColor = false;
                this.btnDeleteAppointment.Click += new System.EventHandler(this.BtnDeleteAppointment_Click);
                // 
                // btnRefreshAppointments
                // 
                this.btnRefreshAppointments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnRefreshAppointments.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnRefreshAppointments.FlatAppearance.BorderSize = 0;
                this.btnRefreshAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnRefreshAppointments.ForeColor = System.Drawing.Color.White;
                this.btnRefreshAppointments.Location = new System.Drawing.Point(490, 10);
                this.btnRefreshAppointments.Name = "btnRefreshAppointments";
                this.btnRefreshAppointments.Size = new System.Drawing.Size(110, 35);
                this.btnRefreshAppointments.TabIndex = 3;
                this.btnRefreshAppointments.Text = "Refresh";
                this.btnRefreshAppointments.UseVisualStyleBackColor = false;
                this.btnRefreshAppointments.Click += new System.EventHandler(this.BtnRefresh_Click);
                // 
                // dgvAppointments
                // 
                this.dgvAppointments.AllowUserToAddRows = false;
                this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvAppointments.BackgroundColor = System.Drawing.Color.White;
                this.dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.dgvAppointments.Location = new System.Drawing.Point(10, 60);
                this.dgvAppointments.Name = "dgvAppointments";
                this.dgvAppointments.ReadOnly = true;
                this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dgvAppointments.Size = new System.Drawing.Size(1100, 430);
                this.dgvAppointments.TabIndex = 4;
                // 
                // tabBilling
                // 
                this.tabBilling.Controls.Add(this.btnAddBill);
                this.tabBilling.Controls.Add(this.btnUpdateBill);
                this.tabBilling.Controls.Add(this.btnRefreshBilling);
                this.tabBilling.Controls.Add(this.dgvBilling);
                this.tabBilling.Location = new System.Drawing.Point(4, 26);
                this.tabBilling.Name = "tabBilling";
                this.tabBilling.Padding = new System.Windows.Forms.Padding(3);
                this.tabBilling.Size = new System.Drawing.Size(1132, 510);
                this.tabBilling.TabIndex = 2;
                this.tabBilling.Text = "Billing & Payments";
                this.tabBilling.UseVisualStyleBackColor = true;
                // 
                // btnAddBill
                // 
                this.btnAddBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnAddBill.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnAddBill.FlatAppearance.BorderSize = 0;
                this.btnAddBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnAddBill.ForeColor = System.Drawing.Color.White;
                this.btnAddBill.Location = new System.Drawing.Point(10, 10);
                this.btnAddBill.Name = "btnAddBill";
                this.btnAddBill.Size = new System.Drawing.Size(130, 35);
                this.btnAddBill.TabIndex = 0;
                this.btnAddBill.Text = "Create Invoice";
                this.btnAddBill.UseVisualStyleBackColor = false;
                this.btnAddBill.Click += new System.EventHandler(this.BtnAddBill_Click);
                // 
                // btnUpdateBill
                // 
                this.btnUpdateBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnUpdateBill.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnUpdateBill.FlatAppearance.BorderSize = 0;
                this.btnUpdateBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnUpdateBill.ForeColor = System.Drawing.Color.White;
                this.btnUpdateBill.Location = new System.Drawing.Point(150, 10);
                this.btnUpdateBill.Name = "btnUpdateBill";
                this.btnUpdateBill.Size = new System.Drawing.Size(150, 35);
                this.btnUpdateBill.TabIndex = 1;
                this.btnUpdateBill.Text = "Update Payment";
                this.btnUpdateBill.UseVisualStyleBackColor = false;
                this.btnUpdateBill.Click += new System.EventHandler(this.BtnUpdateBill_Click);
                // 
                // btnRefreshBilling
                // 
                this.btnRefreshBilling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
                this.btnRefreshBilling.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnRefreshBilling.FlatAppearance.BorderSize = 0;
                this.btnRefreshBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnRefreshBilling.ForeColor = System.Drawing.Color.White;
                this.btnRefreshBilling.Location = new System.Drawing.Point(310, 10);
                this.btnRefreshBilling.Name = "btnRefreshBilling";
                this.btnRefreshBilling.Size = new System.Drawing.Size(110, 35);
                this.btnRefreshBilling.TabIndex = 2;
                this.btnRefreshBilling.Text = "Refresh";
                this.btnRefreshBilling.UseVisualStyleBackColor = false;
                this.btnRefreshBilling.Click += new System.EventHandler(this.BtnRefresh_Click);
                // 
                // dgvBilling
                // 
                this.dgvBilling.AllowUserToAddRows = false;
                this.dgvBilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dgvBilling.BackgroundColor = System.Drawing.Color.White;
                this.dgvBilling.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.dgvBilling.Location = new System.Drawing.Point(10, 60);
                this.dgvBilling.Name = "dgvBilling";
                this.dgvBilling.ReadOnly = true;
                this.dgvBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dgvBilling.Size = new System.Drawing.Size(1100, 430);
                this.dgvBilling.TabIndex = 3;
                // 
                // AdminDashboard
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
                this.ClientSize = new System.Drawing.Size(1184, 661);
                this.Controls.Add(this.tabControl);
                this.Controls.Add(this.panelHeader);
                this.Name = "AdminDashboard";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Hospital Management System - Admin Dashboard";
                this.panelHeader.ResumeLayout(false);
                this.panelHeader.PerformLayout();
                this.tabControl.ResumeLayout(false);
                this.tabUsers.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
                this.tabAppointments.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
                this.tabBilling.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.dgvBilling)).EndInit();
                this.ResumeLayout(false);
            }
        }
    }