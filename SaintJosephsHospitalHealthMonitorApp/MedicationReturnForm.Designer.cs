namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class MedicationReturnForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDispensingRecords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProcessReturn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSelectedDispense;
        private System.Windows.Forms.Label lblQuantityDispensed;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtQuantityReturn;
        private System.Windows.Forms.ComboBox cmbReturnType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReturnReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRefundAmount;
        private System.Windows.Forms.CheckBox chkReturnToStock;
        private System.Windows.Forms.Label lblReturnWarning;
        private System.Windows.Forms.Label label2;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDispensingRecords = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblReturnWarning = new System.Windows.Forms.Label();
            this.chkReturnToStock = new System.Windows.Forms.CheckBox();
            this.lblRefundAmount = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReturnReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbReturnType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantityReturn = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblQuantityDispensed = new System.Windows.Forms.Label();
            this.lblSelectedDispense = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProcessReturn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispensingRecords)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityReturn)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvDispensingRecords);
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 320);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recent Dispensing Records (Last 30 Days)";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(856, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(546, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search Patient/Medicine:";
            // 
            // dgvDispensingRecords
            // 
            this.dgvDispensingRecords.AllowUserToAddRows = false;
            this.dgvDispensingRecords.AllowUserToDeleteRows = false;
            this.dgvDispensingRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDispensingRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispensingRecords.Location = new System.Drawing.Point(15, 55);
            this.dgvDispensingRecords.MultiSelect = false;
            this.dgvDispensingRecords.Name = "dgvDispensingRecords";
            this.dgvDispensingRecords.ReadOnly = true;
            this.dgvDispensingRecords.RowHeadersWidth = 51;
            this.dgvDispensingRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDispensingRecords.Size = new System.Drawing.Size(931, 250);
            this.dgvDispensingRecords.TabIndex = 0;
            this.dgvDispensingRecords.SelectionChanged += new System.EventHandler(this.DgvDispensingRecords_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblReturnWarning);
            this.groupBox2.Controls.Add(this.chkReturnToStock);
            this.groupBox2.Controls.Add(this.lblRefundAmount);
            this.groupBox2.Controls.Add(this.txtNotes);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtReturnReason);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbReturnType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtQuantityReturn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblUnitPrice);
            this.groupBox2.Controls.Add(this.lblQuantityDispensed);
            this.groupBox2.Controls.Add(this.lblSelectedDispense);
            this.groupBox2.Location = new System.Drawing.Point(12, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 290);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Return Details";
            // 
            // lblReturnWarning
            // 
            this.lblReturnWarning.AutoSize = true;
            this.lblReturnWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblReturnWarning.ForeColor = System.Drawing.Color.Green;
            this.lblReturnWarning.Location = new System.Drawing.Point(230, 258);
            this.lblReturnWarning.Name = "lblReturnWarning";
            this.lblReturnWarning.Size = new System.Drawing.Size(269, 18);
            this.lblReturnWarning.TabIndex = 13;
            this.lblReturnWarning.Text = "Medicine will be returned to inventory";
            // 
            // chkReturnToStock
            // 
            this.chkReturnToStock.AutoSize = true;
            this.chkReturnToStock.Checked = true;
            this.chkReturnToStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReturnToStock.Location = new System.Drawing.Point(20, 257);
            this.chkReturnToStock.Name = "chkReturnToStock";
            this.chkReturnToStock.Size = new System.Drawing.Size(204, 20);
            this.chkReturnToStock.TabIndex = 12;
            this.chkReturnToStock.Text = "Return Medicine to Inventory";
            this.chkReturnToStock.UseVisualStyleBackColor = true;
            this.chkReturnToStock.CheckedChanged += new System.EventHandler(this.ChkReturnToStock_CheckedChanged);
            // 
            // lblRefundAmount
            // 
            this.lblRefundAmount.AutoSize = true;
            this.lblRefundAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRefundAmount.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblRefundAmount.Location = new System.Drawing.Point(700, 257);
            this.lblRefundAmount.Name = "lblRefundAmount";
            this.lblRefundAmount.Size = new System.Drawing.Size(160, 20);
            this.lblRefundAmount.TabIndex = 11;
            this.lblRefundAmount.Text = "Refund Amount: ₱0";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(500, 180);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(440, 60);
            this.txtNotes.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(497, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Additional Notes:";
            // 
            // txtReturnReason
            // 
            this.txtReturnReason.Location = new System.Drawing.Point(20, 180);
            this.txtReturnReason.Multiline = true;
            this.txtReturnReason.Name = "txtReturnReason";
            this.txtReturnReason.Size = new System.Drawing.Size(460, 60);
            this.txtReturnReason.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Return Reason (Required):";
            // 
            // cmbReturnType
            // 
            this.cmbReturnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnType.FormattingEnabled = true;
            this.cmbReturnType.Location = new System.Drawing.Point(630, 122);
            this.cmbReturnType.Name = "cmbReturnType";
            this.cmbReturnType.Size = new System.Drawing.Size(310, 24);
            this.cmbReturnType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(627, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Return Type:";
            // 
            // txtQuantityReturn
            // 
            this.txtQuantityReturn.Location = new System.Drawing.Point(20, 122);
            this.txtQuantityReturn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQuantityReturn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantityReturn.Name = "txtQuantityReturn";
            this.txtQuantityReturn.Size = new System.Drawing.Size(150, 22);
            this.txtQuantityReturn.TabIndex = 4;
            this.txtQuantityReturn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantityReturn.ValueChanged += new System.EventHandler(this.TxtQuantityReturn_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity to Return:";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(17, 70);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(76, 16);
            this.lblUnitPrice.TabIndex = 2;
            this.lblUnitPrice.Text = "Unit Price: ₱0";
            // 
            // lblQuantityDispensed
            // 
            this.lblQuantityDispensed.AutoSize = true;
            this.lblQuantityDispensed.Location = new System.Drawing.Point(17, 48);
            this.lblQuantityDispensed.Name = "lblQuantityDispensed";
            this.lblQuantityDispensed.Size = new System.Drawing.Size(136, 16);
            this.lblQuantityDispensed.TabIndex = 1;
            this.lblQuantityDispensed.Text = "Quantity Dispensed: 0";
            // 
            // lblSelectedDispense
            // 
            this.lblSelectedDispense.AutoSize = true;
            this.lblSelectedDispense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedDispense.Location = new System.Drawing.Point(17, 25);
            this.lblSelectedDispense.Name = "lblSelectedDispense";
            this.lblSelectedDispense.Size = new System.Drawing.Size(244, 18);
            this.lblSelectedDispense.TabIndex = 0;
            this.lblSelectedDispense.Text = "Selected: No record selected";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnProcessReturn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 674);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 60);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(860, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnProcessReturn
            // 
            this.btnProcessReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnProcessReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnProcessReturn.ForeColor = System.Drawing.Color.White;
            this.btnProcessReturn.Location = new System.Drawing.Point(720, 15);
            this.btnProcessReturn.Name = "btnProcessReturn";
            this.btnProcessReturn.Size = new System.Drawing.Size(130, 35);
            this.btnProcessReturn.TabIndex = 0;
            this.btnProcessReturn.Text = "Process Return";
            this.btnProcessReturn.UseVisualStyleBackColor = false;
            this.btnProcessReturn.Click += new System.EventHandler(this.BtnProcessReturn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medication Return";
            // 
            // MedicationReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 734);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedicationReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Medication Return - St. Joseph\'s Hospital";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispensingRecords)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantityReturn)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}