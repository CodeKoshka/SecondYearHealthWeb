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
            lblTitle = new Label();
            lblPatient = new Label();
            cmbPatient = new ComboBox();
            grpServices = new GroupBox();
            btnRemoveService = new Button();
            btnAddService = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbServiceItem = new ComboBox();
            lblServiceItem = new Label();
            cmbServiceCategory = new ComboBox();
            lblServiceCategory = new Label();
            lstServices = new ListView();
            grpCalculations = new GroupBox();
            lblGrandTotal = new Label();
            lblTaxAmount = new Label();
            lblDiscountAmount = new Label();
            lblSubtotal = new Label();
            numTax = new NumericUpDown();
            lblTaxLabel = new Label();
            numDiscount = new NumericUpDown();
            lblDiscountLabel = new Label();
            grpPaymentInfo = new GroupBox();
            txtNotes = new TextBox();
            lblNotes = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaymentMethod = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            btnPrintPreview = new Button();
            grpServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            grpCalculations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).BeginInit();
            grpPaymentInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(214, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create New Invoice";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPatient.ForeColor = Color.FromArgb(52, 73, 94);
            lblPatient.Location = new Point(20, 70);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(50, 15);
            lblPatient.TabIndex = 1;
            lblPatient.Text = "Patient:";
            // 
            // cmbPatient
            // 
            cmbPatient.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPatient.Font = new Font("Segoe UI", 10F);
            cmbPatient.FormattingEnabled = true;
            cmbPatient.Location = new Point(20, 95);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(520, 25);
            cmbPatient.TabIndex = 2;
            // 
            // grpServices
            // 
            grpServices.Controls.Add(btnRemoveService);
            grpServices.Controls.Add(btnAddService);
            grpServices.Controls.Add(numQuantity);
            grpServices.Controls.Add(lblQuantity);
            grpServices.Controls.Add(cmbServiceItem);
            grpServices.Controls.Add(lblServiceItem);
            grpServices.Controls.Add(cmbServiceCategory);
            grpServices.Controls.Add(lblServiceCategory);
            grpServices.Controls.Add(lstServices);
            grpServices.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpServices.Location = new Point(20, 140);
            grpServices.Name = "grpServices";
            grpServices.Size = new Size(880, 364);
            grpServices.TabIndex = 3;
            grpServices.TabStop = false;
            grpServices.Text = "Services / Items";
            // 
            // btnRemoveService
            // 
            btnRemoveService.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveService.Cursor = Cursors.Hand;
            btnRemoveService.FlatAppearance.BorderSize = 0;
            btnRemoveService.FlatStyle = FlatStyle.Flat;
            btnRemoveService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveService.ForeColor = Color.White;
            btnRemoveService.Location = new Point(750, 65);
            btnRemoveService.Name = "btnRemoveService";
            btnRemoveService.Size = new Size(110, 35);
            btnRemoveService.TabIndex = 8;
            btnRemoveService.Text = "Remove";
            btnRemoveService.UseVisualStyleBackColor = false;
            btnRemoveService.Click += BtnRemoveService_Click;
            // 
            // btnAddService
            // 
            btnAddService.BackColor = Color.FromArgb(46, 204, 113);
            btnAddService.Cursor = Cursors.Hand;
            btnAddService.FlatAppearance.BorderSize = 0;
            btnAddService.FlatStyle = FlatStyle.Flat;
            btnAddService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddService.ForeColor = Color.White;
            btnAddService.Location = new Point(620, 65);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(110, 35);
            btnAddService.TabIndex = 7;
            btnAddService.Text = "Add Service";
            btnAddService.UseVisualStyleBackColor = false;
            btnAddService.Click += BtnAddService_Click;
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 9F);
            numQuantity.Location = new Point(490, 70);
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(100, 23);
            numQuantity.TabIndex = 6;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9F);
            lblQuantity.Location = new Point(490, 45);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "Quantity:";
            // 
            // cmbServiceItem
            // 
            cmbServiceItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServiceItem.Font = new Font("Segoe UI", 9F);
            cmbServiceItem.FormattingEnabled = true;
            cmbServiceItem.Location = new Point(240, 70);
            cmbServiceItem.Name = "cmbServiceItem";
            cmbServiceItem.Size = new Size(230, 23);
            cmbServiceItem.TabIndex = 4;
            // 
            // lblServiceItem
            // 
            lblServiceItem.AutoSize = true;
            lblServiceItem.Font = new Font("Segoe UI", 9F);
            lblServiceItem.Location = new Point(240, 45);
            lblServiceItem.Name = "lblServiceItem";
            lblServiceItem.Size = new Size(76, 15);
            lblServiceItem.TabIndex = 3;
            lblServiceItem.Text = "Service/Item:";
            // 
            // cmbServiceCategory
            // 
            cmbServiceCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbServiceCategory.Font = new Font("Segoe UI", 9F);
            cmbServiceCategory.FormattingEnabled = true;
            cmbServiceCategory.Location = new Point(20, 70);
            cmbServiceCategory.Name = "cmbServiceCategory";
            cmbServiceCategory.Size = new Size(200, 23);
            cmbServiceCategory.TabIndex = 2;
            cmbServiceCategory.SelectedIndexChanged += CmbServiceCategory_SelectedIndexChanged;
            // 
            // lblServiceCategory
            // 
            lblServiceCategory.AutoSize = true;
            lblServiceCategory.Font = new Font("Segoe UI", 9F);
            lblServiceCategory.Location = new Point(20, 45);
            lblServiceCategory.Name = "lblServiceCategory";
            lblServiceCategory.Size = new Size(58, 15);
            lblServiceCategory.TabIndex = 1;
            lblServiceCategory.Text = "Category:";
            // 
            // lstServices
            // 
            lstServices.Font = new Font("Segoe UI", 9F);
            lstServices.FullRowSelect = true;
            lstServices.GridLines = true;
            lstServices.Location = new Point(20, 106);
            lstServices.Name = "lstServices";
            lstServices.Size = new Size(840, 238);
            lstServices.TabIndex = 0;
            lstServices.UseCompatibleStateImageBehavior = false;
            lstServices.View = View.Details;
            // 
            // grpCalculations
            // 
            grpCalculations.Controls.Add(lblGrandTotal);
            grpCalculations.Controls.Add(lblTaxAmount);
            grpCalculations.Controls.Add(lblDiscountAmount);
            grpCalculations.Controls.Add(lblSubtotal);
            grpCalculations.Controls.Add(numTax);
            grpCalculations.Controls.Add(lblTaxLabel);
            grpCalculations.Controls.Add(numDiscount);
            grpCalculations.Controls.Add(lblDiscountLabel);
            grpCalculations.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpCalculations.Location = new Point(560, 510);
            grpCalculations.Name = "grpCalculations";
            grpCalculations.Size = new Size(340, 220);
            grpCalculations.TabIndex = 4;
            grpCalculations.TabStop = false;
            grpCalculations.Text = "Bill Summary";
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGrandTotal.ForeColor = Color.FromArgb(41, 128, 185);
            lblGrandTotal.Location = new Point(20, 180);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(147, 21);
            lblGrandTotal.TabIndex = 7;
            lblGrandTotal.Text = "Grand Total: ₱0.00";
            // 
            // lblTaxAmount
            // 
            lblTaxAmount.AutoSize = true;
            lblTaxAmount.Font = new Font("Segoe UI", 10F);
            lblTaxAmount.Location = new Point(20, 145);
            lblTaxAmount.Name = "lblTaxAmount";
            lblTaxAmount.Size = new Size(100, 19);
            lblTaxAmount.TabIndex = 6;
            lblTaxAmount.Text = "Tax (0%): ₱0.00";
            // 
            // lblDiscountAmount
            // 
            lblDiscountAmount.AutoSize = true;
            lblDiscountAmount.Font = new Font("Segoe UI", 10F);
            lblDiscountAmount.Location = new Point(20, 115);
            lblDiscountAmount.Name = "lblDiscountAmount";
            lblDiscountAmount.Size = new Size(142, 19);
            lblDiscountAmount.TabIndex = 5;
            lblDiscountAmount.Text = "Discount (0%): -₱0.00";
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F);
            lblSubtotal.Location = new Point(20, 85);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(102, 19);
            lblSubtotal.TabIndex = 4;
            lblSubtotal.Text = "Subtotal: ₱0.00";
            // 
            // numTax
            // 
            numTax.DecimalPlaces = 2;
            numTax.Font = new Font("Segoe UI", 9F);
            numTax.Location = new Point(220, 50);
            numTax.Name = "numTax";
            numTax.Size = new Size(100, 23);
            numTax.TabIndex = 3;
            numTax.ValueChanged += NumTax_ValueChanged;
            // 
            // lblTaxLabel
            // 
            lblTaxLabel.AutoSize = true;
            lblTaxLabel.Font = new Font("Segoe UI", 9F);
            lblTaxLabel.Location = new Point(220, 30);
            lblTaxLabel.Name = "lblTaxLabel";
            lblTaxLabel.Size = new Size(40, 15);
            lblTaxLabel.TabIndex = 2;
            lblTaxLabel.Text = "Tax %:";
            // 
            // numDiscount
            // 
            numDiscount.DecimalPlaces = 2;
            numDiscount.Font = new Font("Segoe UI", 9F);
            numDiscount.Location = new Point(20, 50);
            numDiscount.Name = "numDiscount";
            numDiscount.Size = new Size(100, 23);
            numDiscount.TabIndex = 1;
            numDiscount.ValueChanged += NumDiscount_ValueChanged;
            // 
            // lblDiscountLabel
            // 
            lblDiscountLabel.AutoSize = true;
            lblDiscountLabel.Font = new Font("Segoe UI", 9F);
            lblDiscountLabel.Location = new Point(20, 30);
            lblDiscountLabel.Name = "lblDiscountLabel";
            lblDiscountLabel.Size = new Size(70, 15);
            lblDiscountLabel.TabIndex = 0;
            lblDiscountLabel.Text = "Discount %:";
            // 
            // grpPaymentInfo
            // 
            grpPaymentInfo.Controls.Add(txtNotes);
            grpPaymentInfo.Controls.Add(lblNotes);
            grpPaymentInfo.Controls.Add(cmbStatus);
            grpPaymentInfo.Controls.Add(lblStatus);
            grpPaymentInfo.Controls.Add(cmbPaymentMethod);
            grpPaymentInfo.Controls.Add(lblPaymentMethod);
            grpPaymentInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpPaymentInfo.Location = new Point(20, 510);
            grpPaymentInfo.Name = "grpPaymentInfo";
            grpPaymentInfo.Size = new Size(520, 220);
            grpPaymentInfo.TabIndex = 5;
            grpPaymentInfo.TabStop = false;
            grpPaymentInfo.Text = "Payment Information";
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Segoe UI", 9F);
            txtNotes.Location = new Point(20, 120);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(480, 80);
            txtNotes.TabIndex = 5;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F);
            lblNotes.Location = new Point(20, 95);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(99, 15);
            lblNotes.TabIndex = 4;
            lblNotes.Text = "Additional Notes:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 9F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Partially Paid", "Cancelled" });
            cmbStatus.Location = new Point(270, 50);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(230, 23);
            cmbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(270, 30);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 9F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "Debit Card", "Check", "Bank Transfer", "Insurance", "Mixed Payment" });
            cmbPaymentMethod.Location = new Point(20, 50);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(230, 23);
            cmbPaymentMethod.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 9F);
            lblPaymentMethod.Location = new Point(20, 30);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(102, 15);
            lblPaymentMethod.TabIndex = 0;
            lblPaymentMethod.Text = "Payment Method:";
            lblPaymentMethod.Visible = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(560, 750);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save Invoice";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(730, 750);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnPrintPreview
            // 
            btnPrintPreview.BackColor = Color.FromArgb(52, 152, 219);
            btnPrintPreview.Cursor = Cursors.Hand;
            btnPrintPreview.FlatAppearance.BorderSize = 0;
            btnPrintPreview.FlatStyle = FlatStyle.Flat;
            btnPrintPreview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrintPreview.ForeColor = Color.White;
            btnPrintPreview.Location = new Point(20, 750);
            btnPrintPreview.Name = "btnPrintPreview";
            btnPrintPreview.Size = new Size(150, 45);
            btnPrintPreview.TabIndex = 8;
            btnPrintPreview.Text = "Print Preview";
            btnPrintPreview.UseVisualStyleBackColor = false;
            btnPrintPreview.Click += BtnPrintPreview_Click;
            // 
            // BillingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(920, 820);
            Controls.Add(btnPrintPreview);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(grpPaymentInfo);
            Controls.Add(grpCalculations);
            Controls.Add(grpServices);
            Controls.Add(cmbPatient);
            Controls.Add(lblPatient);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "BillingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Invoice Management";
            grpServices.ResumeLayout(false);
            grpServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            grpCalculations.ResumeLayout(false);
            grpCalculations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDiscount).EndInit();
            grpPaymentInfo.ResumeLayout(false);
            grpPaymentInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}