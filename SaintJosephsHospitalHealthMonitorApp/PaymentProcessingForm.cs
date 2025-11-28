using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class PaymentProcessingForm : Form
    {
        private int billId;
        private int patientId;
        private string patientName;
        private decimal totalAmount;
        private string currentStatus;
        private int currentUserId;

        public PaymentProcessingForm(int billId, int patientId, string patientName, decimal totalAmount, string status, int userId)
        {
            this.billId = billId;
            this.patientId = patientId;
            this.patientName = patientName;
            this.totalAmount = totalAmount;
            this.currentStatus = status;
            this.currentUserId = userId;

            InitializeComponent();
            ApplyStyles();
            InitializeColumnHeader();
            LoadPaymentDetails();
            ConfigurePaymentOptions();
        }

        private void ApplyStyles()
        {
            this.BackColor = Color.FromArgb(247, 250, 252);
        }

        private void InitializeColumnHeader()
        {
            lstServices.Columns.AddRange(new ColumnHeader[] { colService, colCategory, colQty, colUnitPrice, colTotal });
        }

        private void LoadPaymentDetails()
        {
            try
            {
                lblPatientValue.Text = patientName;
                lblBillIdValue.Text = $"#{billId}";
                lblStatusValue.Text = currentStatus;
                lblTotalAmountValue.Text = $"₱{totalAmount:N2}";

                switch (currentStatus.ToUpper())
                {
                    case "PENDING":
                        lblStatusValue.ForeColor = Color.FromArgb(243, 156, 18);
                        break;
                    case "PARTIALLY PAID":
                        lblStatusValue.ForeColor = Color.FromArgb(52, 152, 219);
                        break;
                    case "PAID":
                        lblStatusValue.ForeColor = Color.FromArgb(46, 204, 113);
                        break;
                    case "CANCELLED":
                        lblStatusValue.ForeColor = Color.FromArgb(231, 76, 60);
                        break;
                }

                LoadBillBreakdown();

                decimal amountPaid = GetAmountAlreadyPaid();
                decimal remaining = totalAmount - amountPaid;

                if (currentStatus.ToUpper() == "PARTIALLY PAID" || amountPaid > 0)
                {
                    numPaymentAmount.Value = remaining;
                    numPaymentAmount.Maximum = 999999999;
                    lblRemainingValue.Text = $"₱{remaining:N2}";
                    panelPartialPayment.Visible = true;
                }
                else if (currentStatus.ToUpper() == "PENDING")
                {
                    numPaymentAmount.Value = totalAmount;
                    numPaymentAmount.Maximum = 999999999; 
                    panelPartialPayment.Visible = false; 
                }
                else
                {
                    numPaymentAmount.Value = totalAmount;
                    numPaymentAmount.Maximum = 999999999;
                    panelPartialPayment.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillBreakdown()
        {
            try
            {
                string query = @"
            SELECT 
                b.subtotal,
                b.discount_percent,
                b.discount_amount,
                b.tax_percent,
                b.tax_amount,
                b.amount,
                b.notes
            FROM Billing b
            WHERE b.bill_id = @billId";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    decimal subtotal = Convert.ToDecimal(row["subtotal"]);
                    decimal discountPercent = Convert.ToDecimal(row["discount_percent"]);
                    decimal discountAmount = Convert.ToDecimal(row["discount_amount"]);
                    decimal taxPercent = Convert.ToDecimal(row["tax_percent"]);
                    decimal taxAmount = Convert.ToDecimal(row["tax_amount"]);

                    lblSubtotalValue.Text = $"₱{subtotal:N2}";
                    lblDiscountValue.Text = $"-₱{discountAmount:N2} ({discountPercent}%)";
                    lblTaxValue.Text = $"₱{taxAmount:N2} ({taxPercent}%)";

                    string notes = row["notes"]?.ToString();
                    if (!string.IsNullOrWhiteSpace(notes))
                    {
                        txtBillNotes.Text = FormatBillNotes(notes);
                        panelBillNotes.Visible = true;
                    }
                    else
                    {
                        panelBillNotes.Visible = false;
                    }
                }
                LoadServiceItems();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading bill breakdown: {ex.Message}");
            }
        }

        private string FormatBillNotes(string notes)
        {
            notes = notes.Replace("---", new string('-', 50) + Environment.NewLine);

            notes = notes.Replace("Edited on:", Environment.NewLine + "Edited on:");
            notes = notes.Replace("Previous payments refunded:", Environment.NewLine + "Previous payments refunded:");
            notes = notes.Replace("Edited by user ID:", Environment.NewLine + "Edited by user ID:");
            notes = notes.Replace("Payment records preserved", Environment.NewLine + "Payment records preserved");

            while (notes.Contains(Environment.NewLine + Environment.NewLine + Environment.NewLine))
            {
                notes = notes.Replace(Environment.NewLine + Environment.NewLine + Environment.NewLine,
                                    Environment.NewLine + Environment.NewLine);
            }

            return notes.Trim();
        }

        private void NumPaymentAmount_ValueChanged(object sender, EventArgs e)
        {
            decimal paymentAmount = numPaymentAmount.Value;
            decimal previouslyPaid = GetAmountAlreadyPaid();
            decimal remainingBalance = totalAmount - previouslyPaid;

            decimal appliedAmount = Math.Min(paymentAmount, remainingBalance);
            decimal change = Math.Max(0, paymentAmount - remainingBalance);
            decimal newRemaining = Math.Max(0, remainingBalance - paymentAmount);

            lblRemainingValue.Text = $"₱{newRemaining:N2}";
            lblRemainingValue.ForeColor = newRemaining > 0
                ? Color.FromArgb(243, 156, 18)  
                : Color.FromArgb(46, 204, 113); 

            if (change > 0)
            {
                lblChange.Visible = true;
                lblChangeValue.Visible = true;
                lblChangeValue.Text = $"₱{change:N2}";
            }
            else
            {
                lblChange.Visible = false;
                lblChangeValue.Visible = false;
            }
        }

        private void LoadServiceItems()
        {
            try
            {
                string query = @"
                    SELECT 
                        COALESCE(s.service_name, 'Service') AS service_name,
                        COALESCE(sc.category_name, 'General') AS category_name,
                        bs.quantity,
                        bs.unit_price,
                        (bs.quantity * bs.unit_price) AS total
                    FROM BillServices bs
                    LEFT JOIN Services s ON bs.service_id = s.service_id
                    LEFT JOIN ServiceCategories sc ON bs.category_id = sc.category_id
                    WHERE bs.bill_id = @billId
                    ORDER BY sc.category_name, s.service_name";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                lstServices.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string serviceName = row["service_name"].ToString();
                    string category = row["category_name"].ToString();
                    int quantity = Convert.ToInt32(row["quantity"]);
                    decimal unitPrice = Convert.ToDecimal(row["unit_price"]);
                    decimal total = Convert.ToDecimal(row["total"]);

                    ListViewItem item = new ListViewItem(serviceName);
                    item.SubItems.Add(category);
                    item.SubItems.Add(quantity.ToString());
                    item.SubItems.Add($"₱{unitPrice:N2}");
                    item.SubItems.Add($"₱{total:N2}");

                    lstServices.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading service items: {ex.Message}");
            }
        }

        private decimal GetAmountAlreadyPaid()
        {
            try
            {
                string query = @"
                    SELECT COALESCE(SUM(amount_paid), 0)
                    FROM PaymentTransactions
                    WHERE bill_id = @billId";

                object result = DatabaseHelper.ExecuteScalar(query,
                    new MySqlParameter("@billId", billId));

                return Convert.ToDecimal(result);
            }
            catch
            {
                return 0;
            }
        }

        private void ConfigurePaymentOptions()
        {
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.AddRange(new object[]
            {
                "Cash",
                "Credit Card",
                "Debit Card",
                "Check",
                "Bank Transfer",
                "Insurance",
                "Mixed Payment"
            });
            cmbPaymentMethod.SelectedIndex = 0;

            if (currentStatus.ToUpper() == "PAID")
            {
                DisablePaymentControls();
                btnProcessPayment.Text = "Already Paid";
                btnProcessPayment.Enabled = false;
            }
            else if (currentStatus.ToUpper() == "CANCELLED")
            {
                DisablePaymentControls();
                btnProcessPayment.Text = "Bill Cancelled";
                btnProcessPayment.Enabled = false;
            }
        }

        private void DisablePaymentControls()
        {
            cmbPaymentMethod.Enabled = false;
            numPaymentAmount.Enabled = false;
            txtReferenceNumber.Enabled = false;
            txtPaymentNotes.Enabled = false;
        }

        private void BtnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaymentMethod.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a payment method.", "Payment Method Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPaymentMethod.Focus();
                    return;
                }

                decimal paymentAmount = numPaymentAmount.Value;
                if (paymentAmount <= 0)
                {
                    MessageBox.Show("Payment amount must be greater than zero.", "Invalid Amount",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    numPaymentAmount.Focus();
                    return;
                }

                decimal previouslyPaid = GetAmountAlreadyPaid();
                decimal remainingBalance = totalAmount - previouslyPaid;

                string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();
                string referenceNumber = txtReferenceNumber.Text.Trim();
                string paymentNotes = txtPaymentNotes.Text.Trim();

                decimal actualPayment = Math.Min(paymentAmount, remainingBalance);
                decimal change = paymentAmount - actualPayment;
                bool isPartialPayment = actualPayment < remainingBalance;

                string confirmMessage = "💳 CONFIRM PAYMENT PROCESSING\n\n" +
                    $"Patient: {patientName}\n" +
                    $"Bill ID: #{billId}\n" +
                    $"Amount Tendered: ₱{paymentAmount:N2}\n";

                if (change > 0)
                {
                    confirmMessage += $"Remaining Balance: ₱{remainingBalance:N2}\n";
                    confirmMessage += $"Actual Payment: ₱{actualPayment:N2}\n";
                    confirmMessage += $"💵 CHANGE: ₱{change:N2}\n\n";
                }
                else
                {
                    confirmMessage += $"Payment Amount: ₱{actualPayment:N2}\n";
                }

                confirmMessage += $"Payment Method: {paymentMethod}\n";

                if (!string.IsNullOrWhiteSpace(referenceNumber))
                {
                    confirmMessage += $"Reference #: {referenceNumber}\n";
                }

                if (previouslyPaid > 0)
                {
                    confirmMessage += $"\nPreviously Paid: ₱{previouslyPaid:N2}\n";
                    confirmMessage += $"Total After Payment: ₱{(previouslyPaid + actualPayment):N2}\n";
                }

                if (isPartialPayment)
                {
                    decimal newRemaining = remainingBalance - actualPayment;
                    confirmMessage += $"\n⚠️ PARTIAL PAYMENT\n" +
                        $"Remaining Balance: ₱{remainingBalance:N2}\n" +
                        $"After Payment: ₱{newRemaining:N2}\n";
                }
                else
                {
                    confirmMessage += "\n✓ FULL PAYMENT - Bill will be marked as PAID\n";
                }

                confirmMessage += "\nProcess this payment?";

                DialogResult result = MessageBox.Show(confirmMessage, "Confirm Payment",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                ProcessPayment(actualPayment, paymentAmount, change, paymentMethod, referenceNumber, paymentNotes, isPartialPayment);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessPayment(decimal actualPayment, decimal amountTendered, decimal change,
            string paymentMethod, string referenceNumber, string paymentNotes, bool isPartialPayment)
        {
            try
            {
                decimal previouslyPaid = GetAmountAlreadyPaid();
                decimal totalAmountPaid = previouslyPaid + actualPayment;

                string newStatus;
                if (totalAmountPaid >= totalAmount)
                {
                    newStatus = "Paid";
                }
                else if (totalAmountPaid > 0 && totalAmountPaid < totalAmount)
                {
                    newStatus = "Partially Paid";
                }
                else
                {
                    newStatus = "Pending";
                }

                string updateBillingQuery = @"
            UPDATE Billing 
            SET status = @status,
                payment_method = @paymentMethod
            WHERE bill_id = @billId";

                DatabaseHelper.ExecuteNonQuery(updateBillingQuery,
                    new MySqlParameter("@status", newStatus),
                    new MySqlParameter("@paymentMethod", paymentMethod),
                    new MySqlParameter("@billId", billId));

                string insertTransactionQuery = @"
            INSERT INTO PaymentTransactions 
            (bill_id, patient_id, amount_paid, payment_method, reference_number, 
             payment_notes, processed_by, payment_date)
            VALUES 
            (@billId, @patientId, @amountPaid, @paymentMethod, @referenceNumber,
             @paymentNotes, @processedBy, NOW())";

                DatabaseHelper.ExecuteNonQuery(insertTransactionQuery,
                    new MySqlParameter("@billId", billId),
                    new MySqlParameter("@patientId", patientId),
                    new MySqlParameter("@amountPaid", actualPayment),
                    new MySqlParameter("@paymentMethod", paymentMethod),
                    new MySqlParameter("@referenceNumber",
                        string.IsNullOrWhiteSpace(referenceNumber) ? DBNull.Value : (object)referenceNumber),
                    new MySqlParameter("@paymentNotes",
                        string.IsNullOrWhiteSpace(paymentNotes) ? DBNull.Value : (object)paymentNotes),
                    new MySqlParameter("@processedBy", currentUserId));

                string successMessage = "✅ PAYMENT PROCESSED SUCCESSFULLY\n\n" +
                    $"Patient: {patientName}\n";

                if (change > 0)
                {
                    successMessage += $"Amount Tendered: ₱{amountTendered:N2}\n";
                    successMessage += $"Amount Applied: ₱{actualPayment:N2}\n";
                    successMessage += $"💵 CHANGE TO RETURN: ₱{change:N2}\n\n";
                }
                else
                {
                    successMessage += $"Amount Processed: ₱{actualPayment:N2}\n";
                }

                successMessage += $"Payment Method: {paymentMethod}\n";

                if (!string.IsNullOrWhiteSpace(referenceNumber))
                {
                    successMessage += $"Reference #: {referenceNumber}\n";
                }

                successMessage += $"\nBill Status: {newStatus}\n";

                if (newStatus == "Partially Paid")
                {
                    decimal remaining = totalAmount - totalAmountPaid;
                    successMessage += $"Total Paid: ₱{totalAmountPaid:N2}\n" +
                        $"Remaining Balance: ₱{remaining:N2}\n";
                }
                else if (newStatus == "Paid")
                {
                    successMessage += $"Total Paid: ₱{totalAmountPaid:N2}\n" +
                        "\n✓ Bill fully paid - Patient ready for discharge";
                }

                MessageBox.Show(successMessage, "Payment Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving payment: {ex.Message}\n\nThe payment was not processed.",
                    "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnViewPaymentHistory_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
                    SELECT 
                        DATE_FORMAT(payment_date, '%Y-%m-%d %H:%i') AS 'Date & Time',
                        amount_paid AS 'Amount',
                        payment_method AS 'Method',
                        reference_number AS 'Reference',
                        u.name AS 'Processed By'
                    FROM PaymentTransactions pt
                    LEFT JOIN Users u ON pt.processed_by = u.user_id
                    WHERE pt.bill_id = @billId
                    ORDER BY pt.payment_date DESC";

                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No payment history found for this bill.", "No History",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (Form historyForm = new Form())
                {
                    historyForm.Text = $"Payment History - Bill #{billId}";
                    historyForm.Size = new Size(800, 500);
                    historyForm.StartPosition = FormStartPosition.CenterParent;

                    DataGridView dgv = new DataGridView
                    {
                        DataSource = dt,
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        AllowUserToAddRows = false,
                        SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    };

                    historyForm.Controls.Add(dgv);
                    historyForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}