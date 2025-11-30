namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class SetNewPasswordForm
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
            panelMain = new Panel();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelContent = new Panel();
            chkShowPasswords = new CheckBox();
            lblStatus = new Label();
            panelConfirmPasswordContainer = new Panel();
            txtConfirmPassword = new TextBox();
            panelConfirmPasswordBorder = new Panel();
            lblConfirmPassword = new Label();
            panelNewPasswordContainer = new Panel();
            txtNewPassword = new TextBox();
            panelNewPasswordBorder = new Panel();
            lblNewPassword = new Label();
            lblRequirements = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSetPassword = new Button();
            panelMain.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelConfirmPasswordContainer.SuspendLayout();
            panelNewPasswordContainer.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(247, 250, 252);
            panelMain.Controls.Add(panelButtons);
            panelMain.Controls.Add(panelContent);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(550, 500);
            panelMain.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(26, 32, 44);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 25, 30, 25);
            panelHeader.Size = new Size(550, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Set New Password";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(160, 174, 192);
            lblSubtitle.Location = new Point(30, 62);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(490, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please enter your new password";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(247, 250, 252);
            panelContent.Controls.Add(chkShowPasswords);
            panelContent.Controls.Add(lblStatus);
            panelContent.Controls.Add(panelConfirmPasswordContainer);
            panelContent.Controls.Add(lblConfirmPassword);
            panelContent.Controls.Add(panelNewPasswordContainer);
            panelContent.Controls.Add(lblNewPassword);
            panelContent.Controls.Add(lblRequirements);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 100);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(30, 20, 30, 20);
            panelContent.Size = new Size(550, 400);
            panelContent.TabIndex = 1;
            // 
            // chkShowPasswords
            // 
            chkShowPasswords.AutoSize = true;
            chkShowPasswords.Font = new Font("Segoe UI", 9F);
            chkShowPasswords.ForeColor = Color.FromArgb(74, 85, 104);
            chkShowPasswords.Location = new Point(33, 285);
            chkShowPasswords.Name = "chkShowPasswords";
            chkShowPasswords.Size = new Size(114, 19);
            chkShowPasswords.TabIndex = 6;
            chkShowPasswords.Text = "Show Passwords";
            chkShowPasswords.UseVisualStyleBackColor = true;
            chkShowPasswords.CheckedChanged += ChkShowPasswords_CheckedChanged;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(229, 62, 62);
            lblStatus.Location = new Point(33, 310);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(484, 40);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "";
            lblStatus.Visible = false;
            // 
            // panelConfirmPasswordContainer
            // 
            panelConfirmPasswordContainer.BackColor = Color.White;
            panelConfirmPasswordContainer.Controls.Add(txtConfirmPassword);
            panelConfirmPasswordContainer.Controls.Add(panelConfirmPasswordBorder);
            panelConfirmPasswordContainer.Location = new Point(30, 230);
            panelConfirmPasswordContainer.Name = "panelConfirmPasswordContainer";
            panelConfirmPasswordContainer.Size = new Size(490, 45);
            panelConfirmPasswordContainer.TabIndex = 4;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor = Color.White;
            txtConfirmPassword.BorderStyle = BorderStyle.None;
            txtConfirmPassword.Font = new Font("Segoe UI", 12F);
            txtConfirmPassword.ForeColor = Color.FromArgb(26, 32, 44);
            txtConfirmPassword.Location = new Point(15, 12);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(460, 22);
            txtConfirmPassword.TabIndex = 0;
            // 
            // panelConfirmPasswordBorder
            // 
            panelConfirmPasswordBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelConfirmPasswordBorder.Dock = DockStyle.Bottom;
            panelConfirmPasswordBorder.Location = new Point(0, 43);
            panelConfirmPasswordBorder.Name = "panelConfirmPasswordBorder";
            panelConfirmPasswordBorder.Size = new Size(490, 2);
            panelConfirmPasswordBorder.TabIndex = 1;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(74, 85, 104);
            lblConfirmPassword.Location = new Point(30, 200);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(490, 25);
            lblConfirmPassword.TabIndex = 3;
            lblConfirmPassword.Text = "CONFIRM NEW PASSWORD";
            // 
            // panelNewPasswordContainer
            // 
            panelNewPasswordContainer.BackColor = Color.White;
            panelNewPasswordContainer.Controls.Add(txtNewPassword);
            panelNewPasswordContainer.Controls.Add(panelNewPasswordBorder);
            panelNewPasswordContainer.Location = new Point(30, 145);
            panelNewPasswordContainer.Name = "panelNewPasswordContainer";
            panelNewPasswordContainer.Size = new Size(490, 45);
            panelNewPasswordContainer.TabIndex = 2;
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.White;
            txtNewPassword.BorderStyle = BorderStyle.None;
            txtNewPassword.Font = new Font("Segoe UI", 12F);
            txtNewPassword.ForeColor = Color.FromArgb(26, 32, 44);
            txtNewPassword.Location = new Point(15, 12);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(460, 22);
            txtNewPassword.TabIndex = 0;
            // 
            // panelNewPasswordBorder
            // 
            panelNewPasswordBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelNewPasswordBorder.Dock = DockStyle.Bottom;
            panelNewPasswordBorder.Location = new Point(0, 43);
            panelNewPasswordBorder.Name = "panelNewPasswordBorder";
            panelNewPasswordBorder.Size = new Size(490, 2);
            panelNewPasswordBorder.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(74, 85, 104);
            lblNewPassword.Location = new Point(30, 115);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(490, 25);
            lblNewPassword.TabIndex = 1;
            lblNewPassword.Text = "NEW PASSWORD";
            // 
            // lblRequirements
            // 
            lblRequirements.Font = new Font("Segoe UI", 9F);
            lblRequirements.ForeColor = Color.FromArgb(113, 128, 150);
            lblRequirements.Location = new Point(30, 20);
            lblRequirements.Name = "lblRequirements";
            lblRequirements.Size = new Size(490, 90);
            lblRequirements.TabIndex = 0;
            lblRequirements.Text = "Password Requirements:\r\n• Minimum 8 characters\r\n• At least one uppercase letter\r\n• At least one number\r\n• At least one special character (!@#$%^&*)";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSetPassword);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 420);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(30, 15, 30, 15);
            panelButtons.Size = new Size(550, 80);
            panelButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(275, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(245, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSetPassword
            // 
            btnSetPassword.BackColor = Color.FromArgb(72, 187, 120);
            btnSetPassword.Cursor = Cursors.Hand;
            btnSetPassword.FlatAppearance.BorderSize = 0;
            btnSetPassword.FlatStyle = FlatStyle.Flat;
            btnSetPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSetPassword.ForeColor = Color.White;
            btnSetPassword.Location = new Point(30, 15);
            btnSetPassword.Name = "btnSetPassword";
            btnSetPassword.Size = new Size(235, 50);
            btnSetPassword.TabIndex = 0;
            btnSetPassword.Text = "✓ Set Password";
            btnSetPassword.UseVisualStyleBackColor = false;
            btnSetPassword.Click += BtnSetPassword_Click;
            // 
            // SetNewPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 500);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetNewPasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set New Password";
            panelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelConfirmPasswordContainer.ResumeLayout(false);
            panelConfirmPasswordContainer.PerformLayout();
            panelNewPasswordContainer.ResumeLayout(false);
            panelNewPasswordContainer.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelContent;
        private Label lblRequirements;
        private Label lblNewPassword;
        private Panel panelNewPasswordContainer;
        private TextBox txtNewPassword;
        private Panel panelNewPasswordBorder;
        private Label lblConfirmPassword;
        private Panel panelConfirmPasswordContainer;
        private TextBox txtConfirmPassword;
        private Panel panelConfirmPasswordBorder;
        private Label lblStatus;
        private CheckBox chkShowPasswords;
        private Panel panelButtons;
        private Button btnSetPassword;
        private Button btnCancel;
    }
}