namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ServiceChecklistForm
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
            lblPatientInfo = new Label();
            lblServiceCount = new Label();
            grpAddService = new GroupBox();
            btnRemoveService = new Button();
            btnAddService = new Button();
            numQuantity = new NumericUpDown();
            lblQuantity = new Label();
            cmbService = new ComboBox();
            lblService = new Label();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            lstServices = new ListView();
            panelFooter = new Panel();
            lblTotal = new Label();
            btnCancel = new Button();
            btnSaveAndComplete = new Button();
            panelHeader.SuspendLayout();
            grpAddService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            panelFooter.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblPatientInfo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(889, 80);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(337, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📋 Equipment & Services Report";
            // 
            // lblPatientInfo
            // 
            lblPatientInfo.AutoSize = true;
            lblPatientInfo.Font = new Font("Segoe UI", 10F);
            lblPatientInfo.ForeColor = Color.White;
            lblPatientInfo.Location = new Point(20, 50);
            lblPatientInfo.Name = "lblPatientInfo";
            lblPatientInfo.Size = new Size(150, 19);
            lblPatientInfo.TabIndex = 1;
            lblPatientInfo.Text = "Patient: [Patient Name]";
            // 
            // lblServiceCount
            // 
            lblServiceCount.AutoSize = true;
            lblServiceCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblServiceCount.ForeColor = Color.FromArgb(52, 152, 219);
            lblServiceCount.Location = new Point(20, 100);
            lblServiceCount.Name = "lblServiceCount";
            lblServiceCount.Size = new Size(172, 19);
            lblServiceCount.TabIndex = 1;
            lblServiceCount.Text = "Services Selected: 0 of 0";
            // 
            // grpAddService
            // 
            grpAddService.Controls.Add(btnRemoveService);
            grpAddService.Controls.Add(btnAddService);
            grpAddService.Controls.Add(numQuantity);
            grpAddService.Controls.Add(lblQuantity);
            grpAddService.Controls.Add(cmbService);
            grpAddService.Controls.Add(lblService);
            grpAddService.Controls.Add(cmbCategory);
            grpAddService.Controls.Add(lblCategory);
            grpAddService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpAddService.Location = new Point(20, 135);
            grpAddService.Name = "grpAddService";
            grpAddService.Size = new Size(843, 120);
            grpAddService.TabIndex = 2;
            grpAddService.TabStop = false;
            grpAddService.Text = "Add Service/Equipment";
            // 
            // btnRemoveService
            // 
            btnRemoveService.BackColor = Color.FromArgb(231, 76, 60);
            btnRemoveService.Cursor = Cursors.Hand;
            btnRemoveService.FlatAppearance.BorderSize = 0;
            btnRemoveService.FlatStyle = FlatStyle.Flat;
            btnRemoveService.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemoveService.ForeColor = Color.White;
            btnRemoveService.Location = new Point(702, 60);
            btnRemoveService.Name = "btnRemoveService";
            btnRemoveService.Size = new Size(120, 40);
            btnRemoveService.TabIndex = 7;
            btnRemoveService.Text = "❌ Remove";
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
            btnAddService.Location = new Point(562, 60);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(120, 40);
            btnAddService.TabIndex = 6;
            btnAddService.Text = "➕ Add";
            btnAddService.UseVisualStyleBackColor = false;
            btnAddService.Click += BtnAddService_Click;
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(400, 69);
            numQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(108, 25);
            numQuantity.TabIndex = 5;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 9F);
            lblQuantity.Location = new Point(400, 50);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 4;
            lblQuantity.Text = "Quantity:";
            // 
            // cmbService
            // 
            cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbService.Font = new Font("Segoe UI", 10F);
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(191, 68);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(203, 25);
            cmbService.TabIndex = 3;
            cmbService.SelectedIndexChanged += new System.EventHandler(this.CmbService_SelectedIndexChanged);
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Font = new Font("Segoe UI", 9F);
            lblService.Location = new Point(191, 50);
            lblService.Name = "lblService";
            lblService.Size = new Size(110, 15);
            lblService.TabIndex = 2;
            lblService.Text = "Service/Equipment:";
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Font = new Font("Segoe UI", 10F);
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(20, 68);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(165, 25);
            cmbCategory.TabIndex = 1;
            cmbCategory.SelectedIndexChanged += CmbCategory_SelectedIndexChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9F);
            lblCategory.Location = new Point(20, 50);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(58, 15);
            lblCategory.TabIndex = 0;
            lblCategory.Text = "Category:";
            // 
            // lstServices
            // 
            lstServices.CheckBoxes = true;
            lstServices.Font = new Font("Segoe UI", 9F);
            lstServices.FullRowSelect = true;
            lstServices.GridLines = true;
            lstServices.Location = new Point(20, 270);
            lstServices.Name = "lstServices";
            lstServices.Size = new Size(843, 313);
            lstServices.TabIndex = 3;
            lstServices.UseCompatibleStateImageBehavior = false;
            lstServices.View = View.Details;
            lstServices.ItemChecked += LstServices_ItemChecked;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(236, 240, 241);
            panelFooter.Controls.Add(lblTotal);
            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSaveAndComplete);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 611);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(889, 90);
            panelFooter.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(52, 152, 219);
            lblTotal.Location = new Point(20, 30);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 25);
            lblTotal.TabIndex = 0;
            lblTotal.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(692, 19);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 50);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "❌ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSaveAndComplete
            // 
            btnSaveAndComplete.BackColor = Color.FromArgb(46, 204, 113);
            btnSaveAndComplete.Cursor = Cursors.Hand;
            btnSaveAndComplete.FlatAppearance.BorderSize = 0;
            btnSaveAndComplete.FlatStyle = FlatStyle.Flat;
            btnSaveAndComplete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveAndComplete.ForeColor = Color.White;
            btnSaveAndComplete.Location = new Point(442, 19);
            btnSaveAndComplete.Name = "btnSaveAndComplete";
            btnSaveAndComplete.Size = new Size(230, 50);
            btnSaveAndComplete.TabIndex = 1;
            btnSaveAndComplete.Text = "✅ Complete Equipment Report";
            btnSaveAndComplete.UseVisualStyleBackColor = false;
            btnSaveAndComplete.Click += BtnSaveAndComplete_Click;
            // 
            // ServiceChecklistForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(889, 701);
            Controls.Add(panelFooter);
            Controls.Add(lstServices);
            Controls.Add(grpAddService);
            Controls.Add(lblServiceCount);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ServiceChecklistForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Equipment & Services Report";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            grpAddService.ResumeLayout(false);
            grpAddService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion 

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblPatientInfo;
        private Label lblServiceCount;
        private GroupBox grpAddService;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblService;
        private ComboBox cmbService;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Button btnAddService;
        private Button btnRemoveService;
        private ListView lstServices;
        private Panel panelFooter;
        private Label lblTotal;
        private Button btnSaveAndComplete;
        private Button btnCancel;
    }
}