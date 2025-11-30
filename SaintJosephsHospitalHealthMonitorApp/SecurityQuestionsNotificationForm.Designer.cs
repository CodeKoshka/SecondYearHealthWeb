namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class SecurityQuestionsNotificationForm
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
            lblSubtitle = new Label();
            lblCount = new Label();
            dgvUsers = new DataGridView();
            panelButtons = new Panel();
            btnSetSecurity = new Button();
            btnClose = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(66, 153, 225);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(291, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔔 Security Notifications";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(224, 224, 224);
            lblSubtitle.Location = new Point(20, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(386, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Users requiring security question configuration";
            // 
            // lblCount
            // 
            lblCount.BackColor = Color.FromArgb(255, 243, 205);
            lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCount.ForeColor = Color.FromArgb(133, 77, 14);
            lblCount.Location = new Point(20, 90);
            lblCount.Name = "lblCount";
            lblCount.Padding = new Padding(15, 10, 15, 10);
            lblCount.Size = new Size(860, 40);
            lblCount.TabIndex = 1;
            lblCount.Text = "⚠️ 0 user(s) need security configuration";
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(20, 140);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(860, 380);
            dgvUsers.TabIndex = 2;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnSetSecurity);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 530);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(900, 70);
            panelButtons.TabIndex = 3;
            // 
            // btnSetSecurity
            // 
            btnSetSecurity.BackColor = Color.FromArgb(66, 153, 225);
            btnSetSecurity.Cursor = Cursors.Hand;
            btnSetSecurity.FlatAppearance.BorderSize = 0;
            btnSetSecurity.FlatStyle = FlatStyle.Flat;
            btnSetSecurity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSetSecurity.ForeColor = Color.White;
            btnSetSecurity.Location = new Point(590, 15);
            btnSetSecurity.Name = "btnSetSecurity";
            btnSetSecurity.Size = new Size(200, 40);
            btnSetSecurity.TabIndex = 0;
            btnSetSecurity.Text = "🔐 Configure Security";
            btnSetSecurity.UseVisualStyleBackColor = false;
            btnSetSecurity.Click += BtnSetSecurity_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(113, 128, 150);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(800, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 40);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // SecurityQuestionsNotificationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(panelButtons);
            Controls.Add(dgvUsers);
            Controls.Add(lblCount);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SecurityQuestionsNotificationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Security Notifications";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblCount;
        private DataGridView dgvUsers;
        private Panel panelButtons;
        private Button btnSetSecurity;
        private Button btnClose;
    }
}
