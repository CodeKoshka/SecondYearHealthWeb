using MySqlConnector;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SaintJosephsHospitalHealthMonitorApp
{
    public partial class BillingForm : Form
    {
        private decimal currentTotal = 0;
        private int? editingBillId = null;

        public BillingForm(int? billId = null)
        {
            InitializeComponent();
            editingBillId = billId;
            LoadPatients();
            LoadServiceCategories();
            SetupServiceItems();

            if (editingBillId.HasValue)
            {
                LoadExistingBill(editingBillId.Value);
                lblTitle.Text = "Edit Invoice";
                this.Text = "Edit Invoice";
            }
        }

        private void LoadPatients()
        {
            string query = @"SELECT p.patient_id, CONCAT(u.name, ' (ID: ', p.patient_id, ')') as display_name,
                           u.name, p.blood_type, p.phone_number
                           FROM Patients p
                           INNER JOIN Users u ON p.user_id = u.user_id
                           WHERE u.is_active = 1
                           ORDER BY u.name";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cmbPatient.DisplayMember = "display_name";
            cmbPatient.ValueMember = "patient_id";
            cmbPatient.DataSource = dt;
        }

        private void LoadServiceCategories()
        {
            cmbServiceCategory.Items.Clear();
            cmbServiceCategory.Items.Add("-- Select Category --");
            cmbServiceCategory.Items.Add("Consultation");
            cmbServiceCategory.Items.Add("Laboratory");
            cmbServiceCategory.Items.Add("Radiology");
            cmbServiceCategory.Items.Add("Procedures");
            cmbServiceCategory.Items.Add("Medications");
            cmbServiceCategory.Items.Add("Room Charges");
            cmbServiceCategory.Items.Add("Emergency Services");
            cmbServiceCategory.Items.Add("Surgery");
            cmbServiceCategory.Items.Add("Other Services");
            cmbServiceCategory.SelectedIndex = 0;
        }

        private void SetupServiceItems()
        {
            lstServices.View = View.Details;
            lstServices.FullRowSelect = true;
            lstServices.GridLines = true;
            lstServices.Columns.Add("Service/Item", 250);
            lstServices.Columns.Add("Category", 120);
            lstServices.Columns.Add("Quantity", 80);
            lstServices.Columns.Add("Unit Price", 100);
            lstServices.Columns.Add("Amount", 100);
        }

        private void CmbServiceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbServiceItem.Items.Clear();
            cmbServiceItem.Items.Add("-- Select Service --");

            string category = cmbServiceCategory.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(category) || category == "-- Select Category --")
                return;

            switch (category)
            {
                case "Consultation":
                    cmbServiceItem.Items.Add("General Consultation - ₱2,500");
                    cmbServiceItem.Items.Add("Specialist Consultation - ₱5,000");
                    cmbServiceItem.Items.Add("Follow-up Consultation - ₱1,500");
                    cmbServiceItem.Items.Add("Emergency Consultation - ₱7,500");
                    break;

                case "Laboratory":
                    cmbServiceItem.Items.Add("Complete Blood Count (CBC) - ₱1,250");
                    cmbServiceItem.Items.Add("Blood Chemistry - ₱2,000");
                    cmbServiceItem.Items.Add("Urinalysis - ₱750");
                    cmbServiceItem.Items.Add("Lipid Profile - ₱1,750");
                    cmbServiceItem.Items.Add("Blood Typing - ₱1,000");
                    cmbServiceItem.Items.Add("Liver Function Test - ₱2,250");
                    cmbServiceItem.Items.Add("Kidney Function Test - ₱2,250");
                    break;

                case "Radiology":
                    cmbServiceItem.Items.Add("X-Ray (Single View) - ₱3,000");
                    cmbServiceItem.Items.Add("X-Ray (Two Views) - ₱4,500");
                    cmbServiceItem.Items.Add("CT Scan - ₱15,000");
                    cmbServiceItem.Items.Add("MRI - ₱25,000");
                    cmbServiceItem.Items.Add("Ultrasound - ₱4,000");
                    cmbServiceItem.Items.Add("Mammogram - ₱6,000");
                    break;

                case "Procedures":
                    cmbServiceItem.Items.Add("ECG - ₱2,000");
                    cmbServiceItem.Items.Add("Echocardiogram - ₱10,000");
                    cmbServiceItem.Items.Add("Endoscopy - ₱20,000");
                    cmbServiceItem.Items.Add("Colonoscopy - ₱22,500");
                    cmbServiceItem.Items.Add("Minor Suturing - ₱3,750");
                    cmbServiceItem.Items.Add("Dressing Change - ₱1,500");
                    break;

                case "Medications":
                    cmbServiceItem.Items.Add("Antibiotics (Generic) - ₱750");
                    cmbServiceItem.Items.Add("Pain Relief Medication - ₱500");
                    cmbServiceItem.Items.Add("IV Fluids - ₱1,250");
                    cmbServiceItem.Items.Add("Vaccine/Immunization - ₱1,750");
                    cmbServiceItem.Items.Add("Custom Medication (Enter Details)");
                    break;

                case "Room Charges":
                    cmbServiceItem.Items.Add("Private Room (per day) - ₱10,000");
                    cmbServiceItem.Items.Add("Semi-Private Room (per day) - ₱6,000");
                    cmbServiceItem.Items.Add("Ward Bed (per day) - ₱4,000");
                    cmbServiceItem.Items.Add("ICU (per day) - ₱25,000");
                    cmbServiceItem.Items.Add("Emergency Room - ₱7,500");
                    break;

                case "Emergency Services":
                    cmbServiceItem.Items.Add("Emergency Room Fee - ₱7,500");
                    cmbServiceItem.Items.Add("Ambulance Service - ₱10,000");
                    cmbServiceItem.Items.Add("Emergency Surgery - ₱100,000");
                    cmbServiceItem.Items.Add("Trauma Care - ₱15,000");
                    break;

                case "Surgery":
                    cmbServiceItem.Items.Add("Minor Surgery - ₱50,000");
                    cmbServiceItem.Items.Add("Major Surgery - ₱150,000");
                    cmbServiceItem.Items.Add("Operating Room Fee - ₱25,000");
                    cmbServiceItem.Items.Add("Anesthesia - ₱20,000");
                    cmbServiceItem.Items.Add("Surgical Supplies - ₱10,000");
                    break;

                case "Other Services":
                    cmbServiceItem.Items.Add("Physical Therapy Session - ₱3,000");
                    cmbServiceItem.Items.Add("Dietary Consultation - ₱2,000");
                    cmbServiceItem.Items.Add("Medical Certificate - ₱1,000");
                    cmbServiceItem.Items.Add("Medical Records Copy - ₱500");
                    cmbServiceItem.Items.Add("Custom Service (Enter Details)");
                    break;
            }
            cmbServiceItem.SelectedIndex = 0;
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            if (cmbServiceCategory.SelectedIndex <= 0 || cmbServiceItem.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a service category and item.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string serviceItem = cmbServiceItem.SelectedItem.ToString();
            string category = cmbServiceCategory.SelectedItem.ToString();

            decimal unitPrice = 0;
            string serviceName = serviceItem;

            if (serviceItem.Contains(" - ₱"))
            {
                string[] parts = serviceItem.Split(new[] { " - ₱" }, StringSplitOptions.None);
                serviceName = parts[0];
                if (parts.Length > 1)
                {
                    string priceStr = parts[1].Replace(",", "");
                    decimal.TryParse(priceStr, out unitPrice);
                }
            }

            if (serviceItem.Contains("Custom") || serviceItem.Contains("Enter Details"))
            {
                using (var inputForm = new InputDialog("Enter Service Details", "Service Name:", serviceName))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        serviceName = inputForm.InputValue;
                    }
                    else return;
                }

                using (var priceForm = new InputDialog("Enter Price", "Unit Price:", "0"))
                {
                    if (priceForm.ShowDialog() == DialogResult.OK)
                    {
                        if (!decimal.TryParse(priceForm.InputValue, out unitPrice))
                        {
                            MessageBox.Show("Invalid price entered.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else return;
                }
            }

            int quantity = (int)numQuantity.Value;
            decimal amount = unitPrice * quantity;

            ListViewItem item = new ListViewItem(serviceName);
            item.SubItems.Add(category);
            item.SubItems.Add(quantity.ToString());
            item.SubItems.Add("₱" + unitPrice.ToString("N2"));
            item.SubItems.Add("₱" + amount.ToString("N2"));
            lstServices.Items.Add(item);

            UpdateTotal();

            cmbServiceItem.SelectedIndex = 0;
            numQuantity.Value = 1;
        }

        private void BtnRemoveService_Click(object sender, EventArgs e)
        {
            if (lstServices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a service to remove.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ListViewItem item in lstServices.SelectedItems)
            {
                lstServices.Items.Remove(item);
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            currentTotal = 0;
            foreach (ListViewItem item in lstServices.Items)
            {
                string amountStr = item.SubItems[4].Text.Replace("₱", "").Replace(",", "");
                decimal.TryParse(amountStr, out decimal amount);
                currentTotal += amount;
            }

            decimal discount = numDiscount.Value;
            decimal tax = numTax.Value;

            decimal discountAmount = currentTotal * (discount / 100);
            decimal subtotalAfterDiscount = currentTotal - discountAmount;
            decimal taxAmount = subtotalAfterDiscount * (tax / 100);
            decimal grandTotal = subtotalAfterDiscount + taxAmount;

            lblSubtotal.Text = $"Subtotal: ₱{currentTotal:N2}";
            lblDiscountAmount.Text = $"Discount ({discount}%): -₱{discountAmount:N2}";
            lblTaxAmount.Text = $"Tax ({tax}%): ₱{taxAmount:N2}";
            lblGrandTotal.Text = $"Grand Total: ₱{grandTotal:N2}";
        }

        private void NumDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void NumTax_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue == null)
            {
                MessageBox.Show("Please select a patient.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstServices.Items.Count == 0)
            {
                MessageBox.Show("Please add at least one service/item.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int patientId = Convert.ToInt32(cmbPatient.SelectedValue);
                string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";
                string status = cmbStatus.SelectedItem?.ToString() ?? "Pending";

                decimal discount = numDiscount.Value;
                decimal tax = numTax.Value;
                decimal discountAmount = currentTotal * (discount / 100);
                decimal subtotalAfterDiscount = currentTotal - discountAmount;
                decimal taxAmount = subtotalAfterDiscount * (tax / 100);
                decimal grandTotal = subtotalAfterDiscount + taxAmount;

                string description = txtNotes.Text + "\n\nServices:\n";
                foreach (ListViewItem item in lstServices.Items)
                {
                    description += $"- {item.SubItems[0].Text} ({item.SubItems[1].Text}) x{item.SubItems[2].Text} @ {item.SubItems[3].Text} = {item.SubItems[4].Text}\n";
                }

                if (editingBillId.HasValue)
                {
                    string updateQuery = @"UPDATE Billing 
                                         SET patient_id = @patientId, 
                                             amount = @amount,
                                             subtotal = @subtotal,
                                             discount_percent = @discount,
                                             discount_amount = @discountAmount,
                                             tax_percent = @tax,
                                             tax_amount = @taxAmount,
                                             description = @description,
                                             payment_method = @paymentMethod,
                                             status = @status,
                                             notes = @notes
                                         WHERE bill_id = @billId";

                    DatabaseHelper.ExecuteNonQuery(updateQuery,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@amount", grandTotal),
                        new MySqlParameter("@subtotal", currentTotal),
                        new MySqlParameter("@discount", discount),
                        new MySqlParameter("@discountAmount", discountAmount),
                        new MySqlParameter("@tax", tax),
                        new MySqlParameter("@taxAmount", taxAmount),
                        new MySqlParameter("@description", description),
                        new MySqlParameter("@paymentMethod", paymentMethod),
                        new MySqlParameter("@status", status),
                        new MySqlParameter("@notes", txtNotes.Text),
                        new MySqlParameter("@billId", editingBillId.Value));

                    MessageBox.Show("Invoice updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string insertQuery = @"INSERT INTO Billing 
                                         (patient_id, amount, subtotal, discount_percent, discount_amount,
                                          tax_percent, tax_amount, description, payment_method, status, notes, bill_date)
                                         VALUES 
                                         (@patientId, @amount, @subtotal, @discount, @discountAmount,
                                          @tax, @taxAmount, @description, @paymentMethod, @status, @notes, NOW())";

                    DatabaseHelper.ExecuteNonQuery(insertQuery,
                        new MySqlParameter("@patientId", patientId),
                        new MySqlParameter("@amount", grandTotal),
                        new MySqlParameter("@subtotal", currentTotal),
                        new MySqlParameter("@discount", discount),
                        new MySqlParameter("@discountAmount", discountAmount),
                        new MySqlParameter("@tax", tax),
                        new MySqlParameter("@taxAmount", taxAmount),
                        new MySqlParameter("@description", description),
                        new MySqlParameter("@paymentMethod", paymentMethod),
                        new MySqlParameter("@status", status),
                        new MySqlParameter("@notes", txtNotes.Text));

                    MessageBox.Show("Invoice created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving invoice: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExistingBill(int billId)
        {
            try
            {
                string query = @"SELECT * FROM Billing WHERE bill_id = @billId";
                DataTable dt = DatabaseHelper.ExecuteQuery(query,
                    new MySqlParameter("@billId", billId));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    cmbPatient.SelectedValue = row["patient_id"];
                    txtNotes.Text = row["notes"]?.ToString() ?? "";

                    if (row["discount_percent"] != DBNull.Value)
                        numDiscount.Value = Convert.ToDecimal(row["discount_percent"]);

                    if (row["tax_percent"] != DBNull.Value)
                        numTax.Value = Convert.ToDecimal(row["tax_percent"]);

                    if (row["payment_method"] != DBNull.Value)
                        cmbPaymentMethod.SelectedItem = row["payment_method"].ToString();

                    if (row["status"] != DBNull.Value)
                        cmbStatus.SelectedItem = row["status"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bill: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            if (lstServices.Items.Count == 0)
            {
                MessageBox.Show("Please add services before generating preview.", "No Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string preview = GenerateInvoicePreview();
            MessageBox.Show(preview, "Invoice Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateInvoicePreview()
        {
            string patientName = cmbPatient.Text.Split('(')[0].Trim();
            string preview = $"SAINT JOSEPH'S HOSPITAL\n";
            preview += $"INVOICE PREVIEW\n";
            preview += $"{'=',50}\n\n";
            preview += $"Patient: {patientName}\n";
            preview += $"Date: {DateTime.Now:yyyy-MM-dd HH:mm}\n";
            preview += $"Payment Method: {cmbPaymentMethod.SelectedItem}\n";
            preview += $"Status: {cmbStatus.SelectedItem}\n\n";
            preview += $"{'=',50}\n";
            preview += $"SERVICES:\n";
            preview += $"{'=',50}\n\n";

            foreach (ListViewItem item in lstServices.Items)
            {
                preview += $"{item.SubItems[0].Text}\n";
                preview += $"  Category: {item.SubItems[1].Text}\n";
                preview += $"  Qty: {item.SubItems[2].Text} x {item.SubItems[3].Text} = {item.SubItems[4].Text}\n\n";
            }

            preview += $"{'=',50}\n";
            preview += lblSubtotal.Text + "\n";
            preview += lblDiscountAmount.Text + "\n";
            preview += lblTaxAmount.Text + "\n";
            preview += $"{'=',50}\n";
            preview += lblGrandTotal.Text + "\n";

            if (!string.IsNullOrWhiteSpace(txtNotes.Text))
            {
                preview += $"\nNotes: {txtNotes.Text}\n";
            }

            return preview;
        }
    }

    public class InputDialog : Form
    {
        private TextBox txtInput;
        private Button btnOk;
        private Button btnCancel;
        public string InputValue { get; private set; }

        public InputDialog(string title, string prompt, string defaultValue = "")
        {
            this.Text = title;
            this.Size = new Size(400, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblPrompt = new Label();
            lblPrompt.Text = prompt;
            lblPrompt.Location = new Point(20, 20);
            lblPrompt.Size = new Size(350, 20);
            this.Controls.Add(lblPrompt);

            txtInput = new TextBox();
            txtInput.Location = new Point(20, 45);
            txtInput.Size = new Size(340, 23);
            txtInput.Text = defaultValue;
            this.Controls.Add(txtInput);

            btnOk = new Button();
            btnOk.Text = "OK";
            btnOk.Location = new Point(200, 80);
            btnOk.Size = new Size(75, 30);
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Click += (s, e) => { InputValue = txtInput.Text; };
            this.Controls.Add(btnOk);

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(285, 80);
            btnCancel.Size = new Size(75, 30);
            btnCancel.DialogResult = DialogResult.Cancel;
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}