namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.GroupBox grpServices;
        private System.Windows.Forms.Label lblServiceCategory;
        private System.Windows.Forms.ComboBox cmbServiceCategory;
        private System.Windows.Forms.Label lblServiceItem;
        private System.Windows.Forms.ComboBox cmbServiceItem;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.ListView lstServices;
        private System.Windows.Forms.GroupBox grpCalculations;
        private System.Windows.Forms.Label lblDiscountLabel;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblTaxLabel;
        private System.Windows.Forms.NumericUpDown numTax;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblTaxAmount;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.GroupBox grpPaymentInfo;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPrintPreview;

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
            this.lblPatient = new System.Windows.Forms.Label();
            this.cmbPatient = new System.Windows.Forms.ComboBox();
            this.grpServices = new System.Windows.Forms.GroupBox();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbServiceItem = new System.Windows.Forms.ComboBox();
            this.lblServiceItem = new System.Windows.Forms.Label();
            this.cmbServiceCategory = new System.Windows.Forms.ComboBox();
            this.lblServiceCategory = new System.Windows.Forms.Label();
            this.lstServices = new System.Windows.Forms.ListView();
            this.grpCalculations = new System.Windows.Forms.GroupBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblTaxAmount = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.numTax = new System.Windows.Forms.NumericUpDown();
            this.lblTaxLabel = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblDiscountLabel = new System.Windows.Forms.Label();
            this.grpPaymentInfo = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.grpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.grpCalculations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.grpPaymentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(216, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create New Invoice";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPatient.Location = new System.Drawing.Point(20, 70);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(88, 15);
            this.lblPatient.TabIndex = 1;
            this.lblPatient.Text = "Select Patient:";
            // 
            // cmbPatient
            // 
            this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPatient.FormattingEnabled = true;
            this.cmbPatient.Location = new System.Drawing.Point(20, 95);
            this.cmbPatient.Name = "cmbPatient";
            this.cmbPatient.Size = new System.Drawing.Size(520, 23);
            this.cmbPatient.TabIndex = 2;
            // 
            // grpServices
            // 
            this.grpServices.Controls.Add(this.btnRemoveService);
            this.grpServices.Controls.Add(this.btnAddService);
            this.grpServices.Controls.Add(this.numQuantity);
            this.grpServices.Controls.Add(this.lblQuantity);
            this.grpServices.Controls.Add(this.cmbServiceItem);
            this.grpServices.Controls.Add(this.lblServiceItem);
            this.grpServices.Controls.Add(this.cmbServiceCategory);
            this.grpServices.Controls.Add(this.lblServiceCategory);
            this.grpServices.Controls.Add(this.lstServices);
            this.grpServices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpServices.Location = new System.Drawing.Point(20, 140);
            this.grpServices.Name = "grpServices";
            this.grpServices.Size = new System.Drawing.Size(880, 350);
            this.grpServices.TabIndex = 3;
            this.grpServices.TabStop = false;
            this.grpServices.Text = "Services / Items";
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveService.FlatAppearance.BorderSize = 0;
            this.btnRemoveService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveService.ForeColor = System.Drawing.Color.White;
            this.btnRemoveService.Location = new System.Drawing.Point(750, 65);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(110, 35);
            this.btnRemoveService.TabIndex = 8;
            this.btnRemoveService.Text = "Remove";
            this.btnRemoveService.UseVisualStyleBackColor = false;
            this.btnRemoveService.Click += new System.EventHandler(this.BtnRemoveService_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddService.FlatAppearance.BorderSize = 0;
            this.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddService.ForeColor = System.Drawing.Color.White;
            this.btnAddService.Location = new System.Drawing.Point(620, 65);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(110, 35);
            this.btnAddService.TabIndex = 7;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = false;
            this.btnAddService.Click += new System.EventHandler(this.BtnAddService_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numQuantity.Location = new System.Drawing.Point(490, 70);
            this.numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(100, 23);
            this.numQuantity.TabIndex = 6;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantity.Location = new System.Drawing.Point(490, 45);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 15);
            this.lblQuantity.TabIndex = 5;
            this.lblQuantity.Text = "Quantity:";
            // 
            // cmbServiceItem
            // 
            this.cmbServiceItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbServiceItem.FormattingEnabled = true;
            this.cmbServiceItem.Location = new System.Drawing.Point(240, 70);
            this.cmbServiceItem.Name = "cmbServiceItem";
            this.cmbServiceItem.Size = new System.Drawing.Size(230, 23);
            this.cmbServiceItem.TabIndex = 4;
            // 
            // lblServiceItem
            // 
            this.lblServiceItem.AutoSize = true;
            this.lblServiceItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServiceItem.Location = new System.Drawing.Point(240, 45);
            this.lblServiceItem.Name = "lblServiceItem";
            this.lblServiceItem.Size = new System.Drawing.Size(77, 15);
            this.lblServiceItem.TabIndex = 3;
            this.lblServiceItem.Text = "Service/Item:";
            // 
            // cmbServiceCategory
            // 
            this.cmbServiceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbServiceCategory.FormattingEnabled = true;
            this.cmbServiceCategory.Location = new System.Drawing.Point(20, 70);
            this.cmbServiceCategory.Name = "cmbServiceCategory";
            this.cmbServiceCategory.Size = new System.Drawing.Size(200, 23);
            this.cmbServiceCategory.TabIndex = 2;
            this.cmbServiceCategory.SelectedIndexChanged += new System.EventHandler(this.CmbServiceCategory_SelectedIndexChanged);
            // 
            // lblServiceCategory
            // 
            this.lblServiceCategory.AutoSize = true;
            this.lblServiceCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServiceCategory.Location = new System.Drawing.Point(20, 45);
            this.lblServiceCategory.Name = "lblServiceCategory";
            this.lblServiceCategory.Size = new System.Drawing.Size(58, 15);
            this.lblServiceCategory.TabIndex = 1;
            this.lblServiceCategory.Text = "Category:";
            // 
            // lstServices
            // 
            this.lstServices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstServices.FullRowSelect = true;
            this.lstServices.GridLines = true;
            this.lstServices.HideSelection = false;
            this.lstServices.Location = new System.Drawing.Point(20, 120);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(840, 210);
            this.lstServices.TabIndex = 0;
            this.lstServices.UseCompatibleStateImageBehavior = false;
            this.lstServices.View = System.Windows.Forms.View.Details;
            // 
            // grpCalculations
            // 
            this.grpCalculations.Controls.Add(this.lblGrandTotal);
            this.grpCalculations.Controls.Add(this.lblTaxAmount);
            this.grpCalculations.Controls.Add(this.lblDiscountAmount);
            this.grpCalculations.Controls.Add(this.lblSubtotal);
            this.grpCalculations.Controls.Add(this.numTax);
            this.grpCalculations.Controls.Add(this.lblTaxLabel);
            this.grpCalculations.Controls.Add(this.numDiscount);
            this.grpCalculations.Controls.Add(this.lblDiscountLabel);
            this.grpCalculations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCalculations.Location = new System.Drawing.Point(560, 510);
            this.grpCalculations.Name = "grpCalculations";
            this.grpCalculations.Size = new System.Drawing.Size(340, 220);
            this.grpCalculations.TabIndex = 4;
            this.grpCalculations.TabStop = false;
            this.grpCalculations.Text = "Bill Summary";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblGrandTotal.Location = new System.Drawing.Point(20, 180);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(143, 21);
            this.lblGrandTotal.TabIndex = 7;
            this.lblGrandTotal.Text = "Grand Total: $0.00";
            // 
            // lblTaxAmount
            // 
            this.lblTaxAmount.AutoSize = true;
            this.lblTaxAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxAmount.Location = new System.Drawing.Point(20, 145);
            this.lblTaxAmount.Name = "lblTaxAmount";
            this.lblTaxAmount.Size = new System.Drawing.Size(100, 19);
            this.lblTaxAmount.TabIndex = 6;
            this.lblTaxAmount.Text = "Tax (0%): $0.00";
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountAmount.Location = new System.Drawing.Point(20, 115);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(145, 19);
            this.lblDiscountAmount.TabIndex = 5;
            this.lblDiscountAmount.Text = "Discount (0%): -$0.00";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtotal.Location = new System.Drawing.Point(20, 85);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(104, 19);
            this.lblSubtotal.TabIndex = 4;
            this.lblSubtotal.Text = "Subtotal: $0.00";
            // 
            // numTax
            // 
            this.numTax.DecimalPlaces = 2;
            this.numTax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTax.Location = new System.Drawing.Point(220, 50);
            this.numTax.Name = "numTax";
            this.numTax.Size = new System.Drawing.Size(100, 23);
            this.numTax.TabIndex = 3;
            this.numTax.ValueChanged += new System.EventHandler(this.NumTax_ValueChanged);
            // 
            // lblTaxLabel
            // 
            this.lblTaxLabel.AutoSize = true;
            this.lblTaxLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTaxLabel.Location = new System.Drawing.Point(220, 30);
            this.lblTaxLabel.Name = "lblTaxLabel";
            this.lblTaxLabel.Size = new System.Drawing.Size(44, 15);
            this.lblTaxLabel.TabIndex = 2;
            this.lblTaxLabel.Text = "Tax %:";
            // 
            // numDiscount
            // 
            this.numDiscount.DecimalPlaces = 2;
            this.numDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDiscount.Location = new System.Drawing.Point(20, 50);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(100, 23);
            this.numDiscount.TabIndex = 1;
            this.numDiscount.ValueChanged += new System.EventHandler(this.NumDiscount_ValueChanged);
            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.AutoSize = true;
            this.lblDiscountLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscountLabel.Location = new System.Drawing.Point(20, 30);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(74, 15);
            this.lblDiscountLabel.TabIndex = 0;
            this.lblDiscountLabel.Text = "Discount %:";
            // 
            // grpPaymentInfo
            // 
            this.grpPaymentInfo.Controls.Add(this.txtNotes);
            this.grpPaymentInfo.Controls.Add(this.lblNotes);
            this.grpPaymentInfo.Controls.Add(this.cmbStatus);
            this.grpPaymentInfo.Controls.Add(this.lblStatus);
            this.grpPaymentInfo.Controls.Add(this.cmbPaymentMethod);
            this.grpPaymentInfo.Controls.Add(this.lblPaymentMethod);
            this.grpPaymentInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpPaymentInfo.Location = new System.Drawing.Point(20, 510);
            this.grpPaymentInfo.Name = "grpPaymentInfo";
            this.grpPaymentInfo.Size = new System.Drawing.Size(520, 220);
            this.grpPaymentInfo.TabIndex = 5;
            this.grpPaymentInfo.TabStop = false;
            this.grpPaymentInfo.Text = "Payment Information";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.Location = new System.Drawing.Point(20, 140);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(480, 60);
            this.txtNotes.TabIndex = 5;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNotes.Location = new System.Drawing.Point(20, 115);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(96, 15);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Additional Notes:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Paid",
            "Partially Paid",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(280, 50);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(220, 23);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(280, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Credit Card",
            "Debit Card",
            "Check",
            "Bank Transfer",
            "Insurance",
            "Mixed Payment"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(20, 50);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(240, 23);
            this.cmbPaymentMethod.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 30);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(104, 15);
            this.lblPaymentMethod.TabIndex = 0;
            this.lblPaymentMethod.Text = "Payment Method:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(560, 750);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Invoice";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(730, 750);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 45);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrintPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintPreview.FlatAppearance.BorderSize = 0;
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintPreview.ForeColor = System.Drawing.Color.White;
            this.btnPrintPreview.Location = new System.Drawing.Point(20, 750);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(150, 45);
            this.btnPrintPreview.TabIndex = 8;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.BtnPrintPreview_Click);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(920, 820);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpPaymentInfo);
            this.Controls.Add(this.grpCalculations);
            this.Controls.Add(this.grpServices);
            this.Controls.Add(this.cmbPatient);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BillingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoice Management";
            this.grpServices.ResumeLayout(false);
            this.grpServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.grpCalculations.ResumeLayout(false);
            this.grpCalculations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.grpPaymentInfo.ResumeLayout(false);
            this.grpPaymentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}