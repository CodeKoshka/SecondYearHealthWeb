namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class DispenseMedicineForm
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
            lblFormTitle = new Label();
            groupBoxOrderInfo = new GroupBox();
            lblDoctor = new Label();
            lblPatient = new Label();
            lblOrderId = new Label();
            groupBoxMedicineDetails = new GroupBox();
            lblQuantityOrdered = new Label();
            lblDosage = new Label();
            lblMedicineName = new Label();
            groupBoxInventory = new GroupBox();
            lblControlled = new Label();
            lblStockStatus = new Label();
            lblExpiryDate = new Label();
            lblBatchNumber = new Label();
            lblPrice = new Label();
            lblAvailableStock = new Label();
            cmbMedicineSelect = new ComboBox();
            label1 = new Label();
            groupBoxDispensing = new GroupBox();
            lblTotalAmount = new Label();
            txtNotes = new TextBox();
            label3 = new Label();
            txtQuantityDispense = new TextBox();
            label2 = new Label();
            panelButtons = new Panel();
            btnCancel = new Button();
            btnDispense = new Button();
            panelHeader.SuspendLayout();
            groupBoxOrderInfo.SuspendLayout();
            groupBoxMedicineDetails.SuspendLayout();
            groupBoxInventory.SuspendLayout();
            groupBoxDispensing.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            panelHeader.Controls.Add(lblFormTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(900, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblFormTitle.ForeColor = System.Drawing.Color.White;
            lblFormTitle.Location = new System.Drawing.Point(15, 15);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new System.Drawing.Size(219, 32);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Dispense Medicine";
            // 
            // groupBoxOrderInfo
            // 
            groupBoxOrderInfo.Controls.Add(lblDoctor);
            groupBoxOrderInfo.Controls.Add(lblPatient);
            groupBoxOrderInfo.Controls.Add(lblOrderId);
            groupBoxOrderInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupBoxOrderInfo.Location = new System.Drawing.Point(20, 75);
            groupBoxOrderInfo.Name = "groupBoxOrderInfo";
            groupBoxOrderInfo.Size = new System.Drawing.Size(860, 100);
            groupBoxOrderInfo.TabIndex = 1;
            groupBoxOrderInfo.TabStop = false;
            groupBoxOrderInfo.Text = "Order Information";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblDoctor.Location = new System.Drawing.Point(15, 65);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new System.Drawing.Size(81, 17);
            lblDoctor.TabIndex = 2;
            lblDoctor.Text = "Doctor: N/A";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblPatient.Location = new System.Drawing.Point(15, 43);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new System.Drawing.Size(82, 17);
            lblPatient.TabIndex = 1;
            lblPatient.Text = "Patient: N/A";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblOrderId.Location = new System.Drawing.Point(15, 21);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new System.Drawing.Size(90, 17);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Order ID: N/A";
            // 
            // groupBoxMedicineDetails
            // 
            groupBoxMedicineDetails.Controls.Add(lblQuantityOrdered);
            groupBoxMedicineDetails.Controls.Add(lblDosage);
            groupBoxMedicineDetails.Controls.Add(lblMedicineName);
            groupBoxMedicineDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupBoxMedicineDetails.Location = new System.Drawing.Point(20, 185);
            groupBoxMedicineDetails.Name = "groupBoxMedicineDetails";
            groupBoxMedicineDetails.Size = new System.Drawing.Size(860, 95);
            groupBoxMedicineDetails.TabIndex = 2;
            groupBoxMedicineDetails.TabStop = false;
            groupBoxMedicineDetails.Text = "Prescribed Medicine";
            // 
            // lblQuantityOrdered
            // 
            lblQuantityOrdered.AutoSize = true;
            lblQuantityOrdered.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblQuantityOrdered.Location = new System.Drawing.Point(15, 65);
            lblQuantityOrdered.Name = "lblQuantityOrdered";
            lblQuantityOrdered.Size = new System.Drawing.Size(145, 17);
            lblQuantityOrdered.TabIndex = 2;
            lblQuantityOrdered.Text = "Quantity Ordered: N/A";
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblDosage.Location = new System.Drawing.Point(15, 43);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new System.Drawing.Size(90, 17);
            lblDosage.TabIndex = 1;
            lblDosage.Text = "Dosage: N/A";
            // 
            // lblMedicineName
            // 
            lblMedicineName.AutoSize = true;
            lblMedicineName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblMedicineName.Location = new System.Drawing.Point(15, 21);
            lblMedicineName.Name = "lblMedicineName";
            lblMedicineName.Size = new System.Drawing.Size(101, 17);
            lblMedicineName.TabIndex = 0;
            lblMedicineName.Text = "Medicine: N/A";
            // 
            // groupBoxInventory
            // 
            groupBoxInventory.Controls.Add(lblControlled);
            groupBoxInventory.Controls.Add(lblStockStatus);
            groupBoxInventory.Controls.Add(lblExpiryDate);
            groupBoxInventory.Controls.Add(lblBatchNumber);
            groupBoxInventory.Controls.Add(lblPrice);
            groupBoxInventory.Controls.Add(lblAvailableStock);
            groupBoxInventory.Controls.Add(cmbMedicineSelect);
            groupBoxInventory.Controls.Add(label1);
            groupBoxInventory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupBoxInventory.Location = new System.Drawing.Point(20, 290);
            groupBoxInventory.Name = "groupBoxInventory";
            groupBoxInventory.Size = new System.Drawing.Size(860, 180);
            groupBoxInventory.TabIndex = 3;
            groupBoxInventory.TabStop = false;
            groupBoxInventory.Text = "Inventory Selection";
            // 
            // lblControlled
            // 
            lblControlled.AutoSize = true;
            lblControlled.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            lblControlled.ForeColor = System.Drawing.Color.Red;
            lblControlled.Location = new System.Drawing.Point(15, 150);
            lblControlled.Name = "lblControlled";
            lblControlled.Size = new System.Drawing.Size(213, 17);
            lblControlled.TabIndex = 7;
            lblControlled.Text = "⚠️ CONTROLLED SUBSTANCE";
            lblControlled.Visible = false;
            // 
            // lblStockStatus
            // 
            lblStockStatus.AutoSize = true;
            lblStockStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblStockStatus.ForeColor = System.Drawing.Color.Green;
            lblStockStatus.Location = new System.Drawing.Point(15, 125);
            lblStockStatus.Name = "lblStockStatus";
            lblStockStatus.Size = new System.Drawing.Size(128, 19);
            lblStockStatus.TabIndex = 6;
            lblStockStatus.Text = "✓ Stock available";
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblExpiryDate.Location = new System.Drawing.Point(455, 95);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new System.Drawing.Size(82, 17);
            lblExpiryDate.TabIndex = 5;
            lblExpiryDate.Text = "Expiry: N/A";
            // 
            // lblBatchNumber
            // 
            lblBatchNumber.AutoSize = true;
            lblBatchNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblBatchNumber.Location = new System.Drawing.Point(455, 70);
            lblBatchNumber.Name = "lblBatchNumber";
            lblBatchNumber.Size = new System.Drawing.Size(79, 17);
            lblBatchNumber.TabIndex = 4;
            lblBatchNumber.Text = "Batch: N/A";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblPrice.Location = new System.Drawing.Point(15, 95);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(74, 17);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Price: ₱0.00";
            // 
            // lblAvailableStock
            // 
            lblAvailableStock.AutoSize = true;
            lblAvailableStock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            lblAvailableStock.Location = new System.Drawing.Point(15, 70);
            lblAvailableStock.Name = "lblAvailableStock";
            lblAvailableStock.Size = new System.Drawing.Size(96, 17);
            lblAvailableStock.TabIndex = 2;
            lblAvailableStock.Text = "Available: N/A";
            // 
            // cmbMedicineSelect
            // 
            cmbMedicineSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMedicineSelect.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            cmbMedicineSelect.FormattingEnabled = true;
            cmbMedicineSelect.Location = new System.Drawing.Point(155, 30);
            cmbMedicineSelect.Name = "cmbMedicineSelect";
            cmbMedicineSelect.Size = new System.Drawing.Size(685, 25);
            cmbMedicineSelect.TabIndex = 1;
            cmbMedicineSelect.SelectedIndexChanged += new System.EventHandler(CmbMedicineSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            label1.Location = new System.Drawing.Point(15, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(113, 17);
            label1.TabIndex = 0;
            label1.Text = "Select Medicine:";
            // 
            // groupBoxDispensing
            // 
            groupBoxDispensing.Controls.Add(lblTotalAmount);
            groupBoxDispensing.Controls.Add(txtNotes);
            groupBoxDispensing.Controls.Add(label3);
            groupBoxDispensing.Controls.Add(txtQuantityDispense);
            groupBoxDispensing.Controls.Add(label2);
            groupBoxDispensing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            groupBoxDispensing.Location = new System.Drawing.Point(20, 480);
            groupBoxDispensing.Name = "groupBoxDispensing";
            groupBoxDispensing.Size = new System.Drawing.Size(860, 160);
            groupBoxDispensing.TabIndex = 4;
            groupBoxDispensing.TabStop = false;
            groupBoxDispensing.Text = "Dispensing Information";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            lblTotalAmount.Location = new System.Drawing.Point(350, 28);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new System.Drawing.Size(102, 21);
            lblTotalAmount.TabIndex = 4;
            lblTotalAmount.Text = "Total: ₱0.00";
            // 
            // txtNotes
            // 
            txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            txtNotes.Location = new System.Drawing.Point(155, 65);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new System.Drawing.Size(685, 80);
            txtNotes.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            label3.Location = new System.Drawing.Point(15, 68);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(48, 17);
            label3.TabIndex = 2;
            label3.Text = "Notes:";
            // 
            // txtQuantityDispense
            // 
            txtQuantityDispense.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            txtQuantityDispense.Location = new System.Drawing.Point(155, 28);
            txtQuantityDispense.Name = "txtQuantityDispense";
            txtQuantityDispense.Size = new System.Drawing.Size(150, 25);
            txtQuantityDispense.TabIndex = 1;
            txtQuantityDispense.TextChanged += new System.EventHandler(TxtQuantityDispense_TextChanged);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            label2.Location = new System.Drawing.Point(15, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(134, 17);
            label2.TabIndex = 0;
            label2.Text = "Quantity to Dispense:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnDispense);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new System.Drawing.Point(0, 650);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new System.Drawing.Size(900, 60);
            panelButtons.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(750, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(130, 38);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(BtnCancel_Click);
            // 
            // btnDispense
            // 
            btnDispense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            btnDispense.Cursor = Cursors.Hand;
            btnDispense.FlatAppearance.BorderSize = 0;
            btnDispense.FlatStyle = FlatStyle.Flat;
            btnDispense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDispense.ForeColor = System.Drawing.Color.White;
            btnDispense.Location = new System.Drawing.Point(600, 12);
            btnDispense.Name = "btnDispense";
            btnDispense.Size = new System.Drawing.Size(130, 38);
            btnDispense.TabIndex = 0;
            btnDispense.Text = "Dispense";
            btnDispense.UseVisualStyleBackColor = false;
            btnDispense.Click += new System.EventHandler(BtnDispense_Click);
            // 
            // DispenseMedicineForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(900, 710);
            Controls.Add(panelButtons);
            Controls.Add(groupBoxDispensing);
            Controls.Add(groupBoxInventory);
            Controls.Add(groupBoxMedicineDetails);
            Controls.Add(groupBoxOrderInfo);
            Controls.Add(panelHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DispenseMedicineForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dispense Medicine - St. Joseph\'s Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupBoxOrderInfo.ResumeLayout(false);
            groupBoxOrderInfo.PerformLayout();
            groupBoxMedicineDetails.ResumeLayout(false);
            groupBoxMedicineDetails.PerformLayout();
            groupBoxInventory.ResumeLayout(false);
            groupBoxInventory.PerformLayout();
            groupBoxDispensing.ResumeLayout(false);
            groupBoxDispensing.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Panel panelHeader;
        private Label lblFormTitle;
        private GroupBox groupBoxOrderInfo;
        private Label lblDoctor;
        private Label lblPatient;
        private Label lblOrderId;
        private GroupBox groupBoxMedicineDetails;
        private Label lblQuantityOrdered;
        private Label lblDosage;
        private Label lblMedicineName;
        private GroupBox groupBoxInventory;
        private Label lblControlled;
        private Label lblStockStatus;
        private Label lblExpiryDate;
        private Label lblBatchNumber;
        private Label lblPrice;
        private Label lblAvailableStock;
        private ComboBox cmbMedicineSelect;
        private Label label1;
        private GroupBox groupBoxDispensing;
        private Label lblTotalAmount;
        private TextBox txtNotes;
        private Label label3;
        private TextBox txtQuantityDispense;
        private Label label2;
        private Panel panelButtons;
        private Button btnCancel;
        private Button btnDispense;
    }
}