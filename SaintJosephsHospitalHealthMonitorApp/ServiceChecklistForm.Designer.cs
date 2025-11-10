namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ServiceChecklistForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPatientInfo;
        private System.Windows.Forms.Label lblServiceCount;
        private System.Windows.Forms.GroupBox grpAddService;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.ListView lstServices;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnSaveAndComplete;
        private System.Windows.Forms.Button btnCancel;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPatientInfo = new System.Windows.Forms.Label();
            this.lblServiceCount = new System.Windows.Forms.Label();
            this.grpAddService = new System.Windows.Forms.GroupBox();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lstServices = new System.Windows.Forms.ListView();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAndComplete = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.grpAddService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblPatientInfo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(398, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📋 Equipment & Services Report";
            // 
            // lblPatientInfo
            // 
            this.lblPatientInfo.AutoSize = true;
            this.lblPatientInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientInfo.ForeColor = System.Drawing.Color.White;
            this.lblPatientInfo.Location = new System.Drawing.Point(20, 50);
            this.lblPatientInfo.Name = "lblPatientInfo";
            this.lblPatientInfo.Size = new System.Drawing.Size(150, 19);
            this.lblPatientInfo.TabIndex = 1;
            this.lblPatientInfo.Text = "Patient: [Patient Name]";
            // 
            // lblServiceCount
            // 
            this.lblServiceCount.AutoSize = true;
            this.lblServiceCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblServiceCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblServiceCount.Location = new System.Drawing.Point(20, 100);
            this.lblServiceCount.Name = "lblServiceCount";
            this.lblServiceCount.Size = new System.Drawing.Size(165, 19);
            this.lblServiceCount.TabIndex = 1;
            this.lblServiceCount.Text = "Services Selected: 0 of 0";
            // 
            // grpAddService
            // 
            this.grpAddService.Controls.Add(this.btnRemoveService);
            this.grpAddService.Controls.Add(this.btnAddService);
            this.grpAddService.Controls.Add(this.numQuantity);
            this.grpAddService.Controls.Add(this.lblQuantity);
            this.grpAddService.Controls.Add(this.cmbService);
            this.grpAddService.Controls.Add(this.lblService);
            this.grpAddService.Controls.Add(this.cmbCategory);
            this.grpAddService.Controls.Add(this.lblCategory);
            this.grpAddService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpAddService.Location = new System.Drawing.Point(20, 135);
            this.grpAddService.Name = "grpAddService";
            this.grpAddService.Size = new System.Drawing.Size(960, 120);
            this.grpAddService.TabIndex = 2;
            this.grpAddService.TabStop = false;
            this.grpAddService.Text = "Add Service/Equipment";
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveService.FlatAppearance.BorderSize = 0;
            this.btnRemoveService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveService.ForeColor = System.Drawing.Color.White;
            this.btnRemoveService.Location = new System.Drawing.Point(820, 65);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(120, 40);
            this.btnRemoveService.TabIndex = 7;
            this.btnRemoveService.Text = "❌ Remove";
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
            this.btnAddService.Location = new System.Drawing.Point(680, 65);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(120, 40);
            this.btnAddService.TabIndex = 6;
            this.btnAddService.Text = "➕ Add";
            this.btnAddService.UseVisualStyleBackColor = false;
            this.btnAddService.Click += new System.EventHandler(this.BtnAddService_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numQuantity.Location = new System.Drawing.Point(540, 70);
            this.numQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 25);
            this.numQuantity.TabIndex = 5;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantity.Location = new System.Drawing.Point(540, 40);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(56, 15);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity:";
            // 
            // cmbService
            // 
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(260, 68);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(260, 25);
            this.cmbService.TabIndex = 3;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblService.Location = new System.Drawing.Point(260, 40);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(104, 15);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Service/Equipment:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(20, 68);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(220, 25);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.CmbCategory_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategory.Location = new System.Drawing.Point(20, 40);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(58, 15);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category:";
            // 
            // lstServices
            // 
            this.lstServices.CheckBoxes = true;
            this.lstServices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstServices.FullRowSelect = true;
            this.lstServices.GridLines = true;
            this.lstServices.HideSelection = false;
            this.lstServices.Location = new System.Drawing.Point(20, 270);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(960, 320);
            this.lstServices.TabIndex = 3;
            this.lstServices.UseCompatibleStateImageBehavior = false;
            this.lstServices.View = System.Windows.Forms.View.Details;
            this.lstServices.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LstServices_ItemChecked);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelFooter.Controls.Add(this.lblTotal);
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.Controls.Add(this.btnSaveAndComplete);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 610);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1000, 90);
            this.panelFooter.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotal.Location = new System.Drawing.Point(20, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 25);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(830, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 50);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "❌ Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSaveAndComplete
            // 
            this.btnSaveAndComplete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveAndComplete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAndComplete.FlatAppearance.BorderSize = 0;
            this.btnSaveAndComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndComplete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveAndComplete.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndComplete.Location = new System.Drawing.Point(580, 20);
            this.btnSaveAndComplete.Name = "btnSaveAndComplete";
            this.btnSaveAndComplete.Size = new System.Drawing.Size(230, 50);
            this.btnSaveAndComplete.TabIndex = 1;
            this.btnSaveAndComplete.Text = "✅ Complete Equipment Report";
            this.btnSaveAndComplete.UseVisualStyleBackColor = false;
            this.btnSaveAndComplete.Click += new System.EventHandler(this.BtnSaveAndComplete_Click);
            // 
            // ServiceChecklistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.grpAddService);
            this.Controls.Add(this.lblServiceCount);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ServiceChecklistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Equipment & Services Report";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpAddService.ResumeLayout(false);
            this.grpAddService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}