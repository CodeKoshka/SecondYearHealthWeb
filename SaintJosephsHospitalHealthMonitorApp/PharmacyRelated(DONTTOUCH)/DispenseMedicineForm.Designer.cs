namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class DispenseMedicineForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.GroupBox groupBoxOrderInfo;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.GroupBox groupBoxMedicineDetails;
        private System.Windows.Forms.Label lblQuantityOrdered;
        private System.Windows.Forms.Label lblDosage;
        private System.Windows.Forms.Label lblMedicineName;
        private System.Windows.Forms.GroupBox groupBoxInventory;
        private System.Windows.Forms.Label lblControlled;
        private System.Windows.Forms.Label lblStockStatus;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAvailableStock;
        private System.Windows.Forms.ComboBox cmbMedicineSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDispensing;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantityDispense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDispense;

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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.groupBoxOrderInfo = new System.Windows.Forms.GroupBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.groupBoxMedicineDetails = new System.Windows.Forms.GroupBox();
            this.lblQuantityOrdered = new System.Windows.Forms.Label();
            this.lblDosage = new System.Windows.Forms.Label();
            this.lblMedicineName = new System.Windows.Forms.Label();
            this.groupBoxInventory = new System.Windows.Forms.GroupBox();
            this.lblControlled = new System.Windows.Forms.Label();
            this.lblStockStatus = new System.Windows.Forms.Label();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAvailableStock = new System.Windows.Forms.Label();
            this.cmbMedicineSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDispensing = new System.Windows.Forms.GroupBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantityDispense = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDispense = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.groupBoxOrderInfo.SuspendLayout();
            this.groupBoxMedicineDetails.SuspendLayout();
            this.groupBoxInventory.SuspendLayout();
            this.groupBoxDispensing.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.panelHeader.Controls.Add(this.lblFormTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(900, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(15, 15);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(219, 32);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Dispense Medicine";
            // 
            // groupBoxOrderInfo
            // 
            this.groupBoxOrderInfo.Controls.Add(this.lblDoctor);
            this.groupBoxOrderInfo.Controls.Add(this.lblPatient);
            this.groupBoxOrderInfo.Controls.Add(this.lblOrderId);
            this.groupBoxOrderInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxOrderInfo.Location = new System.Drawing.Point(20, 75);
            this.groupBoxOrderInfo.Name = "groupBoxOrderInfo";
            this.groupBoxOrderInfo.Size = new System.Drawing.Size(860, 100);
            this.groupBoxOrderInfo.TabIndex = 1;
            this.groupBoxOrderInfo.TabStop = false;
            this.groupBoxOrderInfo.Text = "Order Information";
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDoctor.Location = new System.Drawing.Point(15, 65);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(81, 17);
            this.lblDoctor.TabIndex = 2;
            this.lblDoctor.Text = "Doctor: N/A";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPatient.Location = new System.Drawing.Point(15, 43);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(82, 17);
            this.lblPatient.TabIndex = 1;
            this.lblPatient.Text = "Patient: N/A";
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblOrderId.Location = new System.Drawing.Point(15, 21);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(90, 17);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Order ID: N/A";
            // 
            // groupBoxMedicineDetails
            // 
            this.groupBoxMedicineDetails.Controls.Add(this.lblQuantityOrdered);
            this.groupBoxMedicineDetails.Controls.Add(this.lblDosage);
            this.groupBoxMedicineDetails.Controls.Add(this.lblMedicineName);
            this.groupBoxMedicineDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxMedicineDetails.Location = new System.Drawing.Point(20, 185);
            this.groupBoxMedicineDetails.Name = "groupBoxMedicineDetails";
            this.groupBoxMedicineDetails.Size = new System.Drawing.Size(860, 95);
            this.groupBoxMedicineDetails.TabIndex = 2;
            this.groupBoxMedicineDetails.TabStop = false;
            this.groupBoxMedicineDetails.Text = "Prescribed Medicine";
            // 
            // lblQuantityOrdered
            // 
            this.lblQuantityOrdered.AutoSize = true;
            this.lblQuantityOrdered.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblQuantityOrdered.Location = new System.Drawing.Point(15, 65);
            this.lblQuantityOrdered.Name = "lblQuantityOrdered";
            this.lblQuantityOrdered.Size = new System.Drawing.Size(145, 17);
            this.lblQuantityOrdered.TabIndex = 2;
            this.lblQuantityOrdered.Text = "Quantity Ordered: N/A";
            // 
            // lblDosage
            // 
            this.lblDosage.AutoSize = true;
            this.lblDosage.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDosage.Location = new System.Drawing.Point(15, 43);
            this.lblDosage.Name = "lblDosage";
            this.lblDosage.Size = new System.Drawing.Size(90, 17);
            this.lblDosage.TabIndex = 1;
            this.lblDosage.Text = "Dosage: N/A";
            // 
            // lblMedicineName
            // 
            this.lblMedicineName.AutoSize = true;
            this.lblMedicineName.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblMedicineName.Location = new System.Drawing.Point(15, 21);
            this.lblMedicineName.Name = "lblMedicineName";
            this.lblMedicineName.Size = new System.Drawing.Size(101, 17);
            this.lblMedicineName.TabIndex = 0;
            this.lblMedicineName.Text = "Medicine: N/A";
            // 
            // groupBoxInventory
            // 
            this.groupBoxInventory.Controls.Add(this.lblControlled);
            this.groupBoxInventory.Controls.Add(this.lblStockStatus);
            this.groupBoxInventory.Controls.Add(this.lblExpiryDate);
            this.groupBoxInventory.Controls.Add(this.lblBatchNumber);
            this.groupBoxInventory.Controls.Add(this.lblPrice);
            this.groupBoxInventory.Controls.Add(this.lblAvailableStock);
            this.groupBoxInventory.Controls.Add(this.cmbMedicineSelect);
            this.groupBoxInventory.Controls.Add(this.label1);
            this.groupBoxInventory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxInventory.Location = new System.Drawing.Point(20, 290);
            this.groupBoxInventory.Name = "groupBoxInventory";
            this.groupBoxInventory.Size = new System.Drawing.Size(860, 180);
            this.groupBoxInventory.TabIndex = 3;
            this.groupBoxInventory.TabStop = false;
            this.groupBoxInventory.Text = "Inventory Selection";
            // 
            // lblControlled
            // 
            this.lblControlled.AutoSize = true;
            this.lblControlled.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblControlled.ForeColor = System.Drawing.Color.Red;
            this.lblControlled.Location = new System.Drawing.Point(15, 150);
            this.lblControlled.Name = "lblControlled";
            this.lblControlled.Size = new System.Drawing.Size(213, 17);
            this.lblControlled.TabIndex = 7;
            this.lblControlled.Text = "⚠️ CONTROLLED SUBSTANCE";
            this.lblControlled.Visible = false;
            // 
            // lblStockStatus
            // 
            this.lblStockStatus.AutoSize = true;
            this.lblStockStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStockStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStockStatus.Location = new System.Drawing.Point(15, 125);
            this.lblStockStatus.Name = "lblStockStatus";
            this.lblStockStatus.Size = new System.Drawing.Size(128, 19);
            this.lblStockStatus.TabIndex = 6;
            this.lblStockStatus.Text = "✓ Stock available";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblExpiryDate.Location = new System.Drawing.Point(455, 95);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(82, 17);
            this.lblExpiryDate.TabIndex = 5;
            this.lblExpiryDate.Text = "Expiry: N/A";
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblBatchNumber.Location = new System.Drawing.Point(455, 70);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(79, 17);
            this.lblBatchNumber.TabIndex = 4;
            this.lblBatchNumber.Text = "Batch: N/A";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblPrice.Location = new System.Drawing.Point(15, 95);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(74, 17);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price: ₱0.00";
            // 
            // lblAvailableStock
            // 
            this.lblAvailableStock.AutoSize = true;
            this.lblAvailableStock.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblAvailableStock.Location = new System.Drawing.Point(15, 70);
            this.lblAvailableStock.Name = "lblAvailableStock";
            this.lblAvailableStock.Size = new System.Drawing.Size(96, 17);
            this.lblAvailableStock.TabIndex = 2;
            this.lblAvailableStock.Text = "Available: N/A";
            // 
            // cmbMedicineSelect
            // 
            this.cmbMedicineSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicineSelect.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbMedicineSelect.FormattingEnabled = true;
            this.cmbMedicineSelect.Location = new System.Drawing.Point(155, 30);
            this.cmbMedicineSelect.Name = "cmbMedicineSelect";
            this.cmbMedicineSelect.Size = new System.Drawing.Size(685, 25);
            this.cmbMedicineSelect.TabIndex = 1;
            this.cmbMedicineSelect.SelectedIndexChanged += new System.EventHandler(this.CmbMedicineSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Medicine:";
            // 
            // groupBoxDispensing
            // 
            this.groupBoxDispensing.Controls.Add(this.lblTotalAmount);
            this.groupBoxDispensing.Controls.Add(this.txtNotes);
            this.groupBoxDispensing.Controls.Add(this.label3);
            this.groupBoxDispensing.Controls.Add(this.txtQuantityDispense);
            this.groupBoxDispensing.Controls.Add(this.label2);
            this.groupBoxDispensing.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxDispensing.Location = new System.Drawing.Point(20, 480);
            this.groupBoxDispensing.Name = "groupBoxDispensing";
            this.groupBoxDispensing.Size = new System.Drawing.Size(860, 160);
            this.groupBoxDispensing.TabIndex = 4;
            this.groupBoxDispensing.TabStop = false;
            this.groupBoxDispensing.Text = "Dispensing Information";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(350, 28);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(102, 21);
            this.lblTotalAmount.TabIndex = 4;
            this.lblTotalAmount.Text = "Total: ₱0.00";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNotes.Location = new System.Drawing.Point(155, 65);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(685, 80);
            this.txtNotes.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Notes:";
            // 
            // txtQuantityDispense
            // 
            this.txtQuantityDispense.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQuantityDispense.Location = new System.Drawing.Point(155, 28);
            this.txtQuantityDispense.Name = "txtQuantityDispense";
            this.txtQuantityDispense.Size = new System.Drawing.Size(150, 25);
            this.txtQuantityDispense.TabIndex = 1;
            this.txtQuantityDispense.TextChanged += new System.EventHandler(this.TxtQuantityDispense_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(15, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quantity to Dispense:";
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnCancel);
            this.panelButtons.Controls.Add(this.btnDispense);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 650);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(900, 60);
            this.panelButtons.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(750, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnDispense
            // 
            this.btnDispense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnDispense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispense.FlatAppearance.BorderSize = 0;
            this.btnDispense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDispense.ForeColor = System.Drawing.Color.White;
            this.btnDispense.Location = new System.Drawing.Point(600, 12);
            this.btnDispense.Name = "btnDispense";
            this.btnDispense.Size = new System.Drawing.Size(130, 38);
            this.btnDispense.TabIndex = 0;
            this.btnDispense.Text = "Dispense";
            this.btnDispense.UseVisualStyleBackColor = false;
            this.btnDispense.Click += new System.EventHandler(this.BtnDispense_Click);
            // 
            // DispenseMedicineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(900, 710);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.groupBoxDispensing);
            this.Controls.Add(this.groupBoxInventory);
            this.Controls.Add(this.groupBoxMedicineDetails);
            this.Controls.Add(this.groupBoxOrderInfo);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DispenseMedicineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispense Medicine - St. Joseph\'s Hospital";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.groupBoxOrderInfo.ResumeLayout(false);
            this.groupBoxOrderInfo.PerformLayout();
            this.groupBoxMedicineDetails.ResumeLayout(false);
            this.groupBoxMedicineDetails.PerformLayout();
            this.groupBoxInventory.ResumeLayout(false);
            this.groupBoxInventory.PerformLayout();
            this.groupBoxDispensing.ResumeLayout(false);
            this.groupBoxDispensing.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}