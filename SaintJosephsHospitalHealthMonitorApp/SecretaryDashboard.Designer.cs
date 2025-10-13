namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class SecretaryDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
        private System.Windows.Forms.Button btnRefreshPatients;

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
            this.tabQueue = new System.Windows.Forms.TabPage();
            this.lblQueueCount = new System.Windows.Forms.Label();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.btnAssignDoctor = new System.Windows.Forms.Button();
            this.btnCallNext = new System.Windows.Forms.Button();
            this.btnRemoveFromQueue = new System.Windows.Forms.Button();
            this.btnRefreshQueue = new System.Windows.Forms.Button();
            this.dgvQueue = new System.Windows.Forms.DataGridView();
            this.tabPatients = new System.Windows.Forms.TabPage();
            this.btnViewPatient = new System.Windows.Forms.Button();
            this.btnRefreshPatients = new System.Windows.Forms.Button();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.panelHeader.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).BeginInit();
            this.tabPatients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
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
            this.lblWelcome.Size = new System.Drawing.Size(250, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, Secretary";
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
            this.tabControl.Controls.Add(this.tabQueue);
            this.tabControl.Controls.Add(this.tabPatients);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(20, 100);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1140, 540);
            this.tabControl.TabIndex = 1;
            // 
            // tabQueue
            // 
            this.tabQueue.Controls.Add(this.lblQueueCount);
            this.tabQueue.Controls.Add(this.btnAddToQueue);
            this.tabQueue.Controls.Add(this.btnAssignDoctor);
            this.tabQueue.Controls.Add(this.btnCallNext);
            this.tabQueue.Controls.Add(this.btnRemoveFromQueue);
            this.tabQueue.Controls.Add(this.btnRefreshQueue);
            this.tabQueue.Controls.Add(this.dgvQueue);
            this.tabQueue.Location = new System.Drawing.Point(4, 26);
            this.tabQueue.Name = "tabQueue";
            this.tabQueue.Padding = new System.Windows.Forms.Padding(3);
            this.tabQueue.Size = new System.Drawing.Size(1132, 510);
            this.tabQueue.TabIndex = 0;
            this.tabQueue.Text = "Patient Queue";
            this.tabQueue.UseVisualStyleBackColor = true;
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.AutoSize = true;
            this.lblQueueCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQueueCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblQueueCount.Location = new System.Drawing.Point(900, 18);
            this.lblQueueCount.Name = "lblQueueCount";
            this.lblQueueCount.Size = new System.Drawing.Size(180, 19);
            this.lblQueueCount.TabIndex = 6;
            this.lblQueueCount.Text = "Total in Queue Today: 0";
            // 
            // btnAddToQueue
            // 
            this.btnAddToQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddToQueue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToQueue.FlatAppearance.BorderSize = 0;
            this.btnAddToQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToQueue.ForeColor = System.Drawing.Color.White;
            this.btnAddToQueue.Location = new System.Drawing.Point(10, 10);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(140, 35);
            this.btnAddToQueue.TabIndex = 0;
            this.btnAddToQueue.Text = "Add to Queue";
            this.btnAddToQueue.UseVisualStyleBackColor = false;
            this.btnAddToQueue.Click += new System.EventHandler(this.BtnAddToQueue_Click);
            // 
            // btnAssignDoctor
            // 
            this.btnAssignDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAssignDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignDoctor.FlatAppearance.BorderSize = 0;
            this.btnAssignDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignDoctor.ForeColor = System.Drawing.Color.White;
            this.btnAssignDoctor.Location = new System.Drawing.Point(160, 10);
            this.btnAssignDoctor.Name = "btnAssignDoctor";
            this.btnAssignDoctor.Size = new System.Drawing.Size(140, 35);
            this.btnAssignDoctor.TabIndex = 1;
            this.btnAssignDoctor.Text = "Assign Doctor";
            this.btnAssignDoctor.UseVisualStyleBackColor = false;
            this.btnAssignDoctor.Click += new System.EventHandler(this.BtnAssignDoctor_Click);
            // 
            // btnCallNext
            // 
            this.btnCallNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnCallNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCallNext.FlatAppearance.BorderSize = 0;
            this.btnCallNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallNext.ForeColor = System.Drawing.Color.White;
            this.btnCallNext.Location = new System.Drawing.Point(310, 10);
            this.btnCallNext.Name = "btnCallNext";
            this.btnCallNext.Size = new System.Drawing.Size(140, 35);
            this.btnCallNext.TabIndex = 2;
            this.btnCallNext.Text = "Call Patient";
            this.btnCallNext.UseVisualStyleBackColor = false;
            this.btnCallNext.Click += new System.EventHandler(this.BtnCallNext_Click);
            // 
            // btnRemoveFromQueue
            // 
            this.btnRemoveFromQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveFromQueue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFromQueue.FlatAppearance.BorderSize = 0;
            this.btnRemoveFromQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromQueue.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromQueue.Location = new System.Drawing.Point(460, 10);
            this.btnRemoveFromQueue.Name = "btnRemoveFromQueue";
            this.btnRemoveFromQueue.Size = new System.Drawing.Size(140, 35);
            this.btnRemoveFromQueue.TabIndex = 3;
            this.btnRemoveFromQueue.Text = "Remove";
            this.btnRemoveFromQueue.UseVisualStyleBackColor = false;
            this.btnRemoveFromQueue.Click += new System.EventHandler(this.BtnRemoveFromQueue_Click);
            // 
            // btnRefreshQueue
            // 
            this.btnRefreshQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefreshQueue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshQueue.FlatAppearance.BorderSize = 0;
            this.btnRefreshQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshQueue.ForeColor = System.Drawing.Color.White;
            this.btnRefreshQueue.Location = new System.Drawing.Point(610, 10);
            this.btnRefreshQueue.Name = "btnRefreshQueue";
            this.btnRefreshQueue.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshQueue.TabIndex = 4;
            this.btnRefreshQueue.Text = "Refresh";
            this.btnRefreshQueue.UseVisualStyleBackColor = false;
            this.btnRefreshQueue.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvQueue
            // 
            this.dgvQueue.AllowUserToAddRows = false;
            this.dgvQueue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQueue.BackgroundColor = System.Drawing.Color.White;
            this.dgvQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvQueue.Location = new System.Drawing.Point(10, 60);
            this.dgvQueue.Name = "dgvQueue";
            this.dgvQueue.ReadOnly = true;
            this.dgvQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueue.Size = new System.Drawing.Size(1100, 430);
            this.dgvQueue.TabIndex = 5;
            // 
            // tabPatients
            // 
            this.tabPatients.Controls.Add(this.btnViewPatient);
            this.tabPatients.Controls.Add(this.btnRefreshPatients);
            this.tabPatients.Controls.Add(this.dgvPatients);
            this.tabPatients.Location = new System.Drawing.Point(4, 26);
            this.tabPatients.Name = "tabPatients";
            this.tabPatients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPatients.Size = new System.Drawing.Size(1132, 510);
            this.tabPatients.TabIndex = 1;
            this.tabPatients.Text = "Patient Records";
            this.tabPatients.UseVisualStyleBackColor = true;
            // 
            // btnViewPatient
            // 
            this.btnViewPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnViewPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewPatient.FlatAppearance.BorderSize = 0;
            this.btnViewPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPatient.ForeColor = System.Drawing.Color.White;
            this.btnViewPatient.Location = new System.Drawing.Point(10, 10);
            this.btnViewPatient.Name = "btnViewPatient";
            this.btnViewPatient.Size = new System.Drawing.Size(140, 35);
            this.btnViewPatient.TabIndex = 0;
            this.btnViewPatient.Text = "View Details";
            this.btnViewPatient.UseVisualStyleBackColor = false;
            this.btnViewPatient.Click += new System.EventHandler(this.BtnViewPatient_Click);
            // 
            // btnRefreshPatients
            // 
            this.btnRefreshPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefreshPatients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshPatients.FlatAppearance.BorderSize = 0;
            this.btnRefreshPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshPatients.ForeColor = System.Drawing.Color.White;
            this.btnRefreshPatients.Location = new System.Drawing.Point(160, 10);
            this.btnRefreshPatients.Name = "btnRefreshPatients";
            this.btnRefreshPatients.Size = new System.Drawing.Size(110, 35);
            this.btnRefreshPatients.TabIndex = 1;
            this.btnRefreshPatients.Text = "Refresh";
            this.btnRefreshPatients.UseVisualStyleBackColor = false;
            this.btnRefreshPatients.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.Location = new System.Drawing.Point(10, 60);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(1100, 430);
            this.dgvPatients.TabIndex = 2;
            // 
            // SecretaryDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelHeader);
            this.Name = "SecretaryDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management System - Secretary Dashboard";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabQueue.ResumeLayout(false);
            this.tabQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueue)).EndInit();
            this.tabPatients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);
        }
    }
}