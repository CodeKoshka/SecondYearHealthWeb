
namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ManageInventoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblMedicineName;
        private System.Windows.Forms.TextBox txtMedicineName;
        private System.Windows.Forms.Label lblGenericName;
        private System.Windows.Forms.TextBox txtGenericName;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDosageForm;
        private System.Windows.Forms.ComboBox cmbDosageForm;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.TextBox txtStrength;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblReorderLevel;
        private System.Windows.Forms.TextBox txtReorderLevel;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.TextBox txtCostPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.TextBox txtBatchNumber;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Label lblStorageLocation;
        private System.Windows.Forms.TextBox txtStorageLocation;
        private System.Windows.Forms.CheckBox chkControlled;
        private System.Windows.Forms.CheckBox chkRequiresApproval;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdjustStock;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Button btnClose;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblMedicineName = new System.Windows.Forms.Label();
            this.txtMedicineName = new System.Windows.Forms.TextBox();
            this.lblGenericName = new System.Windows.Forms.Label();
            this.txtGenericName = new System.Windows.Forms.TextBox();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDosageForm = new System.Windows.Forms.Label();
            this.cmbDosageForm = new System.Windows.Forms.ComboBox();
            this.lblStrength = new System.Windows.Forms.Label();
            this.txtStrength = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblReorderLevel = new System.Windows.Forms.Label();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.txtCostPrice = new System.Windows.Forms.TextBox();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.txtBatchNumber = new System.Windows.Forms.TextBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblStorageLocation = new System.Windows.Forms.Label();
            this.txtStorageLocation = new System.Windows.Forms.TextBox();
            this.chkControlled = new System.Windows.Forms.CheckBox();
            this.chkRequiresApproval = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdjustStock = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblTotalItems);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 70);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(296, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Medicine Inventory";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalItems.ForeColor = System.Drawing.Color.White;
            this.lblTotalItems.Location = new System.Drawing.Point(22, 45);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(88, 19);
            this.lblTotalItems.TabIndex = 1;
            this.lblTotalItems.Text = "Total Items: 0";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1270, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.White;
            this.panelLeft.Controls.Add(this.lblMedicineName);
            this.panelLeft.Controls.Add(this.txtMedicineName);
            this.panelLeft.Controls.Add(this.lblGenericName);
            this.panelLeft.Controls.Add(this.txtGenericName);
            this.panelLeft.Controls.Add(this.lblBrandName);
            this.panelLeft.Controls.Add(this.txtBrandName);
            this.panelLeft.Controls.Add(this.lblCategory);
            this.panelLeft.Controls.Add(this.cmbCategory);
            this.panelLeft.Controls.Add(this.lblDosageForm);
            this.panelLeft.Controls.Add(this.cmbDosageForm);
            this.panelLeft.Controls.Add(this.lblStrength);
            this.panelLeft.Controls.Add(this.txtStrength);
            this.panelLeft.Controls.Add(this.lblQuantity);
            this.panelLeft.Controls.Add(this.txtQuantity);
            this.panelLeft.Controls.Add(this.lblUnit);
            this.panelLeft.Controls.Add(this.cmbUnit);
            this.panelLeft.Controls.Add(this.lblReorderLevel);
            this.panelLeft.Controls.Add(this.txtReorderLevel);
            this.panelLeft.Controls.Add(this.lblCostPrice);
            this.panelLeft.Controls.Add(this.txtCostPrice);
            this.panelLeft.Controls.Add(this.lblSellingPrice);
            this.panelLeft.Controls.Add(this.txtSellingPrice);
            this.panelLeft.Controls.Add(this.lblSupplier);
            this.panelLeft.Controls.Add(this.txtSupplier);
            this.panelLeft.Controls.Add(this.lblBatchNumber);
            this.panelLeft.Controls.Add(this.txtBatchNumber);
            this.panelLeft.Controls.Add(this.lblExpiryDate);
            this.panelLeft.Controls.Add(this.dtpExpiryDate);
            this.panelLeft.Controls.Add(this.lblStorageLocation);
            this.panelLeft.Controls.Add(this.txtStorageLocation);
            this.panelLeft.Controls.Add(this.chkControlled);
            this.panelLeft.Controls.Add(this.chkRequiresApproval);
            this.panelLeft.Controls.Add(this.btnAdd);
            this.panelLeft.Controls.Add(this.btnUpdate);
            this.panelLeft.Controls.Add(this.btnDelete);
            this.panelLeft.Controls.Add(this.btnClear);
            this.panelLeft.Location = new System.Drawing.Point(20, 90);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(400, 620);
            this.panelLeft.TabIndex = 1;
            // 
            // lblMedicineName
            // 
            this.lblMedicineName.AutoSize = true;
            this.lblMedicineName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMedicineName.Location = new System.Drawing.Point(15, 15);
            this.lblMedicineName.Name = "lblMedicineName";
            this.lblMedicineName.Size = new System.Drawing.Size(102, 15);
            this.lblMedicineName.TabIndex = 0;
            this.lblMedicineName.Text = "Medicine Name: *";
            // 
            // txtMedicineName
            // 
            this.txtMedicineName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedicineName.Location = new System.Drawing.Point(15, 35);
            this.txtMedicineName.Name = "txtMedicineName";
            this.txtMedicineName.Size = new System.Drawing.Size(370, 23);
            this.txtMedicineName.TabIndex = 1;
            // 
            // lblGenericName
            // 
            this.lblGenericName.AutoSize = true;
            this.lblGenericName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGenericName.Location = new System.Drawing.Point(15, 65);
            this.lblGenericName.Name = "lblGenericName";
            this.lblGenericName.Size = new System.Drawing.Size(87, 15);
            this.lblGenericName.TabIndex = 2;
            this.lblGenericName.Text = "Generic Name:";
            // 
            // txtGenericName
            // 
            this.txtGenericName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGenericName.Location = new System.Drawing.Point(15, 85);
            this.txtGenericName.Name = "txtGenericName";
            this.txtGenericName.Size = new System.Drawing.Size(370, 23);
            this.txtGenericName.TabIndex = 3;
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBrandName.Location = new System.Drawing.Point(15, 115);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(77, 15);
            this.lblBrandName.TabIndex = 4;
            this.lblBrandName.Text = "Brand Name:";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBrandName.Location = new System.Drawing.Point(15, 135);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.Size = new System.Drawing.Size(370, 23);
            this.txtBrandName.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(15, 165);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 15);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category: *";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(15, 185);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 23);
            this.cmbCategory.TabIndex = 7;
            // 
            // lblDosageForm
            // 
            this.lblDosageForm.AutoSize = true;
            this.lblDosageForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDosageForm.Location = new System.Drawing.Point(205, 165);
            this.lblDosageForm.Name = "lblDosageForm";
            this.lblDosageForm.Size = new System.Drawing.Size(80, 15);
            this.lblDosageForm.TabIndex = 8;
            this.lblDosageForm.Text = "Dosage Form:";
            // 
            // cmbDosageForm
            // 
            this.cmbDosageForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDosageForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDosageForm.FormattingEnabled = true;
            this.cmbDosageForm.Location = new System.Drawing.Point(205, 185);
            this.cmbDosageForm.Name = "cmbDosageForm";
            this.cmbDosageForm.Size = new System.Drawing.Size(180, 23);
            this.cmbDosageForm.TabIndex = 9;
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStrength.Location = new System.Drawing.Point(15, 215);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(102, 15);
            this.lblStrength.TabIndex = 10;
            this.lblStrength.Text = "Strength (e.g. 500mg):";
            // 
            // txtStrength
            // 
            this.txtStrength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStrength.Location = new System.Drawing.Point(15, 235);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(180, 23);
            this.txtStrength.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantity.Location = new System.Drawing.Point(205, 215);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 15);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuantity.Location = new System.Drawing.Point(205, 235);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(85, 23);
            this.txtQuantity.TabIndex = 13;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnit.Location = new System.Drawing.Point(300, 215);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(32, 15);
            this.lblUnit.TabIndex = 14;
            this.lblUnit.Text = "Unit:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(300, 235);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(85, 23);
            this.cmbUnit.TabIndex = 15;
            // 
            // lblReorderLevel
            // 
            this.lblReorderLevel.AutoSize = true;
            this.lblReorderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReorderLevel.Location = new System.Drawing.Point(15, 265);
            this.lblReorderLevel.Name = "lblReorderLevel";
            this.lblReorderLevel.Size = new System.Drawing.Size(84, 15);
            this.lblReorderLevel.TabIndex = 16;
            this.lblReorderLevel.Text = "Reorder Level:";
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReorderLevel.Location = new System.Drawing.Point(15, 285);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(120, 23);
            this.txtReorderLevel.TabIndex = 17;
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCostPrice.Location = new System.Drawing.Point(145, 265);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(63, 15);
            this.lblCostPrice.TabIndex = 18;
            this.lblCostPrice.Text = "Cost Price:";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCostPrice.Location = new System.Drawing.Point(145, 285);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(115, 23);
            this.txtCostPrice.TabIndex = 19;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSellingPrice.Location = new System.Drawing.Point(270, 265);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(77, 15);
            this.lblSellingPrice.TabIndex = 20;
            this.lblSellingPrice.Text = "Selling Price: *";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSellingPrice.Location = new System.Drawing.Point(270, 285);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(115, 23);
            this.txtSellingPrice.TabIndex = 21;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(15, 315);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 15);
            this.lblSupplier.TabIndex = 22;
            this.lblSupplier.Text = "Supplier:";
            // 
            // txtSupplier
            // 
            this.txtSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSupplier.Location = new System.Drawing.Point(15, 335);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(370, 23);
            this.txtSupplier.TabIndex = 23;
            // 
            // lblBatchNumber
            // 
            this.lblBatchNumber.AutoSize = true;
            this.lblBatchNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBatchNumber.Location = new System.Drawing.Point(15, 365);
            this.lblBatchNumber.Name = "lblBatchNumber";
            this.lblBatchNumber.Size = new System.Drawing.Size(87, 15);
            this.lblBatchNumber.TabIndex = 24;
            this.lblBatchNumber.Text = "Batch Number:";
            // 
            // txtBatchNumber
            // 
            this.txtBatchNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBatchNumber.Location = new System.Drawing.Point(15, 385);
            this.txtBatchNumber.Name = "txtBatchNumber";
            this.txtBatchNumber.Size = new System.Drawing.Size(180, 23);
            this.txtBatchNumber.TabIndex = 25;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExpiryDate.Location = new System.Drawing.Point(205, 365);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(70, 15);
            this.lblExpiryDate.TabIndex = 26;
            this.lblExpiryDate.Text = "Expiry Date:";
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(205, 385);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(180, 23);
            this.dtpExpiryDate.TabIndex = 27;
            // 
            // lblStorageLocation
            // 
            this.lblStorageLocation.AutoSize = true;
            this.lblStorageLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStorageLocation.Location = new System.Drawing.Point(15, 415);
            this.lblStorageLocation.Name = "lblStorageLocation";
            this.lblStorageLocation.Size = new System.Drawing.Size(102, 15);
            this.lblStorageLocation.TabIndex = 28;
            this.lblStorageLocation.Text = "Storage Location:";
            // 
            // txtStorageLocation
            // 
            this.txtStorageLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStorageLocation.Location = new System.Drawing.Point(15, 435);
            this.txtStorageLocation.Name = "txtStorageLocation";
            this.txtStorageLocation.Size = new System.Drawing.Size(370, 23);
            this.txtStorageLocation.TabIndex = 29;
            // 
            // chkControlled
            // 
            this.chkControlled.AutoSize = true;
            this.chkControlled.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkControlled.Location = new System.Drawing.Point(15, 470);
            this.chkControlled.Name = "chkControlled";
            this.chkControlled.Size = new System.Drawing.Size(147, 19);
            this.chkControlled.TabIndex = 30;
            this.chkControlled.Text = "Controlled Substance";
            this.chkControlled.UseVisualStyleBackColor = true;
            // 
            // chkRequiresApproval
            // 
            this.chkRequiresApproval.AutoSize = true;
            this.chkRequiresApproval.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRequiresApproval.Location = new System.Drawing.Point(205, 470);
            this.chkRequiresApproval.Name = "chkRequiresApproval";
            this.chkRequiresApproval.Size = new System.Drawing.Size(126, 19);
            this.chkRequiresApproval.TabIndex = 31;
            this.chkRequiresApproval.Text = "Requires Approval";
            this.chkRequiresApproval.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(15, 510);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 40);
            this.btnAdd.TabIndex = 32;
            this.btnAdd.Text = "Add Medicine";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(205, 510);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(180, 40);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(15, 560);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 40);
            this.btnDelete.TabIndex = 34;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(205, 560);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 40);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "Clear Fields";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.Controls.Add(this.lblSearch);
            this.panelRight.Controls.Add(this.txtSearch);
            this.panelRight.Controls.Add(this.btnSearch);
            this.panelRight.Controls.Add(this.btnAdjustStock);
            this.panelRight.Controls.Add(this.dgvInventory);
            this.panelRight.Location = new System.Drawing.Point(440, 90);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(940, 620);
            this.panelRight.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(15, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(123, 19);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search Medicine:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(15, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(600, 25);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(625, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnAdjustStock
            // 
            this.btnAdjustStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnAdjustStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdjustStock.FlatAppearance.BorderSize = 0;
            this.btnAdjustStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjustStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdjustStock.ForeColor = System.Drawing.Color.White;
            this.btnAdjustStock.Location = new System.Drawing.Point(775, 35);
            this.btnAdjustStock.Name = "btnAdjustStock";
            this.btnAdjustStock.Size = new System.Drawing.Size(150, 35);
            this.btnAdjustStock.TabIndex = 3;
            this.btnAdjustStock.Text = "Adjust Stock";
            this.btnAdjustStock.UseVisualStyleBackColor = false;
            this.btnAdjustStock.Click += new System.EventHandler(this.BtnAdjustStock_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(15, 85);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(910, 520);
            this.dgvInventory.TabIndex = 4;
            this.dgvInventory.SelectionChanged += new System.EventHandler(this.DgvInventory_SelectionChanged);
            // 
            // ManageInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1400, 730);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ManageInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Medicine Inventory";
            this.Load += new System.EventHandler(this.ManageInventoryForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}