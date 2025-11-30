using Org.BouncyCastle.Asn1.X509;

namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class FireUserDialog
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
            panelWarning = new Panel();
            lblWarning = new Label();
            lblReason = new Label();
            panelReasonContainer = new Panel();
            txtReason = new TextBox();
            panelReasonBorder = new Panel();
            panelRehireOption = new Panel();
            chkCanRehire = new CheckBox();
            lblRehireDesc = new Label();
            panelButtons = new Panel();
            btnFire = new Button();
            btnCancel = new Button();
            panelMain.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelWarning.SuspendLayout();
            panelReasonContainer.SuspendLayout();
            panelRehireOption.SuspendLayout();
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
            panelMain.Size = new Size(600, 500);
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
            lblTitle.ForeColor = Color.FromArgb(220, 53, 69);
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🚫 FIRE USER";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(160, 174, 192);
            lblSubtitle.Location = new Point(30, 62);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(540, 40);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Role: User";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(247, 250, 252);
            panelContent.Controls.Add(panelRehireOption);
            panelContent.Controls.Add(panelReasonContainer);
            panelContent.Controls.Add(lblReason);
            panelContent.Controls.Add(panelWarning);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 110);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(30, 20, 30, 20);
            panelContent.Size = new Size(600, 390);
            panelContent.TabIndex = 1;
            // 
            // panelWarning
            // 
            panelWarning.BackColor = Color.FromArgb(254, 226, 226);
            panelWarning.Controls.Add(lblWarning);
            panelWarning.Location = new Point(30, 20);
            panelWarning.Name = "panelWarning";
            panelWarning.Padding = new Padding(20, 15, 20, 15);
            panelWarning.Size = new Size(540, 70);
            panelWarning.TabIndex = 0;
            // 
            // lblWarning
            // 
            lblWarning.Dock = DockStyle.Fill;
            lblWarning.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(185, 28, 28);
            lblWarning.Location = new Point(20, 15);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(500, 40);
            lblWarning.TabIndex = 0;
            lblWarning.Text = "⚠️ WARNING: This is a permanent action.\r\nUser will be moved to 'Fired' tab and cannot log in.";
            lblWarning.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReason
            // 
            lblReason.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblReason.ForeColor = Color.FromArgb(74, 85, 104);
            lblReason.Location = new Point(30, 105);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(540, 25);
            lblReason.TabIndex = 1;
            lblReason.Text = "REASON FOR TERMINATION (REQUIRED)";
            // 
            // panelReasonContainer
            // 
            panelReasonContainer.BackColor = Color.White;
            panelReasonContainer.Controls.Add(txtReason);
            panelReasonContainer.Controls.Add(panelReasonBorder);
            panelReasonContainer.Location = new Point(30, 135);
            panelReasonContainer.Name = "panelReasonContainer";
            panelReasonContainer.Size = new Size(540, 90);
            panelReasonContainer.TabIndex = 2;
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
            txtReason.PlaceholderText = "Enter detailed reason for firing this user...";
            txtReason.Size = new Size(510, 70);
            txtReason.TabIndex = 0;
            // 
            // panelReasonBorder
            // 
            panelReasonBorder.BackColor = Color.FromArgb(226, 232, 240);
            panelReasonBorder.Dock = DockStyle.Bottom;
            panelReasonBorder.Location = new Point(0, 88);
            panelReasonBorder.Name = "panelReasonBorder";
            panelReasonBorder.Size = new Size(540, 2);
            panelReasonBorder.TabIndex = 1;
            // 
            // panelRehireOption
            // 
            panelRehireOption.BackColor = Color.White;
            panelRehireOption.Controls.Add(lblRehireDesc);
            panelRehireOption.Controls.Add(chkCanRehire);
            panelRehireOption.Location = new Point(30, 240);
            panelRehireOption.Name = "panelRehireOption";
            panelRehireOption.Padding = new Padding(15);
            panelRehireOption.Size = new Size(540, 80);
            panelRehireOption.TabIndex = 3;
            // 
            // chkCanRehire
            // 
            chkCanRehire.AutoSize = true;
            chkCanRehire.Checked = true;
            chkCanRehire.CheckState = CheckState.Checked;
            chkCanRehire.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkCanRehire.ForeColor = Color.FromArgb(52, 152, 219);
            chkCanRehire.Location = new Point(15, 15);
            chkCanRehire.Name = "chkCanRehire";
            chkCanRehire.Size = new Size(332, 23);
            chkCanRehire.TabIndex = 0;
            chkCanRehire.Text = "✓ Allow rehiring by Head Administrator";
            chkCanRehire.UseVisualStyleBackColor = true;
            // 
            // lblRehireDesc
            // 
            lblRehireDesc.Font = new Font("Segoe UI", 9F);
            lblRehireDesc.ForeColor = Color.FromArgb(113, 128, 150);
            lblRehireDesc.Location = new Point(35, 43);
            lblRehireDesc.Name = "lblRehireDesc";
            lblRehireDesc.Size = new Size(490, 22);
            lblRehireDesc.TabIndex = 1;
            lblRehireDesc.Text = "If checked, Head Administrator can rehire this user in the future";
            //
            // panelButtons
            //
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnFire);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 420);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(30, 15, 30, 15);
            panelButtons.Size = new Size(600, 80);
            panelButtons.TabIndex = 2;
            //
            // btnFire
            //
            btnFire.BackColor = Color.FromArgb(220, 53, 69);
            btnFire.Cursor = Cursors.Hand;
            btnFire.FlatAppearance.BorderSize = 0;
            btnFire.FlatStyle = FlatStyle.Flat;
            btnFire.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFire.ForeColor = Color.White;
            btnFire.Location = new Point(30, 15);
            btnFire.Name = "btnFire";
            btnFire.Size = new Size(260, 50);
            btnFire.TabIndex = 0;
            btnFire.Text = "🚫 Fire User";
            btnFire.UseVisualStyleBackColor = false;
            btnFire.Click += BtnFire_Click;
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
            // FireUserDialog
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 500);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FireUserDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Fire User";
            panelMain.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelWarning.ResumeLayout(false);
            panelReasonContainer.ResumeLayout(false);
            panelReasonContainer.PerformLayout();
            panelRehireOption.ResumeLayout(false);
            panelRehireOption.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelContent;
        private Panel panelWarning;
        private Label lblWarning;
        private Label lblReason;
        private Panel panelReasonContainer;
        private TextBox txtReason;
        private Panel panelReasonBorder;
        private Panel panelRehireOption;
        private CheckBox chkCanRehire;
        private Label lblRehireDesc;
        private Panel panelButtons;
        private Button btnFire;
        private Button btnCancel;
    }
}