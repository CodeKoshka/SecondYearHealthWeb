namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class SetSecurityQuestionForm
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
            lblUserInfo = new Label();
            lblQuestion = new Label();
            cmbSecurityQuestion = new ComboBox();
            lblAnswer = new Label();
            txtSecurityAnswer = new TextBox();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            lblNote = new Label();
            panelHeader.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(66, 153, 225);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(500, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(259, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔐 Set Security Question";
            // 
            // lblUserInfo
            // 
            lblUserInfo.BackColor = Color.FromArgb(247, 250, 252);
            lblUserInfo.Font = new Font("Segoe UI", 10F);
            lblUserInfo.ForeColor = Color.FromArgb(74, 85, 104);
            lblUserInfo.Location = new Point(20, 70);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Padding = new Padding(10);
            lblUserInfo.Size = new Size(460, 60);
            lblUserInfo.TabIndex = 1;
            lblUserInfo.Text = "👤 User Name\n📧 user@email.com";
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuestion.ForeColor = Color.FromArgb(74, 85, 104);
            lblQuestion.Location = new Point(20, 145);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(137, 19);
            lblQuestion.TabIndex = 2;
            lblQuestion.Text = "Security Question:";
            // 
            // cmbSecurityQuestion
            // 
            cmbSecurityQuestion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSecurityQuestion.Font = new Font("Segoe UI", 11F);
            cmbSecurityQuestion.FormattingEnabled = true;
            cmbSecurityQuestion.Location = new Point(20, 170);
            cmbSecurityQuestion.Name = "cmbSecurityQuestion";
            cmbSecurityQuestion.Size = new Size(460, 28);
            cmbSecurityQuestion.TabIndex = 3;
            // 
            // lblAnswer
            // 
            lblAnswer.AutoSize = true;
            lblAnswer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAnswer.ForeColor = Color.FromArgb(74, 85, 104);
            lblAnswer.Location = new Point(20, 215);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(63, 19);
            lblAnswer.TabIndex = 4;
            lblAnswer.Text = "Answer:";
            // 
            // txtSecurityAnswer
            // 
            txtSecurityAnswer.Font = new Font("Segoe UI", 11F);
            txtSecurityAnswer.Location = new Point(20, 240);
            txtSecurityAnswer.Name = "txtSecurityAnswer";
            txtSecurityAnswer.Size = new Size(460, 27);
            txtSecurityAnswer.TabIndex = 5;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblNote.ForeColor = Color.FromArgb(229, 62, 62);
            lblNote.Location = new Point(20, 275);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(410, 30);
            lblNote.TabIndex = 6;
            lblNote.Text = "⚠️ Make sure the user remembers this answer.\nThey will need it to recover their password.";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 320);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(500, 70);
            panelButtons.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(72, 187, 120);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(280, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "✓ Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(113, 128, 150);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(390, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // SetSecurityQuestionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 390);
            Controls.Add(panelButtons);
            Controls.Add(lblNote);
            Controls.Add(txtSecurityAnswer);
            Controls.Add(lblAnswer);
            Controls.Add(cmbSecurityQuestion);
            Controls.Add(lblQuestion);
            Controls.Add(lblUserInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetSecurityQuestionForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Set Security Question";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblUserInfo;
        private Label lblQuestion;
        private ComboBox cmbSecurityQuestion;
        private Label lblAnswer;
        private TextBox txtSecurityAnswer;
        private Label lblNote;
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
    }
}