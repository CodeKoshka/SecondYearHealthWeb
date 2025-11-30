namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class DeactivationTypeDialog
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
            lblType = new Label();
            panelTemporary = new Panel();
            rdoTemporary = new RadioButton();
            lblTempDesc = new Label();
            panelPermanent = new Panel();
            rdoPermanent = new RadioButton();
            lblPermDesc = new Label();
            lblReason = new Label();
            panelReasonContainer = new Panel();
            txtReason = new TextBox();
            panelReasonBorder = new Panel();
            panelButtons = new Panel();
            btnConfirm = new Button();
            btnCancel = new Button();
            panelMain.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelTemporary.SuspendLayout();
            panelPermanent.SuspendLayout();
            panelReasonContainer.SuspendLayout();
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
            panelMain.Size = new Size(600, 550);
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
            panelHeader.Size = new Size(600, 110);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(196, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Deactivate User";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(160, 174, 192);
            lblSubtitle.Location = new Point(30, 62);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(72, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Role: User";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(247, 250, 252);
            panelContent.Controls.Add(panelReasonContainer);
            panelContent.Controls.Add(lblReason);
            panelContent.Controls.Add(panelPermanent);
            panelContent.Controls.Add(panelTemporary);
            panelContent.Controls.Add(lblType);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 110);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(30, 20, 30, 20);
            panelContent.Size = new Size(600, 440);
            panelContent.TabIndex = 1;
            // 
            // lblType
            // 
            lblType.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblType.ForeColor = Color.FromArgb(26, 32, 44);
            lblType.Location = new Point(30, 20);
            lblType.Name = "lblType";
            lblType.Size = new Size(540, 25);
            lblType.TabIndex = 0;
            lblType.Text = "Select Deactivation Type";
            // 
            // panelTemporary
            // 
            panelTemporary.BackColor = Color.White;
            panelTemporary.Controls.Add(lblTempDesc);
            panelTemporary.Controls.Add(rdoTemporary);
            panelTemporary.Location = new Point(30, 55);
            panelTemporary.Name = "panelTemporary";
            panelTemporary.Padding = new Padding(15);
            panelTemporary.Size = new Size(540, 100);
            panelTemporary.TabIndex = 1;
            // 
            // rdoTemporary
            // 
            rdoTemporary.AutoSize = true;
            rdoTemporary.Checked = true;
            rdoTemporary.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            rdoTemporary.ForeColor = Color.FromArgb(66, 153, 225);
            rdoTemporary.Location = new Point(15, 15);
            rdoTemporary.Name = "rdoTemporary";
            rdoTemporary.Size = new Size(213, 24);
            rdoTemporary.TabIndex = 0;
            rdoTemporary.TabStop = true;
            rdoTemporary.Text = "⏸️ Temporary Deactivation";
            rdoTemporary.UseVisualStyleBackColor = true;
            // 
            // lblTempDesc
            // 
            lblTempDesc.Font = new Font("Segoe UI", 9F);
            lblTempDesc.ForeColor = Color.FromArgb(113, 128, 150);
            lblTempDesc.Location = new Point(35, 45);
            lblTempDesc.Name = "lblTempDesc";
            lblTempDesc.Size = new Size(490, 40);
            lblTempDesc.TabIndex = 1;
            lblTempDesc.Text = "For temporary issues (failed logins, security concerns)\r\nCan be reactivated by any administrator • User account preserved";
            // 
            // panelPermanent
            // 
            panelPermanent.BackColor = Color.White;
            panelPermanent.Controls.Add(lblPermDesc);
            panelPermanent.Controls.Add(rdoPermanent);
            panelPermanent.Location = new Point(30, 170);
            panelPermanent.Name = "panelPermanent";
            panelPermanent.Padding = new Padding(15);
            panelPermanent.Size = new Size(540, 100);
            panelPermanent.TabIndex = 2;
            // 
            // rdoPermanent
            // 
            rdoPermanent.AutoSize = true;
            rdoPermanent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            rdoPermanent.ForeColor = Color.FromArgb(231, 76, 60);
            rdoPermanent.Location = new Point(15, 15);
            rdoPermanent.Name = "rdoPermanent";
            rdoPermanent.Size = new Size(173, 24);
            rdoPermanent.TabIndex = 0;
            rdoPermanent.Text = "🚫 Permanent Firing";
            rdoPermanent.UseVisualStyleBackColor = true;
            // 
            // lblPermDesc
            // 
            lblPermDesc.Font = new Font("Segoe UI", 9F);
            lblPermDesc.ForeColor = Color.FromArgb(113, 128, 150);
            lblPermDesc.Location = new Point(35, 45);
            lblPermDesc.Name = "lblPermDesc";
            lblPermDesc.Size = new Size(490, 40);
            lblPermDesc.TabIndex = 1;
            lblPermDesc.Text = "For termination of employment\r\nOnly Head Administrator can rehire • Moved to 'Fired' tab";
            // 
            // lblReason
            // 
            lblReason.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReason.ForeColor = Color.FromArgb(74, 85, 104);
            lblReason.Location = new Point(30, 285);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(540, 25);
            lblReason.TabIndex = 3;
            lblReason.Text = "REASON (REQUIRED)";
            // 
            // panelReasonContainer
            // 
            panelReasonContainer.BackColor = Color.White;
            panelReasonContainer.Controls.Add(txtReason);
            panelReasonContainer.Controls.Add(panelReasonBorder);
            panelReasonContainer.Location = new Point(30, 315);
            panelReasonContainer.Name = "panelReasonContainer";
            panelReasonContainer.Size = new Size(540, 75);
            panelReasonContainer.TabIndex = 4;
            // 
            // txtReason
            // 
            txtReason.BackColor = Color.White;
            txtReason.BorderStyle = BorderStyle.None;
            txtReason.Font = new Font("Segoe UI", 10F);
            txtReason.ForeColor = Color.FromArgb(26, 32, 44);
            txtReason.Location = new Point(15, 10);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.PlaceholderText = "Enter the reason for deactivation...";
            txtReason.Size = new Size(510, 55);
            txtReason.TabIndex = 0;
            // 
            // panelReasonBorder
            // 
            panelReasonBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelReasonBorder.Dock = DockStyle.Bottom;
            panelReasonBorder.Location = new Point(0, 73);
            panelReasonBorder.Name = "panelReasonBorder";
            panelReasonBorder.Size = new Size(540, 2);
            panelReasonBorder.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnConfirm);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 470);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(30, 15, 30, 15);
            panelButtons.Size = new Size(600, 80);
            panelButtons.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(231, 76, 60);
            btnConfirm.Cursor = Cursors.Hand;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(30, 15);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(260, 50);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "✓ Confirm Deactivation";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += BtnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(310, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(260, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // DeactivationTypeDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 550);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DeactivationTypeDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Deactivate Account";
            panelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelTemporary.ResumeLayout(false);
            panelTemporary.PerformLayout();
            panelPermanent.ResumeLayout(false);
            panelPermanent.PerformLayout();
            panelReasonContainer.ResumeLayout(false);
            panelReasonContainer.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelContent;
        private Label lblType;
        private Panel panelTemporary;
        private RadioButton rdoTemporary;
        private Label lblTempDesc;
        private Panel panelPermanent;
        private RadioButton rdoPermanent;
        private Label lblPermDesc;
        private Label lblReason;
        private Panel panelReasonContainer;
        private TextBox txtReason;
        private Panel panelReasonBorder;
        private Panel panelButtons;
        private Button btnConfirm;
        private Button btnCancel;
    }
}