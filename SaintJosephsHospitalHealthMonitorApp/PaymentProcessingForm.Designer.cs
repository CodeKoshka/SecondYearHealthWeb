namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class PaymentProcessingForm
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
            lblSubtitle = new Label();
            panelMain = new Panel();
            panelLeft = new Panel();
            grpBillSummary = new GroupBox();
            lstServices = new ListView();
            colService = new ColumnHeader();
            colCategory = new ColumnHeader();
            colQty = new ColumnHeader();
            colUnitPrice = new ColumnHeader();
            colTotal = new ColumnHeader();
            panelBillNotes = new Panel();
            txtBillNotes = new TextBox();
            lblBillNotes = new Label();
            panelTotals = new Panel();
            lblTotalAmountValue = new Label();
            lblTotalAmount = new Label();
            lblTaxValue = new Label();
            lblTax = new Label();
            lblDiscountValue = new Label();
            lblDiscount = new Label();
            lblSubtotalValue = new Label();
            lblSubtotal = new Label();
            grpPatientInfo = new GroupBox();
            lblPatientValue = new Label();
            lblPatient = new Label();
            lblBillIdValue = new Label();
            lblBillId = new Label();
            lblStatusValue = new Label();
            lblStatus = new Label();
            panelRight = new Panel();
            grpPaymentDetails = new GroupBox();
            panelPartialPayment = new Panel();
            lblRemainingValue = new Label();
            lblRemaining = new Label();
            txtPaymentNotes = new TextBox();
            lblPaymentNotes = new Label();
            txtReferenceNumber = new TextBox();
            lblReferenceNumber = new Label();
            numPaymentAmount = new NumericUpDown();
            lblPaymentAmount = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaymentMethod = new Label();
            panelActions = new Panel();
            btnViewPaymentHistory = new Button();
            btnCancel = new Button();
            btnProcessPayment = new Button();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            panelLeft.SuspendLayout();
            grpBillSummary.SuspendLayout();
            panelBillNotes.SuspendLayout();
            panelTotals.SuspendLayout();
            grpPatientInfo.SuspendLayout();
            panelRight.SuspendLayout();
            grpPaymentDetails.SuspendLayout();
            panelPartialPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).BeginInit();
            panelActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(30, 20, 30, 20);
            panelHeader.Size = new Size(1200, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(279, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💳 Process Payment";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(30, 60);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(387, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Record payment and update billing status for this patient";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelLeft);
            panelMain.Controls.Add(panelRight);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 100);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(20);
            panelMain.Size = new Size(1200, 700);
            panelMain.TabIndex = 1;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(grpBillSummary);
            panelLeft.Controls.Add(grpPatientInfo);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(20, 20);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(0, 0, 10, 0);
            panelLeft.Size = new Size(760, 660);
            panelLeft.TabIndex = 0;
            // 
            // grpBillSummary
            // 
            grpBillSummary.BackColor = Color.White;
            grpBillSummary.Controls.Add(lstServices);
            grpBillSummary.Controls.Add(panelBillNotes);
            grpBillSummary.Controls.Add(panelTotals);
            grpBillSummary.Dock = DockStyle.Fill;
            grpBillSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpBillSummary.ForeColor = Color.FromArgb(52, 73, 94);
            grpBillSummary.Location = new Point(0, 120);
            grpBillSummary.Margin = new Padding(0, 10, 0, 0);
            grpBillSummary.Name = "grpBillSummary";
            grpBillSummary.Padding = new Padding(20);
            grpBillSummary.Size = new Size(750, 540);
            grpBillSummary.TabIndex = 1;
            grpBillSummary.TabStop = false;
            grpBillSummary.Text = "Bill Summary & Services";
            // 
            // lstServices
            // 
            lstServices.Columns.AddRange(new ColumnHeader[] { colService, colCategory, colQty, colUnitPrice, colTotal });
            lstServices.Dock = DockStyle.Fill;
            lstServices.Font = new Font("Segoe UI", 9F);
            lstServices.FullRowSelect = true;
            lstServices.GridLines = true;
            lstServices.Location = new Point(20, 153);
            lstServices.Name = "lstServices";
            lstServices.Size = new Size(710, 250);
            lstServices.TabIndex = 0;
            lstServices.UseCompatibleStateImageBehavior = false;
            lstServices.View = View.Details;
            // 
            // colService
            // 
            colService.Text = "Service/Item";
            colService.Width = 250;
            // 
            // colCategory
            // 
            colCategory.Text = "Category";
            colCategory.Width = 150;
            // 
            // colQty
            // 
            colQty.Text = "Qty";
            // 
            // colUnitPrice
            // 
            colUnitPrice.Text = "Unit Price";
            colUnitPrice.Width = 120;
            // 
            // colTotal
            // 
            colTotal.Text = "Total";
            colTotal.Width = 120;
            // 
            // panelBillNotes
            // 
            panelBillNotes.BackColor = Color.FromArgb(255, 250, 235);
            panelBillNotes.Controls.Add(txtBillNotes);
            panelBillNotes.Controls.Add(lblBillNotes);
            panelBillNotes.Dock = DockStyle.Bottom;
            panelBillNotes.Location = new Point(20, 403);
            panelBillNotes.Name = "panelBillNotes";
            panelBillNotes.Padding = new Padding(10);
            panelBillNotes.Size = new Size(710, 117);
            panelBillNotes.TabIndex = 2;
            // 
            // txtBillNotes
            // 
            txtBillNotes.BackColor = Color.FromArgb(255, 250, 235);
            txtBillNotes.BorderStyle = BorderStyle.None;
            txtBillNotes.Dock = DockStyle.Fill;
            txtBillNotes.Font = new Font("Segoe UI", 9F);
            txtBillNotes.ForeColor = Color.FromArgb(113, 128, 150);
            txtBillNotes.Location = new Point(10, 40);
            txtBillNotes.Multiline = true;
            txtBillNotes.Name = "txtBillNotes";
            txtBillNotes.ReadOnly = true;
            txtBillNotes.ScrollBars = ScrollBars.Vertical;
            txtBillNotes.Size = new Size(690, 67);
            txtBillNotes.TabIndex = 1;
            // 
            // lblBillNotes
            // 
            lblBillNotes.AutoSize = true;
            lblBillNotes.Dock = DockStyle.Top;
            lblBillNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBillNotes.ForeColor = Color.FromArgb(113, 128, 150);
            lblBillNotes.Location = new Point(10, 10);
            lblBillNotes.Name = "lblBillNotes";
            lblBillNotes.Padding = new Padding(0, 5, 0, 10);
            lblBillNotes.Size = new Size(76, 30);
            lblBillNotes.TabIndex = 0;
            lblBillNotes.Text = "📝 Bill Notes";
            // 
            // panelTotals
            // 
            panelTotals.BackColor = Color.FromArgb(249, 250, 251);
            panelTotals.Controls.Add(lblTotalAmountValue);
            panelTotals.Controls.Add(lblTotalAmount);
            panelTotals.Controls.Add(lblTaxValue);
            panelTotals.Controls.Add(lblTax);
            panelTotals.Controls.Add(lblDiscountValue);
            panelTotals.Controls.Add(lblDiscount);
            panelTotals.Controls.Add(lblSubtotalValue);
            panelTotals.Controls.Add(lblSubtotal);
            panelTotals.Dock = DockStyle.Top;
            panelTotals.Location = new Point(20, 38);
            panelTotals.Name = "panelTotals";
            panelTotals.Padding = new Padding(10);
            panelTotals.Size = new Size(710, 115);
            panelTotals.TabIndex = 1;
            // 
            // lblTotalAmountValue
            // 
            lblTotalAmountValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalAmountValue.ForeColor = Color.FromArgb(52, 152, 219);
            lblTotalAmountValue.Location = new Point(450, 80);
            lblTotalAmountValue.Name = "lblTotalAmountValue";
            lblTotalAmountValue.Size = new Size(250, 25);
            lblTotalAmountValue.TabIndex = 7;
            lblTotalAmountValue.Text = "₱0.00";
            lblTotalAmountValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotalAmount.Location = new Point(13, 83);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(136, 21);
            lblTotalAmount.TabIndex = 6;
            lblTotalAmount.Text = "TOTAL AMOUNT:";
            // 
            // lblTaxValue
            // 
            lblTaxValue.Font = new Font("Segoe UI", 10F);
            lblTaxValue.ForeColor = Color.FromArgb(26, 32, 44);
            lblTaxValue.Location = new Point(450, 50);
            lblTaxValue.Name = "lblTaxValue";
            lblTaxValue.Size = new Size(250, 20);
            lblTaxValue.TabIndex = 5;
            lblTaxValue.Text = "₱0.00 (0%)";
            lblTaxValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTax
            // 
            lblTax.AutoSize = true;
            lblTax.Font = new Font("Segoe UI", 10F);
            lblTax.ForeColor = Color.FromArgb(113, 128, 150);
            lblTax.Location = new Point(13, 50);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(30, 19);
            lblTax.TabIndex = 4;
            lblTax.Text = "Tax:";
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.Font = new Font("Segoe UI", 10F);
            lblDiscountValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblDiscountValue.Location = new Point(450, 30);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(250, 20);
            lblDiscountValue.TabIndex = 3;
            lblDiscountValue.Text = "-₱0.00 (0%)";
            lblDiscountValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F);
            lblDiscount.ForeColor = Color.FromArgb(113, 128, 150);
            lblDiscount.Location = new Point(13, 30);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(66, 19);
            lblDiscount.TabIndex = 2;
            lblDiscount.Text = "Discount:";
            // 
            // lblSubtotalValue
            // 
            lblSubtotalValue.Font = new Font("Segoe UI", 10F);
            lblSubtotalValue.ForeColor = Color.FromArgb(26, 32, 44);
            lblSubtotalValue.Location = new Point(450, 10);
            lblSubtotalValue.Name = "lblSubtotalValue";
            lblSubtotalValue.Size = new Size(250, 20);
            lblSubtotalValue.TabIndex = 1;
            lblSubtotalValue.Text = "₱0.00";
            lblSubtotalValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F);
            lblSubtotal.ForeColor = Color.FromArgb(113, 128, 150);
            lblSubtotal.Location = new Point(13, 10);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(63, 19);
            lblSubtotal.TabIndex = 0;
            lblSubtotal.Text = "Subtotal:";
            // 
            // grpPatientInfo
            // 
            grpPatientInfo.BackColor = Color.White;
            grpPatientInfo.Controls.Add(lblPatientValue);
            grpPatientInfo.Controls.Add(lblPatient);
            grpPatientInfo.Controls.Add(lblBillIdValue);
            grpPatientInfo.Controls.Add(lblBillId);
            grpPatientInfo.Controls.Add(lblStatusValue);
            grpPatientInfo.Controls.Add(lblStatus);
            grpPatientInfo.Dock = DockStyle.Top;
            grpPatientInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPatientInfo.ForeColor = Color.FromArgb(52, 73, 94);
            grpPatientInfo.Location = new Point(0, 0);
            grpPatientInfo.Name = "grpPatientInfo";
            grpPatientInfo.Padding = new Padding(20);
            grpPatientInfo.Size = new Size(750, 120);
            grpPatientInfo.TabIndex = 0;
            grpPatientInfo.TabStop = false;
            grpPatientInfo.Text = "Patient & Bill Information";
            // 
            // lblPatientValue
            // 
            lblPatientValue.AutoSize = true;
            lblPatientValue.Font = new Font("Segoe UI", 11F);
            lblPatientValue.ForeColor = Color.FromArgb(26, 32, 44);
            lblPatientValue.Location = new Point(150, 35);
            lblPatientValue.Name = "lblPatientValue";
            lblPatientValue.Size = new Size(98, 20);
            lblPatientValue.TabIndex = 1;
            lblPatientValue.Text = "Patient Name";
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Font = new Font("Segoe UI", 10F);
            lblPatient.ForeColor = Color.FromArgb(113, 128, 150);
            lblPatient.Location = new Point(23, 36);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(95, 19);
            lblPatient.TabIndex = 0;
            lblPatient.Text = "Patient Name:";
            // 
            // lblBillIdValue
            // 
            lblBillIdValue.AutoSize = true;
            lblBillIdValue.Font = new Font("Segoe UI", 11F);
            lblBillIdValue.ForeColor = Color.FromArgb(26, 32, 44);
            lblBillIdValue.Location = new Point(150, 65);
            lblBillIdValue.Name = "lblBillIdValue";
            lblBillIdValue.Size = new Size(42, 20);
            lblBillIdValue.TabIndex = 3;
            lblBillIdValue.Text = "#000";
            // 
            // lblBillId
            // 
            lblBillId.AutoSize = true;
            lblBillId.Font = new Font("Segoe UI", 10F);
            lblBillId.ForeColor = Color.FromArgb(113, 128, 150);
            lblBillId.Location = new Point(23, 66);
            lblBillId.Name = "lblBillId";
            lblBillId.Size = new Size(47, 19);
            lblBillId.TabIndex = 2;
            lblBillId.Text = "Bill ID:";
            // 
            // lblStatusValue
            // 
            lblStatusValue.AutoSize = true;
            lblStatusValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatusValue.ForeColor = Color.FromArgb(243, 156, 18);
            lblStatusValue.Location = new Point(150, 95);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(66, 20);
            lblStatusValue.TabIndex = 5;
            lblStatusValue.Text = "Pending";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.FromArgb(113, 128, 150);
            lblStatus.Location = new Point(23, 96);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 19);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status:";
            // 
            // panelRight
            // 
            panelRight.Controls.Add(grpPaymentDetails);
            panelRight.Controls.Add(panelActions);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(780, 20);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10, 0, 0, 0);
            panelRight.Size = new Size(400, 660);
            panelRight.TabIndex = 1;
            // 
            // grpPaymentDetails
            // 
            grpPaymentDetails.BackColor = Color.White;
            grpPaymentDetails.Controls.Add(panelPartialPayment);
            grpPaymentDetails.Controls.Add(txtPaymentNotes);
            grpPaymentDetails.Controls.Add(lblPaymentNotes);
            grpPaymentDetails.Controls.Add(txtReferenceNumber);
            grpPaymentDetails.Controls.Add(lblReferenceNumber);
            grpPaymentDetails.Controls.Add(numPaymentAmount);
            grpPaymentDetails.Controls.Add(lblPaymentAmount);
            grpPaymentDetails.Controls.Add(cmbPaymentMethod);
            grpPaymentDetails.Controls.Add(lblPaymentMethod);
            grpPaymentDetails.Dock = DockStyle.Fill;
            grpPaymentDetails.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPaymentDetails.ForeColor = Color.FromArgb(52, 73, 94);
            grpPaymentDetails.Location = new Point(10, 0);
            grpPaymentDetails.Name = "grpPaymentDetails";
            grpPaymentDetails.Padding = new Padding(20);
            grpPaymentDetails.Size = new Size(390, 500);
            grpPaymentDetails.TabIndex = 0;
            grpPaymentDetails.TabStop = false;
            grpPaymentDetails.Text = "Payment Details";
            // 
            // panelPartialPayment
            // 
            panelPartialPayment.BackColor = Color.FromArgb(255, 250, 235);
            panelPartialPayment.Controls.Add(lblRemainingValue);
            panelPartialPayment.Controls.Add(lblRemaining);
            panelPartialPayment.Location = new Point(23, 160);
            panelPartialPayment.Name = "panelPartialPayment";
            panelPartialPayment.Padding = new Padding(10);
            panelPartialPayment.Size = new Size(344, 50);
            panelPartialPayment.TabIndex = 9;
            panelPartialPayment.Visible = false;
            // 
            // lblRemainingValue
            // 
            lblRemainingValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRemainingValue.ForeColor = Color.FromArgb(243, 156, 18);
            lblRemainingValue.Location = new Point(170, 13);
            lblRemainingValue.Name = "lblRemainingValue";
            lblRemainingValue.Size = new Size(164, 22);
            lblRemainingValue.TabIndex = 1;
            lblRemainingValue.Text = "₱0.00";
            lblRemainingValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Segoe UI", 10F);
            lblRemaining.ForeColor = Color.FromArgb(113, 128, 150);
            lblRemaining.Location = new Point(10, 15);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(126, 19);
            lblRemaining.TabIndex = 0;
            lblRemaining.Text = "Remaining Balance:";
            // 
            // txtPaymentNotes
            // 
            txtPaymentNotes.Font = new Font("Segoe UI", 9F);
            txtPaymentNotes.Location = new Point(23, 298);
            txtPaymentNotes.Multiline = true;
            txtPaymentNotes.Name = "txtPaymentNotes";
            txtPaymentNotes.PlaceholderText = "Enter any additional notes about this payment...";
            txtPaymentNotes.ScrollBars = ScrollBars.Vertical;
            txtPaymentNotes.Size = new Size(344, 179);
            txtPaymentNotes.TabIndex = 7;
            // 
            // lblPaymentNotes
            // 
            lblPaymentNotes.AutoSize = true;
            lblPaymentNotes.Font = new Font("Segoe UI", 9F);
            lblPaymentNotes.ForeColor = Color.FromArgb(113, 128, 150);
            lblPaymentNotes.Location = new Point(23, 278);
            lblPaymentNotes.Name = "lblPaymentNotes";
            lblPaymentNotes.Size = new Size(91, 15);
            lblPaymentNotes.TabIndex = 6;
            lblPaymentNotes.Text = "Payment Notes:";
            // 
            // txtReferenceNumber
            // 
            txtReferenceNumber.Font = new Font("Segoe UI", 10F);
            txtReferenceNumber.Location = new Point(23, 238);
            txtReferenceNumber.Name = "txtReferenceNumber";
            txtReferenceNumber.PlaceholderText = "Transaction/Check/Reference #";
            txtReferenceNumber.Size = new Size(344, 25);
            txtReferenceNumber.TabIndex = 5;
            // 
            // lblReferenceNumber
            // 
            lblReferenceNumber.AutoSize = true;
            lblReferenceNumber.Font = new Font("Segoe UI", 9F);
            lblReferenceNumber.ForeColor = Color.FromArgb(113, 128, 150);
            lblReferenceNumber.Location = new Point(23, 218);
            lblReferenceNumber.Name = "lblReferenceNumber";
            lblReferenceNumber.Size = new Size(166, 15);
            lblReferenceNumber.TabIndex = 4;
            lblReferenceNumber.Text = "Reference Number (Optional):";
            // 
            // numPaymentAmount
            // 
            numPaymentAmount.DecimalPlaces = 2;
            numPaymentAmount.Font = new Font("Segoe UI", 12F);
            numPaymentAmount.Location = new Point(23, 125);
            numPaymentAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPaymentAmount.Name = "numPaymentAmount";
            numPaymentAmount.Size = new Size(344, 29);
            numPaymentAmount.TabIndex = 3;
            numPaymentAmount.ThousandsSeparator = true;
            numPaymentAmount.ValueChanged += NumPaymentAmount_ValueChanged;
            // 
            // lblPaymentAmount
            // 
            lblPaymentAmount.AutoSize = true;
            lblPaymentAmount.Font = new Font("Segoe UI", 9F);
            lblPaymentAmount.ForeColor = Color.FromArgb(113, 128, 150);
            lblPaymentAmount.Location = new Point(23, 105);
            lblPaymentAmount.Name = "lblPaymentAmount";
            lblPaymentAmount.Size = new Size(104, 15);
            lblPaymentAmount.TabIndex = 2;
            lblPaymentAmount.Text = "Payment Amount:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 10F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(23, 58);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(344, 25);
            cmbPaymentMethod.TabIndex = 1;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 9F);
            lblPaymentMethod.ForeColor = Color.FromArgb(113, 128, 150);
            lblPaymentMethod.Location = new Point(23, 38);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(102, 15);
            lblPaymentMethod.TabIndex = 0;
            lblPaymentMethod.Text = "Payment Method:";
            // 
            // panelActions
            // 
            panelActions.BackColor = Color.White;
            panelActions.Controls.Add(btnViewPaymentHistory);
            panelActions.Controls.Add(btnCancel);
            panelActions.Controls.Add(btnProcessPayment);
            panelActions.Dock = DockStyle.Bottom;
            panelActions.Location = new Point(10, 500);
            panelActions.Name = "panelActions";
            panelActions.Padding = new Padding(20);
            panelActions.Size = new Size(390, 160);
            panelActions.TabIndex = 1;
            // 
            // btnViewPaymentHistory
            // 
            btnViewPaymentHistory.BackColor = Color.FromArgb(149, 165, 166);
            btnViewPaymentHistory.Cursor = Cursors.Hand;
            btnViewPaymentHistory.FlatAppearance.BorderSize = 0;
            btnViewPaymentHistory.FlatStyle = FlatStyle.Flat;
            btnViewPaymentHistory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewPaymentHistory.ForeColor = Color.White;
            btnViewPaymentHistory.Location = new Point(23, 90);
            btnViewPaymentHistory.Name = "btnViewPaymentHistory";
            btnViewPaymentHistory.Size = new Size(344, 40);
            btnViewPaymentHistory.TabIndex = 3;
            btnViewPaymentHistory.Text = "📜 Payment History";
            btnViewPaymentHistory.UseVisualStyleBackColor = false;
            btnViewPaymentHistory.Click += BtnViewPaymentHistory_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(202, 23);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "✕ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnProcessPayment
            // 
            btnProcessPayment.BackColor = Color.FromArgb(46, 204, 113);
            btnProcessPayment.Cursor = Cursors.Hand;
            btnProcessPayment.FlatAppearance.BorderSize = 0;
            btnProcessPayment.FlatStyle = FlatStyle.Flat;
            btnProcessPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcessPayment.ForeColor = Color.White;
            btnProcessPayment.Location = new Point(23, 23);
            btnProcessPayment.Name = "btnProcessPayment";
            btnProcessPayment.Size = new Size(165, 50);
            btnProcessPayment.TabIndex = 0;
            btnProcessPayment.Text = "✓ Process Payment";
            btnProcessPayment.UseVisualStyleBackColor = false;
            btnProcessPayment.Click += BtnProcessPayment_Click;
            // 
            // PaymentProcessingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 800);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaymentProcessingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payment Processing - St. Joseph's Hospital";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            grpBillSummary.ResumeLayout(false);
            panelBillNotes.ResumeLayout(false);
            panelBillNotes.PerformLayout();
            panelTotals.ResumeLayout(false);
            panelTotals.PerformLayout();
            grpPatientInfo.ResumeLayout(false);
            grpPatientInfo.PerformLayout();
            panelRight.ResumeLayout(false);
            grpPaymentDetails.ResumeLayout(false);
            grpPaymentDetails.PerformLayout();
            panelPartialPayment.ResumeLayout(false);
            panelPartialPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).EndInit();
            panelActions.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.GroupBox grpPatientInfo;
        private System.Windows.Forms.Label lblPatientValue;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblBillIdValue;
        private System.Windows.Forms.Label lblBillId;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpBillSummary;
        private System.Windows.Forms.ListView lstServices;
        private System.Windows.Forms.ColumnHeader colService;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colUnitPrice;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Panel panelTotals;
        private System.Windows.Forms.Label lblTotalAmountValue;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTaxValue;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblDiscountValue;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblSubtotalValue;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Panel panelBillNotes;
        private System.Windows.Forms.TextBox txtBillNotes;
        private System.Windows.Forms.Label lblBillNotes;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox grpPaymentDetails;
        private System.Windows.Forms.Panel panelPartialPayment;
        private System.Windows.Forms.Label lblRemainingValue;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.TextBox txtPaymentNotes;
        private System.Windows.Forms.Label lblPaymentNotes;
        private System.Windows.Forms.TextBox txtReferenceNumber;
        private System.Windows.Forms.Label lblReferenceNumber;
        private System.Windows.Forms.NumericUpDown numPaymentAmount;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnViewPaymentHistory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProcessPayment;
    }
}