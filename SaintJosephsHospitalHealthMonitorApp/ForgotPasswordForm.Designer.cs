namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ForgotPasswordForm
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
            panelRight = new Panel();
            lblStatus = new Label();
            btnResetPassword = new Button();
            panelSecurityAnswerContainer = new Panel();
            txtSecurityAnswer = new TextBox();
            panelSecurityAnswerBorder = new Panel();
            lblSecurityAnswer = new Label();
            lblSecurityQuestion = new Label();
            panelEmailContainer = new Panel();
            txtEmail = new TextBox();
            panelEmailBorder = new Panel();
            lblEmail = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            btnBackToLogin = new Button();
            panelLeft = new Panel();
            lblFooter = new Label();
            lblBrandName = new Label();
            lblBrandLogo = new Label();
            panelMain.SuspendLayout();
            panelRight.SuspendLayout();
            panelSecurityAnswerContainer.SuspendLayout();
            panelEmailContainer.SuspendLayout();
            panelLeft.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(247, 250, 252);
            panelMain.Controls.Add(panelRight);
            panelMain.Controls.Add(panelLeft);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1000, 600);
            panelMain.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(247, 250, 252);
            panelRight.Controls.Add(lblStatus);
            panelRight.Controls.Add(btnResetPassword);
            panelRight.Controls.Add(panelSecurityAnswerContainer);
            panelRight.Controls.Add(lblSecurityAnswer);
            panelRight.Controls.Add(lblSecurityQuestion);
            panelRight.Controls.Add(panelEmailContainer);
            panelRight.Controls.Add(lblEmail);
            panelRight.Controls.Add(lblSubtitle);
            panelRight.Controls.Add(lblTitle);
            panelRight.Controls.Add(btnBackToLogin);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(450, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(60, 80, 60, 80);
            panelRight.Size = new Size(550, 600);
            panelRight.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(229, 62, 62);
            lblStatus.Location = new Point(63, 470);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(420, 40);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Visible = false;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(66, 153, 225);
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(60, 420);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(430, 50);
            btnResetPassword.TabIndex = 3;
            btnResetPassword.Text = "RESET PASSWORD";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += BtnResetPassword_Click;
            // 
            // panelSecurityAnswerContainer
            // 
            panelSecurityAnswerContainer.BackColor = Color.White;
            panelSecurityAnswerContainer.Controls.Add(txtSecurityAnswer);
            panelSecurityAnswerContainer.Controls.Add(panelSecurityAnswerBorder);
            panelSecurityAnswerContainer.Location = new Point(60, 360);
            panelSecurityAnswerContainer.Name = "panelSecurityAnswerContainer";
            panelSecurityAnswerContainer.Size = new Size(430, 45);
            panelSecurityAnswerContainer.TabIndex = 7;
            // 
            // txtSecurityAnswer
            // 
            txtSecurityAnswer.BackColor = Color.White;
            txtSecurityAnswer.BorderStyle = BorderStyle.None;
            txtSecurityAnswer.Font = new Font("Segoe UI", 12F);
            txtSecurityAnswer.ForeColor = Color.FromArgb(26, 32, 44);
            txtSecurityAnswer.Location = new Point(15, 12);
            txtSecurityAnswer.Name = "txtSecurityAnswer";
            txtSecurityAnswer.Size = new Size(400, 22);
            txtSecurityAnswer.TabIndex = 0;
            // 
            // panelSecurityAnswerBorder
            // 
            panelSecurityAnswerBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelSecurityAnswerBorder.Dock = DockStyle.Bottom;
            panelSecurityAnswerBorder.Location = new Point(0, 43);
            panelSecurityAnswerBorder.Name = "panelSecurityAnswerBorder";
            panelSecurityAnswerBorder.Size = new Size(430, 2);
            panelSecurityAnswerBorder.TabIndex = 1;
            // 
            // lblSecurityAnswer
            // 
            lblSecurityAnswer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSecurityAnswer.ForeColor = Color.FromArgb(74, 85, 104);
            lblSecurityAnswer.Location = new Point(60, 330);
            lblSecurityAnswer.Name = "lblSecurityAnswer";
            lblSecurityAnswer.Size = new Size(430, 25);
            lblSecurityAnswer.TabIndex = 6;
            lblSecurityAnswer.Text = "SECURITY ANSWER";
            lblSecurityAnswer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSecurityQuestion
            // 
            lblSecurityQuestion.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblSecurityQuestion.ForeColor = Color.FromArgb(113, 128, 150);
            lblSecurityQuestion.Location = new Point(60, 295);
            lblSecurityQuestion.Name = "lblSecurityQuestion";
            lblSecurityQuestion.Size = new Size(430, 30);
            lblSecurityQuestion.TabIndex = 5;
            lblSecurityQuestion.Text = "Enter your email first to see your security question";
            lblSecurityQuestion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelEmailContainer
            // 
            panelEmailContainer.BackColor = Color.White;
            panelEmailContainer.Controls.Add(txtEmail);
            panelEmailContainer.Controls.Add(panelEmailBorder);
            panelEmailContainer.Location = new Point(60, 235);
            panelEmailContainer.Name = "panelEmailContainer";
            panelEmailContainer.Size = new Size(430, 45);
            panelEmailContainer.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.ForeColor = Color.FromArgb(26, 32, 44);
            txtEmail.Location = new Point(15, 12);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 22);
            txtEmail.TabIndex = 0;
            txtEmail.Leave += TxtEmail_Leave;
            // 
            // panelEmailBorder
            // 
            panelEmailBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelEmailBorder.Dock = DockStyle.Bottom;
            panelEmailBorder.Location = new Point(0, 43);
            panelEmailBorder.Name = "panelEmailBorder";
            panelEmailBorder.Size = new Size(430, 2);
            panelEmailBorder.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(74, 85, 104);
            lblEmail.Location = new Point(60, 205);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(430, 25);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "EMAIL ADDRESS";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(113, 128, 150);
            lblSubtitle.Location = new Point(60, 145);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(430, 50);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Enter your email and answer your security question to reset your password";
            lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(26, 32, 44);
            lblTitle.Location = new Point(60, 80);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(430, 60);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Forgot Password";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.BackColor = Color.Transparent;
            btnBackToLogin.Cursor = Cursors.Hand;
            btnBackToLogin.FlatAppearance.BorderSize = 0;
            btnBackToLogin.FlatStyle = FlatStyle.Flat;
            btnBackToLogin.Font = new Font("Segoe UI", 10F);
            btnBackToLogin.ForeColor = Color.FromArgb(66, 153, 225);
            btnBackToLogin.Location = new Point(60, 520);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(430, 40);
            btnBackToLogin.TabIndex = 9;
            btnBackToLogin.Text = "← Back to Login";
            btnBackToLogin.UseVisualStyleBackColor = false;
            btnBackToLogin.Click += BtnBackToLogin_Click;
            // 
            // panelLeft
            // 
            panelLeft.BackColor = Color.FromArgb(26, 32, 44);
            panelLeft.Controls.Add(lblFooter);
            panelLeft.Controls.Add(lblBrandName);
            panelLeft.Controls.Add(lblBrandLogo);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(450, 600);
            panelLeft.TabIndex = 0;
            // 
            // lblFooter
            // 
            lblFooter.Font = new Font("Segoe UI", 9F);
            lblFooter.ForeColor = Color.FromArgb(160, 174, 192);
            lblFooter.Location = new Point(0, 560);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(450, 30);
            lblFooter.TabIndex = 2;
            lblFooter.Text = "© 2025 St. Joseph's Hospital. All rights reserved.";
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBrandName
            // 
            lblBrandName.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBrandName.ForeColor = Color.White;
            lblBrandName.Location = new Point(30, 280);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(390, 80);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "ST. JOSEPH'S HOSPITAL\nPassword Recovery";
            lblBrandName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBrandLogo
            // 
            lblBrandLogo.Font = new Font("Segoe UI", 72F, FontStyle.Bold);
            lblBrandLogo.ForeColor = Color.FromArgb(66, 153, 225);
            lblBrandLogo.Location = new Point(0, 150);
            lblBrandLogo.Name = "lblBrandLogo";
            lblBrandLogo.Size = new Size(450, 120);
            lblBrandLogo.TabIndex = 0;
            lblBrandLogo.Text = "🔐";
            lblBrandLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(1000, 600);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "St. Joseph's Hospital - Password Recovery";
            panelMain.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelSecurityAnswerContainer.ResumeLayout(false);
            panelSecurityAnswerContainer.PerformLayout();
            panelEmailContainer.ResumeLayout(false);
            panelEmailContainer.PerformLayout();
            panelLeft.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelLeft;
        private Panel panelRight;
        private Label lblBrandLogo;
        private Label lblBrandName;
        private Label lblFooter;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblEmail;
        private Panel panelEmailContainer;
        private TextBox txtEmail;
        private Panel panelEmailBorder;
        private Label lblSecurityQuestion;
        private Label lblSecurityAnswer;
        private Panel panelSecurityAnswerContainer;
        private TextBox txtSecurityAnswer;
        private Panel panelSecurityAnswerBorder;
        private Button btnResetPassword;
        private Label lblStatus;
        private Button btnBackToLogin;
    }
}