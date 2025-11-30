partial class DispenseOrderForm
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
        pnlTop = new Panel();
        lblFormTitle = new Label();
        lblOrderDetails = new Label();
        btnConfirm = new Button();
        btnCancel = new Button();
        pnlTop.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
        pnlTop.Controls.Add(lblFormTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new System.Drawing.Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new System.Drawing.Size(500, 60);
        pnlTop.TabIndex = 0;
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        lblFormTitle.ForeColor = System.Drawing.Color.White;
        lblFormTitle.Location = new System.Drawing.Point(20, 15);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new System.Drawing.Size(175, 30);
        lblFormTitle.TabIndex = 0;
        lblFormTitle.Text = "Dispense Order";
        // 
        // lblOrderDetails
        // 
        lblOrderDetails.Font = new System.Drawing.Font("Segoe UI", 11F);
        lblOrderDetails.Location = new System.Drawing.Point(30, 80);
        lblOrderDetails.Name = "lblOrderDetails";
        lblOrderDetails.Size = new System.Drawing.Size(440, 150);
        lblOrderDetails.TabIndex = 1;
        lblOrderDetails.Text = "Order Details Loading...";
        // 
        // btnConfirm
        // 
        btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
        btnConfirm.FlatStyle = FlatStyle.Flat;
        btnConfirm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        btnConfirm.ForeColor = System.Drawing.Color.White;
        btnConfirm.Location = new System.Drawing.Point(150, 250);
        btnConfirm.Name = "btnConfirm";
        btnConfirm.Size = new System.Drawing.Size(150, 40);
        btnConfirm.TabIndex = 2;
        btnConfirm.Text = "✓ Confirm Dispense";
        btnConfirm.UseVisualStyleBackColor = false;
        btnConfirm.Click += new System.EventHandler(BtnConfirm_Click);
        // 
        // btnCancel
        // 
        btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.FlatStyle = FlatStyle.Flat;
        btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        btnCancel.ForeColor = System.Drawing.Color.White;
        btnCancel.Location = new System.Drawing.Point(310, 250);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(150, 40);
        btnCancel.TabIndex = 3;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = false;
        // 
        // DispenseOrderForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        CancelButton = btnCancel;
        ClientSize = new System.Drawing.Size(500, 320);
        Controls.Add(btnCancel);
        Controls.Add(btnConfirm);
        Controls.Add(lblOrderDetails);
        Controls.Add(pnlTop);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DispenseOrderForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Dispense Medication Order";
        pnlTop.ResumeLayout(false);
        pnlTop.PerformLayout();
        ResumeLayout(false);
    }

#endregion

    private Panel pnlTop;
    private Label lblFormTitle;
    private Label lblOrderDetails;
    private Button btnConfirm;
    private Button btnCancel;
}
