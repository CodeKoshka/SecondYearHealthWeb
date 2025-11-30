
namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ManageInventoryForm
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
            panelTop = new Panel();
            lblTitle = new Label();
            lblTotalItems = new Label();
            btnClose = new Button();
            panelLeft = new Panel();
            lblMedicineName = new Label();
            txtMedicineName = new TextBox();
            lblGenericName = new Label();
            txtGenericName = new TextBox();
            lblBrandName = new Label();
            txtBrandName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblDosageForm = new Label();
            cmbDosageForm = new ComboBox();
            lblStrength = new Label();
            txtStrength = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            lblUnit = new Label();
            cmbUnit = new ComboBox();
            lblReorderLevel = new Label();
            txtReorderLevel = new TextBox();
            lblCostPrice = new Label();
            txtCostPrice = new TextBox();
            lblSellingPrice = new Label();
            txtSellingPrice = new TextBox();
            lblSupplier = new Label();
            txtSupplier = new TextBox();
            lblBatchNumber = new Label();
            txtBatchNumber = new TextBox();
            lblExpiryDate = new Label();
            dtpExpiryDate = new DateTimePicker();
            lblStorageLocation = new Label();
            txtStorageLocation = new TextBox();
            chkControlled = new CheckBox();
            chkRequiresApproval = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            panelRight = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAdjustStock = new Button();
            dgvInventory = new DataGridView();
            panelTop.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvInventory)).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            panelTop.Controls.Add(lblTitle);
            panelTop.Controls.Add(lblTotalItems);
            panelTop.Controls.Add(btnClose);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(1400, 70);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(296, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Manage Medicine Inventory";
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTotalItems.ForeColor = System.Drawing.Color.White;
            lblTotalItems.Location = new System.Drawing.Point(22, 45);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new System.Drawing.Size(88, 19);
            lblTotalItems.TabIndex = 1;
            lblTotalItems.Text = "Total Items: 0";
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1270, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(110, 40);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += new System.EventHandler(BtnClose_Click);
            // 
            // panelLeft
            // 
            panelLeft.BackColor = System.Drawing.Color.White;
            panelLeft.Controls.Add(lblMedicineName);
            panelLeft.Controls.Add(txtMedicineName);
            panelLeft.Controls.Add(lblGenericName);
            panelLeft.Controls.Add(txtGenericName);
            panelLeft.Controls.Add(lblBrandName);
            panelLeft.Controls.Add(txtBrandName);
            panelLeft.Controls.Add(lblCategory);
            panelLeft.Controls.Add(cmbCategory);
            panelLeft.Controls.Add(lblDosageForm);
            panelLeft.Controls.Add(cmbDosageForm);
            panelLeft.Controls.Add(lblStrength);
            panelLeft.Controls.Add(txtStrength);
            panelLeft.Controls.Add(lblQuantity);
            panelLeft.Controls.Add(txtQuantity);
            panelLeft.Controls.Add(lblUnit);
            panelLeft.Controls.Add(cmbUnit);
            panelLeft.Controls.Add(lblReorderLevel);
            panelLeft.Controls.Add(txtReorderLevel);
            panelLeft.Controls.Add(lblCostPrice);
            panelLeft.Controls.Add(txtCostPrice);
            panelLeft.Controls.Add(lblSellingPrice);
            panelLeft.Controls.Add(txtSellingPrice);
            panelLeft.Controls.Add(lblSupplier);
            panelLeft.Controls.Add(txtSupplier);
            panelLeft.Controls.Add(lblBatchNumber);
            panelLeft.Controls.Add(txtBatchNumber);
            panelLeft.Controls.Add(lblExpiryDate);
            panelLeft.Controls.Add(dtpExpiryDate);
            panelLeft.Controls.Add(lblStorageLocation);
            panelLeft.Controls.Add(txtStorageLocation);
            panelLeft.Controls.Add(chkControlled);
            panelLeft.Controls.Add(chkRequiresApproval);
            panelLeft.Controls.Add(btnAdd);
            panelLeft.Controls.Add(btnUpdate);
            panelLeft.Controls.Add(btnDelete);
            panelLeft.Controls.Add(btnClear);
            panelLeft.Location = new System.Drawing.Point(20, 90);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new System.Drawing.Size(400, 620);
            panelLeft.TabIndex = 1;
            // 
            // lblMedicineName
            // 
            lblMedicineName.AutoSize = true;
            lblMedicineName.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblMedicineName.Location = new System.Drawing.Point(15, 15);
            lblMedicineName.Name = "lblMedicineName";
            lblMedicineName.Size = new System.Drawing.Size(102, 15);
            lblMedicineName.TabIndex = 0;
            lblMedicineName.Text = "Medicine Name: *";
            // 
            // txtMedicineName
            // 
            txtMedicineName.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtMedicineName.Location = new System.Drawing.Point(15, 35);
            txtMedicineName.Name = "txtMedicineName";
            txtMedicineName.Size = new System.Drawing.Size(370, 23);
            txtMedicineName.TabIndex = 1;
            // 
            // lblGenericName
            // 
            lblGenericName.AutoSize = true;
            lblGenericName.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblGenericName.Location = new System.Drawing.Point(15, 65);
            lblGenericName.Name = "lblGenericName";
            lblGenericName.Size = new System.Drawing.Size(87, 15);
            lblGenericName.TabIndex = 2;
            lblGenericName.Text = "Generic Name:";
            // 
            // txtGenericName
            // 
            txtGenericName.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtGenericName.Location = new System.Drawing.Point(15, 85);
            txtGenericName.Name = "txtGenericName";
            txtGenericName.Size = new System.Drawing.Size(370, 23);
            txtGenericName.TabIndex = 3;
            // 
            // lblBrandName
            // 
            lblBrandName.AutoSize = true;
            lblBrandName.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblBrandName.Location = new System.Drawing.Point(15, 115);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new System.Drawing.Size(77, 15);
            lblBrandName.TabIndex = 4;
            lblBrandName.Text = "Brand Name:";
            // 
            // txtBrandName
            // 
            txtBrandName.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBrandName.Location = new System.Drawing.Point(15, 135);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.Size = new System.Drawing.Size(370, 23);
            txtBrandName.TabIndex = 5;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCategory.Location = new System.Drawing.Point(15, 165);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(65, 15);
            lblCategory.TabIndex = 6;
            lblCategory.Text = "Category: *";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new System.Drawing.Point(15, 185);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new System.Drawing.Size(180, 23);
            cmbCategory.TabIndex = 7;
            // 
            // lblDosageForm
            // 
            lblDosageForm.AutoSize = true;
            lblDosageForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblDosageForm.Location = new System.Drawing.Point(205, 165);
            lblDosageForm.Name = "lblDosageForm";
            lblDosageForm.Size = new System.Drawing.Size(80, 15);
            lblDosageForm.TabIndex = 8;
            lblDosageForm.Text = "Dosage Form:";
            // 
            // cmbDosageForm
            // 
            cmbDosageForm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDosageForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbDosageForm.FormattingEnabled = true;
            cmbDosageForm.Location = new System.Drawing.Point(205, 185);
            cmbDosageForm.Name = "cmbDosageForm";
            cmbDosageForm.Size = new System.Drawing.Size(180, 23);
            cmbDosageForm.TabIndex = 9;
            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;
            lblStrength.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStrength.Location = new System.Drawing.Point(15, 215);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new System.Drawing.Size(102, 15);
            lblStrength.TabIndex = 10;
            lblStrength.Text = "Strength (e.g. 500mg):";
            // 
            // txtStrength
            // 
            txtStrength.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtStrength.Location = new System.Drawing.Point(15, 235);
            txtStrength.Name = "txtStrength";
            txtStrength.Size = new System.Drawing.Size(180, 23);
            txtStrength.TabIndex = 11;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblQuantity.Location = new System.Drawing.Point(205, 215);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(56, 15);
            lblQuantity.TabIndex = 12;
            lblQuantity.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtQuantity.Location = new System.Drawing.Point(205, 235);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new System.Drawing.Size(85, 23);
            txtQuantity.TabIndex = 13;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblUnit.Location = new System.Drawing.Point(300, 215);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new System.Drawing.Size(32, 15);
            lblUnit.TabIndex = 14;
            lblUnit.Text = "Unit:";
            // 
            // cmbUnit
            // 
            cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbUnit.FormattingEnabled = true;
            cmbUnit.Location = new System.Drawing.Point(300, 235);
            cmbUnit.Name = "cmbUnit";
            cmbUnit.Size = new System.Drawing.Size(85, 23);
            cmbUnit.TabIndex = 15;
            // 
            // lblReorderLevel
            // 
            lblReorderLevel.AutoSize = true;
            lblReorderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblReorderLevel.Location = new System.Drawing.Point(15, 265);
            lblReorderLevel.Name = "lblReorderLevel";
            lblReorderLevel.Size = new System.Drawing.Size(84, 15);
            lblReorderLevel.TabIndex = 16;
            lblReorderLevel.Text = "Reorder Level:";
            // 
            // txtReorderLevel
            // 
            txtReorderLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtReorderLevel.Location = new System.Drawing.Point(15, 285);
            txtReorderLevel.Name = "txtReorderLevel";
            txtReorderLevel.Size = new System.Drawing.Size(120, 23);
            txtReorderLevel.TabIndex = 17;
            // 
            // lblCostPrice
            // 
            lblCostPrice.AutoSize = true;
            lblCostPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCostPrice.Location = new System.Drawing.Point(145, 265);
            lblCostPrice.Name = "lblCostPrice";
            lblCostPrice.Size = new System.Drawing.Size(63, 15);
            lblCostPrice.TabIndex = 18;
            lblCostPrice.Text = "Cost Price:";
            // 
            // txtCostPrice
            // 
            txtCostPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtCostPrice.Location = new System.Drawing.Point(145, 285);
            txtCostPrice.Name = "txtCostPrice";
            txtCostPrice.Size = new System.Drawing.Size(115, 23);
            txtCostPrice.TabIndex = 19;
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSellingPrice.Location = new System.Drawing.Point(270, 265);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new System.Drawing.Size(77, 15);
            lblSellingPrice.TabIndex = 20;
            lblSellingPrice.Text = "Selling Price: *";
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSellingPrice.Location = new System.Drawing.Point(270, 285);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new System.Drawing.Size(115, 23);
            txtSellingPrice.TabIndex = 21;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSupplier.Location = new System.Drawing.Point(15, 315);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new System.Drawing.Size(54, 15);
            lblSupplier.TabIndex = 22;
            lblSupplier.Text = "Supplier:";
            // 
            // txtSupplier
            // 
            txtSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtSupplier.Location = new System.Drawing.Point(15, 335);
            txtSupplier.Name = "txtSupplier";
            txtSupplier.Size = new System.Drawing.Size(370, 23);
            txtSupplier.TabIndex = 23;
            // 
            // lblBatchNumber
            // 
            lblBatchNumber.AutoSize = true;
            lblBatchNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblBatchNumber.Location = new System.Drawing.Point(15, 365);
            lblBatchNumber.Name = "lblBatchNumber";
            lblBatchNumber.Size = new System.Drawing.Size(87, 15);
            lblBatchNumber.TabIndex = 24;
            lblBatchNumber.Text = "Batch Number:";
            // 
            // txtBatchNumber
            // 
            txtBatchNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBatchNumber.Location = new System.Drawing.Point(15, 385);
            txtBatchNumber.Name = "txtBatchNumber";
            txtBatchNumber.Size = new System.Drawing.Size(180, 23);
            txtBatchNumber.TabIndex = 25;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblExpiryDate.Location = new System.Drawing.Point(205, 365);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new System.Drawing.Size(70, 15);
            lblExpiryDate.TabIndex = 26;
            lblExpiryDate.Text = "Expiry Date:";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            dtpExpiryDate.Format = DateTimePickerFormat.Short;
            dtpExpiryDate.Location = new System.Drawing.Point(205, 385);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new System.Drawing.Size(180, 23);
            dtpExpiryDate.TabIndex = 27;
            // 
            // lblStorageLocation
            // 
            lblStorageLocation.AutoSize = true;
            lblStorageLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblStorageLocation.Location = new System.Drawing.Point(15, 415);
            lblStorageLocation.Name = "lblStorageLocation";
            lblStorageLocation.Size = new System.Drawing.Size(102, 15);
            lblStorageLocation.TabIndex = 28;
            lblStorageLocation.Text = "Storage Location:";
            // 
            // txtStorageLocation
            // 
            txtStorageLocation.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtStorageLocation.Location = new System.Drawing.Point(15, 435);
            txtStorageLocation.Name = "txtStorageLocation";
            txtStorageLocation.Size = new System.Drawing.Size(370, 23);
            txtStorageLocation.TabIndex = 29;
            // 
            // chkControlled
            // 
            chkControlled.AutoSize = true;
            chkControlled.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkControlled.Location = new System.Drawing.Point(15, 470);
            chkControlled.Name = "chkControlled";
            chkControlled.Size = new System.Drawing.Size(147, 19);
            chkControlled.TabIndex = 30;
            chkControlled.Text = "Controlled Substance";
            chkControlled.UseVisualStyleBackColor = true;
            // 
            // chkRequiresApproval
            // 
            chkRequiresApproval.AutoSize = true;
            chkRequiresApproval.Font = new System.Drawing.Font("Segoe UI", 9F);
            chkRequiresApproval.Location = new System.Drawing.Point(205, 470);
            chkRequiresApproval.Name = "chkRequiresApproval";
            chkRequiresApproval.Size = new System.Drawing.Size(126, 19);
            chkRequiresApproval.TabIndex = 31;
            chkRequiresApproval.Text = "Requires Approval";
            chkRequiresApproval.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(15, 510);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(180, 40);
            btnAdd.TabIndex = 32;
            btnAdd.Text = "Add Medicine";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += new System.EventHandler(BtnAdd_Click);
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnUpdate.ForeColor = System.Drawing.Color.White;
            btnUpdate.Location = new System.Drawing.Point(205, 510);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(180, 40);
            btnUpdate.TabIndex = 33;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += new System.EventHandler(BtnUpdate_Click);
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(15, 560);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(180, 40);
            btnDelete.TabIndex = 34;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += new System.EventHandler(BtnDelete_Click);
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnClear.ForeColor = System.Drawing.Color.White;
            btnClear.Location = new System.Drawing.Point(205, 560);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(180, 40);
            btnClear.TabIndex = 35;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += new System.EventHandler(BtnClear_Click);
            // 
            // panelRight
            // 
            panelRight.BackColor = System.Drawing.Color.White;
            panelRight.Controls.Add(lblSearch);
            panelRight.Controls.Add(txtSearch);
            panelRight.Controls.Add(btnSearch);
            panelRight.Controls.Add(btnAdjustStock);
            panelRight.Controls.Add(dgvInventory);
            panelRight.Location = new System.Drawing.Point(440, 90);
            panelRight.Name = "panelRight";
            panelRight.Size = new System.Drawing.Size(940, 620);
            panelRight.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSearch.Location = new System.Drawing.Point(15, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(123, 19);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search Medicine:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.Location = new System.Drawing.Point(15, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(600, 25);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(625, 35);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(140, 35);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(BtnSearch_Click);
            // 
            // btnAdjustStock
            // 
            btnAdjustStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            btnAdjustStock.Cursor = Cursors.Hand;
            btnAdjustStock.FlatAppearance.BorderSize = 0;
            btnAdjustStock.FlatStyle = FlatStyle.Flat;
            btnAdjustStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAdjustStock.ForeColor = System.Drawing.Color.White;
            btnAdjustStock.Location = new System.Drawing.Point(775, 35);
            btnAdjustStock.Name = "btnAdjustStock";
            btnAdjustStock.Size = new System.Drawing.Size(150, 35);
            btnAdjustStock.TabIndex = 3;
            btnAdjustStock.Text = "Adjust Stock";
            btnAdjustStock.UseVisualStyleBackColor = false;
            btnAdjustStock.Click += new System.EventHandler(BtnAdjustStock_Click);
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.BackgroundColor = System.Drawing.Color.White;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new System.Drawing.Point(15, 85);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new System.Drawing.Size(910, 520);
            dgvInventory.TabIndex = 4;
            dgvInventory.SelectionChanged += new System.EventHandler(DgvInventory_SelectionChanged);
            // 
            // ManageInventoryForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            ClientSize = new System.Drawing.Size(1400, 730);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ManageInventoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Medicine Inventory";
            Load += new System.EventHandler(ManageInventoryForm_Load);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvInventory)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitle;
        private Label lblTotalItems;
        private Panel panelLeft;
        private Label lblMedicineName;
        private TextBox txtMedicineName;
        private Label lblGenericName;
        private TextBox txtGenericName;
        private Label lblBrandName;
        private TextBox txtBrandName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblDosageForm;
        private ComboBox cmbDosageForm;
        private Label lblStrength;
        private TextBox txtStrength;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Label lblUnit;
        private ComboBox cmbUnit;
        private Label lblReorderLevel;
        private TextBox txtReorderLevel;
        private Label lblCostPrice;
        private TextBox txtCostPrice;
        private Label lblSellingPrice;
        private TextBox txtSellingPrice;
        private Label lblSupplier;
        private TextBox txtSupplier;
        private Label lblBatchNumber;
        private TextBox txtBatchNumber;
        private Label lblExpiryDate;
        private DateTimePicker dtpExpiryDate;
        private Label lblStorageLocation;
        private TextBox txtStorageLocation;
        private CheckBox chkControlled;
        private CheckBox chkRequiresApproval;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Panel panelRight;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAdjustStock;
        private DataGridView dgvInventory;
        private Button btnClose;
    }
}