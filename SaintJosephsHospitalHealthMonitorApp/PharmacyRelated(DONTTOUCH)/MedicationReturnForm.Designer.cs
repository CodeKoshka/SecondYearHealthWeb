namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class MedicationReturnForm
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
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label1 = new Label();
            dgvDispensingRecords = new DataGridView();
            groupBox2 = new GroupBox();
            lblReturnWarning = new Label();
            chkReturnToStock = new CheckBox();
            lblRefundAmount = new Label();
            txtNotes = new TextBox();
            label7 = new Label();
            txtReturnReason = new TextBox();
            label6 = new Label();
            cmbReturnType = new ComboBox();
            label5 = new Label();
            txtQuantityReturn = new NumericUpDown();
            label4 = new Label();
            lblUnitPrice = new Label();
            lblQuantityDispensed = new Label();
            lblSelectedDispense = new Label();
            panel1 = new Panel();
            btnCancel = new Button();
            btnProcessReturn = new Button();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvDispensingRecords)).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(txtQuantityReturn)).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvDispensingRecords);
            groupBox1.Location = new System.Drawing.Point(12, 52);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(960, 320);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Recent Dispensing Records (Last 30 Days)";
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(856, 23);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(90, 26);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(546, 25);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(300, 22);
            txtSearch.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(395, 28);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(145, 16);
            label1.TabIndex = 1;
            label1.Text = "Search Patient/Medicine:";
            // 
            // dgvDispensingRecords
            // 
            dgvDispensingRecords.AllowUserToAddRows = false;
            dgvDispensingRecords.AllowUserToDeleteRows = false;
            dgvDispensingRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDispensingRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDispensingRecords.Location = new System.Drawing.Point(15, 55);
            dgvDispensingRecords.MultiSelect = false;
            dgvDispensingRecords.Name = "dgvDispensingRecords";
            dgvDispensingRecords.ReadOnly = true;
            dgvDispensingRecords.RowHeadersWidth = 51;
            dgvDispensingRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDispensingRecords.Size = new System.Drawing.Size(931, 250);
            dgvDispensingRecords.TabIndex = 0;
            dgvDispensingRecords.SelectionChanged += new System.EventHandler(DgvDispensingRecords_SelectionChanged);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblReturnWarning);
            groupBox2.Controls.Add(chkReturnToStock);
            groupBox2.Controls.Add(lblRefundAmount);
            groupBox2.Controls.Add(txtNotes);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtReturnReason);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cmbReturnType);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtQuantityReturn);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lblUnitPrice);
            groupBox2.Controls.Add(lblQuantityDispensed);
            groupBox2.Controls.Add(lblSelectedDispense);
            groupBox2.Location = new System.Drawing.Point(12, 378);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(960, 290);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Return Details";
            // 
            // lblReturnWarning
            // 
            lblReturnWarning.AutoSize = true;
            lblReturnWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblReturnWarning.ForeColor = System.Drawing.Color.Green;
            lblReturnWarning.Location = new System.Drawing.Point(230, 258);
            lblReturnWarning.Name = "lblReturnWarning";
            lblReturnWarning.Size = new System.Drawing.Size(269, 18);
            lblReturnWarning.TabIndex = 13;
            lblReturnWarning.Text = "Medicine will be returned to inventory";
            // 
            // chkReturnToStock
            // 
            chkReturnToStock.AutoSize = true;
            chkReturnToStock.Checked = true;
            chkReturnToStock.CheckState = CheckState.Checked;
            chkReturnToStock.Location = new System.Drawing.Point(20, 257);
            chkReturnToStock.Name = "chkReturnToStock";
            chkReturnToStock.Size = new System.Drawing.Size(204, 20);
            chkReturnToStock.TabIndex = 12;
            chkReturnToStock.Text = "Return Medicine to Inventory";
            chkReturnToStock.UseVisualStyleBackColor = true;
            chkReturnToStock.CheckedChanged += new System.EventHandler(ChkReturnToStock_CheckedChanged);
            // 
            // lblRefundAmount
            // 
            lblRefundAmount.AutoSize = true;
            lblRefundAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            lblRefundAmount.ForeColor = System.Drawing.Color.DarkGreen;
            lblRefundAmount.Location = new System.Drawing.Point(700, 257);
            lblRefundAmount.Name = "lblRefundAmount";
            lblRefundAmount.Size = new System.Drawing.Size(160, 20);
            lblRefundAmount.TabIndex = 11;
            lblRefundAmount.Text = "Refund Amount: ₱0";
            // 
            // txtNotes
            // 
            txtNotes.Location = new System.Drawing.Point(500, 180);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new System.Drawing.Size(440, 60);
            txtNotes.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(497, 161);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(107, 16);
            label7.TabIndex = 9;
            label7.Text = "Additional Notes:";
            // 
            // txtReturnReason
            // 
            txtReturnReason.Location = new System.Drawing.Point(20, 180);
            txtReturnReason.Multiline = true;
            txtReturnReason.Name = "txtReturnReason";
            txtReturnReason.Size = new System.Drawing.Size(460, 60);
            txtReturnReason.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(17, 161);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(134, 16);
            label6.TabIndex = 7;
            label6.Text = "Return Reason (Required):";
            // 
            // cmbReturnType
            // 
            cmbReturnType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReturnType.FormattingEnabled = true;
            cmbReturnType.Location = new System.Drawing.Point(630, 122);
            cmbReturnType.Name = "cmbReturnType";
            cmbReturnType.Size = new System.Drawing.Size(310, 24);
            cmbReturnType.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(627, 103);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(85, 16);
            label5.TabIndex = 5;
            label5.Text = "Return Type:";
            // 
            // txtQuantityReturn
            // 
            txtQuantityReturn.Location = new System.Drawing.Point(20, 122);
            txtQuantityReturn.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            txtQuantityReturn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtQuantityReturn.Name = "txtQuantityReturn";
            txtQuantityReturn.Size = new System.Drawing.Size(150, 22);
            txtQuantityReturn.TabIndex = 4;
            txtQuantityReturn.Value = new decimal(new int[] { 1, 0, 0, 0 });
            txtQuantityReturn.ValueChanged += new System.EventHandler(TxtQuantityReturn_ValueChanged);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 103);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(107, 16);
            label4.TabIndex = 3;
            label4.Text = "Quantity to Return:";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new System.Drawing.Point(17, 70);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new System.Drawing.Size(76, 16);
            lblUnitPrice.TabIndex = 2;
            lblUnitPrice.Text = "Unit Price: ₱0";
            // 
            // lblQuantityDispensed
            // 
            lblQuantityDispensed.AutoSize = true;
            lblQuantityDispensed.Location = new System.Drawing.Point(17, 48);
            lblQuantityDispensed.Name = "lblQuantityDispensed";
            lblQuantityDispensed.Size = new System.Drawing.Size(136, 16);
            lblQuantityDispensed.TabIndex = 1;
            lblQuantityDispensed.Text = "Quantity Dispensed: 0";
            // 
            // lblSelectedDispense
            // 
            lblSelectedDispense.AutoSize = true;
            lblSelectedDispense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            lblSelectedDispense.Location = new System.Drawing.Point(17, 25);
            lblSelectedDispense.Name = "lblSelectedDispense";
            lblSelectedDispense.Size = new System.Drawing.Size(244, 18);
            lblSelectedDispense.TabIndex = 0;
            lblSelectedDispense.Text = "Selected: No record selected";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnProcessReturn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 674);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(984, 60);
            panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(860, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 35);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new System.EventHandler(BtnCancel_Click);
            // 
            // btnProcessReturn
            // 
            btnProcessReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            btnProcessReturn.FlatStyle = FlatStyle.Flat;
            btnProcessReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            btnProcessReturn.ForeColor = System.Drawing.Color.White;
            btnProcessReturn.Location = new System.Drawing.Point(720, 15);
            btnProcessReturn.Name = "btnProcessReturn";
            btnProcessReturn.Size = new System.Drawing.Size(130, 35);
            btnProcessReturn.TabIndex = 0;
            btnProcessReturn.Text = "Process Return";
            btnProcessReturn.UseVisualStyleBackColor = false;
            btnProcessReturn.Click += new System.EventHandler(BtnProcessReturn_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(12, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(198, 29);
            label2.TabIndex = 3;
            label2.Text = "Medication Return";
            // 
            // MedicationReturnForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 734);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MedicationReturnForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Medication Return - St. Joseph\'s Hospital";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvDispensingRecords)).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(txtQuantityReturn)).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvDispensingRecords;
        private GroupBox groupBox2;
        private Panel panel1;
        private Button btnProcessReturn;
        private Button btnCancel;
        private Label label1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblSelectedDispense;
        private Label lblQuantityDispensed;
        private Label lblUnitPrice;
        private Label label4;
        private NumericUpDown txtQuantityReturn;
        private ComboBox cmbReturnType;
        private Label label5;
        private TextBox txtReturnReason;
        private Label label6;
        private TextBox txtNotes;
        private Label label7;
        private Label lblRefundAmount;
        private CheckBox chkReturnToStock;
        private Label lblReturnWarning;
        private Label label2;
    }
}