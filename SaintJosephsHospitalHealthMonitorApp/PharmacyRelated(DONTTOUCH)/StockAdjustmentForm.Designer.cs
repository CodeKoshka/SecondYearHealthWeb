namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class StockAdjustmentForm
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
            lblTitle = new Label();
            panelInfo = new Panel();
            lblMedicineName = new Label();
            lblCurrentStock = new Label();
            panelAdjustment = new Panel();
            lblAdjustmentType = new Label();
            cmbAdjustmentType = new ComboBox();
            lblQuantityChange = new Label();
            txtQuantityChange = new TextBox();
            lblNewStock = new Label();
            lblWarning = new Label();
            lblReason = new Label();
            txtReason = new TextBox();
            lblBatchNumber = new Label();
            txtBatchNumber = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelInfo.SuspendLayout();
            panelAdjustment.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(168, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Stock Adjustment";
            // 
            // panelInfo
            // 
            panelInfo.BackColor = System.Drawing.Color.White;
            panelInfo.BorderStyle = BorderStyle.FixedSingle;
            panelInfo.Controls.Add(lblMedicineName);
            panelInfo.Controls.Add(lblCurrentStock);
            panelInfo.Location = new System.Drawing.Point(20, 60);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new System.Drawing.Size(560, 80);
            panelInfo.TabIndex = 1;
            // 
            // lblMedicineName
            // 
            lblMedicineName.AutoSize = true;
            lblMedicineName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblMedicineName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            lblMedicineName.Location = new System.Drawing.Point(15, 15);
            lblMedicineName.Name = "lblMedicineName";
            lblMedicineName.Size = new System.Drawing.Size(155, 20);
            lblMedicineName.TabIndex = 0;
            lblMedicineName.Text = "Medicine: [Loading...]";
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblCurrentStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            lblCurrentStock.Location = new System.Drawing.Point(15, 45);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new System.Drawing.Size(107, 19);
            lblCurrentStock.TabIndex = 1;
            lblCurrentStock.Text = "Current Stock: 0";
            // 
            // panelAdjustment
            // 
            panelAdjustment.BackColor = System.Drawing.Color.White;
            panelAdjustment.BorderStyle = BorderStyle.FixedSingle;
            panelAdjustment.Controls.Add(lblAdjustmentType);
            panelAdjustment.Controls.Add(cmbAdjustmentType);
            panelAdjustment.Controls.Add(lblQuantityChange);
            panelAdjustment.Controls.Add(txtQuantityChange);
            panelAdjustment.Controls.Add(lblNewStock);
            panelAdjustment.Controls.Add(lblWarning);
            panelAdjustment.Controls.Add(lblReason);
            panelAdjustment.Controls.Add(txtReason);
            panelAdjustment.Controls.Add(lblBatchNumber);
            panelAdjustment.Controls.Add(txtBatchNumber);
            panelAdjustment.Controls.Add(lblNotes);
            panelAdjustment.Controls.Add(txtNotes);
            panelAdjustment.Location = new System.Drawing.Point(20, 160);
            panelAdjustment.Name = "panelAdjustment";
            panelAdjustment.Size = new System.Drawing.Size(560, 430);
            panelAdjustment.TabIndex = 2;
            // 
            // lblAdjustmentType
            // 
            lblAdjustmentType.AutoSize = true;
            lblAdjustmentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblAdjustmentType.Location = new System.Drawing.Point(15, 15);
            lblAdjustmentType.Name = "lblAdjustmentType";
            lblAdjustmentType.Size = new System.Drawing.Size(121, 19);
            lblAdjustmentType.TabIndex = 0;
            lblAdjustmentType.Text = "Adjustment Type:";
            // 
            // cmbAdjustmentType
            // 
            cmbAdjustmentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdjustmentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbAdjustmentType.FormattingEnabled = true;
            cmbAdjustmentType.Location = new System.Drawing.Point(15, 40);
            cmbAdjustmentType.Name = "cmbAdjustmentType";
            cmbAdjustmentType.Size = new System.Drawing.Size(530, 25);
            cmbAdjustmentType.TabIndex = 1;
            cmbAdjustmentType.SelectedIndexChanged += new System.EventHandler(CmbAdjustmentType_SelectedIndexChanged);
            // 
            // lblQuantityChange
            // 
            lblQuantityChange.AutoSize = true;
            lblQuantityChange.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblQuantityChange.Location = new System.Drawing.Point(15, 80);
            lblQuantityChange.Name = "lblQuantityChange";
            lblQuantityChange.Size = new System.Drawing.Size(117, 19);
            lblQuantityChange.TabIndex = 2;
            lblQuantityChange.Text = "Quantity Change:";
            // 
            // txtQuantityChange
            // 
            txtQuantityChange.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtQuantityChange.Location = new System.Drawing.Point(15, 105);
            txtQuantityChange.Name = "txtQuantityChange";
            txtQuantityChange.Size = new System.Drawing.Size(250, 25);
            txtQuantityChange.TabIndex = 3;
            txtQuantityChange.TextChanged += new System.EventHandler(TxtQuantityChange_TextChanged);
            // 
            // lblNewStock
            // 
            lblNewStock.AutoSize = true;
            lblNewStock.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblNewStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            lblNewStock.Location = new System.Drawing.Point(290, 108);
            lblNewStock.Name = "lblNewStock";
            lblNewStock.Size = new System.Drawing.Size(100, 20);
            lblNewStock.TabIndex = 4;
            lblNewStock.Text = "New Stock: 0";
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            lblWarning.Location = new System.Drawing.Point(15, 140);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new System.Drawing.Size(226, 15);
            lblWarning.TabIndex = 5;
            lblWarning.Text = "Warning: Stock cannot be negative!";
            lblWarning.Visible = false;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblReason.Location = new System.Drawing.Point(15, 170);
            lblReason.Name = "lblReason";
            lblReason.Size = new System.Drawing.Size(155, 19);
            lblReason.TabIndex = 6;
            lblReason.Text = "Reason (Required): *";
            // 
            // txtReason
            // 
            txtReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtReason.Location = new System.Drawing.Point(15, 195);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new System.Drawing.Size(530, 60);
            txtReason.TabIndex = 7;
            // 
            // lblBatchNumber
            // 
            lblBatchNumber.AutoSize = true;
            lblBatchNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBatchNumber.Location = new System.Drawing.Point(15, 270);
            lblBatchNumber.Name = "lblBatchNumber";
            lblBatchNumber.Size = new System.Drawing.Size(143, 19);
            lblBatchNumber.TabIndex = 8;
            lblBatchNumber.Text = "Batch Number (Opt):";
            // 
            // txtBatchNumber
            // 
            txtBatchNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBatchNumber.Location = new System.Drawing.Point(15, 295);
            txtBatchNumber.Name = "txtBatchNumber";
            txtBatchNumber.Size = new System.Drawing.Size(530, 25);
            txtBatchNumber.TabIndex = 9;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblNotes.Location = new System.Drawing.Point(15, 335);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new System.Drawing.Size(116, 19);
            lblNotes.TabIndex = 10;
            lblNotes.Text = "Additional Notes:";
            // 
            // txtNotes
            // 
            txtNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNotes.Location = new System.Drawing.Point(15, 360);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new System.Drawing.Size(530, 55);
            txtNotes.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(20, 610);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(270, 45);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save Adjustment";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += new System.EventHandler(BtnSave_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(310, 610);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(270, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(BtnCancel_Click);
            // 
            // StockAdjustmentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            ClientSize = new System.Drawing.Size(600, 680);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(panelAdjustment);
            Controls.Add(panelInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockAdjustmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Stock Adjustment - St. Joseph's Hospital";
            panelInfo.ResumeLayout(false);
            panelInfo.PerformLayout();
            panelAdjustment.ResumeLayout(false);
            panelAdjustment.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblMedicineName;
        private Label lblCurrentStock;
        private Label lblAdjustmentType;
        private ComboBox cmbAdjustmentType;
        private Label lblQuantityChange;
        private TextBox txtQuantityChange;
        private Label lblNewStock;
        private Label lblWarning;
        private Label lblReason;
        private TextBox txtReason;
        private Label lblBatchNumber;
        private TextBox txtBatchNumber;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelInfo;
        private Panel panelAdjustment;
    }
}