namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class StockAdjustmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMedicineName;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Label lblAdjustmentType;
        private System.Windows.Forms.ComboBox cmbAdjustmentType;
        private System.Windows.Forms.Label lblQuantityChange;
        private System.Windows.Forms.TextBox txtQuantityChange;
        private System.Windows.Forms.Label lblNewStock;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelAdjustment;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblMedicineName = new System.Windows.Forms.Label();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.panelAdjustment = new System.Windows.Forms.Panel();
            this.lblAdjustmentType = new System.Windows.Forms.Label();
            this.cmbAdjustmentType = new System.Windows.Forms.ComboBox();
            this.lblQuantityChange = new System.Windows.Forms.Label();
            this.txtQuantityChange = new System.Windows.Forms.TextBox();
            this.lblNewStock = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelInfo.SuspendLayout();
            this.panelAdjustment.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Stock Adjustment";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInfo.Controls.Add(this.lblMedicineName);
            this.panelInfo.Controls.Add(this.lblCurrentStock);
            this.panelInfo.Location = new System.Drawing.Point(20, 60);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(560, 80);
            this.panelInfo.TabIndex = 1;
            // 
            // lblMedicineName
            // 
            this.lblMedicineName.AutoSize = true;
            this.lblMedicineName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMedicineName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMedicineName.Location = new System.Drawing.Point(15, 15);
            this.lblMedicineName.Name = "lblMedicineName";
            this.lblMedicineName.Size = new System.Drawing.Size(155, 20);
            this.lblMedicineName.TabIndex = 0;
            this.lblMedicineName.Text = "Medicine: [Loading...]";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrentStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCurrentStock.Location = new System.Drawing.Point(15, 45);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(107, 19);
            this.lblCurrentStock.TabIndex = 1;
            this.lblCurrentStock.Text = "Current Stock: 0";
            // 
            // panelAdjustment
            // 
            this.panelAdjustment.BackColor = System.Drawing.Color.White;
            this.panelAdjustment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAdjustment.Controls.Add(this.lblAdjustmentType);
            this.panelAdjustment.Controls.Add(this.cmbAdjustmentType);
            this.panelAdjustment.Controls.Add(this.lblQuantityChange);
            this.panelAdjustment.Controls.Add(this.txtQuantityChange);
            this.panelAdjustment.Controls.Add(this.lblNewStock);
            this.panelAdjustment.Controls.Add(this.lblWarning);
            this.panelAdjustment.Controls.Add(this.lblReason);
            this.panelAdjustment.Controls.Add(this.txtReason);
            this.panelAdjustment.Controls.Add(this.lblBatchNumber);
            this.panelAdjustment.Controls.Add(this.txtBatchNumber);
            this.panelAdjustment.Controls.Add(this.lblNotes);
            this.panelAdjustment.Controls.Add(this.txtNotes);
            this.panelAdjustment.Location = new System.Drawing.Point(20, 160);
            this.panelAdjustment.Name = "panelAdjustment";
            this.panelAdjustment.Size = new System.Drawing.Size(560, 430);
            this.panelAdjustment.TabIndex = 2;
            // 
            // lblAdjustmentType
            // 
            this.lblAdjustmentType.AutoSize = true;
            this.lblAdjustmentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAdjustmentType.Location = new System.Drawing.Point(15, 15);
            this.lblAdjustmentType.Name = "lblAdjustmentType";
            this.lblAdjustmentType.Size = new System.Drawing.Size(121, 19);
            this.lblAdjustmentType.TabIndex = 0;
            this.lblAdjustmentType.Text = "Adjustment Type:";
            // 
            // cmbAdjustmentType
            // 
            this.cmbAdjustmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdjustmentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAdjustmentType.FormattingEnabled = true;
            this.cmbAdjustmentType.Location = new System.Drawing.Point(15, 40);
            this.cmbAdjustmentType.Name = "cmbAdjustmentType";
            this.cmbAdjustmentType.Size = new System.Drawing.Size(530, 25);
            this.cmbAdjustmentType.TabIndex = 1;
            this.cmbAdjustmentType.SelectedIndexChanged += new System.EventHandler(this.CmbAdjustmentType_SelectedIndexChanged);
            // 
            // lblQuantityChange
            // 
            this.lblQuantityChange.AutoSize = true;
            this.lblQuantityChange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQuantityChange.Location = new System.Drawing.Point(15, 80);
            this.lblQuantityChange.Name = "lblQuantityChange";
            this.lblQuantityChange.Size = new System.Drawing.Size(117, 19);
            this.lblQuantityChange.TabIndex = 2;
            this.lblQuantityChange.Text = "Quantity Change:";
            // 
            // txtQuantityChange
            // 
            this.txtQuantityChange.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQuantityChange.Location = new System.Drawing.Point(15, 105);
            this.txtQuantityChange.Name = "txtQuantityChange";
            this.txtQuantityChange.Size = new System.Drawing.Size(250, 25);
            this.txtQuantityChange.TabIndex = 3;
            this.txtQuantityChange.TextChanged += new System.EventHandler(this.TxtQuantityChange_TextChanged);
            // 
            // lblNewStock
            // 
            this.lblNewStock.AutoSize = true;
            this.lblNewStock.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNewStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblNewStock.Location = new System.Drawing.Point(290, 108);
            this.lblNewStock.Name = "lblNewStock";
            this.lblNewStock.Size = new System.Drawing.Size(100, 20);
            this.lblNewStock.TabIndex = 4;
            this.lblNewStock.Text = "New Stock: 0";
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblWarning.Location = new System.Drawing.Point(15, 140);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(226, 15);
            this.lblWarning.TabIndex = 5;
            this.lblWarning.Text = "Warning: Stock cannot be negative!";
            this.lblWarning.Visible = false;
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblReason.Location = new System.Drawing.Point(15, 170);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(155, 19);
            this.lblReason.TabIndex = 6;
            this.lblReason.Text = "Reason (Required): *";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtReason.Location = new System.Drawing.Point(15, 195);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(530, 60);
            this.txtReason.TabIndex = 7;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBatchNumber.Location = new System.Drawing.Point(15, 270);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(143, 19);
            this.lblBatchNumber.TabIndex = 8;
            this.lblBatchNumber.Text = "Batch Number (Opt):";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBatchNumber.Location = new System.Drawing.Point(15, 295);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(530, 25);
            this.txtBatchNumber.TabIndex = 9;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNotes.Location = new System.Drawing.Point(15, 335);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(116, 19);
            this.lblNotes.TabIndex = 10;
            this.lblNotes.Text = "Additional Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNotes.Location = new System.Drawing.Point(15, 360);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(530, 55);
            this.txtNotes.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 610);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(270, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Adjustment";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(310, 610);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(270, 45);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // StockAdjustmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(600, 680);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelAdjustment);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockAdjustmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Adjustment - St. Joseph's Hospital";
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelAdjustment.ResumeLayout(false);
            this.panelAdjustment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}