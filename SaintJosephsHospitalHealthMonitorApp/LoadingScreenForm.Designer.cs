namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class LoadingScreenForm
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
            lblLogo = new Label();
            lblTitle = new Label();
            panelSpinner = new Panel();
            lblStatus = new Label();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(26, 32, 44);
            panelMain.Controls.Add(lblProgress);
            panelMain.Controls.Add(progressBar);
            panelMain.Controls.Add(lblStatus);
            panelMain.Controls.Add(panelSpinner);
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblLogo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(600, 400);
            panelMain.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.Font = new System.Drawing.Font("Segoe UI", 48F, FontStyle.Bold);
            lblLogo.ForeColor = Color.FromArgb(66, 153, 225);
            lblLogo.Location = new Point(0, 60);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(600, 80);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "⚕️";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 145);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "ST. JOSEPH'S HOSPITAL";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSpinner
            // 
            panelSpinner.BackColor = Color.Transparent;
            panelSpinner.Location = new Point(250, 200);
            panelSpinner.Name = "panelSpinner";
            panelSpinner.Size = new Size(100, 100);
            panelSpinner.TabIndex = 2;
            panelSpinner.Paint += PanelSpinner_Paint;
            // 
            // lblStatus
            // 
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblStatus.ForeColor = Color.FromArgb(160, 174, 192);
            lblStatus.Location = new Point(50, 310);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(500, 25);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Initializing system...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            progressBar.ForeColor = Color.FromArgb(66, 153, 225);
            progressBar.Location = new Point(150, 340);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(300, 8);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 4;
            // 
            // lblProgress
            // 
            lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            lblProgress.ForeColor = Color.FromArgb(66, 153, 225);
            lblProgress.Location = new Point(250, 350);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(100, 20);
            lblProgress.TabIndex = 5;
            lblProgress.Text = "0%";
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 32, 44);
            ClientSize = new Size(600, 400);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading...";
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label lblLogo;
        private Label lblTitle;
        private Panel panelSpinner;
        private Label lblStatus;
        private ProgressBar progressBar;
        private Label lblProgress;
    }
}