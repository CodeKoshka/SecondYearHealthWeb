namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class LoginForm
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
            lblError = new Label();
            btnLogin = new Button();
            chkShowPassword = new CheckBox();
            panelPasswordContainer = new Panel();
            txtPassword = new TextBox();
            panelPasswordBorder = new Panel();
            lblPassword = new Label();
            panelEmailContainer = new Panel();
            txtEmail = new TextBox();
            panelEmailBorder = new Panel();
            lblEmail = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panelLeft = new Panel();
            lblFooter = new Label();
            lblBrandName = new Label();
            lblBrandLogo = new Label();
            panelMain.SuspendLayout();
            panelRight.SuspendLayout();
            panelPasswordContainer.SuspendLayout();
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
            panelRight.Controls.Add(lblError);
            panelRight.Controls.Add(btnLogin);
            panelRight.Controls.Add(chkShowPassword);
            panelRight.Controls.Add(panelPasswordContainer);
            panelRight.Controls.Add(lblPassword);
            panelRight.Controls.Add(panelEmailContainer);
            panelRight.Controls.Add(lblEmail);
            panelRight.Controls.Add(lblSubtitle);
            panelRight.Controls.Add(lblTitle);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(450, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(60, 100, 60, 100);
            panelRight.Size = new Size(550, 600);
            panelRight.TabIndex = 1;
            // 
            // lblError
            // 
            lblError.BackColor = Color.Transparent;
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(229, 62, 62);
            lblError.Location = new Point(63, 388);
            lblError.Name = "lblError";
            lblError.Size = new Size(420, 20);
            lblError.TabIndex = 6;
            lblError.Text = "Error message here";
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            lblError.Visible = false;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(66, 153, 225);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(49, 130, 206);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(60, 450);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(430, 50);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "SIGN IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(74, 85, 104);
            chkShowPassword.Location = new Point(63, 411);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(108, 19);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
            // 
            // panelPasswordContainer
            // 
            panelPasswordContainer.BackColor = Color.White;
            panelPasswordContainer.Controls.Add(txtPassword);
            panelPasswordContainer.Controls.Add(panelPasswordBorder);
            panelPasswordContainer.Location = new Point(60, 340);
            panelPasswordContainer.Name = "panelPasswordContainer";
            panelPasswordContainer.Size = new Size(430, 45);
            panelPasswordContainer.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = Color.FromArgb(26, 32, 44);
            txtPassword.Location = new Point(15, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(400, 22);
            txtPassword.TabIndex = 0;
            // 
            // panelPasswordBorder
            // 
            panelPasswordBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelPasswordBorder.Dock = DockStyle.Bottom;
            panelPasswordBorder.Location = new Point(0, 43);
            panelPasswordBorder.Name = "panelPasswordBorder";
            panelPasswordBorder.Size = new Size(430, 2);
            panelPasswordBorder.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(74, 85, 104);
            lblPassword.Location = new Point(60, 310);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(430, 25);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "PASSWORD";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelEmailContainer
            // 
            panelEmailContainer.BackColor = Color.White;
            panelEmailContainer.Controls.Add(txtEmail);
            panelEmailContainer.Controls.Add(panelEmailBorder);
            panelEmailContainer.Location = new Point(60, 245);
            panelEmailContainer.Name = "panelEmailContainer";
            panelEmailContainer.Size = new Size(430, 45);
            panelEmailContainer.TabIndex = 3;
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
            lblEmail.Location = new Point(60, 215);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(430, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "EMAIL ADDRESS";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(113, 128, 150);
            lblSubtitle.Location = new Point(60, 155);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(430, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Access the Hospital Management System";
            lblSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(26, 32, 44);
            lblTitle.Location = new Point(60, 100);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(430, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sign In";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
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
            lblBrandName.Text = "ST. JOSEPH'S HOSPITAL\nManagement System";
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
            lblBrandLogo.Text = "⚕️";
            lblBrandLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 250, 252);
            ClientSize = new Size(1000, 600);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "St. Joseph's Hospital - Login";
            panelMain.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelPasswordContainer.ResumeLayout(false);
            panelPasswordContainer.PerformLayout();
            panelEmailContainer.ResumeLayout(false);
            panelEmailContainer.PerformLayout();
            panelLeft.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelLeft;
        private Panel panelMain;
        private Panel panelRight;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblEmail;
        private TextBox txtEmail;
        private Panel panelEmailBorder;
        private Label lblPassword;
        private TextBox txtPassword;
        private Panel panelPasswordBorder;
        private Button btnLogin;
        private Label lblError;
        private Label lblBrandLogo;
        private Label lblBrandName;
        private Label lblFooter;
        private Panel panelEmailContainer;
        private Panel panelPasswordContainer;
        private CheckBox chkShowPassword;
    }
}