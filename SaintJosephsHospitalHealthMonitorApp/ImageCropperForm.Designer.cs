namespace SaintJosephsHospitalHealthMonitorApp
{
    partial class ImageCropperForm
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
            pictureBoxCrop = new PictureBox();
            btnCrop = new Button();
            btnCancel = new Button();
            lblInstructions = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxCrop)).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(700, 60);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "✂️ Crop Picture";
            // 
            // pictureBoxCrop
            // 
            pictureBoxCrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            pictureBoxCrop.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCrop.Location = new System.Drawing.Point(20, 120);
            pictureBoxCrop.Name = "pictureBoxCrop";
            pictureBoxCrop.Size = new System.Drawing.Size(660, 440);
            pictureBoxCrop.TabIndex = 1;
            pictureBoxCrop.TabStop = false;
            pictureBoxCrop.Paint += new PaintEventHandler(PictureBoxCrop_Paint);
            pictureBoxCrop.MouseDown += new MouseEventHandler(PictureBoxCrop_MouseDown);
            pictureBoxCrop.MouseMove += new MouseEventHandler(PictureBoxCrop_MouseMove);
            pictureBoxCrop.MouseUp += new MouseEventHandler(PictureBoxCrop_MouseUp);
            // 
            // lblInstructions
            // 
            lblInstructions.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            lblInstructions.Location = new System.Drawing.Point(20, 75);
            lblInstructions.Name = "lblInstructions";
            lblInstructions.Size = new System.Drawing.Size(660, 35);
            lblInstructions.TabIndex = 2;
            lblInstructions.Text = "Drag to select the area you want to keep. The selected area will be cropped to a" + " square.";
            lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCrop
            // 
            btnCrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            btnCrop.Cursor = Cursors.Hand;
            btnCrop.FlatAppearance.BorderSize = 0;
            btnCrop.FlatStyle = FlatStyle.Flat;
            btnCrop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCrop.ForeColor = System.Drawing.Color.White;
            btnCrop.Location = new System.Drawing.Point(20, 575);
            btnCrop.Name = "btnCrop";
            btnCrop.Size = new System.Drawing.Size(320, 45);
            btnCrop.TabIndex = 3;
            btnCrop.Text = "✔️ Crop && Save";
            btnCrop.UseVisualStyleBackColor = false;
            btnCrop.Click += new System.EventHandler(BtnCrop_Click);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(360, 575);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(320, 45);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "❌ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += new System.EventHandler(BtnCancel_Click);
            // 
            // ImageCropperForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(700, 640);
            Controls.Add(btnCancel);
            Controls.Add(btnCrop);
            Controls.Add(lblInstructions);
            Controls.Add(pictureBoxCrop);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImageCropperForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Crop Picture - St. Joseph\'s Hospital";
            ((System.ComponentModel.ISupportInitialize)(pictureBoxCrop)).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxCrop;
        private Button btnCrop;
        private Button btnCancel;
        private Label lblInstructions;
        private Panel panelHeader;
        private Label lblTitle;
    }
}