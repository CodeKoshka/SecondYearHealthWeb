namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ShowDetailedMedicalHistoryForm
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
            panelHeader = new System.Windows.Forms.Panel();
            lblInstruction = new System.Windows.Forms.Label();
            lblStats = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            dgvHistory = new System.Windows.Forms.DataGridView();
            panelButtons = new System.Windows.Forms.Panel();
            btnClose = new System.Windows.Forms.Button();
            btnPrint = new System.Windows.Forms.Button();
            btnViewDetails = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            panelHeader.Controls.Add(this.lblInstruction);
            panelHeader.Controls.Add(this.lblStats);
            panelHeader.Controls.Add(this.lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(1200, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblInstruction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            lblInstruction.Location = new System.Drawing.Point(20, 75);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new System.Drawing.Size(357, 15);
            lblInstruction.TabIndex = 2;
            lblInstruction.Text = "Double-click any record to view full medical documentation";
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblStats.ForeColor = System.Drawing.Color.White;
            lblStats.Location = new System.Drawing.Point(20, 50);
            lblStats.Name = "lblStats";
            lblStats.Size = new System.Drawing.Size(257, 20);
            lblStats.TabIndex = 1;
            lblStats.Text = "Medical Records: 0 | Total Visits: 0";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(388, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📋 Complete Medical History - Patient";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.BackgroundColor = System.Drawing.Color.White;
            dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistory.ColumnHeadersHeight = 50;
            dgvHistory.Location = new System.Drawing.Point(20, 120);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowTemplate.Height = 40;
            dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new System.Drawing.Size(1160, 520);
            dgvHistory.TabIndex = 1;
            dgvHistory.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistory_CellDoubleClick);
            // 
            // panelButtons
            // 
            panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            panelButtons.Controls.Add(this.btnClose);
            panelButtons.Controls.Add(this.btnPrint);
            panelButtons.Controls.Add(this.btnViewDetails);
            panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelButtons.Location = new System.Drawing.Point(0, 660);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(1200, 90);
            panelButtons.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1030, 22);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(150, 45);
            btnClose.TabIndex = 2;
            btnClose.Text = "✓ Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnPrint
            // 
            btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnPrint.ForeColor = System.Drawing.Color.White;
            btnPrint.Location = new System.Drawing.Point(210, 22);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new System.Drawing.Size(150, 45);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "🖨️ Print History";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnViewDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViewDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnViewDetails.ForeColor = System.Drawing.Color.White;
            btnViewDetails.Location = new System.Drawing.Point(20, 22);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new System.Drawing.Size(180, 45);
            btnViewDetails.TabIndex = 0;
            btnViewDetails.Text = "👁️ View Full Record";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += new System.EventHandler(this.BtnViewDetails_Click);
            // 
            // ShowDetailedMedicalHistoryForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            ClientSize = new System.Drawing.Size(1200, 750);
            Controls.Add(this.panelButtons);
            Controls.Add(this.dgvHistory);
            Controls.Add(this.panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShowDetailedMedicalHistoryForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Medical History";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblStats;
        private Label lblInstruction;
        private DataGridView dgvHistory;
        private Panel panelButtons;
        private Button btnViewDetails;
        private Button btnPrint;
        private Button btnClose;
    }
}